using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blad : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject bladTrilPrefab;
    private GameObject TempBladPrefab;

    CircleCollider2D circleCollider2D;
    public float mainCurrentVelocity = 0.001f;

    Vector2 priviousPosition;

    Camera cam;
    public bool isBladActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCuting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }
        if (isBladActive)
        {
            UpdateCute();
        }
    }
    void UpdateCute()
    {
        Vector2 newwPos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newwPos;

        float velocity = (newwPos - priviousPosition).magnitude * Time.deltaTime;

        if (velocity > mainCurrentVelocity)
        {
            circleCollider2D.enabled = true;
        }
        else
        {
            circleCollider2D.enabled = false;
        }
        priviousPosition = newwPos;

    }
    void StartCuting()
    {
        isBladActive = true;
        TempBladPrefab = Instantiate(bladTrilPrefab, transform);
        priviousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider2D.enabled = false;

    }
    void StopCutting()
    {
        isBladActive = false;
        TempBladPrefab.transform.SetParent(null);
        Destroy(TempBladPrefab, 2f);
        circleCollider2D.enabled = false;
    }
}
