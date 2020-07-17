using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DamagePopupText : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disTimer;
    private Color textColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        textColor = textMesh.color;
        disTimer = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        disTimer -= Time.deltaTime;
        if (disTimer < 0)
        {
            float disSpeed = 3f;
            textColor.a -= disSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
