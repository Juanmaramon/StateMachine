using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XRS
{
    public class StateMachine : MonoBehaviour
    {
        public const string ON_LOAD_STATES = "OnLoadStates";
        bool DEBUG = true;

        public Bindings bindings;

        public List<GameState> states;
        public int currentStateIdx = 0;

        [HideInInspector] public GameState currentState;

        void OnEnable()
        {
            EventManager.StartListening<BasicEvent>(ON_LOAD_STATES, OnLoadStates);
        }

        void OnDisable()
        {
            EventManager.StopListening<BasicEvent>(ON_LOAD_STATES, OnLoadStates);
        }

        void Start()
        {
            if (states.Count > 0)
                currentState = states[0];
        }

        void Update()
        {
            if (states.Count > 0)
                currentState.UpdateState();
        }

        void OnLoadStates(BasicEvent e)
        {
            states = (List<GameState>)e.Data;
        }

        public void GetNextState()
        {
            currentState = states[++currentStateIdx];
            if (DEBUG)
            {
                Debug.Log("[StateMachine] Transitioning to state " + currentStateIdx);
            }
        }

        public void GetNextState(int stateIdx)
        {
            currentStateIdx = stateIdx;
            currentState = states[stateIdx];
            if (DEBUG)
            {
                Debug.Log("[StateMachine] Transitioning to state " + currentStateIdx);
            }
        }
    }
}