using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectBetelgeuse.GameState
{
    public class BetelgeuseStateMachine
    {
        public delegate void OnStateSwitch(BetelgeuseState nextState);
        public event OnStateSwitch OnStatePreSwitchEvent = null;

        private Dictionary<BetelgeuseState, BetelgeuseState_Base<BetelgeuseState>> states = new Dictionary<BetelgeuseState, BetelgeuseState_Base<BetelgeuseState>>();
        private BetelgeuseState_Base<BetelgeuseState> currentState = null;
        private List<BetelgeuseState> prevGameState;

        public BetelgeuseStateMachine(GameManager manager)
        {
            states = new Dictionary<BetelgeuseState, BetelgeuseState_Base<BetelgeuseState>>();

            Betelgeuse_Loading loading = new Betelgeuse_Loading(manager);
            Betelgeuse_InGame inGame = new Betelgeuse_InGame(manager);
            Betelgeuse_Exit exit = new Betelgeuse_Exit(manager);

            states.Add(loading.State, (BetelgeuseState_Base<BetelgeuseState>)loading);
            states.Add(inGame.State, (BetelgeuseState_Base<BetelgeuseState>)inGame);
            states.Add(exit.State, (BetelgeuseState_Base<BetelgeuseState>)exit);

            currentState = loading;
            currentState.Start();

            prevGameState = new List<BetelgeuseState>();
            prevGameState.Add(currentState.State);
        }

        public void Update()
        {
            if (currentState != null)
                currentState.Update();
        }

        public void TimerUpdate()
        {
            if (currentState != null)
                currentState.TimerUpdate();
        }

        public void Destroy()
        {
            if (states != null)
            {
                foreach (BetelgeuseState key in states.Keys)
                {
                    states[key].Destroy();
                }
                states.Clear();
                states = null;
            }
        }

        public BetelgeuseState_Base<BetelgeuseState> GetCurrentState
        {
            get { return currentState; }
        }

        public string GetPreviousStateList()
        {
            string prevStates = "PREVIOUS STATES: ";

#if UNITY_EDITOR
            if (prevGameState != null)
            {
                for (int i = prevGameState.Count - 1; i >= 0; i--)
                {
                    prevStates += "\n-> " + prevGameState[i].ToString();
                }
            }
#endif

            return prevStates;
        }


        public bool SwitchState(BetelgeuseState newState)
        {
            bool switchSuccess = false;
            Debug.Log("Switch state to " + newState);
            if (states != null && states.ContainsKey(newState))
            {
                if (currentState == null)
                {
                    currentState = states[newState];
                    currentState.Start();
                    switchSuccess = true;
                }
                else if (currentState.AllowTransition(newState))
                {
                    currentState.End();
                    currentState = states[newState];
                    currentState.Start();
                    switchSuccess = true;
                }
                else
                {
                    Debug.Log(string.Format("{0} does not allow transition to {1}", currentState.State, newState));
                }
            }

            if (switchSuccess)
            {
                // Updating state history
#if UNITY_EDITOR
                if (prevGameState != null)
                {
                    prevGameState.Add(newState);
                    if (prevGameState.Count > 20)
                    {
                        prevGameState.RemoveAt(0);
                    }
                }
#endif

                if (this.OnStatePreSwitchEvent != null)
                {
                    this.OnStatePreSwitchEvent(newState);
                }
            }
            else
            {
                Debug.Log("States dictionary not ready for switching to " + newState);
            }

            return switchSuccess;
        }
    }
}
