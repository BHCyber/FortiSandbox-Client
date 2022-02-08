using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FortiSandboxOnDemandSubmitEndpoint
{
    class Data
    {
        [JsonProperty("msg")]
        public string msg;
    }
}
