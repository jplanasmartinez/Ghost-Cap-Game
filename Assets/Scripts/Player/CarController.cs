using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CarController : MonoBehaviour {

     [SerializeField] private CarData carData; 
    private Rigidbody _rigidbody;
    private Vector2 direction;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        _rigidbody.AddForce(new Vector3(direction.x * carData.speed, 0.5f, direction.y * carData.speed));
        CorrectMaximumSpeed();
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,CalculateRotationByDirection(),0), 5f);
    }

    public void MoveCar(Vector2 directionEntry) {
        direction = directionEntry;
    }

    private void CorrectMaximumSpeed() {
        _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, carData.maxSpeed);
        _rigidbody.angularVelocity = Vector3.ClampMagnitude(_rigidbody.angularVelocity, carData.maxAngularSpeed);
    }

    private float CalculateRotationByDirection() {
        float rotation = (float) (Math.Atan2(direction.x, direction.y) * 180 / Math.PI);
        return rotation;
    }
}
