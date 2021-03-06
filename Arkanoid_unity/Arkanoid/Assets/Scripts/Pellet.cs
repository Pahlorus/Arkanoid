﻿using System;
using UnityEngine;


namespace Arkanoid
{
    public class Pellet : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _pelletRigidbody;
        [SerializeField]
        private Transform _batTransform;
        [SerializeField]
        private Vector3 _initialMovement;

        private Transform _pelletTransform;
        private Vector3 _newPelletPosition;
        private Vector3 _initialPelletPosition;
        private bool _isPelletActive;
        private bool _isSpaceKeyDown;
        private float _speed = 2f;

        public event EventHandler OnCollision;
        public event EventHandler OnFailed;

        void Awake()
        {
            _pelletTransform = transform;
            _initialPelletPosition.y = _pelletTransform.position.y;
            _isPelletActive = false;
        }

        internal void SpeedUp()
        {
            _pelletRigidbody.velocity = _pelletRigidbody.velocity * _speed;
        }

        internal void PelletInActive()
        {
            _isPelletActive = false;
            _pelletRigidbody.velocity = Vector3.zero;
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

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.GetComponent<Tile>())
                OnCollision?.Invoke(this, EventArgs.Empty);
            if (collision.collider.transform.tag == "Bottom")
            {
                OnFailed?.Invoke(this, EventArgs.Empty);
            }
        }

        void Update()
        {
            if (!_isSpaceKeyDown)
                _isSpaceKeyDown = Input.GetKeyDown(KeyCode.Space);
        }

        void FixedUpdate()
        {
            if (_isSpaceKeyDown && !_isPelletActive)
            {
                _pelletRigidbody.AddForce(_initialMovement, ForceMode2D.Impulse);
                _isSpaceKeyDown = false;
                _isPelletActive = true;
            }

            if (!_isPelletActive)
            {
                _pelletTransform.position = new Vector3(_batTransform.position.x, _initialPelletPosition.y, -1);
            }
        }
    }
}
