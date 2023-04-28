using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //this script was from my previous implementation I will look into it later tonight if I can delete it without breaking anything
    public Transform cameraPosition;

    private void Update(){
        transform.position = cameraPosition.position;
    }
}
