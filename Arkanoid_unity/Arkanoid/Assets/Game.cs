using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Arkanoid
{

    public class Game : MonoBehaviour
    {
        [SerializeField]
        private GameObject _board;
        [SerializeField]
        private GameObject _pellet;
        private Rigidbody2D _pelletRigidbody;
        private Vector3 _movement;
        private float _boardHeight = 10.5f;
        private float _boardWidth = 18.17F;

        // Use this for initialization
        void Awake()
        {
            _pelletRigidbody = _pellet.GetComponent<Rigidbody2D>();
            _movement = new Vector3(-4, 4, 0);
        }

        void Start()
        {
            //Application.targetFrameRate = 40;
        }

        void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _pelletRigidbody.AddForce(_movement,  ForceMode2D.Impulse);
            }
        }


        void Update()
        {


        }
    }
}
