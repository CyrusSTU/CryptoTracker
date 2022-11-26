using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using RestSharp;
using CryptoTracker.Model;

namespace CryptoTracker
{
    public partial class MainPage : ContentPage
    {
        private string apiKey = "267468AE-483B-47D8-BFE0-8511F3D8C700";
        private string baseImageURL = "https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_64/";
        public MainPage()
        {
            InitializeComponent();
            CoinListView.ItemsSource = GetCoins();

        }

        private void Refresh_Clicked(object sender, EventArgs e)
        {
            CoinListView.ItemsSource = GetCoins();
        }
        
        private List<Coins> GetCoins()
        {
            List<Coins> coins;
            var client = new RestClient("http://rest.coinapi.io/v1/assets/?filter_asset_id=BTC;ETH;XMR;LTC;DOGE");
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-CoinAPI-Key", apiKey);
            var reponse = client.Execute(request);
            coins = JsonConvert.DeserializeObject<List<Coins>>(reponse.Content);

            foreach (var c in coins)
            {
                c.Icon_Url = baseImageURL + c.id_icon.Replace("-", "") + ".png";
            }

            return coins;
        }
    }
}
