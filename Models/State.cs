using System.ComponentModel.DataAnnotations;
using MrBin.Models;
namespace Models{
    public class State
    {   
        [Key] 
        public string ?StateId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ?StateName { get; set; }
    }
}