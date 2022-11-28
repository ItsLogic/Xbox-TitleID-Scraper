using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;

namespace TitleID_Scraper
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static HttpClientHandler handler = new HttpClientHandler()
        {
            AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
        };
        int Selection = 0;
        string APILink;
        void BTN_Grab_Click(object sender, EventArgs e)
        {
            //gamepass console url https://catalog.gamepass.com/sigls/v2?id=f6f1f99f-9b49-4ccd-b3bf-4d9767a77f5e&language=en-gb&market=GB
            //gamepass pc url https://catalog.gamepass.com/sigls/v2?id=609d944c-d395-4c0a-9ea4-e9f39b52c1ad&language=en-gb&market=GB
            Selection = Int32.Parse((PlatformDropdown.SelectedIndex + 1).ToString() + (CategoryDropdown.SelectedIndex + 1).ToString());
            switch (Selection)
            {
                case 11:
                    APILink = "https://reco-public.rec.mp.microsoft.com/channels/Reco/V8.0/Lists/Computed/BestRated?Market=gb&Language=en&ItemTypes=Game&deviceFamily=Windows.Xbox&count=2000&skipitems=0";
                    GetOther();
                    break;
                case 12:
                    APILink = "https://reco-public.rec.mp.microsoft.com/channels/Reco/V8.0/Lists/Computed/ComingSoon?Market=gb&Language=en&ItemTypes=Game&deviceFamily=Windows.Xbox&count=2000&skipitems=0";
                    GetOther();
                    break; ;
                case 13:
                    APILink = "https://reco-public.rec.mp.microsoft.com/channels/Reco/V8.0/Lists/Computed/Deal?Market=gb&Language=en&ItemTypes=Game&deviceFamily=Windows.Xbox&count=2000&skipitems=0";
                    GetOther();
                    break; ;
                case 14:
                    APILink = "https://reco-public.rec.mp.microsoft.com/channels/Reco/V8.0/Lists/Computed/MostPlayed?Market=gb&Language=en&ItemTypes=Game&deviceFamily=Windows.Xbox&count=2000&skipitems=0";
                    GetOther();
                    break; ;
                case 15:
                    APILink = "https://reco-public.rec.mp.microsoft.com/channels/Reco/V8.0/Lists/Computed/New?Market=gb&Language=en&ItemTypes=Game&deviceFamily=Windows.Xbox&count=2000&skipitems=0";
                    GetOther();
                    break; ;
                case 16:
                    APILink = "https://reco-public.rec.mp.microsoft.com/channels/Reco/V8.0/Lists/Computed/TopFree?Market=gb&Language=en&ItemTypes=Game&deviceFamily=Windows.Xbox&count=2000&skipitems=0";
                    GetOther();
                    break; ;
                case 17:
                    APILink = "https://reco-public.rec.mp.microsoft.com/channels/Reco/V8.0/Lists/Computed/TopPaid?Market=gb&Language=en&ItemTypes=Game&deviceFamily=Windows.Xbox&count=2000&skipitems=0";
                    GetOther();
                    break; ;
                case 18:
                    APILink = "https://catalog.gamepass.com/sigls/v2?id=f6f1f99f-9b49-4ccd-b3bf-4d9767a77f5e&language=en-gb&market=GB";
                    GetGamepass();
                    break;
                case 21:
                    APILink = "https://reco-public.rec.mp.microsoft.com/channels/Reco/V8.0/Lists/Computed/BestRated?Market=gb&Language=en&ItemTypes=Game&deviceFamily=Windows.Desktop&count=2000&skipitems=0";
                    GetOther();
                    break;
                case 22:
                    APILink = "https://reco-public.rec.mp.microsoft.com/channels/Reco/V8.0/Lists/Computed/ComingSoon?Market=gb&Language=en&ItemTypes=Game&deviceFamily=Windows.Desktop&count=2000&skipitems=0";
                    GetOther();
                    break;
                case 23:
                    APILink = "https://reco-public.rec.mp.microsoft.com/channels/Reco/V8.0/Lists/Computed/Deal?Market=gb&Language=en&ItemTypes=Game&deviceFamily=Windows.Desktop&count=2000&skipitems=0";
                    GetOther();
                    break;
                case 24:
                    APILink = "https://reco-public.rec.mp.microsoft.com/channels/Reco/V8.0/Lists/Computed/MostPlayed?Market=gb&Language=en&ItemTypes=Game&deviceFamily=Windows.Desktop&count=2000&skipitems=0";
                    GetOther();
                    break;
                case 25:
                    APILink = "https://reco-public.rec.mp.microsoft.com/channels/Reco/V8.0/Lists/Computed/New?Market=gb&Language=en&ItemTypes=Game&deviceFamily=Windows.Desktop&count=2000&skipitems=0";
                    GetOther();
                    break;
                case 26:
                    APILink = "https://reco-public.rec.mp.microsoft.com/channels/Reco/V8.0/Lists/Computed/TopFree?Market=gb&Language=en&ItemTypes=Game&deviceFamily=Windows.Desktop&count=2000&skipitems=0";
                    GetOther();
                    break;
                case 27:
                    APILink = "https://reco-public.rec.mp.microsoft.com/channels/Reco/V8.0/Lists/Computed/TopPaid?Market=gb&Language=en&ItemTypes=Game&deviceFamily=Windows.Desktop&count=2000&skipitems=0";
                    GetOther();
                    break;
                case 28:
                    APILink = "https://catalog.gamepass.com/sigls/v2?id=609d944c-d395-4c0a-9ea4-e9f39b52c1ad&language=en-gb&market=GB";
                    GetGamepass();
                    break;
                default:
                    MessageBox.Show("Choose platform and category", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

            }
        }

        async void GetGamepass()
        {
            string ProductIDsFormatted = "{\"Products\":[";
            HttpClient client = new HttpClient(handler);
            var responseString = await client.GetStringAsync(APILink);
            var Jsonresponse = (dynamic)(new JArray());
            Jsonresponse = (dynamic)JArray.Parse(responseString);
            for (int i = 0; i < Jsonresponse.Count; i++)
            {
                if (Jsonresponse[i].id != null)
                {
                    ProductIDsFormatted = ProductIDsFormatted + "\"" + Jsonresponse[i].id + "\",";
                }
            }
            ProductIDsFormatted = ProductIDsFormatted.Remove(ProductIDsFormatted.Length - 1) + "]}";
            var ProductIDsConverted = new StringContent(ProductIDsFormatted);
            var TitleIDsResponse = await client.PostAsync("https://catalog.gamepass.com/products?market=GB&language=en-GB&hydration=PCHome", ProductIDsConverted);
            string TitleIDsContent = await TitleIDsResponse.Content.ReadAsStringAsync();
            var JsonTitleIDs = (dynamic)JObject.Parse(TitleIDsContent);
            using (StreamWriter writer = new StreamWriter((PlatformDropdown.Items[PlatformDropdown.SelectedIndex].ToString()) + "Gamepass.txt"))
            {
                foreach (var Product in JsonTitleIDs.Products)
                {
                    foreach (var Title in Product)
                    {
                        if (Title.ToString().Contains("\"ProductType\": \"Game\",") && Title.XboxTitleId != null)
                        {
                            writer.WriteLine(Title.XboxTitleId.ToString() + "," + Title.ProductTitle.ToString());
                        }

                    }
                }
            }
        }

        async void GetOther()
        {
            string ProductIDsFormatted = "{\"Products\":[";
            HttpClient client = new HttpClient(handler);
            var responseString = await client.GetStringAsync(APILink);
            var Jsonresponse = (dynamic)(new JArray());
            Jsonresponse = (dynamic)JObject.Parse(responseString);
            var gamenum = 0;
            while (gamenum < (int)Jsonresponse.PagingInfo.TotalItems)
            {
                gamenum = gamenum + 200;
                for (int i = 0; i < Jsonresponse.Items.Count; i++)
                {
                    if (Jsonresponse.Items[i].Id != null)
                    {
                        ProductIDsFormatted = ProductIDsFormatted + "\"" + Jsonresponse.Items[i].Id + "\",";
                    }
                }
                Thread.Sleep(200);
                var newlink = APILink.Substring(APILink.Length - 3) + gamenum.ToString();
                responseString = await client.GetStringAsync(APILink);
                Jsonresponse = (dynamic)(new JArray());
                Jsonresponse = (dynamic)JObject.Parse(responseString);
            }


            ProductIDsFormatted = ProductIDsFormatted.Remove(ProductIDsFormatted.Length - 1) + "]}";
            var ProductIDsConverted = new StringContent(ProductIDsFormatted);
            var TitleIDsResponse = await client.PostAsync("https://catalog.gamepass.com/products?market=GB&language=en-GB&hydration=PCHome", ProductIDsConverted);
            string TitleIDsContent = await TitleIDsResponse.Content.ReadAsStringAsync();
            var JsonTitleIDs = (dynamic)JObject.Parse(TitleIDsContent);
            using (StreamWriter writer = new StreamWriter((PlatformDropdown.Items[PlatformDropdown.SelectedIndex].ToString()) + (CategoryDropdown.Items[CategoryDropdown.SelectedIndex].ToString()) + ".txt"))
            {
                foreach (var Product in JsonTitleIDs.Products)
                {
                    foreach (var Title in Product)
                    {
                        if (Title.ToString().Contains("\"ProductType\": \"Game\",") && Title.XboxTitleId != null)
                        {
                            writer.WriteLine(Title.XboxTitleId.ToString() + "," + Title.ProductTitle.ToString());
                        }

                    }
                }
            }
        }

        async void BTN_Link_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient(handler);
            string[] Link = TXT_Link.Text.Split("/");
            if (Link[Link.Count() - 1].Length != 0)
            {

                var ProductIDsConverted = new StringContent("{\"Products\":[\"" + Link[Link.Count() - 1] + "\"]}");
                var TitleIDsResponse = await client.PostAsync(
                    "https://catalog.gamepass.com/products?market=GB&language=en-GB&hydration=PCHome",
                    ProductIDsConverted);
                string TitleIDsContent = await TitleIDsResponse.Content.ReadAsStringAsync();
                var JsonTitleIDs = (dynamic)JObject.Parse(TitleIDsContent);
                foreach (var Product in JsonTitleIDs.Products)
                {
                    foreach (var Title in Product)
                    {
                        if (Title.ToString().Contains("\"ProductType\": \"Game\",") && Title.XboxTitleId != null)
                        {
                            TXT_ID.Text = TXT_ID.Text + Title.ProductTitle.ToString() + "\n";
                            TXT_ID.Text = TXT_ID.Text + Title.XboxTitleId.ToString() + "\n" + "\n";
                        }

                    }
                }

            }
            else
            {
                MessageBox.Show("This link is invalid or there is a / at the end. Remove it and try again",
                    "Invalid Link", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
