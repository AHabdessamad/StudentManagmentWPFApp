using Microsoft.Win32;
using StudentManagmentWPF.Data;
using StudentManagmentWPF.Model;
using StudentManagmentWPF.Utilities;
using StudentManagmentWPF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentManagmentWPF.ViewModel
{
    class AddStudentVM : ViewModelBase
    {

        string _nom;
        public string Nom { get { return _nom; } set { _nom = value; } }
        string _prenom;
        public string Prenom { get { return _prenom; } set { _prenom = value; } }
        bool _sexeH;
        public bool SexeH { get { return _sexeH; } set { _sexeH = value; } } 
        bool _sexeF;
        public bool SexeF { get { return _sexeF; } set { _sexeF = value; } }
        DateOnly _dateNaissance;
        public DateOnly DateNaissance { get { return _dateNaissance; } set { _dateNaissance = value; } }
        string _cne;
        public string Cne { get { return _cne; } set { _cne = value; } }
        string _img;
        public string Img { get { return _img; } set { _img = value; } }
        Field _field;
        public Field Field { get { return _field; } set { _field = value; } }

        private ObservableCollection<Field> _fields;
        public ObservableCollection<Field> Fields
        {
            get { return new ObservableCollection<Field>(GetAllFields()); }
            set
            {
                _fields = value;
            }

        }

        private List<Field> GetAllFields()
        {
            var fields = _db.Fields.ToList<Field>();
            return fields;
        }

        public ICommand chooseImageCommand { get; set; }
        private void ChooseImage(object obj)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // The user selected an image file, and you can access its path using openFileDialog.FileName
                Img = openFileDialog.FileName;
            }
            else
            {
                // The user canceled the operation
                return;
            }
        }




        private object _currentView;
        SchoolDbContext _db;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }


        public AddStudentVM()
        {
            CancelStudentCommand = new RelayCommand(Student);
            AddStudentCommand = new RelayCommand(AddStudentMethod);
            chooseImageCommand = new RelayCommand(ChooseImage);
            _db = new SchoolDbContext();

            // Initialize with default content
            _currentView = null;
        }

        public void AddStudentMethod(object obj)
        {
            Gender choosedSexe = this.SexeF ? Gender.Femme : Gender.Homme;
            byte[] imgByte = LoadImageBytes(Img);
            if (imgByte != null)
            {
                // Image loaded successfully
            }
            else
            {
                Console.WriteLine("Failed to load image.");
                return;
                // Failed to load image
            }
            Student addedStudent = new Student { Nom=this.Nom, Prenom=this.Prenom, Sexe=choosedSexe, DateNaissance=this.DateNaissance, Cne=this.Cne, ImageProfile= imgByte, Field=this.Field};
            _db.Add(addedStudent);
            _db.SaveChanges();
            CurrentView = new StudentUI();

        }

        public ICommand CancelStudentCommand { get; set; }
        public ICommand AddStudentCommand { get; set; }
        private void Student(object obj)
        {
            // Logic to navigate or update content
            CurrentView = new StudentUI();

        }



        //Loading an image
        byte[] LoadImageBytes(string imagePath)
        {
            try
            {
                // Check if the file exists
                if (File.Exists(imagePath))
                {
                    // Read all bytes from the file
                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    return imageBytes;
                }
                else
                {
                    Console.WriteLine("File not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., file not found, permission issues)
                Console.WriteLine($"Error loading image: {ex.Message}");
                return null;
            }
        }
    }
}
