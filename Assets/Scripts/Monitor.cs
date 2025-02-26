using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monitor : MonoBehaviour


{
    public Image displayImage; 
    public Sprite[] images; 
    private int currentIndex = 0;

    void Start()
    {
        if (images.Length > 0)
        {
            displayImage.sprite = images[currentIndex]; 
        }
    }

    public void NextImage()
    {
        if (images.Length == 0) return;

        currentIndex = (currentIndex + 1) % images.Length; 
        displayImage.sprite = images[currentIndex]; 
    }
}
