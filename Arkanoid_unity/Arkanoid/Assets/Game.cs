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
        [SerializeField]
        private GameObject _bat;

        private bool _isPelletActive;
        private int _lives;
        private float _boardHeight = 10.5f;
        private float _boardWidth = 18.17F;

        private float _speedBat = 30.0f;
        private float _coordBatX = 0.0f;
        private float _coordBatY = -3.5f;

        private Vector3 _movement;
        private Rigidbody2D _pelletRigidbody;



        // Use this for initialization
        void Awake()
        {
            _pelletRigidbody = _pellet.GetComponent<Rigidbody2D>();
            _movement = new Vector3(-6, 6, 0);
            _isPelletActive = false;
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

            _coordBatX += Input.GetAxis("Horizontal") * Time.deltaTime * _speedBat;
            _bat.transform.position = new Vector3(_coordBatX, _coordBatY);


        }


        void Update()
        {


        }
    }
}
