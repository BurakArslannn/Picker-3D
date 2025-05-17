using RunTime.Data.ValueObjects;
using RunTime.Managers;

namespace RunTime.Commands.Player
{
    public class ForceBallsToPoolCommand
    {
        private PlayerManager _manager;
        private PlayerData.PlayerForceData _forceData;

        public ForceBallsToPoolCommand(PlayerManager manager, PlayerData.PlayerForceData forceData)
        {
            _manager = manager;
            _forceData = forceData;
        }

        internal void Execute()
        {
            
        }
    }
}