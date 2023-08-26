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

using System.Collections.ObjectModel;
using ESFE.SysAsistencia.UI;


namespace ESFE.SysAsistencia.UI.Pages
{
    /// <summary>
    /// Lógica de interacción para Asistencia.xaml
    /// </summary>
    public partial class Asistencia : Page
    {
        MainWindow main_frame;
        public Asistencia(MainWindow padre)
        {
            InitializeComponent();
            main_frame = padre;
        }

        private void click_new(object sender, RoutedEventArgs e)
        {
            main_frame.frame.NavigationService.Navigate(new Pages.NuevaAsistencia());
        }
    }
}
