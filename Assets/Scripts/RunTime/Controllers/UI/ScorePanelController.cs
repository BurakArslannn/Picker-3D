using System;
using RunTime.Managers;
using RunTime.Signals;
using TMPro;
using UnityEngine;

namespace RunTime.Controllers.UI
{
    public class ScorePanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private TextMeshProUGUI scoreText;

        #endregion

        #endregion


        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onSetScore += OnSetLevelValue;
        }

        private void OnSetLevelValue(byte scoreValue)
        {
            var totalCollected = CollectedPoolDataManager.Instance.TotalCollected;
            scoreText.text = totalCollected.ToString();
        }

        private void OnDisable()
        {
            UnSubcscribeEvents();
        }

        private void UnSubcscribeEvents()
        {
            UISignals.Instance.onSetScore -= OnSetLevelValue;
        }
    }
}