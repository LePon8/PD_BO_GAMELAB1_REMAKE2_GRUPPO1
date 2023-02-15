using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Gameplay relative")]
    //[SerializeField, Min(1)] int MaxDifficultyScore;
    [SerializeField] public float CamSpeed;
    public float DistanceBeforeCatchup = 5f;

    public float CatchupSpeed = 6;
    [Tooltip("Zone after Distance bbefore cathup in witch Catchup speed is gradualy scaled")]
    public float CatchupZone = 3f;
    //public AnimationCurve CamSpeedCurve;

    [Header ("Setup")]
    [SerializeField] PlayerController playerController;
    [SerializeField] Transform CameraHolder;
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
        float DistanceToPlayer = CameraHolder.position.z - playerController.transform.position.z;

        //Calculation of the speed trought distance 
        float SpeedWhitDistance = CamSpeed + (CatchupSpeed * (Mathf.Clamp(-DistanceToPlayer - DistanceBeforeCatchup,0,CatchupZone) / CatchupZone));
        //Debug.Log(SpeedWhitDistance + " the Speed is this");
        //Debug.Log(-DistanceBeforeCatchup - DistanceToPlayer);
        if (IsStopped == false)
            CameraHolder.Translate(Vector3.forward * SpeedWhitDistance * Time.deltaTime, Space.World);
    }
}
