
using UnityEngine;

namespace Arkanoid
{
    public class Game : MonoBehaviour
    {
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
        private UIManager _uiManager;

        protected bool _isPowerUpActive;
        private int _tilesCount;
        private int _lives;
        private int _scores;
        private int _scoreStep = 10;
        private int _initialLivesLimit = 3;
        private int _probabilityPowerUp = 10;

        void Awake()
        {
            Cursor.visible = false;
            _tilesCount = _levelTiles.transform.childCount;
            GameStart();
            _uiManager.LivesTextOutput(_lives);
            _uiManager.ScoreTextOutput(_scores);
            _pellet.OnCollision += _pellet_OnCollision;
            _pellet.OnFailed += _pellet_OnFailed;
            foreach (Transform transform in _levelTiles.transform)
            {
                transform.GetComponent<Tile>().OnTileDestroy += Tile_OnTileDestroy;
            }
        }

        public void GameStart()
        {
            _lives = _initialLivesLimit;
            _scores = 0;
            _isPowerUpActive = false;
        }

        public void GameStop()
        {
            enabled = false;
            _bat.enabled = false;
            _pellet.PelletInActive();
            _pellet.enabled = false;
            _pellet.gameObject.SetActive(false);
        }

        public void PelletSpeedUp()
        {
            _pellet.SpeedUp();
        }

        public void BatWidthUp()
        {
            _bat.WidthUp();
        }

        public void LivesUp()
        {
            _lives += 1;
            _uiManager.LivesTextOutput(_lives);
        }

        public void ScoreUp()
        {
            _scores += _scoreStep;
            _uiManager.ScoreTextOutput(_scores);
        }

        public void SetPowerUpStatus()
        {
            if (_isPowerUpActive)
                _isPowerUpActive = false;
            else
                _isPowerUpActive = true;
        }

        private void Tile_OnTileDestroy(object sender, System.EventArgs e)
        {
            CountTilesAndCheckLevelCompleted();
            ScoreUp();
        }

        private void _pellet_OnFailed(object sender, System.EventArgs e)
        {
            _lives -= 1;
            CountLivesCheck();
            _uiManager.LivesTextOutput(_lives);
            _pellet.PelletInActive();
        }

        private void _pellet_OnCollision(object sender, System.EventArgs e)
        {
            BonusCreate();
            ScoreUp();
        }

        private void CountLivesCheck()
        {
            if (_lives < 0)
            {
                _uiManager.GameOverMessage();
                GameStop();
            }
        }

        private void CountTilesAndCheckLevelCompleted()
        {
            _tilesCount -= 1;
            if (_tilesCount <= 0)
            {
                _uiManager.LevelCompletedMessage();
                GameStop();
            }
        }

        private void BonusCreate()
        {
            if (!_isPowerUpActive)
            {
                int powerUpProbability = Random.Range(0, _probabilityPowerUp);

                if (powerUpProbability <= 2)
                {
                    Vector3 pelletPosition = _pellet.transform.position;
                    PowerUp powerUpPref = _powerUpManager.PowerUpPrefGet();
                    PowerUp powerUp = Instantiate(powerUpPref, _powerUpManager.transform);
                    SetPowerUpStatus();
                    powerUp.Initialize(this);
                    powerUp.transform.localScale = Vector3.one;
                    powerUp.transform.position = pelletPosition;
                }
            }
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }
}

