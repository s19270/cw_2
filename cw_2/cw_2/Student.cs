using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace cw_2
{
    [Serializable]
    public class Student
    {
        [JsonPropertyName("Numer indexu")]
        public string indexNumber { get; set; }
        [JsonPropertyName("Imie")]
        [XmlAttribute(AttributeName = "author=")]
        public string fname { get; set; }
        [JsonPropertyName("Nazwisko")]
        [XmlAttribute(AttributeName = " ")]
        public string lname { get; set; }

        [XmlElement(ElementName = "Data Urodzenia")]
        public string birthdate { get; set; }
        [JsonPropertyName("Adres email")]
        public string email { get; set; }
        [JsonPropertyName("Imie matki")]
        public string mothersName { get; set; }
        [JsonPropertyName("Imie ojca")]
        public string fathersName { get; set; }
        [JsonPropertyName("Nazwa studiow")]
        public string studiesname { get; set; }
        [JsonPropertyName("Tryb studiow")]
        public string studiesmode { get; set; }
        public string toString()
        {
            return fname + ", "  + lname + ", " + studiesname + ", " + studiesmode + ", " + indexNumber + ", "
                + birthdate + ", " + email + ", " + mothersName + ", " + fathersName;
        }
    }
}
