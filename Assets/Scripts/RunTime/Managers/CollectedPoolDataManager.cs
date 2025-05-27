using RunTime.Signals;
using UnityEngine;

namespace RunTime.Managers
{
    public class CollectedPoolDataManager : MonoBehaviour
    {
        public static CollectedPoolDataManager Instance;

        private int _totalCollected;

        public int TotalCollected => _totalCollected;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        public void AddCollected(byte amount)
        {
            _totalCollected += amount;
            UISignals.Instance.onSetScore?.Invoke(amount);

        }

        public void ResetCollected()
        {
            _totalCollected = 0;
        }
    }
}