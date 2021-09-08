using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.SqlClient;
using System.Configuration;

namespace CalcWithLoginscreen
{
    public partial class MainWindow : Window
    {

       
        private void Reg_Button_Click(object sender, RoutedEventArgs e)
        {

            // DB
            string connectionString = ConfigurationManager.ConnectionStrings["userdb"].ConnectionString;
            SqlConnection sqlConnection = null;
            
            // Data
            string login = LoginBox.Text;
            string pass = PassBox.Password;
            string pass_check = PassCheckBox.Password;

            // Login lenght check
            if (login.Length < 5)
            { MessageBox.Show("Длина логина должна быть больше 5 символов с:"); }

            // Pass lenght check
            else if (pass.Length < 5)
            { MessageBox.Show("Длина пароля должна быть больше 5 символов с:"); }

            // Checking for a password match
            else if (pass_check != pass)
            { MessageBox.Show("Пароли не совпадают :с"); }

            // If everything is Ok -> reg  
            else
            {      
                // Add to the database data
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                //SqlDataReader sqlDataReader = null;
                SqlCommand command = new SqlCommand($"INSERT INTO [UsersDB] (login, pass) VALUES ('{login}','{pass}')", sqlConnection);
                command.ExecuteNonQuery();

                // Next window for login
                Auth auth = new Auth();
                auth.Show();
                Hide();

                // Complete message
                MessageBox.Show("Регистрация успешно завершена");
            }

        }

        // Login button
        private void Auth_Button_Click(object sender, RoutedEventArgs e)
        {
            // Show auth window  (copy-paste potomuchto mogu 😎 ya indus)
            Auth auth = new Auth();
            auth.Show();
            Hide();
        }
    }
}
