using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srvlocal_gui
{
    public class ZipExtractor
    {
        public ZipExtractor()
        {

        }

        public class ZipOutcome
        {
            public ZipOutcome() 
            {
                
            }

            public string Error { get; set; }

            public bool Success { get; set; }

            public string Message { get; set; }
        }

        public ZipOutcome Extract(string input, string output)
        {
            var outcome = new ZipOutcome();

            try
            {
                outcome.Message = "Have a nice day";
                outcome.Success = true;

                return outcome;
            }
            catch(Exception ex) // Error Handle
            {
                outcome.Error = ex.Message;
                outcome.Success = false;

                return outcome;
            }

        }

        public void StartZipper(string[] args)
        {
            var output = Extract(".\\zip.zip", "output\\dir");

            if (!output.Success)
            {
                Console.WriteLine("Error: " + output.Error);

                return;
            }

            Console.WriteLine(output.Message);
            Console.WriteLine(output.Success);

        }
    }
}
