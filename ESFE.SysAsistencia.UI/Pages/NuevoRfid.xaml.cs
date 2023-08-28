using ESFE.SysAsistencia.BL;
using System;
using System.IO.Ports;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace ESFE.SysAsistencia.UI.Pages
{
    public partial class NuevoRfid : Page
    {
        private SerialPort serialPort;
        int idEstudiante;

        RfidBL rfidBL = new RfidBL();
        public NuevoRfid(int _idEstudiante)
        {
            idEstudiante = _idEstudiante;
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

        private async void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedData = serialPort.ReadLine().Trim();

            if (!string.IsNullOrEmpty(receivedData) && receivedData != "0" && receivedData.Length > 1 && Application.Current != null)
            {
                await Application.Current.Dispatcher.InvokeAsync(async () =>
                {
                    imgLoader.Visibility = Visibility.Collapsed;
                    txt.Text = "Guardando, por favor espere...";
                    imgRfid.Visibility = Visibility.Visible;

                    bool result = await rfidBL.PostUid(receivedData, idEstudiante);

                    //imgRfid.Visibility = Visibility.c;

                    if (result)
                    {
                        Uri newImageUri = new Uri("/Pages/check.png", UriKind.Relative);
                        BitmapImage newImage = new BitmapImage(newImageUri);
                        imgRfid.Source = newImage;
                        txt.Text = "Hecho";
                    }
                    else
                    {
                        txt.Text = "Eror...";
                        MessageBox.Show("Oh no. Ocurrio un error");
;                    }
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
