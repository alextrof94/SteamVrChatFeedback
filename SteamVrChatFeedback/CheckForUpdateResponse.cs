using Newtonsoft.Json;

namespace SteamVrChatFeedback
{
    [JsonObject(MemberSerialization.OptIn)]
    public class CheckForUpdateResponse
    {
        [JsonProperty("version")]
        public string? Version { get; set; }

        [JsonProperty("link")]
        public string? Link { get; set; }
    }
}
