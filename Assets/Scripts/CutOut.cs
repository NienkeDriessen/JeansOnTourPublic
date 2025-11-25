using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.TouchPhase;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CutOut : MonoBehaviour, IPointerDownHandler
{
    private CanvasGroup canvasGroup;
    GameObject[] jeansParts;
    Color darkGrey;
    public static bool done;
    Color beige = new Color(247f/255f, 236f/255f, 216f/255f);
    
    
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        jeansParts = GameObject.FindGameObjectsWithTag("JeansPart");
        darkGrey = new Color(20f/256f, 20f/256f, 20f/256f, 1f);
        done = false;
    }

    void Start()
    {
        done = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (canvasGroup.alpha == 1f)
        {
            Debug.Log("Clicked");
            cutOut();
        }
    }

    void cutOut()
    {
        foreach (GameObject jeanspart in jeansParts)
        {
            jeanspart.GetComponent<Image>().color = Color.white;
        }
        done = true;
    }
}
