using System.Collections.Generic;
using RunTime.Data.UnityObjects;
using RunTime.Data.ValueObjects;
using RunTime.Signals;
using UnityEngine;

namespace RunTime.Controllers.MiniGame
{
    public class CoinPhysicController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<GameObject> coins;
        [SerializeField] private Collider pickerCollider;

        #region Private Variables

        private int _cointValue;
        private InventoryData _inventoryData;

        private readonly string _blueCoin = "BlueCoin";
        private readonly string _pinkCoin = "PinkCoin";
        private readonly string _greenCoin = "GreenCoin";
        private readonly string _orangeCoin = "OrangeCoin";

        #endregion

        #endregion

        #endregion

        private void OnEnable()
        {
            CoreGameSignals.Instance.onMinigameCompleted += OnMinigameCompleted;
        }

        private void OnMinigameCompleted()
        {
            OnTriggerEnter(pickerCollider);
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.onMinigameCompleted -= OnMinigameCompleted;
        }


        private void OnTriggerEnter(Collider other)
        {
            _inventoryData = Resources.Load<CD_Inventory>("Data/CD_Inventory").InventoryData;

            if (other.CompareTag(_greenCoin))
            {
                _inventoryData.cointCount += 100;
            }
            else if (other.CompareTag(_blueCoin))
            {
                _inventoryData.cointCount += 400;
            }
            else if (other.CompareTag(_pinkCoin))
            {
                _inventoryData.cointCount += 300;
            }
            else if (other.CompareTag(_orangeCoin))
            {
                _inventoryData.cointCount += 200;
            }
            else
            {
                return;
            }

            UISignals.Instance.onSetCoinCount?.Invoke(_inventoryData.cointCount);
        }
    }
}