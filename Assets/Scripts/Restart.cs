using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CutOut.done)
        {
            GetComponent<CanvasGroup>().alpha = 1f;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (CutOut.done)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
