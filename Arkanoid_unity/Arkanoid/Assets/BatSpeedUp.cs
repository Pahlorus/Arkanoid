using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Arkanoid
{
    internal class BatSpeedUp : PowerUps
    {
        private int speedMultyplier = 3;
        public override void PowerUpAction()
        {
            _batScript.SpeedUp(speedMultyplier);
        }
    }

}
