using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorState_Clothes : NarratorBaseState
{

    public NarratorState_Clothes(NarratorStateMachine ctx) : base(ctx) { }



    public override void StateEnter()
    {
        _ctx.ChangeChoicePanel(false, (int)_ctx.CurrentStateLabel - 1);
        _ctx.ChangeChoicePanel(true, (int)_ctx.CurrentStateLabel);
    }
    public override void StateExit()
    {
        _ctx.Clothes.SetActive(false);
    }



    public override void ChoiceA()
    {
        _ctx.Suspicion += 0;
        _ctx.Mislead += 0;
        _ctx.Fader.OnChoiceFade(() =>
        {
            _ctx.ChangeState(NarratorStateMachine.StateLabels.ForgedLetter);
        });
    }
    public override void ChoiceB()
    {
        _ctx.SpottedCount++;
        _ctx.Suspicion += 1;
        if (_ctx.Mislead > 0) _ctx.Mislead += 1; else _ctx.Mislead += 0;
        _ctx.Fader.OnChoiceFade(() =>
        {
            _ctx.ChangeState(NarratorStateMachine.StateLabels.ForgedLetter);
        });
    }
    public override void ChoiceC()
    {
        _ctx.Suspicion = 0;
        _ctx.Mislead = 0;
        _ctx.Fader.OnChoiceFade(() =>
        {
            _ctx.NewspaperType = NarratorStateMachine.NewspaperTypes.PlayerClothes;
            _ctx.ChangeState(NarratorStateMachine.StateLabels.Ending);
        });
    }
}
