using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ModBuilder
{
    class XMLSerializer
    {
        public static void Save<T>(string savePath, T obj) where T : Prototype
        {


            XmlSerializer serializer = new XmlSerializer(typeof(T));
            string path = savePath + obj.Name + ".xml";
            FileStream stream = new FileStream(path, FileMode.Create);
            serializer.Serialize(stream, obj);
            stream.Close();

        }
    }
}
