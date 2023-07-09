using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorState_Ring : NarratorBaseState
{

    public NarratorState_Ring(NarratorStateMachine ctx) : base(ctx) { }



    public override void StateEnter()
    {
        _ctx.ChangeChoicePanel(true, (int)_ctx.CurrentStateLabel);
    }
    public override void StateExit()
    {

    }



    public override void ChoiceA()
    {
        _ctx.Suspicion = 0;
        _ctx.Mislead = 0;
        _ctx.Fader.OnChoiceFade(() =>
        {
            _ctx.Ring.SetActive(false);
            _ctx.ChangeState(NarratorStateMachine.StateLabels.KeysLost);
        });
    }
    public override void ChoiceB()
    {
        _ctx.Suspicion = 1;
        _ctx.Mislead = 0;
        _ctx.Fader.OnChoiceFade(() =>
        {
            _ctx.ChangeState(NarratorStateMachine.StateLabels.KeysLost);
        });
    }
    public override void ChoiceC()
    {
        _ctx.Suspicion = 0;
        _ctx.Mislead = 0;
        _ctx.RingPlanted = true;
        _ctx.Fader.OnChoiceFade(() =>
        {
            _ctx.Ring.SetActive(false);
            _ctx.ChangeState(NarratorStateMachine.StateLabels.KeysLost);
        });
    }
}
