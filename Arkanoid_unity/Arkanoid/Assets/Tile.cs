using UnityEngine;

namespace Arkanoid
{
    public class Tile : MonoBehaviour
    {
        [SerializeField]
        private bool _isDestroyable;
        [SerializeField]
        private int _durability;

        //TODO временно.
        private bool _isHaveBonus = true;

        void OnCollisionEnter2D()
        {
            if (_isDestroyable && _durability > 0)
                _durability -= 1;
            if (_durability == 0)
                gameObject.SetActive(false);
        }
    }
}
