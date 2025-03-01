using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Scaler : MonoBehaviour
{
    // List of objects to scale
    public List<GameObject> gameObjects = new List<GameObject>();

    // UI slider reference
    public Slider slider;

    // Dictionary to store original scales
    private Dictionary<GameObject, Vector3> originalScales = new Dictionary<GameObject, Vector3>();

    void Start()
    {
        saveOriginalScales();
    }

    void Update()
    {
        float sliderValue = 1f + slider.value;
        if (sliderValue != 1f)
        {
            foreach (GameObject obj in gameObjects)
            {
                obj.transform.localScale = originalScales[obj] * sliderValue;
            }
        }
    }

    void saveOriginalScales()
    {
        foreach (GameObject obj in gameObjects)
        {
            originalScales[obj] = obj.transform.localScale;
        }
    }
}
