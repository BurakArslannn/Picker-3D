using RunTime.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace RunTime.Signals
{
    public class CoreUISignals : MonoBehaviour
    {
        #region Singleton

        public static CoreUISignals Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        #endregion

        public UnityAction<UIPanelTypes, int> onOpenpanel = delegate { };
        public UnityAction<int> onClosepanel = delegate { };
        public UnityAction onCloseAllPanel = delegate { };
    }
}