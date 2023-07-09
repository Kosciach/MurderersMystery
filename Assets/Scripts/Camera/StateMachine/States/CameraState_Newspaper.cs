using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraState_Newspaper : CameraBaseState
{
    public CameraState_Newspaper(CameraStateMachine ctx) : base(ctx) { }

    public override void StateEnter()
    {
        _ctx.Fov.Toggle(true);

        _ctx.FollowMove.Move(new Vector3(0, 3.74f, 1.27f), 2);
        _ctx.LookAtMove.Move(new Vector3(0, 2.18f, 0.47f), 2);
    }
    public override void StateExit()
    {

    }
}
