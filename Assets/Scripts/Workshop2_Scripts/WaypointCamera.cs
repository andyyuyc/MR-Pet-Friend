using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointCamera : MonoBehaviour
{
    public List<GameObject> Waypoints;
    int currentWaypointGoal = 1;
    int lastWaypointGoal = 0;

    public int cameraSlowness = 10;
    float interpolationProgress = 0.0f;

    //Has no effect on the script other than to help debug.
    //Shows lines between waypoints
    public bool debugMode = true;
    //Draws a line from the camera to the origin
	public bool showDistFromOrigin = true;

    // Start is called before the first frame update
    void Start()
    {
        //always start the camera at the first waypoint's transform
        gameObject.transform.position = Waypoints[0].transform.position;
        gameObject.transform.rotation = Waypoints[0].transform.rotation;        
    }

    // Update is called once per frame
    void Update()
    {
        //interpolate position
        gameObject.transform.position = Vector3.Lerp(Waypoints[lastWaypointGoal].transform.position,
                                                     Waypoints[currentWaypointGoal].transform.position, interpolationProgress);
        //interpolate rotation
        gameObject.transform.rotation = Quaternion.Lerp(Waypoints[lastWaypointGoal].transform.rotation,
                                                        Waypoints[currentWaypointGoal].transform.rotation, interpolationProgress);
        
        //Function to pick a new goal waypoint
        SwitchGoals();
       
        DebugInfo();
        //Debug.Log(Time.deltaTime);
	}

    void SwitchGoals()
    {
         //If we have completed our interpolation, assign new goals and reset the frame number (or index).
        if (interpolationProgress >= 1.0f)
        {
            lastWaypointGoal = currentWaypointGoal;
            //if there are still more new goal waypoints, then make the next one in the list our goal.
            //if not, then loop back to the first waypoint.
            if (currentWaypointGoal < Waypoints.Count-1)
            {
                currentWaypointGoal++;
            } else
            {
                currentWaypointGoal = 0;
            }
            interpolationProgress = 0.0f;
        } else//if still interpolating, then update frame index
        {
            //divide by camera speed to scale the transformation
            interpolationProgress += Time.deltaTime * (1.0f / cameraSlowness);
        }
    }

    void DebugInfo()
    {
        if (debugMode == true)
        {
            Debug.DrawLine(Waypoints[Waypoints.Count - 1].transform.position, Waypoints[0].transform.position, new Color(1, 1, 1));
            for (int i = 1; i < Waypoints.Count; i++)
            {
                Debug.DrawLine(Waypoints[i - 1].transform.position, Waypoints[i].transform.position, new Color(1, 1, 1));
            }
        }

        if (showDistFromOrigin)
        {
            Debug.DrawLine(Vector3.zero, gameObject.transform.position, new Color(1, 1, 1));
        }
    }
}
