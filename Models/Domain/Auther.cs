using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Domain
{
    public class Auther
    {
        public int Id { get; set; }

        [Required]
        public string AutherName { get; set; }
    }
}
