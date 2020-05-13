using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

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
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {
            //targetPos = -Vector3.one;
            targetPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));// 

            Debug.Log(targetPos);
            positionSet = true;

        }
        if (Vector3.Distance(this.transform.position, targetPos) > 0.1f && positionSet == true)
        {
            transform.Translate((targetPos - transform.position).normalized * (moveSpeed));

        }
        else if (Vector3.Distance(this.transform.position, targetPos) < 0.1f)
        {
            positionSet = false;


        }

        //
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(Vector3.Distance(this.transform.position, targetPos));
        }
        //

        ArrowMovement();

    }

    private void ArrowMovement()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        transform.Translate(direction * moveSpeed);

    }

    
    //public void OnPointerClick(PointerEventData data)
    //{
    //    Debug.Log(gameObject.name + ": I was clicked!");
    //}
    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
    

    
}
