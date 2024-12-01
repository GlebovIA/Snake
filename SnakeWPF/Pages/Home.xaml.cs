using Newtonsoft.Json;
using System.Net;
using System.Windows;
using System.Windows.Controls;

namespace SnakeWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            if (MainWindow.mainWindow.receivingUpClient != null)
                MainWindow.mainWindow.receivingUpClient.Close();
            if (MainWindow.mainWindow.tRec != null)
                MainWindow.mainWindow.tRec.Abort();
            IPAddress UserIpAddress;
            if (!IPAddress.TryParse(ipTBx.Text, out UserIpAddress))
            {
                MessageBox.Show("Please use the Ip address in the format X.X.X.X.");
                return;
            }
            int UserPort;
            if (!int.TryParse(portTBx.Text, out UserPort))
            {
                MessageBox.Show("Please use the Port as a number.");
                return;
            }
            MainWindow.mainWindow.StartReceiver();
            MainWindow.mainWindow.viewModelUserSettings.IPAddress = ipTBx.Text;
            MainWindow.mainWindow.viewModelUserSettings.Port = portTBx.Text;
            MainWindow.mainWindow.viewModelUserSettings.Name = nameTBx.Text;
            MainWindow.Send("/start|" + JsonConvert.SerializeObject(MainWindow.mainWindow.viewModelUserSettings));
        }
    }
}
