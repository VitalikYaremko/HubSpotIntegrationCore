using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubSpotIntegrationCore.Domain.Models
{
    public class ContactRecordModel
    {

        public int vid { get; set; }
        public int canonicalvid { get; set; }
        public object[] mergedvids { get; set; }
        public int portalid { get; set; }
        public bool iscontact { get; set; }
        public string profiletoken { get; set; }
        public string profileurl { get; set; }
        public Properties properties { get; set; } = new Properties();
        [JsonProperty(PropertyName = "associated-company")]
        public AssociatedCompany associatedcompany { get; set; } = new AssociatedCompany();

        public class Properties
        {
            public State state { get; set; } = new State();
            public Zip zip { get; set; } = new Zip();
            public Phone phone { get; set; } = new Phone();
            public City city { get; set; } = new City();
            public Lifecyclestage lifecyclestage { get; set; } = new Lifecyclestage();
        }


        public class State
        {
            public string value { get; set; } = null;
            public StateVersion[] versions { get; set; }
        }

        public class StateVersion
        {
            public string value { get; set; }
            public string sourcetype { get; set; }
            public object sourceid { get; set; }
            public object sourcelabel { get; set; }
            public long timestamp { get; set; }
            public bool selected { get; set; }
        }
        public class Zip
        {
            public string value { get; set; } = null;
            public ZipVersion[] versions { get; set; }
        }

        public class ZipVersion
        {
            public string value { get; set; }
            public string sourcetype { get; set; }
            public object sourceid { get; set; }
            public object sourcelabel { get; set; }
            public long timestamp { get; set; }
            public bool selected { get; set; }
        }
        public class Phone
        {
            public string value { get; set; } = null;
            public PhoneVersion[] versions { get; set; }
        }

        public class PhoneVersion
        {
            public string value { get; set; }
            public string sourcetype { get; set; }
            public object sourceid { get; set; }
            public object sourcelabel { get; set; }
            public long timestamp { get; set; }
            public bool selected { get; set; }
        }
        public class City
        {
            public string value { get; set; } = null;
            public CityVersion[] versions { get; set; }
        }

        public class CityVersion
        {
            public string value { get; set; }
            public string sourcetype { get; set; }
            public object sourceid { get; set; }
            public object sourcelabel { get; set; }
            public long timestamp { get; set; }
            public bool selected { get; set; }
        }
        public class Lifecyclestage
        {
            public string value { get; set; } = null;
            public LifecyclestageVersion[] versions { get; set; }
        }

        public class LifecyclestageVersion
        {
            public string value { get; set; }
            public string sourcetype { get; set; }
            public object sourceid { get; set; }
            public object sourcelabel { get; set; }
            public long timestamp { get; set; }
            public bool selected { get; set; }
        }
        public class AssociatedCompany
        {
            public int companyid { get; set; }
            public int portalid { get; set; }
            public AssociatedCompanyProperties properties { get; set; } = new AssociatedCompanyProperties();
        }

        public class AssociatedCompanyProperties
        {
            public AssociatedCompanyCity city { get; set; } = new AssociatedCompanyCity();
            public AssociatedCompanyState state { get; set; } = new AssociatedCompanyState();
            public AssociatedCompanyZip zip { get; set; } = new AssociatedCompanyZip();
            public AssociatedCompanyWebsite website { get; set; } = new AssociatedCompanyWebsite();
            public AssociatedCompanyPhone phone { get; set; } = new AssociatedCompanyPhone();
            public AssociatedCompanyPhoneName name { get; set; } = new AssociatedCompanyPhoneName();


        }
        public class AssociatedCompanyPhone
        {
            public string value { get; set; }
        }
        public class AssociatedCompanyWebsite
        {
            public string value { get; set; }
        }
        public class AssociatedCompanyState
        {
            public string value { get; set; }
        }
        public class AssociatedCompanyCity
        {
            public string value { get; set; }
        }
        public class AssociatedCompanyZip
        {
            public string value { get; set; } = null;
            public AssociatedCompanyVersion[] versions { get; set; }
        }

        public class AssociatedCompanyVersion
        {
            public string value { get; set; }
            public string sourcetype { get; set; }
            public object sourceid { get; set; }
            public object sourcelabel { get; set; }
            public long timestamp { get; set; }
            public bool selected { get; set; }
        }
        public class AssociatedCompanyPhoneName
        {
            public string value { get; set; } = null;
        }
    }
}
