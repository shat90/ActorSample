using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ActorSample.Messages
{
    public class PlayMovieMessage
    {
        public string MovieName { get; private set; }
        public int UserId { get; private set; }

        public PlayMovieMessage(string movieName_, int userId_)
        {
            MovieName = movieName_;
            UserId = userId_;
        }
    }
}
