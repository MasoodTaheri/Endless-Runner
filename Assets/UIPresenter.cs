using UnityEngine;

public class UIPresenter: MonoBehaviour
{
    private UIModel _uiModel;
    [SerializeField] private UIView _uiView;
    private GameEventManager _gameEventManager;
    public int coinCount;
    public int StarCount;

    public void Initialize(GameEventManager gameEventManager)
    {
        _uiModel = new UIModel();
        _uiView.UpdateUI(_uiModel);
        this._gameEventManager = gameEventManager;
        
        gameEventManager.OnScoreUpdated.AddListener(UpdateScore);
        gameEventManager.OnStarUpdated.AddListener(UpdateStar);
    }

    private void UpdateStar(int arg0)
    {
        StarCount = arg0;
    }

    private void UpdateScore(int arg0)
    {
        coinCount = arg0;
    }
}