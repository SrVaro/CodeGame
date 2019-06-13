using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector: MonoBehaviour
{
    private string lastLevel;

    public Button[] buttons;

    /* Funcion que se ejecuta cuando se inicia la escena */
    void Start()
    {
        lastLevel = PlayerPrefs.GetString("level");

        foreach (var button in buttons)
        {
            button.interactable = false;
        }

        if(PlayerPrefs.HasKey("level"))
        {
            string temp1 = lastLevel.Substring(lastLevel.Length -1, 1);

            levelsUnblocked(int.Parse(temp1));
        }
    }

    /* Metodo que inicia los botones de los niveles como interactuables o no segun el ultimo nivel desbloqueado */
    private void levelsUnblocked(int level)
    {
        for (int i = 0; i < level; i++)
        {
            buttons[i].interactable = true;
        }
    }

}
