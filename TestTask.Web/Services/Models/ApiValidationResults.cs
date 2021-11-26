using System.Collections.Generic;

namespace TestTask.Services.Models
{
    public class ApiValidationResults
    {
        public string Type {get; set;}
        public string Title { get; set; }
        public string TraceId { get; set; }
        public string Status { get; set; }
        public Dictionary<string,string> Errors { get; set; }
    }
}