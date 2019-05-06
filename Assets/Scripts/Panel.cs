using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject playButton;
    
    public Collider2D[] huecos;

    private Collider2D[] huecosOcupados = new Collider2D[2];

    private ContactFilter2D contactFilter = new ContactFilter2D();

    private List<string> listaAcciones = new List<string>();

    public GameObject player;

    private bool moviendose = false;

    private float maxY = -7;
    
    void Update(){

        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));

        if (Input.GetAxis("Mouse ScrollWheel") != 0f) // forward
        {
            transform.position -= new Vector3(0, Input.GetAxis("Mouse ScrollWheel") * 1.25f, 0);
        }
    }


    public void OverlapCircle()
    {
        foreach (var hueco in huecos)
        {
            hueco.OverlapCollider(contactFilter.NoFilter(), huecosOcupados);

            foreach (var item in huecosOcupados) {

                if (item != null)
                {
                    moviendose = true;

                    listaAcciones.Add(item.gameObject.GetComponent<Comando>().accion);

                    huecosOcupados = new Collider2D[1];
                }              
            }
        }

        StartCoroutine("LeerAcciones");

    }

    IEnumerator LeerAcciones()
    {

        playButton.SetActive(false);

        int jumpEnd = 0;

        for (int i = 0; i < listaAcciones.Count; i++)
        {
            
            switch (listaAcciones[i])
            {
                case "Arriba":

                    if(!player.GetComponent<Player>().BlockedUp()){
                        for (float value = 2f; value >= 0; value -= 0.1f)
                        {
                            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.1f);
                            yield return null;
                        }
                    }

                    moviendose = false;

                    break;

                case "Abajo":

                    if(!player.GetComponent<Player>().BlockedDown()){
                        for (float value = 2f; value >= 0; value -= 0.1f)
                        {
                            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 0.1f);
                            yield return null;
                        }
                    }

                    moviendose = false;

                    break;

                case "Izquierda":

                    if(!player.GetComponent<Player>().BlockedLeft()){
                        for (float value = 2f; value >= 0; value -= 0.1f)
                        {
                            player.transform.position = new Vector2(player.transform.position.x - 0.1f, player.transform.position.y);
                            yield return null;
                        }
                    }
                    moviendose = false;

                    break;

                case "Derecha":

                    if(!player.GetComponent<Player>().BlockedRight()){
                        for (float value = 2f; value >= 0; value -= 0.1f)
                        {
                            player.transform.position = new Vector2(player.transform.position.x + 0.1f, player.transform.position.y);
                            yield return null;
                        }
                    }

                    moviendose = false;

                    break;

                case "JumpEnd":

                    jumpEnd = i;

                    break;

                case "Jump":

                    i = jumpEnd;

                    break;
            }
        }

        listaAcciones = new List<string>();

        playButton.SetActive(true);
    }
}
