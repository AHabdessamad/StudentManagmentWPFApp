using StudentManagmentWPF.Data;
using StudentManagmentWPF.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentManagmentWPF.ViewModel
{
    class LoginVM : INotifyPropertyChanged
    {
        //the command that handel the Login click
        public ICommand LoginCommand { get; private set; }

        // properties
        //_____username______
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged();
                }
            }
        }

        //_____password______
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }

        //_____error______
        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public LoginVM()
        {
            LoginCommand = new RelayCommand(LoginMethod);
        }

        private void LoginMethod(object obj)
        {
            if (ValidateCredentials())
            {
                using (SchoolDbContext dbContext = new SchoolDbContext())
                {

                    var user = dbContext.Users.SingleOrDefault(u => u.Username == Username && u.Password == Password);

                    if (user != null && user.IsAdmin)
                    {

                        Window app = new MainWindow(1);
                        app.Show();
                        if (obj is Window loginWindow)
                        {
                            loginWindow.Close(); // Close the login window
                        }
                    }
                    else
                    {
                        ErrorMessage = "Invalid credentials or non-admin user.";
                    }
                }
            }
            else
            {
                ErrorMessage = "Username and password are required.";
            }
        }

        private bool ValidateCredentials()
        {
            // Implement your authentication logic here
            // For simplicity, you can add basic validation (e.g., check if username and password are not empty)
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
