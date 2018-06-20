//Copyright Gerald Keller 2017
using Newtonsoft.Json;

namespace geraldkeller.com.DTOs
{
  [JsonObject]
  public class ResumeDto
  {
    [JsonProperty]
    public string value { get; set; }

    public ResumeDto()
    {
    }
  }
}