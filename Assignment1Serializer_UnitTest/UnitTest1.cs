using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializationLibrary;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Assignment1Serializer_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestXmlSerialzation()
        {
            bool exceptionWasThrown = false;
            

            try
            {
                var person = new Person("Joe", "Doee", "Tom");
                
                Assignment1Serializer.SerialzToJson(person);



            }
            catch (SerializationException)
            {
                throw new SerializationException("A SharedMemory object was not " +
                    "serialized using any of the following streaming context");
            }



            Assert.IsFalse(exceptionWasThrown, "An XmlSerializationException was thrown. The type xx is not xml serializable!");

        }

    }
}
