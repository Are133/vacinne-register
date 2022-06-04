using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacinneRegister.API.Response
{
    public class APIResponse<T>
    {
        public APIResponse(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}
