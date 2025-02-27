using UnityEngine;

namespace UI.EndGame
{
    public class EndGameController : MonoBehaviour
    {
        [SerializeField] private EndGameView _view;
        private EndGameModel _endGameModel;
        public void Initialize(EndGameModel endGameModel)
        {
            _endGameModel = endGameModel;
            gameObject.SetActive(true);
            _view.Initialize(_endGameModel);
            _view.UpdateUI(_endGameModel);
        }

    }
}