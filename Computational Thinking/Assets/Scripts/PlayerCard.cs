using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCard : MonoBehaviour, IDropHandler
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
            }
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (battleSystem != null)
            {
                battleSystem.GetComponent<BattleSystemFinal>().playerGO = eventData.pointerDrag.gameObject;
            }
            else
            {
                tarefa.GetComponent<Tarefa02>().placed++;
                if (eventData.pointerDrag.gameObject.GetComponent<Winner>() != null)
                {
                    if ((this.vencedor == true && eventData.pointerDrag.gameObject.GetComponent<Winner>().vencedor == true) || this.vencedor == false && eventData.pointerDrag.gameObject.GetComponent<Winner>().vencedor == false)
                    {
                        eventData.pointerDrag.gameObject.GetComponent<Winner>().correto = true;
                    }
                    else
                    {
                        eventData.pointerDrag.gameObject.GetComponent<Winner>().correto = false;
                    }
                }
            }
           
        }
     
    }

}
