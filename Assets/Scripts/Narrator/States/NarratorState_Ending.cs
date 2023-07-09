using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorState_Ending : NarratorBaseState
{

    public NarratorState_Ending(NarratorStateMachine ctx) : base(ctx) { }



    public override void StateEnter()
    {
        _ctx.PrepareChoicePanels();
        _ctx.ChangeChoicePanel(true, (int)_ctx.CurrentStateLabel);

        _ctx.ChangeNewspaper();
        _ctx.CameraStateMachine.ChangeState(CameraStateMachine.StateLabels.Newspaper);
    }
    public override void StateExit()
    {

    }



    public override void ChoiceA()
    {
        _ctx.ResetGame();
        _ctx.CameraStateMachine.ChangeState(CameraStateMachine.StateLabels.Menu);
    }
    public override void ChoiceB()
    {
        _ctx.ResetGame();
        _ctx.CameraStateMachine.ChangeState(CameraStateMachine.StateLabels.Menu);
    }
    public override void ChoiceC()
    {

    }
}
