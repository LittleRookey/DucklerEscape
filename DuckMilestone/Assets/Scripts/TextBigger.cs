using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextBigger : MonoBehaviour
{

    [SerializeField]
    private Text gameOver;

    [SerializeField]
    private Button endBut;

    // Use this for initialization
    void Start()
    {
        gameOver.text = "GameOver";
        gameOver.fontSize = 10;
        endBut.gameObject.SetActive(false);
    }

    public void goBack()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver.fontSize < 180)
        {
            gameOver.fontSize++;
        }
        else
        {
            endBut.gameObject.SetActive(true);
        }
        
    }
}
