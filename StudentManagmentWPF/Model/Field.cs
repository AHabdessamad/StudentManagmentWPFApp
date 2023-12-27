using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentWPF.Model
{
    class Field
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Responsable { get; set; }
    }
}
