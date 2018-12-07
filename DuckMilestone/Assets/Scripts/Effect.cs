using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect {

    public string nameEffect;

    public int hpLoss;

    public bool isActive;

    private Effect noEffect;

    public static Effect effectCon;

    public Effect(string na, int HPlost, bool active)
    {
        nameEffect = na;
        hpLoss = HPlost;
        isActive = active;
    }

	// Use this for initialization
	void Start () {
        noEffect = new Effect("No Effect", 0, false);
        effectCon = noEffect;
  
        //noHPGain = new Effect(0, false);
	}
   
	// Update is called once per frame
	void Update () {
		
	}
}
