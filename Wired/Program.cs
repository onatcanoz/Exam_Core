using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace Wired
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var document = new HtmlWeb().Load("https://www.wired.com/");
    //        var summaryList = document.DocumentNode.SelectNodes("//div[contains(@class,'summary-list__items')]");
    //        foreach (var title in summaryList) 
    //        {
    //            Console.WriteLine(title.InnerText);
    //        }
    //        Console.ReadKey();
    //    }
    //}

    class Program
    {
        public static readonly string CLASS_NAME = "summary-item__hed";
        public static readonly string Url = "http://www.wired.com/";
        static void Main(string[] args)
        {
            GetTitles();
            Console.Read();
        }

        public static List<string> GetTitles()
        {
            List<string> titles = new List<string>();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(Url);
            if (doc == null || doc.DocumentNode == null)
            {
                return titles;
            }
            var nodes = doc.DocumentNode.SelectNodes("//*[@class=\"" + CLASS_NAME + "\"]");
            if (nodes == null)
                return titles;
            titles = nodes.Take(5).Select(x => x.InnerText).ToList();
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
            
            return titles;
        }
    }
}
