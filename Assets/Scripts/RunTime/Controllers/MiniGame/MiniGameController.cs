using Cysharp.Threading.Tasks;
using RunTime.Controllers.Player;
using RunTime.Data.UnityObjects;
using RunTime.Data.ValueObjects;
using RunTime.Managers;
using RunTime.Signals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RunTime.Controllers.MiniGame
{
    public class MiniGameController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized  Variables

        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private CoinPhysicController coinPhysicController;
        [SerializeField] private Transform minigameArea;
        [SerializeField] private Transform pickerTransform;
        [SerializeField] private byte miniGameId;
        [SerializeField] private float maxTravelDistance;

        #endregion

        #region Private Variables

        [ShowInInspector] private LevelObjectData _totalObjectCounts;
        [ShowInInspector] private byte _collectedObjectCount;

        private float _targetZPosition;
        private bool _isCheckingWin = false;

        #endregion

        #endregion


        private void Awake()
        {
            _totalObjectCounts = GetTotalObjectCounts();

            foreach (var col in coinPhysicController.coins)
            {
                col.enabled = false;
            }
        }

        private LevelObjectData GetTotalObjectCounts()
        {
            var cdLevel = Resources.Load<CD_Level>("Data/CD_Level");
            if (cdLevel == null)
            {
                Debug.LogError("CD Level dont found! Check the path: Data/CD_Level");
                return new LevelObjectData();
            }

            int levelIndex = CoreGameSignals.Instance.onGetLevelValue?.Invoke() ?? -1;
            if (levelIndex < 0 || levelIndex >= cdLevel.Levels.Count)
            {
                Debug.LogError($"Unvalid level index: {levelIndex}");
                return new LevelObjectData();
            }

            if (miniGameId >= cdLevel.Levels[levelIndex].ObjectList.Count)
            {
                Debug.LogError(
                    $"Unvalid miniGameId: {miniGameId}, Level: {levelIndex}, ObjectList count: {cdLevel.Levels[levelIndex].ObjectList.Count}");
                return new LevelObjectData();
            }

            return cdLevel.Levels[levelIndex].ObjectList[miniGameId];
        }


        private async UniTaskVoid CheckWinConditionAsync()
        {
            while (pickerTransform.position.z < _targetZPosition)
            {
                await UniTask.Yield();
            }

            movementController.MultiplyForwardSpeed(0);

            foreach (var col in coinPhysicController.coins)
            {
                col.enabled = true;
            }

            CoreGameSignals.Instance.onMinigameCompleted?.Invoke();
            CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
            
            _isCheckingWin = false;
        }


        internal void SpeedUpPicker()
        {
            movementController.MultiplyForwardSpeed(3f);
            Debug.LogWarning("speed up");
        }


        internal void CalculateTravelDistance()
        {
            _collectedObjectCount = CollectedPoolDataManager.Instance.TotalCollected;

            float ratio = (float)_collectedObjectCount / _totalObjectCounts.totalObjectCount;

            _targetZPosition = pickerTransform.position.z + (ratio * maxTravelDistance);

            Debug.Log(
                $"Total object: {_totalObjectCounts.totalObjectCount}, Collected: {_collectedObjectCount}, Ratio: {ratio}, Target Z: {_targetZPosition}");

            CheckWinConditionAsync().Forget();
        }
        
        
    }
}