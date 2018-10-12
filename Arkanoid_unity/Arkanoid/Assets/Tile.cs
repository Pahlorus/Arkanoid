using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arkanoid
{
    public class Tile : MonoBehaviour
    {
        void OnCollisionEnter2D()
        {
            gameObject.SetActive(false);
        }

    }
}
