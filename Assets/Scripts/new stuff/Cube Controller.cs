using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Transform[] waypoints; // Array of waypoints defining the path of the purple lines
    public float speed = 5.0f; // Speed of the cube's movement along the path
    public float rotationSpeed = 5.0f; // Speed of rotation
    private int waypointIndex = 0; // Current index of the waypoint array

    void Update()
    {
        MoveAlongPath();
    }

    void MoveAlongPath()
    {
        if (waypointIndex < waypoints.Length)
        {
            // Move the cube towards the current waypoint
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);

            // Rotate the cube towards the current waypoint
            Vector3 direction = waypoints[waypointIndex].position - transform.position;
            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            }

            // Check if the cube has reached the waypoint
            if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 0.1f)
            {
                // Increment the waypoint index to target the next one
                waypointIndex++;
            }
        }
        else
        {
            // If the end of the path is reached, optionally loop back to the start
            waypointIndex = 0;
        }
    }
}
