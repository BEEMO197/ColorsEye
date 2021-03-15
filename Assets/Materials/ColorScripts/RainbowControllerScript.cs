using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowControllerScript : MonoBehaviour
{
    private float timer;
    private Material rainbowMat;
    private void Start()
    {
        rainbowMat = GetComponent<Renderer>().material;
        rainbowMat.SetInt("AtoB", 1);
    }
    private void Update()
    {
        rainbowMat.SetFloat("Time", timer);
        timer += Time.deltaTime;
        if (timer >= 1.0f)
        {
            timer = 0.0f;
            if(rainbowMat.GetInt("AtoB") == 1)
            {
                rainbowMat.SetInt("AtoB", 0);
                rainbowMat.SetInt("BtoC", 1);
            }
            else if(rainbowMat.GetInt("BtoC") == 1)
            {
                rainbowMat.SetInt("BtoC", 0);
                rainbowMat.SetInt("CtoA", 1);
            }
            else
            {
                rainbowMat.SetInt("CtoA", 0);
                rainbowMat.SetInt("AtoB", 1);
            }
        }
    }
}
