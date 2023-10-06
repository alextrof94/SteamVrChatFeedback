using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamVrChatFeedback
{
    [Serializable]
    public class HapticAnimation
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; } = "bz";

        [JsonProperty(PropertyName = "hapticFrames")]
        public List<HapticFrame> HapticFrames { get; set; } = new List<HapticFrame>();

        public override string ToString()
        {
            return Name;
        }
    }

    [Serializable]
    public class HapticFrame
    {
        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; } = 100;

        [JsonProperty(PropertyName = "delayAfterPlay")]
        public int DelayAfterPlay { get; set; } = 100;
    }
}
