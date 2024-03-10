using Newtonsoft.Json;

namespace Tasks.Models
{
    public class ChangeTaskStatusLogicModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("isCompleted")]
        public bool IsCompleted { get; set; }
    }
}
