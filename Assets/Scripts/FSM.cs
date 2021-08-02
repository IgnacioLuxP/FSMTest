using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    public PlayerState CurrentState { get; private set; }

    public void Initialize(PlayerState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        CurrentState.Exit();
        //Debug.Log("Exited: " + Time.time);
        CurrentState = newState;
        CurrentState.Enter();
        //Debug.Log("Entered: " + Time.time);
    }

}
