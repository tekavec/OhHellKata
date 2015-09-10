using System;

namespace OhHellKata
{
    public class FourPlayers
    {
        private readonly IPlayer _Player1= new Player();
        private readonly IPlayer _Player2= new Player();
        private readonly IPlayer _Player3= new Player();
        private readonly IPlayer _Player4= new Player();

        public IPlayer Player1
        {
            get { return _Player1; }
        }

        public IPlayer Player2
        {
            get { return _Player2; }
        }

        public IPlayer Player3
        {
            get { return _Player3; }
        }

        public IPlayer Player4
        {
            get { return _Player4; }
        }
    }
}