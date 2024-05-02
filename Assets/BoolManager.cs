using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BoolManager : MonoBehaviour
{

    public bool isStartup = true;
    public PlayerZone pz;
    
    void Start()
    {
        
            if (pz.GetBoolManager() != null && pz.GetBoolManager() != this)
            {
                Destroy(gameObject);
            }
            else
            {
                pz.SetBoolManager(this);
             }
        
        DontDestroyOnLoad(this.gameObject);
    }


}
