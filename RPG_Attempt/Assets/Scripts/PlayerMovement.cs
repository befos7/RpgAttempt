using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 targetPos;

   
    private Vector2 direction;
    private float moveSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //targetPos = -Vector3.one;
        //    //targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));// 
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit2D hit;
        //    if (Physics2D.Raycast(Camera.main, Camera.main.ScreenPointToRay(Input.mousePosition));
        //    {

        //    }

        //    this.transform.position = targetPos;
        //}
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
