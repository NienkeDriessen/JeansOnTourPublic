using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeansOnFabric : MonoBehaviour
{
    public Transform rectangleCenter; // The center of the rectangle
    public float rectangleWidth;// Width of the rectangle
    public float rectangleHeight;// Height of the rectangle
    public string objectTag = "JeansPart"; // Tag of the objects to check
    bool allPartsOnFabrics = true;
    public static int collision = 0;
    Bounds rectangleBounds;
    GameObject[] jeansParts;
    CanvasGroup finished;
    CanvasGroup cut;
    //BoxCollider denim;
    private int collisionCounter;


    void Start()
    {
        collisionCounter = 0;

        // Get all colliders with the specified tag
        jeansParts = GameObject.FindGameObjectsWithTag(objectTag);

        finished = (GameObject.Find("Finished")).GetComponent<CanvasGroup>();
        cut = (GameObject.Find("CutOut")).GetComponent<CanvasGroup>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionCounter++;
        //Debug.Log("collision counter is " + collisionCounter);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collisionCounter--;
        //Debug.Log("collision counter is " + collisionCounter);
    }

    // Update is called once per frame
    void Update()
    {
        allPartsOnFabrics = true;
        if (collisionCounter != 0)
        {
            allPartsOnFabrics = false;
            finished.alpha = 0f;
            cut.alpha = 0f;
        }
        foreach (GameObject jeansPart in jeansParts)
        {
            if (collision != 0)
            {
                allPartsOnFabrics = false;
                finished.alpha = 0f;
                cut.alpha = 0f;
            }
        }
        if (allPartsOnFabrics == true)
        {
            finished.alpha = 1f;
            cut.alpha = 1f;

        }
    }
}
