using UnityEngine;


namespace Arkanoid
{
    internal class PowerUps : MonoBehaviour
    {
        private float _speed = 5f;
        private float _coordX;
        private float _coordY;
        protected Game _game;

        public virtual void PowerUpAction() { }

        public void Initialize(Game game)
        {
            _game = game;
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            
            if (collider.GetComponent<BatControler>())
            {
                PowerUpAction();
                _game.SetPowerUpStatus();
                Destroy(this.gameObject);
            }
            if (collider.transform.tag == "Bottom")
            {
                _game.SetPowerUpStatus();
                Destroy(this.gameObject);
            }
        }

        void Start()
        {
            _coordX = transform.position.x;
            _coordY = transform.position.y;
        }

        internal void FixedUpdate()
        {
            _coordY -= Time.deltaTime * _speed;
            transform.position = new Vector3(_coordX, _coordY, -1);
        }
    }
}

