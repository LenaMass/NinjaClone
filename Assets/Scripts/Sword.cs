using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private bool isCutting = false;
    
    Rigidbody2D Rb; 
    
    Camera cam;

    private CircleCollider2D CircleCollider;
    
    private GameObject currentTrail;

    public GameObject Sprefab;

    private Vector2 oldPossition;

    public float minCutVelocity = .001f;
    void Start()
    {
        cam = Camera.main;
        
        Rb = GetComponent<Rigidbody2D>();

        CircleCollider = GetComponent<CircleCollider2D>();

    }

    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut();
        }
        
    }

    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Rb.position = newPosition;

        float velocity = (newPosition - oldPossition).magnitude * Time.deltaTime;
        if (velocity > minCutVelocity)
        {
            CircleCollider.enabled = true;
        }
        else
        {
            CircleCollider.enabled = false;
        }

        oldPossition = newPosition;

    }
    void StartCutting ()
    {
        isCutting = true;
        currentTrail = Instantiate(Sprefab, transform);
        oldPossition = cam.ScreenToWorldPoint(Input.mousePosition);
        CircleCollider.enabled = false;
        

    }

    void StopCutting ()
    {
        isCutting = false;
        currentTrail.transform.SetParent(null);
        Destroy(currentTrail, 1f);
        CircleCollider.enabled = false;
    }
}
