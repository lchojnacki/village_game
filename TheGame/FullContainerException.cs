using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    [Serializable()]
    class FullContainerException : System.Exception
    {
        public FullContainerException() : base() { }
        public FullContainerException(string message) : base(message) { }
        public FullContainerException(string message, System.Exception inner) : base(message, inner) { }

        protected FullContainerException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
