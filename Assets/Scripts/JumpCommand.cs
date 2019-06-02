using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpCommand : MonoBehaviour
{
    private bool moving, aboveGap = false;

    private string actualGap;

    private Vector3 gapPosition;

    public Material LineMaterial;
    
    public GameObject jump, jumpEnd;   

    private LineRenderer line; 

     /* Funcion que se ejecuta cuando se inicia el inicio */
    void Start ()
    {
         line = this.gameObject.AddComponent<LineRenderer>();

         line.SetWidth(0.05F, 0.05F);

         line.SetVertexCount(3);

         line.sortingLayerName = "Command";

         line.material = LineMaterial;

         line.startWidth = 0.5f;
         
         line.endWidth = 0.5f;
    }
     
    /* Metodo que se ejecuta una vez por FRAME, es decir, 60 por segundos */
    void Update () 
    {
        if (jump != null && jumpEnd != null)
        {
            line.SetPosition(0, new Vector3(jump.transform.position.x, jump.transform.position.y, -6));
            line.SetPosition(1, new Vector3((jump.transform.position.x + 2) + (jumpEnd.transform.position.x + 2), jump.transform.position.y + jumpEnd.transform.position.y, -12) / 2);
            line.SetPosition(2, new Vector3(jumpEnd.transform.position.x, jumpEnd.transform.position.y, -6));
        }

        if (moving) MoverCursor();
    }

    /* Metodo que se llama cuando se presiona el boton izquierdo del raton */
    private void OnMouseDown()
    {
        moving = true;
    }

    /* Metodo que se llama cuando se levanta el boton izquierdo del raton */
    private void OnMouseUp()
    {
        moving = false;

        if(aboveGap){
            transform.position = gapPosition;
        }else{
            actualGap = "none";
        }

    }


    /* Metodo que se sigue el movimiento del raton y se lo aplica al comando */
    private void MoverCursor()
    {
        var screenPoint = Input.mousePosition;
        screenPoint.z = 4.0f; //distance of the plane from the camera
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }


        /* Metodo que se llama cuando el objeto padre entra en un Trigger */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        actualGap = collision.gameObject.name;      
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
    public string getHueco()
    {
        return actualGap;
    }
}
