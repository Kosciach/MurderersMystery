using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupController : MonoBehaviour
{
    private CanvasGroup _canvasGroup;


    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ToggleInteractable(bool enable)
    {
        _canvasGroup.interactable = enable;
    }
    public void ToggleBlocksRaycasts(bool enable)
    {
        _canvasGroup.blocksRaycasts = enable;
    }
    public void ToggleVisibility(bool enable, bool easing)
    {
        int weight = enable ? 1 : 0;
        if (!easing) LeanTween.alphaCanvas(_canvasGroup, weight, 0.1f);
        else LeanTween.alphaCanvas(_canvasGroup, weight, 0.1f).setEaseInOutQuart();
    }
    public void ToggleVisibility(bool enable, float duration, bool easing)
    {
        int weight = enable ? 1 : 0;
        if(!easing) LeanTween.alphaCanvas(_canvasGroup, weight, duration);
        else LeanTween.alphaCanvas(_canvasGroup, weight, duration).setEaseInOutQuart();
    }
}
