using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsynchroneProgrammieren
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // TaskIstFertigEvent += TaskIstFertig;
        }

        //// Callback wenn der Task fertig ist
        //private void TaskIstFertig(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Ende");
        //}

        //private event EventHandler TaskIstFertigEvent;


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Start");

            await MachEtwas().ConfigureAwait(true); // Standardfall, Bricht mit (false)

            // UI-Thread
            labelWert.Content = "Es läuft ....";
            MessageBox.Show("Ende");
        }

        private async Task MachEtwas()
        {
            await Task.Run(async () =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    //Thread.Sleep(100);   // Blockiert den Thread
                    await Task.Delay(100); // Threadpool könnte weitermachen mit einem anderen Thread
                    Dispatcher.Invoke(() => progressBarWert.Value = i);
                }
                // TaskIstFertigEvent?.Invoke(this, EventArgs.Empty);
            });
        }
    }
}
