using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCard : MonoBehaviour, IDropHandler
{
    public GameObject BattleSystem;
    public GameObject player;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            BattleSystem.GetComponent<BattleSystem>().playerGO = eventData.pointerDrag.gameObject;
  

        }
    }

}
