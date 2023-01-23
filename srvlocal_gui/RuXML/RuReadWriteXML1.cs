using System.Text;
using System.Xml;
using System.Xml.Serialization;

// 1.Update to 2.0 from 19.08.2022
// 2.Update to NET 6.0 
// 3.Parameters for the file dialog boxes can be entered

// 4.Update to 2.1 from 20.12.2022
// 5.Update due to Net 6.0
// 6.Insert FileStreamOptions because save didn't work unlike SaveAs

namespace srvlocal_gui
{
    public class XML
    {
        /// <summary>
        /// Writes an object to an XML file.
        /// With or without FileOpen dialog  
        /// </summary>
        /// <typeparam name="T">objectname/classname</typeparam>
        /// <param name="filename">file.xml</param>
        /// <param name="with SaveFileDialog">true/false</param>
        /// <param name="FileTypeText">Xml-File (*.xml)|*.xml|txt files (*.txt)|*.txt|All files (*.*)|*.*</param>
        /// <returns>true/false</returns>
        public static bool Write_XML<T>(T value, string filename, bool withDialog = false, string FileTypeText = "Xml-File (*.xml)|*.xml|txt files (*.txt)|*.txt|All files (*.*)|*.*")
        {
            bool result = false;

            try
            {
                SaveFileDialog dlg = new SaveFileDialog();

                dlg.Filter = FileTypeText;
                dlg.InitialDirectory = Path.GetDirectoryName(filename);
                dlg.RestoreDirectory = true;
                dlg.FileName = filename; //Path.GetFileName(filename);

                DialogResult dlgresult = DialogResult.Cancel;

                if (withDialog == true)
                {
                    dlgresult = dlg.ShowDialog();
                }
                else
                {
                    dlgresult = DialogResult.OK;
                }
                if (dlgresult == DialogResult.OK)
                {
                    FileStreamOptions fileStreamOptions = new FileStreamOptions();
                    fileStreamOptions.Access = FileAccess.Write;
                    fileStreamOptions.Mode = FileMode.Create;
                    using (StreamWriter streamWriter = new StreamWriter(dlg.FileName, fileStreamOptions))
                    {
                        var settings = new XmlWriterSettings { Encoding = Encoding.UTF8, CheckCharacters = false, NewLineHandling = NewLineHandling.None, Indent = true };
                        using (XmlWriter xmlWriter = XmlWriter.Create(streamWriter, settings))
                        {

                            XmlSerializer serializer = new XmlSerializer(typeof(T));

                            serializer.Serialize(xmlWriter, value);

                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not write file to disk. Original error: " + ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Reads an object from an XML file.
        /// With or without FileOpen dialog
        /// </summary>
        /// <typeparam name="T">objectname/classname</typeparam>
        /// <param name="ref filename">file.xml</param>
        /// <param name="with OpenFileDialog">true/false</param>
        /// <param name="FileTypeText">Xml-File (*.xml)|*.xml|txt files (*.txt)|*.txt|All files (*.*)|*.*</param>
        /// <returns>XML object or default</returns>
        public static T Read_XML<T>(ref string filename, bool withDialog = false, string FileTypeText = "Xml-File (*.xml)|*.xml|txt files (*.txt)|*.txt|All files (*.*)|*.*") where T : new()
        {
#pragma warning disable CS8600
#pragma warning disable CS8603

            T result = default(T);

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = FileTypeText;
            dlg.InitialDirectory = Path.GetDirectoryName(filename);
            dlg.RestoreDirectory = true;
            dlg.FileName = Path.GetFileName(filename);

            DialogResult dlgresult = DialogResult.Cancel;
            if (withDialog == true)
            {
                dlgresult = dlg.ShowDialog();
            }
            else
            {
                dlgresult = DialogResult.OK;
            }
            if (dlgresult == DialogResult.OK)
            {
                try
                {
                    using (StreamReader fileStream = new StreamReader(new FileStream(dlg.FileName, FileMode.Open), Encoding.UTF8, true, 1024))
                    {
                        var serializer = new XmlSerializer(typeof(T));

                        result = (T)serializer.Deserialize(fileStream);

                        filename = dlg.FileName;

                        fileStream.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

            return result;
#pragma warning restore CS8600
#pragma warning restore CS8603
        }
    }
}

