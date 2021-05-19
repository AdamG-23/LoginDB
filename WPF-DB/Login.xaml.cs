using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_DB.DataSetTableAdapters;

namespace WPF_DB
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        public string name;
        public string Password;
        private UsersTableAdapter adapter = new UsersTableAdapter();
        private DataSet dataSet = new DataSet();

        public Login()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adapter.Fill(dataSet.Users);
            DataContext = dataSet.Users.DefaultView;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
           //IEnumerable<DataSet.UsersDataTable> usersRows = (IEnumerable<DataSet.UsersDataTable>)dataSet.Users;
            var query = from user in dataSet.Users
                        where (user.Name == txtName.Text)
                        where (user.Password == txtPassword.Text)
                        select user;

            if (query.Count() > 0)
            {
                MainWindow main = new MainWindow();
                main.Show();
                main.Close();
            }
            else
            {
                MessageBoxResult textBox = MessageBox.Show("User does not exist", "Submit", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtName.Text = "";
                txtPassword.Text = "";
            }
           //usersRows = from Users in Name where Name = txtName.Text;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            DataSet.UsersRow row = (DataSet.UsersRow)dataSet.Users.NewRow();

            row.Name = txtName.Text;
            row.Password = txtPassword.Text;
             

            dataSet.Users.AddUsersRow(row);
            adapter.Update(dataSet);

            MessageBoxResult message = MessageBox.Show("User was registered", "Register", MessageBoxButton.OK, MessageBoxImage.Information);
            // show message box that states the user was registered
            // on the message box show an information icon and “Register” caption
            // look at resources section below for message box information

            txtName.Text = "";
            txtPassword.Text = "";
            // clear text boxes
        }

    }
}
