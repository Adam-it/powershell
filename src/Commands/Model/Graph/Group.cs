using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PnP.PowerShell.Commands.Model.Graph
{
    public class Group
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string MailNickname { get; set; }
        public string Description { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public GroupVisibility Visibility { get; set; }

        [JsonPropertyName("owners@odata.bind")]
        public List<string> Owners { get; set; }

        [JsonPropertyName("members@odata.bind")]
        public List<string> Members { get; set; }

        public string Classification { get; set; }

        public bool MailEnabled { get; set; }

        public List<string> GroupTypes { get; set; }

        public bool? SecurityEnabled { get; set; }
    }

    public enum GroupVisibility
    {
        NotSpecified,
        Private,
        Public
    }

}
