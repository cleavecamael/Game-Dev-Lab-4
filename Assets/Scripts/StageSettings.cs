using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StageSettings", menuName = "ScriptableObjects/StageSettings", order = 2)]
public class StageSettings : ScriptableObject
{

    public Vector3 StartCameraPosition;
    public Vector3 StartMarioPosition;
    public Vector3 StartBootsPosition;

   
}
