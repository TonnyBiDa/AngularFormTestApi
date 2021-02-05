using System;
namespace BidOneApi.Models
{
    public class CommonResult<T>
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
