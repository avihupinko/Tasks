using Newtonsoft.Json;

namespace Tasks.Models
{
    public class OpenTasksLogicModel
    {
        [JsonProperty("name")]
        public required string Name { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
