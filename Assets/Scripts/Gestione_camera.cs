using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestione_camera : MonoBehaviour
{
    [SerializeField] public float velocit‡Camera;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimentoCamera();
    }

    public void MovimentoCamera()
    {
        rb.velocity = new Vector3(0, 0, velocit‡Camera);
    }
}
