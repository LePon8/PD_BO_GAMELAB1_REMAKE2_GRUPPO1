using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGround : MonoBehaviour
{
    //Numero di Ground da spawnare
    [SerializeField] private int maxGround;

    //Creo una lista per le differenti tipologie di terreno
    [SerializeField] private List<GameObject> typeOfGround = new List<GameObject>();

    //Creo un raccoglitore per i ground che vengono spawnati
    [SerializeField] Transform contenitore_Ground;

    //Quantità ground presenti in scena
    private List<GameObject> currentGround = new List<GameObject>();

    //Posizione Spawn primo terreno
    private Vector3 currentPosition = new Vector3(0, 0, -10);


    private void Start()
    {

        //Spawna una serie di terreni allo start, numero che viene scelto da noi
        for (int i = 0; i < maxGround; i++)
        {
            //Crea la prima tipologia di terreno e aggiorna la posizione
            GameObject initialGround = Instantiate(typeOfGround[Random.Range(0, typeOfGround.Count)], currentPosition, Quaternion.identity);
            currentPosition.z++;
            initialGround.transform.SetParent(contenitore_Ground);
        }
    }

    private void Update()
    {
        SpawnGround();
    }

    void SpawnGround()
    {


        //Quando avanzo crea un nuovo pezzo di terreno e aggiorna la posizione
        if (Input.GetKeyDown("up") || Input.GetButtonDown("Jump"))
        {
            GameObject ground = Instantiate(typeOfGround[Random.Range(0, typeOfGround.Count)], currentPosition, Quaternion.identity);
            currentPosition.z++;

            //Aggiungo gameobject ground alla lista che mostra la quantità di ground presenti in scena
            currentGround.Add(ground);

            //Rendo i ground parenti del contenitore creato
            ground.transform.SetParent(contenitore_Ground);
        }

        //Se la quantità di ground presenti in scena è maggiore di max ground, distruggo il primo
        if (currentGround.Count > maxGround)
        {
            Destroy(currentGround[0]);
            //Rimuovo il primo dalla lista
            currentGround.RemoveAt(0);
        }
    }
}
