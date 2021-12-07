using ProjectBetelgeuse.GameState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGamePaused = false;
    private bool isStateActive = false;
    private Coroutine updateRoutine = null;
    private Coroutine timeTrackerRoutine = null;

    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }

    private BetelgeuseStateMachine stateMachine = null;
    public BetelgeuseStateMachine StateMachine { get { return this.stateMachine; } }

    [SerializeField] private DeskHandler deskHandler;
    [SerializeField] private int frameRate = 60;
    
    public DeskHandler DeskHandler { get { return deskHandler; } }

    public GameManagerUI GameManagerUI { get { return GameManagerUI.Instance; } }

    #region Monobehavior Function
    void Awake()
    {
        Application.targetFrameRate = frameRate;
        instance = this;
    }

    void Start()
    {
        stateMachine = new BetelgeuseStateMachine(this);
        isStateActive = true;
        updateRoutine = StartCoroutine(ControlledUpdate());
        timeTrackerRoutine = StartCoroutine(TimeTracker());
    }
    #endregion

    public void PauseGame(bool isPause)
    {
        isGamePaused = isPause;
    }

    public void ExitingGame()
    {
        isStateActive = false;
        instance = null;
        if (stateMachine != null)
        {
            stateMachine.Destroy();
            stateMachine = null;
        }
        if (updateRoutine != null)
        {
            StopCoroutine(updateRoutine);
        }
    }

    private IEnumerator ControlledUpdate()
    {
        while (isStateActive)
        {
            yield return new WaitForEndOfFrame();
            if (isGamePaused == false)
            {
                stateMachine.Update();
                GameManagerUI.Instance.ControlledUpdate();
            }
        }
    }

    private IEnumerator TimeTracker()
    {
        while (isStateActive)
        {
            yield return new WaitForSeconds(1);
            if (isGamePaused == false)
            {
                stateMachine.TimerUpdate();
                GameManagerUI.Instance.ControlledTimerUpdate();
            }
        }
    }
}
