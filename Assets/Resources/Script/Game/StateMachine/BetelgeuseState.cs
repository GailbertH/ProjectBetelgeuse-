using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectBetelgeuse.GameState
{
    public enum BetelgeuseState
    {
        LOADING = 0,
        INGAME = 1,
        EXIT = 2
    }

    public class BetelgeuseState_Base<BetelgeuseState>
    {
        private BetelgeuseState state;
        private GameManager manager;

        public BetelgeuseState State { get { return state; } }
        public GameManager Manager { get { return manager; } }

        public BetelgeuseState_Base(BetelgeuseState state, GameManager manager)
        {
            this.state = state;
            this.manager = manager;
        }

        public virtual void Start()
        {
            Debug.Log("Current State " + this.State.ToString());
        }

        public virtual void Update() { }

        public virtual void TimerUpdate() { }

        public virtual void End() { }

        public virtual void Destroy()
        {
            End();
            manager = null;
        }

        public virtual void GoToNextState() { }

        public virtual bool AllowTransition(BetelgeuseState nextState)
        {
            return true;
        }

    }
}
