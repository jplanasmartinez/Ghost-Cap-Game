using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car Movement Data", menuName = "Car Movement Data")]
public class CarData : ScriptableObject
{
    [Header("MovementMagnitudes")]
    [Range(1,100)] public float speed;
    [Range(1,100)] public float maxSpeed;
    [Range(1,100)] public float angularSpeed;
    [Range(1,100)] public float maxAngularSpeed;
}
