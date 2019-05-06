using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : MonoBehaviour
{
    private bool moviendose = false;

    public string accion;

    private string huecoActual;

    private Vector3 posicionHueco;

    private bool encimaDeHueco = false;

    public Material LineMaterial;
    
     public GameObject gameObject1;          // Reference to the first GameObject

     public GameObject gameObject2;          // Reference to the second GameObject
 
     private LineRenderer line;                           // Line Renderer

     // Use this for initialization
     void Start () {
         // Add a Line Renderer to the GameObject
         line = this.gameObject.AddComponent<LineRenderer>();
         // Set the width of the Line Renderer
         line.SetWidth(0.05F, 0.05F);
         // Set the number of vertex fo the Line Renderer
         line.SetVertexCount(3);

         line.sortingLayerName = "Command";

         line.material = LineMaterial;

         line.startWidth = 0.5f;
         
         line.endWidth = 0.5f;
     }
     
     // Update is called once per frame
     void Update () {
         // Check if the GameObjects are not null
         if (gameObject1 != null && gameObject2 != null)
         {
             // Update position of the two vertex of the Line Renderer
             line.SetPosition(0, new Vector3(gameObject1.transform.position.x, gameObject1.transform.position.y, -6));
             line.SetPosition(1, new Vector3((gameObject1.transform.position.x + 2) + (gameObject2.transform.position.x + 2), gameObject1.transform.position.y + gameObject2.transform.position.y, -12) / 2);
             line.SetPosition(2, new Vector3(gameObject2.transform.position.x, gameObject2.transform.position.y, -6));
         }

         if (moviendose)
        {
            MoverCursor();
        }
     }

     private void OnMouseDown()
    {
        moviendose = true;
    }
    private void OnMouseUp()
    {
        moviendose = false;

        if(encimaDeHueco){
            transform.position = posicionHueco;
        }else{
            huecoActual = "none";
        }

        Debug.Log(huecoActual);

    }

    private void MoverCursor()
    {
        var screenPoint = Input.mousePosition;
        screenPoint.z = 4.0f; //distance of the plane from the camera
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Tocando el " + collision.gameObject.name);  

        huecoActual = collision.gameObject.name;      
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
