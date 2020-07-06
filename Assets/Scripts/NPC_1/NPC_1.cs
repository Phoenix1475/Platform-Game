using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_1 : MonoBehaviour
{


    bool isShaking = false;
    float shakeAmount = .1f;
    Vector2 startPos;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (isShaking)
        {

            transform.position = startPos + UnityEngine.Random.insideUnitCircle * shakeAmount;



        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "AttackHitBox")
        {

            isShaking = true;
            Invoke("StopShaking", 1f);

            //StartCoroutine(StopShaking());


        }


    }

    void StopShaking()
    //IEnumerator StopShaking()

    {

        //yield return new WaitForSeconds(1f);

        isShaking = false;
        //yield return new WaitForSeconds(1f);

        transform.position = startPos;

    }

}

