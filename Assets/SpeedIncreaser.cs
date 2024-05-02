using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpeedIncreaser : MonoBehaviour
{

    public bool isUsingTime;
    public bool isUsingObjectCount;
    public float timer = 0;
    public float timeNeededToSpeedUp;
    public float objectsNeededToSpeedUp;
    public float increaseAmount;
    private ObjectCounter count;
    private NavMeshAgent enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        count = GameObject.Find("ObjectCounter").GetComponent<ObjectCounter>();
        enemy = GetComponent<NavMeshAgent>();
        
        if(isUsingTime)
        {
            isUsingObjectCount = false;
            timer = 0;
        }

        if(isUsingObjectCount)
        {
            isUsingTime = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsingTime)
        {
            if (timer >= (timeNeededToSpeedUp * 60))
            {
                timer = 0;
                IncreaseSpeed();
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
        
        else if (isUsingObjectCount)
        {
            if (count.GetCount() >= objectsNeededToSpeedUp)
            {
                IncreaseSpeed();
                isUsingObjectCount = false;
            }
        }
    }

    void IncreaseSpeed()
    {
        enemy.speed = enemy.speed + increaseAmount;
    }
}
