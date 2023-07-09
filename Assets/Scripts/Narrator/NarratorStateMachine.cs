using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorStateMachine : MonoBehaviour
{
    private NarratorBaseState[] _narratorStates;
    private NarratorBaseState _currentState;


    [Header("====References====")]
    [SerializeField] FaderController _fader;                                    public FaderController Fader { get { return _fader; } }
    [SerializeField] CanvasGroupController[] _choicePanelsCanvasGroups;         public CanvasGroupController[] ChoicePanelsCanvasGroups { get { return _choicePanelsCanvasGroups;} }
    [SerializeField] CanvasGroupController[] _newspapersCanvasGroups;           public CanvasGroupController[] NewspapersCanvasGroups { get { return _newspapersCanvasGroups; } }
    [SerializeField] CameraStateMachine _cameraStateMachine;                    public CameraStateMachine CameraStateMachine { get { return _cameraStateMachine; } }

    [Space(10)]
    [SerializeField] Transform _newspaperTransform;
    [SerializeField] GameObject _ring;                                    public GameObject Ring { get { return _ring; } }
    [SerializeField] GameObject _clothes;                                 public GameObject Clothes { get { return _clothes; } }
    [SerializeField] GameObject _letter;                                  public GameObject Letter { get { return _letter; } }
    [SerializeField] GameObject _weapon;                                  public GameObject Weapon { get { return _weapon; } }


    [Space(20)]
    [Header("====Debugs====")]
    [SerializeField] StateLabels _currentStateLabel;                        public StateLabels CurrentStateLabel { get { return _currentStateLabel; } }
    [SerializeField] NewspaperTypes _newspaperType;                         public NewspaperTypes NewspaperType { get { return _newspaperType; } set { _newspaperType = value; } }
    [SerializeField] int _suspicion;                                        public int Suspicion { get { return _suspicion; } set { _suspicion = value; } }
    [SerializeField] int _mislead;                                          public int Mislead { get { return _mislead; } set { _mislead = value; } }
    [SerializeField] int _spottedCount;                                     public int SpottedCount { get { return _spottedCount; } set { _spottedCount = value; } }
    [SerializeField] bool _ringPlanted;                                     public bool RingPlanted { get { return _ringPlanted; } set { _ringPlanted = value; } }
    [SerializeField] bool _letterPlanted;                                   public bool LetterPlanted { get { return _letterPlanted; } set { _letterPlanted = value; } }
    [SerializeField] bool _weaponPlanted;                                   public bool WeaponPlanted { get { return _weaponPlanted; } set { _weaponPlanted = value; } }



    public enum StateLabels
    {
        Ring, KeysLost, Clothes, ForgedLetter, Weapon, Ending
    }
    public enum NewspaperTypes
    {
        Beginning, PlayerSpotted, NeighbourRingLetter, NeighbourRingWeapon, NeighbourLetterWeapon, PlayerWeapon, PlayerClothes, PlayerMainSuspect, NeighbourMainSuspect, PoliceGivesUp
    }




    private void Awake()
    {
        PrepareChoicePanels();
        PrepareStates();
        PrepareNewspapers();
    }

    private void PrepareMeshes()
    {
        _ring.SetActive(true);
        _clothes.SetActive(true);
        _letter.SetActive(true);
        _weapon.SetActive(true);
    }

    public void PrepareChoicePanels()
    {
        foreach(CanvasGroupController choicePanelsCanvasGroup in _choicePanelsCanvasGroups)
        {
            choicePanelsCanvasGroup.ToggleVisibility(false, true);
            choicePanelsCanvasGroup.ToggleBlocksRaycasts(false);
            choicePanelsCanvasGroup.ToggleInteractable(false);
        }
    }
    public void ChangeChoicePanel(bool enable, int index)
    {
        CanvasGroupController currentChoicePanelCanvasGroup = _choicePanelsCanvasGroups[index];
        currentChoicePanelCanvasGroup.ToggleVisibility(enable, true);
        currentChoicePanelCanvasGroup.ToggleBlocksRaycasts(enable);
        currentChoicePanelCanvasGroup.ToggleInteractable(enable);
    }


    private void PrepareNewspapers()
    {
        foreach (CanvasGroupController newspaperCanvasGroup in _newspapersCanvasGroups)
        {
            newspaperCanvasGroup.ToggleVisibility(false, true);
            newspaperCanvasGroup.ToggleBlocksRaycasts(false);
            newspaperCanvasGroup.ToggleInteractable(false);
        }

        CanvasGroupController begginingNewspaperCanvasGroup = _newspapersCanvasGroups[0];
        begginingNewspaperCanvasGroup.ToggleVisibility(true, true);
        begginingNewspaperCanvasGroup.ToggleBlocksRaycasts(true);
        begginingNewspaperCanvasGroup.ToggleInteractable(true);


        float newspaperAngle = UnityEngine.Random.Range(-35, 35);
        _newspaperTransform.localRotation = Quaternion.Euler(0, 90 - newspaperAngle, 0);
        begginingNewspaperCanvasGroup.GetComponent<RectTransform>().localRotation = Quaternion.Euler(90, 180, newspaperAngle);
    }
    public void ChangeNewspaper()
    {
        CanvasGroupController begginingNewspaperCanvasGroup = _newspapersCanvasGroups[0];
        begginingNewspaperCanvasGroup.ToggleVisibility(false, true);
        begginingNewspaperCanvasGroup.ToggleBlocksRaycasts(false);
        begginingNewspaperCanvasGroup.ToggleInteractable(false);

        CanvasGroupController newspaperCanvasGroup = _newspapersCanvasGroups[(int)_newspaperType];
        newspaperCanvasGroup.ToggleVisibility(true, true);
        newspaperCanvasGroup.ToggleBlocksRaycasts(true);
        newspaperCanvasGroup.ToggleInteractable(true);


        float newspaperAngle = UnityEngine.Random.Range(-35, 35);
        _newspaperTransform.localRotation = Quaternion.Euler(0, 90 - newspaperAngle, 0);
        newspaperCanvasGroup.GetComponent<RectTransform>().localRotation = Quaternion.Euler(90, 180, newspaperAngle);
    }


    private void PrepareStates()
    {
        _narratorStates = new NarratorBaseState[Enum.GetValues(typeof(StateLabels)).Length];

        _narratorStates[(int)StateLabels.Ring]          = new NarratorState_Ring(this);
        _narratorStates[(int)StateLabels.KeysLost]      = new NarratorState_KeysLost(this);
        _narratorStates[(int)StateLabels.Clothes]       = new NarratorState_Clothes(this);
        _narratorStates[(int)StateLabels.ForgedLetter]  = new NarratorState_ForgedLetter(this);
        _narratorStates[(int)StateLabels.Weapon]        = new NarratorState_Weapon(this);
        _narratorStates[(int)StateLabels.Ending]        = new NarratorState_Ending(this);


        _currentState = _narratorStates[(int)_currentStateLabel];
        _currentState.StateEnter();
    }
    public void ChangeState(StateLabels stateLabel)
    {
        _currentState.StateExit();

        _currentState = _narratorStates[(int)stateLabel];
        _currentStateLabel = stateLabel;

        _currentState.StateEnter();
    }


    public void ChoiceA()
    {
        _currentState.ChoiceA();
    }
    public void ChoiceB()
    {
        _currentState.ChoiceB();
    }
    public void ChoiceC()
    {
        _currentState.ChoiceC();
    }



    public void ResetGame()
    {
        _suspicion = 0;
        _mislead = 0;
        _spottedCount = 0;
        _ringPlanted = false;
        _letterPlanted = false;
        _weaponPlanted = false;
        _newspaperType = NewspaperTypes.Beginning;

        _currentState = _narratorStates[(int)StateLabels.Ring];
        _currentStateLabel = StateLabels.Ring;

        PrepareMeshes();
        PrepareChoicePanels();
        PrepareNewspapers();

        ChangeChoicePanel(true, (int)_currentStateLabel);
    }
}
