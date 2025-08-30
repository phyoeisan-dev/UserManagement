using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Results
{
    public class ResponseMessage
    {
        public bool Succeeded { get; set; }
        public string? Error { get; set; }
        public static ResponseMessage Success() => new() { Succeeded = true };
        public static ResponseMessage Fail(string error) => new() { Succeeded = false, Error = error };
    }
}
