using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMover : MonoBehaviour
{
    bool debugMode = true;

    bool showDistFromOrigin = true;

    public Vector3 startPos;
    public Vector3 endPos;
    public Vector3 initialTranslation;

    public int movementSlowness = 10;
    int frameIndex = 0;
    float interpolationProgress = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = gameObject.transform.position;
        endPos = gameObject.transform.position + initialTranslation;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.Lerp(startPos,
                                                   endPos, interpolationProgress);

        //If we have completed out interpolation, switch the start and end point and reset the frame number (index).
        if (interpolationProgress >= 1.0f)
        {
            endPos = startPos;
            startPos = gameObject.transform.position;

            gameObject.transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));

            interpolationProgress = 0.0f;
        }
        else//if still interpolating, then update frame index
        {
            interpolationProgress += Time.deltaTime * (1.0f / movementSlowness);
            Debug.Log(Time.deltaTime);
        }

       DebugInfo();
    }

    void DebugInfo()
    { 
        if (debugMode == true)
        {
            Debug.DrawLine(startPos, endPos, new Color(1.0f, 0.0f, 1.0f));
        }

        if (showDistFromOrigin)
        {
            Debug.DrawLine(Vector3.zero, gameObject.transform.position, new Color(1.0f, 0.0f, 0.0f));
        }

    }
}
