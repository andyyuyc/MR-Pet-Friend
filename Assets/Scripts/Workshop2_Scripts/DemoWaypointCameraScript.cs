using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoWaypointCameraScript : MonoBehaviour
{
    public bool debugMode = true;
    public bool showDistFromOrigin = true;

    public List<GameObject> Waypoints;

    int currentWaypointGoal = 1;
    int lastWaypointGoal = 0;

    public int cameraSlowness = 10;
    int frameIndex = 0;
    float interpolationProgress = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //always start the camera at the first waypoint's transform
        //gameObject.transform.position = Waypoints[0].transform.position;
        //gameObject.transform.rotation = Waypoints[0].transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = new Vector3(0, 0, 0);
        Vector3 endPosition = new Vector3(0, 0, 0);

        //           position1,      position2,  interpolation progress
        Vector3.Lerp(startPosition, endPosition, interpolationProgress);
        interpolationProgress += Time.deltaTime * (1.0f / cameraSlowness);

        //interpolate position
        gameObject.transform.position = Vector3.Lerp(Waypoints[lastWaypointGoal].transform.position,
                                                     Waypoints[currentWaypointGoal].transform.position, interpolationProgress);
        //interpolate rotation
        gameObject.transform.rotation = Quaternion.Lerp(Waypoints[lastWaypointGoal].transform.rotation,
                                                        Waypoints[currentWaypointGoal].transform.rotation, interpolationProgress);

        //If we have completed out interpolation, assign new goals and reset the frame number (index).
        if (interpolationProgress >= 1.0f)
        {
            lastWaypointGoal = currentWaypointGoal;
            //if there are still more new goal waypoints, then make the next one in the list our goal.
            //if not, then loop back to the first waypoint.
            if (currentWaypointGoal < Waypoints.Count - 1)
            {
                currentWaypointGoal++;
            }
            else
            {
                currentWaypointGoal = 0;
            }

            interpolationProgress = 0.0f;
        }
        else//if still interpolating, then update frame index
        {
            //divide by camera speed to scale the transformation
            //interpolationProgress += (1.0f / cameraSlowness);
            interpolationProgress += Time.deltaTime * (1.0f/cameraSlowness);
        }

        DebugInfo();

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
