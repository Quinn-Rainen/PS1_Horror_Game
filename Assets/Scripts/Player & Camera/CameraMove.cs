using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Range(0.001f, 1f)]
    public float Amount = 0.002f;
    [Range(1f, 30f)]
    public float frequency = 10.0f;
    [Range(1f, 100f)]
    public float Smooth = 1f;

    Vector3 StartPos;
    private bool isMoving;
    private bool isSprinting;
    private bool isCrouching;

    public GameObject playerObject;
    // private PlayerMovement playerMovementScript;

    void Start()
    {
        StartPos = transform.localPosition;
    }

    void Update()
    {
        isSprinting = playerObject.GetComponent<PlayerMovement>().isSprinting;
        isCrouching = playerObject.GetComponent<PlayerMovement>().isCrouching;
        CheckForHeadbobTrigger();
        StopHeadbob();
    }

    private void CheckForHeadbobTrigger()
    {
        float inputMagnitude = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude;
        if (inputMagnitude > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void FixedUpdate()
    {


        if(isMoving && isCrouching){
            //Debug.Log(isCrouching);
            Vector3 pos = Vector3.zero;
            pos.y += Mathf.Lerp(pos.y, Mathf.Sin(Time.time * frequency) * Amount * 0.5f, Smooth * Time.deltaTime);
            pos.x += Mathf.Lerp(pos.x, Mathf.Cos(Time.time * frequency / 3f) * Amount * 1.1f, Smooth * Time.deltaTime);
            transform.localPosition += pos;           
        }
        else if(isMoving && isSprinting){
            //Debug.Log("ISSPRINTING");
            Vector3 pos = Vector3.zero;
            pos.y += Mathf.Lerp(pos.y, Mathf.Sin(Time.time * (frequency*1.5f)) * Amount * 2f, Smooth * Time.deltaTime);
            pos.x += Mathf.Lerp(pos.x, Mathf.Cos(Time.time * (frequency*1.5f)  / 1.5f) * Amount * 1.8f, Smooth * Time.deltaTime);
            transform.localPosition += pos;              
        }
        else if(isMoving){
            //Debug.Log("Base Walk Bob");
            //base walking camera movement
            Vector3 pos = Vector3.zero;
            pos.y += Mathf.Lerp(pos.y, Mathf.Sin(Time.time * frequency) * Amount * 1.4f, Smooth * Time.deltaTime);
            pos.x += Mathf.Lerp(pos.x, Mathf.Cos(Time.time * frequency / 2f) * Amount * 1.6f, Smooth * Time.deltaTime);
            transform.localPosition += pos;
        }
    }

    private void StopHeadbob()
    {
        if (transform.localPosition == StartPos) return;
        transform.localPosition = Vector3.Lerp(transform.localPosition, StartPos, Smooth * Time.deltaTime);
    }
}