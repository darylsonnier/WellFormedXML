using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WellFormedXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            if (args.Count() == 0)
            {
                Console.WriteLine("WellFormedXML --h :  This help information.");
                Console.WriteLine("WellFormedXML [file.xml] : Opens file.xml to check for well-formed status.  ");
                return;
            }

            else if (string.Compare(args[0], "--h",true) == 0)
            {
                Console.WriteLine("WellFormedXML --h :  This help information.");
                Console.WriteLine("WellFormedXML [file.xml] : Opens file.xml to check for well-formed status (no mismatched nodes, etc.)");
            }

            if (string.Compare(Path.GetExtension(args[0].ToString()), ".XML", true) == 0)
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Document;
                try
                {
                    using (XmlReader reader = XmlReader.Create(args[0], settings))
                    {
                        try
                        {
                            while (reader.Read())
                            {
                            }
                        }
                        catch (Exception ex)
                        {
                            List<string> error = new List<string>(ex.ToString().Split('\n'));
                            Console.WriteLine(error[0].Substring(25));
                            return;
                        }
                    }
                }
                catch 
                { 
                    Console.WriteLine("Unable to open " + args[0].ToUpper());
                    return;
                }
            }
            else
            {
                Console.WriteLine(args[0].ToUpper() + " is not an XML file name.");
                return;
            }
            Console.WriteLine("The XML is  well formed.");
        }
    }
}
