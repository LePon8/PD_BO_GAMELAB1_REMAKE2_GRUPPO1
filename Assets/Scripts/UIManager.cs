using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject pausa;

    // Start is called before the first frame update
    void Start()
    {
        //Disattiva lo script del player cercandolo in scena
        GameObject.Find("Player").GetComponent<Gestione_Player>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Pausa();
    }

    public void StartGame()
    {
        //Disattiva il menu e riattiva lo script
        startMenu.SetActive(false);
        GameObject.Find("Player").GetComponent<Gestione_Player>().enabled = true;
    }

    public void Pausa()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Attiva il menu di pausa e disattiva lo script del player
            pausa.SetActive(true);
            GameObject.Find("Player").GetComponent<Gestione_Player>().enabled = false;
           
        }
    }

    //Quando premo il tasto "Resume" toglie la pausa e riattiva lo script del giocatore
    public void Resume()
    {
        pausa.SetActive(false);
        GameObject.Find("Player").GetComponent<Gestione_Player>().enabled = true;
    }
}
