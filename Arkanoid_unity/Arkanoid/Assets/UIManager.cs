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

        internal void GameOverMessage()
        {
            _messageTextArray[1].gameObject.SetActive(true);
        }

        internal void LevelCompletedMessage()
        {
            _messageTextArray[0].gameObject.SetActive(true);
        }

        internal void DeleteMessage()
        {
            foreach (var message in _messageTextArray)
            {
                message.SetActive(true);
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
    }
}
