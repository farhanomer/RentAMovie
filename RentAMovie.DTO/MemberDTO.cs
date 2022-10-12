using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentAMovie.DTO
{
    public class MemberDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "YOu Password is ")]
        public string Password { get; set; }
        public string Address { get; set; }
        [Required]
        public int CityId { get; set; }
        public CityDTO City { get; set; }
    }


    public class RegisterDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Your Password should be 8-15 characters long.")]
        public string Password { get; set; }
        public string Address { get; set; }
        [Required]
        public int CityId { get; set; }
        public string Role { get; set; }
    }

    public class SignInDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "YOu Password is ")]
        public string Password { get; set; }
    }
}
