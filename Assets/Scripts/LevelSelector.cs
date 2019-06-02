using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector: MonoBehaviour
{

    private string lastLevel;

    public Button level1, level2, level3, level4, level5, level6;

    /* Funcion que se ejecuta cuando se inicia la escena */
    void Start()
    {

         level1.interactable = level2.interactable = level3.interactable = level4.interactable = level5.interactable = level6.interactable = false;
        
        lastLevel = PlayerPrefs.GetString("level");

        if(PlayerPrefs.HasKey("level")){
            string temp1 = lastLevel.Substring(lastLevel.Length -1, 1);

            levelsUnblocked(int.Parse(temp1));
        }else{

        }
    }

    /* Metodo que inicia los botones de los niveles como interactuables o no segun el ultimo nivel desbloqueado */
    private void levelsUnblocked(int level)
    {
        switch(level)
        {
            case 1:
                level1.interactable = true;
            break;
            
            case 2:
                level1.interactable = level2.interactable = true;
            break;

            case 3:
                level1.interactable = level2.interactable = level3.interactable = true;
            break;

            case 4:
                level1.interactable = level2.interactable = level3.interactable = level4.interactable = true;
            break;

            case 5:
                level1.interactable = level2.interactable = level3.interactable = level4.interactable = level5.interactable = true;
            break;

            case 6:
                level1.interactable = level2.interactable = level3.interactable = level4.interactable = level5.interactable = level6.interactable = true;
            break;

        }
    }

}
