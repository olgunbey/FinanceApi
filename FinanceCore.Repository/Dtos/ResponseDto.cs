using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinanceCore.Repository.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }

        public static ResponseDto<T> Success(T data,int statusCode)
        {
            return new ResponseDto<T> { Data = data, StatusCode = statusCode };
        }
        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T> { StatusCode = statusCode };
        }
        public static ResponseDto<T> Fail(List<string> errors,int statusCode)
        {
            return new ResponseDto<T> { StatusCode = statusCode,Errors=errors };
        }
        public static ResponseDto<T> Fail(string errors,int statusCode)
        {
            return new ResponseDto<T> { StatusCode = statusCode, Errors = new List<string>(){errors}};
        }

        public struct ResponseData
        {
            public static IActionResult Response<T>(ResponseDto<T> responseDto)
            {
                if(responseDto.StatusCode==204)
                {
                    return new ObjectResult(null);
                }
                return new ObjectResult(JsonSerializer.Serialize(responseDto));
            }
        }
    }
}
