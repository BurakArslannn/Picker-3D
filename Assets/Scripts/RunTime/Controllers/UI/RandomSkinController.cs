using System.Collections.Generic;
using RunTime.Managers;
using RunTime.Signals;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace RunTime.Controllers.UI
{
    public class RandomSkinController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<Button> pickerSkins = new List<Button>();

        [SerializeField] private ParticleSystem confettiParticle;

        #region Private Variables

        private int _totalCoins;

        private const int RandomSkinCost = 500;

        #endregion

        #endregion

        #endregion

        private void Awake()
        {
            _totalCoins = SaveManager.LoadTotalCoin();
            ShowOpenedSkins();
        }

        private void ShowOpenedSkins()
        {
            int openedSkinCount = SaveManager.LoadCurrentSkin();

            for (int i = 0; i < openedSkinCount && i < pickerSkins.Count; i++)
            {
                var button = pickerSkins[i];
                button.gameObject.SetActive(true);

                Transform skinTransform = button.transform;

                Transform closedImage = skinTransform.GetChild(0);
                Transform openImage = skinTransform.GetChild(1);

                closedImage.gameObject.SetActive(true);
                openImage.gameObject.SetActive(false);
            }
        }


        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onOpenSkin += OnOpenRandomSkin;
        }

        private void OnOpenRandomSkin()
        {
            var currentSkinIndex = SaveManager.LoadCurrentSkin();

            if (currentSkinIndex >= pickerSkins.Count)
            {
                Debug.Log("Tüm skinler açıldı. İşlem yapılmayacak.");
                return;
            }

            if (_totalCoins >= RandomSkinCost)
            {
                var button = pickerSkins[currentSkinIndex];
                button.gameObject.SetActive(true);

                Transform skinTransform = button.transform;

                Transform closedImage = skinTransform.GetChild(0);
                Transform openImage = skinTransform.GetChild(1);

                closedImage.gameObject.SetActive(true);
                openImage.gameObject.SetActive(false);

                confettiParticle.Play();
                _totalCoins -= RandomSkinCost;
                SaveManager.SaveTotalCoin(_totalCoins);
                UISignals.Instance.onSetTotalCoinCount?.Invoke(_totalCoins);

                // Bir sonraki skin için index artırılır
                SaveManager.SaveCurrentSkin(currentSkinIndex + 1);
            }
            else
            {
                Debug.Log("Yeterli coin yok.");
            }
        }


        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void UnSubscribeEvents()
        {
            UISignals.Instance.onOpenSkin -= OnOpenRandomSkin;
        }

        [Button]
        private void ResetIndex()
        {
            SaveManager.ResetSkinIndexValue();
        }
    }
}