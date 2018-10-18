
using UnityEngine;

namespace Arkanoid
{

    public class Game : MonoBehaviour
    {
        [SerializeField]
        private GameObject _board;
        //[SerializeField]
        //private GameObject _pellet;
        [SerializeField]
        private Pellet _pellet;
        [SerializeField]
        private BatControler _bat;
        [SerializeField]
        private PowerUpManager _powerUpManager;
        [SerializeField]
        private PelletSpeedUp _powerUp;
        protected bool _isPowerUpActive;

        private int _lives;
        private int _scores;
        private int _livesLimit = 3;
        private float _boardHeight = 10.5f;
        private float _boardWidth = 18.17F;
        private int _probabilityIndex = 10;


        public void GameStart()
        {
            _lives = _livesLimit;
            _scores = 0;
            _isPowerUpActive = false;
        }


        void Awake()
        {
           // _pellet.OnCollision += BonusCreate;
        }

        public void PelletSpeedUp()
        {
            _pellet.SpeedUp();
        }

        public void BatWidthUp()
        {
            _bat.WidthUp();
        }

        public void SetPowerUpStatus()
        {
            if (_isPowerUpActive)
                _isPowerUpActive = false;
            else
                _isPowerUpActive = true;
        }

        private void BonusCreate(object sender, System.EventArgs e)
        {
            if (!_isPowerUpActive)
            {
                int powerUpProbability = Random.Range(0, _probabilityIndex);

                if (powerUpProbability <= 5)
                {
                    Vector3 pelletPosition = _pellet.transform.position;
                    PowerUps powerUpPref = _powerUpManager.PowerUpPrefGet();
                    PowerUps powerUp = Instantiate(powerUpPref, _powerUpManager.transform);
                    SetPowerUpStatus();
                    powerUp.Initialize(this);
                    powerUp.transform.localScale = Vector3.one;
                    powerUp.transform.position = pelletPosition;
                }
            }


        }
    }
}

