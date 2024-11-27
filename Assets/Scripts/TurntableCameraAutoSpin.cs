using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Camera))]
public class TurntableCameraAutoSpin : MonoBehaviour
{
    public Transform Target;
    public float Speed;
    
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Target.position, Vector3.down, Speed * Time.deltaTime);
    }
}
