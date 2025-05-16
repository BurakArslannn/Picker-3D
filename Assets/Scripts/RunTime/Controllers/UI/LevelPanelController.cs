using System;
using System.Collections.Generic;
using DG.Tweening;
using RunTime.Signals;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RunTime.Controllers.UI
{
    public class LevelPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<Image> stageImages = new List<Image>();
        [SerializeField] private List<TextMeshProUGUI> levelText = new List<TextMeshProUGUI>();

        #endregion

        #endregion


        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onSetLevelValue += OnSetLevelValue;
            UISignals.Instance.onSetStageColor += OnSetStageColor;
        }

        [Button("Set Stage Color")]
        private void OnSetStageColor(byte stageValues)
        {
            stageImages[stageValues].DOColor(new Color(0.9960785f, 0.4196079f, 0.07843138f), 0.5f);
        }

        private void OnSetLevelValue(byte levelValues)
        {
            var additionalValue = ++levelValues;
            levelText[0].text = additionalValue.ToString();
            additionalValue++;
            levelText[1].text = additionalValue.ToString();
        }

        private void UnSubscribeEvents()
        {
            UISignals.Instance.onSetLevelValue -= OnSetLevelValue;
            UISignals.Instance.onSetStageColor -= OnSetStageColor;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
}