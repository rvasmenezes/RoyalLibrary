using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RoyalLibrary.API.Data;
using RoyalLibrary.API.DTOs;
using RoyalLibrary.API.Helpers;
using RoyalLibrary.API.Model;
using RoyalLibrary.API.Services;
using RoyalLibrary.WEB.ViewModel;
using System.Web;

namespace RoyalLibrary.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly EFContext _context;
        public readonly BookServices _bookServices;

        public HomeController(EFContext context, BookServices bookServices)
        {
            _context = context;
            _bookServices = bookServices;
        }

        public async Task<IActionResult> IndexAsync(SearchBookDto dto)
        {
            var viewModel = new BookListViewModel
            {
                //BookListPaginated = await _bookServices.GetPaginated(dto),
                BookListPaginated = await GetBooksApi(dto),
                AuthorList = await _context.Author.ToListAsync(),
                searchBookDto = dto
            };

            return View(viewModel);
        }

        static async Task<PaginatedResult<Book>> GetBooksApi(SearchBookDto dto)
        {
            using (HttpClient httpClient = new())
            {

                string queryString = ToQueryString(dto);

                string apiUrl = $"http://localhost:32768/Book?{queryString}";

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string conteudo = await response.Content.ReadAsStringAsync();

                        if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                            return new PaginatedResult<Book>();

                        return JsonConvert.DeserializeObject<PaginatedResult<Book>>(conteudo);
                    }
                    else
                    {
                        Console.WriteLine("Request Error: " + response.StatusCode);
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Request Error: " + e.Message);
                }

                return null;
            }
        }

        static string ToQueryString(SearchBookDto dto)
        {
            var properties = dto.GetType().GetProperties();

            var keyValuePairs = properties
                .Select(property => $"{property.Name}={HttpUtility.UrlEncode(property.GetValue(dto)?.ToString() ?? "")}");

            return string.Join("&", keyValuePairs);
        }
    }
}
