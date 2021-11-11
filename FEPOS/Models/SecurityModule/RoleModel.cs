﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEPOS.Models.SecurityModule
{
    public class RoleModel
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
        [MaxLength(100)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;

        [DisplayName("Descripcion")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        private bool removed;

        [DisplayName("Eliminado")]
        public bool Removed
        {
            get { return removed; }
            set { removed = value; }
        }
    }
}