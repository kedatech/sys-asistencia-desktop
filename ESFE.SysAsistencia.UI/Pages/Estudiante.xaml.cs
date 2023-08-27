using ESFE.SysAsistencia.BL;
using ESFE.SysAsistencia.DAL;
using ESFE.SysAsistencia.EN;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ESFE.SysAsistencia.UI.Pages
{
    /// <summary>
    /// Lógica de interacción para Estudiante.xaml
    /// </summary>
    public partial class Estudiante : Page
    {
        Auth Docente;
        EstudianteBL estudianteBL = new EstudianteBL();
        public Estudiante(Auth _Docente)
        {
            Docente = _Docente;
            InitializeComponent();

            var resut = estudianteBL.GetEstudiantes(Docente.id);

            var converter = new BrushConverter();
            //ObservableCollection<EstudianteGrid> members = new ObservableCollection<EstudianteGrid>();

            //membersDataGrid.ItemsSource = members;
        }

        private bool IsMaximize = false;

        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

