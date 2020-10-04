using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCard : MonoBehaviour, IDropHandler
{
    public GameObject battleSystem;


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.gameObject.GetComponent<CardDisplay>().inPlace = true;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            battleSystem.GetComponent<BattleSystem>().playerGO = eventData.pointerDrag.gameObject;
        }
     
    }

}
