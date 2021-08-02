using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public FSM StateMachine;

    public PlayerIdleState IdleState;
    public PlayerAttackState AttackState;
    public PlayerMoveState MoveState;

    public Animator anim;

    [SerializeField] internal bool timeBasedTransition = true;

    private void Awake()
    {
        StateMachine = new FSM();

        IdleState = new PlayerIdleState(this, StateMachine, "idle");
        AttackState = new PlayerAttackState(this, StateMachine, "attack");
        MoveState = new PlayerMoveState(this, StateMachine, "move");
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        StateMachine.Initialize(IdleState);
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
}
