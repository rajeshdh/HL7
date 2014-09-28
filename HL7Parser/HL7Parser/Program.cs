using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HL7Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"E:\Test.hl7");


            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
            var parser = new Parser();

            var xDoc = parser.Parse(text);

            var messageType = (from elem in xDoc.Descendants("MSH.9.1") select elem.Value).FirstOrDefault();


            //MSH ms = new MSH();


            //ms.GetMSH(xDoc);
            //var g = new g();
            //var s = g.start();

            HL7Client abs = new HL7Client();
             var a =     abs.Start(xDoc);
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

       
    }
   
     class a
    {
        private string abc { get; set; }
        public a getA ()
        {
            var b = new a() { abc = "test" };
            return b;
        }
    }
     class g
     {
         private a ab = new a();
         public g()
         {
             this.ab = this.ab.getA();
         }
         public g start ()
         {
             return new g();
         }

     }
    
   
}
