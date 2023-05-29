using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class BotCollectState : State
{
    private NavMeshAgent agent;
    private GameObject target;

    public BotCollectState(Bot bot, StateMachine stateMachine) : base(bot, stateMachine)
    {
        agent = bot.Agent;
    }

    public override void Enter()
    {
        base.Enter();

        target = bot.GetClosestBrickOfType(bot.colorType);
        if(target != null)
        {
            agent.SetDestination(target.transform.position);
        }
        else
        {
            stateMachine.ChangeState(stateMachine.states[0]);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Tick()
    {
        base.Tick();

        if(target == null)
        {
            stateMachine.ChangeState(stateMachine.states[0]);
            return;
        }

        if(Vector3.Distance(bot.transform.position, target.transform.position) < 0.5f)
        {
            stateMachine.ChangeState(stateMachine.states[0]);
            return;
        }

        if(bot.BrickCount > 10)
        {
            stateMachine.ChangeState(stateMachine.states[2]);
            return;
        }
    }
}
