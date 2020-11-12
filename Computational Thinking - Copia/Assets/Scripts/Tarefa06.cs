using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Tarefa06 : MonoBehaviour
{
    public ParticleSystem fireParticle;
    public Transform fireParticlePosition;
    public GameObject battleSystem;
    public CanvasEffects Canvas;
    public DialogueManager manager;

    public int count;
    public Transform attackPoint1;
    public Transform attackPoint2;
    public Transform attackPoint3;
    public Transform attackPoint4;
    public PlayerStats playerStats;
    public EnemyStats enemyStats;
    CardDisplay playerHUD;
    CardDisplay enemyHUD;
    public GameObject enemyPrefab;
    public Card playerUnit;
    public Card enemyUnit;
    float nextSentenceTime = 0f;
    public float sentenceRate;
    public GameObject opponent1;
    public GameObject opponent2;
    public GameObject card;
    public GameObject card2;
    public GameObject[] playerCards;
    public GameObject[] selCards;
    public GameObject attackButton;
    public GameObject nextButton;
    public GameObject  selButton;
    public GameObject textBox;
    public GameObject enemyCardPos;
    public GameObject playerCardSel;
    string sentence;
    public bool isQuestion;
    public Card tocha;
    public Card marinho;
    public Card Carnivora;
    public int numberOfCards;
    public Card[] tsunami;
    public Card[] torrao;
    public Card[] rochoso;
    public Card[] fogareu;
    public Card[] eletron;
    public Card figueira;
    public Card trovoada;
    public int mestre;
    public GameObject mapBackground;
    public GameObject vulcao;
    public GameObject mar;
    public GameObject caverna;
    public GameObject arvore;
    public GameObject montanha;
    public GameObject usina;
    public GameObject estacao;
    public GameObject vulcaoButton;
    public GameObject marButton;
    public GameObject cavernaButton;
    public GameObject arvoreButton;
    public GameObject montanhaButton;
    public GameObject usinaButton;
    public GameObject estacaoButton;
    public bool usinaDone;
    public bool estacaoDone;
    public bool marDone;
    public bool vulcaoDone;
    public bool arvoreDone;
    public bool cavernaDone;
    public bool MontanhaDone;


    public GameObject centro;
    public GameObject[] place;

    public GameObject pointers;
    public GameObject dice;

    public Image diceImage;
    public Sprite[] diceSides;

    public int placed;

    public void Start()
    {
        nextSentenceTime = Time.time + 1f / sentenceRate;
        isQuestion = false;
        count = 55;
        numberOfCards = 3;
        usinaDone = true;
        estacaoDone = true;
        marDone = true;
        vulcaoDone = true;
        arvoreDone = true;
        cavernaDone = true;
        MontanhaDone = true;

    }
    public void Update()
    {
        if (Time.time >= nextSentenceTime && isQuestion == false)
        {
            nextButton.SetActive(true);
        }
    }
    public void BattleEnd()
    {
        if (battleSystem.GetComponent<BattleSystemFinal>().battleOver == true)
        {
            for (int i = 0; i < numberOfCards; i++)
            {
                playerCards[i].SetActive(false);
             }
                if (usinaDone == true && arvoreDone == true)
            {
                manager.GetComponent<DialogueManager>().DialogueText.text = "Parabéns!!! Você é o melhor mestre elemental!!!";
            }
            opponent1.SetActive(false);
            enemyCardPos.SetActive(false);
            textBox.SetActive(true);
            attackButton.SetActive(false);
            if (battleSystem.GetComponent<BattleSystemFinal>().battleWon == true)
            {
                if (mestre == 1)
                {
                    marDone = true;
                    playerCards[numberOfCards].SetActive(true);
                    playerCards[numberOfCards].GetComponent<RectTransform>().anchoredPosition = centro.GetComponent<RectTransform>().anchoredPosition;
                    manager.GetComponent<DialogueManager>().DialogueText.text = "Você derrotou o mestre da praia e adquiriu uma  carta!";
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<CardDisplay>().card = tsunami[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().card = tsunami[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().SetHp();
                    numberOfCards++;
                    mapBackground.SetActive(true);
                    mar.SetActive(false);
                }
                if (mestre == 2)
                {
                    cavernaDone = true;
                    playerCards[numberOfCards].SetActive(true);
                    playerCards[numberOfCards].GetComponent<RectTransform>().anchoredPosition = centro.GetComponent<RectTransform>().anchoredPosition;
                    manager.GetComponent<DialogueManager>().DialogueText.text = "Você derrotou o mestre da caverna e adquiriu esta carta!";
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<CardDisplay>().card = torrao[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().card = torrao[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().SetHp();
                    numberOfCards++;
                    mapBackground.SetActive(true);
                    caverna.SetActive(false);
                }
                if (mestre == 3)
                {
                    MontanhaDone = true;
                    playerCards[numberOfCards].SetActive(true);
                    playerCards[numberOfCards].GetComponent<RectTransform>().anchoredPosition = centro.GetComponent<RectTransform>().anchoredPosition;
                    manager.GetComponent<DialogueManager>().DialogueText.text = "Você derrotou o mestre da montanha e adquiriu esta carta!";
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<CardDisplay>().card = rochoso[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().card = rochoso[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().SetHp();
                    numberOfCards++;
                    mapBackground.SetActive(true);
                    montanha.SetActive(false);
                }
                if (mestre == 4)
                {
                    vulcaoDone = true;
                    playerCards[numberOfCards].SetActive(true);
                    playerCards[numberOfCards].GetComponent<RectTransform>().anchoredPosition = centro.GetComponent<RectTransform>().anchoredPosition;
                    manager.GetComponent<DialogueManager>().DialogueText.text = "Você derrotou o mestre do vulcão e adquiriu esta carta!";
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<CardDisplay>().card = fogareu[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().card = fogareu[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().SetHp();
                    numberOfCards++;
                    mapBackground.SetActive(true);
                    vulcao.SetActive(false);
                }
                if (mestre == 5)
                {
                    estacaoDone = true;
                    playerCards[numberOfCards].SetActive(true);
                    playerCards[numberOfCards].GetComponent<RectTransform>().anchoredPosition = centro.GetComponent<RectTransform>().anchoredPosition;
                    manager.GetComponent<DialogueManager>().DialogueText.text = "Você derrotou o mestre da sub-estação e adquiriu esta carta!";
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<CardDisplay>().card = eletron[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().card = eletron[1];
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().SetHp();
                    numberOfCards++;
                    mapBackground.SetActive(true);
                    estacao.SetActive(false);
                }
                if (mestre == 6)
                {
                    arvoreDone = true;
                    playerCards[numberOfCards].SetActive(true);
                    playerCards[numberOfCards].GetComponent<RectTransform>().anchoredPosition = centro.GetComponent<RectTransform>().anchoredPosition;
                    manager.GetComponent<DialogueManager>().DialogueText.text = "Você derrotou o mestre da árvore e adquiriu esta carta!";
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<CardDisplay>().card = figueira;
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().card = figueira;
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().SetHp();
                    numberOfCards++;
                    mapBackground.SetActive(true);
                    arvore.SetActive(false);
                }
                if (mestre == 7)
                {
                    usinaDone = true;
                    playerCards[numberOfCards].SetActive(true);
                    playerCards[numberOfCards].GetComponent<RectTransform>().anchoredPosition = centro.GetComponent<RectTransform>().anchoredPosition;
                    manager.GetComponent<DialogueManager>().DialogueText.text = "Você derrotou o mestre da usina e adquiriu esta carta!";
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<CardDisplay>().card = trovoada;
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().card = trovoada;
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[numberOfCards].GetComponent<PlayerStats>().SetHp();
                    numberOfCards++;
                    usina.SetActive(false);
                    mapBackground.SetActive(true);
                }
            }
            else
            {
                manager.GetComponent<DialogueManager>().DialogueText.text = "Parece que você perdeu dessa vez, mas não desista!";
            }
            vulcaoButton.SetActive(true);
            marButton.SetActive(true);
            arvoreButton.SetActive(true);
            estacaoButton.SetActive(true);
            usinaButton.SetActive(true);
            cavernaButton.SetActive(true);
            montanhaButton.SetActive(true);
            textBox.SetActive(true);
            


        }
    }
  
    public void NextSceneScript()
    {
        nextSentenceTime = Time.time + 1f / sentenceRate;
        nextButton.SetActive(false);
        count--;   
        if (count == 30)
        {
            nextButton.SetActive(false);
            textBox.SetActive(false);
            isQuestion = true;
            textBox.SetActive(false);
            nextButton.SetActive(false);
            usinaDone = false;
            estacaoDone = false;
            marDone = false;
            vulcaoDone = false;
            arvoreDone = false;
            cavernaDone = false;
            MontanhaDone = false;
            isQuestion = true;
            playerCards[0].SetActive(false);
            playerCards[1].SetActive(false);
            playerCards[2].SetActive(false);
            playerCards[0].GetComponent<RectTransform>().anchoredPosition = place[0].GetComponent<RectTransform>().anchoredPosition;
            playerCards[1].GetComponent<RectTransform>().anchoredPosition = place[1].GetComponent<RectTransform>().anchoredPosition;
            playerCards[2].GetComponent<RectTransform>().anchoredPosition = place[2].GetComponent<RectTransform>().anchoredPosition;
        }
        if (count == 32)
        {
            playerCards[0].SetActive(true);
            playerCards[1].SetActive(true);
            playerCards[2].SetActive(true);
            
        }
        if (count == 35)
        {
            card.SetActive(false);
            card2.SetActive(false);
            opponent1.SetActive(false);
            enemyCardPos.SetActive(false);
            dice.SetActive(false);
           

        }
        if (count == 36)
        {
            diceImage.sprite = diceSides[5];
            card2.GetComponent<CardDisplay>().card = marinho;
            card2.GetComponent<CardDisplay>().SetCard();
            enemyUnit = card2.GetComponent<CardDisplay>().card;
            enemyHUD = card2.GetComponent<CardDisplay>();
            enemyStats = card2.GetComponent<EnemyStats>();
            enemyStats.SetStats();
            StartCoroutine(ElementalAttack3());
            StartCoroutine(ElementalAttack2Damage(2*playerUnit.damage));
            sentenceRate = 0.7f;
        }
        if (count == 37)
        {
            diceImage.sprite = diceSides[3];
            card2.GetComponent<CardDisplay>().card = tocha;
            card2.GetComponent<CardDisplay>().SetCard();
            enemyUnit = card2.GetComponent<CardDisplay>().card;
            enemyHUD = card2.GetComponent<CardDisplay>();
            enemyStats = card2.GetComponent<EnemyStats>();
            enemyStats.SetStats();
            StartCoroutine(ElementalAttack3());
            StartCoroutine(ElementalAttack2Damage(2*playerUnit.damage));
        }
        if (count == 38)
        {
            diceImage.sprite = diceSides[1];
            card.SetActive(true);
            opponent1.SetActive(true);
            opponent2.SetActive(true);
            card.GetComponent<RectTransform>().anchoredPosition = opponent1.GetComponent<RectTransform>().anchoredPosition;
            card2.SetActive(true);
            card2.GetComponent<RectTransform>().anchoredPosition = opponent2.GetComponent<RectTransform>().anchoredPosition;
            enemyUnit = card2.GetComponent<CardDisplay>().card;
            enemyUnit.currentHP = enemyUnit.maxHP;
            enemyHUD = card2.GetComponent<CardDisplay>();
            enemyStats = card2.GetComponent<EnemyStats>();
            enemyStats.SetStats();
            playerUnit = card.GetComponent<CardDisplay>().card;
            playerHUD = card.GetComponent<CardDisplay>();
            StartCoroutine(ElementalAttack3());
            StartCoroutine(ElementalAttack2Damage(2 * playerUnit.damage));
        }
        if(count == 39)
        {
            sentenceRate = 0.2f;
        }
        if (count == 42)
        {
            dice.SetActive(true);
            pointers.SetActive(false);
        }
        if (count == 47)
        {
            pointers.SetActive(true);
        }
        if (count == 55)
        {
            Canvas.Fade();
        }

    }

    public IEnumerator WaitDialogue()
    {
        yield return new WaitForSeconds(1f);
        manager.GetComponent<DialogueManager>().DisplayNextSentence();
        NextSceneScript();
    }
  
    public IEnumerator WaitDialogueDrag()
    {
        yield return new WaitForSeconds(3f);
        manager.GetComponent<DialogueManager>().DisplayNextSentence();
        NextSceneScript();
        nextSentenceTime = 0f;

    }
    public IEnumerator Wait2DialogueDrag()
    {
        yield return new WaitForSeconds(3f);

        manager.GetComponent<DialogueManager>().DialogueText.text = sentence;


    }

public void SetLife()
{
    for (int i = 0; i < battleSystem.GetComponent<BattleSystemFinal>().playerCards.Length; i++)
    {
        battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
            battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<CardDisplay>().SetHP(playerCards[i].GetComponent<PlayerStats>().card.maxHP);
        }


}

public void PickEstacao()
{
        if (estacaoDone == false)
        {
            textBox.SetActive(true);
            manager.GetComponent<DialogueManager>().DialogueText.text = "Você quer batalhar contra o mestre da estação? Este mestre possui elementais elétricos, escolha três dos seus elementais para esta batalha.";
            mestre = 5;
            playerCardSel.SetActive(true);
            for (int i = 0; i < numberOfCards; i++)
            {
                playerCards[i].SetActive(true);
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<CardDisplay>().SetHP(playerCards[i].GetComponent<PlayerStats>().card.maxHP);
                playerCards[i].GetComponent<CardDisplay>().isSel = false;
                playerCards[i].GetComponent<CardDisplay>().inPlace = false;
            }
            placed = 0;
            nextButton.SetActive(false);
            selButton.SetActive(true);

            isQuestion = true;
            battleSystem.GetComponent<BattleSystemFinal>().index = 1;
            battleSystem.GetComponent<BattleSystemFinal>().playerIndex = 1;
            battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = eletron[1];
            battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = eletron[0];
            mapBackground.SetActive(false);
            estacao.SetActive(true);
            vulcaoButton.SetActive(false);
            marButton.SetActive(false);
            arvoreButton.SetActive(false);
            estacaoButton.SetActive(false);
            usinaButton.SetActive(false);
            cavernaButton.SetActive(false);
            montanhaButton.SetActive(false);
        }


    }
public void PickVulcao()
{
        if (vulcaoDone == false)
        {
            textBox.SetActive(true);
            manager.GetComponent<DialogueManager>().DialogueText.text = "Você quer batalhar contra o mestre da estação? Este mestre possui elementais elétricos, escolha três dos seus elementais para esta batalha.";
            mestre = 4;
            playerCardSel.SetActive(true);
            for (int i = 0; i < numberOfCards; i++)
            {
                playerCards[i].SetActive(true);
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<CardDisplay>().SetHP(playerCards[i].GetComponent<PlayerStats>().card.maxHP);
                playerCards[i].GetComponent<CardDisplay>().isSel = false;
                playerCards[i].GetComponent<CardDisplay>().inPlace = false;
            }

            selButton.SetActive(true);
            nextButton.SetActive(false);
            placed = 0;
            isQuestion = true;
            battleSystem.GetComponent<BattleSystemFinal>().index = 1;
            battleSystem.GetComponent<BattleSystemFinal>().playerIndex = 1;
          //  battleSystem.GetComponent<BattleSystemFinal>().enemyCards[2] = tocha;
            battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = tocha;
            battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = fogareu[0];
            mapBackground.SetActive(false);
            vulcao.SetActive(true);
            vulcaoButton.SetActive(false);
            marButton.SetActive(false);
            arvoreButton.SetActive(false);
            estacaoButton.SetActive(false);
            usinaButton.SetActive(false);
            cavernaButton.SetActive(false);
            montanhaButton.SetActive(false);
        }

    }
public void PickPraia()
{
        if (marDone == false)
        {
            textBox.SetActive(true);
            manager.GetComponent<DialogueManager>().DialogueText.text = "Você quer batalhar contra o mestre da praia? Este mestre possui elementais aquáticos, escolha três dos seus elementais para esta batalha.";
            mestre = 1;
            playerCardSel.SetActive(true);
            for (int i = 0; i < numberOfCards; i++)
            {
                playerCards[i].SetActive(true);
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<CardDisplay>().SetHP(playerCards[i].GetComponent<PlayerStats>().card.maxHP);
                playerCards[i].GetComponent<CardDisplay>().isSel = false;
                playerCards[i].GetComponent<CardDisplay>().inPlace = false;
            }

            selButton.SetActive(true);
            nextButton.SetActive(false);
            placed = 0;
            isQuestion = true;
            battleSystem.GetComponent<BattleSystemFinal>().index = 1;
            battleSystem.GetComponent<BattleSystemFinal>().playerIndex = 1;
            //battleSystem.GetComponent<BattleSystemFinal>().enemyCards[2] = marinho;
           battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = tsunami[0];
            battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = tsunami[0];
            mapBackground.SetActive(false);
            mar.SetActive(true);
            vulcaoButton.SetActive(false);
            marButton.SetActive(false);
            arvoreButton.SetActive(false);
            estacaoButton.SetActive(false);
            usinaButton.SetActive(false);
            cavernaButton.SetActive(false);
            montanhaButton.SetActive(false);
        }

    }
public void PickUsina()
{
        if (usinaDone == false)
        {
            textBox.SetActive(true);
            manager.GetComponent<DialogueManager>().DialogueText.text = "Você quer batalhar contra o mestre da Usina? Cuidado! Este é um mestre poderoso e possui elementais elétricos, escolha três dos seus elementais para esta batalha.";
            mestre = 7;
            playerCardSel.SetActive(true);
            for (int i = 0; i < numberOfCards; i++)
            {
                playerCards[i].SetActive(true);
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<CardDisplay>().SetHP(playerCards[i].GetComponent<PlayerStats>().card.maxHP);
                playerCards[i].GetComponent<CardDisplay>().isSel = false;
                playerCards[i].GetComponent<CardDisplay>().inPlace = false;
            }
            selButton.SetActive(true);
            nextButton.SetActive(false);
            placed = 0;
            isQuestion = true;
            battleSystem.GetComponent<BattleSystemFinal>().index = 1;
            battleSystem.GetComponent<BattleSystemFinal>().playerIndex = 1;
            battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = eletron[0];
          //  battleSystem.GetComponent<BattleSystemFinal>().enemyCards[2] = eletron[1];
            battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = trovoada;
            mapBackground.SetActive(false);
            usina.SetActive(true);
            vulcaoButton.SetActive(false);
            marButton.SetActive(false);
            arvoreButton.SetActive(false);
            estacaoButton.SetActive(false);
            usinaButton.SetActive(false);
            cavernaButton.SetActive(false);
            montanhaButton.SetActive(false);
        }


    }
public void PickArvore()
{
        if (arvoreDone == false)
        {
            manager.GetComponent<DialogueManager>().DialogueText.text = "Você quer batalhar contra o chefão da árvore? Cuidado! Este é um mestre poderoso e possui elementais do tipo planta, escolha três dos seus elementais para esta batalha.";
            textBox.SetActive(true);
            mestre = 6;
            playerCardSel.SetActive(true);
            for (int i = 0; i < numberOfCards; i++)
            {
                playerCards[i].SetActive(true);
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<CardDisplay>().SetHP(playerCards[i].GetComponent<PlayerStats>().card.maxHP);
                playerCards[i].GetComponent<CardDisplay>().isSel = false;
                playerCards[i].GetComponent<CardDisplay>().inPlace = false;
            }
            selButton.SetActive(true);
            nextButton.SetActive(false);
            placed = 0;
            isQuestion = true;
            battleSystem.GetComponent<BattleSystemFinal>().index = 1;
            battleSystem.GetComponent<BattleSystemFinal>().playerIndex = 1;
            battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = Carnivora;
            battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = figueira;
           // battleSystem.GetComponent<BattleSystemFinal>().enemyCards[2] = Carnivora;
            mapBackground.SetActive(false);
            arvore.SetActive(true);
            vulcaoButton.SetActive(false);
            marButton.SetActive(false);
            arvoreButton.SetActive(false);
            estacaoButton.SetActive(false);
            usinaButton.SetActive(false);
            cavernaButton.SetActive(false);
            montanhaButton.SetActive(false);
        }

    }
public void PickCaverna()
{
        if (cavernaDone == false)
        {
            textBox.SetActive(true);
            manager.GetComponent<DialogueManager>().DialogueText.text = "Você quer batalhar contra o mestre da caverna? Este mestre possui elementais do tipo pedra, escolha três dos seus elementais para esta batalha.";
            mestre = 2;
            playerCardSel.SetActive(true);
            for (int i = 0; i < numberOfCards; i++)
            {
                playerCards[i].SetActive(true);
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<CardDisplay>().SetHP(playerCards[i].GetComponent<PlayerStats>().card.maxHP);
                playerCards[i].GetComponent<CardDisplay>().isSel = false;
                playerCards[i].GetComponent<CardDisplay>().inPlace = false;
            }
            selButton.SetActive(true);
            nextButton.SetActive(false);
            isQuestion = true;
            battleSystem.GetComponent<BattleSystemFinal>().index = 1;
            battleSystem.GetComponent<BattleSystemFinal>().playerIndex = 1;
            battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = torrao[0];
            battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = rochoso[0];
            mapBackground.SetActive(false);
            caverna.SetActive(true);
            vulcaoButton.SetActive(false);
            marButton.SetActive(false);
            arvoreButton.SetActive(false);
            estacaoButton.SetActive(false);
            usinaButton.SetActive(false);
            cavernaButton.SetActive(false);
            montanhaButton.SetActive(false);
        }

    }
public void PickMontanha()
{
        if (MontanhaDone == false)
        {
            textBox.SetActive(true);
            manager.GetComponent<DialogueManager>().DialogueText.text = "Você quer batalhar contra o mestre da montanha? Este mestre possui elementais do tipo pedra, escolha três dos seus elementais para esta batalha.";
            mestre = 3;
            playerCardSel.SetActive(true);
            for (int i = 0; i < numberOfCards; i++)
            {
                playerCards[i].SetActive(true);
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
                battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<CardDisplay>().SetHP(playerCards[i].GetComponent<PlayerStats>().card.maxHP);
                playerCards[i].GetComponent<CardDisplay>().isSel = false;
                playerCards[i].GetComponent<CardDisplay>().inPlace = false;
            }
            placed = 0;
            selButton.SetActive(true);
            nextButton.SetActive(false);
            isQuestion = true;
            battleSystem.GetComponent<BattleSystemFinal>().index = 1;
            battleSystem.GetComponent<BattleSystemFinal>().playerIndex = 1;
       //     battleSystem.GetComponent<BattleSystemFinal>().enemyCards[2] = rochoso[0];
            battleSystem.GetComponent<BattleSystemFinal>().enemyCards[1] = rochoso[0];
            battleSystem.GetComponent<BattleSystemFinal>().enemyCards[0] = torrao[1];
            mapBackground.SetActive(false);
            montanha.SetActive(true);
            vulcaoButton.SetActive(false);
            marButton.SetActive(false);
            arvoreButton.SetActive(false);
            estacaoButton.SetActive(false);
            usinaButton.SetActive(false);
            cavernaButton.SetActive(false);
            montanhaButton.SetActive(false);
        }
    }
    public void CardsSelected()
    {
        if (placed == 3)
        {
            int j = 0;
            for (int i = 0; i < numberOfCards; i++)
            {
                if (playerCards[i].GetComponent<CardDisplay>().isSel == false)
                {
                    playerCards[i].SetActive(false);
                }
                else
                {
                    playerCards[i].GetComponent<RectTransform>().anchoredPosition = place[j].GetComponent<RectTransform>().anchoredPosition;
                    j++;
                    battleSystem.GetComponent<BattleSystemFinal>().playerCards[i].GetComponent<PlayerStats>().SetHp();
                    playerCards[i].GetComponent<CardDisplay>().isSel = false;
                    playerCards[i].GetComponent<CardDisplay>().inPlace = false;
                }
            }
            selButton.SetActive(false);
            playerCardSel.SetActive(false);
            attackButton.SetActive(true);
            opponent1.SetActive(true);
            enemyCardPos.SetActive(true);
            textBox.SetActive(true);
            manager.GetComponent<DialogueManager>().DialogueText.text = "Boa sorte!";
            battleSystem.GetComponent<BattleSystemFinal>().SetBattle();
        }
        else
        {
            manager.GetComponent<DialogueManager>().DialogueText.text = "Você precisa escolher 3 elementais para batalhar!";

        }
      
    }

    public IEnumerator ElementalAttack2()
    {
        yield return new WaitForSeconds(1f);
       ParticleSystem go = Instantiate(fireParticle, attackPoint1.position, Quaternion.identity);
        Destroy(go.gameObject, 5f);
    }
    public IEnumerator ElementalAttack3()
    {
        yield return new WaitForSeconds(1f);
        ParticleSystem go = Instantiate(fireParticle, attackPoint2.position, Quaternion.identity);
        ParticleSystem go2 = Instantiate(fireParticle, attackPoint1.position, Quaternion.identity);
        Destroy(go.gameObject, 5f);
        Destroy(go2.gameObject, 5f);
    }
    public IEnumerator ElementalAttack2Damage(int damage)
    {
        yield return new WaitForSeconds(1f);
        bool isDead = enemyStats.TakeDamage(damage);
        enemyHUD.SetHP(enemyStats.currentHealth);
        if (isDead)
        {
            card2.GetComponent<CardDamage>().StartCoroutine(card2.GetComponent<CardDamage>().DeathCoroutine(1.5f));
            enemyHUD.SetHP(0);
        }
        else
        {
            card2.GetComponent<CardDamage>().StartCoroutine(card2.GetComponent<CardDamage>().DamageCoroutine(0f, 5, 0.5f));

        }
    }
    public IEnumerator ElementalAttack5()
    {
        yield return new WaitForSeconds(1f);
        ParticleSystem go = Instantiate(fireParticle, attackPoint2.position, Quaternion.identity);
        ParticleSystem go2 = Instantiate(fireParticle, attackPoint1.position, Quaternion.identity);
        ParticleSystem go3 = Instantiate(fireParticle, attackPoint3.position, Quaternion.identity);
        Destroy(go.gameObject, 5f);
        Destroy(go2.gameObject, 5f);
        Destroy(go3.gameObject, 5f);

    }
    public IEnumerator ElementalAttack4()
    {
        yield return new WaitForSeconds(1f);
        ParticleSystem go = Instantiate(fireParticle, attackPoint2.position, Quaternion.identity);
        ParticleSystem go2 = Instantiate(fireParticle, attackPoint1.position, Quaternion.identity);
        ParticleSystem go3 = Instantiate(fireParticle, attackPoint3.position, Quaternion.identity);
        ParticleSystem go4 = Instantiate(fireParticle, attackPoint4.position, Quaternion.identity);
        Destroy(go.gameObject, 5f);
        Destroy(go2.gameObject, 5f);
        Destroy(go3.gameObject, 5f);
        Destroy(go4.gameObject, 5f);

    }
}




