using System;
using RunTime.Signals;
using UnityEngine;
using UnityEngine.Serialization;

namespace RunTime.Managers
{
    public class SoundManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private AudioSource gameSound;

        #endregion

        #endregion

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onTurnOnSound += TurnOnMusic;
            CoreGameSignals.Instance.onTurnOffSound += TurnOffMusic;
        }

        private void TurnOffMusic()
        {
            gameSound.enabled = false;
        }

        private void TurnOnMusic()
        {
            gameSound.enabled = true;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onTurnOnSound -= TurnOnMusic;
            CoreGameSignals.Instance.onTurnOffSound -= TurnOffMusic;
        }
    }
}