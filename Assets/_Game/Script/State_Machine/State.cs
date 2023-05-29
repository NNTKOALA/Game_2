using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[System.Serializable]
public class State
{
    protected Bot bot;
    protected StateMachine stateMachine;

    public State(Bot bot, StateMachine stateMachine)
    {
        this.bot = bot;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        
    }

    public virtual void Tick()
    {

    }

    public virtual void Exit()
    {
        
    }
}
