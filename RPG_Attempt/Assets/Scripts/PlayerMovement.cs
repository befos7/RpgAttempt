using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 targetPos;
    private bool positionSet;
   
    private Vector2 direction;
    private float moveSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        positionSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //targetPos = -Vector3.one;
            targetPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));// 
            
            Debug.Log(targetPos);
            positionSet = true;
            
        }
        if (Vector3.Distance(this.transform.position, targetPos) > 0.1f  && positionSet == true)
        {
            transform.Translate((targetPos - transform.position).normalized * (moveSpeed));

        }
        else if(Vector3.Distance(this.transform.position, targetPos) < 0.1f)
        {
            positionSet = false;


        }

        //
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(Vector3.Distance(this.transform.position, targetPos));
        }
        //

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector2.up;
            transform.Translate(direction * moveSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
            transform.Translate(direction * moveSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector2.down;
            transform.Translate(direction * moveSpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
            transform.Translate(direction * moveSpeed);
        }


    }

    private void OnMouseDown()
    {
      
    }
}
