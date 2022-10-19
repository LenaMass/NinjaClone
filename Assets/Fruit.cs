using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Fruit : MonoBehaviour
{ 
 public GameObject Slicedprefab; 
 Rigidbody2D rb;
 public float startForce = 15f; 

 private void Start()
 {
   rb = GetComponent<Rigidbody2D>();
   rb.AddForce(transform.up *startForce, ForceMode2D.Impulse);
 }

 void OnTriggerEnter2D(Collider2D col)
  {
    if (col.CompareTag("Sword"))
    {
      Vector3 direction = (col.transform.position - transform.position).normalized;
      Quaternion rotation = Quaternion.LookRotation(direction);
      Instantiate(Slicedprefab, transform.position, rotation);
      //Debug.Log("Hit!!!");
      Destroy(gameObject);
    }
  }
}
