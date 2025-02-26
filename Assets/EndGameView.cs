using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameView : MonoBehaviour
{
    [SerializeField] private TMP_Text _Score;
    [SerializeField] private Button _restartButton;
    [SerializeField] private int _scoreValue;

    [SerializeField] private float scoreChangeDuration = 0.5f; // Duration of the animation
    [SerializeField] private float scaleEffectStrength = 1.2f; // Scale effect multiplier
    [SerializeField] private float scaleEffectDuration = 0.2f; // Duration of the scale effect

    public void Initialize(EndGameModel endGameModel)
    {
        
        _restartButton.gameObject.SetActive(false);
        _restartButton.onClick.RemoveAllListeners();   
        _restartButton.onClick.AddListener(endGameModel.Restart.Invoke);   
    }
    
    public void UpdateUI(EndGameModel endGameModel)
    {
        DOTween.To(
            () => _scoreValue, // Start value
            x =>
            {
                _scoreValue = x;
                _Score.text = $"Score: {_scoreValue}"; // Update the text
            },
            endGameModel.score, // End value
            scoreChangeDuration // Duration
        ).OnComplete(() =>
        {
            // Add a scale effect when the animation completes
            _Score.transform.DOScale(scaleEffectStrength, scaleEffectDuration)
                .SetEase(Ease.OutBack)
                .OnComplete(() =>
                {
                    _Score.transform.DOScale(1f, scaleEffectDuration);
                    _restartButton.gameObject.SetActive(true);
                });
        });
    }
}