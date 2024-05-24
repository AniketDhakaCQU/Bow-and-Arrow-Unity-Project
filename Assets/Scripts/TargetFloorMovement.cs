using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFloorMovement : MonoBehaviour
{
    public GameObject targetFloor;
    public float speed = 2f; // Speed of the floor movement
    public float leftLimit = -5f; // Left boundary limit
    public float rightLimit = 5f; // Right boundary limit
    public float uplimit = 0f; // Right boundary limit
    public float downlimit = -4f; // Right boundary limit

    private int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreManager.instance.level == 2) {
            // Calculate the new position
            Vector3 newPosition = targetFloor.transform.position + Vector3.right * direction * speed * Time.deltaTime;

            // Check if the floor reaches the boundary limits
            if (newPosition.x > rightLimit)
            {
                newPosition.x = rightLimit;
                direction = -1; // Change direction to left
            }
            else if (newPosition.x < leftLimit)
            {
                newPosition.x = leftLimit;
                direction = 1; // Change direction to right
            }

            // Apply the new position
            transform.position = newPosition;
        } else if (ScoreManager.instance.level == 3) {
            // Calculate the new position
            Vector3 newPosition = targetFloor.transform.position + Vector3.up * direction * speed * Time.deltaTime;

            // Check if the floor reaches the boundary limits
            if (newPosition.y > uplimit)
            {
                newPosition.y = uplimit;
                direction = -1; // Change direction to left
            }
            else if (newPosition.y < downlimit)
            {
                newPosition.y = downlimit;
                direction = 1; // Change direction to right
            }

            // Apply the new position
            transform.position = newPosition;
        }
    }
}
