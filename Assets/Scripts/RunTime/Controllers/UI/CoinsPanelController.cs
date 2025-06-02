using RunTime.Signals;
using TMPro;
using UnityEngine;

namespace RunTime.Controllers.UI
{
    public class CoinsPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private TextMeshProUGUI coinsText;

        #endregion

        #endregion


        private void OnEnable()
        {
            SubsribeEvents();
        }

        private void SubsribeEvents()
        {
            UISignals.Instance.onSetMiniGameCoinCount += SetCointsText;
        }

        private void SetCointsText(int coins)
        {
            coinsText.text = coins.ToString();
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void UnSubscribeEvents()
        {
            UISignals.Instance.onSetMiniGameCoinCount -= SetCointsText;
        }
    }
}