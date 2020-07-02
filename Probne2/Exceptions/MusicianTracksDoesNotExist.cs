using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Probne2.Exceptions
{
    public class MusicianTracksDoesNotExist : Exception
    {
        public MusicianTracksDoesNotExist()
        {
        }

        public MusicianTracksDoesNotExist(string message) : base(message)
        {
        }

        public MusicianTracksDoesNotExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MusicianTracksDoesNotExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
