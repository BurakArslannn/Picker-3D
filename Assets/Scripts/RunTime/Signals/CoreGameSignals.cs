using System;
using RunTime.Enums;
using RunTime.Extentions;
using UnityEngine.Events;

namespace RunTime.Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction<GameStates> onChangeGameState = delegate { };

        public UnityAction<byte> onLevelInitialize = delegate { };
        public UnityAction onClearActiveLevel = delegate { };
        public UnityAction onLevelSuccessful = delegate { };
        public UnityAction onLevelFailed = delegate { };
        public UnityAction onNextLevel = delegate { };
        public UnityAction onRestartLevel = delegate { };
        public UnityAction onReset = delegate { };

        //Func can send and return parameter
        public Func<byte> onGetLevelValue = delegate { return 0; };
        public UnityAction onStageAreaEntered = delegate { };
        public UnityAction<byte> onStageAreaSuccessful = delegate { };
        public UnityAction onFinishAreaEntered = delegate { };
    }
}