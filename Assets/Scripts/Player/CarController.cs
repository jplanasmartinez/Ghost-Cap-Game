using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CarController : MonoBehaviour {

     [SerializeField] private CarData carData; 
    private Rigidbody _rigidbody;
    private Vector2 _direction;

    #region Unity Functions
    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        ApplyForces();
        CorrectMaximumSpeed();
        if (_direction != Vector2.zero) RotateCar();
    }

    #endregion
    
    #region Car Movement
    private void ApplyForces() {
        _rigidbody.AddForce(new Vector3(_direction.x * carData.speed, 0, _direction.y * carData.speed));
        if (_direction == Vector2.zero && _rigidbody.velocity != Vector3.zero) {
            ReduceSpeed();
            Debug.Log(_rigidbody.velocity.magnitude);
        }
    }

    public void MoveCar(Vector2 directionEntry) {
        _direction = directionEntry;
    }

    public void RotateCar() {
        carData.rotationY = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,CalculateRotationByDirection(),0), carData.rotationSpeed);
        transform.rotation = carData.rotationY;
    }
    
    private void CorrectMaximumSpeed() {
        _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, carData.maxSpeed);
    }
    
    private void ReduceSpeed() {
        if (_rigidbody.velocity.magnitude > 0) {
            Vector3 reducedVelocity = Vector3.Lerp(_rigidbody.velocity, Vector3.zero, carData.speedDecrease * Time.deltaTime);
            _rigidbody.velocity = reducedVelocity;
        }
    }
    
    #endregion
    
    #region Auxiliar Functions
    
    private int CalculateRotationByDirection() {
        int directionX = Mathf.RoundToInt(_direction.x);
        int directionY = Mathf.RoundToInt(_direction.y);
        int rotation = (int) (Math.Atan2(directionX, directionY) * 180 / Math.PI);
        return rotation ;
    }
    
    #endregion
}
