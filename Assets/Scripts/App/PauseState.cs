using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XRS;

public class PauseState : GameState {
    private readonly StateMachine gamePlay;
    private bool enabled = true;

    public PauseState(StateMachine stateMachine)
    {
        gamePlay = stateMachine;
    }

    public override void UpdateState()
    {
        if (enabled)
        {
            EnableState();
        }
    }

    public override void EnableState()
    {
        enabled = false;
        Time.timeScale = 0f;
    }
}
