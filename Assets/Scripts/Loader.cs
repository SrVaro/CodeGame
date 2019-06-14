using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{
    public GameObject gameVars; //GameManager prefab to instantiate.

    /* Funcion que se ejecuta cuando se crea el script
       En ella se crea un objeto de la clase GameVars */
    void Awake ()
    {
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (GameVars.instance == null)

            //Instantiate gameManager prefab
            Instantiate(gameVars);
    }
}