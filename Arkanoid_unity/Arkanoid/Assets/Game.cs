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
        private Pellet _scriptPellet;
        [SerializeField]
        private GameObject _bat;
        [SerializeField]
        private GameObject _powerUps;
        private BatSpeedUp _powerUp;


        private int _lives;
        private float _boardHeight = 10.5f;
        private float _boardWidth = 18.17F;




        void Awake()
        {
            _scriptPellet.BonusCreate += _scriptPellet_BonusCreate;
        }

        private void _scriptPellet_BonusCreate(object sender, System.EventArgs e)
        {
            _powerUp = new GameObject("BatSpeedUp", typeof(BatSpeedUp)).GetComponent<BatSpeedUp>();
            _powerUp.transform.SetParent(_powerUps.transform);
        }


        // Use this for initialization


        void Start()
        {
            //Application.targetFrameRate = 40;
        }



        void Update()
        {


        }
    }
}
