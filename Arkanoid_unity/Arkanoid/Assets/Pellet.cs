using System;
using UnityEngine;


namespace Arkanoid
{
    public class Pellet : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _pelletRigidbody;
        [SerializeField]
        private Transform _batTransform;

        private Transform _pelletTransform;
        private Vector3 _newPelletPosition;
        private Vector3 _initialPelletPosition;
        private bool _isPelletActive;
        private float _speed = 2f;
        private Vector3 _initialMovement;

        public event EventHandler OnCollision;
        public event EventHandler OnFailed;

        void Awake()
        {
            _pelletTransform = transform;
            _initialPelletPosition.y = _pelletTransform.position.y;
            _initialMovement = new Vector3(-7, 7, 0);
            _isPelletActive = false;
        }

        public void SpeedUp()
        {
            _pelletRigidbody.velocity = _pelletRigidbody.velocity * _speed;
        }

        public void SetOverBat()
        {
            _isPelletActive = false;
            _pelletRigidbody.velocity = Vector3.zero;
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

        void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _pelletRigidbody.AddForce(_initialMovement, ForceMode2D.Impulse);
                _isPelletActive = true;
            }

            if (!_isPelletActive)
            {
                _pelletTransform.position = new Vector3(_batTransform.position.x, _initialPelletPosition.y, -1);
            }
        }
    }
}
