using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rating : MonoBehaviour
{

    public GameObject fullStarPrefab, emptyStarPrefab;

    public Transform star1Position, star2Position, star3Position;

    /* Funcion que se ejecuta cuando se crea el script
       En ella se recoge la puntuación del nivel terminado e instanciar el numero de estrellas correspondiente */
    void Awake()
    {
        switch(GameVars.instance.getScore()){
            case 1:

                Instantiate(fullStarPrefab, star1Position.position, Quaternion.identity);
                Instantiate(emptyStarPrefab, star2Position.position, Quaternion.identity);
                Instantiate(emptyStarPrefab, star3Position.position, Quaternion.identity);

            break;

            case 2:

                Instantiate(fullStarPrefab, star1Position.position, Quaternion.identity);
                Instantiate(fullStarPrefab, star2Position.position, Quaternion.identity);
                Instantiate(emptyStarPrefab, star3Position.position, Quaternion.identity);

            break;

            case 3:

                Instantiate(fullStarPrefab, star1Position.position, Quaternion.identity);
                Instantiate(fullStarPrefab, star2Position.position, Quaternion.identity);
                Instantiate(fullStarPrefab, star3Position.position, Quaternion.identity);

            break;
        }
    }
}
