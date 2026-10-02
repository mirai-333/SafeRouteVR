using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class FadeScreen : MonoBehaviour
{
    public float fadeDuration = 2;
    public Color fadeColor;
    private Renderer rend;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        
    }

}
