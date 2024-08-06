using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Blade : MonoBehaviour{

    public int counter;
    public Vector3 lastposition;
    public float minCuttingVelocity = 0.001f;
    Vector2 previousPosition;
    public GameObject bladeTrailPrefab;
    bool isCutting = false;
    public Text scoreText;
    Camera cam;
    Rigidbody2D rb;
    GameObject currentBladeTrail;
    CircleCollider2D circleCollider;
    int scoreCounter = 0;
    void Start(){

        cam=Camera.main;
        rb= GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }
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
        if (counter > 5)

        {
            counter = 0;
            lastposition = transform.position;
        }
        counter++;

        // Skoru güncelle
        scoreText.text = "Score: " + scoreCounter;
    }

    

    void UpdateCut(){

        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;
        float velocity = (newPosition - previousPosition).magnitude*Time.deltaTime;
        if (velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else 
        { 
            circleCollider.enabled=false;
        }

        previousPosition = newPosition;
        
    }

    void StartCutting(){

        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab,transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;
        scoreCounter++;

       

    
       
    }

    void StopCutting(){

       isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail,2f);
        circleCollider.enabled = false;
       
    }       
     public Vector3 getcurrentcutdirection()
    {
        return transform.position - lastposition;
    }


     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fruit"))
        {
            scoreCounter++;
            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("Bomb"))
        {
            scoreCounter = 0;
            Destroy(collision.gameObject);
        }
    }
}
