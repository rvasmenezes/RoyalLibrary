using Microsoft.EntityFrameworkCore;

namespace RoyalLibrary.API.Helpers
{
    public static class Pagination
    {
        public static async Task<PaginatedResult<T>> GetPagedAsync<T>(this IQueryable<T> query, int pagina, int itensPorPagina) where T : class
        {
            var result = new PaginatedResult<T>
            {
                Page = pagina,
                ItemsPerPage = itensPorPagina,
                TotalRegisters = query.Count()
            };

            var pageCount = (double)result.TotalRegisters / itensPorPagina;
            result.TotalPages = (int)Math.Ceiling(pageCount);
            var skip = (pagina - 1) * itensPorPagina;
            result.Result = await query.Skip(skip).Take(itensPorPagina).ToListAsync();

            return result;
        }
    }
}
