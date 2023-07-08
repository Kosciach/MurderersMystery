using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraBaseState
{
    protected CameraStateMachine _ctx;
    public CameraBaseState(CameraStateMachine ctx)
    {
        _ctx = ctx;
    }


    public abstract void StateEnter();
    public abstract void StateExit();
}
