using System;

namespace fatmamba.Models
{
    public class Vote
    {
        public string UserId { get; set; }
        public string ArtistId { get; set; }
        public Passcode Passcode { get; set; }
    }
}