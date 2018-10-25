namespace Arkanoid
{
    internal class PelletSpeedUp : PowerUp
    {
        public override void PowerUpAction()
        {
            _game.PelletSpeedUp();
        }
    }

}
