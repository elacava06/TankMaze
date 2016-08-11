using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

    public enum gameState {lobby,play };
    public gameState currentGameState = gameState.lobby;
    //public bool allowedToSwitchDuringGamePlay;

    void Start()
    {
        //if (GameControl.control != null)
        //{
        //    if (GameControl.control.getUseGameControl())
        //    {
        //        Debug.Log("this happened");
        //        setAllowedToChange(GameControl.control.getAllowedToChange());
        //    }
        //}
    }

    public void setGameStateToPlay()
    {
        currentGameState = gameState.play;
    }

    public void setGameStateToLobby()
    {
        currentGameState = gameState.lobby;
    }

    //public void setAllowedToChange(bool value)
    //{
    //    allowedToSwitchDuringGamePlay = value;
    //}
}
