using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Collider2D[] gapsOcuppied = new Collider2D[2];

    private ContactFilter2D contactFilter = new ContactFilter2D();

    public Collider2D upCollider, downCollider, leftCollider, rightCollider;

    public LayerMask layerMask;

    private GameObject goal;

    /* Esta funcion se ejecuta siempre al inicio de la escena y se utiliza para inicializar las variables */
    void Start()
    {
        contactFilter.useLayerMask = true;
        contactFilter.layerMask = layerMask;

        goal = GameObject.Find("Goal");
    }

    public bool BlockedDir(string dir){

        bool blocked = false;

        this.GetType().GetField(dir).GetValue(this).OverlapCollider(contactFilter, gapsOcuppied);

        if (gapsOcuppied[0] != null){
            gapsOcuppied = new Collider2D[1];
            blocked = true;
        }

        gapsOcuppied = new Collider2D[1];

        return blocked;
    }

    /* Metodos para comprobar si el camino del jugador esta bloqueado en las diversas direcciones */
    public bool BlockedUp(string dir)
    {
        bool blocked = false;

        upCollider.OverlapCollider(contactFilter, gapsOcuppied);

        if (gapsOcuppied[0] != null){
            gapsOcuppied = new Collider2D[1];
            blocked = true;
        }

        gapsOcuppied = new Collider2D[1];

        return blocked;
    }

    public bool BlockedDown()
    {
        bool blocked = false;

        downCollider.OverlapCollider(contactFilter, gapsOcuppied);

        if (gapsOcuppied[0] != null){
            gapsOcuppied = new Collider2D[1];
            blocked = true;
        }

        gapsOcuppied = new Collider2D[1];

        return blocked;
    }

    public bool BlockedLeft()
    {
        bool blocked = false;

        leftCollider.OverlapCollider(contactFilter, gapsOcuppied);

        if (gapsOcuppied[0] != null)
        {
            gapsOcuppied = new Collider2D[1];
            blocked = true;
        }

        gapsOcuppied = new Collider2D[1];

        return blocked;

    }

    public bool BlockedRight()
    {
        bool blocked = false;

        rightCollider.OverlapCollider(contactFilter, gapsOcuppied);

        if (gapsOcuppied[0] != null)
        {
            gapsOcuppied = new Collider2D[1];
            blocked = true;
        }

        gapsOcuppied = new Collider2D[1];

        return blocked;

    }

    // Metodo que comprueba si el jugador se encuentra en las escaleras (Condicion de victoria)
    public bool checkWinCondition()
    {
        return GetComponent<BoxCollider2D>().OverlapPoint(goal.transform.position);
    }

}
