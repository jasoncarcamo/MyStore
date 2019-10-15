﻿using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class MenuItem
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Inventory { get; set; }

        [Required]
        [Range(minimum: 0.01, maximum: (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public long MenuId { get; set; }
    }
}
