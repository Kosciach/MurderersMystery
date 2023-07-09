using SimpleMan.CoroutineExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(CanvasGroupController))]
public class FaderController : MonoBehaviour
{
    private CanvasGroupController _canvasGroupController;
    private bool _canFade = true;


    private void Awake()
    {
        _canvasGroupController = GetComponent<CanvasGroupController>();
        _canFade = true;
    }
    private void Start()
    {
        _canvasGroupController.ToggleInteractable(false);
        _canvasGroupController.ToggleBlocksRaycasts(false);
    }



    public void OnChoiceFade(Action toDo)
    {
        if (!_canFade) return;

        _canFade = false;
        _canvasGroupController.ToggleInteractable(true);
        _canvasGroupController.ToggleBlocksRaycasts(true);

        _canvasGroupController.ToggleVisibility(true, 1, true);
        this.Delay(1.5f, () =>
        {
            toDo.Invoke();

            _canvasGroupController.ToggleVisibility(false, 1, true);
            this.Delay(1, () =>
            {
                _canFade = true;
                _canvasGroupController.ToggleInteractable(false);
                _canvasGroupController.ToggleBlocksRaycasts(false);
            });
        });
    }
}
