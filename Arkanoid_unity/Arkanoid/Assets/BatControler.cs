using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class BatControler : MonoBehaviour
    {
        private float _initialBatSpeed = 25.0f;
        private float _initialBaScale = 1.0f;
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

        void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.transform.tag == "Pellet")
            {
                ContactPoint2D contactPoint = collision.contacts[0];
                float pelletVelocityMagnitude = contactPoint.collider.attachedRigidbody.velocity.magnitude;
                float angleReflection = (contactPoint.point.x - transform.position.x)*1.348f;
                double newX = pelletVelocityMagnitude * Math.Sin(angleReflection);
                double newY = pelletVelocityMagnitude * Math.Cos(angleReflection)*(-1);
                contactPoint.collider.attachedRigidbody.velocity = Vector3.zero;
                Vector2 newVelocity= new Vector2((float)newX, (float)newY);
                contactPoint.collider.attachedRigidbody.AddForce(newVelocity, ForceMode2D.Impulse);
            }
        }
    }
}

