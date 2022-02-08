using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;


namespace FortiSandboxOnDemandSubmitEndpoint
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                //Provide FortiSandbox API URL as first args example https://sandbox.domain.com/jsonrpc
                string fortiSandboxUri = args[0];

                //Provide a FortiSandbox Username as second argument. 
                //The user should have the requried permision to submit a file and to call an API
                string username = args[1];
                
                //Provide a FortiSandbox Password of the user as third argument. 
                string password = args[2];

                //Provide the path to the file that you want to submit as fourth argument. 
                string FilePath = args[3];

                //If the file is a password-protected compressed file, password of the achieved file must be provided  
                //Provide the archived file password as a fiveth argument
                string archive_password = "";
                if (args.Length > 4)
                    archive_password = args[4];

                //Build the login request API
                LoginRequest loginRequest = new LoginRequest(username, password);

                //Submit the request
                string response = FortiSandboxPOSTRequest(fortiSandboxUri,loginRequest.LoginResquestString);

                //covert the file content to Base64 string
                string FileBase64 = FileUploadRequest.FileContentToBase64(FilePath);

                //convert the file name to base64 string
                string FileNameBase64 = FileUploadRequest.FileNameToBase64(Path.GetFileName(FilePath));

                //extract session ID from the response of the login API call
                string SessionID = LoginRequest.getSessionID(response);

                //build the file upload API
                FileUploadRequest fileUploadRequest = new FileUploadRequest(FileBase64, FileNameBase64, archive_password, SessionID);

                //submit the file upload API
                response = FortiSandboxPOSTRequest(fortiSandboxUri,fileUploadRequest.FileUploadRequestString);

                //extract the response for the file uplaod API call
                response = FileUploadRequest.getResponseMSG(response);

                //print the response to the console
                Console.WriteLine(response);

            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        public static string FortiSandboxPOSTRequest(string fortiSandboxUri,string request)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(fortiSandboxUri);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                streamWriter.Write(request);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }

        }


    }
}
