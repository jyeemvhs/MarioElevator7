using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    private float startYLoc;
    public float speed = .05f;
    public float dist = 1;
    // Start is called before the first frame update
    void Start()
    {
        startYLoc = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed, 0);
        float currDist = Mathf.Abs(transform.position.y - startYLoc);
        if (currDist > dist)
            speed = -speed;
    }


    void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter");
        other.transform.GetComponent<MarioScript>().OnMover(transform);
    }
}
