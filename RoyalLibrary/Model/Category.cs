﻿using System.ComponentModel.DataAnnotations;

namespace RoyalLibrary.API.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}

