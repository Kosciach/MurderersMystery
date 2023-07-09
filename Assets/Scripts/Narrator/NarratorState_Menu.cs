using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorState_Menu : NarratorBaseState
{

    public NarratorState_Menu(NarratorStateMachine ctx) : base(ctx) { }



    public override void StateEnter()
    {

    }
    public override void StateExit()
    {

    }



    public override void ChoiceA()
    {
        Debug.Log("StartGame");
    }
    public override void ChoiceB()
    {

    }
    public override void ChoiceC()
    {

    }
}
