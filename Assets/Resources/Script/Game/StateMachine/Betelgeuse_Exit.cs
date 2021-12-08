using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectBetelgeuse.GameState
{
    public class Betelgeuse_Exit : BetelgeuseState_Base<BetelgeuseState>
    {
        public Betelgeuse_Exit(GameManager manager) : base(BetelgeuseState.EXIT, manager)
        {
        }

        public override void Start()
        {
            base.Start();
            //START UNLOADING
            if (LoadingManager.Instance != null)
            {
                LoadingManager.Instance.SetSceneToUnload(SceneNames.GAME_UI + "," + SceneNames.GAME_SCENE);
                LoadingManager.Instance.SetSceneToLoad(SceneNames.LOBBY_SCENE);
                LoadingManager.Instance.LoadGameScene();
            }
        }
        public override void End()
        {
            Manager.ExitingGame();
        }
    }
}
