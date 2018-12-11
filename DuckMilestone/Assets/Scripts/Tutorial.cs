using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {

    public Text tutorText;
    public float speed;
    private string expla2;
    private string expla3;
    private string expla4;
    private string expla5;
    private string expla6;
    private string expla7;
    private int index;
    private string[] explanations;
	// Use this for initialization
	void Start () {
        explanations = new string[6];
        index = 0;

        tutorText.text = "There are total 36 rounds and each round lasts 10 seconds." +
            " Each round, one random food is going to pop out from the rectangle from the middle. The food has" +
            "the hpEffect and the disease effect. Diseases can be cured when the player eats " +
            "the food that has a cure effect.";

        expla2 = "The player(Duck) can change its state countlessly before the time ends." +
            "They touch snowman, tree, egloo, or the box."; 
        expla3 =
            " Touching Snowman will change your state to Ignore. When you ignore the food, you lose 3 HP but can ignore the " +
            "food's hpEffect and disease effect.";
        expla3 = "Touching Trees" +
            " will change your state to Purify and Eat. Purifying the food will make the hp Effect 0 but can't cure the " +
            "cure the disease effect";
        expla4 = "Touching Egloo will change your state to Save. Saving food can store the food to a storage. " +
            "The saved food can only be eaten when they save another food. ";
        expla5 = "Lastly, touching box will change your state to Nothing(Eat). Eating food will" +
            " give you the original effect of the food";
        expla6 = "There are total 2 diseases: Malaria and Bilharzia. When you are infected by Malaria, you will " +
            "lose 1 hp every round. When you are infected by Bilharzia, you will lose 2 HP every turn. And these diseases can only" +
            " be cured when you eat the food that has cure effect.";
        expla7 = "Your HP is 15 and you need to give a decision to survive from this polluted world. Good luck!";

        explanations[0] = expla2;
        explanations[1] = expla3;
        explanations[2] = expla4;
        explanations[3] = expla5;
        explanations[4] = expla6;
        explanations[5] = expla7;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (index >= 6)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                tutorText.text = explanations[index];
                index++;
            }
            
        }
	}
}
