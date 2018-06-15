using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XRS;

public class IdleState : GameState {
    private readonly StateMachine gamePlay;
    private bool enabled = true;

    public IdleState(StateMachine stateMachine)
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
        gamePlay.bindings.ball.GetComponent<Rigidbody>().useGravity = true;
        CoroutineHandler.instance.StartCoroutine(ToPauseState());
    }

    IEnumerator ToPauseState()
    {
        yield return new WaitForSeconds(2f);
        gamePlay.GetNextState();
    }
 }
