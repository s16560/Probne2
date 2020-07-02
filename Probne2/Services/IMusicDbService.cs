using Probne2.DTO.Responses;
using Probne2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Probne2.Services
{
    public interface IMusicDbService
    {
        public MusicLabel GetMusicLabel(int id);
        public void RemoveMusician(int id);
    }
}
