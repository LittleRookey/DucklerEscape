using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ePlayerAction
{
    Purify, Ignore, Save, Eat, Nothing
};
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private GameController gameControl;

    [SerializeField]
    private CardPool cardP;

    [SerializeField]
    private UIController uiCon;

    public List<Effect> effArr;

    private float horizontal;

    private float vertical;

    private Vector2 movement;

    private Rigidbody2D rb;

    public float speed;

    public int playerHP;

    public ePlayerAction state;

    public Food savedFood;

    public Food temp;

    private Effect noEffect;

    private System.Random rand = new System.Random();

    public int purifyNum;

    public int ignoreNum;

    private bool infMal;
    private bool infBil;

    private int malNum;
    private int bilNum;

    public bool takeAction;
    // Use this for initialization
    void Start()
    {
        malNum = 0;
        bilNum = 0;
        effArr = new List<Effect>();
        effArr.Add(cardP.malaria);
        effArr.Add(cardP.bilharzia);
        gameControl.ef1 = effArr.ToArray();
        infMal = false;
        infBil = false;
        ignoreNum = 0;
        purifyNum = 0;

        noEffect = new Effect("No effect", 0, false);
        savedFood = new Food("No food", 0, noEffect, 0);
        temp = new Food("No food", 0, noEffect, 0);
        rb = GetComponent<Rigidbody2D>();
        playerHP = 15;
        uiCon.updatePlayerHP();

        takeAction = false;
        state = ePlayerAction.Nothing;
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float vertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 velocity = new Vector2(horizontal, vertical);

        velocity = velocity * speed;

        rb.velocity = velocity;
    }

    public void controlHP(int val)
    {
        playerHP += val;
    }

    public IEnumerator PlayerAction(Food f)
    {
        WaitForSeconds pointFIve = new WaitForSeconds(.5f);
        while (takeAction)
        {
            switch (state)
            {
                case ePlayerAction.Purify:
                    Debug.Log("Action Purified");
                    PurifyFood(f);
                    purifyNum++;
                    makeActive();
                    checkDIseaseEat(f);

                    uiCon.updatePlayerHP();
                    takeAction = false;
                    yield return pointFIve;
                    break;
                case ePlayerAction.Ignore:
                    Debug.Log("Action Ignored");
                    controlHP(-3);
                    uiCon.updatePlayerHP();
                    ignoreNum++;
                    makeActive();
                    checkContinuedDisease(gameControl.ef1);

                    uiCon.updatePlayerHP();
                    takeAction = false;
                    yield return pointFIve;
                    break;
                case ePlayerAction.Save:
                    Debug.Log("Action Saved");
                    makeActive();
                    saveOrEatFood(f);
                    uiCon.updateSavedCardEffect(savedFood);

                    uiCon.updatePlayerHP();
                    takeAction = false;
                    yield return pointFIve;
                    break;
                case ePlayerAction.Nothing:
                    Debug.Log("Action Nothing");
                    EatFood(f);
                    makeActive();
                    checkDIseaseEat(f);

                    uiCon.updatePlayerHP();
                    takeAction = false;
                    yield return pointFIve;
                    break;
                default:
                    Debug.Log("your action is not valid");
                    uiCon.updatePlayerHP();
                    takeAction = false;

                    checkDIseaseEat(f);
                    yield return pointFIve;
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Purify"))
        {
            state = ePlayerAction.Purify;
            uiCon.updateState();
        }
        if (collision.gameObject.CompareTag("Ignore"))
        {
            state = ePlayerAction.Ignore;
            uiCon.updateState();
        }
        if (collision.gameObject.CompareTag("Save"))
        {
            state = ePlayerAction.Save;
            uiCon.updateState();
        }
        if (collision.gameObject.CompareTag("Nothing"))
        {
            state = ePlayerAction.Nothing;
            uiCon.updateState();
        }
    }

    // restrict using purify and ignore 
    public void makeActive()
    {
        if (!gameControl.pur.activeInHierarchy)
        {
            gameControl.pur.SetActive(true);
        }
        if (!gameControl.ign.activeInHierarchy)
        {
            gameControl.ign.SetActive(true);
        }
    }

    public void EatFood(Food f)
    {
        controlHP(f.hpEffect);

        //TODO make the disease effect and rules that restrict using cards. 
    }

    // checks if the player has disease and if the player has
    // malaria or bilharzia, set it true
    public void checkDIseaseEat(Food f)
    {

        if (f.effect.nameEffect.Equals("Cure"))
        {
            CureDisease(gameControl.ef1);
            Debug.Log("Earned " + 1.ToString() + "HP" + "Disease cured");
        }

        if (f.effect.nameEffect.Equals("Malaria"))
        {
            int indexx = effArr.IndexOf(cardP.malaria);
            gameControl.ef1[indexx].isActive = true;
            Debug.Log(string.Format("Index Num: {0}, {1}", effArr.IndexOf(cardP.malaria), cardP.malaria.nameEffect));
        }
        else if (f.effect.nameEffect.Equals("Bilharzia"))
        {
            int indexx = effArr.IndexOf(cardP.bilharzia);
            gameControl.ef1[indexx].isActive = true;
            Debug.Log(string.Format("Index Num: {0}, {1}", effArr.IndexOf(cardP.bilharzia), gameControl.ef1[indexx].nameEffect));
        }

        checkContinuedDisease(gameControl.ef1);
    }

   
    // applies disease that is ongoing, affect hp
    public void checkContinuedDisease(Effect[] ef2)
    {
        int hpTotalLoss = 0;
        for (int i = 0; i < ef2.Length; i++)
        {
            if (ef2[i].isActive)
            {
               
                if (ef2[i].nameEffect.Equals("Malaria"))
                {
                    malNum++;
                    gameControl.malaria.gameObject.SetActive(true);
                    if(malNum > 1)
                    {
                        hpTotalLoss--;
                    }
                }
                else if (ef2[i].nameEffect.Equals("Bilharzia"))
                {
                    bilNum++;
                    gameControl.bilharzia.gameObject.SetActive(true);
                    if(bilNum > 1)
                    {
                        hpTotalLoss -= 2;
                    }
                }
            }
        }
        controlHP(hpTotalLoss);
        Debug.Log("lost " + hpTotalLoss.ToString() + "HP");

    }




    public void PurifyFood(Food f)
    {
        Food f1 = f.Clone();
        f1.hpEffect = 0;
        EatFood(f1);

    }

    // updates the food inside storage
    public void saveOrEatFood(Food f)
    {
        EatFood(savedFood);
        checkDIseaseEat(savedFood);
        savedFood = f;
    }

    
    public void CureDisease(Effect[] ef1)
    {
        for (int i = 0; i < ef1.Length; i++)
        {
            ef1[i].isActive = false;
        }
        malNum = 0;
        bilNum = 0;
        controlHP(1);
        setFalse();
        Debug.Log("diseases cured!---------------");
    }

    public void setFalse()
    {
        gameControl.bilharzia.gameObject.SetActive(false);
        gameControl.malaria.gameObject.SetActive(false);
    }
}
