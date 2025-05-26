using RunTime.Controllers.Player;
using UnityEngine;

namespace RunTime.Controllers.MiniGame
{
    public class MiniGameController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized  Variables

        [SerializeField] private PlayerMovementController movementController;

        #endregion

        #endregion

        internal void SpeedUpPicker()
        {
            movementController.MultiplyForwardSpeed(3f);
            Debug.LogWarning("speed up");
        }
    }
}