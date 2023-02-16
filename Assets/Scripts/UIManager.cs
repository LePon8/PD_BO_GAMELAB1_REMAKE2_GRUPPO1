using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [HideInInspector] public static UIManager Instance;

    [Header("Setup in scene")]
    public string MainSceneName;
    [SerializeField] PlayerController playerController;
    [SerializeField] CameraController cameraController;

    [Header("UI elements")]
    [SerializeField] GameObject UIStartMenu;
    [SerializeField] GameObject UIPausa;
    [SerializeField] GameObject UIGameOver;

    // Start is called before the first frame update
    void Start()
    {
        
        if (Instance == null)
            Instance = this;
        //Disattiva lo script del player cercandolo in scena
        playerController.enabled = false;
        cameraController.IsStopped = true;
        //Qui c'era da suicidarsi tutto funzionava usando la funzione Find e usava una String Hardcoded (Simon)
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausa();
        }
        if (playerController.transform.position.z < cameraController.transform.position.z)
        {
            GameOver(false);
        }
    }

    public void StartGame()
    {
        //Disattiva il menu e riattiva lo script
        UIStartMenu.SetActive(false);
        playerController.enabled = true;
        cameraController.IsStopped = false;

    }

    public void Pausa()
    {
        //Attiva il menu di pausa e disattiva lo script del player
        UIPausa.SetActive(true);
        playerController.enabled = false;
        cameraController.IsStopped = true;
        Time.timeScale = 0f;
    }

    //Quando premo il tasto "Resume" toglie la pausa e riattiva lo script del giocatore
    public void Resume()
    {
        UIPausa.SetActive(false);
        playerController.enabled = true;
        cameraController.IsStopped = false;
        Time.timeScale = 1f;
    }
    
    public void GameOver(bool IsSplat)
    {
        UIGameOver.SetActive(true);
        playerController.enabled = false;
        cameraController.IsStopped = true;
        if (IsSplat == true)
            playerController.transform.localScale =new Vector3(1, 0.1f, 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(MainSceneName);
    }
}
