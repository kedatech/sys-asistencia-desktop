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
using ESFE.SysAsistencia.BL;
using Esfe.SysAsistencia.EN;

namespace ESFE.SysAsistencia.UI.Pages
{
    /// <summary>
    /// Lógica de interacción para Asistencia.xaml
    /// </summary>
    public partial class Asistencia : Page
    {
        MainWindow main_frame;
        ObservableCollection<EstudianteAsistencia> estudianteGrid = new ObservableCollection<EstudianteAsistencia>();
        public Asistencia(MainWindow padre)
        {
            main_frame = padre;
            InitializeComponent();
            InitDataGrid();
        }
        public async void InitDataGrid()
        {
            EstudianteBL estudianteBL = new EstudianteBL();
            var estudiantes = await estudianteBL.GetEstudiantes(3);


            for (int i = 0; i < estudiantes.Length; i++)
            {
                estudianteGrid.Add(new EstudianteAsistencia
                {
                    Id = estudiantes[i].Id,
                    Nombre = estudiantes[i].Nombre,
                    Codigo = estudiantes[i].Codigo,
                    Correo = estudiantes[i].Correo,
                    GrupoId = estudiantes[i].GrupoId,
                    GrupoName = estudiantes[i].GrupoName,
                    Telefono = estudiantes[i].Telefono,
                    Character = estudiantes[i].Nombre[0].ToString(),
                    Rfid = estudiantes[i].Rfid,
                    BgColor = GetRandomColor(),
                    Criterio = "NO ASISTIÓ"
                });
            }

            dataGrid.ItemsSource = estudianteGrid;
        }

        private void click_new(object sender, RoutedEventArgs e)
        {
            //main_frame.frame.NavigationService.Navigate(new Pages.NuevaAsistencia());
            frame.NavigationService.Navigate(new Pages.RfidAsistencia(estudianteGrid, dataGrid));
        }

        public class EstudianteAsistencia : Esfe.SysAsistencia.EN.Estudiante
        {
            public string Criterio { get; set; }
            public string Character {get;set;}
            public Brush BgColor { get; set; }
        }
        private static readonly List<string> Colors = new List<string>
        {
            "#1098AD", "#1E88E5", "#FF8F00", "#FF5252", "#0CA678", "#6741D9", "#FF6D00", "#1E88E5",
            "#1098AD", "#1E88E5", "#FF8F00", "#FF5252", "#0CA678", "#6741D9", "#FF6D00", "#1E88E5",
            "#1098AD", "#1E88E5", "#FF8F00", "#FF5252", "#0CA678", "#6741D9", "#FF6D00", "#1E88E5",
            "#1098AD", "#1E88E5", "#FF8F00", "#FF5252", "#0CA678"
        };

        private static readonly Random Random = new Random();

        public static Brush GetRandomColor()
        {
            var converter = new BrushConverter();

            var randomColorIndex = Random.Next(Colors.Count);
            var colorString = Colors[randomColorIndex];
            var color = (Brush)converter.ConvertFromString(colorString);
            return color;
        }
    }
}
