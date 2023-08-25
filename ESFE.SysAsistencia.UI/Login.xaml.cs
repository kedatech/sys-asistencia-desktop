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
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Auth value = await auth.Login("helen.contreras@esfe.agape.edu.sv", "123");
            //txtLogin.Text = value;
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
        }
    }
}
