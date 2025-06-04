using RunTime.Enums;
using Runtime.Managers;
using RunTime.Managers;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Handlers
{
    public class UIEventSubscriber : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private UIEventSubscriptionTypes type;
        [SerializeField] private Button button;

        #endregion

        #region Private Variables

        [ShowInInspector] private UIManager _manager;

        #endregion

        #endregion

        private void Awake()
        {
            FindReferences();
        }

        private void FindReferences()
        {
            _manager = FindObjectOfType<UIManager>();
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            switch (type)
            {
                case UIEventSubscriptionTypes.OnPlay:
                {
                    button.onClick.AddListener(_manager.Play);
                    break;
                }
                case UIEventSubscriptionTypes.OnNextLevel:
                {
                    button.onClick.AddListener(_manager.NextLevel);
                    break;
                }
                case UIEventSubscriptionTypes.OnRestartLevel:
                {
                    button.onClick.AddListener(_manager.RestartLevel);
                    break;
                }
                case UIEventSubscriptionTypes.OnOpenStorePanel:
                {
                    button.onClick.AddListener(_manager.OpenStorePanel);
                    break;
                }
                case UIEventSubscriptionTypes.OnTurnStartPanel:
                {
                    button.onClick.AddListener(_manager.TurnOnMenu);
                    break;
                }
                case UIEventSubscriptionTypes.OnOpenSkin:
                {
                    button.onClick.AddListener(_manager.OpenPickerCostume);
                    break;
                }
                case UIEventSubscriptionTypes.OnExitGame:
                {
                    button.onClick.AddListener(_manager.ExitGame);
                    break;
                }
                case UIEventSubscriptionTypes.OnOpenSettingsPanel:
                {
                    button.onClick.AddListener(_manager.OpenSettings);
                    break;
                }
                case UIEventSubscriptionTypes.OnOpenInfoPanel:
                {
                    button.onClick.AddListener(_manager.OpenInfoPanel);
                    break;
                }
                case UIEventSubscriptionTypes.OnTurnOnMusic:
                {
                    button.onClick.AddListener(_manager.TurnOnMusic);
                    break;
                }
                case UIEventSubscriptionTypes.OnTurnOffMusic:
                {
                    button.onClick.AddListener(_manager.TurnOffMusic);
                    break;
                }
            }
        }

        private void UnsubscribeEvents()
        {
            switch (type)
            {
                case UIEventSubscriptionTypes.OnPlay:
                {
                    button.onClick.RemoveListener(_manager.Play);
                    break;
                }
                case UIEventSubscriptionTypes.OnNextLevel:
                {
                    button.onClick.RemoveListener(_manager.NextLevel);
                    break;
                }
                case UIEventSubscriptionTypes.OnRestartLevel:
                {
                    button.onClick.RemoveListener(_manager.RestartLevel);
                    break;
                }
                case UIEventSubscriptionTypes.OnOpenStorePanel:
                {
                    button.onClick.AddListener(_manager.OpenStorePanel);
                    break;
                }
                case UIEventSubscriptionTypes.OnTurnStartPanel:
                {
                    button.onClick.AddListener(_manager.TurnOnMenu);
                    break;
                }
                case UIEventSubscriptionTypes.OnOpenSkin:
                {
                    button.onClick.AddListener(_manager.OpenPickerCostume);
                    break;
                }
                case UIEventSubscriptionTypes.OnExitGame:
                {
                    button.onClick.AddListener(_manager.ExitGame);
                    break;
                }
                case UIEventSubscriptionTypes.OnOpenSettingsPanel:
                {
                    button.onClick.AddListener(_manager.OpenSettings);
                    break;
                }
                case UIEventSubscriptionTypes.OnOpenInfoPanel:
                {
                    button.onClick.AddListener(_manager.OpenInfoPanel);
                    break;
                }
                case UIEventSubscriptionTypes.OnTurnOnMusic:
                {
                    button.onClick.AddListener(_manager.TurnOnMusic);
                    break;
                }
                case UIEventSubscriptionTypes.OnTurnOffMusic:
                {
                    button.onClick.AddListener(_manager.TurnOffMusic);
                    break;
                }
            }
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
    }
}