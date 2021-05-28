using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace dump_to_asphyxia_core
{
    public partial class AsyLine
    {
        [JsonProperty("collection")]
        public string Collection { get; set; }

        [JsonProperty("mid")]
        public long Mid { get; set; }

        [JsonProperty("type")]
        public long Type { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("exscore")]
        public long Exscore { get; set; }

        [JsonProperty("clear")]
        public long Clear { get; set; }

        [JsonProperty("grade")]
        public long Grade { get; set; }

        [JsonProperty("buttonRate")]
        public long ButtonRate { get; set; }

        [JsonProperty("longRate")]
        public long LongRate { get; set; }

        [JsonProperty("volRate")]
        public long VolRate { get; set; }

        [JsonProperty("__s")]
        public string S { get; set; }

        [JsonProperty("__refid")]
        public string Refid { get; set; }

        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("createdAt")]
        public AtedAt CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public AtedAt UpdatedAt { get; set; }
    }

    public partial class AtedAt
    {
        [JsonProperty("$$date")]
        public long Date { get; set; }
    }
}
