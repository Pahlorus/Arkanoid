using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    internal class BatWidthUp : PowerUp
    {
        public override void PowerUpAction()
        {
            _game.BatWidthUp();
        }
    }
}
