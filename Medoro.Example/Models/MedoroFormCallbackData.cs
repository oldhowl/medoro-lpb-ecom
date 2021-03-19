using Microsoft.AspNetCore.Mvc;

namespace Medoro.Example.Models
{
    public class MedoroFormCallbackData
    {
        [FromForm(Name = "KEY")]
        public string Key { get; set; }

        [FromForm(Name = "KEY_INDEX")]
        public int KeyIndex { get; set; }
        
        [FromForm(Name = "DATA")]
        public string Data { get; set; }
        
        [FromForm(Name = "SIGNATURE")]
        public string Signature { get; set; }
        
        [FromForm(Name = "INTERFACE")]
        public string Interface { get; set; }
    }
}