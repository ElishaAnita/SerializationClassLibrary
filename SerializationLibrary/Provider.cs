using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace SerializationLibrary
{
    /* Both the XmlRootAttribute and JsonObject allow to set an alternate name
   (Provider) of both XML element and JsonObject, the element namespace; by
   default, the XmlSerializer and JsonSerializer use the class name. The attribute
   also allows you to set the XML and Json namespace for the element.  */

    /// <summary>
    /// Represnt a Provider class that derived from base class Person
    /// </summary>
    [XmlRoot]
    [XmlType] // type of data will be xml
    [JsonObject]
    public class Provider : Person
    {
        /// <summary>
        /// General Constructor
        /// </summary>
        public Provider()
        {
        }

        /// <summary>
        /// Represent a Constructor with specialty parameter
        /// </summary>
        /// <param name="specialty">Represent a specialty of the person</param>
        public Provider(string firstName, string lastName, string middleName,string specialty):
            base(firstName,lastName, middleName)
        {
            Specialty = specialty;
        }

        /// <summary>
        /// Create a Specialty attribute type string
        /// </summary>
        public string Specialty { get; set; } 
    }
}
