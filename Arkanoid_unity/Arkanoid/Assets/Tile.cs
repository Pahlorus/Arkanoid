using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class Tile : MonoBehaviour
    {
        [SerializeField]
        private bool _isDestroyable;
        [SerializeField]
        private int _durability;
        [SerializeField]
        private Color32 color;

        void OnCollisionEnter2D()
        {
            if (_isDestroyable && _durability > 0)
                _durability -= 1;
            if(_durability ==0 )
            gameObject.SetActive(false);
        }

    }
}
