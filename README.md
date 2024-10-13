# FortiSandbox On-Demand Submission Client
A C# software client consumes FortiSandbox APIs to triger an on-demand scan job for a specific file directly from the endpoint.
This peice of software is useful with endpoint detection and response (EDR) solutions which support a call for customized actions, SOAR solutions, or any other way that helps to call for actions.

--------------------

FortiSandbox Requirements:
  1. Tested with version 3.0, supposed to work fine with any above versions as far as there is no change in FortiSandbox APIs
  2. Username with permission to submit file on-demand and to call APIs

--------------------

Packges Requriements:
  1. Newtonsoft.Json -> version="13.0.0"

--------------------

Endpoint Requirements:
  1. .Net Framework 4.5

--------------------

Examples on how to run the software:
  1. Submission of archived file with password
        FortiSandboxOnDemandSubmitEndpoint.exe "https://sandbox.domain.com/jsonrpc" "username" "password" "c:\filePath\file.zip" "FilePassword"
  2. any other file
        FortiSandboxOnDemandSubmitEndpoint.exe "https://sandbox.domain.com/jsonrpc" "username" "password" "c:\filePath\file.docx"
