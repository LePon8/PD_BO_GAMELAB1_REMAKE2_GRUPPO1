using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainScripts : MonoBehaviour
{
    public float TrainSpeed;
    public float TrainIntervallTime;
    public float TrainWarn;
    public float LightAlternationTime;
    public float TrainLifetime;


    [SerializeField] Transform InitialPosition;
    [SerializeField] Transform TrainGameobject;
    [SerializeField] GameObject[] Lights;

    float LightCooldown;
    float Cooldown;
    int LightCount;

    // Start is called before the first frame update
    void Start()
    {
        TrainGameobject.position = InitialPosition.position;
        Cooldown = Random.Range(0, TrainIntervallTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (TrainIntervallTime - TrainWarn <= Cooldown)
        {
            Lights[LightCount].SetActive(true);
            if (LightAlternationTime <= LightCooldown)
            {
                if (LightCount == 1)
                {
                    LightCount = 0;
                    Lights[1].SetActive(false);
                }
                else
                {
                    LightCount = 1;
                    Lights[0].SetActive(false);
                }
                LightCooldown += Time.deltaTime;
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
        }
        else
        {
            foreach (GameObject light in Lights)
            {
                light.SetActive(false);
            }
        }
        Cooldown += Time.deltaTime;

    }
}
