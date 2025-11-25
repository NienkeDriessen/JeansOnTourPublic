using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBox : MonoBehaviour
{
    GameObject[] jeansParts;
    public GameObject leftBound;
    public GameObject rightBound;
    public GameObject upperBound; 
    public GameObject lowerBound;
    public GameObject jeansFabric;
    public GameObject stof; 
    public float percentage;
    RectTransform rectTransform;
    Collider2D objectCollider;
    Bounds jeansBounds;
    float minX, maxX, minY, maxY;
    float fabricLeft, fabricRight, fabricUp, fabricLow;
    bool fabricSet = false;

    // Start is called before the first frame update
    void Start()
    {
        minX = minY = float.MaxValue;
        maxX = maxY = float.MinValue;
        jeansParts = GameObject.FindGameObjectsWithTag("JeansPart");
        
    }

    // Update is called once per frame
    void Update()
    {
        //Bereken de bounds waarin alle stukken broek liggen
        minX = minY = float.MaxValue;
        maxX = maxY = float.MinValue;
        foreach (GameObject jeansPart in jeansParts)
        {
            objectCollider = jeansPart.GetComponent<Collider2D>();
            jeansBounds = objectCollider.bounds;
            if (minX > (jeansBounds.center.x - jeansBounds.extents.x)) {
                minX = jeansBounds.center.x - jeansBounds.extents.x;
            }
            if (maxX < (jeansBounds.center.x + jeansBounds.extents.x))
            {
                maxX = jeansBounds.center.x + jeansBounds.extents.x;
            }
            if (minY > (jeansBounds.center.y - jeansBounds.extents.y))
            {
                minY = jeansBounds.center.y - jeansBounds.extents.y;
            }
            if (maxY < (jeansBounds.center.y + jeansBounds.extents.y))
            {
                maxY = jeansBounds.center.y + jeansBounds.extents.y;
            }
        }
        //Bepaal eenmalig waar de randen van de denimstof liggen
        if (!fabricSet)
        {
            //objectCollider = jeansFabric.GetComponent<Collider2D>();
            objectCollider = stof.GetComponent<Collider2D>();
            fabricLeft = objectCollider.bounds.center.x - objectCollider.bounds.extents.x;
            fabricRight = objectCollider.bounds.center.x + objectCollider.bounds.extents.x;
            fabricUp = objectCollider.bounds.center.y + objectCollider.bounds.extents.y;
            fabricLow = objectCollider.bounds.center.y - objectCollider.bounds.extents.y;
            fabricSet = true; 
        }

        //Als de stukken buiten de stof liggen, zet de bounds op de stof 
        if (minX < fabricLeft)
        {
            minX = fabricLeft;
        }
        if (maxX > fabricRight)
        {
            maxX = fabricRight;
        }
        if (maxY > fabricUp)
        {
            maxY = fabricUp;
        }
        if (minY < fabricLow)
        {
            minY = fabricLow;
        }
        //Transform de lijnen naar de bounds waarbinnen de stukken liggen 

        calculatePercentage();
        leftBound.transform.position = new Vector3(minX, leftBound.transform.position.y, leftBound.transform.position.z); 
        rightBound.transform.position = new Vector3(maxX, rightBound.transform.position.y, rightBound.transform.position.z); 
        upperBound.transform.position = new Vector3(upperBound.transform.position.x, maxY, upperBound.transform.position.z);
        lowerBound.transform.position = new Vector3(lowerBound.transform.position.x, minY, lowerBound.transform.position.z);
    }

    void calculatePercentage()
    {
        float total = (fabricRight - fabricLeft) * (fabricUp - fabricLow);
        float current = (maxX - minX) * (maxY - minY);
        percentage = 100 - ((current / total) * 100);

    }
}
