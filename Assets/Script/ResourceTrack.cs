//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ResourceTrack : MonoBehaviour
//{
//    public struct NodeResource
//    {
//        public ResourceInfo.NodeColor nodeColor;
//        public int nodeNum;
//    }
//    public NodeResource[] NodeList;
//    private BoardManager bm;
//    // Start is called before the first frame update
//    void Start()
//    {
//        bm = GetComponent<BoardManager>();
//        GetResourceInfo();
//    }

//    void GetResourceInfo()
//    {
//        for(int i = 0; i < 13; i++)
//        {
//            NodeList[i].nodeColor = bm.resourceList[i].GetComponent<ResourceInfo>().color;
//            NodeList[i].nodeNum = bm.resourceList[i].GetComponent<ResourceInfo>().numOfResource;
//            Debug.Log(NodeList[i].nodeColor);
//            Debug.Log(NodeList[i].nodeNum);
//        }
//    }
//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
