using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BotIdleState : State
{
    private float time = 1f;

    public BotIdleState(Bot bot, StateMachine stateMachine) : base(bot, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Tick()
    {
        base.Tick();
        time -= Time.deltaTime;
        if(time < 0f)
        {
            stateMachine.ChangeState(stateMachine.states[1]);

        }

    }
}
