using System;
using System.IO.Ports; // Agregar esta línea
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ESFE.SysAsistencia.UI.RFID
{
    public partial class Escanear : Window
    {
        private SerialPort serialPort;

        public Escanear()
        {
            InitializeComponent();
            InitializeSerialPort();
        }

        private void InitializeSerialPort()
        {
            serialPort = new SerialPort();
            serialPort.PortName = "COM12"; // Cambiar a tu puerto serial
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataReceived += SerialPort_DataReceived;

            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el puerto serial: {ex.Message}");
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string receivedData = serialPort.ReadLine();
            Dispatcher.Invoke(() =>
            {
                txtUID.Text = receivedData.Trim();
            });
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            serialPort.Close();
        }
    }
}
