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

        private float _coordX;
        private float _coordY;

        private float _batScaleXMax = 1.5f;
        private float _batScaleXtMin = 0.5f;
        private float _batScaleXStep = 0.5f;
        private float _limitBorderX = 8.3f;
        private float _maxAngleRebound = 75f;
        private Vector3 _movement;
        private Transform _batTransform;
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _batRigidbody2D;

        private void Awake()
        {
            _batTransform = transform;
            _coordY = _batTransform.position.y;
            _batRigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        internal void WidthUp()
        {
            if (_batTransform.localScale.x < _batScaleXMax)
            {
                Vector3 newScale = new Vector3(_batTransform.localScale.x + _batScaleXStep, 1, 1);
                _batTransform.localScale = newScale;
            }
        }

        internal void SwitchOn()
        {
            gameObject.SetActive(true);
            enabled = true;
        }

        internal void SwitchOff()
        {
            gameObject.SetActive(false);
            enabled = false;
        }



        private void Update()
        {
            if (_batRigidbody2D.position.x > _limitBorderX)
            {
                _coordX = _limitBorderX;
                _batTransform.position = new Vector2(_coordX, _coordY);
            }
            if (_batRigidbody2D.position.x < -_limitBorderX)
            {
                _coordX = -_limitBorderX;
                _batTransform.position = new Vector2(_coordX, _coordY);
            }
            _movement = new Vector2(Input.GetAxis("Mouse X"), 0);
        }

        private void FixedUpdate()
        {
            _batRigidbody2D.MovePosition(_batTransform.position + _movement * Time.fixedDeltaTime * _speedBat);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.GetComponent<Pellet>())
            {
                ContactPoint2D contactPoint = collision.contacts[0];

                float deviationСoefficient = (_maxAngleRebound * Mathf.Deg2Rad) / (_spriteRenderer.sprite.rect.width / 200);
                float pelletVelocityMagnitude = contactPoint.collider.attachedRigidbody.velocity.magnitude;
                float angleReflection;

                if (Mathf.Abs(contactPoint.point.x - transform.position.x) >= _spriteRenderer.sprite.rect.width / 200)
                    angleReflection = _maxAngleRebound * Mathf.Deg2Rad;
                else
                    angleReflection = (contactPoint.point.x - transform.position.x) * deviationСoefficient;
 
                double newX = Mathf.Sign(contactPoint.point.x - transform.position.x) * pelletVelocityMagnitude * Mathf.Sin(Mathf.Abs(angleReflection));
                double newY = pelletVelocityMagnitude * Mathf.Cos(Mathf.Abs(angleReflection));
                contactPoint.collider.attachedRigidbody.velocity = Vector3.zero;
                Vector2 newVelocity = new Vector2((float)newX, (float)newY);
                contactPoint.collider.attachedRigidbody.AddForce(newVelocity, ForceMode2D.Impulse);
            }
        }
    }
}

