using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    internal class UIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _messageTextArray;
        [SerializeField]
        private Text _scoreText;
        [SerializeField]
        private Text _livesText;
        [SerializeField]
        private Button[] _mainMenuButtons;
        [SerializeField]
        private Button _mainMenuReturnButton;


        internal void GameOverMessage()
        {
            _messageTextArray[1].gameObject.SetActive(true);
        }

        internal void LevelCompletedMessage()
        {
            _messageTextArray[0].gameObject.SetActive(true);
        }

        internal void WinMessage()
        {
            _messageTextArray[2].gameObject.SetActive(true);
        }

        internal void DeleteMessage()
        {
            foreach (var message in _messageTextArray)
            {
                message.SetActive(false);
            }
        }

        internal void ScoreTextOutput(int score)
        {
            _scoreText.text = "Score: " + score.ToString();
        }

        internal void LivesTextOutput(int lives)
        {
            _livesText.text = "Lives: " + lives.ToString();
        }

        internal void HUDTextSwitchOn()
        {
            _livesText.gameObject.SetActive(true);
            _scoreText.gameObject.SetActive(true);
        }

        internal void HUDTextSwitchOff()
        {
            _livesText.gameObject.SetActive(false);
            _scoreText.gameObject.SetActive(false);
        }

        internal void UIButtonsSwitchOn()
        {
            foreach (var button in _mainMenuButtons)
            {
                button.gameObject.SetActive(true);
            }
        }

        internal void UIButtonReturnSwitchOn()
        {
            _mainMenuReturnButton.gameObject.SetActive(true);
        }
        internal void UIButtonReturnSwitchOff()
        {
            _mainMenuReturnButton.gameObject.SetActive(false);
        }

        internal void UIButtonsSwitchOff()
        {
            foreach (var button in _mainMenuButtons)
            {
                button.gameObject.SetActive(false);
            }
        }
    }
}
