using System;
namespace EndlessMilestones.Models
{
    public class Response
    {
        public Response(int code, string message, List<Goals>? d, Goals? g, methods? m)
        {
            sCode = code;
            rMessage = message;
            Data = d;
            goal = g;
            method = m;
        }

        public int sCode { get; set; }
        public string rMessage { get; set; }
        public IEnumerable<Goals> Data { get; set; }
        public Goals goal { get; set; }
        public methods method { get; set; }


    }
}

