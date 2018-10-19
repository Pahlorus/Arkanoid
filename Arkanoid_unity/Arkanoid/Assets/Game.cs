
using UnityEngine;

namespace Arkanoid
{

    public class Game : MonoBehaviour
    {
        [SerializeField]
        private GameObject _board;
        [SerializeField]
        private GameObject _levelTiles;
        [SerializeField]
        private Pellet _pellet;
        [SerializeField]
        private BatControler _bat;
        [SerializeField]
        private PowerUpManager _powerUpManager;
        [SerializeField]
        private PelletSpeedUp _powerUp;
        [SerializeField]
        private UIManager _ui;


        protected bool _isPowerUpActive;

        private int _tilesCount;
        private int _lives;
        private int _scores;
        private int _initialLivesLimit = 3;
        private float _boardHeight = 10.5f;
        private float _boardWidth = 18.17F;
        private int _probabilityIndex = 10;


        public void GameStart()
        {
            _lives = _initialLivesLimit;
            _scores = 0;
            _isPowerUpActive = false;
        }

        public void GameStop()
        {
            enabled = false;
        }


        void Awake()
        {
            _lives = _initialLivesLimit = 3;
            Cursor.visible = false;
            //  _pellet.OnCollision += _pellet_OnCollision;
            _pellet.OnFailed += _pellet_OnFailed; ;
            _tilesCount = _levelTiles.transform.childCount;
        }

        private void _pellet_OnFailed(object sender, System.EventArgs e)
        {

        }

        private void _pellet_OnCollision(object sender, System.EventArgs e)
        {
            BonusCreate();
            CountTilesAndCheckLevelCompleted();

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


        private void CountTilesAndCheckLevelCompleted()
        {
            _tilesCount -= 1;
            if (_tilesCount <= 0)
            {
                _ui.LevelCompletedMessage();
                GameStop();
            }
                

        }


        private void BonusCreate()
        {
            if (!_isPowerUpActive)
            {
                int powerUpProbability = Random.Range(0, _probabilityIndex);

                if (powerUpProbability <= 2)
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

