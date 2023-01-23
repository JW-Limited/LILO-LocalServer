
/*
using System.Xml;
using System.Xml.Serialization;

namespace srvlocal_gui
{
    #region Form
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Default file name
            string filename = "PhoneBook.xml";

            // Create phonebook
            PhoneBook phoneBook = new PhoneBook();

            // Add number to phonebook
            Number number = new Number();
            number.Type = PhoneType.Home;
            number.Value = "01781111111111";
            phoneBook.Add(number);

            // Add number to phonebook
            number = new Number();
            number.Type = PhoneType.Mobil;
            number.Value = "01782222222222";
            phoneBook.Add(number);

            // Add number to phonebook
            number = new Number();
            number.Type = PhoneType.Work;
            number.Value = "01783333333333";
            phoneBook.Add(number);

            // Add number to phonebook
            phoneBook.Add(new Number(PhoneType.Fax, "02241666666"));

            // Delete phone number by number
            // string numberRemove = "01782222222222";
            // phoneBook.Remove(numberRemove);

            // Delete phone number by index
            // phoneBook.Remove(0);

            // Write to XML file with SaveFileDialog
            XML.Write_XML<PhoneBook>(phoneBook, filename, true, "Phonebook (*.xml)|*.xml|txt files (*.txt)|*.txt|All files (*.*)|*.*");

            // Read from XML file with OpenFileDialog
            phoneBook = XML.Read_XML<PhoneBook>(ref filename, true, "Phonebook (*.xml)|*.xml|txt files (*.txt)|*.txt|All files (*.*)|*.*");

            // Display phonebook items
            if (phoneBook != null)
            {
                if (phoneBook.number != null)
                {
                    foreach (Number n in phoneBook.number)
                    {
                        // Console.WriteLine("Type: {0} Value: {1}", n.Type, n.Value);
                        // Debug.Print("Type: {0} Value: {1}", n.Type, n.Value);
                   }
                }
            }
            // Test Data

            // <?xml version="1.0" encoding="utf-8"?>
            // <phoneBook xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" nid="4">
            //     <number type="Home" id="01781111111111"/>
            //     <number type="Mobil" id="01782222222222"/>
            //     <number type="Work" id="01783333333333"/>
            //     <number type="Fax" id="02241666666"/>
            // </phoneBook>           
        }
    }
    #endregion
    #region PhoneBook
    [XmlType(TypeName = "phoneBook")]
    public class PhoneBook
    {
        #region Elemets
        [XmlAttribute("nid")]
        public int Nid { get; set; }
        [XmlElement]
        public Number[] number { get; set; }
        #endregion

        #region Add/Remove
        public void Add(Number item)
        {
            List<Number> list = new List<Number>();
            if (this.number != null)
            {
                list = new List<Number>(this.number);
            }
            list.Add(item);
            this.number = list.ToArray();
            this.Nid++;
        }
        public void Remove(string value)
        {
            if (value != null)
            {
                List<Number> list = new List<Number>(this.number);
                int index = 0;
                foreach (Number n in this.number)
                {
                    if (n.Value == value)
                    {
                        list.RemoveAt(index);
                        this.number = list.ToArray();
                        this.Nid--;
                    }
                    index++;
                }
            }
        }
        public void Remove(int index)
        {
            if (this.number != null & index < this.Nid)
            {
                List<Number> list = new List<Number>(this.number);
                list.RemoveAt(index);
                this.number = list.ToArray();
                this.Nid--;
            }
        }
        #endregion
    }
    #endregion
    #region Number
    [XmlType(TypeName = "number")]
    public class Number
    {
        #region Init
        public Number()
        {

        }

        public Number(PhoneType type, string value)
        {
            Type = type;
            Value = value;
        }

        #endregion

        #region Element
        [XmlAttribute("type")]
        public PhoneType Type { get; set; }

        [XmlAttribute("id")]

        [XmlText]
        public string Value { get; set; }
        #endregion
    }
    #endregion
    #region PhoneType
    public enum PhoneType
    {
        Home,
        Mobil,
        Work,
        Fax
    }
    #endregion
}
*/