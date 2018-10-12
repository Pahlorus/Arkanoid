using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class BatControler : MonoBehaviour
    {
        private float _speedBat = 10.0f;
        private float _coordX = 0.0f;
        private float _coordY = -3.5f;

        void FixedUpdate()
        {
            _coordX += Input.GetAxis("Horizontal") * Time.deltaTime * _speedBat;
            transform.position = new Vector3(_coordX, _coordY);

        }

    }
}

