﻿using RoyalLibrary.API.DTOs;
using RoyalLibrary.API.Helpers;
using RoyalLibrary.API.Model;

namespace RoyalLibrary.WEB.ViewModel
{
    public class BookListViewModel
    {
        public PaginatedResult<Book> BookListPaginated { get; set; }

        public List<Author> AuthorList { get; set; }

        public SearchBookDto searchBookDto { get; set; }

        /*public int? AuthorId { get; set; }
        public string? ISBN { get; set; }
        public bool? WantRead { get; set; }*/
    }
}
