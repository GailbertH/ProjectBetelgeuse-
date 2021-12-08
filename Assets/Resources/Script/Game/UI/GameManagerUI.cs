using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerUI : MonoBehaviour
{
    private static GameManagerUI instance = null;
    public static GameManagerUI Instance { get { return instance; } }

    [SerializeField] private MeterHandlerUI meterHandler;
    public MeterHandlerUI MeterHandler { get { return meterHandler; } }

    void Awake()
    {
        instance = this;
    }

    //For Pausable UIs
    public void ControlledUpdate()
    {
        meterHandler.ControlledUpdate();
    }

    //For Pausable UIs
    public void ControlledTimerUpdate()
    {

    }
}
