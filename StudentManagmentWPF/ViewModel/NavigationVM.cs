using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using StudentManagmentWPF.Utilities;
using StudentManagmentWPF.ViewModel;
using System.Transactions;

namespace StudentManagmentWPF.ViewModel
{
    class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public bool isAdmin = false;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand StudentCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand FieldCommand { get; set; }
        public ICommand StatisticCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Student(object obj) => CurrentView = new StudentVM();
        private void User(object obj) => CurrentView = new UserVM();
        private void Field(object obj) => CurrentView = new FieldVM();
        private void Statistic(object obj) => CurrentView = new StatisticVM();
        

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            StudentCommand = new RelayCommand(Student);
            UserCommand = new RelayCommand(User);
            FieldCommand = new RelayCommand(Field);
            StatisticCommand = new RelayCommand(Statistic);

            // Startup Page
            _currentView = new FieldVM();
        }
    }
}