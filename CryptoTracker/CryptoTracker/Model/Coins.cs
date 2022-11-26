using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoTracker.Model
{
    internal class Coins
    {
        public string Asset_Id { get; set; }
        public string Name { get; set; }
        public float Price_USD { get; set; }
        public string id_icon { get; set; }
        public string Icon_Url { get; set; }
    }
}
