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
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (eventData.pointerDrag.gameObject.GetComponent<CardDisplay>() != null)
            {
                if (tarefa.GetComponent<Tarefa06>() != null)
                { 
                    tarefa.GetComponent<Tarefa06>().placed++;
                }
                eventData.pointerDrag.gameObject.GetComponent<CardDisplay>().inPlace = true;
                eventData.pointerDrag.gameObject.GetComponent<CardDisplay>().isSel = true;
            }       
            if (battleSystem != null)
            {
                if (battleSystem.GetComponent<BattleSystemFinal>() != null)
                {
                    battleSystem.GetComponent<BattleSystemFinal>().playerGO = eventData.pointerDrag.gameObject;
                }
                else if (battleSystem.GetComponent<Tarefa01Battle>() != null)
                {
                    battleSystem.GetComponent<Tarefa01Battle>().playerGO = eventData.pointerDrag.gameObject;
                }
                else if (battleSystem.GetComponent<BattleSystem>() != null)
                {
                    battleSystem.GetComponent<BattleSystem>().playerGO = eventData.pointerDrag.gameObject;
                }
                else if (battleSystem.GetComponent<BattleSystemFin>() != null)
                {
                    battleSystem.GetComponent<BattleSystemFin>().playerGO = eventData.pointerDrag.gameObject;
                }
            }
            else if (tarefa.GetComponent<Tarefa02>() != null)
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
