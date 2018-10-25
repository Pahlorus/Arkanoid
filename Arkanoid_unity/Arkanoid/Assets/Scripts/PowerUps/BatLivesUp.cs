namespace Arkanoid
{
    internal class BatLivesUp : PowerUp
    {
        public override void PowerUpAction()
        {
            _game.LivesUp();
        }
    }
}

