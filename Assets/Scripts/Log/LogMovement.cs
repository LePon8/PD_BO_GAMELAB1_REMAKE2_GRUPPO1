using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour
{
    public float logSpeed = 5f;
    public float logLifetime = 6.0f;

    void Update()
    {
        if (PowerUpManager.Instance.freezePowerUp == false)
            transform.position += new Vector3(logSpeed * Time.deltaTime, 0, 0);
    }
}
