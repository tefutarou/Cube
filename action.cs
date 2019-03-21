using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class action : MonoBehaviour
{
    GameObject OnMouseObject;
    GameObject ClickObject;
    public GameObject parent;
    public GameObject child;
    Collider collision;
    bool a;
    bool b;
    bool c;
    public static bool only;

    Rotation Rotation;

    void Start()
    {
        Rotation = parent.GetComponent<Rotation>();
        parent.transform.DetachChildren();
        a = false;
        b = false;
        c = false;
        only = false;
    }

    public void OnMouse()
    {
        OnMouseObject = this.gameObject;
        Debug.Log(OnMouseObject + "を選択しますか？");

        c = true;
       
    }
    public void ExitMouse()
    {
        c = false;
    }

     void Update()
    {
        if (only==false&&c==true&&Input.GetMouseButton(0))
        {
            Debug.Log(OnMouseObject + "を選択しました。");
            
            b = true;
        }
        if (Input.GetMouseButton(1))
        {
            b = false;
            a = false;
            only = false;
        }
        if (a == true)
        {
            only = true;
            Rotation.Rot();
            
        }
    }


    void OnTriggerStay(Collider collision)
    {
        if (b == true)
        {
            string layerName = LayerMask.LayerToName(collision.gameObject.layer);
            if (layerName == "Cube")
            {
                child = collision.gameObject;
                child.transform.parent = parent.transform;
                a = true;
                // Debug.Log("接触");
            }
        }
        if (b == false)
        {
            parent.transform.DetachChildren();
           // Debug.Log("解除しました");
        }
        
    }


}
