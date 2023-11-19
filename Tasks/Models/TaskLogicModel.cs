using Newtonsoft.Json;

namespace Tasks.Models
{
    public class TaskLogicModel
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("subject")]
        public required string Subject { get; set; }

        [JsonProperty("targetDate")]
        public DateTime TargetDate { get; set; }

        [JsonProperty("isCompleted")]
        public bool IsCompleted { get; set; }

        [JsonProperty("user")]
        public UserLogicModel? User { get; set; }
    }
}
