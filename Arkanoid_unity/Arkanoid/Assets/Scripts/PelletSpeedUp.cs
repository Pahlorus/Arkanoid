namespace Arkanoid
{
    internal class PelletSpeedUp : PowerUps
    {
        public override void PowerUpAction()
        {
            _game.PelletSpeedUp();
        }
    }

}
