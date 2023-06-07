using Newtonsoft.Json;

namespace Domain.Common
{
    public abstract class BaseEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateUpdated { get; set;}
        public DateTimeOffset DateDeleted { get; set; }
    }
}
