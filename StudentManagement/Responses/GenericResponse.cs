using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Responses
{
    public class GenericResponse
    {
        public GenericResponse(object data, params string[] messages)
        {
            Data = data;
            Message = messages;
        }

        public IEnumerable<string> Message { get; set; }
        public object Data { get; set; }
    }
}
