using RunTime.Controllers.MiniGame;
using RunTime.Signals;
using UnityEngine;

namespace RunTime.Managers
{
    public class MiniGameManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private MiniGameController miniGameController;

        #endregion

        #region Private Variables

        private byte _collectedObjectCount;

        #endregion

        #endregion

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onMiniGameAreaEntered += OnMiniGameAreaEntered;
        }

        private void OnMiniGameAreaEntered()
        {
            miniGameController.SpeedUpPicker();
            miniGameController.CalculateTravelDistance();
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onMiniGameAreaEntered -= OnMiniGameAreaEntered;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
}