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
        LocalLoginBL locallogin = new LocalLoginBL();
        public Login()
        {
            InitializeComponent();
            txtUser.Text = "helen.contreras@esfe.agape.edu.sv";
            txtPass.Password = "123";
        }

        private async void LogAPI()
        {
            
            Auth value = await auth.Login(txtUser.Text, txtPass.Password);

            if (value != null && value.Id != 0)
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
        private async void LogLocal()
        {
            var auth_log = locallogin.Login(txtUser.Text, txtPass.Password);
            
            if (auth_log != null && auth_log.Count > 0)
            {
                Auth auth_class = new Auth();
                foreach (var i in auth_log)
                {
                    auth_class.Id = i.Id;
                    auth_class.Nombre = i.Nombre;
                    auth_class.Correo = i.Correo;
                    auth_class.Contrasenia = i.Contrasenia;
                    auth_class.Telefono = i.Telefono;
                    auth_class.CarreraId = i.CarreraId;
                }
                if (auth_class != null && auth_class.Id != 0)
                {
                    MessageBox.Show("Se ha iniciado sesión localmente, Bienvenido", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    btnLogin.IsEnabled = false;
                    btnLogin.Content = "Ingresar";
                    MainWindow mainWindow = new MainWindow(auth_class);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo iniciar la sesión localmente debido a un error, Se iniciará la sesión en línea", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                    LogAPI();
                }

            }
            else
            {

                //Pedir que devuelva la api
                Auth auth_value = await auth.Login(txtUser.Text, txtPass.Password);

                if (auth_value != null && auth_value.Id != 0)
                {
                    Auth auth_class = new Auth()
                    {
                        Id = auth_value.Id,
                        Nombre = auth_value.Nombre,
                        Correo = auth_value.Correo,
                        Contrasenia = auth_value.Contrasenia,
                        Telefono = auth_value.Telefono,
                        CarreraId = auth_value.CarreraId
                    };

                    var response = locallogin.GuardarSesion(auth_class);
                    if (response)
                    {
                        //Se guardo la cuenta localmente de forma exitosa y ahora se inicia sesion
                        
                        MessageBox.Show("Se ha iniciado sesión con éxito y se guardó la sesión localmente, Bienvenido", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        //No se pudo guardar localmente pero se inicia sesion con la API
                        MessageBox.Show("No se pudo guardar la sesión localmente debido a un error, Se iniciará la sesión en línea", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);

                    }

                    //Login con la API
                    btnLogin.IsEnabled = false;
                    btnLogin.Content = "Ingresar";
                    MainWindow mainWindow = new MainWindow(auth_value);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    //error del response de la api
                    MessageBox.Show("Las credenciales no coinciden, correo o usuario incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);


                }

                btnLogin.IsEnabled = true;
                txtPass.IsEnabled = true;
                txtUser.IsEnabled = true;
                btnLogin.Content = "Ingresar";
            }
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(txtUser.Text != "" && txtPass.Password != "")
            {
                btnLogin.IsEnabled = false;
                txtPass.IsEnabled = false;
                txtUser.IsEnabled = false;
                btnLogin.Content = "Ingresando...";

                LogLocal();


            }
            else
            {
                MessageBox.Show("Los campos no deben estar vacíos", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);

            }


        }
    }
}
