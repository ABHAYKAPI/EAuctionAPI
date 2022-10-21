using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SellerAPI.Errors
{
    public class ApiError
    {
        public ApiError(int errorCode, string errorMessage, string erroDetails = null)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            ErroDetails = erroDetails;
        }

        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErroDetails { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
