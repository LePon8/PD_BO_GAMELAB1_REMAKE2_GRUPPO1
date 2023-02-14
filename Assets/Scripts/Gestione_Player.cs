using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gestione_Player : MonoBehaviour
{
    [Header("Giocatore")]
    [SerializeField] int forzaAvanzamento = 1;
    [SerializeField] private Animator animazione;
    [SerializeField] int stopPosition;

    [Header("Ground")]
    [SerializeField] private SpawnerGround groundSpawner;

    [Header("Score")]
    [SerializeField] Text scoreText;
    int score = 0;
    int maxScore;

    UIManager uimanager;


    private void Start()
    {
        scoreText.text = "0";
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
        Limits();
    }

    public void Movimento()
    {
        //Movimento verticale
        if (Input.GetKeyDown("up") || Input.GetButtonDown("Jump"))
        {
            transform.Translate(new Vector3(0, 0, forzaAvanzamento));
            animazione.SetTrigger("salto");
            score++;

            if (maxScore < score)
            {
                scoreText.text = "" + score;
                maxScore = score;
            }
        }

        else if (Input.GetKeyDown("down"))
        {
            transform.Translate(new Vector3(0, 0, -forzaAvanzamento));
            animazione.SetTrigger("salto");
            score --;
        }



        //Movimento orizzontale
        if (Input.GetKeyDown("right"))
        {
            transform.Translate(new Vector3(forzaAvanzamento, 0, 0));
            animazione.SetTrigger("salto");
        }

        else if (Input.GetKeyDown("left"))
        {
            transform.Translate(new Vector3(-forzaAvanzamento, 0, 0));
            animazione.SetTrigger("salto");
        }

        groundSpawner.SpawnGround(false, transform.position);

    }

    void Limits()
    {
        if(transform.position.x >= stopPosition)
        {
            transform.position = new Vector3(stopPosition, transform.position.y, transform.position.z);
        }
        else if(transform.position.x <= -stopPosition)
        {
            transform.position = new Vector3(-stopPosition, transform.position.y, transform.position.z);
        }
    }

    //void OnBecameVisible()
    //{
    //    Debug.Log("visible");
    //}
    //void OnBecameInvisible()
    //{
    //    uimanager.GameOver();
    //}
}