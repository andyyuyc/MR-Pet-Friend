using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCounter : MonoBehaviour
{
   public float ObjectsCollected;
   public float ObjectsNeededToWin;



    public void AddCount()
    {
        ObjectsCollected = ObjectsCollected + 1;
    }

    public void SubtractCount()
    {
        ObjectsCollected = ObjectsCollected - 1;
    }

    public float GetCount()
    {
        return ObjectsCollected;
    }

    public float GetNeededToWin()
    {
        return ObjectsNeededToWin;
    }
}
