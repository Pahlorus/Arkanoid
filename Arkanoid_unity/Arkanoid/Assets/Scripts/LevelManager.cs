using System;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace Arkanoid
{
    public class LevelManager : MonoBehaviour
    {
        private GameObject[] _levelRootObjects;
        private int _scenesCount;
        private int _activeSceneIndex;
        private int _tilesCount;
        private float _timeDelay = 2;
        private Scene _levelScene;
        private AsyncOperation _asyncOperation;
        private Transform _levelTiles;

        internal event EventHandler OnLevelLoadCompleted;
        internal event EventHandler OnLevelUnLoadCompleted;
        internal event EventHandler OnAllScenesCompleted;

        internal int TilesCount { get { return _tilesCount; } }
        internal Transform LevelTiles { get { return _levelTiles; } }

        void Awake()
        {
            _scenesCount = SceneManager.sceneCountInBuildSettings-1;
            _activeSceneIndex = 0;
        }

        IEnumerator LoadScene(int indexLevel)
        {
            _asyncOperation = SceneManager.LoadSceneAsync(indexLevel, LoadSceneMode.Additive);
            while (!_asyncOperation.isDone)
            {
                yield return null;
            }
            _levelScene = SceneManager.GetSceneByBuildIndex(indexLevel);
            _levelRootObjects = _levelScene.GetRootGameObjects();
            _levelTiles = _levelRootObjects[0].transform;
            _tilesCount = _levelTiles.childCount;
            OnLevelLoadCompleted?.Invoke(this, EventArgs.Empty);
        }

        IEnumerator UnLoadScene(int indexLevel)
        {
            _asyncOperation = SceneManager.UnloadSceneAsync(indexLevel);
            while (!_asyncOperation.isDone)
            {
                yield return null;
            }
            OnLevelUnLoadCompleted?.Invoke(this, EventArgs.Empty);
        }

        IEnumerator LevelChangeWithDelay(float time, int activeLevel)
        {
            yield return new WaitForSeconds(time);
            UnLoadLevel(activeLevel);
            LoadLevel(activeLevel+1);
        }


        internal void ChangeLevel()
        {
            if (_activeSceneIndex < _scenesCount)
                StartCoroutine(LevelChangeWithDelay(_timeDelay, _activeSceneIndex));
            else
            {
                UnLoadLevel(_activeSceneIndex);
                OnAllScenesCompleted?.Invoke(this, EventArgs.Empty);
            }
        }

        internal void LoadLevel(int indexLevel)
        {
            StartCoroutine(LoadScene(indexLevel));
            _activeSceneIndex += 1;
        }

        private void UnLoadLevel(int indexLevel)
        {
            StartCoroutine(UnLoadScene(indexLevel));
        }

    }
}
