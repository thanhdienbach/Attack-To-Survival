using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameState
{
    public virtual void Enter()
    {
        Debug.Log("Enter base state");
    }
    public virtual void Update()
    {
        Debug.Log("Update base state");
    }
    public virtual void Exit()
    {
        Debug.Log("Exit base state");
    }
}

public class SpawnPlayerState : GameState
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Spawn player state enter");
    }
    public override void Update()
    {
        base.Update();
        Debug.Log("Spawn player state update");
    }
    public override void Exit()
    {
        base.Exit();
        Debug.Log("Spawn player state exit");
    }
}
public class PlayingState : GameState
{
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Playing state enter");
    }
    public override void Update()
    {
        base.Update();
        Debug.Log("Playing state update");
    }
    public override void Exit()
    {
        base.Exit();
        Debug.Log("Playing state exit");
    }
}
