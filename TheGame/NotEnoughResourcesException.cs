using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    [Serializable()]
    class NotEnoughResourcesException : System.Exception
    {
        public NotEnoughResourcesException() : base() { }
        public NotEnoughResourcesException(string message) : base(message) { }
        public NotEnoughResourcesException(string message, System.Exception inner) : base(message, inner) { }

        protected NotEnoughResourcesException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
