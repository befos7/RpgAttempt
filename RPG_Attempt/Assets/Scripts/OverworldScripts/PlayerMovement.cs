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

    
    public bool playerIsMoving;

    [SerializeField]
    public GameObject[] spawnArray;
    
    void Start()
    {
        targetPos = transform.position;
        positionSet = false;
        menuOpen = false;
        playerIsMoving = false;
        if (PersistantData.locationSaved)
        {
            this.transform.localPosition = PersistantData.playerLocation;
            PersistantData.locationSaved = false;
        }
        else
        {
            this.transform.localPosition = spawnArray[PersistantData.locationToSpawn].transform.position;
        }
        
        
    }

    
    

    private void FixedUpdate()
    {

        if (!menuOpen)
        {
            ArrowMovement();
            MouseMovement();

        }

        
    }

    private void MouseMovement()
    {
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {
            
            targetPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));// 

            positionSet = true;

        }
        if (Vector3.Distance(this.transform.position, targetPos) > 0.1f && positionSet == true)
        {
            playerIsMoving = true;
            transform.Translate((targetPos - transform.position).normalized * (moveSpeed * Time.fixedDeltaTime));

        }
        else if (Vector3.Distance(this.transform.position, targetPos) < 0.1f)
        {
            playerIsMoving = false;
            positionSet = false;


        }
    }

    private void ArrowMovement()
    {
        direction = Vector2.zero;
        directionX = 0f;
        directionY = 0f;
        playerIsMoving = false;
        if (Input.GetKey(KeyCode.W))
        {
            
            directionY = 1f;
            playerIsMoving = true;
            //positionSet = false;


        }
        if (Input.GetKey(KeyCode.D))
        {
            
            directionX = 1f;
            playerIsMoving = true;
            //positionSet = false;


        }
        if (Input.GetKey(KeyCode.S))
        {
           
            directionY = -1f;
            playerIsMoving = true;
            //positionSet = false;



        }
        if (Input.GetKey(KeyCode.A))
        {
           
            directionX = -1f;
            playerIsMoving = true;
            //positionSet = false;


        }
        direction = new Vector2(directionX, directionY);
        transform.Translate(direction * moveSpeed * Time.fixedDeltaTime);

    }


    
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerIsMoving = false;
        positionSet = false;
    }

}
