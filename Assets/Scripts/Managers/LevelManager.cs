using System;
using Commands.Level;
using Data.UnityObjects;
using Data.ValueObjects;
using Signals;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region SelfVariables

        #region Serialized Variables

        [SerializeField] private Transform levelHolder;
        [SerializeField] private byte totalLevelCount;

        #endregion

        #region Private Variables

        private OnLevelLoaderCommand _levelLoaderCommand;
        private OnLevelDestroyerCommand _levelDestroyerCommand;

        private short _currentLevel;
        private LevelData _levelData;

        #endregion

        #endregion


        private void Awake()
        {
            _levelData = GetLevelData();
            _currentLevel = GetActiveLevel();

            Init();
        }

        private void Init()
        {
            _levelLoaderCommand = new OnLevelLoaderCommand(levelHolder);
            _levelDestroyerCommand = new OnLevelDestroyerCommand(levelHolder);
        }

        private LevelData GetLevelData()
        {
            return Resources.Load<CD_Level>("Data/CD_Level").Levels[_currentLevel];
        }

        private byte GetActiveLevel()
        {
            return (byte)_currentLevel;
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }


        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize += _levelLoaderCommand.Execute;
            CoreGameSignals.Instance.onClearActiveLevel += _levelDestroyerCommand.Execute;
            CoreGameSignals.Instance.onGetLevelValue += OnGetLevelValue;
            CoreGameSignals.Instance.onNextlevel += OnNextlevel;
            CoreGameSignals.Instance.onRestartLevel += OnRestartLevel;
        }

        private void OnNextlevel()
        {
            _currentLevel++;
            CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.onReset?.Invoke();
            CoreGameSignals.Instance.onLevelInitialize?.Invoke((byte)(_currentLevel % totalLevelCount));
        }

        private byte OnGetLevelValue()
        {
            return (byte)_currentLevel;
        }

        private void OnRestartLevel()
        {
            CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.onReset?.Invoke();
            CoreGameSignals.Instance.onLevelInitialize?.Invoke((byte)(_currentLevel % totalLevelCount));
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize -= _levelLoaderCommand.Execute;
            CoreGameSignals.Instance.onClearActiveLevel -= _levelDestroyerCommand.Execute;
            CoreGameSignals.Instance.onGetLevelValue -= OnGetLevelValue;
            CoreGameSignals.Instance.onNextlevel -= OnNextlevel;
            CoreGameSignals.Instance.onRestartLevel -= OnRestartLevel;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void Start()
        {
            CoreGameSignals.Instance.onLevelInitialize?.Invoke((byte)(_currentLevel % totalLevelCount));
            //UISignals
        }
    }
}