using System;
using HtmlAgilityPack;

namespace Wired
{
    class Program
    {
        static void Main(string[] args)
        {
            var document = new HtmlWeb().Load("https://www.wired.com/");
            var summaryList = document.DocumentNode.SelectNodes("//div[contains(@class,'summary-list__items')]");
            foreach (var title in summaryList)
            {
                Console.WriteLine(title.InnerText);
            }
            Console.ReadKey();
        }
    }
}
