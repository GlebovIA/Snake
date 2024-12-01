using System.Windows;
using System.Windows.Controls;

namespace SnakeWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для EndGame.xaml
    /// </summary>
    public partial class EndGame : Page
    {
        public EndGame()
        {
            InitializeComponent();
            name.Content = MainWindow.mainWindow.viewModelUserSettings.Name;
            top.Content = MainWindow.mainWindow.viewModelGames.Top;
            glasses.Content = $"{MainWindow.mainWindow.viewModelGames.SnakesPlayers.Points.Count - 3} glasses";
            MainWindow.mainWindow.receivingUpClient.Close();
            MainWindow.mainWindow.tRec.Abort();
            MainWindow.mainWindow.viewModelGames = null;
        }

        private void OpenHome(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.OpenPages(MainWindow.mainWindow.Home);
        }
    }
}
