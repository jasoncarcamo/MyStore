using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class Menu
    {
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
