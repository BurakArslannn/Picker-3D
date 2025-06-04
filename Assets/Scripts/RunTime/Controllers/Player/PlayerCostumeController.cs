using RunTime.Managers;
using RunTime.Signals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RunTime.Controllers.Player
{
    public class PlayerCostumeController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private GameObject picker;
        [SerializeField] private Material[] costumes;

        #endregion

        #endregion

        private void Awake()
        {
            int index = SaveManager.LoadChoosenSkinIndex();
            OnSetSelectedCostume(index);
        }


        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onSetSelectedCostume += OnSetSelectedCostume;
        }

        private void OnSetSelectedCostume(int index)
        {
            switch (index)
            {
                case 1:
                    picker.GetComponent<MeshRenderer>().material = costumes[0];
                    Debug.LogWarning("Kostum indexi degistirildi: " + index);
                    break;
                case 2:
                    picker.GetComponent<MeshRenderer>().material = costumes[1];
                    Debug.LogWarning("Kostum indexi degistirildi: " + index);
                    break;
                case 3:
                    picker.GetComponent<MeshRenderer>().material = costumes[2];
                    Debug.LogWarning("Kostum indexi degistirildi: " + index);
                    break;
                default:
                    Debug.LogWarning("Geçersiz kostüm indexi: " + index);
                    break;
            }

            SaveManager.SaveChoosenSkinIndex(index);
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onSetSelectedCostume -= OnSetSelectedCostume;
        }

        [Button]
        private void ResetIndex()
        {
            SaveManager.ResetChosenSkinIndex();
        }
    }
}