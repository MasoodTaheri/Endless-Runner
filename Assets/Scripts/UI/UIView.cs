using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIView : MonoBehaviour
{
    [SerializeField] private TMP_Text _startCount;
    [SerializeField] private TMP_Text _coinCount;
    [SerializeField] private TMP_Text _Score;
    [SerializeField] private int _scoreValue;
    // [SerializeField] private int _coinValue;
    // [SerializeField] private int _starValue;

    [SerializeField] private float scoreChangeDuration = 0.5f; // Duration of the animation
    [SerializeField] private float scaleEffectStrength = 1.2f; // Scale effect multiplier
    [SerializeField] private float scaleEffectDuration = 0.2f; // Duration of the scale effect

    public void UpdateUI(UIModel uiModel)
    {
        _startCount.text = uiModel.StarCount.ToString();
        _coinCount.text = uiModel.coinCount.ToString();

        DOTween.To(
            () => _scoreValue, // Start value
            x =>
            {
                _scoreValue = x;
                _Score.text = $"Score: {_scoreValue}"; // Update the text
            },
            uiModel.score, // End value
            scoreChangeDuration // Duration
        ).OnComplete(() =>
        {
            // Add a scale effect when the animation completes
            _Score.transform.DOScale(scaleEffectStrength, scaleEffectDuration)
                .SetEase(Ease.OutBack)
                .OnComplete(() => _Score.transform.DOScale(1f, scaleEffectDuration));
        });
    }
}