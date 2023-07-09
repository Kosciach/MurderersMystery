using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorState_Weapon : NarratorBaseState
{

    public NarratorState_Weapon(NarratorStateMachine ctx) : base(ctx) { }



    public override void StateEnter()
    {
        _ctx.ChangeChoicePanel(false, (int)_ctx.CurrentStateLabel - 1);
        _ctx.ChangeChoicePanel(true, (int)_ctx.CurrentStateLabel);
    }
    public override void StateExit()
    {
        _ctx.Weapon.SetActive(false);
    }



    public override void ChoiceA()
    {
        _ctx.Suspicion = 0;
        _ctx.Mislead = 0;
        _ctx.Fader.OnChoiceFade(() =>
        {
            _ctx.NewspaperType = NarratorStateMachine.NewspaperTypes.PlayerWeapon;
            _ctx.ChangeState(NarratorStateMachine.StateLabels.Ending);
        });
    }
    public override void ChoiceB()
    {
        _ctx.WeaponPlanted = true;
        if (_ctx.LetterPlanted || _ctx.RingPlanted)
        {
            _ctx.Suspicion = 0;
            _ctx.Mislead = 0;
            _ctx.Fader.OnChoiceFade(() =>
            {
                if (_ctx.LetterPlanted) _ctx.NewspaperType = NarratorStateMachine.NewspaperTypes.NeighbourLetterWeapon;
                else if (_ctx.RingPlanted) _ctx.NewspaperType = NarratorStateMachine.NewspaperTypes.NeighbourRingWeapon;
                _ctx.ChangeState(NarratorStateMachine.StateLabels.Ending);
            });
        }
        else
        {
            _ctx.Suspicion += 0;
            _ctx.Mislead += 3;
            FinalOutcome();
        }
    }
    public override void ChoiceC()
    {
        _ctx.Suspicion += 0;
        _ctx.Mislead += 0;
        FinalOutcome();
    }





    private void FinalOutcome()
    {
        if(_ctx.Suspicion > _ctx.Mislead)
            _ctx.Fader.OnChoiceFade(() =>
            {
                _ctx.NewspaperType = NarratorStateMachine.NewspaperTypes.PlayerMainSuspect;
                _ctx.ChangeState(NarratorStateMachine.StateLabels.Ending);
            });
        else if (_ctx.Suspicion < _ctx.Mislead)
            _ctx.Fader.OnChoiceFade(() =>
            {
                _ctx.NewspaperType = NarratorStateMachine.NewspaperTypes.NeighbourMainSuspect;
                _ctx.ChangeState(NarratorStateMachine.StateLabels.Ending);
            });
        else
            _ctx.Fader.OnChoiceFade(() =>
            {
                _ctx.NewspaperType = NarratorStateMachine.NewspaperTypes.PoliceGivesUp;
                _ctx.ChangeState(NarratorStateMachine.StateLabels.Ending);
            });
    }
}
