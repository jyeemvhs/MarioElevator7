using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverScript : MonoBehaviour
{
    private float startXLoc;
    public float speed = .05f;
    public float dist = 1;
    // Start is called before the first frame update
    void Start()
    {
        startXLoc = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed, 0, 0);
        float currDist = Mathf.Abs(transform.position.x - startXLoc);
        if (currDist > dist)
            speed = -speed;

    }
    
    void OnTriggerEnter(Collider other)
    {
        other.transform.GetComponent<MarioScript>().OnMover(transform);
    }
}
