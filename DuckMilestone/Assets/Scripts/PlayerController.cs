using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ePlayerAction{
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

    public ArrayList effArr;

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

    public bool takeAction;
    // Use this for initialization
    void Start()
    {
        effArr = new ArrayList();

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
        uiCon.updatePlayerHP();

    }

    public IEnumerator PlayerAction(Food f)
    {
        WaitForSeconds pointFIve = new WaitForSeconds(.5f);
        while(takeAction)
        {
            switch (state)
            {
                case ePlayerAction.Purify:
                    Debug.Log("Action Purified");
                    PurifyFood(f);
                    purifyNum++;
                    makeActive();
                    ContinuosDisease(effArr);

                    uiCon.updatePlayerHP();
                    takeAction = false;
                    yield return pointFIve;
                    break;
                case ePlayerAction.Ignore:
                    Debug.Log("Action Ignored");
                    controlHP(-3);
                    uiCon.updatePlayerHP();
                    ignoreNum++;
                    purifyNum = 0;
                    makeActive();
                    ContinuosDisease(effArr);

                    uiCon.updatePlayerHP();
                    takeAction = false;
                    yield return pointFIve;
                    break;
                case ePlayerAction.Save:
                    Debug.Log("Action Saved");
                    makeActive();
                    saveOrEatFood(f);
                    uiCon.updateSavedCardEffect(savedFood);
                    ContinuosDisease(effArr);

                    uiCon.updatePlayerHP();
                    takeAction = false;
                    yield return pointFIve;
                    break;
                case ePlayerAction.Nothing:
                    Debug.Log("Action Nothing");
                    EatFood(f);
                    makeActive();
                    ContinuosDisease(effArr);

                    uiCon.updatePlayerHP();
                    takeAction = false;
                    yield return pointFIve;
                    break;
                default:
                    Debug.Log("your action is not valid");
                    uiCon.updatePlayerHP();
                    takeAction = false;
                    yield return pointFIve;
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Purify"))
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

    public void makeActive()
    {
        if (!gameControl.pur.activeInHierarchy)
        {
            gameControl.pur.SetActive(true);
        }
        if (!gameControl.ign.activeInHierarchy)
        {
            gameControl.pur.SetActive(true);
        }
    }
    public void EatFood(Food f)
    {
        f.effect.isActive = true;
        if(f.effect.isActive && !(f.effect.nameEffect.Equals("Cure")))
        {
            effArr.Add(f.effect);
        }
        if (f.effect.nameEffect.Equals("Cure"))
        {
            CureDisease(effArr);
        }
        controlHP(f.hpEffect);
        RunEffect(f.effect);
        uiCon.updatePlayerHP();
        //TODO make the disease effect and rules that restrict using cards. 
    }


    public void RunEffect(Effect e)
    {
        controlHP(e.hpLoss);
    }

    public void PurifyFood(Food f)
    {
        Food f1 = f.Clone();
        f1.hpEffect = 0;
        EatFood(f1);

    }

    public void ContinuosDisease(ArrayList ef)
    {
        Debug.Log("Disease ongoing!!!!!!!!!!");
        object[] ob = ef.ToArray();
        Effect[] eff = new Effect[ob.Length];
        if (eff.Length != 0)
        {
            Debug.Log(eff.Length);
            for(int i = 0; i< eff.Length; i++)
            {
                if (eff[i].nameEffect.Equals("Malaria"))
                {
                    RunEffect(eff[i]);
                    uiCon.updatePlayerHP();
                }
                else if (eff[i].nameEffect.Equals("Bilharzia"))
                {
                    RunEffect(eff[i]);
                    uiCon.updatePlayerHP();
                }
            }
        }
    }

    // updates the food inside storage
    public void saveOrEatFood(Food f)
    {
        EatFood(savedFood);
        savedFood = f;
    }

    public void CureDisease(ArrayList ef)
    {
        Debug.Log("disease cured, +1HP");
        playerHP++;
        object[] ob = ef.ToArray();
        Effect[] eff = new Effect[ob.Length];
        for(int k = 0; k < ob.Length; k++)
        {
            eff[k] = (Effect)ob[k];
        }
        for (int i = 0; i < eff.Length; i++)
        {
            ef.Remove(eff[i]);
        }
    }

}
