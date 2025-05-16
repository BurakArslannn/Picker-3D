using System.Collections.Generic;
using RunTime.Enums;
using RunTime.Signals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RunTime.Controllers.UI
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
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreUISignals.Instance.onClosepanel += OnClosePanel;
            CoreUISignals.Instance.onOpenpanel += OnOpenPanel;
            CoreUISignals.Instance.onCloseAllPanel += OnCloseAllPanel;
        }

        [NaughtyAttributes.Button("Close All Panel")]
        private void OnCloseAllPanel()
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
        private void OnOpenPanel(UIPanelTypes panelTypes, int value)
        {
            OnClosePanel(value);
            Instantiate(Resources.Load<GameObject>($"Screens/{panelTypes}Panel"), layers[value]);
        }

        [Button("Close Panel")]
        private void OnClosePanel(int value)
        {
            if (layers[value].childCount <= 0) return;
            {
#if UNITY_EDITOR
                DestroyImmediate(layers[value].GetChild(0).gameObject);
#else
            Destroy(layers[value].GetChild(0).gameObject);
#endif
            }
        }


        private void UnSubscribeEvents()
        {
            CoreUISignals.Instance.onClosepanel -= OnClosePanel;
            CoreUISignals.Instance.onOpenpanel -= OnOpenPanel;
            CoreUISignals.Instance.onCloseAllPanel -= OnCloseAllPanel;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
}