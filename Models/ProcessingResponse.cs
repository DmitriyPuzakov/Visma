using System;
using System.Collections.Generic;
using System.Linq;

namespace Visma.Models
{
    public class ProcessingResponse
    {
        public string LongNumber { get; set; }
        public bool CheckDigitValid { get; set; }
        public string Status { get; set; }
    }
}