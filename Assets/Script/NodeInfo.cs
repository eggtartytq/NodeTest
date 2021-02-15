using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class NodeInfo : MonoBehaviour
{
    private GameObject gm;
    private int cc;
    public enum Owner
    {
        Nil = 0,
        US = 1,
        USSR = 2
    }
    public Owner nodeOwner = Owner.Nil;
    public int nodeOrder;

    void OnMouseDown()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(200,0,100);
        this.gameObject.GetComponent<NodeInfo>().nodeOwner = Owner.USSR;
        cc = this.gameObject.GetComponent<NodeInfo>().nodeOrder;
        Debug.Log(this.gameObject.GetComponent<NodeInfo>().nodeOrder);
        Debug.Log(this.gameObject.GetComponent<NodeInfo>().nodeOwner);
        GameObject.FindObjectOfType<BoardManager>().ChangeNodeOwner(cc);
        
    }
    private void Start()
    {
        gm = GameObject.Find("GameManager");
    }
    void Update()
    {
       
    }
}
