using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody rb;
    private bool isAtCorrectPosition = false;
    public GameObject screwdriver;
    private float ogYPosition;
    public GameObject targetPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ogYPosition = transform.position.y;


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == screwdriver)
        {
            isAtCorrectPosition = true;
            Debug.Log("colliding");
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == screwdriver)
        {
            isAtCorrectPosition = false;
            Debug.Log("colliding");
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (isAtCorrectPosition)
        {


            // Calculate local position difference (relative to the object's position)
            float localYPosition = transform.localPosition.y;
            float targetYPosition = targetPos.transform.localPosition.y;

            // Only rotate and move if the object is above the target in local space
            if (localYPosition > targetYPosition)
            {
                // Rotate around the object's local forward axis (local space)
                transform.Rotate(Vector3.forward * 150f * Time.deltaTime, Space.Self); // Rotate in local space

                // Apply velocity in local space, moving the object relative to its orientation
                rb.velocity = transform.forward * -0.5f * Time.deltaTime;
            }
        }

        else
        {
            transform.Rotate(0, 0, 0);
            rb.velocity = Vector3.zero;
        }
    }
}
