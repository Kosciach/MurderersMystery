using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanelsController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] GameObject[] _panels;
    public enum Panels
    {
        Main, Settings, Guide, Credits
    }

    
    public void ChangePanel(MainMenuPanelEnumHolder enumHolder)
    {
        foreach (GameObject panel in _panels) panel.SetActive(false);
        _panels[(int)enumHolder.PanelEnum].SetActive(true);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
