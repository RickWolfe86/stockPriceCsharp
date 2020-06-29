using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace StockPrice
{
    class StockPrice
    {
        static void Main(string[] args)
        {
            Console.WriteLine(openAndClosePrices("26-March-2000", "15-August-2000", "Wednesday"));
        }


        public static string openAndClosePrices(string firstDate, string lastDate, string weekDay)
        {
            string strResponseValue = string.Empty;
            List<string> finalList = new List<string>();
            
            //Parsing the dates with named months to a Datetime
            DateTime dateMin = DateTime.ParseExact(firstDate, "dd-MMMM-yyyy", CultureInfo.CurrentCulture);
            DateTime dateMax = DateTime.ParseExact(lastDate, "dd-MMMM-yyyy", CultureInfo.CurrentCulture);

            while (dateMin <= dateMax)
            {
                int maxPageIndex = 1;
                //maxPageIndex will start at 1, and will be setted in the first interation
                for (int nIndexPage = 1; nIndexPage <= maxPageIndex && maxPageIndex > 0; nIndexPage++)
                {
                    //setting the endpoint with the month and not the day for better perfomance
                    string endPoint = "https://jsonmock.hackerrank.com/api/stocks/search?date=" + dateMin.ToString("MMMM-yyyy") + "&page=" + nIndexPage;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
                    request.Method = "GET";

                    //Calling the endpoint
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new ApplicationException("Error" + response.StatusCode.ToString());
                        }

                        
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            if (responseStream != null)
                            {
                                using (StreamReader reader = new StreamReader(responseStream))
                                {
                                    strResponseValue = reader.ReadToEnd();
                                }
                            }
                        }
                    }
                    //Parsing the received string to JSON object
                    var responseJSON = JObject.Parse(strResponseValue);

                    //Now I have the total of pages then I update the maxPageIndex
                    maxPageIndex = Convert.ToInt32(responseJSON["total_pages"]);

                    //Iterate of the data
                    foreach (var item in responseJSON["data"])
                    {
                        var dt = DateTime.ParseExact(item["date"].ToString(), "d-MMMM-yyyy", CultureInfo.CurrentCulture);
                        if (dateMin <= dt && dt <= dateMax)
                        {
                            if (dt.DayOfWeek.ToString().ToLower() == weekDay.ToLower())
                            {
                                finalList.Add(item["date"] + " " + item["open"] + " " + item["close"]);
                            }
                        }
                    }

                }
                //Get the lastDay of the month and add one more day to get the next month
                int lastDay = DateTime.DaysInMonth(dateMin.Year, dateMin.Month);
                dateMin = new DateTime(dateMin.Year, dateMin.Month, lastDay).AddDays(1);
            }

            //Finally I create the return string
            StringBuilder builder = new StringBuilder();
            foreach(var item in finalList)
            {
                builder.AppendLine(item);
            }
            return builder.ToString();

        }
    }
}
