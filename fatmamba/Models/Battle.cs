using System;

namespace fatmamba.Models
{
    public class Battle
    {
        public string BattleName { get; set; }
        public Status BattleStatus { get; set; }
        public TimeSpan TimeLeft { get; set; }
        public Artist ArtistOne { get; set; }
        public Artist ArtistTwo { get; set; }
    }

    public enum Status { battle, intermission, final }
}