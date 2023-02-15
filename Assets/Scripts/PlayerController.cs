using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [Header("Giocatore")]
    [SerializeField] int forzaAvanzamento = 1;
    [SerializeField] private Animator animazione;
    [SerializeField] int stopPosition;

    [Header("Ground")]
    [SerializeField] private SpawnerGround groundSpawner;

    [Header("Score")]
    [SerializeField] Text scoreText;
    int score = 0;
    [HideInInspector] public int maxScore = 0;

    UIManager uimanager;

    [SerializeField] LayerMask EnemyLayer;
    [SerializeField] LayerMask ObstacleLayerMask;
    [SerializeField] Transform GraphicsTransform;

    private void Start()
    {
       uimanager = UIManager.Instance;
       scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
        Limits();
    }

    public void Movimento()
    {
        //Movimento verticale
        if (Input.GetKeyDown("up") || Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W))
        {
            if (CheckDirection(Vector3.forward))
            {
                transform.Translate(new Vector3(0, 0, forzaAvanzamento));
                score++;

            }
            animazione.SetTrigger("salto");

            if (maxScore < score)
            {
                scoreText.text = "" + score;
                maxScore = score;
            }
        }

        else if (Input.GetKeyDown("down") || Input.GetKeyDown(KeyCode.S))
        {
            if (CheckDirection(Vector3.back))
            {
                transform.Translate(new Vector3(0, 0, -forzaAvanzamento));
                score --;
            }
            animazione.SetTrigger("salto");
        }



        //Movimento orizzontale
        if (Input.GetKeyDown("right") || Input.GetKeyDown(KeyCode.D))
        {
            if (CheckDirection(Vector3.right))
                transform.Translate(new Vector3(forzaAvanzamento, 0, 0));
            animazione.SetTrigger("salto");
        }

        else if (Input.GetKeyDown("left") || Input.GetKeyDown(KeyCode.A))
        {
            if (CheckDirection(Vector3.left))
                transform.Translate(new Vector3(-forzaAvanzamento, 0, 0));
            animazione.SetTrigger("salto");
            
        }

        groundSpawner.SpawnGround(false, transform.position);

    }

    bool CheckDirection(Vector3 DirectionVector)
    {
        GraphicsTransform.LookAt(GraphicsTransform.position + DirectionVector, Vector3.up);
        if (!Physics.CheckBox(transform.position + DirectionVector, Vector3.one * 0.45f, Quaternion.identity, ObstacleLayerMask))
        {
            return true;
        }
        return false;
    }

    void Limits()
    {
        if(transform.position.x >= stopPosition)
        {
            transform.position = new Vector3(stopPosition, transform.position.y, transform.position.z);
        }
        else if(transform.position.x <= -stopPosition)
        {
            transform.position = new Vector3(-stopPosition, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        CarScript carScript = collider.GetComponent<CarScript>();
        if ( carScript != null )
        {
            //Debug.Log("splat");
            uimanager.GameOver(true);

        }
    }

    //void OnBecameVisible()
    //{
    //    Debug.Log("visible");
    //}
    //void OnBecameInvisible()
    //{
    //    uimanager.GameOver();
    //}
}
