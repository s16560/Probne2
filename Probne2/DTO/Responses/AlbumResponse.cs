using Probne2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Probne2.DTO.Responses
{
    public class AlbumResponse
    {
        public MusicLabel musicLabel { get; set; }
        public ICollection<Album> albums { get; set; }
    }
}
