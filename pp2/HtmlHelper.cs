using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace pp2
{
    internal class HtmlHelper
    {

        public string[] HtmlTagg { get; set; }
        public string[] HtmlvoidTagg { get; set; }
         
        private readonly static HtmlHelper _instance = new HtmlHelper();
        public static HtmlHelper Instance =>_instance;


        private HtmlHelper() {

            var fulltxt = File.ReadAllText("fulltxt.txt");
            var voidtxt = File.ReadAllText("voidtext.txt");

            // המרה ממחרוזת JSON למערכים באמצעות JsonSerializer
            HtmlTagg = JsonSerializer.Deserialize<string[]>(fulltxt);//תגיות שיכול היות להם ילדים
            HtmlvoidTagg = JsonSerializer.Deserialize<string[]>(voidtxt);


        }





    }
}
