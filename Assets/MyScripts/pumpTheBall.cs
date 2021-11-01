using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpTheBall : MonoBehaviour
{
    public float myLevel;
    public GameObject ball;
    public float movespeed;
    public Rigidbody2D RGB;


    // Start is called before the first frame update
    void Start()
    {
        RGB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // Grab a reference to the GameObject holding the script that holds the variable we want to access

        //then access the variable
        myLevel = ball.GetComponent<ListenIn>().level;

        // Debug.Log("My Level" + myLevel);
        //Quick and dirty sphere scaling - the 10.0f is an arbitrary scaling factor
        if (myLevel > 0)
        {
            transform.position = new Vector3(10.0f * movespeed,0,0);
            if (myLevel > 0.5)
            {
                transform.position = new Vector3(0, myLevel* 1.0f ,0 );
            }
        }

    }
  
}
