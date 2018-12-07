using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPool : MonoBehaviour {

    //public static CardPool cardPool;
    public  ArrayList foods;

    [SerializeField]
    private Transform iconPos;

    public GameObject[] imgs = new GameObject[12];

    private BirdSeed birdseed;
    private Oat oat;
    private Lettuce lettuce;
    private Rice rice;
    private RottenGrape rottenGrape;
    private PollutedCrackedCorn pollutedCrackedCorn;
    private Avocado avocado;
    private Onion onion;
    private Nuts nuts;
    private Chocolate chocolate;
    private Popcorn popcorn;
    private Bread bread;

    private Effect purifyEffect;
    private Effect malaria;
    private Effect bilharzia;

    public ArrayList effectsActive;

    private Effect noEffect;

    public int indexIcon;

    public string effectExp1;
    public string effectExp2;
    public string effectExp3;

    private System.Random rand;

    //classes of food
    class BirdSeed : Food
    {
        public BirdSeed(string name, int val, Effect eff, int indx)
            : base(name, val, eff, indx)
        {

        }
    }

    class Oat : Food
    {
        public Oat(string name, int val, Effect eff, int indx)
            : base(name, val, eff, indx)
        {

        }
    }

    class Lettuce : Food
    {
        public Lettuce(string name, int val, Effect eff, int indx)
            : base(name, val, eff, indx)
        {

        }
    }

    class Rice : Food
    {
        public Rice(string name, int val, Effect eff, int indx)
            : base(name, val, eff, indx)
        {

        }
    }

    class RottenGrape : Food
    {
        public RottenGrape(string name, int val, Effect eff, int indx)
            : base(name, val, eff, indx)
        {

        }
    }


    class PollutedCrackedCorn : Food
    {
        public PollutedCrackedCorn(string name, int val, Effect eff, int indx)
            : base(name, val, eff, indx)
        {

        }
    }

    class Avocado : Food
    {
        public Avocado(string name, int val, Effect eff, int indx)
            : base(name, val, eff, indx)
        {

        }
    }


    class Onion : Food
    {
        public Onion(string name, int val, Effect eff, int indx)
            : base(name, val, eff, indx)
        {

        }
    }


    class Nuts : Food
    {
        public Nuts(string name, int val, Effect eff, int indx)
            : base(name, val, eff, indx)
        {

        }
    }

    class Chocolate : Food
    {
        public Chocolate(string name, int val, Effect eff, int indx)
            : base(name, val, eff, indx)
        {

        }
    }

    class Popcorn : Food
    {
        public Popcorn(string name, int val, Effect eff, int indx)
            : base(name, val, eff, indx)
        {

        }
    }

    class Bread : Food
    {
        public Bread(string name, int val, Effect eff, int indx)
            : base(name, val, eff, indx)
        {

        }
    }

    // Use this for initialization
    void Start()
    {
        rand = new System.Random();

        indexIcon = rand.Next(0, 12);
        noEffect = new Effect("No Disease", 0, false);

        purifyEffect = new Effect("Cure", 1, false);

        malaria = new Effect("Malaria", -1, false);

        bilharzia = new Effect("Bilharzia", -1, false);
        
        effectExp1 = "lose 1 HP every turn";
        effectExp2 = "Cure all disease and +1 HP";
        effectExp3 = "lose 1 HP every turn";

        effectsActive = new ArrayList();
        foods = new ArrayList();

        birdseed = new BirdSeed("Bird Seed", 1, noEffect, 0);
        oat = new Oat("Oat", 1, malaria, 1);
        Lettuce lettuce = new Lettuce("Lettuce", 3, bilharzia, 2); // lose speed -> speed/2
        Rice rice = new Rice("Rice", 1, purifyEffect, 3);
        RottenGrape rottenGrape = new RottenGrape("Rotten Grape", -2, malaria, 4);
        PollutedCrackedCorn pollutedCrackedCorn = new PollutedCrackedCorn("Polluted Cracked Corn", -2, malaria, 5);
        Avocado avocado = new Avocado("Avocado", -2, malaria, 6);
        Onion onion = new Onion("Onion", -2, purifyEffect, 7);
        Nuts nuts = new Nuts("Nuts", -2, purifyEffect, 8);
        Chocolate chocolate = new Chocolate("Chocolate", -2, purifyEffect, 9);
        Popcorn popcorn = new Popcorn("Popcorn", -2, bilharzia, 10);
        Bread bread = new Bread("Bread", -2, malaria, 11);



        for (int i = 0; i < 3; i++)
        {
            foods.Add(birdseed);
            foods.Add(oat);
            foods.Add(lettuce);
            foods.Add(rice);
            foods.Add(rottenGrape);
            foods.Add(pollutedCrackedCorn);
            foods.Add(avocado);
            foods.Add(onion);
            foods.Add(nuts);
            foods.Add(chocolate);
            foods.Add(popcorn);
            foods.Add(bread);
        }

    }

    public void placeIcon(int index, bool active)
    {
        imgs[index].gameObject.SetActive(active);
    }

    

    public Food spawnFood(int index)
    {
        
        return (Food)foods[index];
        // remove that food from the list
    }


    // Update is called once per frame
    void Update () {
		
	}
}
