using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Responses
{
    /// <summary>
    /// This class contains information about how the request was handled. It is inherited by all response classes
    /// Success will be set to true or false, accordingly.
    /// Message will have a message for the user
    /// ValidationErrors, if any, will have one or more errormessages for the user.
    /// </summary>
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }
        public BaseResponse(string message = null)
        {
            Success = true;
            Message = message;
        }

        public BaseResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
