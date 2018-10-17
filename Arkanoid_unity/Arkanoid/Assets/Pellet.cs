using System;
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
        private float _speed = 2f;
        // TODO временно, далее определить из размеровов спрайта
        private float _batHalfX = 0.105f;
        // Приращение угла отражения в зависимости от расстояния до центра ракетки.
        private float _anglePerLength = 14.124f;

        private Vector3 _movement;


        public event EventHandler OnCollision;

        public void SpeedUp()
        {
            _pelletRigidbody.velocity = _pelletRigidbody.velocity * _speed;
        }

        void Awake()
        {
            transform.position = new Vector3(_coordX, _coordY, -1);
            _movement = new Vector3(-6, 6, 0);
            _isPelletActive = false;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.tag == "Tile")
                OnCollision?.Invoke(this, EventArgs.Empty);

            if (collision.transform.tag == "Bat")
            {
                Vector2 pelletVelocity = _pelletRigidbody.velocity;
                float pelletVelocityMagnitude = pelletVelocity.magnitude;
                double angle = Math.Atan(pelletVelocity.y / pelletVelocity.x); ;
                float batX = collision.transform.position.x;
                float pelletX = transform.position.x;
                
                if (pelletVelocity.x<0 && pelletX>= batX || pelletX <= batX+ _batHalfX)
                {
                    double newAngle = (pelletX-batX)*_anglePerLength;

                    double newX = pelletVelocityMagnitude / Math.Cos(newAngle);
                    double newY = -pelletVelocityMagnitude / Math.Sin(newAngle);
                    _pelletRigidbody.velocity = new Vector3((float)newX, (float)newY, 0);
                }

                if ()
                {

                }
                if ()
                {

                }
                if ()
                {

                }

               
            }
        }

        void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _pelletRigidbody.AddForce(_movement, ForceMode2D.Impulse);
            }
        }
    }
}
