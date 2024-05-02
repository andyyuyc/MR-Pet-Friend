using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishForce : MonoBehaviour
{

    private Rigidbody jFish;
    public float thrust;
    
    private float period = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        jFish = GetComponent<Rigidbody>();
        jFish.MoveRotation(Random.rotation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (period > 10f)
        {
            jFish.AddForce(transform.up * -thrust, ForceMode.Force);
            //Debug.Log("1st push");
            period = 0;
            jFish.MoveRotation(Random.rotation);
        }

        if (period > 2.5f)
        {
            jFish.AddForce(transform.up * 0.35f * thrust, ForceMode.Force);
            //Debug.Log("2nd push");
        }
        
        period += UnityEngine.Time.deltaTime;



    }

   
}
