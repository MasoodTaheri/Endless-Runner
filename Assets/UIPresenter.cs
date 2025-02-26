using UnityEngine;

public class UIPresenter: MonoBehaviour
{
    private UIModel _uiModel;
    [SerializeField] private UIView _uiView;
    private GameEventManager _gameEventManager;


    public void Initialize(GameEventManager gameEventManager)
    {
        _uiModel = new UIModel();
        _uiView.UpdateUI(_uiModel);
        this._gameEventManager = gameEventManager;
        
        gameEventManager.OnScoreUpdated.AddListener(UpdateCoin);
        gameEventManager.OnStarUpdated.AddListener(UpdateStar);
    }

    private void UpdateStar(int arg0)
    {
        _uiModel.AddStar(arg0);
        _uiView.UpdateUI(_uiModel);
    }

    private void UpdateCoin(int arg0)
    {
        _uiModel.AddCoin(arg0);
        _uiView.UpdateUI(_uiModel);
    }
}