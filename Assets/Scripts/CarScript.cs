using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float CarSpeed = 5f;
    public float CarLifetime = 6.0f;
    //public float speedIncrement = 0.1f;

    //private float currentSpeed;

    void Start()
    {
        //currentSpeed = CarSpeed;
    }

    void Update()
    {
        if (CarLifetime <= 0f)
        {
            Destroy(gameObject);
            return;
        }
        if (PowerUpManager.Instance.freezePowerUp == false)
            transform.position += new Vector3(CarSpeed * Time.deltaTime, 0, 0);
        //currentSpeed += speedIncrement * Time.deltaTime;
        CarLifetime -= Time.deltaTime;
    }
}
