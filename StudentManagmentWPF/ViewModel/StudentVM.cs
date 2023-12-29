using SharpDX.DirectWrite;
using StudentManagmentWPF.Data;
using StudentManagmentWPF.Model;
using StudentManagmentWPF.Utilities;
using StudentManagmentWPF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentManagmentWPF.ViewModel
{
    class StudentVM : ViewModelBase
    {
        SchoolDbContext _db = new SchoolDbContext();
        private object _currentView;

        Student _selectedItem;
        public Student SelectedItem { get { return _selectedItem; } set { _selectedItem = value; OnPropertyChanged(); } }


        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand AddStudentCommand { get; set; }
        public ICommand ModifyStudentCommand { get; set; }
        public ICommand deleteStudentCommand { get; set; }
        private void AddStudent(object obj)
        {
            // Logic to navigate or update content
            CurrentView = new AddStudentUI();
        }

        private void ModifyStudent(object obj)
        {
            if (SelectedItem == null) return;
            CurrentView = new EditStudentUI(SelectedItem);
        }

        private void DeleteStudent(object obj)
        {
            _db.Remove(SelectedItem);
            _db.SaveChanges();
            Students = new ObservableCollection<Student>(GetStudents(SelectedField?.Nom));
        }
        public StudentVM()
        {
            _db = new SchoolDbContext();
            Students = new ObservableCollection<Student>(GetStudents());
            AddStudentCommand = new RelayCommand(AddStudent);
            deleteStudentCommand = new RelayCommand(DeleteStudent);
            ModifyStudentCommand = new RelayCommand(ModifyStudent);

            // Initialize with default content
            _currentView = null;
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

        private Field? _selectedField;
        public Field? SelectedField
        {
            get { return _selectedField; }
            set
            {
                if (_selectedField != value)
                {
                    _selectedField = value;
                    Responsable = value.Responsable != null ? $"Le Responsable de ce Filière est: {value.Responsable}" : "";

                    this.Students = new ObservableCollection<Student>(GetStudents(value.Nom));           
                }
            }
        }

        private string _responsable;
        public string Responsable { get { return _responsable; } 
            set { _responsable = value; } }


        private List<Student> GetStudents(string? FieldName = "Tous Les Filières")
        {
            if(FieldName?.CompareTo("Tous Les Filières") != 0 && FieldName != null) return _db.Students.Where(x => x.Field.Nom ==  FieldName).ToList();
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
