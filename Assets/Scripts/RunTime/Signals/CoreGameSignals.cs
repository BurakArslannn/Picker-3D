using System;
using RunTime.Extentions;
using UnityEngine.Events;

namespace RunTime.Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction<byte> onLevelInitialize = delegate { };
        public UnityAction onClearActiveLevel = delegate { };
        public UnityAction onLevelSuccessful = delegate { };
        public UnityAction onLevelFailed = delegate { };
        public UnityAction onNextlevel = delegate { };
        public UnityAction onRestartLevel = delegate { };
        public UnityAction onReset = delegate { };

        //Func can send and return parameter
        public Func<byte> onGetLevelValue = delegate { return 0; };
        public UnityAction onStageAreaEntered = delegate { };
        public UnityAction<byte> onStageAreaSuccesful = delegate { };
        public UnityAction onFinishAreaEntered = delegate { };
    }
}