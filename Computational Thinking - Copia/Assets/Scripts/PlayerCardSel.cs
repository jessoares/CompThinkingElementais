using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCardSel : MonoBehaviour, IDropHandler
{
    public GameObject battleSystem;

    public bool vencedor;

    public GameObject tarefa;


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.gameObject.GetComponent<CardDisplay>() != null)
            {
                eventData.pointerDrag.gameObject.GetComponent<CardDisplay>().inPlace = true;
                eventData.pointerDrag.gameObject.GetComponent<CardDisplay>().isSel = true;
            }
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;              
        }
     
    }

}
