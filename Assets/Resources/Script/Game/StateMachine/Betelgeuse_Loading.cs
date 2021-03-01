using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectBetelgeuse.GameState
{
    public class Betelgeuse_Loading : BetelgeuseState_Base<BetelgeuseState>
    {
        private Coroutine cdNextState;

        public Betelgeuse_Loading(GameManager manager) : base(BetelgeuseState.LOADING, manager)
        {
        }

        public override void GoToNextState()
        {
            Manager.StateMachine.SwitchState(BetelgeuseState.INGAME);
        }

        public override bool AllowTransition(BetelgeuseState nextState)
        {
            return (nextState == BetelgeuseState.INGAME);
        }

        public override void Start()
        {
            base.Start();
            cdNextState = Manager.StartCoroutine(DelayedStateSwitch(2f));
        }

        public override void End()
        {
            if (cdNextState != null && Manager != null)
                Manager.StopCoroutine(cdNextState);

            LoadingManager.Instance?.LoadFinish();
            cdNextState = null;
        }

        public override void Destroy()
        {
            End();
            base.Destroy();
        }

        private IEnumerator DelayedStateSwitch(float delay)
        {
            yield return new WaitForSeconds(delay);
            GoToNextState();
        }
    }
}
