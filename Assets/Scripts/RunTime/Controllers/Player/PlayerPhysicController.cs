using System;
using RunTime.Managers;
using RunTime.Signals;
using UnityEngine;

namespace RunTime.Controllers.Player
{
    public class PlayerPhysicController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerManager manager;
        [SerializeField] private new Collider collider;
        [SerializeField] private new Rigidbody rigidbody;

        private readonly string _stageArea = "Stage Area";
        private readonly string _finishArea = "Finish Area";
        private readonly string _minigame = "Minigame Area";

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_stageArea))
            {
                manager.ForceCommand.Execute();
                CoreGameSignals.Instance.onStageAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();

                //Stage area Control
            }

            if (other.CompareTag(_finishArea))
            {
                CoreGameSignals.Instance.onFinishAreaEntered?.Invoke();
                InputSignals.Instance.onDisableInput?.Invoke();
                CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
                return;
            }

            if (other.CompareTag(_minigame))
            {
                //Write minigame mechanics
                
            }
        }
    }
}