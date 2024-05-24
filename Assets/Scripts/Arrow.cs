using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Arrow : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        // Destroy(other.gameObject);
        // Destroy(gameObject);
        // Check if the arrow collides with the target GameObject
        // if (collision.gameObject.CompareTag("TargetCube"))
        // {
        //     Debug.Log("Hit");
        //     // Disable the Rigidbody to stop physics interactions
        //     Rigidbody rb = GetComponent<Rigidbody>();
        //     if (rb != null)
        //         rb.isKinematic = true;

        //     // Disable renderers to make the arrow appear pierced into the target
        //     Renderer[] renderers = GetComponentsInChildren<Renderer>();
        //     foreach (Renderer renderer in renderers)
        //     {
        //         renderer.enabled = false;
        //     }
        // }
    }
}
