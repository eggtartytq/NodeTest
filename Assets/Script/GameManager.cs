using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private BoardManager boardScript;
    //ivate ResourceTrack RT;
    // Start is called before the first frame update
    void Awake()
    {
        boardScript = GetComponent<BoardManager>();
        // = GetComponent<ResourceTrack>();
        InitGame();

        Debug.Log(boardScript.resourceList[3].GetComponent<ResourceInfo>().nodeColor);
        Debug.Log(boardScript.resourceList[3].GetComponent<ResourceInfo>().numOfResource);


    }
    void InitGame()
    {
        boardScript.SetupScene();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
