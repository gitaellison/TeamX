using Newtonsoft.Json;
using System.Collections.Generic;


public class Root {
    [JsonProperty("description")]
    public Description description{get;set;}
} 
public class Description
{
    [JsonProperty("tags")]
    public List<string> Tag { get; set; }

    [JsonProperty("captions")]
    public List<Caption> Caption { get; set; }

}

public class Caption
{
    [JsonProperty("text")]
    public string text { get; set; }

    [JsonProperty("confidence")]
    public string conf { get; set; }
}

