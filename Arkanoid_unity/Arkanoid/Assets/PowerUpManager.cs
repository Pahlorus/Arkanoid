using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    internal class PowerUpManager : MonoBehaviour
    {
        [SerializeField]
        private PowerUps[] _powerUpArray;
        private int _powerUpArrayLength;

        private void Awake()
        {
            _powerUpArrayLength = this.GetComponent<PowerUpManager>()._powerUpArray.Length;
        }

        internal PowerUps PowerUpPrefGet()
        {
            int arrayIndex = UnityEngine.Random.Range(0, _powerUpArrayLength);
            return _powerUpArray[arrayIndex];
        }
    }
}
