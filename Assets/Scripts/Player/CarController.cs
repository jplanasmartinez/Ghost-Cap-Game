using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    [Header("MovementMagnitudes")]
    [SerializeField] private float _speed;
    [SerializeField] private float _angularSpeed;
    
    private Rigidbody _rigidbody;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MoveCar(Vector2 direction) {
        _rigidbody.AddForce(new Vector3(direction.x * _speed, 0.5f, direction.y * _speed));
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,CalculateRotationByDirection(direction),0), 5f);
    }

    private float CalculateRotationByDirection(Vector2 direction) {
        float rotation = (float) (Math.Atan2(direction.x, direction.y) * 180 / Math.PI);
        return rotation;
    }
}
