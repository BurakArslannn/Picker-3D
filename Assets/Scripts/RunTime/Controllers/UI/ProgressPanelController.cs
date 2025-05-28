using System.Collections.Generic;
using DG.Tweening;
using RunTime.Data.ValueObjects;
using RunTime.Signals;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace RunTime.Controllers.UI
{
    public class ProgressPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serilized Variables

        [SerializeField] private List<Image> stageimages = new List<Image>();

        #endregion

        #endregion

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onSetScore += OnSetProgressColor;
        }


        private void OnSetProgressColor(byte scoreValue)
        {
            if (stageimages == null || stageimages.Count < 6) return;

            TrySetStage(0, scoreValue > 5, Color.red);
            TrySetStage(1, scoreValue > 10, new Color(1f, 0.5f, 0.5f));
            TrySetStage(2, scoreValue > 15, new Color(1f, 0.65f, 0f));
            TrySetStage(3, scoreValue > 20, Color.yellow);
            TrySetStage(4, scoreValue > 25, new Color(0.56f, 0.93f, 0.56f));
            TrySetStage(5, scoreValue > 30, new Color(0f, 0.5f, 0f));
        }

        private void TrySetStage(int index, bool condition, Color targetColor)
        {
            if (!condition) return;

            var img = stageimages[index];

            Color startColor = targetColor;
            startColor.a = 0f;
            img.color = startColor;

            img.DOColor(new Color(targetColor.r, targetColor.g, targetColor.b, 1f), 1f);
        }


        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void UnSubscribeEvents()
        {
            UISignals.Instance.onSetScore -= OnSetProgressColor;
        }
    }
}