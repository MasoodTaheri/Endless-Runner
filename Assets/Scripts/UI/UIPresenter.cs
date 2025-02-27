using UI.EndGame;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIPresenter : MonoBehaviour
    {
        private UIModel _uiModel;
        [SerializeField] private UIView _uiView;
        [SerializeField] private EndGameController _endGameController;
        private GameEventManager _gameEventManager;


        public void Initialize(GameEventManager gameEventManager)
        {
            _uiModel = new UIModel();
            _uiView.UpdateUI(_uiModel);
            _gameEventManager = gameEventManager;

            _gameEventManager.OnScoreUpdated.AddListener(UpdateCoin);
            _gameEventManager.OnStarUpdated.AddListener(UpdateStar);
            _gameEventManager.OnGameFinished.AddListener(ShowEndGamePanel);
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

        public void ShowEndGamePanel()
        {
            var endgameModel = new EndGameModel()
            {
                score = _uiModel.Score,
                Restart = () => { SceneManager.LoadScene(0); }
            };
            _endGameController.Initialize(endgameModel);
        }
    }
}