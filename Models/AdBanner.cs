﻿using Newtonsoft.Json;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShopTemplateAPI.Models
{
    public partial class AdBanner
    {
        [JsonIgnore]
        public int AdBannerId { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
    }
}
