using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialisierung
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person { Vorname = "Tom", Nachname = "Ate", Alter = 10, Kontostand = 100m };
            Person p2 = new Person { Vorname = "Anna", Nachname = "Nass", Alter = 20, Kontostand = 2000m };

            #region Binär
            //// Serialisieren:
            //BinaryFormatter formatter = new BinaryFormatter();
            //FileStream stream = new FileStream("person.bin", FileMode.Create);
            //formatter.Serialize(stream, p1);
            //formatter.Serialize(stream, p2);
            //stream.Close();

            //// Deserialisieren:
            //stream = new FileStream("person.bin", FileMode.Open);
            //var geladenePerson = formatter.Deserialize(stream);
            //var geladenePerson2 = formatter.Deserialize(stream);
            //stream.Close();

            //Console.WriteLine(geladenePerson.GetType());
            //var deserialisiertePerson = (Person)geladenePerson;
            //Console.WriteLine(deserialisiertePerson.Vorname);
            //Console.WriteLine(deserialisiertePerson.Nachname); 
            #endregion

            #region XML
            //// Einschränkungen:
            ///* Klasse MUSS public sein
            // * Klasse darf nur public member haben
            // * Properties müssen GET und SET haben
            // * Es muss einen parameterlosen Konstruktor geben
            // * Man kann optional noch mit Attributen steuern
            // */

            //// Serialisieren
            //XmlSerializer xmlserializer = new XmlSerializer(typeof(Person));
            //FileStream stream = new FileStream("person.xml", FileMode.Create);
            //xmlserializer.Serialize(stream, p1);
            //stream.Close();

            //// Deserialisieren
            //stream = new FileStream("person.xml", FileMode.Open);
            //var geladenePerson = xmlserializer.Deserialize(stream);
            //Console.WriteLine(geladenePerson.GetType());
            //var xmlPerson = (Person)geladenePerson;
            //Console.WriteLine(xmlPerson.Vorname);
            //Console.WriteLine(xmlPerson.Nachname); 
            #endregion

            #region JSON (.NET / Newtonsoft.JSON)
            //// Serialisieren
            //MemoryStream stream = new MemoryStream();
            //DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));
            //serializer.WriteObject(stream, p1);

            //stream.Position = 0; // auf Start
            //StreamReader sr = new StreamReader(stream);
            //Console.WriteLine(sr.ReadToEnd()); 
            #endregion

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
