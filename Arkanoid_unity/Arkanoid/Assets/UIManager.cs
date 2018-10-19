using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    internal class UIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _messageTextArray;

        internal void GameOverMessage()
        {
            _messageTextArray[0].gameObject.SetActive(true);
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


    }
}
