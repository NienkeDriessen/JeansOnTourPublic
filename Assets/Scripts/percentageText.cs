using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class percentageText : MonoBehaviour
{
    public GameObject tekstbespaard;
    CanvasGroup canvasGroup; 
    public TMP_Text textToDisplay;
    GameObject bounds;
    public static float percentage;
    // Start is called before the first frame update
    void Start()
    {
        bounds = GameObject.Find("Bounds");
        textToDisplay.text = "";
        canvasGroup = tekstbespaard.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        percentage = bounds.GetComponent<BoundingBox>().percentage;
        if (percentage <= 0)
        {
            textToDisplay.SetText("");
            canvasGroup.alpha = 0;
        }
        else
        {
            textToDisplay.SetText((Mathf.Round(percentage)).ToString() + "%");
            canvasGroup.alpha = 1; 
        }
    }
}
