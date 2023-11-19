using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class UserLogicModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        [JsonProperty("name")]
        public required string Name { get; set; }
    }

}
