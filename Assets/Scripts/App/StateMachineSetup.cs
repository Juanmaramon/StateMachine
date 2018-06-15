using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XRS;

public class StateMachineSetup : MonoBehaviour {
    StateMachine stateMachine;

    void Start () {
        stateMachine = GetComponent<StateMachine>();

        List<GameState> states = new List<GameState>();

        IdleState idleState = new IdleState(stateMachine);
        PauseState pauseState = new PauseState(stateMachine);

        states.Add(idleState);
        states.Add(pauseState);

        EventManager.TriggerEvent(StateMachine.ON_LOAD_STATES, new BasicEvent(states));
	}
}