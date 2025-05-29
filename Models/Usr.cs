using System.ComponentModel.DataAnnotations;

namespace MrBin.Models
{
    public class Usr
    {
        [Required]
        [StringLength(100)]
        public string? UFname { get; set; }

        [Required]
        [StringLength(100)]
        public string? ULname { get; set; }

        [Required]
        public int? ZipCode { get; set; }

        [Required]
        [StringLength(100)]
        public string? UEmail { get; set; }

        [Required]
        public string? UProfileImage { get; set; }

        [Required]
        [StringLength(100)]
        public string? UPassword { get; set; }

    }
}