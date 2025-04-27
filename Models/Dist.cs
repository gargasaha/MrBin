using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MrBin.Models;
namespace Models{
    public class Dist
    {   
        [Key] 
        public string ?DistId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ?DistName { get; set; }
        [ForeignKey("State")]
        public string ?StateId { get; set; }
    }
}