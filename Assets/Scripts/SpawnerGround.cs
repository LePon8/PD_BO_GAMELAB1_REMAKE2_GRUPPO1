using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGround : MonoBehaviour
{
    //controlla la distanza dal giocatore
    [SerializeField] private int minDistanceToPlayer;
    //Numero di Ground da spawnare
    [SerializeField] private int maxGround;

    //Creo una lista per le differenti tipologie di terreno
    [SerializeField] private List<GroundData> groundDatas = new List<GroundData>();

    //Creo un raccoglitore per i ground che vengono spawnati
    [SerializeField] Transform contenitore_Ground;

    //Quantità ground presenti in scena
    private List<GameObject> currentGround = new List<GameObject>();

    //Posizione Spawn primo terreno
    private Vector3 currentPosition = new Vector3(0, 0, -5);


    private void Start()
    {
        for (int i = 0; i < maxGround; i++)
        {
            SpawnGround(true, currentPosition);
        }
        maxGround = currentGround.Count;
    }

    private void Update()
    {
        ////Quando avanzo crea un nuovo pezzo di terreno e aggiorna la posizione
        //if (Input.GetKeyDown("up") || Input.GetButtonDown("Jump"))
        //{
        //    SpawnGround(false);

        //}
    }

    public void SpawnGround(bool isStart, Vector3 playerPos)
    {
        //Se la distanza è inferiore a minDistnce, spawna un ground e ne elimina uno
        if (currentPosition.z - playerPos.z < minDistanceToPlayer || (isStart))
        {
            int whichGround = Random.Range(0, groundDatas.Count);
            int groundInSuccession = Random.Range(3, groundDatas[whichGround].maxInSuccession);
            for (int i = 0; i < groundInSuccession; i++)
            {
                GameObject ground = Instantiate(groundDatas[whichGround].possibleGround[Random.Range(0, groundDatas[whichGround].possibleGround.Count)], currentPosition, Quaternion.identity);

                //Aggiungo gameobject ground alla lista che mostra la quantità di ground presenti in scena
                currentGround.Add(ground);
                if (!isStart)
                {
                    //Se la quantità di ground presenti in scena è maggiore di max ground, distruggo il primo
                    if (currentGround.Count > maxGround)
                    {
                        Destroy(currentGround[0]);
                        //Rimuovo il primo dalla lista
                        currentGround.RemoveAt(0);
                    }
                }
                //Rendo i ground parenti del contenitore creato
                ground.transform.SetParent(contenitore_Ground);
                currentPosition.z++;
            }
        }
    }
}
