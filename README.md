------------------------------------------------------------------------------------
# 📄 Html_Serialize

## ✨ Project Description

This project is designed for processing and handling HTML files, while developing an infrastructure that allows implementing a Crawler (or Scraper).

The tool enables analyzing the HTML structure and extracting useful information.

## 🎯 Project Goals


✔️ Develop a basic infrastructure for implementing a Crawler (or Scraper) for analyzing **HTML** pages.

✔️ Create a system that converts **HTML** into **C#** objects.

✔️ Build a hierarchical tree of **HTML** tags.

✔️ Enable executing queries on the **HTML** tree using **CSS Selectors**.

## 🏗️Project Structure

The project consists of two main components:

1️⃣ **Html Serializer** – A service for converting **HTML** pages into **C#** objects.

2️⃣ **Html Query** – A service for querying the **HTML** structure using **CSS** Selectors.

## 🔎 Details

1️⃣ Html Serializer
   
This module is responsible for converting **HTML** into **C#** objects.

### It includes the following steps:

✔️**Fetching a web page** – Using HttpClient to request a web page and download the HTML content.

✔️**Parsing by tags** – Using Regular Expressions (Regex) to identify HTML tags and clean up unnecessary whitespace.

✔️**HtmlElement class** – Represents HTML tags as objects containing an ID (Id), tag name (Name), attributes (Attributes), class list (Classes), inner content (InnerHtml), and hierarchical relationships (Parent and Children).

✔️**HtmlHelper class** – Provides a list of HTML tags from a JSON file, implemented as a Singleton to prevent redundant loading.

✔️**Building an HTML tree** – Iterates over the tag list and constructs a hierarchy of HtmlElement objects.

2️⃣ Html Query
   
This module is responsible for searching elements within the HTML tree using CSS Selectors.

Selector class – Represents a selector containing search details such as tag name (TagName), ID (Id), and class list (Classes).
Parsing Selector queries – Converts selector strings into Selector objects.

### Tree navigation functions:

✔️**Descendants** – Returns all child elements of a given element.

✔️**Ancestors** – Returns all parent elements of a given element.

✔️**Searching elements in the tree by Selector** – Implements a function that searches for elements in the tree using navigation functions.

✔️**Avoiding duplicates** – Uses a HashSet to prevent duplicate results in queries.

## 🛠️ Technologies & Tools:

**Programming Language:** **C#**

**Libraries:** **System.Net.Http**, **System.Text.Json**, **Regex**

**Development Principles:** Singleton, Queue for tree search management, HashSet for preventing duplicates

##  🚀 Installation & Execution:

**⚙️ System Requirements**

✔️ .NET 6 or later

✔️ Visual Studio (or any .NET-compatible development environment)

✔️ Internet connection (to fetch HTML pages from the web)

## Steps to Install & Run 

1️⃣ Clone the project.

2️⃣ Open the project in Visual Studio.

3️⃣ Run the build and execution commands: dotnet build followed by dotnet run.

4️⃣ Modify the selector as needed.

5️⃣ View the output in the console.

## Detailed Steps

1️⃣ Clone the Project
Download or clone the project source code from GitHub:


    git clone https://github.com/NAVA054847/Html_Serializer.git
   
2️⃣ Open the Project

Open the directory containing the code using Visual Studio or the command line.

3️⃣ Compile & Run
   
Ensure the project is successfully built by running the following command:


    dotnet build
   
To execute the application, run:


    dotnet run
    
4️⃣ Modify the Target URL
   
To change the website URL you want to scrape, update the URL inside the quotes in the Program.cs file.

For example, if you want to scrape https://example.com, modify this line:


    var html = await Load("https://example.com");
    
The code will then fetch HTML content from the new URL you specified.

Use a Local File Instead of a URL
If you want to use a local file instead of fetching content from a URL, modify this line:


    var html = File.ReadAllText("test.txt");
    Where "test.txt" is a file located within your project.

Modify the CSS Selector
The line where you define the CSS Selector is:


    string exam = "div";
    Selector newss = Selector.convertt(exam);
   
You can replace "div" with the CSS selector you want to search for.

For example, to find a <div> with the class "container", update it like this:


    string exam = "div.container";
    Selector newss = Selector.convertt(exam);

5️⃣ Console Output

After running the code, the output will be displayed in the Console.

You will see all the elements that match your **CSS** Selector.

For example, if searching for <div>, the output might look like this:


name: div

classes: class1 class2

attribute: id

id: div1

innerhtml:Example Content

































-----------------------------------





<div dir="rtl">

# 📄 Html_Serialize

## ✨ תיאור הפרויקט

