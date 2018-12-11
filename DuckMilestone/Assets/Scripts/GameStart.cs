using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour {

    public void gameStarts()
    {
        SceneManager.LoadScene(1);
    }
    
    public void GameVolume()
    {

    }
    public void GameEnd()
    {
        Application.Quit();
    }
}
