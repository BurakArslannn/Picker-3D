using RunTime.Signals;
using TMPro;
using UnityEngine;

namespace RunTime.Controllers.UI
{
    public class TotalCoinsPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private TextMeshProUGUI totalCoinsText;
        
        #endregion

        #endregion

        
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onSetTotalCoinCount += OnSetTotalCoinCountText;
        }

        private void OnSetTotalCoinCountText(int totalCoinValue)
        {
            totalCoinsText.text = totalCoinValue.ToString();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void UnSubscribeEvents()
        {
            UISignals.Instance.onSetTotalCoinCount -= OnSetTotalCoinCountText;
        }
    }
}