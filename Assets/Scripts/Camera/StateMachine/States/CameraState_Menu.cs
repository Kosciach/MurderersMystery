using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraState_Menu : CameraBaseState
{
    public CameraState_Menu(CameraStateMachine ctx) : base(ctx) { }

    public override void StateEnter()
    {
        Debug.Log("Menu");

        _ctx.Fov.Toggle(false);

        SetToggles(true);

        _ctx.FollowMove.Move(new Vector3(0, 3.63f, -2.58f), 2);
        _ctx.LookAtMove.Move(new Vector3(0, 3.55f, -4.6f), 2);
    }
    public override void StateExit()
    {
        SetToggles(false);
    }



    private void SetToggles(bool mainToggle)
    {
        //Visibility
        _ctx.CanvasGroups.MainMenu.ToggleVisibility(mainToggle, true);
        _ctx.CanvasGroups.Choices.ToggleVisibility(!mainToggle, true);
        _ctx.CanvasGroups.BoardArrow.ToggleVisibility(!mainToggle, true);
        _ctx.CanvasGroups.NewspaperArrow.ToggleVisibility(!mainToggle, true);

        //Interactable
        _ctx.CanvasGroups.Choices.ToggleInteractable(!mainToggle);

        //BlocksRaycasts
        _ctx.CanvasGroups.Choices.ToggleBlocksRaycasts(!mainToggle);
    }
}
