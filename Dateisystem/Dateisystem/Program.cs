using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dateisystem
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben Sie etwas ein:");
            string eingabe = Console.ReadLine();

            #region FileStream
            //FileStream stream = new FileStream("demo.txt", FileMode.Create);

            //byte[] data = Encoding.Default.GetBytes(eingabe);
            //stream.Write(data, 0, data.Length);

            //stream.Flush();
            //stream.Close(); 
            #endregion

            #region StreamWriter
            ////StreamWriter stream = new StreamWriter("demo.txt");
            ////stream.Write(eingabe);
            ////stream.Flush();
            ////stream.Close();


            //using (StreamWriter stream = new StreamWriter("demo.txt"))
            //{
            //    stream.Write(eingabe);
            //} 
            #endregion

            #region StreamReader
            //StreamReader sr = new StreamReader("demo.txt");
            //while (sr.Peek() != -1)
            //{
            //    string zeile = sr.ReadLine();
            //    // ....
            //} 
            #endregion

            #region File / Directory / DriveInfo / Environment.SpecialFolder
            //// Directory.GetFiles(...);
            //File.WriteAllText("demo.txt", eingabe);
            //var info = DriveInfo.GetDrives();
            //Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)); 
            #endregion

            #region Dialoge
            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Title = "Textdokument speichern unter:";
            //sfd.Filter = "Textdokument | *.txt";

            //if(sfd.ShowDialog() == DialogResult.OK)
            //{
            //    File.WriteAllText(sfd.FileName, eingabe);
            //}

            //FolderBrowserDialog dlg = new FolderBrowserDialog();
            //dlg.ShowDialog(); 
            #endregion

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
