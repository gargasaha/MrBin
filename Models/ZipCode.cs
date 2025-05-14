using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MrBin.Models;
namespace Models{
    public class ZipCode
    {   
        [Key] 
        public int ?ZId { get; set; }
        [Required]
        [MaxLength(6)]
        public string ?ZCode { get; set; }
        [Required]
        [MaxLength(5)]
        public string ?DistId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ?AreaName { get; set; }
    }
}