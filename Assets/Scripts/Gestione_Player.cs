using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestione_Player : MonoBehaviour
{
    [SerializeField] int forzaAvanzamento = 1;
    //[SerializeField] private Animator animazione;

    //private Quaternion rotazione = Quaternion.identity;


    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movimento();
    }

    void movimento()
    {
        //Movimento verticale
        if (Input.GetKeyDown("up") || Input.GetButtonDown("Jump"))
        {
            transform.Translate(new Vector3(0, 0, forzaAvanzamento));
            //animazione.SetTrigger("salto");
        }

        else if (Input.GetKeyDown("down"))
        {
            transform.Translate(new Vector3(0, 0, -forzaAvanzamento));
        }

        //Movimento orizzontale
        if (Input.GetKeyDown("right"))
        {
            transform.Translate(new Vector3(forzaAvanzamento, 0, 0));
        }

        else if (Input.GetKeyDown("left"))
        {
            transform.Translate(new Vector3(-forzaAvanzamento, 0, 0));
        }

    }
}
