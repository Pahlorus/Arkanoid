﻿
using System.Collections;
using UnityEngine;

namespace Arkanoid
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private Pellet _pellet;
        [SerializeField]
        private BatControler _bat;
        [SerializeField]
        private PowerUpManager _powerUpManager;
        [SerializeField]
        private PelletSpeedUp _powerUp;
        [SerializeField] private UIManager _uiManager;

        protected bool _isPowerUpActive;
        [SerializeField] private LevelManager _levelManager;
        private int _lives;
        private int _scores;
        private int _tilesCount;
        private int _scoreStep = 10;
        private int _initialLivesLimit = 3;
        private int _probabilityPowerUp = 10;

        private Transform _levelTiles;



        void Awake()
        {
            _pellet.OnCollision += _pellet_OnCollision;
            _pellet.OnFailed += _pellet_OnFailed;
            _levelManager.OnLevelLoadCompleted += _levelManager_OnLevelLoadCompleted;
            _levelManager.OnLevelUnLoadCompleted += _levelManager_OnLevelUnLoadCompleted;
            _levelManager.OnAllScenesCompleted += _levelManager_OnAllScenesCompleted;
        }

        private void _levelManager_OnAllScenesCompleted(object sender, System.EventArgs e)
        {
            GameStop();
            _uiManager.WinMessage();
            _uiManager.UIButtonReturnSwitchOn();
            Cursor.visible = true;
        }

        private void _levelManager_OnLevelUnLoadCompleted(object sender, System.EventArgs e)
        {

        }

        private void _levelManager_OnLevelLoadCompleted(object sender, System.EventArgs e)
        {
            _uiManager.DeleteMessage();
            _tilesCount = _levelManager.TilesCount;
            _levelTiles = _levelManager.LevelTiles;

            foreach (Transform transform in _levelTiles)
            {
                transform.GetComponent<Tile>().OnTileDestroy += Tile_OnTileDestroy;
            }

            _pellet.SwitchOn();
            _bat.SwitchOn();
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
                _pellet.PelletInActive();
                _pellet.SwitchOff();
                _bat.SwitchOff();
                _levelManager.ChangeLevel();
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


        internal void GameStart()
        {
            Cursor.visible = false;
            _lives = _initialLivesLimit;
            _scores = 0;
            _uiManager.LivesTextOutput(_lives);
            _uiManager.ScoreTextOutput(_scores);
            _levelManager.ActiveSceneIndexReset();
            _levelManager.LoadLevel(1);
            _uiManager.HUDTextSwitchOn();
            _uiManager.UIButtonsSwitchOff();
            _isPowerUpActive = false;
            _pellet.SwitchOn();
            _bat.SwitchOn();
        }
        internal void MainMenuReturn()
        {
            _uiManager.DeleteMessage();
            _uiManager.UIButtonReturnSwitchOff();
            _uiManager.HUDTextSwitchOff();
            _uiManager.UIButtonsSwitchOn();
        }

        internal void GameStop()
        {
            _bat.SwitchOff();
            _pellet.PelletInActive();
            _pellet.SwitchOff();
        }

        internal void PelletSpeedUp()
        {
            _pellet.SpeedUp();
        }

        internal void BatWidthUp()
        {
            _bat.WidthUp();
        }

        internal void LivesUp()
        {
            _lives += 1;
            _uiManager.LivesTextOutput(_lives);
        }

        internal void ScoreUp()
        {
            _scores += _scoreStep;
            _uiManager.ScoreTextOutput(_scores);
        }

        internal void SetPowerUpStatus()
        {
            if (_isPowerUpActive)
                _isPowerUpActive = false;
            else
                _isPowerUpActive = true;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }
}

