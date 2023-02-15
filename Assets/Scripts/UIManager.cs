using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [HideInInspector] public static UIManager Instance;
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject pausa;
    [SerializeField] GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
        //Disattiva lo script del player cercandolo in scena
        GameObject.Find("Player").GetComponent<Gestione_Player>().enabled = false;
        GameObject.Find("Main Camera").GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        Pausa();
        GameOver();
    }

    public void StartGame()
    {
        //Disattiva il menu e riattiva lo script
        startMenu.SetActive(false);
        GameObject.Find("Player").GetComponent<Gestione_Player>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<Rigidbody>().isKinematic = false;

    }

    public void Pausa()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Attiva il menu di pausa e disattiva lo script del player
            pausa.SetActive(true);
            GameObject.Find("Player").GetComponent<Gestione_Player>().enabled = false;
            GameObject.Find("Main Camera").GetComponent<Rigidbody>().isKinematic = true;

        }
    }

    //Quando premo il tasto "Resume" toglie la pausa e riattiva lo script del giocatore
    public void Resume()
    {
        pausa.SetActive(false);
        GameObject.Find("Player").GetComponent<Gestione_Player>().enabled = true;
        GameObject.Find("Main Camera").GetComponent<Rigidbody>().isKinematic = false;
    }

    public void GameOver()
    {
        if(GameObject.Find("Player").transform.position.z < GameObject.Find("Main Camera").transform.position.z)
        {
            gameOver.SetActive(true);
            GameObject.Find("Player").GetComponent<Gestione_Player>().enabled = false;
            GameObject.Find("Main Camera").GetComponent<Rigidbody>().isKinematic = true;

        }

    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
