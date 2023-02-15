using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Gameplay relative")]
    [SerializeField, Min(1)] int MaxDifficultyScore;
    [SerializeField] public float CamSpeed;
    //public AnimationCurve CamSpeedCurve;

    [Header ("Setup")]
    PlayerController playerController;
    public bool IsStopped;
    //Rigidbody rb; che pazzia usare un RB per cose cosi semplici (Simon)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentoCamera();
    }

    public void MovimentoCamera()
    {
       //float DesiredCamSpeed = CamSpeed * ( 1 + CamSpeedCurve.Evaluate(Mathf.Min(playerController.maxScore / MaxDifficultyScore, 1f)));

        if (IsStopped == false)
            transform.Translate(Vector3.forward * CamSpeed * Time.deltaTime, Space.World);
    }
}
