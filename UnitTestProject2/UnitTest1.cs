using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerializationLibrary;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

/*
* - Anita Elisha-000786108
* - Project date: January 24th, 2021
* - The purpose of this project is to create a .Net Core 2.2 Unit Test class
*   to test set of mthods on SerializationLibrary project. 
*  -Create 4 unique unit tests for the Assignment1Serializerclass.ca
* - Statement of Authrship: I, Anita Elisha, 000786108 certify that this material is my original work. No other person's 
*   work has been used without due acknowledgement.
* - Instroctor: Mohamed Elliethy.
*/
namespace UnitTest_SerializationLibrary
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test a person object Json serialzation and
        /// throw an exception error.
        /// </summary>
        [TestMethod]
        public void TestJsonSerialzation()
        {
            bool exceptionWasThrown = false;
            var person = new Person("Anita", "Elisha", "Idward");
            try
            {
                Assignment1Serializer.SerialzToJson(person);
                //Assignment1Serializer.SerialzToXML(person);            
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            Assert.IsFalse(exceptionWasThrown,
                           $"A JsonSerializationException was thrown. The type {person.GetType()} is not Json object serializable!");
        }

        /// <summary>
        /// Test object type that might be serialize or deserialize
        /// </summary>
        [TestMethod]
        public void TestTypeOfObject()
        {
            object objExpect = new Person("Anita", "Elisha", "Idward");
            var objResult = typeof(Person);

            try
            {
                Assert.AreEqual(objResult, objExpect.GetType(), $"The object result type: {objResult} is not equal to " +
                                $"the Expected object type: {objExpect} ");
            }
            catch (SerializationException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Test the Xml serialize and desialize object
        /// by using AreEqual method.
        /// </summary>
        [TestMethod]

        public void TestTypeOfDeserialerXMLObject()
        {
            var identity = new Identifier("admin", "manger");
            //var person = new Person("Anita", "Elisha", "Idward");
            var bytes = File.ReadAllBytes($"{AppDomain.CurrentDomain.BaseDirectory}\\output.xml");
            var expectedResult = identity.GetType();
            try
            {
                Assignment1Serializer.SerialzToXML(identity);
                object actual = Assignment1Serializer.DeserialzFromXML(typeof(Person), bytes);
                Assert.AreEqual(actual.GetType(), expectedResult,
                        $"DeserialzFromXML method return a wrong sourceObject type");
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to get DeserializeXMLObject type. Reason: " + e.Message);
                throw;
            }
        }

        /// <summary>
        /// Test an XmlIgnore attribut with DateTimeOffset
        /// Proprity type
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_DateOfBirthXml_Attribut()
        {


            var patient = new Patient("A", "B", "C", DateTimeOffset.Now, "X");
            var expectedResult = DateTimeOffset.Now;
            // This is your expected object which you are going to write to xml.
            // Writing object to XML.
            byte[] bytes = Assignment1Serializer.SerialzToXML(patient);
            // Deserialize xml to get actual object (which should be equal to sourceObject) 
            try
            {

                var actual = Assignment1Serializer.DeserialzFromXML<Patient>(bytes);
                Assert.AreEqual(actual.DateOfBirthXml, expectedResult,
                    "Failed: The DateOfBirth Proprity is DateTimeOffset format not System.string");
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to Deserialize. Reason: " + e.Message);
                throw;
            }


        }
    }
}
