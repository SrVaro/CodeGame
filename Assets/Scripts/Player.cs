using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Collider2D[] huecosOcupados = new Collider2D[2];

    private ContactFilter2D contactFilter = new ContactFilter2D();

    public Collider2D upCollider;

    public Collider2D downCollider;

    public Collider2D leftCollider;

    public Collider2D rightCollider;


    public bool BlockedUp(){

        upCollider.OverlapCollider(contactFilter.NoFilter(), huecosOcupados);

        if (huecosOcupados[0] != null)
        {
            Debug.Log("Celda superior ocupado");

            huecosOcupados = new Collider2D[1];  

            return true;
        }  

        Debug.Log("Celda superior libre");
        
        huecosOcupados = new Collider2D[1];  
        
        return false;
    }

    public bool BlockedDown(){

        downCollider.OverlapCollider(contactFilter.NoFilter(), huecosOcupados);

        if (huecosOcupados[0] != null)
        {
            Debug.Log("Celda inferior ocupado");

            huecosOcupados = new Collider2D[1];  

            return true;
        }              

        Debug.Log("Celda inferior libre");

        huecosOcupados = new Collider2D[1];  

        return false;
    }

    public bool BlockedLeft(){

        leftCollider.OverlapCollider(contactFilter.NoFilter(), huecosOcupados);

        if (huecosOcupados[0] != null)
        {
            Debug.Log("Celda izquierda ocupado");

            huecosOcupados = new Collider2D[1];  

            return true;
        }          

        Debug.Log("Celda izquierda libre");

        huecosOcupados = new Collider2D[1];     

        return false; 

    }

    public bool BlockedRight(){

        rightCollider.OverlapCollider(contactFilter.NoFilter(), huecosOcupados);

        if (huecosOcupados[0] != null)
        {
            Debug.Log("Celda derecha ocupado");

            huecosOcupados = new Collider2D[1];  

            return true;
        }     

        Debug.Log("Celda derecha libre");

        huecosOcupados = new Collider2D[1];     

        return false;      

    }


}
