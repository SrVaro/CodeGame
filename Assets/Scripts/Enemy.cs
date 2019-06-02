using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    private GameObject player;

    /* Esta funcion se ejecuta siempre al inicio de la escena y se utiliza para inicializar las variables */    
    void Start()
    {
        player = GameObject.Find("Player");
    }

    /* Metodo que se ejecuta una vez por FRAME, es decir, 60 por segundos */
    void Update()
    {
        if(GetComponent<BoxCollider2D>().OverlapPoint(player.transform.position)) SceneManager.LoadScene(GameVars.instance.getLevel());
    }
}
