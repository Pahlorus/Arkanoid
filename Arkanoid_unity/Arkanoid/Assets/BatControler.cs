using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    internal class BatControler : MonoBehaviour
    {
        private float _speedBat = 10.0f;
        private float _coordX = 0.0f;
        private float _coordY = -3.5f;

        internal void FixedUpdate()
        {
            _coordX += Input.GetAxis("Horizontal") * Time.deltaTime * _speedBat;
            transform.position = new Vector3(_coordX, _coordY);

        }

    }
}

