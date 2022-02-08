using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace FortiSandboxOnDemandSubmitEndpoint
{
    class FileUploadRequest
    {
        public string FileUploadRequestString;

        //build the API request to upload the file to FortiSandbox 
        public FileUploadRequest(string FileBase64,string FileNameBase64,string ArchivePassword,string SessionID)
        {
            FileUploadRequestString = "{\"method\": \"set\",\"params\": [{\"file\": \""+FileBase64+"\",\"filename\": \""+FileNameBase64 + "\",\"skip_steps\": \"2\",\"url\": \"/alert/ondemand/submit-file\",\"type\": \"file\",\"overwrite_vm_list\":\"WIN10X64VM,WIN10X64VMO16\",\"archive_password\":" + ArchivePassword+"\"\",\"timeout\": \"3600\"}],\"session\": \"" + SessionID + "\",\"id\": 11,\"ver\": \"2.5\"}";
        }

        //convert a file to Base64 string
        public static string FileContentToBase64(string FilePath)
        {
            Byte[] bytes = File.ReadAllBytes(FilePath);
            return Convert.ToBase64String(bytes);
        }

        //convert file name to base64 string
        public static string FileNameToBase64(string FileName)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(FileName);
            return Convert.ToBase64String(bytes);
        }

        //extract the response msg from the API call response
        public static string getResponseMSG(string UploadResponse)
        {
            FortiSandboxUploadResponse result = JsonConvert.DeserializeObject<FortiSandboxUploadResponse>(UploadResponse);

            return result.result.data.msg;
        }

    }
}
