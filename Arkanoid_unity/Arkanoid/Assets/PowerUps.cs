using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Arkanoid
{
    internal class PowerUps : MonoBehaviour
    {
        [SerializeField]
        protected GameObject _pellet;
        [SerializeField]
        protected GameObject _bat;
        [SerializeField]
        protected Sprite _sprite;
        [SerializeField]
        protected BatControler _batScript;

        private float _speed = 5f;
        private float _coordX;
        private float _coordY;


        public virtual void PowerUpAction() { }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.transform.tag == "Bat")
                Destroy(this.gameObject);
        }

        void Awake()
        {
            _coordX = 0;
            _coordY = 0;
        }

        internal void FixedUpdate()
        {
            _coordY -= Time.deltaTime * _speed;
            transform.position = new Vector3(_coordX, _coordY, -1);
        }
    }
}

