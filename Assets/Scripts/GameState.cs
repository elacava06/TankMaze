using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

    public enum gameState {lobby,play };
    public gameState currentGameState = gameState.lobby;
    public bool allowedToSwitchDuringGamePlay=false;

    public void setGameStateToPlay()
    {
        currentGameState = gameState.play;
    }
    public void setGameStateToLobby()
    {
        currentGameState = gameState.lobby;
    }
    void Start()
    {
        if (GameControl.control != null)
        {
            if (GameControl.control.getUseGameControl())
            {
                setAllowedToChange(GameControl.control.getAllowedToChange());
            }
        }
    }
    void setAllowedToChange(bool value)
    {
        allowedToSwitchDuringGamePlay = value;
    }
}
