using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    //Enable or Disable TimeBasedTransition Flag in the Inspector (Player object)
    //1) timeBasedTransition = true: Exit Transition based on AnimationState's normalized time
    //2) timeBasedTransition = false: Uses AnimationEvent to determine if the animation has finished playing and exits.

    int framecount;
    float stateExitDifference; //Saves Time.time when the Animation is finished (either Time-Based or via AnimationFinishedTrigger function).
    public PlayerAttackState(Player player, FSM stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        framecount = 0;
        player.anim.Play("Attack");
        stateExitDifference = 0;
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Delay between Animation's end and State's exit time: " + (Time.time - stateExitDifference));
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        //Debug.Log(framecount++);

        if (player.timeBasedTransition)
        {
            //Debug.Log("Anim time " + player.anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            if (player.anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                Debug.Log("Attack State (Time-Based) Finished at " + Time.time);
                stateExitDifference = Time.time;
                player.StateMachine.ChangeState(player.IdleState);
            }
        }
        else
        {
            if (isAnimationFinished)
            {
                Debug.Log("Attack State (w/Animation Events) Finished at " + Time.time);
                player.StateMachine.ChangeState(player.IdleState);
            }
        }
    }

    public override void AnimationFinishTrigger()
    {
        //base.AnimationFinishTrigger();
        isAnimationFinished = true;
        stateExitDifference = Time.time;
        Debug.Log("Reached AnimationEvent - AnimationFinishTrigger set TRUE at " + Time.time);
    }

}