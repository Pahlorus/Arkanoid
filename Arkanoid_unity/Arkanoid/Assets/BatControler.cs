using System;
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
        // TODO временно, далее определить из размеровов спрайта
        private float _batHalfX = 0.105f;
        // Приращение угла отражения в зависимости от расстояния до центра ракетки.
        private float _anglePerLength = 14.124f;

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


        void OnTriggerEnter2D(Collider2D collider)
        {

            if (collider.transform.tag == "Pellet")
            {
                Rigidbody2D pelletRigidbody = collider.GetComponent<Rigidbody2D>();
                Vector2 pelletVelocity = pelletRigidbody.velocity;
                float pelletVelocityMagnitude = pelletVelocity.magnitude;
                double angle = Math.Atan(pelletVelocity.y / pelletVelocity.x); ;
                float batX = transform.position.x;
                float pelletX = collider.transform.position.x;

                if (pelletVelocity.x < 0 && pelletX >= batX && pelletX <= batX + _batHalfX)
                {
                    double newAngle = (pelletX - batX) * _anglePerLength;

                    double newX = pelletVelocityMagnitude / Math.Cos(newAngle);
                    double newY = -pelletVelocityMagnitude / Math.Sin(newAngle);
                    pelletRigidbody.velocity = new Vector3((float)newX, (float)newY, 0);
                }

                if (pelletVelocity.x < 0 && pelletX < batX && pelletX >= batX - _batHalfX)
                {
                    double newAngle = (batX - pelletX) * _anglePerLength;

                    double newX = -pelletVelocityMagnitude / Math.Cos(newAngle);
                    double newY = -pelletVelocityMagnitude / Math.Sin(newAngle);
                    pelletRigidbody.velocity = new Vector3((float)newX, (float)newY, 0);
                }
                if (pelletVelocity.x > 0 && pelletX >= batX && pelletX <= batX + _batHalfX)
                {
                    double newAngle = (pelletX - batX) * _anglePerLength;

                    double newX = pelletVelocityMagnitude / Math.Cos(newAngle);
                    double newY = -pelletVelocityMagnitude / Math.Sin(newAngle);
                    pelletRigidbody.velocity = new Vector3((float)newX, (float)newY, 0);
                }
                if (pelletVelocity.x > 0 && pelletX < batX && pelletX >= batX - _batHalfX)
                {
                    double newAngle = (batX - pelletX) * _anglePerLength;

                    double newX = -pelletVelocityMagnitude / Math.Cos(newAngle);
                    double newY = -pelletVelocityMagnitude / Math.Sin(newAngle);
                    pelletRigidbody.velocity = new Vector3((float)newX, (float)newY, 0);
                }


            }
        }




    }
}

