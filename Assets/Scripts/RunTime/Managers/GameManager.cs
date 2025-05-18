using RunTime.Enums;
using RunTime.Signals;
using UnityEngine;

namespace RunTime.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private GameStates states;

        #endregion

        #endregion


        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onChangeGameState += OnChangeGameState;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onChangeGameState -= OnChangeGameState;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        //[Button("Change State")]
        private void OnChangeGameState(GameStates state)
        {
            states = state;
        }
    }
}