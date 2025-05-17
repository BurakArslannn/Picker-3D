using System.Collections.Generic;
using RunTime.Enums;
using RunTime.Signals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Runtime.Controllers.UI
{
    public class UIPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<Transform> layers = new List<Transform>();

        #endregion

        #endregion

        private void OnEnable()
        {
            if (CoreUISignals.Instance != null)
            {
                SubscribeEvents();
            }
            else
            {
                Debug.LogError("CoreUISignals.Instance is null in UIPanelController");
            }
        }

        private void SubscribeEvents()
        {
            CoreUISignals.Instance.onOpenpanel += OnOpenPanel;
            CoreUISignals.Instance.onClosepanel += OnClosePanel;
            CoreUISignals.Instance.onCloseAllPanel += OnCloseAllPanels;
        }

        [Button("Close All Panels")]
        private void OnCloseAllPanels()
        {
            foreach (var layer in layers)
            {
                if (layer.childCount <= 0) return;
#if UNITY_EDITOR
                DestroyImmediate(layer.GetChild(0).gameObject);
#else
                Destroy(layer.GetChild(0).gameObject);
#endif
            }
        }

        [Button("Open Panel")]
        private void OnOpenPanel(UIPanelTypes panelType, int value)
        {
            OnClosePanel(value);
            Instantiate(Resources.Load<GameObject>($"Screens/{panelType}Panel"), layers[value]);
        }

        [Button("Close Panel")]
        private void OnClosePanel(int value)
        {
            if (layers[value].childCount <= 0) return;

#if UNITY_EDITOR
            DestroyImmediate(layers[value].GetChild(0).gameObject);
#else
                Destroy(layers[value].GetChild(0).gameObject);
#endif
        }

        private void UnSubscribeEvents()
        {
            CoreUISignals.Instance.onClosepanel -= OnClosePanel;
            CoreUISignals.Instance.onOpenpanel -= OnOpenPanel;
            CoreUISignals.Instance.onCloseAllPanel -= OnCloseAllPanels;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
}