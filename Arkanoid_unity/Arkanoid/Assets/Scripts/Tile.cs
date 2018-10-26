using System;
using UnityEngine;

namespace Arkanoid
{
    public class Tile : MonoBehaviour
    {
        [SerializeField]
        private bool _isDestroyable;
        [SerializeField]
        private int _durability;

        internal event EventHandler OnTileDestroy;

        void OnCollisionEnter2D()
        {
            if (_isDestroyable && _durability > 0)
                _durability -= 1;
            if (_durability == 0)
            {
                gameObject.SetActive(false);
                OnTileDestroy?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
