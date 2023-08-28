using ESFE.SysAsistencia.BL;
using Esfe.SysAsistencia.EN;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
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
using static System.Net.Mime.MediaTypeNames;
using System.IO.Ports;


namespace ESFE.SysAsistencia.UI.Pages
{
    /// <summary>
    /// Lógica de interacción para RfidAsistencia.xaml
    /// </summary>
    public partial class RfidAsistencia : Page
    {
        private SerialPort serialPort;
        ObservableCollection<Asistencia.EstudianteAsistencia> estudiantes;
        DataGrid dataGrid;
        public RfidAsistencia(ObservableCollection<Asistencia.EstudianteAsistencia> _estudiantes, DataGrid _dataGrid)
        {
            dataGrid = _dataGrid;
            estudiantes = _estudiantes;
            InitializeComponent();
            InitializeSerialPort();
            Unloaded += NuevoRfid_Unloaded;
        }
        private void InitializeSerialPort()
        {
            serialPort = new SerialPort
            {
                PortName = "COM14", // Cambiar a tu puerto serial
                BaudRate = 9600,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One,
            };

            try
            {
                serialPort.Open();
                serialPort.DataReceived += SerialPort_DataReceived;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el puerto serial: {ex.Message}");
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedData = serialPort.ReadLine().Trim();
            if (!string.IsNullOrEmpty(receivedData) && receivedData != "0" && receivedData.Length > 1 )
            {
                Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(receivedData);
                    // Buscar el estudiante en la colección que tenga la propiedad Rfid igual a receivedData
                    var estudianteEncontrado = estudiantes.FirstOrDefault(est => est.Rfid == receivedData);

                    if (estudianteEncontrado != null)
                    {
                        MessageBox.Show("Presencial");
                        // Actualizar la propiedad Criterio del estudiante a "SESIÓN PRESENCIAL"
                        estudianteEncontrado.Criterio = "SESIÓN PRESENCIAL";
                        dataGrid.Items.Refresh();
                    }
                });

            }
        }



        private void NuevoRfid_Unloaded(object sender, RoutedEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }
    }
}
