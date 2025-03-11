using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pp2
{
    public class HtmlElement
    {


        public string Id { get; set; }
        public string Name { get; set; }

        // רשימת מאפיינים (Attributes) - זוגות של שם וערך
        public List<string> Attributes { get; set; }// = new Dictionary<string, string>();

        // רשימת מחלקות (Classes) - שמות המחלקות שמחוברות לתגית
        public List<string> Classes { get; set; } //= new List<string>();
        public string InnerHtml { get; set; }

        public HtmlElement Parent { get; set; } // תגית ההורה
        public List<HtmlElement> Children { get; set; } // רשימת תגיות ילדים


        public HtmlElement(string name)
        {
            this.Id = "null";
            this.Name = name;
            this.Attributes = new List<string>();
            this.Classes = new List<string>();
            this.InnerHtml = "null";
            this.Parent = null;
            this.Children = new List<HtmlElement>();
        }




        //פונקציה שמחזירה את כל הצאצאים של אובייקט מסויים
        public static IEnumerable<HtmlElement> Descendants(HtmlElement root)
        {
            // הגדרת התור לשמירה זמנית של הילדים
            Queue<HtmlElement> q = new Queue<HtmlElement>();
            q.Enqueue(root); // אתחול עם השורש

            // כל עוד התור לא ריק
            while (q.Count > 0)
            {
                // שליפת האובייקט הראשון בתור
                HtmlElement current = q.Dequeue();

                // החזרת האובייקט באמצעות yield return
                yield return current;

                // הוספת כל הילדים של האובייקט הנוכחי לתור
                foreach (var child in current.Children)
                {
                    q.Enqueue(child);
                }
            }
        }



        //כאן שמור לי מה שיש ברשימה
        // List<HtmlElement> descendants = Descendants(root).ToList();

    

        //פונקציה שמחזירה רשימה של כל האבות
        public List<HtmlElement> Ancestors(HtmlElement child)
        {
            HtmlElement current =child.Parent;//הואבייקט הנוכחי
            List<HtmlElement> l= new List<HtmlElement>();
            //כל עוד יש לך אבא 
            while (current!= null)
            {
                l.Add(current);
                current = current.Parent;
            }
            return l;  
        }
       
    }
}
