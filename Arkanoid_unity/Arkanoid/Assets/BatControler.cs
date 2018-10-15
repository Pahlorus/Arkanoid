using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class BatControler : MonoBehaviour
    {
        private float _initialSpeedBat = 25.0f;
        private float _speedBat;
        private float _coordX = 0.0f;
        private float _coordY = -3.5f;
        internal void Awake()
        {
            _speedBat = _initialSpeedBat;
        }

        internal void FixedUpdate()
        {
            _coordX += Input.GetAxis("Horizontal") * Time.deltaTime * _speedBat;
            transform.position = new Vector3(_coordX, _coordY);
        }

        public void SpeedUp(int multiplier)
        {
            _speedBat = _initialSpeedBat * multiplier;
        }

    }
}

