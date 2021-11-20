using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tomahawk_Async.Models
{
    public class ContentLengthViewModel
    {
        public int ContentLength { get; set; }
        //public CancellationTokenSource token { get; set; }
        public string message { get; set; }
        //public CancellationToken token { get; set; }
    }
}
