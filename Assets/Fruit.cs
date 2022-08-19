using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject froutsPrefabs;
    Rigidbody2D rb;
    public float speed = 15f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "blad")
        {
            Vector3 driction = (col.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(driction);
          //  Debug.Log("blad");
            GameObject ff = Instantiate(froutsPrefabs, transform.position, rotation);
            Destroy(ff, 2f);
            Destroy(gameObject);
        }
    }
}
