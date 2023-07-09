using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorState_KeysLost : NarratorBaseState
{

    public NarratorState_KeysLost(NarratorStateMachine ctx) : base(ctx) { }



    public override void StateEnter()
    {
        _ctx.ChangeChoicePanel(false, (int)_ctx.CurrentStateLabel - 1);
        _ctx.ChangeChoicePanel(true, (int)_ctx.CurrentStateLabel);
    }
    public override void StateExit()
    {

    }



    public override void ChoiceA()
    {
        _ctx.SpottedCount++;
        _ctx.Suspicion += 1;
        _ctx.Mislead += 1;
        _ctx.Fader.OnChoiceFade(() =>
        {
            _ctx.ChangeState(NarratorStateMachine.StateLabels.Clothes);
        });
    }
    public override void ChoiceB()
    {
        _ctx.Suspicion += _ctx.Suspicion;
        _ctx.Mislead += 0;
        _ctx.Fader.OnChoiceFade(() =>
        {
            _ctx.ChangeState(NarratorStateMachine.StateLabels.Clothes);
        });
    }
    public override void ChoiceC()
    {
        _ctx.Suspicion += 0;
        _ctx.Mislead += 0;
        _ctx.Fader.OnChoiceFade(() =>
        {
            _ctx.ChangeState(NarratorStateMachine.StateLabels.Clothes);
        });
    }
}
