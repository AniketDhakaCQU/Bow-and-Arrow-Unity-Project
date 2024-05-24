using UnityEngine;

public class Target : MonoBehaviour
{
    public Transform attachpoint;
    public GameObject targetPrefab;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            // Increase the score
            ScoreManager.instance.AddScore(10);

            // Optionally, destroy the arrow or target
            Destroy(collision.gameObject);
        }
    }
}