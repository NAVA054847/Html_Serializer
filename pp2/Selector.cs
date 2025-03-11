using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace pp2
{
    public class Selector
    {
        public string TagName { get; set; }
        public string Id { get; set; }
        public List<string> Classes { get; set; }
        public Selector Parent { get; set; }
        public Selector Child { get; set; }

        public Selector() {
            Classes = new List<string>();
        }

       //פונקציה שמקבל סטרינג של לסקטור ובונה לי מזה אובייקט או עץ של סלקטור
        public static Selector convertt(string str)
        {
            if (str.Contains(" "))//אם אתה מכיל כמה דורות
            {
                Selector current = null;//מצביע על האבא הנוכחי
                Selector root = null;
                string[] parts = str.Split(' ');

                foreach (string part in parts)
                {
                    Selector new1 = new Selector();
                    if (root == null)
                    {
                        if (HtmlHelper.Instance.HtmlTagg.Contains(part) || HtmlHelper.Instance.HtmlvoidTagg.Contains(part))
                        {
                            new1.TagName = part;//תתן שם לסלקטור root כשם התגית
                            current = new1;//שינתי את האובייקט הנוכחתי להיות האוביירקט החדש
                            root= new1;
                        }
                        else if (part.StartsWith("#"))
                        {
                            new1.Id = part.Substring(1);//תתן שם root החדש כשם התגית
                            current = new1;//שינתי את האובייקט הנוכחתי להיות האוביירקט החדש
                            root = new1;
                        }
                        else
                        {
                            new1.Classes.Add(part.Substring(1));//תתן שם root החדש כשם התגית
                            current = new1;//שינתי את האובייקט הנוכחתי להיות האוביירקט החדש
                            root = new1;
                        }
                    }
                        
                    
                    //אם אתה תגית 
                     else if (HtmlHelper.Instance.HtmlTagg.Contains(part) || HtmlHelper.Instance.HtmlvoidTagg.Contains(part))
                    {
                        new1.TagName = part;//תתן שם לסלקטור החדש כשם התגית
                        new1.Parent = current;//רשמתי לאובייקט החדש מי אבא KU
                        current.Child = new1;//שייכתי את האוביקט החדש לאבא שלו- הנוכחתי
                        current = new1;//שינתי את האובייקט הנוכחתי להיות האוביירקט החדש
                       // Console.WriteLine("the tag name is:{0}",new1.TagName);
                    }
                    else if (part.StartsWith("#"))
                    {
                        new1.Id = part.Substring(1);
                        current.Child = new1;
                        new1.Parent = current;
                        current = new1;

                       // Console.WriteLine("the id name is:{0}", new1.Id);
                    }
                    else
                    {
                        new1.Classes.Add(part.Substring(1));
                        current.Child = new1;
                        new1.Parent = current;
                        current = new1;
                      //  Console.WriteLine("the classes name is:{0}", new1.Classes);
                    }
                }
                return root;
            }
            //אם אין לך כמה דורות תבנה לי אובייקט ולא עץ עם כל התכונות
            else
            {
                Selector new1 = new Selector();//יצירת אובייקט סלקטוטר חדש
                //אם לא מכיל רווחים
                string pattern = @"([#.]*[^#.]+)";
                MatchCollection matches = Regex.Matches(str, pattern);

                foreach (Match match in matches)//עוברת על כל התכונות שיש לשורה זאת
                {
                    if (!string.IsNullOrEmpty(match.Value)) // אם הערך לא ריק
                    {
                       // Console.WriteLine(match.Value);
                        //אם אתה תגית 
                        if (HtmlHelper.Instance.HtmlTagg.Contains(match.Value) || HtmlHelper.Instance.HtmlvoidTagg.Contains(match.Value))
                        {
                            new1.TagName = match.Value;//תתן שם לסלקטור החדש כשם התגית
                        }
                        else if (match.Value.StartsWith("#"))
                        {
                            new1.Id = match.Value.Substring(1);//אם אתה id 
                        }
                        else
                        {
                            new1.Classes.Add(match.Value.Substring(1));//אם אתה class  תוסיף לסלקטור הנוכחצי את זהזה 
                        }
                    }
                }
                return new1;
            }

        }


    }
}
