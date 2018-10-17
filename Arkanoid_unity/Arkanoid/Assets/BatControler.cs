using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class BatControler : MonoBehaviour
    {
        private float _initialBatSpeed = 25.0f;
        private float _initialBaScalet = 1.0f;
        private float _batScaleXMax = 1.5f;
        private float _batScaleXtMin = 0.5f;
        private float _batScaleXStep = 0.5f;
        private float _speedBat;
        private float _coordX = 0.0f;
        private float _coordY = -3.5f;

        internal void Awake()
        {
            _speedBat = _initialBatSpeed;
        }

        internal void FixedUpdate()
        {
            _coordX += Input.GetAxis("Horizontal") * Time.deltaTime * _speedBat;
            transform.position = new Vector3(_coordX, _coordY);
        }


        public void WidthUp()
        {
            if (transform.localScale.x < _batScaleXMax)
            {
                Vector3 newScale = new Vector3(transform.localScale.x+_batScaleXStep, 1, 1);
                transform.localScale = newScale;
            }

        }

    }
}

