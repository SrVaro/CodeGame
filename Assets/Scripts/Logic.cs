using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    private Vector2 initialPosition;

    public GameObject playButton, menu, gameUI;
    
    public int highScore, lowScore;
    
    public Collider2D[] gaps;

    private Collider2D[] gapCommand = new Collider2D[2];

    private List<string> actionList = new List<string>();

    private ContactFilter2D contactFilter = new ContactFilter2D();

    public LayerMask layerMask;

    private GameObject player;

    private Player playerScript;

    public float movement;

    private int commands;

    private bool menuActive, locked;

    private float maxY;

    /* Esta funcion se ejecuta siempre al inicio de la escena y se utiliza para inicializar las variables */
    void Start() 
    {
        maxY = transform.position.y;

        contactFilter.useLayerMask = true;
        contactFilter.layerMask = layerMask;

        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();

        initialPosition = player.transform.position;

        PlayerPrefs.SetString("level", SceneManager.GetActiveScene().name);

        GameVars.instance.setLevel(SceneManager.GetActiveScene().name);
        GameVars.instance.setScore(0);
    }
    
    /* Funcion que se ejecuta cada FRAME del juego, es decir 60 veces por segundo */
    void Update()
    {
        if (transform.position.y < maxY) transform.position = new Vector3(transform.position.x, maxY, transform.position.z);

        if (Input.GetAxis("Mouse ScrollWheel") != 0f) 
            transform.position -= new Vector3(0, Input.GetAxis("Mouse ScrollWheel") * 1.25f, 0);

        if (Input.GetKeyDown(KeyCode.P))
            pauseMenu();
    }

    /* Funcion que se llamara desde la UI que llama a los metodos para leer los comandos y ejecutarlos */
    public void Play()
    {
        readCommands();

        StartCoroutine("readActions");
    }

    /* Corutina que lee las acciones de la lista y los ejecuta de uno en uno, ademas de añadir las
       el efecto de movimiento al personaje */
    IEnumerator readActions()
    {
        // Se desactiva el boton para que el usuario no pueda volver a pulsar el boton de play
        playButton.SetActive(false);

        int jumpEnd = 0;

        Transform pT = player.transform;
        
        /* Se itera sobre el numero de acciones de la lista, se utiliza un bucle for y no un foreach
           ya que en el bucle for podemos modificar el contador y asi controlar el flujo de las acciones */
        for (int i = 0; i < actionList.Count; i++)
        {
            switch (actionList[i])
            {
                case "Up":
                    if(!playerScript.BlockedUp())
                    {
                        for (float value = movement; value >= 0; value -= 0.1f)
                        {
                            pT.position = new Vector2(pT.position.x, pT.position.y + 0.1f);
                            yield return null;
                        }
                        if(player.GetComponent<Player>().checkWinCondition()) rankLevel();
                    }
                break;

                case "Down":
                    if(!playerScript.BlockedDown())
                    {
                        for (float value = movement; value >= 0; value -= 0.1f)
                        {
                            pT.position = new Vector2(pT.position.x, pT.position.y - 0.1f);
                            yield return null;
                        }
                        if(player.GetComponent<Player>().checkWinCondition()) rankLevel();
                    }
                break;

                case "Left":
                    if(!playerScript.BlockedLeft())
                    {
                        for (float value = movement; value >= 0; value -= 0.1f)
                        {
                            pT.position = new Vector2(pT.position.x - 0.1f, pT.position.y);
                            yield return null;
                        }
                        if(player.GetComponent<Player>().checkWinCondition()) rankLevel();
                    }
                break;

                case "Right":
                    if(!playerScript.BlockedRight())
                    {
                        for (float value = movement; value >= 0; value -= 0.1f)
                        {
                            pT.position = new Vector2(pT.position.x + 0.1f, pT.position.y);
                            yield return null;
                        }
                        if(player.GetComponent<Player>().checkWinCondition()) rankLevel();
                    }
                break;

                case "FUp":
                    while(!playerScript.BlockedUp())
                    {
                        for (float value = movement; value >= 0; value -= 0.1f)
                        {
                            pT.position = new Vector2(pT.position.x, pT.position.y + 0.1f);
                            yield return null;
                        }
                        if(player.GetComponent<Player>().checkWinCondition()) rankLevel();
                    }
                break;

                case "FDown":
                    while(!playerScript.BlockedDown())
                    {
                        for (float value = movement; value >= 0; value -= 0.1f)
                        {
                            pT.position = new Vector2(pT.position.x, pT.position.y - 0.1f);
                            yield return null;
                        }
                        if(player.GetComponent<Player>().checkWinCondition()) rankLevel();
                    }
                break;

                case "FLeft":
                    while(!playerScript.BlockedLeft())
                    {
                        for (float value = movement; value >= 0; value -= 0.1f)
                        {
                            pT.position = new Vector2(pT.position.x - 0.1f, pT.position.y);
                            yield return null;
                        }
                        if(player.GetComponent<Player>().checkWinCondition()) rankLevel();
                    }
                break;

                case "FRight":
                    while(!playerScript.BlockedRight())
                    {
                        for (float value = movement; value >= 0; value -= 0.1f)
                        {
                            pT.position = new Vector2(pT.position.x + 0.1f, pT.position.y);
                            yield return null;
                        }
                        if(player.GetComponent<Player>().checkWinCondition()) rankLevel();
                    }
                break;

                case "JumpEnd":
                    jumpEnd = i;
                break;

                case "Jump":
                    i = jumpEnd;
                break;
            }
        }

        /* Si se realizan todas las acciones y aun no se ha llegado a la meta se reinicia el nivel */
        if(!player.GetComponent<Player>().checkWinCondition()) restartLevel();

    }

    /* Metodo para leer todas los comandos introducidos por el usuario y guardar sus acciones en una lista.
       Ademas de guardar el numero de comandos utilizados en el nivel */
    private void readCommands()
    {
        foreach (var gap in gaps)
        {
            gap.OverlapCollider(contactFilter, gapCommand);

            foreach (var command in gapCommand)
            {
                if (command != null)
                {
                    this.actionList.Add(command.gameObject.GetComponent<Command>().action);
                    if(command.gameObject.GetComponent<Command>().action != "JumpEnd")
                    {
                        this.commands++;
                    }
                    gapCommand = new Collider2D[2];
                }
            }
        }
    }

    /* Metodo para clasificar el nivel en base al numero de comandos utilizados en este */
    private void rankLevel()
    {
        switch(this.commands){
            case var _ when commands <= highScore:
                GameVars.instance.setScore(3);
            break;

            case var _ when commands >= lowScore:
                GameVars.instance.setScore(1);
            break;

            default:
                GameVars.instance.setScore(2);
            break;
        }

        StartCoroutine(GameObject.FindObjectOfType<Fade_Scene>().FadeAndLoadScene(Fade_Scene.FadeDirection.In, "WinScreen"));
    }
    
    // Metodo utilizado para reiniciar el nivel
    public void restartLevel()
    {
        player.transform.position = initialPosition;

        actionList = new List<string>();

        playButton.SetActive(true);
    }

    // Metodo para activar el menu de pausa y desactivar la UI principal
    public void pauseMenu()
    {
        menuActive = !menuActive;

        menu.SetActive(menuActive);

        gameUI.SetActive(!menuActive);
    }
}
