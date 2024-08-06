using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit : MonoBehaviour{

Rigidbody2D rb;
public float startForce = 15f;

    void Start(){

        rb= GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    public GameObject fruitSlicedPrefab;
   void OnTriggerEnter2D(Collider2D col){
    
    if(col.tag =="Blade"){

        Vector3 direction= (col.transform.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
        Destroy(slicedFruit,3f);
        Destroy(gameObject);
    }
   }
}
