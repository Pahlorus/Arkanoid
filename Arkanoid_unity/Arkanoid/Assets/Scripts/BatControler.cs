using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class BatControler : MonoBehaviour
    {
        [SerializeField]
        private float _speedBat;
        private float _batScaleXMax = 1.5f;
        private float _batScaleXtMin = 0.5f;
        private float _batScaleXStep = 0.5f;
        private float _coordX = 0.0f;
        private float _coordY = -3.5f;
        private float _limitBorderX = 8.3f;
        private Vector3 _movement;
        private Transform _batTransform;
        private Rigidbody2D _batRigidbody2D;

        internal void Awake()
        {
            //_speedBat = _initialBatSpeed;
            _batTransform = transform;
            _batRigidbody2D = GetComponent<Rigidbody2D>();

        }


        internal void Update()
        {
            if (_batTransform.position.x > _limitBorderX)
            {
                _coordX = _limitBorderX;
            }
            else if (_batTransform.position.x < -_limitBorderX)
            {
                _coordX = -_limitBorderX;
            }
            else
            {
                //_coordX += Input.GetAxis("Horizontal") * Time.deltaTime * _speedBat;
                // _coordX += Input.GetAxis("Mouse X") * Time.fixedDeltaTime * _speedBat;
                // _coordX += Input.GetAxis("Mouse X");

            }
            _movement = new Vector2(Input.GetAxis("Mouse X"), 0) ;
           

        }

        internal void FixedUpdate()
        {

            _batRigidbody2D.MovePosition(_batTransform.position + _movement * Time.fixedDeltaTime * _speedBat);

            //_batRigidbody2D.velocity = new Vector2(Input.GetAxis("Mouse X")*Time.fixedDeltaTime * 600f, 0);

            //_batTransform.position = new Vector3(_coordX, _coordY);
        }

        public void WidthUp()
        {
            if (_batTransform.localScale.x < _batScaleXMax)
            {
                Vector3 newScale = new Vector3(_batTransform.localScale.x + _batScaleXStep, 1, 1);
                _batTransform.localScale = newScale;
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.GetComponent<Pellet>())
            {
                ContactPoint2D contactPoint = collision.contacts[0];

                float pelletVelocityMagnitude = contactPoint.collider.attachedRigidbody.velocity.magnitude;
                float angleReflection = (contactPoint.point.x - transform.position.x) * 1.185f;
                double newX = pelletVelocityMagnitude * Math.Sin(angleReflection);
                double newY = (-1) * pelletVelocityMagnitude * Math.Cos(angleReflection);

                contactPoint.collider.attachedRigidbody.velocity = Vector3.zero;
                Vector2 newVelocity = new Vector2((float)newX, (float)newY);
                contactPoint.collider.attachedRigidbody.AddForce(newVelocity, ForceMode2D.Impulse);




            }
        }
    }
}

