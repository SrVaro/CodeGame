using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    public string action;

    private string actualGap;

    private Vector3 gapPosition;

    private bool aboveGap, locked, moving = false;


    /* Metodo que se ejecuta una vez por FRAME, es decir, 60 por segundos */
    void Update()
    {
        if (moving) MoveCursor();

        if (locked) transform.position = new Vector3(gapPosition.x, gapPosition.y, -6);
    }

    /* Metodo que se llama cuando se presiona el boton izquierdo del raton */
    private void OnMouseDown()
    {
        moving = true;
        locked = false;
    }

    /* Metodo que se llama cuando se levanta el boton izquierdo del raton */
    private void OnMouseUp()
    {
        moving = false;

        if(aboveGap) locked = true;
        else actualGap = "none";
    }

    /* Metodo que se sigue el movimiento del raton y se lo aplica al comando */
    private void MoveCursor()
    {
        var screenPoint = Input.mousePosition;
        screenPoint.z = 4.0f; // Distancia entre el plano y la camara
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    /* Metodo que se llama cuando el objeto padre sale de un Trigger */
    private void OnTriggerExit2D(Collider2D collision)
    {
        aboveGap = false;

    }

    /* Metodo que se llama cuando el objeto padre esta dentro de un Trigger */
    private void OnTriggerStay2D(Collider2D collision)
    {
        aboveGap = true;

        gapPosition = collision.gameObject.transform.position;
    }

    /* Metodo que devuelve un hueco */
    public string getHueco(){
        return actualGap;
    }
}
