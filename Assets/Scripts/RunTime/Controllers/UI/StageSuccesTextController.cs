using System;
using System.Collections.Generic;
using DG.Tweening;
using RunTime.Signals;
using TMPro;
using UnityEngine;

namespace RunTime.Controllers.UI
{
    public class StageSuccesTextController : MonoBehaviour
    {
        [SerializeField] private List<TextMeshProUGUI> successTexts = new List<TextMeshProUGUI>();

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onShowStageSuccessText += OnShowStageSuccessText;
        }

        private void OnShowStageSuccessText(byte stageValue)
        {
            successTexts[stageValue - 1].gameObject.SetActive(true);
            successTexts[stageValue - 1].DOFade(1, 4).OnComplete(() => successTexts[stageValue - 1].DOFade(0, 1));
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void UnSubscribeEvents()
        {
            UISignals.Instance.onShowStageSuccessText -= OnShowStageSuccessText;
        }
    }
}