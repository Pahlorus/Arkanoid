using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Arkanoid
{
    public class Pellet : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _pelletRigidbody;
        private bool _isPelletActive;
        private float _coordX = 0.0f;
        private float _coordY = -3.28f;
        private Vector3 _movement;

        public event EventHandler BonusCreate;
        // Use this for initialization

        void Awake()
        {
            transform.position = new Vector3(_coordX, _coordY);
            _pelletRigidbody = GetComponent<Rigidbody2D>();
            _movement = new Vector3(-6, 6, 0);
            _isPelletActive = false;
        }

        void OnCollisionEnter2D()
        {
            BonusCreate?.Invoke(this, EventArgs.Empty);
        }

        void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _pelletRigidbody.AddForce(_movement, ForceMode2D.Impulse);
            }
        }



        // Update is called once per frame
        void Update()
        {

        }
    }
}
