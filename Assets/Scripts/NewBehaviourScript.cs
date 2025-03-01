using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody rb;
    private bool isAtCorrectPosition = false;
    public GameObject screwdriver;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

       
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == screwdriver)
        {
            isAtCorrectPosition = true;
            Debug.Log("colliding");
        }
        if (other.CompareTag("Screwdriver"))
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
            transform.Rotate(Vector3.forward * 100f * Time.deltaTime);

        }
        //transform.Rotate(Vector3.forward * 100f * Time.deltaTime);
        //transform.Rotate(Vector3.up * 100f * Time.deltaTime);
    }
}
