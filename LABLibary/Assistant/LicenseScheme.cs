using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace LABLibary
{
    public class LicenseScheme
    {
        public class Config
        {
            [XmlElement("STARTUPBOST")]
            public bool StartUpBoost { get; set; }
            [XmlElement("STARTSOUND")]
            public bool StartSound { get; set; }
            [XmlElement("USERID")]
            public int UserId { get; set; }
            [XmlElement("BACKGROUND")]
            public string Background { get; set; }
            [XmlElement("USERRIGHTSTATUS")]
            public string UserRightStatus { get; set; }
            [XmlElement("CODE")]
            public string Code { get; set; }
            [XmlElement("installagnt")]
            public bool InstallAgent { get; set; }
            [XmlElement("assembly")]
            public Assembly Assembly { get; set; }
            [XmlElement("PROPERTIES")]
            public Properties Properties { get; set; }

            public Config() { }

            public void WriteToXmlFile(string filename)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Config));
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;

                using (XmlWriter writer = XmlWriter.Create(filename, settings))
                {
                    serializer.Serialize(writer, this);
                }
            }

            public static Config ReadFromXmlFile(string filename)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Config));
                using (XmlReader reader = XmlReader.Create(filename))
                {
                    return (Config)serializer.Deserialize(reader);
                }
            }
        }

        public class Assembly
        {
            [XmlElement("name")]
            public string Name { get; set; }
            [XmlElement("version")]
            public string Version { get; set; }
            [XmlElement("buildchannel")]
            public BuildChannel BuildChannel { get; set; }
        }

        public class BuildChannel
        {
            [XmlElement("channel")]
            public string Channel { get; set; }
            [XmlElement("devtools")]
            public bool DevTools { get; set; }
            [XmlElement("devinsight")]
            public bool DevInsight { get; set; }
        }

        public class Properties
        {
            [XmlElement("VALUE")]
            public Value[] Values { get; set; }
        }

        public class Value
        {
            [XmlAttribute("name")]
            public string Name { get; set; }
            [XmlAttribute("val")]
            public string Val { get; set; }
        }
    }
}
