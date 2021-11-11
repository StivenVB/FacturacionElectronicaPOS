using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEPOS.Models.SecurityModule
{
    public class UserModel : ModelBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        [DisplayName("Nombre")]
        [Required()]
        [MaxLength(50)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string lastname;

        [DisplayName("Apellidos")]
        [Required()]
        [MaxLength(100)]
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }


        private string cellphone;

        [DisplayName("Celular")]
        [MaxLength(30)]
        public string Cellphone
        {
            get { return cellphone; }
            set { cellphone = value; }
        }

        private string document;

        [DisplayName("Documento")]
        [Required()]
        [MaxLength(50)]
        public string Document
        {
            get { return document; }
            set { document = value; }
        }

        private string city;

        [DisplayName("Ciudad")]
        [MaxLength(100)]
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string email;

        [DisplayName("Correo Electronico")]
        [Required()]
        [MaxLength(100)]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private bool removed;

        public bool Removed
        {
            get { return removed; }
            set { removed = value; }
        }

        private IEnumerable<RoleModel> roles;

        [DisplayName("Rol")]
        [Required()]
        public IEnumerable<RoleModel> Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        private string token;

        public string Token
        {
            get { return token; }
            set { token = value; }
        }
    }
}