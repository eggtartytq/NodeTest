using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInfo : MonoBehaviour
{
    public enum Color {Red, Green, Blue, Yellow, Empty}

    public Color nodeColor;
    public int numOfResource;

    void OnMouseDown()
    {
        Debug.Log("I click it!");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
