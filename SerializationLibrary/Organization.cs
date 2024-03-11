using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace SerializationLibrary
{
    /* Both the XmlRootAttribute and JsonObject allow to set an alternate name
   (Organization) of both XML element and JsonObject, the element namespace; by
   default, the XmlSerializer and JsonSerializer use the class name. The attribute
   also allows you to set the XML and Json namespace for the element.  */

    /// <summary>
    /// Represnt a Organization class that derived from base class Entity
    /// Represent an  base class. 
    /// </summary>
    [XmlRoot]
    [XmlType] // type of data will be xml
    [JsonObject]
    public class Organization : Entity
    {
       /// <summary>
       /// General constructor.
       /// </summary>
       public Organization()
        {
        }

        /// <summary>
        /// Constructor with name parameter
        /// </summary>
        /// <param name="name">Represent the organization name</param>
        public Organization(string name)
        {
            Name = name;
          
        }

        /// <summary>
        /// Create Name attribute with setter and getter
        /// </summary>
        [XmlElement]
        public string Name { get; set; }
    }
}
