using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car Movement Data", menuName = "Car Movement Data")]
public class CarData : ScriptableObject {
    
    [Header("Direction")]
    public Quaternion rotationY;
    [Range(0.01f, 0.3f)] public float rotationSpeed;

    [Header("MovementMagnitudes")]
    [Range(1,100)] public float speed;
    [Range(1,100)] public float maxSpeed;
    [Range(0.1f,5)]public float speedDecrease;
}
