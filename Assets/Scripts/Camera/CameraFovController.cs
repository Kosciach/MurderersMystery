using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFovController : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] CinemachineVirtualCamera _cineCamera;


    [Space(20)]
    [Header("====Settings====")]
    [SerializeField] bool _toggle;


    [Space(20)]
    [Header("====Settings====")]
    [Range(20, 60)]
    [SerializeField] float _baseFov;
    [Range(20, 60)]
    [SerializeField] float _focusFov;


    private MouseInput _mouseInput;


    private void Awake()
    {
        _mouseInput = new MouseInput();
        Focus(false);
    }
    private void Start()
    {
        _mouseInput.Mouse.Focus.performed += ctx => Focus(true);
        _mouseInput.Mouse.Focus.canceled += ctx => Focus(false);
    }



    public void Focus(bool focus)
    {
        if (!_toggle) return;


        float fov = focus ? _focusFov : _baseFov;
        LeanTween.value(_cineCamera.m_Lens.FieldOfView, fov, 0.2f).setOnUpdate((float val) =>
        {
            _cineCamera.m_Lens.FieldOfView = val;
        });
    }


    public void Toggle(bool enable)
    {
        _toggle = enable;
        if(!_toggle)
        {
            Focus(false);
        }
    }


    private void OnEnable()
    {
        _mouseInput.Enable();
    }
    private void OnDisable()
    {
        _mouseInput.Disable();
    }
}
