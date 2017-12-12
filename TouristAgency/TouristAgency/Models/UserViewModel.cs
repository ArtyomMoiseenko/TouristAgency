using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToristAgency.Contracts;

namespace TouristAgency.Models
{
    public class UserViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [ScaffoldColumn(false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [ScaffoldColumn(false)]
        public int RoleId { get; set; }
        [Display(Name = "Роль в системе")]
        public string RoleName { get; set; }
        [Display(Name = "Роль в системе")]
        public IEnumerable<Role> Roles { get; set; }
    }

    public enum RoleType
    {
        ADMIN = 1,
        MANAGER,
        USER
    }
}