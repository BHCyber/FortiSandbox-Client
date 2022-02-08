using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FortiSandboxOnDemandSubmitEndpoint
{
    class Result
    {
        [JsonProperty("data")]
        public Data data = new Data();
    }
}
