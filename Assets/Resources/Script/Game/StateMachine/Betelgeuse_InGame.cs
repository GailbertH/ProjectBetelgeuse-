using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectBetelgeuse.GameState
{
    public class Betelgeuse_InGame : BetelgeuseState_Base<BetelgeuseState>
    {
        private Dictionary<GameplayState, GameplayState_Base<GameplayState>> states = new Dictionary<GameplayState, GameplayState_Base<GameplayState>>();
        private GameplayState_Base<GameplayState> currentState = null;

        public Betelgeuse_InGame(GameManager manager) : base(BetelgeuseState.INGAME, manager)
        {
            states = new Dictionary<GameplayState, GameplayState_Base<GameplayState>>();

            Gameplay_Idle idle = new Gameplay_Idle(Manager, this);
            Gameplay_ClassEvent classEvent = new Gameplay_ClassEvent(Manager, this);
            Gameplay_SpecialEvent specialEvent = new Gameplay_SpecialEvent(Manager, this);
            Gameplay_Quiz quiz = new Gameplay_Quiz(Manager, this);
            Gameplay_Result result = new Gameplay_Result(Manager, this);
            Gameplay_Exit exit = new Gameplay_Exit(Manager, this);

            states.Add(idle.State, (GameplayState_Base<GameplayState>)idle);
            states.Add(classEvent.State, (GameplayState_Base<GameplayState>)classEvent);
            states.Add(specialEvent.State, (GameplayState_Base<GameplayState>)specialEvent);
            states.Add(quiz.State, (GameplayState_Base<GameplayState>)quiz);
            states.Add(result.State, (GameplayState_Base<GameplayState>)result);
            states.Add(exit.State, (GameplayState_Base<GameplayState>)exit);

            currentState = idle;
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update() { base.Update(); }

        public override void TimerUpdate()
        {
            currentState.GameTimerUpdate();
        }

        public override void End() { base.End(); }

        public override void Destroy()
        {
            End();
            base.Destroy();
        }

        public override void GoToNextState() { base.GoToNextState(); }

        public override bool AllowTransition(BetelgeuseState nextState)
        {
            return (nextState == BetelgeuseState.EXIT);
        }
    }
}
