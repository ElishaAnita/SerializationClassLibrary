using Newtonsoft.Json;
using System;
using System.Xml.Serialization;

namespace SerializationLibrary
{
    /* Both the XmlRootAttribute and JsonObject allow to set an alternate name
    (Identifier) of both XML element and JsonObject, the element namespace; by
    default, the XmlSerializer and JsonSerializer use the class name. The attribute
    also allows you to set the XML and Json namespace for the element.  */

    /// <summary>
    /// Represent an Identifier object class
    /// </summary>
    [XmlRoot]
    [XmlType] // type of data will be xml
    [JsonObject]
    public class Identifier
    {
        /// <summary>
        /// General Identifier constructor
        /// </summary>
        public Identifier()
        {
        }

        /// <summary>
        /// Represnt a constructor with tow parameters 
        /// </summary>
        /// <param name="authority">Represent a person identifier</param>
        /// <param name="value">Represnt a value</param>
        public Identifier(string authority, string value)
        {
            Authority = authority;
            Value = value;
        }
        /// <summary>
        /// Create an Authority attribute type string.
        /// </summary>
        [XmlElement]
        public string Authority { get; set; }
        /// <summary>
        /// Create an EntityId attribute type Guid.
        /// </summary>
        [XmlElement]
        public Guid EntityId { get; set; }
        /// <summary>
        /// Create an Value attribute type string.
        /// </summary>
        [XmlElement]
        public string Value { get; set; }

    }
}
