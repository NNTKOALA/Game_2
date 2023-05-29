using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class BotBuildState : State
{
    private NavMeshAgent agent;
    private GameObject target;

    public BotBuildState(Bot bot, StateMachine stateMachine) : base(bot, stateMachine)
    {
        agent = bot.Agent;
    }

    public override void Enter()
    {
        base.Enter();
        agent.SetDestination(bot.testNavMeshMove.position);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Tick()
    {
        base.Tick();
        if (Vector3.Distance(bot.transform.position, bot.testNavMeshMove.position) < 1f)
        {
            stateMachine.ChangeState(stateMachine.states[0]);
        }
    }
}
