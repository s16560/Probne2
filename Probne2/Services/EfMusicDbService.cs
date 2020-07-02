using Microsoft.EntityFrameworkCore;
using Probne2.DTO.Responses;
using Probne2.Exceptions;
using Probne2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Probne2.Services
{
    public class EfMusicDbService : IMusicDbService
    {
        private readonly MusicDbContext _context;
        public EfMusicDbService(MusicDbContext context) {
            _context = context;
        }
        public MusicLabel GetMusicLabel(int id)
        {
            var musiclabel = _context.MusicLabels
                                     .Include(m => m.Albums)
                                     .FirstOrDefault(m => m.IdMusicLabel == id);
            musiclabel.Albums = musiclabel.Albums.OrderByDescending(m => m.PublichDate).ToList();

          //  if (musicLabel == null) {
          //      return null;
          //  }
                   
            return musiclabel;
        }

        public void RemoveMusician(int id)
        {
            var musician = _context.Musicians
                            .Include(m => m.MusicianTracks)
                            .SingleOrDefault(m => m.IdMusician == id);
            if (musician == null) {
                throw new MusicianDoesNotExistException($"Musician with id {id} doesn't exist");
            }

            if (musician.MusicianTracks == null) {
                throw new MusicianTracksDoesNotExist("Tracks does not exist");
            }

            if (!musician.MusicianTracks.Any(m => m.Track.IdMusicAlbum != null))
            {
                _context.MusicianTracks.RemoveRange(musician.MusicianTracks);
                _context.Musicians.Remove(musician);
                _context.SaveChanges();
            }
            else {
                throw new MusicianHasNoUnreleasedTracksException("No unreleased tracks");
            }

        }
    }
}
