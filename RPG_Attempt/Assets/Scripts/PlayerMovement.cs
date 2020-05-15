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
    private float directionX, directionY;
    private float moveSpeed = 5f;

    private bool menuOpen;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        positionSet = false;
        menuOpen = false;
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
            transform.Translate((targetPos - transform.position).normalized * (moveSpeed * Time.fixedDeltaTime));

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
        if (!menuOpen)
        {
        ArrowMovement();

        }

    }

    private void ArrowMovement()
    {
        direction = Vector2.zero;
        directionX = 0f;
        directionY = 0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //direction = Vector2.up;
            directionY = 1f;


        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //direction = Vector2.right;
            directionX = 1f;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
           // direction = Vector2.down;
            directionY = -1f;


        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //direction = Vector2.left;
            directionX = -1f;

        }
        direction = new Vector2(directionX, directionY);
        transform.Translate(direction * moveSpeed * Time.fixedDeltaTime);

    }


    //public void OnPointerClick(PointerEventData data)
    //{
    //    Debug.Log(gameObject.name + ": I was clicked!");
    //}
    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public void StopMovement()
    {
        menuOpen = !menuOpen;
        direction = Vector2.zero;
        targetPos = transform.position;
    }
    

    
}
