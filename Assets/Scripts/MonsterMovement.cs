using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

// for z coordinate makes the monster come towards you
    public float monstDistance = -80.0f;
    public float monstSpeed = 20.0f;
    private bool inProximity;
    private bool hasMoved;
    private bool timeToLeave;

    public GameObject Enemy;

    void Start()
    {
        Enemy.SetActive(true);
        inProximity = false;
        hasMoved = false;
        timeToLeave = false;
    }

    void Update()
    {
        if (inProximity && !hasMoved)
        {
            Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - monstDistance);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * monstSpeed);
        }
        if (timeToLeave)
        {
            Vector3 targetUp = new Vector3(transform.position.x, transform.position.y + 50, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetUp, Time.deltaTime * monstSpeed);
            //StartCoroutine(ExampleCoroutine2());     
        }  
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {  
            inProximity = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {  
            inProximity = false;
            StartCoroutine(ExampleCoroutine1());
        }
    }

    IEnumerator ExampleCoroutine1()
    {
        yield return new WaitForSeconds(2);
        timeToLeave = true;

    }

    IEnumerator ExampleCoroutine2()
    {
        yield return new WaitForSeconds(4);
        Enemy.SetActive(false);

    }

}
