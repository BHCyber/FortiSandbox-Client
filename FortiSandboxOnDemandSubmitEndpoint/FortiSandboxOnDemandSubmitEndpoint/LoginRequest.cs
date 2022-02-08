using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace FortiSandboxOnDemandSubmitEndpoint
{
    class LoginRequest
    {

        public string LoginResquestString;
        
        //to build the login API call
        public LoginRequest(string username, string password)
        {
            LoginResquestString = "{\"method\": \"exec\",\"params\": [{\"url\": \"/sys/login/user\",\"data\": [{\"user\": \""+username+"\",\"passwd\": \""+password+"\"}]}],\"id\": 1,\"ver\": \"2.0\"}";
        }

        //to extrac the session ID from the login JSON response
        public static string getSessionID(string LoginResponse)
        {
            FortiSandboxResponse result = JsonConvert.DeserializeObject<FortiSandboxResponse>(LoginResponse);
            return result.session;
        }




    }
}
