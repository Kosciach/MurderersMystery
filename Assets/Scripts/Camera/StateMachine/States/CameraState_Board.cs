using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraState_Board : CameraBaseState
{
    public CameraState_Board(CameraStateMachine ctx) : base(ctx) { }

    public override void StateEnter()
    {
        Debug.Log("Board");

        _ctx.Fov.Toggle(false);

        _ctx.FollowMove.Move(new Vector3(0, 3.94f, -2.3f), 2);
        _ctx.LookAtMove.Move(new Vector3(0, 3.49f, -4.36f), 2);
    }
    public override void StateExit()
    {

    }
}
