using Newtonsoft.Json;

namespace CurrencyExchanger;

public class Rate
{
    [JsonProperty("code")]
    public string Code { get; set; }
    [JsonProperty("bid")]
    public double Bid { get; set; }
    [JsonProperty("ask")]
    public double Ask { get; set; }
}