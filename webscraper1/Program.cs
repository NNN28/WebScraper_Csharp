using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace webscraper1
{
    class Program
        
    {
        static  void Main(string[] args)
        {


            //startcwaulerAsync();
            crawlerweb();
            Console.ReadLine();
        }
       private static async Task startcwaulerAsync()
        {
            var url = "https://www.automobile.tn/neuf/bmw.3/";
            var httpclient = new HttpClient();
            var html = await httpclient.GetStringAsync(url);

            var htmldocument = new HtmlDocument();

            htmldocument.LoadHtml(html);
            var divs = htmldocument.DocumentNode.Descendants("div").
                 Where(node => node.GetAttributeValue("class", "").
             Equals("article_new_car article_last_modele")).ToList();
            var listcar = new List<car>();
            foreach (var div in divs)
            {
                var name = div.Descendants("h2").FirstOrDefault().InnerText;
                var price = div.Descendants("div").FirstOrDefault().Element("span").InnerText;
                var imgurl = div.Descendants("img").FirstOrDefault().ChildAttributes("src").FirstOrDefault().Value;
                var link = div.Descendants("a").FirstOrDefault().ChildAttributes("href").FirstOrDefault().Value;

                var car = new car(name, price, imgurl, link);
                listcar.Add(car);
              
            }
            for(int i=0; i<=14; i++) { Console.WriteLine(listcar[i]); }
           
        }

        public class car
        {
            private String name;
            private String price;
            private String imgurl;
            private String link;

            public car(string name, string price, string imgurl, string link)
            {
                this.name = name;
                this.Price = price;
                this.Imgurl = imgurl;
                this.link = link;
            }

            public string Name { get => name; set => name = value; }
            public string Price { get => price; set => price = value; }
            public string Imgurl { get => imgurl; set => imgurl = value; }
            public string Link { get => link; set => link = value; }
        }
     /*   private static async void crawlerweb()

        {
            var searchword= "iphone 8 plus";
            var url = "https://www.amazon.com.br/s/ref=nb_sb_noss/141-1509725-5841359?__mk_pt_BR=ÅMÅŽÕÑ&url=search-alias%3Daps&field-keywords="+searchword;
           HttpClient httpclient = new HttpClient();
             var html = await httpclient.GetStringAsync(url);
             HtmlDocument htmldoc = new HtmlDocument();
             htmldoc.LoadHtml(html);

            var res = htmldoc.DocumentNode.Descendants();
            HttpWebRequest httpreq =(HttpWebRequest) WebRequest.Create(url);
            HttpWebResponse Response = (HttpWebResponse) httpreq.GetResponse();
           StreamReader sr = new StreamReader(Response.GetResponseStream());
            String read_text = sr.ReadToEnd();
            HtmlDocument htmldocument = new HtmlDocument();
            htmldocument.LoadHtml(read_text);
            var divs = htmldocument.DocumentNode.Descendants("div").
                 Where(node => node.GetAttributeValue("class", "").
             Equals("s-item-container")).ToList(); 

            foreach(var div in divs)
            {
                var name = div.Descendants("h2").FirstOrDefault().InnerText;
                var price = div.ChildNodes.Descendants("span").Where(node => node.GetAttributeValue("class", "").

               Equals("a-size-base a-color-price a-text-bold")).FirstOrDefault().InnerText ;

                ///html[1]/body[1]/div[1]/div[2]/div[1]/div[3]/div[2]/div[1]/div[4]/div[1]/div[1]/ul[1]/li[2]/div[1]/div[4]/div[3]/a[1]/span[1]
                /////*[@id="result_0"]/div/div[4]/div/a/span[1]
                var autrepprice = htmldocument.DocumentNode.SelectNodes("//*[@id=\"result_0\"]//div//div//div//a//span").FirstOrDefault().InnerText;
                    
            }



        }*/

    }
}
