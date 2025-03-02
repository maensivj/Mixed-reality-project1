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
    // Update is called once per frame
    void Update()
    {
        if (isAtCorrectPosition)
        {
            
            
            if (transform.localPosition.y > targetPos.transform.localPosition.y)
            {
                Debug.Log("0");
                transform.Rotate(Vector3.forward * 150f * Time.deltaTime);
                Debug.Log("1");
                transform.position += new Vector3(0, -0.01f * Time.deltaTime, 0);
                Debug.Log("2");
            }

        }
        
    }
}
