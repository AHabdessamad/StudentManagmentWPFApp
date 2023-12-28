using SharpDX.DirectWrite;
using StudentManagmentWPF.Data;
using StudentManagmentWPF.Model;
using StudentManagmentWPF.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentWPF.ViewModel
{
    class StudentVM : ViewModelBase
    {
        SchoolDbContext _db = new SchoolDbContext();
        public StudentVM()
        {
            _db = new SchoolDbContext();
            Students = new ObservableCollection<Student>(GetStudents());
        }
        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        { 
            get { return _students; } 
            set {
                _students = value;
                OnPropertyChanged(nameof(Students));

            } 
        }

        private ObservableCollection<Field> _fields;
        public ObservableCollection<Field> Fields
        { get { return new ObservableCollection<Field>(GetAllFields()); }
            set
            {
                _fields = value;
            }
        
        }

        private Field _selectedField;
        public Field SelectedField
        {
            get { return _selectedField; }
            set
            {
                if (_selectedField != value)
                {
                    _selectedField = value;

                    this.Students = new ObservableCollection<Student>(GetStudents(value.Nom));           
                }
            }
        }

        private string _myProperty;
        public string MyProperty { get; set; }


        private List<Student>  GetStudents(string FieldName = null)
        {
            if(FieldName != null) return _db.Students.Where(x => x.Field.Nom ==  FieldName).ToList();
            return _db.Students.ToList<Student>();
        }
        private List<Field> GetAllFields()
        {
            var fields = _db.Fields.ToList<Field>();
            fields.Insert(0, new Field { Nom = "Tous Les Filières" });
            return fields;
        }
    }
}
