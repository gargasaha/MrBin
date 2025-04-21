using System.ComponentModel.DataAnnotations;

namespace MrBin.Models
{
    public class Usr
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(100)]
        public string ?UserName { get; set; }
        [Required]
        [StringLength(2)]
        public string ?UserStateId { get; set; }
        [Required]
        [StringLength(3)]
        public string ?UserDistId { get; set; }
        
        public byte[] ?UserProfileImage { get; set; }
        [Required]
        public byte[] ?Password { get; set; }
    }
}