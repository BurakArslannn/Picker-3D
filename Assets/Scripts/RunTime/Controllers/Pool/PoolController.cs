using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace RunTime.Controllers.Pool
{
    public class PoolController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<DOTweenAnimation> tweens = new List<DOTweenAnimation>();

        #endregion

        #endregion
    }
}