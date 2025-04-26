using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Core.Models
{
    public abstract record Match(
        Team HomeTeam,
        Team AwayTeam,
        DateTime StartTime,
        string Location,
        TeamsIntValuePair Result
    )
    {
        public List<TeamsIntValuePair> PeriodResults { get; init; } = new();
        
        public abstract int PeriodsNumber { get; }
        public abstract void Print();
    }


}
