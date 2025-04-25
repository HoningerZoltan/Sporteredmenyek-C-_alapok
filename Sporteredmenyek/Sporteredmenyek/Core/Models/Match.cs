using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sporteredmenyek.Core.Models
{
    abstract class Match
    {
        private Team _homeTeam
            ;
        private Team _awayTeam;
        private TimeSpan _start_time;
        private string _location;
        public abstract int PeriodsNumber { get; set; }
        public Team HomeTeam
        {
            get { return _homeTeam; }
            private set { _homeTeam = value; }
        }
        public Team AwayTeam
        {
            get { return _awayTeam; }
            private set { _awayTeam = value; }
        }
        public TimeSpan StartTime
        {
            get { return _start_time; }
            private set { _start_time = value; }
        }
        public string Location
        {
            get { return _location; }
            private set { _location = value; }
        }


        protected Match(Team homeTeam, Team awayTeam, TimeSpan start_time, string location)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            StartTime = start_time;
            Location = location;
        }
    }
}
