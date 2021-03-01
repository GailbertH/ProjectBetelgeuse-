using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectBetelgeuse.GameState
{
    public class Betelgeuse_InGame : BetelgeuseState_Base<BetelgeuseState>
    {
        private int studyPoints = 0;
        public Betelgeuse_InGame(GameManager manager) : base(BetelgeuseState.INGAME, manager)
        {
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update() { base.Update(); }

        public override void TimerUpdate()
        {
            studyPoints += Manager.DeskHandler.StudentStudyActivity();
            if (studyPoints > 100)
            {
                studyPoints -= 100;
            }
            Manager.GameManagerUI.MeterHandler.UpdateMeter(studyPoints);
            //Debug.Log("Study Points : " + studyPoints);
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
