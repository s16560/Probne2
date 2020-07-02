using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Probne2.Exceptions
{
    public class MusicianHasNoUnreleasedTracksException : Exception
    {
        public MusicianHasNoUnreleasedTracksException()
        {
        }

        public MusicianHasNoUnreleasedTracksException(string message) : base(message)
        {
        }

        public MusicianHasNoUnreleasedTracksException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MusicianHasNoUnreleasedTracksException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
