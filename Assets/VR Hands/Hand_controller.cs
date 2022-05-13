using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hand_controller : MonoBehaviour
{
    [SerializeField] InputActionReference controllerActionGrip;
    [SerializeField] InputActionReference controllerActionTrigger;

    private Animator _handAnimator;

    private void Awake()
    {
        controllerActionGrip.action.performed += GripPress;
        controllerActionTrigger.action.performed += TriggerPress;

        controllerActionGrip.action.canceled += GripCancel;

        _handAnimator = GetComponent<Animator>();
    }

    private void GripCancel(InputAction.CallbackContext obj)
    {
        _handAnimator.SetFloat("Grip", 0);
    }

    private void TriggerPress(InputAction.CallbackContext obj)
    {
        _handAnimator.SetFloat("Trigger", obj.ReadValue<float>());

    }

    private void GripPress(InputAction.CallbackContext obj)
    {
        _handAnimator.SetFloat("Grip", obj.ReadValue<float>());
    }

}
