using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ActorSample.Messages;
using Akka.Actor;

namespace ActorSample.Actors
{
    public class PlaybackActor : ReceiveActor
    {

        public PlaybackActor()
        {
            Console.WriteLine("Creating Playback Actor");
            
            Receive<PlayMovieMessage>(m_ => OnReceive(m_));
        }

        protected override void PreStart()
        {
            Console.WriteLine("PreStart");
            
            base.PreStart();
        }

        protected override void PostStop()
        {
            Console.WriteLine("PostStop");
            base.PostStop();
        }

        private void OnReceive(PlayMovieMessage playMovieMessage)
        {
            Console.WriteLine(playMovieMessage.MovieName);
            Console.WriteLine(playMovieMessage.UserId);
            
        }
    }
}
