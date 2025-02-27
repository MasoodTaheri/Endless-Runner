using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _startCount;
        [SerializeField] private TMP_Text _coinCount;
        [SerializeField] private TMP_Text _Score;
        [SerializeField] private int _scoreValue;


        [SerializeField] private float scoreChangeDuration = 0.5f;
        [SerializeField] private float scaleEffectStrength = 1.2f;
        [SerializeField] private float scaleEffectDuration = 0.2f;

        public void UpdateUI(UIModel uiModel)
        {
            _startCount.text = uiModel.StarCount.ToString();
            _coinCount.text = uiModel.CoinCount.ToString();

            DOTween.To(
                () => _scoreValue,
                x =>
                {
                    _scoreValue = x;
                    _Score.text = $"Score: {_scoreValue}";
                },
                uiModel.Score,
                scoreChangeDuration
            ).OnComplete(() =>
            {
                _Score.transform.DOScale(scaleEffectStrength, scaleEffectDuration)
                    .SetEase(Ease.OutBack)
                    .OnComplete(() => _Score.transform.DOScale(1f, scaleEffectDuration));
            });
        }
    }
}