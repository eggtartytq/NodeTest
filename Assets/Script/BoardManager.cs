using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    public struct NodeResource
    {
        public ResourceInfo.Color nodeColor;
        public int nodeNum;
        //safe the location
        public int xLoc; 
        public int yLoc;
    }
    public int columns = 11;
    public int rows = 11;
    public GameObject node;
    public GameObject hengBranch;
    public GameObject shuBranch;
    public GameObject[] resourceList;
    public GameObject[] nodeList;
    public NodeResource[] ResourceInfoList = new NodeResource[13];
    /*
     * X = empty; N = node; H = heng branch; S = shu branch; R = resource
     */
    char[,] GameBoard = new char[11,11]
    {
        {'X', 'X', 'X', 'X', 'N', 'H', 'N', 'X', 'X', 'X', 'X'},
        {'X', 'X', 'X', 'X', 'S', 'R', 'S', 'X', 'X', 'X', 'X'},
        {'X', 'X', 'N', 'H', 'N', 'H', 'N', 'H', 'N', 'X', 'X'},
        {'X', 'X', 'S', 'R', 'S', 'R', 'S', 'R', 'S', 'X', 'X'},
        {'N', 'H', 'N', 'H', 'N', 'H', 'N', 'H', 'N', 'H', 'N'},
        {'S', 'R', 'S', 'R', 'S', 'R', 'S', 'R', 'S', 'R', 'S'},
        {'N', 'H', 'N', 'H', 'N', 'H', 'N', 'H', 'N', 'H', 'N'},
        {'X', 'X', 'S', 'R', 'S', 'R', 'S', 'R', 'S', 'X', 'X'},
        {'X', 'X', 'N', 'H', 'N', 'H', 'N', 'H', 'N', 'X', 'X'},
        {'X', 'X', 'X', 'X', 'S', 'R', 'S', 'X', 'X', 'X', 'X'},
        {'X', 'X', 'X', 'X', 'N', 'H', 'N', 'X', 'X', 'X', 'X'},
    };

    private int resourceCount = 0;
    private int nodeCount = 0;
    //private int branchCount = 0;
    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();
    private ResourceInfo.Color tempColor;
    private int tempNum;
   
    void Shuffle(GameObject[] resourceList)
    {
        int randomNum;
        GameObject temp;
        for(int i = 0; i < resourceList.Length; i++)
        {
            temp = resourceList[i];
            randomNum = Random.Range(0, resourceList.Length);
            resourceList[i] = resourceList[randomNum];
            resourceList[randomNum] = temp;
        }
    }

 

    void BoardSetUp(char[,] Map)
    {
        boardHolder = new GameObject("Board").transform;
        GameObject instance;
        int hang = -40;
        int lie = -30;
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                switch(Map[x ,y])
                {
                    case 'R':
                        instance = Instantiate(resourceList[resourceCount], new Vector3(hang + 5 * x, lie + 5 * y, 0f), Quaternion.identity) as GameObject;
                        instance.transform.SetParent(boardHolder);
                        ResourceInfoList[resourceCount].nodeColor = resourceList[resourceCount].GetComponent<ResourceInfo>().nodeColor;
                        ResourceInfoList[resourceCount].nodeNum = resourceList[resourceCount].GetComponent<ResourceInfo>().numOfResource;
                        ResourceInfoList[resourceCount].xLoc = hang + 5 * x;
                        ResourceInfoList[resourceCount].yLoc = lie + 5 * y;
                        resourceCount++;
                        break;
                    case 'N':
                        instance = Instantiate(nodeList[nodeCount], new Vector3(hang + 5 * x, lie + 5 * y, 0f), Quaternion.identity) as GameObject;
                        instance.transform.SetParent(boardHolder);
                        nodeList[nodeCount].GetComponent<NodeInfo>().nodeOwner = NodeInfo.Owner.Nil;
                        nodeList[nodeCount].GetComponent<NodeInfo>().nodeOrder = nodeCount;
                        nodeCount++;
                        break;
                    case 'H':
                        instance = Instantiate(hengBranch, new Vector3(hang + 5 * x, lie + 5 * y, 0f), Quaternion.identity) as GameObject;
                        instance.transform.SetParent(boardHolder);
                        break;
                    case 'S':
                        instance = Instantiate(shuBranch, new Vector3(hang + 5 * x, lie + 5 * y, 0f), Quaternion.identity) as GameObject;
                        instance.transform.SetParent(boardHolder);
                        break;
                    default:
                        //Debug.Log(Map[x,y]);
                        break;
                }
            }
        }
    }
   void GetInfoForResource()
    {

        for(int i = 0; i < resourceList.Length; i++)
        {
            tempColor = resourceList[i].GetComponent<ResourceInfo>().nodeColor;
            tempNum = resourceList[i].GetComponent<ResourceInfo>().numOfResource;
            ResourceInfoList[i].nodeColor = tempColor;
            ResourceInfoList[i].nodeNum = tempNum;
            
        }
    }
    public void SetupScene()
    {
        gridPositions.Clear();
        Shuffle(resourceList);
        //GetInfoForResource();
        BoardSetUp(GameBoard);
    }

    public void ChangeNodeOwner(int nodeNum)
    {
        nodeList[nodeNum].GetComponent<NodeInfo>().nodeOwner = NodeInfo.Owner.USSR;
        //Debug.Log(nodeNum);
        //Debug.Log(nodeList[nodeNum].GetComponent<NodeInfo>().nodeOrder);
        /*
        for(int i = 0; i < 24; i++)
        {
            Debug.Log(nodeList[i].GetComponent<NodeInfo>().nodeOwner);
        }
        */
    }
}
