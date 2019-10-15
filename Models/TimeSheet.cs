using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class TimeSheet
    {
        public long Id { get; set; }
        
        [Required]
        public float Hours { get; set; }

        [Required]
        public float Rate { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public long EmployeeId { get; set; }
        
    }
}
