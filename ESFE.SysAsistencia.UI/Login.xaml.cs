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
using System.Windows.Shapes;
using ESFE.SysAsistencia.BL;
using ESFE.SysAsistencia.EN;

namespace ESFE.SysAsistencia.UI
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        AuthBL auth = new AuthBL();
        public Login()
        {
            InitializeComponent();
            txtUser.Text = "helen.contreras@esfe.agape.edu.sv";
            txtPass.Password = "123";
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(txtUser.Text != "" && txtPass.Password != "")
            {
                btnLogin.IsEnabled = false;
                txtPass.IsEnabled = false;
                txtUser.IsEnabled = false;
                btnLogin.Content = "Ingresando...";
                Auth value = await auth.Login(txtUser.Text, txtPass.Password);

                if (value != null && value.id != 0)
                {
                    btnLogin.IsEnabled = false;
                    btnLogin.Content = "Ingresar";
                    MessageBox.Show("Se ha iniciado sesión con éxito, Bienvenido", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow mainWindow = new MainWindow(value);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    btnLogin.IsEnabled = true;
                    txtPass.IsEnabled = true;
                    txtUser.IsEnabled = true;
                    btnLogin.Content = "Ingresar";
                    MessageBox.Show("Las credenciales no coinciden, correo o usuario incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                MessageBox.Show("Los campos no deben estar vacíos", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);

            }


        }
    }
}
