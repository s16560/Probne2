using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Probne2.Exceptions
{
    public class MusicianDoesNotExistException : Exception
    {
        public MusicianDoesNotExistException()
        {
        }

        public MusicianDoesNotExistException(string message) : base(message)
        {
        }

        public MusicianDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MusicianDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
