using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LastScene : MonoBehaviour {

    [SerializeField]
    private Text winText;

    [SerializeField]
    private Button goBackButton;

    [SerializeField]
    private GameObject ducks;
    public float speed;
    private void Start()
    {
        winText.gameObject.SetActive(false);
        goBackButton.gameObject.SetActive(false);
        ducks.transform.position = new Vector3(-12f, -.5f, 0);
        speed = 4f;
    }

    public void goBackToStart()
    {
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        if (ducks.transform.position.x < 13)
        {
            ducks.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            winText.gameObject.SetActive(true);
            goBackButton.gameObject.SetActive(true);
        }
    }
}
