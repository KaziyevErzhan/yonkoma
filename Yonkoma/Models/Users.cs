using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Yonkoma.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указан Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}