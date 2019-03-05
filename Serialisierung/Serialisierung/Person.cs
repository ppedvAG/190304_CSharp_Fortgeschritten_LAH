using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Serialisierung
{
    // Für Binär:
    // [Serializable] über der Klasse
    //  --- Ab C# 7.3 [field: NonSerialized] bei AutoProperties

    // Für XML:
    //[XmlRoot(ElementName ="MeinePerson")]
    //public class Person
    //{
    //    [XmlAttribute("Nachname")]
    //    public string Vorname { get; set; }
    //    [XmlAttribute("Vorname")]
    //    public string Nachname { get; set; }
    //    public byte Alter { get; set; }
    //    [XmlIgnore]
    //    public decimal Kontostand { get; set; }
    //}

    // JSON
    // 1) Verweis auf System.Runtime.Serialization hinzufügen
    [DataContract]
    public class Person
    {
        [DataMember]
        public string Vorname { get; set; }
        [DataMember]
        public string Nachname { get; set; }
        [DataMember]
        public byte Alter { get; set; }
        [DataMember]
        public decimal Kontostand { get; set; }
    }

}
