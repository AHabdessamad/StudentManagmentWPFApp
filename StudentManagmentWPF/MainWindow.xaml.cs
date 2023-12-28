using StudentManagmentWPF.Data;
using StudentManagmentWPF.Model;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using WpfLibrary.Data;

namespace StudentManagmentWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly SchoolDbContext _db;
        public MainWindow()
        {
            _db = new SchoolDbContext();
            List<Student> students = _db.Students.ToList<Student>();
            InitializeComponent();
        }
        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}