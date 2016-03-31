using UnityEngine;
using System.Collections;

public class GameManager_Master : MonoBehaviour {

    public delegate void GAmeManagerEventHandler();
    public event GAmeManagerEventHandler MenueToggelEvent;
    public event GAmeManagerEventHandler RestartLevelEvent;
    public event GAmeManagerEventHandler GoToMenuScreenEvent;
    public event GAmeManagerEventHandler playerdied;
    public event GAmeManagerEventHandler GameOverEvent;
    public bool isGameOver;
    public bool isMenueOn;

    public void CAllEventMenueToggel() {
        if (MenueToggelEvent != null) {
            MenueToggelEvent();
        }
    }
 
    public void CAllRestartLevel()
    {
        if (RestartLevelEvent != null)
        {
            RestartLevelEvent();
        }
    }
    public void CAllGoToMenuScreenEvent()
    {
        if (GoToMenuScreenEvent != null)
        {
            GoToMenuScreenEvent();
        }
    }


    public void CAllplayerdied()
    {
        if (playerdied != null)
        {
            playerdied();
        }
    }

    public void CAllGameOverEvent()
    {
        if (GameOverEvent != null)
        {
            GameOverEvent();
        }
    }

}
