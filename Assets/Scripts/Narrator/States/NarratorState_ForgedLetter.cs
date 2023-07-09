using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorState_ForgedLetter : NarratorBaseState
{

    public NarratorState_ForgedLetter(NarratorStateMachine ctx) : base(ctx) { }



    public override void StateEnter()
    {
        _ctx.ChangeChoicePanel(false, (int)_ctx.CurrentStateLabel - 1);
        _ctx.ChangeChoicePanel(true, (int)_ctx.CurrentStateLabel);
    }
    public override void StateExit()
    {
        _ctx.Letter.SetActive(false);
    }



    public override void ChoiceA()
    {
        if(_ctx.SpottedCount == 2)
        {
            _ctx.Fader.OnChoiceFade(() =>
            {
                _ctx.NewspaperType = NarratorStateMachine.NewspaperTypes.PlayerSpotted;
                _ctx.ChangeState(NarratorStateMachine.StateLabels.Ending);
            });
            return;
        }

        _ctx.Suspicion += 1;
        if (_ctx.Mislead > 0) _ctx.Mislead += 1; else _ctx.Mislead += 0;
        _ctx.Fader.OnChoiceFade(() =>
        {
            _ctx.ChangeState(NarratorStateMachine.StateLabels.Weapon);
        });
    }
    public override void ChoiceB()
    {
        _ctx.LetterPlanted = true;
        if(_ctx.RingPlanted)
        {
            _ctx.Suspicion = 0;
            _ctx.Mislead = 0;
            _ctx.Fader.OnChoiceFade(() =>
            {
                _ctx.NewspaperType = NarratorStateMachine.NewspaperTypes.NeighbourRingLetter;
                _ctx.ChangeState(NarratorStateMachine.StateLabels.Ending);
            });
        }
        else
        {
            _ctx.Suspicion += 0;
            _ctx.Mislead += 3;
            _ctx.Fader.OnChoiceFade(() =>
            {
                _ctx.ChangeState(NarratorStateMachine.StateLabels.Weapon);
            });
        }
    }
    public override void ChoiceC()
    {
        _ctx.Suspicion += 1;
        _ctx.Mislead += 0;
        _ctx.Fader.OnChoiceFade(() =>
        {
            _ctx.ChangeState(NarratorStateMachine.StateLabels.Weapon);
        });
    }
}
