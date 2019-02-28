using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubSpotIntegrationCore.Domain.Models
{
    public class ListContactModel
    {
        public Contact[] contacts { get; set; }
        [JsonProperty(PropertyName = "has-more")]
        public bool has_more { get; set; }
        [JsonProperty(PropertyName = "vid-offset")]
        public long vid_offset { get; set; }
        [JsonProperty(PropertyName = "time-offset")]
        public long time_offset { get; set; }

        public class Contact 
        {
            public long addedAt { get; set; }
            public int vid { get; set; }
            public int canonicalvid { get; set; }
            public object[] mergedvids { get; set; }
            public int portalid { get; set; }
            public bool iscontact { get; set; }
            public string profiletoken { get; set; }
            public string profileurl { get; set; }
            public Properties properties { get; set; } = new Properties();
            public object[] formsubmissions { get; set; }
            public IdentityProfiles[] identityprofiles { get; set; }
            public object[] mergeaudits { get; set; }
        }

        public class Properties
        {
            public Firstname firstname { get; set; } = new Firstname();
            public Lastmodifieddate lastmodifieddate { get; set; }
            public Company company { get; set; } = new Company();
            public Lastname lastname { get; set; } = new Lastname();
        }

        public class Firstname
        {
            public string value { get; set; } = null;
        }

        public class Lastmodifieddate
        {
            public string value { get; set; } = null;
        }

        public class Company
        {
            public string value { get; set; } = null;
        }

        public class Lastname
        {
            public string value { get; set; } = null;
        }

        public class IdentityProfiles
        {
            public int vid { get; set; }
            public long savedattimestamp { get; set; }
            public int deletedchangedtimestamp { get; set; }
            public Identity[] identities { get; set; }
        }

        public class Identity
        {
            public string type { get; set; }
            public string value { get; set; }
            public long timestamp { get; set; }
        }
    }
}
