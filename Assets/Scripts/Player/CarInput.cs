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
        InputManager._instance.carJumpAction.action.performed += JumpCar;
    }

    private void OnDestroy() {
        InputManager._instance.carMovementAction.action.performed -= MoveCar;
        InputManager._instance.carMovementAction.action.canceled -= MoveCar;
        InputManager._instance.carJumpAction.action.performed -= JumpCar;
    }

    private void MoveCar(InputAction.CallbackContext obj) {
        if (obj.performed) {
            _carController.MoveCar(InputManager._instance.carMovementAction.action.ReadValue<Vector2>());
        } else if (obj.canceled) {
            _carController.MoveCar(Vector2.zero);
        }
    }

    private void JumpCar(InputAction.CallbackContext obj) {
        Debug.Log("Jump");
    }
    

}
