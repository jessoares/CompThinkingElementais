using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public GameObject battleSystem;
    public GameObject tarefa;
     

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        if (eventData.pointerDrag.gameObject.GetComponent<CardDisplay>() != null)
        {
            if (eventData.pointerDrag.gameObject.GetComponent<CardDisplay>().inPlace == true)
            {
                battleSystem.GetComponent<BattleSystemFinal>().playerGO = null;
                eventData.pointerDrag.gameObject.GetComponent<CardDisplay>().inPlace = false;
            }
        }
        else
        {
            tarefa.GetComponent<Tarefa02>().placed--;
            if (tarefa.GetComponent<Tarefa02>().placed <= 0)
            {
                tarefa.GetComponent<Tarefa02>().placed = 0;
            }
                
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
    
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
   

}
