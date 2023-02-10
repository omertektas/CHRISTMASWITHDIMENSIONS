using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1 : MonoBehaviour
{
    
    Transform myTransform, camTransform;
    Rigidbody2D myRigidbody;    
    Vector2 targetPosition;
    bool clickable = true;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myTransform = transform;
        camTransform = Camera.main.transform;      
        
    }
    private void OnMouseDrag()
    {
        if (clickable)
        {
            myRigidbody.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -camTransform.position.z-3.33f));
        }

    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            Debug.Log("ok");
        }
    }
}
