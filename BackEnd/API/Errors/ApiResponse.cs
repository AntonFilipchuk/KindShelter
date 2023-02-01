using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Error 400! Bad request!",
                401 => "Error 401! You are not authorized",
                404 => "Error 404! We couldn't find the resource!",
                500 => "Error 500! Something broke on the server!",
                _ => ""
            };
        }
    }
}
