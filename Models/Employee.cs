using System;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class Employee
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        [Range(minimum: 0.01, maximum: (double)decimal.MaxValue)]
        public decimal Wage { get; set; }

        [Required]
        public bool IsCurrentEmployee { get; set; }

        [Required]
        public double Password{get; set;}
    }
}
