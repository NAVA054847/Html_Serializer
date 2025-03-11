
using pp2;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.RegularExpressions;


// שליפת תוכן HTML מכתובת URL
//var html = await Load("https://learn.malkabruk.co.il/practicode/projects/pract-2/#hashset");
var html = File.ReadAllText("test.txt");


//יצירת קובץ
string filePath = "temp.txt";
using (var writer = new StreamWriter(filePath)) ;


// ניקוי HTML: שמירה על רווחים בין מילים והסרת רווחים מיותרים
var cleanhtml = new Regex(@"\s{2,}").Replace(html.Trim(), " ");
Console.ReadLine();
// פיצול ה-HTML לפי תגיות ושמירת טקסט שאינו ריק
var htmllines = new Regex("<(.*?)>").Split(cleanhtml).Where(s => s.Length > 0);
var tempText = " ";


////הדפסה של כל האלנטים בקוד בצורה של מפתח וערך
foreach (var x in htmllines)
{
    var attributes1 = new Regex("([^\\s]*?)=\"(.*?)\"").Matches(x);
    ////הדפסה של כל השורה
    //Console.WriteLine(x);

    //הדפסת המילה הראשונה בשורה
    string firstWord = x.Contains(' ') ? x.Substring(0, x.IndexOf(' ')) : x;

    //הגדרת דגל
    bool flag = false;
    //מעבר על מערך התגיות שלא סגורות  ובודקת האם המילה הראשונה בשורה מהווה שם של תגית פותחת
    for (int i = 0; i < HtmlHelper.Instance.HtmlTagg.Length; i++)
    {
        //אם היא תגית פוצחת אז תעדכן את הדגל להיות טרו
        if (firstWord.Equals(HtmlHelper.Instance.HtmlTagg[i]))
            flag = true; break;
    }


    //אם זה לא תגית אז אז זה תוכן ואל תחתוך ותעתיק את כל השורה



    if (flag)
    {
        using (var writer = new StreamWriter(filePath, append: true))
        {
            writer.WriteLine(x);

        }
    }
    //אם זה תגית תחתוך אלי את שמה ותכניס אותה לקובץ
    else
    {
        using (var writer = new StreamWriter(filePath, append: true))
        {
            writer.WriteLine(firstWord);
        }
    }


    foreach (Match match in attributes1)
    {
        using (var writer = new StreamWriter(filePath, append: true))
        {
            writer.WriteLine($"Attribute {match.Groups[1].Value} Value {match.Groups[2].Value}");
        }
    }
    Console.WriteLine();
}





//הדפסת הקובץ

//if (File.Exists(filePath)) // בדיקה אם הקובץ קיים
//{
//    string[] lines = File.ReadAllLines(filePath); // קריאת כל השורות
//    foreach (var line in lines)
//    {
//        Console.WriteLine(line); // הדפסת כל שורה
//    }
//}
//else
//{
//    Console.WriteLine($"The file '{filePath}' does not exist.");
//}
//Console.WriteLine();











//בנית השורש-html
HtmlElement root = new HtmlElement("html");
root.Attributes.Add("lang=en");
//Console.WriteLine(root.Attributes[0]); בדיקה




//בניית stuck
Stack<HtmlElement> s = new Stack<HtmlElement>();
//הכנסנו את התגית html לstuck
s.Push(root);
//Console.WriteLine(s.Pop());

//מעבר על הקובץ לצורך בניית העץ
HtmlElement curent = root;





if (File.Exists(filePath)) // בדיקה אם הקובץ קיים
{
    string[] lines = File.ReadAllLines(filePath); // קריאת כל השורות
    foreach (var line in lines)
    {

        string fword = line.Contains(' ') ? line.Substring(0, line.IndexOf(' ')) : line;


        //אם אתה תגית 
        if (HtmlHelper.Instance.HtmlTagg.Contains(line) || HtmlHelper.Instance.HtmlvoidTagg.Contains(line))
        {
           

            //אם האבא הנוכחי הוא תגית סגורה
            if (HtmlHelper.Instance.HtmlvoidTagg.Contains(s.Peek().Name))
            {
                //תוציא את התגית הסגורה
                s.Pop();
            }
            HtmlElement newE = new HtmlElement(fword);//בניית עצם בשם 

            curent = s.Peek();//מי האבא כרגע
            newE.Parent = curent;
            s.Push(newE);//הכנסת העצם לסטאק
            curent.Children.Add(newE);//הכנסתי את הילד
        }

        //אם את ה אטיריבוטס
        else if (fword.Equals("Attribute"))
        {
            string result = line.Replace("Attribute ", "");//מחיקת המילה אטריבוט
            result = result.Replace("Value ", "=");//ובמקום ווליו תחליף לי לשווה

            string typ = result.Contains(' ') ? result.Substring(0, result.IndexOf(' ')) : result;//המילה הראשונה

            if (typ.Equals("class"))//אם אתה class
            {
                result = result.Replace("class =", "");//תשאיר לי רק את הערך ו
                s.Peek().Classes.Add(result);//תכניס אתזה לרשימה של ה class שלי
                                           
            }
            else if (typ.Equals("id"))
            {
                result = result.Replace("id =", "");//תשאיר לי רק את הערך ו
                s.Peek().Id = result;//תעדכן את ה id שלי
            }
            else//אם אתה אטריבוט
            {
                s.Peek().Attributes.Add(result);
            }
        }

        else if (fword.StartsWith("/"))//אם אתה תגית סוגרת
        {
            if (s.Count() > 0)
                s.Pop();//סגירת התגית הפתוחה

            if (s.Count() > 0)
                curent = s.Peek();//עדכון האבא הנוכחי

        }

        else if (line.Length != 0)//אם את  הטקסט
        {
            curent.InnerHtml = line;
        }
    }
}
else
{
    Console.WriteLine($"The file '{filePath}' does not exist.");
}










//////////////////////////////////////////////////////////////////////////////
string exam = "div";
Selector newss = Selector.convertt(exam);

//יצירת אשסט שמכיל את הואבייקיט שעונים על התנאי של הסלקטור
HashSet<HtmlElement> l = HtmlElementExtensions.FindElementsBySelector(root, newss);


Console.WriteLine();
//בשביל הראות שזה עובד
foreach (HtmlElement e in l)
{
    Console.WriteLine("name:{0}", e.Name);
    Console.WriteLine("classes:");
    if (e.Classes.Count() > 0)
        for (int i = 0; i < e.Classes.Count(); i++)
            Console.WriteLine(e.Classes[i]);
    if (e.Attributes.Count() > 0)
        for (int i = 0; i < e.Attributes.Count(); i++)
            Console.WriteLine("atribute:",e.Attributes[i]);
    Console.WriteLine("id:{0}",e.Id);
    Console.WriteLine("innerhtml:{0}",e.InnerHtml);
    Console.WriteLine();
}






// פונקציה להורדת HTML מאתר אינטרנט
async Task<string> Load(string url)
{
    HttpClient client = new HttpClient();
    var response = await client.GetAsync(url);
    return await response.Content.ReadAsStringAsync();
}








