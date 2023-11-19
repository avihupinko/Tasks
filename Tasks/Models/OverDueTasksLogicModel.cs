using Newtonsoft.Json;

namespace Tasks.Models
{
    public class OverDueTasksLogicModel
    {
        [JsonProperty("targetDate")]
        public DateTime TargetDate { get; set; }
    }
}
