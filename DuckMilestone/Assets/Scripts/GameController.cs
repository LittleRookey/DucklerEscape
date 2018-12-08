using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private Food food;

    [SerializeField]
    private CardPool cardP;
    public int timer;

    [SerializeField]
    private UIController uiCon;

    [SerializeField]
    public GameObject malaria, bilharzia;

    public GameObject pur;

    public GameObject ign;

    System.Random rand;
    int spawnNum;
    public int round;
    private Coroutine gameStart;
    int roundNum;

    public Effect[] ef1;

    private void Start()
    {
        rand = new System.Random();
        timer = 10;
        roundNum = 36;
        round = 0;
        player.playerHP = 15;
        gameStart = StartCoroutine(gameFlow());
        ef1 = new Effect[2];
        malaria.gameObject.SetActive(false);
        bilharzia.gameObject.SetActive(false);
    }

    private IEnumerator gameFlow()
    {
        WaitForSeconds pointFIve = new WaitForSeconds(.5f);
        WaitForSeconds oneSec = new WaitForSeconds(1f);
        WaitForSeconds twoSec = new WaitForSeconds(2f);
        if(player.purifyNum > 0)
        {
            pur.gameObject.SetActive(false);
            player.state = ePlayerAction.Nothing;
            player.purifyNum = 0;
            uiCon.updateState();
        }
        if(player.ignoreNum > 1)
        {
            ign.gameObject.SetActive(false);
            player.state = ePlayerAction.Nothing;
            player.ignoreNum = 0;
            uiCon.updateState();
        }

        round++;
        uiCon.updateRound();
        yield return twoSec;
        uiCon.roundText.gameObject.SetActive(false);
        Debug.Log("Round start!");
        timer = 10;
        uiCon.updateTimer(); 

        int ind = rand.Next(0, roundNum);

        //spawn food
        cardP.spawnFood(ind);
        Food inst = cardP.spawnFood(ind);
        player.temp = inst;
        cardP.placeIcon(inst.iconInd, true);
        uiCon.updateFoods(inst);
        while (timer > 0)
        {
            yield return oneSec;
            timer--;
            uiCon.updateTimer();
        }
        
        uiCon.updatePlayersAction(inst);
        cardP.placeIcon(inst.iconInd, false);

        //remove food from arraylist
        roundNum--;
        cardP.foods.RemoveAt(ind);
        if (player.playerHP > 0)
        {
            StartCoroutine(gameFlow());
        }
        else
        {
            //TODO GameOver
            player.playerHP = 0;
            uiCon.updatePlayerHP();
            GameOver();
        }
    }


    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
    // Update is called once per frame
    void Update () {
		if(roundNum <= 0)
        {
            if (player.playerHP > 0)
            {
                SceneManager.LoadScene(3);
            }
            else
            {
                Debug.Log("Game end");
                StopCoroutine(gameStart);
                GameOver();
            }
        }
        

        
	}
}
