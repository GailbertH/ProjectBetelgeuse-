﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public void SetupGameScene()
    {
        if (LoadingManager.Instance != null)
        {
            LoadingManager.Instance.SetSceneToUnload(SceneNames.LOBBY_SCENE);
            LoadingManager.Instance.SetSceneToLoad(SceneNames.GAME_UI + "," + SceneNames.GAME_SCENE);
            LoadingManager.Instance.LoadGameScene();
        }
        else
        {
            Debug.LogError("Loading Manager is missing");
        }
    }
}
