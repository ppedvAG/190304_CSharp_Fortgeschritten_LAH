using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            //MessageBox.Show("Start");

            //await MachEtwas().ConfigureAwait(true); // Standardfall, Bricht mit (false)

            //// UI-Thread
            //labelWert.Content = "Es läuft ....";
            //MessageBox.Show("Ende");

            int[] durchgänge = { 100, 500, 750, 1000, 2000, 3000, 5000 };
            Stopwatch watch = new Stopwatch();
            Debug.WriteLine($"SynchronisationContext: {SynchronizationContext.Current == null}");
            for (int i = 0; i < durchgänge.Length; i++)
            {
                Debug.WriteLine($"------------- Durchgang {durchgänge[i]} --------------");
                watch.Restart();
                await MachEtwas(durchgänge[i], true);
                watch.Stop();
                Debug.WriteLine($"Configure True: {watch.ElapsedMilliseconds}ms");

                watch.Restart();
                await MachEtwas(durchgänge[i], false);
                watch.Stop();
                Debug.WriteLine($"Configure False: {watch.ElapsedMilliseconds}ms");
            }
            Debug.WriteLine("---ENDE---");
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

        public static async Task<int> MachEtwas(int durchgänge, bool configureAwait)
        {
            int result = 0;
            for (int i = 0; i < durchgänge; i++)
            {
                // Hier könnte man UI Zeugs machen
                await Task.Run(() => ParallelTest(durchgänge)).ConfigureAwait(configureAwait);
                result += i;
            }
            return result;
        }

        private static void ParallelTest(int durchgänge)
        {
            double[] werte = new double[durchgänge];
            // new ParallelOptions { MaxDegreeOfParallelism = 2 }
            Parallel.For(0, durchgänge, i =>
            {
                werte[i] = (Math.Pow(i, 0.33333) * Math.Sqrt(Math.Sin(123 * i))) / Math.PI;
            });
        }
    }
}
