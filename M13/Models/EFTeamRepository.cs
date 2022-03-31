using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M13.Models
{
    public class EFTeamRepository : ITeamRepository
    {
        private BowlersDbContext _context { get; set; }
        public EFTeamRepository(BowlersDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Team> Teams => _context.Teams;


    }
}