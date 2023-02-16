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
    [SerializeField] LayerMask WaterLayerMask;
    [SerializeField] LayerMask LogLayerMask;
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
            if (CheckDirection(Vector3.forward, ObstacleLayerMask))
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
            if (CheckDirection(Vector3.back, ObstacleLayerMask))
            {
                transform.Translate(new Vector3(0, 0, -forzaAvanzamento));
                score --;
            }
            animazione.SetTrigger("salto");
        }


        if (transform.position.x <= stopPosition - 1f)
        {
            //Movimento orizzontale
            if (Input.GetKeyDown("right") || Input.GetKeyDown(KeyCode.D))
            {
                if (CheckDirection(Vector3.right, ObstacleLayerMask))
                    transform.Translate(new Vector3(forzaAvanzamento, 0, 0));
                animazione.SetTrigger("salto");
            }
        }
        if (transform.position.x >= -stopPosition + 1f)
        {
            if (Input.GetKeyDown("left") || Input.GetKeyDown(KeyCode.A))
            {
                if (CheckDirection(Vector3.left, ObstacleLayerMask))
                    transform.Translate(new Vector3(-forzaAvanzamento, 0, 0));
                animazione.SetTrigger("salto");

            }
        }
        groundSpawner.SpawnGround(false, transform.position);

    }

    bool CheckDirection(Vector3 DirectionVector, LayerMask layerMask)
    {
        GraphicsTransform.LookAt(GraphicsTransform.position + DirectionVector, Vector3.up);
        if (!Physics.CheckBox(transform.position + DirectionVector, Vector3.one * 0.45f, Quaternion.identity, layerMask))
        {
            return true;
        }
        return false;
    }

    void Limits()
    {
        if(transform.position.x >= stopPosition + 1)
        {
            uimanager.GameOver(false);
            //transform.position = new Vector3(stopPosition, transform.position.y, transform.position.z);
        }
        else if(transform.position.x <= -stopPosition -1)
        {
            uimanager.GameOver(false);
            //transform.position = new Vector3(-stopPosition, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            uimanager.GameOver(true);
            //Debug.Log("splat");
        }

        if (collider.CompareTag("Log"))
        {
            transform.SetParent(collider.transform);
            Debug.Log("thock");
            
        }
        if (collider.CompareTag("Water"))
        {
            if (!Physics.CheckBox(transform.position, Vector3.one * 0.45f, Quaternion.identity, LogLayerMask))
            {
                uimanager.GameOver(true);
            }            
            //Debug.Log("splat");
        }

    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Log"))
        {
            transform.parent = null;
            Vector3 RoundedPositionXZ = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
            transform.position = RoundedPositionXZ;            
            if (Physics.CheckBox(transform.position, Vector3.one * 0.45f, Quaternion.identity, WaterLayerMask))
            {
                if (!Physics.CheckBox(transform.position, Vector3.one * 0.45f, Quaternion.identity, LogLayerMask))
                {
                    uimanager.GameOver(true);
                }
            }
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
