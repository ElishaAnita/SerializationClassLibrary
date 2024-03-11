using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace SerializationLibrary
{
    /* Both the XmlRootAttribute and JsonObject allow to set an alternate name
   (Person) of both XML element and JsonObject, the element namespace; by
   default, the XmlSerializer and JsonSerializer use the class name. The attribute
   also allows you to set the XML and Json namespace for the element.  */

    /// <summary>
    ///Represent a base class Person
    /// </summary>
    [XmlRoot]
    [XmlType]
    [JsonObject]
    [Serializable]
    public class Person
    {
        /// <summary>
        /// General Person constructor
        /// </summary>
        public Person()
        {
        }

        public List<Person> Persons = new List<Person>();

        /// <summary>
        /// Constructor with three attributes
        /// </summary>
        /// <param name="firstName">represent person first name</param>
        /// <param name="lastName">represent person last name</param>
        /// <param name="middleName">represent person middle name</param>
        public Person(string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
        }
        [XmlElement("FirstName")]
        public string FirstName { get; set; }
        [XmlElement]
        public string LastName { get; set; }
        [XmlElement]
        public string MiddleName { get; set; }
        //public string Name { get; set; }
    }


}
