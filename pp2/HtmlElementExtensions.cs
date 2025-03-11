using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pp2
{
    //פונקצית הרחבה לhtmlElement
    //פונקציה שמקבלת את ההשורש של האלמנט ואת הסךקטור ומחזירה אשסט של כל האלמנטים ענו על הסלקוטר
    public static class HtmlElementExtensions
    {
        //פונקצית מעטפת
        public static HashSet<HtmlElement> FindElementsBySelector(this HtmlElement root, Selector selector)
        {
            var results = new HashSet<HtmlElement>();
            FindElementsRecursively(root, selector, results);
            return results;
        }

        private static void FindElementsRecursively(HtmlElement element, Selector selector, HashSet<HtmlElement> results)
        {
            // שלב 1: קבלת כל הצאצאים של האלמנט הנוכחי
            var descendants =HtmlElement.Descendants( element);

            // שלב 2: סינון האלמנטים שעונים לקריטריונים של הסלקטור הנוכחי
            var matchingElements = descendants.Where(e => MatchesSelector(e, selector)).ToHashSet();

            // שלב 3: תנאי עצירה - אם זה הסלקטור האחרון, הוסף את כל האלמנטים שמתאימים לרשימת התוצאות
            if (selector.Child == null)
            {
                results.UnionWith(matchingElements);
                return;
            }

            // שלב 4: ריקורסיה - עבור על האלמנטים המתאימים והרץ עליהם את הסלקטור הבא
            foreach (var match in matchingElements)
            {
                FindElementsRecursively(match, selector.Child, results);
            }
        }

        private static bool MatchesSelector(HtmlElement element, Selector selector)
        {
            // בדיקה אם האלמנט מתאים לקריטריונים של הסלקטור
            if (!string.IsNullOrEmpty(selector.TagName) && !element.Name.Equals(selector.TagName, StringComparison.OrdinalIgnoreCase))
                return false;

            if (!string.IsNullOrEmpty(selector.Id) && !element.Id.Equals(selector.Id, StringComparison.OrdinalIgnoreCase))
                return false;

            if (selector.Classes.Any() && !selector.Classes.All(cls => element.Classes.Contains(cls)))
                return false;

            return true;
        }
    }

}
