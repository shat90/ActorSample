using ActorSample.Messages;
using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorSample.Actors
{
    public class UserActor : ReceiveActor
    {
        private string _currentlyWatching;

        public UserActor()
        {
            Console.WriteLine("Creating userActor");
            Stopped();
        }

        private void HandleStopMovieMessage(StopMovieMessage message)
        {
            if (_currentlyWatching == null)
            {
                Console.WriteLine("Cannot stop if nothing is playing");
            }
            else
            {
                Console.WriteLine("Stopping" + _currentlyWatching);

                _currentlyWatching = null;
            }
        }

        private void Playing()
        {
            Receive<PlayMovieMessage>(message_ => Console.WriteLine("Need to Stop Playing Movie"));
            Receive<StopMovieMessage>(message => StopPlayingMovie());
        }

        private void Stopped()
        {
            Receive<PlayMovieMessage>(message_ => StartPlayingMovie(message_));
            Receive<StopMovieMessage>(message_ => Console.WriteLine("Cannot stop if nothing is playing"));
        }

        private void StopPlayingMovie()
        {

            Console.WriteLine("Stopping" + _currentlyWatching);
            _currentlyWatching = null;
            Become(Stopped);
        }

        private void StartPlayingMovie(PlayMovieMessage message_)
        {
            _currentlyWatching = message_.MovieName;
            Console.WriteLine("User is currently watching" +_currentlyWatching);
            Become(Playing);
        }

        private void HandlePlayMovieMessage(PlayMovieMessage message)
        {
            if (_currentlyWatching != null)
            {
                Console.WriteLine("Need to Stop Previous Message");
            }
            else
            {
                _currentlyWatching = message.MovieName;
                Console.WriteLine("User is currently watching");

            }

        }

        protected override void PreStart()
        {
            Console.WriteLine("UserActor Prestart");
            base.PreStart();
        }

        protected override void PostStop()
        {
            Console.WriteLine("UserActor PostStop");
            base.PostStop();
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Console.WriteLine("UserActor preRestart");
            base.PreRestart(reason, message);
        }

    }
}
