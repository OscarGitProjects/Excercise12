using System;

namespace Excercise12Garage2.Models
{
    public class ErrorViewModel
    {
        //Added by Joseph
        public string ThisIsAnUselessProperty { get; set; }
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
