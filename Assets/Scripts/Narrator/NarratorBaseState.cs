using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NarratorBaseState : MonoBehaviour
{
    protected NarratorStateMachine _ctx;

    public NarratorBaseState(NarratorStateMachine ctx)
    {
        _ctx = ctx;
    }



    public abstract void StateEnter();
    public abstract void StateExit();



    public abstract void ChoiceA();
    public abstract void ChoiceB();
    public abstract void ChoiceC();

}
