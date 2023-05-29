using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State[] states = new State[4];
    public State CurrentState { get; private set; }

    public void Initialize(State startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }

    public void ChangeState(State newState)
    {
        CurrentState.Exit();

        CurrentState = newState;
        CurrentState.Enter();
    }

    private void Start()
    {
        Bot bot = GetComponent<Bot>();

        states[0] = new BotIdleState(bot, bot.stateMachine);
        states[1] = new BotCollectState(bot, bot.stateMachine);
        states[2] = new BotBuildState(bot, bot.stateMachine);

        Initialize(states[0]);
    }

    private void Update()
    {
        if(CurrentState != null)
        {
            CurrentState.Tick();
        }
    }
}
