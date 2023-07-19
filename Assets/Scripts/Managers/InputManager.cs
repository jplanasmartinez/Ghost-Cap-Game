using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    public static InputManager _instance;
    [Header("Ingame Actions")]
    public InputActionReference carMovementAction;
    
    private void Awake()
    {
        if (_instance != null)
        {
            if (_instance != this)
            {
                Destroy(_instance.gameObject);
            }

        }
        _instance = this;

    }
}
