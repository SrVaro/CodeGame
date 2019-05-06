using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Controller : MonoBehaviour
{

    public Transform comandoArriba;
    public Transform comandoAbajo;
    public Transform comandoIzquierda;
    public Transform comandoDerecha;
    public Transform comandoJump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ComandoArriba()
    {
        Instantiate(comandoArriba, new Vector3(-7, 0, -6), Quaternion.identity);
    }

    public void ComandoAbajo()
    {
        Instantiate(comandoAbajo, new Vector3(-7, 0, -6), Quaternion.identity);
    }

    public void ComandoIzquierda()
    {
        Instantiate(comandoIzquierda, new Vector3(-7, 0, -6), Quaternion.identity);
    }

    public void ComandoDerecha()
    {
        Instantiate(comandoDerecha, new Vector3(-7, 0, -6), Quaternion.identity);
    }

    public void ComandoJump()
    {
        Instantiate(comandoJump, new Vector3(-7, 0, -6), Quaternion.identity);
    }
}
