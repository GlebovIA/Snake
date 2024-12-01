using Common;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows;

namespace SnakeWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow mainWindow;
        public ViewModelUserSettings viewModelUserSettings = new ViewModelUserSettings();
        public ViewModelGames viewModelGames = null;
        public static IPAddress remoteIpAddress = IPAddress.Parse("127.0.0.1");
        public static int remotePort = 5001;
        public Thread tRec;
        public UdpClient receivingUpClient;
        public Pages.Home Home = new Pages.Home();
        public Pages.Game Game = new Pages.Game();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void StartReceiver()
        {
            tRec = new Thread(new ThreadStart(Receiver));
            tRec.Start();
        }
    }
}
