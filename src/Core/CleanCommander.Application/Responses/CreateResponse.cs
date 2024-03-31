using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCommander.Application.Responses
{
    public class CreateResponse<T>
    {
        public T Data { get; set; }
        public CreateResponse()
        {
            Success = true;
        }
        public CreateResponse(string message = null)
        {
            Success = true;
            Message = message;
        }

        public CreateResponse(string message, bool success)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
