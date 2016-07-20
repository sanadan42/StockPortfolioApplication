using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;


namespace StockPortfolioApplication
{
    class StockDataRetriever
    {

        public void GetHistoricalStockPrices(string symbol)
        {
            List<float> prices = new List<float>();
            GetStockPrices(symbol);
        }

        // from: http://csharphelper.com/blog/2016/05/graph-historical-stock-prices-in-c/
        // Get the prices for this symbol.
        private List<float> GetStockPrices(string symbol)
        {
            // Compose the URL.
            string url = "http://www.google.com/finance/historical?output=csv&q=" + symbol;

            // Get the web response.
            string result = GetWebResponse(url);

            // Get the historical prices.
            string[] lines = result.Split(
                new char[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            List<float> prices = new List<float> ();
            // Process the lines, skipping the header.
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                prices.Add(float.Parse(line.Split(',')[4]));
            }

            return prices;
        }

        // from: http://csharphelper.com/blog/2016/05/graph-historical-stock-prices-in-c/
        // Get a web response.
        private string GetWebResponse(string url)
        {
            // Make a WebClient.
            WebClient web_client = new WebClient();

            // Get the indicated URL.
            Stream response = web_client.OpenRead(url);

            // Read the result.
            using (StreamReader stream_reader = new StreamReader(response))
            {
                // Get the results.
                string result = stream_reader.ReadToEnd();

                // Close the stream reader and its underlying stream.
                stream_reader.Close();

                // Return the result.
                return result;
            }
        }
    }

    class YahooStockDataRetriever
        // i'm trying to piece this together from various pieces of code I find online
    {
        
        // Get a web response.
        private string GetWebResponse(string url)
        {
            // Make a WebClient.
            WebClient web_client = new WebClient();

            // Get the indicated URL.
            Stream response = web_client.OpenRead(url);

            // Read the result.
            using (StreamReader stream_reader = new StreamReader(response))
            {
                // Get the results.
                string result = stream_reader.ReadToEnd();

                // Close the stream reader and its underlying stream.
                stream_reader.Close();

                // Return the result.
                return result;
            }
        }
    }
}
