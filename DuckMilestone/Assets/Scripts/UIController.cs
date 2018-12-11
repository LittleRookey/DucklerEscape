using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    [SerializeField]
    private Text stateText, timer, foodEffect, foodEffect2, playerHP, savedCardEffect, savedCardEffect2;

    [SerializeField]
    public Text roundText;

    [SerializeField]
    private GameController gameControl;

    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private CardPool cardP;

    [SerializeField]
    private GameController game;
	// Use this for initialization
	void Start () {
        savedCardEffect.text = "None";
	}

    public void updatePlayerHP()
    {
        playerHP.text = string.Format("HP: {0}", player.playerHP);
    }

    public void updateSavedCardEffect(Food f)
    {
        if (f.hpEffect >= 0)
        {
            if (f.effect.nameEffect.Equals("Malaria"))
            {
                savedCardEffect.text = string.Format("{0}: HP +{1}", f.name, f.hpEffect);
                savedCardEffect2.text = string.Format("{0}: " + cardP.effectExp1, f.effect.nameEffect);
                Debug.Log("Saved Fooddddddd");
            }
            else if (f.effect.nameEffect.Equals("Cure"))
            {
                savedCardEffect.text = string.Format("{0}: HP +{1}", f.name, f.hpEffect);
                savedCardEffect2.text = string.Format("{0}: " + cardP.effectExp2, f.effect.nameEffect);
            }
            else if (f.effect.nameEffect.Equals("Bilharzia"))
            {
                savedCardEffect.text = string.Format("{0}: HP +{1}", f.name, f.hpEffect);
                savedCardEffect2.text = string.Format("{0}: " + cardP.effectExp3, f.effect.nameEffect);
            }
            else
            {
                savedCardEffect.text = string.Format("{0}: HP +{1}", f.name, f.hpEffect);
                savedCardEffect2.text = string.Format("{0}: ", f.effect.nameEffect);
            }
        }
        else
        {
            if (f.effect.nameEffect.Equals("Malaria"))
            {
                savedCardEffect.text = string.Format("{0}: HP {1}", f.name, f.hpEffect);
                savedCardEffect2.text = string.Format("{0}: " + cardP.effectExp1, f.effect.nameEffect);
                Debug.Log("Saved Fooddddddd");
            }
            else if(f.effect.nameEffect.Equals("Cure"))
            {
                savedCardEffect.text = string.Format("{0}: HP {1}", f.name, f.hpEffect);
                savedCardEffect2.text = string.Format("{0}: " + cardP.effectExp2, f.effect.nameEffect);
            }
            else if(f.effect.nameEffect.Equals("Bilharzia"))
            {
                savedCardEffect.text = string.Format("{0}: HP {1}", f.name, f.hpEffect);
                savedCardEffect2.text = string.Format("{0}: " + cardP.effectExp3, f.effect.nameEffect);
            }
            else
            {
                savedCardEffect.text = string.Format("{0}: HP {1}", f.name, f.hpEffect);
                savedCardEffect2.text = string.Format("{0}: ", f.effect.nameEffect);
            }
        }
    }
    public void updateFoods(Food f)
    {
        if (f.hpEffect >= 0)
        {
            if (f.effect.nameEffect.Equals("Malaria"))
            {
                foodEffect.text = string.Format("{0}: HP +{1}", f.name, f.hpEffect);
                foodEffect2.text = string.Format("{0}: " + cardP.effectExp1, f.effect.nameEffect);
                Debug.Log("Saved Fooddddddd");
            }
            else if (f.effect.nameEffect.Equals("Cure"))
            {
                foodEffect.text = string.Format("{0}: HP +{1}", f.name, f.hpEffect);
                foodEffect2.text = string.Format("{0}: " + cardP.effectExp2, f.effect.nameEffect);
            }
            else if (f.effect.nameEffect.Equals("Bilharzia"))
            {
                foodEffect.text = string.Format("{0}: HP +{1}", f.name, f.hpEffect);
                foodEffect2.text = string.Format("{0}: " + cardP.effectExp3, f.effect.nameEffect);
            }
            else
            {
                foodEffect.text = string.Format("{0}: HP +{1}", f.name, f.hpEffect);
                foodEffect2.text = string.Format("{0}: ", f.effect.nameEffect);
            }
        }
        else
        {
            if (f.effect.nameEffect.Equals("Malaria"))
            {
                foodEffect.text = string.Format("{0}: HP {1}", f.name, f.hpEffect);
                foodEffect2.text = string.Format("{0}: " + cardP.effectExp1, f.effect.nameEffect);
                
            }
            else if (f.effect.nameEffect.Equals("Cure"))
            {
                foodEffect.text = string.Format("{0}: HP {1}", f.name, f.hpEffect);
                foodEffect2.text = string.Format("{0}: " + cardP.effectExp2, f.effect.nameEffect);
            }
            else if (f.effect.nameEffect.Equals("Bilharzia"))
            {
                foodEffect.text = string.Format("{0}: HP {1}", f.name, f.hpEffect);
                foodEffect2.text = string.Format("{0}: " + cardP.effectExp3, f.effect.nameEffect);
            }
            else
            {
                foodEffect.text = string.Format("{0}: HP {1}", f.name, f.hpEffect);
                foodEffect2.text = string.Format("{0}: ", f.effect.nameEffect);
            }
        }
    }

    public void updatePlayersAction(Food f)
    {
        player.takeAction = true;
        StartCoroutine(player.PlayerAction(f));
    }
    public void updateTimer()
    {
        timer.text = string.Format("Time left: {0}", game.timer);
    }

    public void updateState()
    {
        stateText.text = string.Format("Player Action: {0}", player.state);
    }

    public void updateRound()
    {
        roundText.text = string.Format("Round {0}", gameControl.round.ToString());
        roundText.gameObject.SetActive(true);
    }
	// Update is called once per frame
	void Update () {
        
    }
}
