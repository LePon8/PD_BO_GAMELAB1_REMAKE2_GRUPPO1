using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;
    public bool freezePowerUp;
    public float powerUpDuration = 5f;
    float freezeTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        freezeTime -= Time.deltaTime;
        if (freezeTime >= 0)
        {
            freezePowerUp = false;
        }
    }
    
    public void SetFreezeDuration()
    {
        freezeTime = powerUpDuration;
        freezePowerUp = true;
    }
}
