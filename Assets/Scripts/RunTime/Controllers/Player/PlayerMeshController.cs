using DG.Tweening;
using RunTime.Data.ValueObjects;
using Runtime.Managers;
using RunTime.Managers;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace RunTime.Controllers.Player
{
    public class PlayerMeshController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerManager manager;
        [SerializeField] private new Renderer renderer;
        [SerializeField] private TextMeshPro scaleText;
        [SerializeField] private ParticleSystem confettiParticle;

        #endregion

        #region Private Variables

        [ShowInInspector] private PlayerData.PlayerMeshData _data;
        [ShowInInspector] private PoolData _poolData;

        #endregion

        #endregion

        private void Awake()
        {
            scaleText.gameObject.SetActive(false);
        }

        internal void SetData(PlayerData.PlayerMeshData scaleData)
        {
            _data = scaleData;
        }

        internal void ScaleUpPlayer()
        {
            renderer.gameObject.transform.DOScaleX(_data.ScaleCounter, 1).SetEase(Ease.Flash);
        }

        internal void ShowUpText()
        {
            scaleText.gameObject.SetActive(true);
            scaleText.DOFade(1, 0f).SetEase(Ease.Flash).OnComplete(() => scaleText.DOFade(0, 0).SetDelay(.65f));
            scaleText.rectTransform.DOAnchorPosY(.85f, .65f).SetRelative(true).SetEase(Ease.OutBounce).OnComplete(() =>
                scaleText.rectTransform.DOAnchorPosY(-.85f, .65f).SetRelative(true));
        }

        internal void PlayConfetiParticle()
        {
            confettiParticle.Play();
        }

        internal void OnReset()
        {
            renderer.gameObject.transform.DOScaleX(1, 1).SetEase(Ease.Linear);
        }
    }
}