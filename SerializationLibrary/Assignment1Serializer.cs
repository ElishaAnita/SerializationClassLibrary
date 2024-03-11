using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
/*
* - Anita Elisha-000786108
* - Project date: January 24th, 2021
* - The purpose of this project is to create a .Net Core 2.2 class library 
*   to implement a serialization library. 
* - Implement a serialzation and deserialization in JSON and XML and make use
*   of attributes to control it.
* - Statement of Authrship: I, Anita Elisha, 000786108 certify that this material is my original work. No other person's work has been used without due acknowledgement.
* 
* - Instroctor: Mohamed Elliethy.
*/
namespace SerializationLibrary

{
    public class Assignment1Serializer
    {
        /// <summary>
        /// General Constructor
        /// </summary>
        public Assignment1Serializer() { }

        /// <summary>
        /// Reconstruct a Json object to an object type
        /// using stream instance
        /// </summary>
        /// <param name="type">typeof(Type)</param>
        /// <param name="instance">Stream instance</param>
        /// <returns>object type</returns>
        public static object DeserialzFromJson(Type type, byte[] instance)
        {
            if (instance == null || instance.Length == 0)
            {
                throw new ArgumentNullException(nameof(instance));

            }
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));

            }
            try
            {
                var serializer = new JsonSerializer();
                var jsonReader = new JsonTextReader(new StringReader(Encoding.UTF8.GetString(instance)));
                var deserializedJsonInstance = serializer.Deserialize(jsonReader, type);
                return deserializedJsonInstance;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">Stream instance</param>
        /// <returns>Generic type</returns>
        public static T DeserialzFromJson<T>(byte[] instance)
        {
            if (instance == null || instance.Length == 0)
            {
                throw new ArgumentNullException(nameof(T));

            }

            var serializer = new JsonSerializer();
            try
            {
               // SerialzToJson(instance);
                //Console.WriteLine("read our serialized content from a file called 'output.json'");
                var bytes = File.ReadAllBytes($"{AppDomain.CurrentDomain.BaseDirectory}\\output.json");
                var jsonReader = new JsonTextReader(new StringReader(Encoding.UTF8.GetString(bytes)));
                var deserializedJsonInstance = serializer.Deserialize(jsonReader);
                return (T)deserializedJsonInstance;

            }
             catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
                           
        }

        /// <summary>
        /// Reconstruct an object from an XML object
        /// </summary>
        /// <param name="type">string path file</param>
        /// <param name="instance">byte</param>
        /// <returns>object type</returns>
        public static object DeserialzFromXML(Type type, byte[] instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            try
            {
                var serializer = new XmlSerializer(type);
                var deserializedXMLInstance = serializer.Deserialize(new MemoryStream(instance));
                return deserializedXMLInstance;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                new MemoryStream().Close();
            }

        }

        /// <summary>
        /// Reconstruct an object from an XML instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns>Generic type</returns>
        public static T DeserialzFromXML<T>(byte[] instance)
        {

            if (instance == null || instance.Length == 0)
            {
                throw new ArgumentNullException(nameof(T));
            }
            
            //SerialzToXML(instance);
            try
            {
                var serializer = new XmlSerializer(typeof(T));
                var bytes = File.ReadAllBytes($"{AppDomain.CurrentDomain.BaseDirectory}\\output.xml");
                var deserializedXMLInstance = serializer.Deserialize(new MemoryStream(bytes));
                return (T)deserializedXMLInstance;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }

        }

        /// <summary>
        /// Represent a static method that serialize an object
        /// to Json object saved in type path file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="instance">object</param>
        /// <returns>array of byte</returns>
        public static byte[] SerialzToJson(Type type, object instance)
        {

            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));

            }
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));

            }
            // declare and initialize our json serializer
            // supply type of generic to indicate what type of instance
            // is to be serialized
            var serializer = new JsonSerializer();
            var stringWriter = new StringWriter();
            try
            {
                serializer.Serialize(stringWriter, instance);
                var serializedContent = Encoding.UTF8.GetBytes(stringWriter.ToString());
                // write our serialized content to a file called 'output.json'
                File.WriteAllBytes($"{AppDomain.CurrentDomain.BaseDirectory}\\{type}", serializedContent);
                return serializedContent;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                stringWriter.Close();
            }

        }

        /// <summary>
        /// Serialize a generic instance into an Json array of byte
        /// </summary>
        /// <typeparam name="T">Generic</typeparam>

        /// <param name="instance"></param>
        /// <returns>array of byte</returns>
        public static byte[] SerialzToJson<T>(T instance)
        {

            if (instance == null)
            {
                throw new ArgumentNullException(nameof(T));
            }
            // declare and initialize our json serializer
            // supply type of generic to indicate what type of instance
            // is to be serialized
            var serializer = new JsonSerializer();
            var stringWriter = new StringWriter();
            try {   
                serializer.Serialize(stringWriter, instance);
                var serializedContent = Encoding.UTF8.GetBytes(stringWriter.ToString());
                // write our serialized content to a file called 'output.json'
                File.WriteAllBytes($"{AppDomain.CurrentDomain.BaseDirectory}\\output.json", serializedContent);
               return serializedContent;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                stringWriter.Close();
            }
                   
        }

        /// <summary>
        /// Represent a static method that serialize an object
        /// to Xml object saved in type path file
        /// </summary>
        /// <param name="type">string file path</param>
        /// <param name="instance">object to be serialized to xml</param>
        /// <returns>array of byte</returns>
        public static byte[] SerialzToXML(Type type, object instance)
        {
            if (instance == null || type == null)
            {
                throw new ArgumentNullException(nameof(type));

            }
            // Creates a new TestSimpleObject object.
            instance = new object();
            var serializer = new XmlSerializer(typeof(object));
            var memoryStream = new MemoryStream();
            try
            {
                serializer.Serialize(memoryStream, instance);
                var serializedContent = memoryStream.ToArray();
                // write our serialized content to a file called 'output.xml'
                File.WriteAllBytes($"{AppDomain.CurrentDomain.BaseDirectory}\\{type}", serializedContent);
                return serializedContent;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                memoryStream.Close();
            }
        }

        /// <summary>
        /// Serialize an T instance into an XML array byte and 
        /// save it as xml file format
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns>array of bytes</returns>
        public static byte[] SerialzToXML<T>(T instance)
        {

            if (instance == null)
            {
                throw new ArgumentNullException(nameof(T));

            }
            // declare and initialize our xml serializer
            // supply a generic type of instance to indicate the type
            // is to be serialized
            var serializer = new XmlSerializer(typeof(T));
            var memoryStream = new MemoryStream();
            try
            {

                serializer.Serialize(memoryStream, instance);
                var serializedContent = memoryStream.ToArray();
                // write our serialized content to a file called 'output.xml'
                File.WriteAllBytes($"{AppDomain.CurrentDomain.BaseDirectory}\\output.xml", serializedContent);
                return serializedContent;
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                memoryStream.Close();
            }

        }
    } 

}
