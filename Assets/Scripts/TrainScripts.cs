using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScripts : MonoBehaviour
{
    public float TrainSpeed = 15f;
    public float TrainIntervallTime = 15f;
    public float TrainWarn = 2f;
    public float LightAlternationTime = 0.25f;
    public float DistanceToTravel = 30f;


    [SerializeField] Transform InitialPosition;
    [SerializeField] Transform TrainGameobject;
    [SerializeField] GameObject[] Lights;

    float LightCooldown = 0.25f;
    float Cooldown;
    int LightCount = 0;
    float TrainLifetime;

    // Start is called before the first frame update
    void Start()
    {
        TrainGameobject.position = InitialPosition.position;
        Cooldown = Random.Range(0, TrainIntervallTime);
        TrainLifetime = DistanceToTravel / TrainSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (TrainIntervallTime - TrainWarn <= Cooldown && TrainIntervallTime + TrainLifetime >= Cooldown)
        {
            if (LightCooldown <= 0)
            {
                if (LightCount == 1)
                {
                    Lights[0].SetActive(true);
                    Lights[1].SetActive(false);
                    LightCount = 0;
                }
                else
                {
                    Lights[1].SetActive(true);
                    Lights[0].SetActive(false);
                    LightCount = 1;
                }
                LightCooldown = LightAlternationTime;
            }
            LightCooldown -= Time.deltaTime;
        }
        else
        {
            foreach (GameObject light in Lights)
            {
                light.SetActive(false);
            }
        }

        if (TrainIntervallTime <= Cooldown)
        {
            TrainGameobject.transform.Translate(Vector3.right * Time.deltaTime * TrainSpeed,Space.World);
        }

        if (TrainIntervallTime + TrainLifetime <= Cooldown)
        {
            TrainGameobject.position = InitialPosition.position;
            Cooldown = 0f;
        }
        Cooldown += Time.deltaTime;

    }
}
