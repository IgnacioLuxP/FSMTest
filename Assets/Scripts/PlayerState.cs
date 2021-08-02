using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{

    protected FSM stateMachine;
    protected Player player;

    protected bool isAnimationFinished;
    protected bool isExitingState;

    private string animBoolName;

    public PlayerState(Player player, FSM stateMachine, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }


    public virtual void Enter()
    {
        DoChecks();
        player.anim.SetBool(animBoolName, true);
        Debug.Log("Entered " + animBoolName + " at " + Time.time);
        isAnimationFinished = false;
        isExitingState = false;
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
        isExitingState = true;
        Debug.Log("Exited " + animBoolName + " at " + Time.time);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks() { }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger()
    {
        isAnimationFinished = true;
        Debug.Log("Base AnimationFinishTrigger set TRUE at " + Time.time);
    }
}
