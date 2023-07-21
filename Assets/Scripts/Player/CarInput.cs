using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarInput : MonoBehaviour {
    
    private CarController _carController;

    private void Awake() {
        _carController = GetComponent<CarController>();
    }

    private void Start()
    {
        InputManager._instance.carMovementAction.action.performed += MoveCar;
        InputManager._instance.carMovementAction.action.canceled += MoveCar;
    }

    private void OnDestroy() {
        InputManager._instance.carMovementAction.action.performed -= MoveCar;
        InputManager._instance.carMovementAction.action.canceled -= MoveCar;
    }

    private void MoveCar(InputAction.CallbackContext obj) {
        Debug.Log(InputManager._instance.carMovementAction.action.ReadValue<Vector2>());
        _carController.MoveCar(InputManager._instance.carMovementAction.action.ReadValue<Vector2>());
    }
}
