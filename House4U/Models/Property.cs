using System;
using System.ComponentModel.DataAnnotations;

namespace House4U.Models
{
    public class Property
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Address { get; set; }
        [Range(1, int.MaxValue)]
        public int NumRooms { get; set; }
        [Required]
        public bool FullyDelegated { get; set; }
        [Required]
        [EmailAddress]
        public string ClientMail { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
    }
}
