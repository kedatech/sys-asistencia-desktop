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
        MainWindow main_frame;
        public Estudiante(Auth _Docente, MainWindow padre)
        {
            Docente = _Docente;
            main_frame = padre;
            InitializeComponent();

            InitDataGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag != null)
            {
                int id = (int)button.Tag;
                main_frame.frame.NavigationService.Navigate(new Pages.NuevoRfid(id));
            }
        }

        public async void InitDataGrid()
        {
            var estudiantes = await estudianteBL.GetEstudiantes(Docente.Id);

            ObservableCollection<EstudianteGrid> estudianteGrid = new ObservableCollection<EstudianteGrid>();

            for(int i = 0; i < estudiantes.Length; i++)
            {
                estudianteGrid.Add(new EstudianteGrid
                {
                    Id = estudiantes[i].Id,
                    Nombre = estudiantes[i].Nombre,
                    Codigo = estudiantes[i].Codigo,
                    Correo = estudiantes[i].Correo,
                    GrupoId = estudiantes[i].GrupoId,
                    GrupoName = estudiantes[i].GrupoName,
                    Telefono = estudiantes[i].Telefono,
                    Character = estudiantes[i].Nombre[0].ToString(),
                    BgColor = GetRandomColor()
                });
            }

            dataGrid.ItemsSource = estudianteGrid;
        }

        private bool IsMaximize = false;

        private void membersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public class EstudianteGrid : Esfe.SysAsistencia.EN.Estudiante
        {
            public Brush BgColor { get; set; }
            public string Character { get; set; }
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

