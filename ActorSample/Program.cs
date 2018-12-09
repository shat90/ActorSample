using ActorSample.Actors;
using ActorSample.Messages;
using Akka.Actor;
using Akka.Actor.Dsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActorSample
{
    class Program
    {
        private static ActorSystem MovieStreamingActorSystem;
        static void Main(string[] args)
        {
            MovieStreamingActorSystem = ActorSystem.Create("MovieStreamingActorSystem");
            Console.WriteLine("Actor System createD");
            /*Props playBackActorProps = Props.Create<PlaybackActor>();
            IActorRef playBackActorRef = MovieStreamingActorSystem.ActorOf(playBackActorProps, "playbackActor");
            playBackActorRef.Tell(new PlayMovieMessage("This is AKka.Net", 42));
            playBackActorRef.Tell(PoisonPill.Instance);*/

            Props userActorProps = Props.Create<UserActor>();
            IActorRef userActorRef = MovieStreamingActorSystem.ActorOf(userActorProps, "userActor");

            userActorRef.Tell(new PlayMovieMessage("ABCD the movie", 34));
            userActorRef.Tell(new PlayMovieMessage("ABCD 2 the movie", 34));
            Console.ReadLine();

            userActorRef.Tell(new StopMovieMessage());

            userActorRef.Tell(new StopMovieMessage());
 
            MovieStreamingActorSystem.Terminate();

            Console.Read();

        }
    }
}
