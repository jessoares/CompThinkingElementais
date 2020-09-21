using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCard : MonoBehaviour, IDropHandler
{
    public GameObject BattleSystem;
    public PointerEventData eventData2;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData2 = eventData;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            BattleSystem.GetComponent<BattleSystem>().playerGO = eventData.pointerDrag.gameObject;
        }
        else
        {
            eventData2 = eventData;
            BattleSystem.GetComponent<BattleSystem>().playerGO = null;
        }
    }

}
