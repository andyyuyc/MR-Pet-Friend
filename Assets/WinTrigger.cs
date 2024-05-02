using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public ParticleSystem ps;
    public GameObject Counter;
    ObjectCounter Count;

    private void Start()
    {
        Count = Counter.GetComponent<ObjectCounter>();
    }



    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.transform.CompareTag("Win Object"))
        {
            ps.Play();
            Count.AddCount();
        }


    }

    public void OnTriggerExit(Collider other)
    {

        if (other.gameObject.transform.CompareTag("Win Object"))
        {

            Count.SubtractCount();
        }


    }
}
