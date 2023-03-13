using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace srvlocal_gui
{
    public class ProjectFile
    {
        [XmlRoot("Project")]
        public class Project
        {
            [XmlAttribute("name")]
            public string Name { get; set; }

            [XmlAttribute("id")]
            public int Id { get; set; }

            [XmlAttribute("target")]
            public string Target { get; set; }

            [XmlElement("Author")]
            public string Author { get; set; }

            [XmlElement("CloudSave_v3")]
            public bool CloudSave { get; set; } 

            [XmlElement("Company")]
            public string Company { get; set; }

            [XmlElement("Framework")]
            public string Framework { get; set; }

            [XmlElement("Language")]
            public string Language { get; set; }

            [XmlElement("CreationDate")]
            public DateTime CreationDate { get; set; }

            [XmlElement("LastModifiedDate")]
            public DateTime LastModifiedDate { get; set; }

            [XmlElement("Description")]
            public string Description { get; set; }

            [XmlElement("Version")]
            public string Version { get; set; }

            [XmlElement("BuildDate")]
            public DateTime BuildDate { get; set; }

            [XmlElement("MachineName")]
            public string MachineName { get; set; }

            [XmlElement("ServerIP")]
            public string ServerIP { get; set; }

            [XmlElement("ApplicationName")]
            public string ApplicationName { get; set; }

            [XmlElement("ApplicationDescription")]
            public string ApplicationDescription { get; set; }

            [XmlElement("AppTypev2")]
            public string ApplicationType { get; set; }

            [XmlArray("Files")]
            [XmlArrayItem("File")]
            public List<string> Files { get; set; }

            [XmlArray("References")]
            [XmlArrayItem("Reference")]
            public List<string> References { get; set; }

            public void SaveToFile(string filename)
            {
                using (var writer = new StreamWriter(filename))
                {
                    var serializer = new XmlSerializer(typeof(Project));
                    serializer.Serialize(writer, this);
                }
            }

            public static Project LoadFromFile(string filename)
            {
                using (var reader = new StreamReader(filename))
                {
                    var serializer = new XmlSerializer(typeof(Project));
                    return (Project)serializer.Deserialize(reader);
                }
            }
        }

        [Serializable]
        public class LILOBuilder
        {
            public string License { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Country { get; set; }

            public static LILOBuilder LoadFromFile(string filePath)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(LILOBuilder));

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    return (LILOBuilder)serializer.Deserialize(fileStream);
                }
            }

            public void SaveToFile(string filePath)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(LILOBuilder));

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    serializer.Serialize(fileStream, this);
                }
            }
        }
    }
}