פרויקט זה מיועד לטיפול ועיבוד קבצי **HTML**, תוך פיתוח תשתית שתאפשר מימוש של **Crawler** (או **Scraper**).  

🛠️ הכלי מאפשר לנתח את מבנה ה-**HTML** ולשלוף ממנו מידע שימושי.

## 🎯 מטרות הפרויקט

✔️ פיתוח תשתית בסיסית למימוש **Crawler** (או **Scraper**) לניתוח דפי **HTML**.  

✔️ יצירת מערכת הממירה **HTML** לאובייקטים בשפת **C#**.  

✔️ בניית עץ היררכי של תגיות **HTML**.  

✔️ מתן אפשרות לביצוע שאילתות על עץ ה-**HTML** באמצעות **CSS Selectors**.  

--------------

## 🏗️ מבנה הפרויקט

הפרויקט מורכב משני חלקים עיקריים:

1️⃣ **Html Serializer** - שירות להמרת דפי **HTML** לאובייקטים של **C#**.  

2️⃣ **Html Query** - שירות לתשאול מבנה ה-**HTML** באמצעות **CSS Selectors**.  

### 🔎 פירוט


#### 1️⃣ Html Serializer

🛠️ מודול זה אחראי על המרת **HTML** לאובייקטים ב-**C#**.  

📌 **שלבי העבודה**

- **קריאה לדף אינטרנט** – שימוש ב-`HttpClient` להורדת תוכן **HTML**.
  
- **פירוק לפי תגיות** – שימוש ב-**Regex** לזיהוי תגיות **HTML** וניקוי תוכן מיותר.
  
-  **מחלקת HtmlElement** – ייצוג תגיות **HTML** כאובייקטים עם מזהה (`Id`), שם תגית (`Name`), מאפיינים (`Attributes`), מחלקות (`Classes`), תוכן פנימי (`InnerHtml`) וקשרים (`Parent` ו-`Children`).
  
-  **מחלקת HtmlHelper** – מימוש **Singleton** למניעת טעינות חוזרות.
  
-  **בניית עץ HTML** – יצירת היררכיה בין תגיות ה-**HTML**.

#### 2️⃣ Html Query

🔎 מודול זה אחראי על חיפוש אלמנטים בעץ ה-**HTML** באמצעות **CSS Selectors**.

📌 **מרכיבים עיקריים**:

- **מחלקת Selector** – ייצוג סלקטור לפי **TagName**, **Id** ו-**Classes**.
  
-  **פירוק שאילתות Selector** – המרה של טקסט **CSS Selector** לאובייקטים.
  
  
  **פונקציות ניווט בעץ**:
  
  
   📌 `Descendants` – מחזירה את כל הצאצאים של אלמנט מסוים.
    
   📌 `Ancestors` – מחזירה את כל האבות של אלמנט מסוים.
- **חיפוש אלמנטים בעץ**– פונקציה המחפשת אלמנטים בעץ באמצעות הסלקטור.
  
- **מניעת כפילויות**– שימוש ב-`HashSet` למניעת תוצאות כפולות.

------------------

## 🛠️ טכנולוגיות וכלים

🔹 **שפת תכנות**: **C#**  

🔹 **ספריות**: `System.Net.Http`, `System.Text.Json`, `Regex`  

🔹 **עקרונות פיתוח**:  


   - **Singleton** למניעת טעינות כפולות
     
   - **Queue** לניהול חיפושים בעץ
     
   - **HashSet** למניעת כפילויות  

----------

## 🚀 התקנה והפעלה

### ⚙️ דרישות מערכת

- ✅ **.NET 6** ומעלה
  
- ✅ **Visual Studio** (או סביבת פיתוח תומכת **.NET**)  
- ✅ **חיבור לאינטרנט** (לשליפת דפי **HTML** מהרשת)  

### 📌 שלבי התקנה והרצה


1.שכפול הפרויקט.

2.פתיחת הפרויקט ב-Visual Studio.

3.הפעלת הפקודות dotnet build ואז dotnet run.

4.שינוי הסלקטור לפי הצורך.

5.פלט יופיע במסך.

### פירוט:

1️⃣ **שכפול הפרויקט**  

   יש להוריד או לשכפל (**clone**) את קוד הפרויקט ממאגר ה-GitHub:  

  
      git clone https://github.com/NAVA054847/Html_Serializer.git

2️⃣ **פתיחת הפרויקט**

יש לפתוח את התיקייה המכילה את הקוד באמצעות **Visual Studio** או באמצעות שורת הפקודה.

 3 **קומפילציה והרצה**
 
 יש לוודא שהפרויקט נבנה בהצלחה על ידי הפעלת הפקודה הבאה במסוף:

    dotnet build

להרצת האפליקציה:

    dotnet run

 
 



