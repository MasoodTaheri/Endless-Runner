using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameController : MonoBehaviour
{
    private EndGameModel _endGameModel;
    [SerializeField] private EndGameView _view;
    public void Initialize(EndGameModel endGameModel)
    {
        _endGameModel = endGameModel;
        gameObject.SetActive(true);
        _view.Initialize(_endGameModel);
        _view.UpdateUI(_endGameModel);
    }

}