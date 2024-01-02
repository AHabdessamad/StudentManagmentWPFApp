using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentManagmentWPF.Model
{
    public class Field
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Responsable { get; set; }
        public Field()
        {

        }
        public Field(int Id, string Nom, string Responsable)
        {
            this.Id = Id;
            this.Nom = Nom;
            this.Responsable = Responsable;
        }
    }
}
