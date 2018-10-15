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
        protected  BatControler _batScript;

        private float _speed;
        private float _coordX = 0.0f;
        private float _coordY = -3.5f;


        public virtual void PowerUpAction()
        {

        }

        void Awake()
        {
            gameObject.SetActive(false);
        }

        void Start()
        {
            gameObject.SetActive(true);
        }

        internal void FixedUpdate()
        {
            _coordX +=  Time.deltaTime * _speed;
            transform.position = new Vector3(_coordX, _coordY);
        }

        void Update()
        {

        }

    }


}

