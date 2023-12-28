using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentWPF.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Gender Sexe { get; set; }
        public DateOnly DateNaissance { get; set; }
        public bool IsAdmin { get; set; }
        public byte[]? ImageProfile { get; set; }
    }
}
