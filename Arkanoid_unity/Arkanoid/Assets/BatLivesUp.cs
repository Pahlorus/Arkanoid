namespace Arkanoid
{
    internal class BatLivesUp : PowerUps
    {
        public override void PowerUpAction()
        {
            _game.LivesUp();
        }
    }
}

