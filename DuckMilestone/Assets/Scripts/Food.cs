using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food {


    public string name;
    public int hpEffect;
    public Effect effect;
    public int iconInd;

    public Food(string na, int hpEff, Effect effec, int ind)
    {
        name = na;
        hpEffect = hpEff;
        effect = effec;
        iconInd = ind;
    }


    private void Awake()
    {
       
    }


    // Use this for initialization
    void Start () {

    }
    public object GetFood(ArrayList foodsList, int index)
    {
        object f = foodsList[index];
        return f;
    }

    public Food Clone()
    {
        Food f1 = (Food)this.MemberwiseClone();
        return f1;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
