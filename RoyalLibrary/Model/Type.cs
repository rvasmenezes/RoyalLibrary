﻿using System.ComponentModel.DataAnnotations;

namespace RoyalLibrary.API.Model
{
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }
    }
}

