using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Arkanoid
{
    public class LevelManager : MonoBehaviour
    {
        private int _tilesCount;
        private Scene _levelScene;
        private AsyncOperation _asyncOperation;
        [SerializeField]
        private GameObject[] level;
        private Transform _levelTiles;

        internal event EventHandler OnLevelLoadCompleted;

        internal int TilesCount { get { return _tilesCount; } }
        internal Transform LevelTiles { get { return _levelTiles; } }

        IEnumerator LoadScene()
        {
            yield return null;
            _asyncOperation = SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);

            while (!_asyncOperation.isDone)
            {
                yield return null;
            }
            _levelScene = SceneManager.GetSceneByBuildIndex(3);
            level = _levelScene.GetRootGameObjects();
            _levelTiles = level[0].transform;
            _tilesCount = _levelTiles.childCount;
            OnLevelLoadCompleted?.Invoke(this, EventArgs.Empty);
        }

        internal void LoadLevel(int indexLevel)
        {
            StartCoroutine(LoadScene());
        }

        internal void UnLoadLevel(int indexLevel)
        {

        }

    }
}
