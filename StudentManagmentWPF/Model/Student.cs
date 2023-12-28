using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentWPF.Model
{
    public enum Gender
    {
        Homme,
        Femme
    }
    public class Student
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Gender Sexe { get; set; }
        public DateOnly DateNaissance { get; set; }
        public string Cne { get; set; }
        public byte[]? ImageProfile { get; set; }
        public virtual Field Field { get; set; }

    }
}
