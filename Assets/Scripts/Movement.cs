using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    // Speed of horizontal movement
    public float speed = 1f;
    public GameObject arrowPrefab;
    public GameObject targetPrefab;
    public Transform attachPoint;
    public Transform bowTransform;
    public Transform targetSpawnTransform;
    public Slider slider;

    // Start is called before the first frame update
    Vector3 objectInitialPosition;
    
    private GameObject arrow;
    private GameObject target;
    private float shootForce = 10f; // Force applied to the arrow when shooting

    public float arrowLife = 3f;

    public float rotationSpeed = 8f;

    public float forceChangeSpeed = 1f;

    private bool isMouseDown = false;

    void Start()
    {
        objectInitialPosition = Camera.main.WorldToScreenPoint(transform.position);
    }

    void SpawnArrow() {
        arrow = Instantiate(arrowPrefab, attachPoint);
    }

    void SpawnTarget() {
        // target = Instantiate(targetPrefab, new Vector3(transform.position.x, ))
        // Generate random position within the spawn area
        var center = transform.position;
        Vector3 randomPosition = new Vector3(
            Random.Range(center.x - targetSpawnTransform.position.x / 2f, center.x + targetSpawnTransform.position.x / 2f),
            targetSpawnTransform.position.y,
            targetSpawnTransform.position.z
        );
        target = Instantiate(targetPrefab, randomPosition, targetSpawnTransform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (arrow == null) {
            SpawnArrow();
        }
        // if (target == null) {
        //     SpawnTarget();
        // }
        
        // Get the current mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = objectInitialPosition.z;
        // Convert the screen coordinates to world coordinates
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // Move the object towards the mouse position
        transform.position = new Vector3(mousePosition.x, mousePosition.y,transform.position.z);
        
        /// Rotation
        float mouseY = Input.GetAxis("Mouse Y");
        // Debug.Log("Mouse y => " + mouseY);
        // Calculate rotation amount based on vertical mouse movement
        float rotationAmount = mouseY * rotationSpeed;
        // Debug.Log(mousePosition);
        // Ensure the z-coordinate is the same as the object's z-coordinate to maintain depth
        // mousePosition.z = transform.position.z;
        bowTransform.Rotate(Vector3.up, rotationAmount);

        if (Input.GetMouseButtonDown(0)) 
        {
            isMouseDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
            arrow.transform.parent = null;
            Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();
            arrowRigidbody.AddForce(attachPoint.forward * shootForce, ForceMode.Impulse);
            arrowRigidbody.useGravity = true;
            Destroy(arrow, arrowLife);
        }

        if (isMouseDown)
        {
            startForceMeter();
        }
        else
        {
            resetForceMeter();
        }
    }

    void startForceMeter() {
        float currentForce = slider.value;
        shootForce = currentForce + forceChangeSpeed * Time.deltaTime * 10;
        if (shootForce > slider.maxValue) {
            shootForce = slider.minValue;
        }
        slider.value = Mathf.Clamp(shootForce, slider.minValue, slider.maxValue);
        Debug.Log("Current Shoot Force" + shootForce);
    }

    void resetForceMeter() {
        shootForce = 0;
        slider.value = shootForce;
    }
}
