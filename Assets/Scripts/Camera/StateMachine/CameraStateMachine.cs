using CameraFollow;
using CameraLookAt;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateMachine : MonoBehaviour
{
    private CameraBaseState _currentState;
    private CameraBaseState[] _states;

    [Header("====References====")]
    [SerializeField] CameraFollowMove _followMove;                      public CameraFollowMove FollowMove { get { return _followMove; } }
    [SerializeField] CameraLookAtMove _lookAtMove;                      public CameraLookAtMove LookAtMove { get { return _lookAtMove; } }
    [SerializeField] CameraFovController _fov;                          public CameraFovController Fov { get { return _fov; } }

    [Space(10)]
    [SerializeField] CanvasGroupsStruct _canvasGroups;                  public CanvasGroupsStruct CanvasGroups { get { return _canvasGroups; } }



    [Space(20)]
    [Header("====Debugs====")]
    [SerializeField] StateLabels _currentStateLabel;



    public enum StateLabels
    {
        Menu, Newspaper, Board
    }

    [System.Serializable]
    public struct CanvasGroupsStruct
    {
        public CanvasGroupController MainMenu;
        public CanvasGroupController Choices;
        public CanvasGroupController BoardArrow;
        public CanvasGroupController NewspaperArrow;
        public CanvasGroupController Fader;
    }




    private void Awake()
    {
        PrepareStates();
    }






    private void PrepareStates()
    {
        _states = new CameraBaseState[Enum.GetValues(typeof(StateLabels)).Length];

        _states[(int)StateLabels.Menu] = new CameraState_Menu(this);
        _states[(int)StateLabels.Newspaper] = new CameraState_Newspaper(this);
        _states[(int)StateLabels.Board] = new CameraState_Board(this);

        _currentState = _states[(int)_currentStateLabel];
        _currentState.StateEnter();
    }
    public void ChangeState(StateLabels stateLabel)
    {
        _currentState.StateExit();

        _currentState = _states[(int)stateLabel];
        _currentStateLabel = stateLabel;

        _currentState.StateEnter();
    }
    public void ChangeState(CameraStateLabelHolder stateLabelHolder)
    {
        _currentState.StateExit();

        _currentState = _states[(int)stateLabelHolder.StateLabel];
        _currentStateLabel = stateLabelHolder.StateLabel;

        _currentState.StateEnter();
    }
}
