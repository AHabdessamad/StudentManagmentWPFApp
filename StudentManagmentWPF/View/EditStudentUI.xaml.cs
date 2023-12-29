using StudentManagmentWPF.Model;
using StudentManagmentWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentManagmentWPF.View
{
    /// <summary>
    /// Interaction logic for EditStudentUI.xaml
    /// </summary>
    public partial class EditStudentUI : UserControl
    {
        public Student student;
        public EditStudentUI(Student student)
        {
            InitializeComponent();
            this.student = student;
            // Access ViewModel
            var viewModel = new EditStudentVM();
            viewModel.Id = student.Id;
            viewModel.Nom = student.Nom;
            viewModel.Prenom = student.Prenom;
            viewModel.Cne = student.Cne;
            viewModel.ImgByte = student?.ImageProfile;
            viewModel.DateNaissance = student.DateNaissance;
            viewModel.SexeF = student.Sexe == Gender.Femme;
            viewModel.SexeH = student.Sexe == Gender.Homme;
            viewModel.Field = student.Field;
            DataContext = viewModel;
        }
    }
}
