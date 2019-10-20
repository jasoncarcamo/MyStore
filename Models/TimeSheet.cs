using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("Employee")]
        public long EmployeeId { get; set; }

    }
}
