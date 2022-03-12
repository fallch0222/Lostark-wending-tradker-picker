using System.Collections.Specialized;
using System.Net;
using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;

namespace LostArk_Wandering_Trader
{
    class pro
    {
        public static string outputContent = "";
        public static void Main(string[] args)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //URL connect
                driver.Url = "https://ptb.discord.com/channels/660684739056762891/875018290995548180";
                //ready
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);


                Delay(10000);

                //while (true)
                { 
                    //find xpath
                    var element = driver.FindElement(By.XPath("//*[@id=\"message-content-951443263112491038\"]/div/blockquote"));


                    

              
                    try
                    {
                        
                        Console.WriteLine(outputContent);
                        
                        outputContent = element.Text.ToString().Trim(' ').Split(']')[1].Split('-')[0];

         
                        
            
                    
                        var wb = new WebClient();
                        var data = new NameValueCollection();
                        string url = "https://api.fhdk.gg/reports";
                        data["Location"] = outputContent.Split('/')[0];
                        data["Specified Location"] = outputContent.Split('/')[1];
                        data["Card"] = outputContent.Split('/')[2];
                        data["Herohogamdo"] = outputContent.Split('/')[3];

                        wb.UploadValues(url, "POST", data);
                    }
                    catch (Exception e)
                    { 
                        Console.WriteLine(e.ToString());
                       
                    }
                    
                }
               

            }

            



          
        }

        private static DateTime Delay(int MS) //delay
        {
            // More effective then Thread and Timer
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {

                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }
    }
}


;
