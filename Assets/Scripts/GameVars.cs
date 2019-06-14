using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class GameVars : MonoBehaviour
{

    public static GameVars instance = null;     //Instancia statica de Gamevar que permite ser accedida desde otro script

    private int score = 2;

    private string level;

    void Awake()
    {
        //Comprueba si ya existe alguna instancia
        if (instance == null)  instance = this;

        // Si la instancia que es otra diferente a esta destruye la otra, ya que solo puede haber una instancia de GameVars
        else if (instance != this) Destroy(gameObject);

        // Hace que este objeto no se destruya entre escenas
        DontDestroyOnLoad(gameObject);
    }

    /* GETTERS y SETTERS */
    public int getScore()
    {
        return score;
    }

    public void setScore(int score)
    {
        this.score = score;
    }

    public void setLevel(string level)
    {
        this.level = level;

        Debug.Log(level);
    }

    public string getLevel()
    {
        return level;
    }

    /* Metodo que guarda el ultimo nivel jugado */
    public void saveLastLevel(string level)
    {
        if(PlayerPrefs.HasKey("level"))
        {
            int lastLevel = GetLevelNumber(PlayerPrefs.GetString("level"));

            int newLevelNumber =  GetLevelNumber(level);

            if(newLevelNumber > lastLevel) PlayerPrefs.SetString("level", level);
        }
    }

    private int GetLevelNumber(string level)
    {
        string temp = level;
        string output = temp.Substring(temp.Length -1, 1);
        int levelNumber = int.Parse(output);

        levelNumber++;

        return levelNumber;
    }
}