using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screwdriver : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Screwdriver"))
        {
            transform.Rotate(Vector3.right * 100f * Time.deltaTime);
            transform.position += Vector3.down * 1f * Time.deltaTime;

        }
    }
    public void RotateScrewdriver()
    {
        Debug.Log("Working");
        transform.Rotate(Vector3.right * 100f * Time.deltaTime);
    }
}
