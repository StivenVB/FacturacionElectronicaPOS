using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEPOS.Models.SecurityModule
{
    public class LoginModel
    {
        private string username;

        [DisplayName("Nombre de Usuario o Correo Electronico")]
        [Required()]
        [MaxLength(100)]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        [DisplayName("Contraseña")]
        [Required()]
        [MaxLength(100)]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }


    }
}