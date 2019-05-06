using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comando : MonoBehaviour
{
    private bool moviendose = false;

    public string accion;

    private string huecoActual;

    private Vector3 posicionHueco;

    private bool encimaDeHueco = false;

    private bool anclado = false;

    // Update is called once per frame
    void Update()
    {

        if (moviendose)
        {
            MoverCursor();
        }

        if (anclado)
        {
             transform.position = new Vector3(posicionHueco.x, posicionHueco.y, -6);
        }
        
    }

    private void OnMouseDown()
    {
        moviendose = true;
        anclado = false;
    }
    private void OnMouseUp()
    {
        moviendose = false;

        if(encimaDeHueco){
            anclado = true;
        }else{
            huecoActual = "none";
        }
    }

    private void MoverCursor()
    {
        var screenPoint = Input.mousePosition;
        screenPoint.z = 4.0f; //distance of the plane from the camera
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        encimaDeHueco = false;

        Debug.Log("Saliedo de un hueco");

    }

        private void OnTriggerStay2D(Collider2D collision)
    {
        encimaDeHueco = true;

        posicionHueco = collision.gameObject.transform.position;
    }
}
