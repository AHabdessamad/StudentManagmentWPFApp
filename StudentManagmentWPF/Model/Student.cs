using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentWPF.Model
{
    enum Gender
    {
        Homme,
        Femme
    }
    class Student
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Gender Sexe { get; set; }
        public DateOnly DateNaissance { get; set; }
        [Required]
        public string Cne { get; set; }
        [Column(TypeName = "LongBlob")]
        public byte[]? Image { get; set; }

    }
}
