using ProjectBetelgeuse.GameState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameplayState
{
    IDLE = 0,
    CLASS_EVENT = 1,
    SPECIAL_EVENT = 2,
    QUIZ = 3,
    RESULT = 4,
    EXIT = 5
}
public class GameplayState_Base<GameplayState>
{
    private GameplayState state;
    private GameManager manager;
    public Betelgeuse_InGame handler;

    public GameplayState State { get { return state; } }
    public GameManager Manager { get { return manager; } }
    public Betelgeuse_InGame Handler { get { return handler; } }

    public GameplayState_Base(GameplayState state, GameManager manager, Betelgeuse_InGame handler)
    {
        this.state = state;
        this.manager = manager;
        this.handler = handler;
    }

    public virtual bool GameAllowTransition(GameplayState nextState)
    {
        return true;
    }

    public virtual void GameGoToNextState() { }

    public virtual void GameStart()
    {
        Debug.Log(this.state.ToString());
    }

    public virtual void GameUpdate() { }

    public virtual void GameTimerUpdate()
    {
        int studyPoints = Manager.DeskHandler.StudentStudyActivity();
        Manager.GameManagerUI.MeterHandler.UpdateMeter(studyPoints);
    }

    public virtual void GameEnd() { }

    public virtual void GameDestroy()
    {
        state = default;
        manager = null;
        handler = null;
    }
}

public class Gameplay_Idle : GameplayState_Base<GameplayState>
{

    public Gameplay_Idle(GameManager manager, Betelgeuse_InGame handler) : base (GameplayState.IDLE, manager, handler)
    {

    }

    public override bool GameAllowTransition(GameplayState nextState)
    {
        return true;
    }

    public override void GameGoToNextState() { }

    public override void GameStart()
    {
        base.GameStart();
    }

    public override void GameUpdate() { }

    public override void GameTimerUpdate()
    {
        base.GameTimerUpdate();
    }

    public override void GameEnd() { }

    public override void GameDestroy()
    {
        base.GameDestroy();
    }
}

public class Gameplay_ClassEvent : GameplayState_Base<GameplayState>
{

    public Gameplay_ClassEvent(GameManager manager, Betelgeuse_InGame handler) : base(GameplayState.CLASS_EVENT, manager, handler)
    {

    }

    public override bool GameAllowTransition(GameplayState nextState)
    {
        return true;
    }

    public override void GameGoToNextState() { }

    public override void GameStart()
    {
        base.GameStart();
    }

    public override void GameUpdate() { }

    public override void GameTimerUpdate()
    {
        base.GameTimerUpdate();
    }

    public override void GameEnd() { }

    public override void GameDestroy()
    {
        base.GameDestroy();
    }
}

public class Gameplay_SpecialEvent : GameplayState_Base<GameplayState>
{

    public Gameplay_SpecialEvent(GameManager manager, Betelgeuse_InGame handler) : base(GameplayState.SPECIAL_EVENT, manager, handler)
    {

    }

    public override bool GameAllowTransition(GameplayState nextState)
    {
        return true;
    }

    public override void GameGoToNextState() { }

    public override void GameStart()
    {
        base.GameStart();
    }

    public override void GameUpdate() { }

    public override void GameTimerUpdate() { }

    public override void GameEnd() { }

    public override void GameDestroy()
    {
        base.GameDestroy();
    }
}

public class Gameplay_Quiz : GameplayState_Base<GameplayState>
{

    public Gameplay_Quiz(GameManager manager, Betelgeuse_InGame handler) : base(GameplayState.QUIZ, manager, handler)
    {

    }

    public override bool GameAllowTransition(GameplayState nextState)
    {
        return true;
    }

    public override void GameGoToNextState() { }

    public override void GameStart()
    {
        base.GameStart();
    }

    public override void GameUpdate() { }

    public override void GameTimerUpdate() { }

    public override void GameEnd() { }

    public override void GameDestroy()
    {
        base.GameDestroy();
    }
}

public class Gameplay_Result : GameplayState_Base<GameplayState>
{

    public Gameplay_Result(GameManager manager, Betelgeuse_InGame handler) : base(GameplayState.RESULT, manager, handler)
    {

    }

    public override bool GameAllowTransition(GameplayState nextState)
    {
        return true;
    }

    public override void GameGoToNextState() { }

    public override void GameStart()
    {
        base.GameStart();
    }

    public override void GameUpdate() { }

    public override void GameTimerUpdate() { }

    public override void GameEnd() { }

    public override void GameDestroy()
    {
        base.GameDestroy();
    }
}

public class Gameplay_Exit : GameplayState_Base<GameplayState>
{
    public Gameplay_Exit(GameManager manager, Betelgeuse_InGame handler) : base(GameplayState.EXIT, manager, handler)
    {

    }

    public override bool GameAllowTransition(GameplayState nextState)
    {
        return true;
    }

    public override void GameGoToNextState() { }

    public override void GameStart()
    {
        base.GameStart();
    }

    public override void GameUpdate() { }

    public override void GameTimerUpdate() { }

    public override void GameEnd() { }

    public override void GameDestroy()
    {
        base.GameDestroy();
    }
}