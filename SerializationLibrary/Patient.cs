using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace SerializationLibrary
{
    /* Both the XmlRootAttribute and JsonObject allow to set an alternate name
   (Patient) of both XML element and JsonObject, the element namespace; by
   default, the XmlSerializer and JsonSerializer use the class name. The attribute
   also allows you to set the XML and Json namespace for the element.  */

    /// <summary>
    /// Derived class from base class Person
    /// </summary>

    [XmlRoot]
    [XmlType] // type of data will be xml
    [JsonObject]
    public class Patient : Person
    {
        /// <summary>
        /// General Constructor
        /// </summary>
        public Patient()
        {
        }

        /// <summary>
        /// Represent a constructor with two parameters
        /// </summary>
        /// <param name="dateOfBirth">Represent the person date of birth</param>
        /// <param name="gender">Represent the gender of the person</param>
        public Patient(string firstName, string lastName, string middleName, DateTimeOffset dateOfBirth, string gender):
            base(firstName,lastName,middleName)
        {
            DateOfBirth = dateOfBirth;
            Gender = gender;
        }
        /// <summary>
        /// Create a DateOfBirth attribut.
        /// </summary>
        [XmlIgnore] // this attribut will be ignore with the serializer we cannot serliaze date
        public DateTimeOffset DateOfBirth { get; set; }

        /// <summary>
        /// Create a Gender attribut
        /// </summary>
        [XmlElement]
        public string Gender { get; set; }

        /// <summary>
        /// Create a DateOfBirthXml attribut that can be serializer
        /// </summary>
        [XmlElement]
        public string DateOfBirthXml
        {
            get
            {
                return this.DateOfBirth.ToString("o");
            }
            set
            {
                this.DateOfBirth = DateTimeOffset.Parse(value);
            }
        }
    }
}
