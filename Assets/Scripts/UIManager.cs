using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    //Controlla se sei in gioco
    [SerializeField] bool inGame = false;

    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject pausa;

    [SerializeField] Text textScore;
    int score = 1;
    int maxScore;
    int minScore;


    

    // Start is called before the first frame update
    void Start()
    {
        //Disattiva lo script del player cercandolo in scena
        GameObject.Find("Player").GetComponent<Gestione_Player>().enabled = false;
        
        //Imposta lo score a zero
        textScore.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        Pausa();
        Score();
    }

    public void StartGame()
    {
        //Controlla se sei in gioco
        inGame = true;
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
            inGame = false;
           
        }
    }

    //Quando premo il tasto "Resume" toglie la pausa e riattiva lo script del giocatore
    public void Resume()
    {
        pausa.SetActive(false);
        GameObject.Find("Player").GetComponent<Gestione_Player>().enabled = true;
        inGame = true;
    }


    //aggiorna lo score andando avanti
    public void Score()
    {
        if(inGame == true)
        {
            maxScore = score;

            if(Input.GetKeyDown("up") || Input.GetButtonDown("Jump"))
            {
                score++;
                textScore.text = "" + maxScore;
            }
            //else if (Input.GetKeyDown("down"))
            //{
            //    minScore--;
            //    score = minScore;
            //    maxScore != minScore;
                
            //    //maxScore = score;
            //}
        }
    }
}
