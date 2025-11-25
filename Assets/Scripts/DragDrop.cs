using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.TouchPhase;
using UnityEngine.EventSystems;


public class DragDrop : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler 
{

    int pointerCount = 0;
    List<Touch> touches = new List<Touch>();
    private Transform _target;
    private Vector2 _startPosition;
    Collider2D jeanspart;

    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        jeanspart = GetComponent<Collider2D>();
    }

    public void OnPointerDown(PointerEventData eventData){
        //Debug.Log("OnPointerDown");
        pointerCount++;
        Debug.Log(pointerCount);
    }

    public void OnPointerUp(PointerEventData eventData){
        //Debug.Log("OnPointerUp");
        pointerCount--;
        Debug.Log(pointerCount);
    }

    public void OnBeginDrag(PointerEventData eventData){
        if (!CutOut.done)
        {
            canvasGroup.alpha = .5f;
            canvasGroup.blocksRaycasts = false;
            //Debug.Log("OnBeginDrag");
        }
    }

    public void OnEndDrag(PointerEventData eventData){
        //Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData){
        if (pointerCount == 1 && !CutOut.done){
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
            //Debug.Log("OnDrag");
        }
    }
    

    private static bool AnyTouchMoved(ref Touch touchOne, ref Touch touchTwo) =>
        touchOne.phase == Moved || touchTwo.phase == Moved;

    private static bool AnyTouchBegan(ref Touch touchOne, ref Touch touchTwo) =>
        touchOne.phase == Began || touchTwo.phase == Began;

    void Update(){
        if (!CutOut.done)
        {
            touches.Clear();
            if (pointerCount == 2)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch touch = Input.GetTouch(i);
                    if (jeanspart.bounds.Contains(touch.position))
                    {
                        touches.Add(touch);
                    }
                }
                var touchOne = touches[0];
                var touchTwo = touches[1];

                if (AnyTouchBegan(ref touchOne, ref touchTwo))
                {
                    _startPosition = touchTwo.position - touchOne.position;
                }

                if (AnyTouchMoved(ref touchOne, ref touchTwo))
                {
                    var currVector = touchTwo.position - touchOne.position;
                    var angle = Vector2.SignedAngle(_startPosition, currVector);
                    rectTransform.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rectTransform.transform.rotation.eulerAngles.z + angle);
                    _startPosition = currVector;
                }
            }
        }
    }

}
