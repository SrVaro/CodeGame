using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Controller : MonoBehaviour
{

    public Transform upCommand, downCommand, leftCommand, rightCommand, fUpCommand, fDownCommand, fLeftCommand, fRightCommand, jumpCommand;
    private Vector2 position;

    private Vector2 scale = new Vector2(1.5f, 1.5f);

    /* Esta funcion se ejecuta siempre al inicio de la escena y se utiliza para inicializar las variables */
    void Start()
    {
        string temp = PlayerPrefs.GetString("level");
        string output = temp.Substring(temp.Length -1, 1);
        int levelNumber = int.Parse(output);
    }

    /* Metodos que controlan todos los botones del juego */
    public void titleScreen()
    {
        StartCoroutine(GameObject.FindObjectOfType<Fade_Scene>().FadeAndLoadScene(Fade_Scene.FadeDirection.In, "TitleScreen"));
    }

    public void levelsScreen()
    {
       StartCoroutine(GameObject.FindObjectOfType<Fade_Scene>().FadeAndLoadScene(Fade_Scene.FadeDirection.In, "Levels"));
    }

    public void UpCommand()
    {
        Instantiate(upCommand, new Vector3(-7, 0, -6), Quaternion.identity);
    }

    public void DownCommand()
    {
        Instantiate(downCommand, new Vector3(-7, 0, -6), Quaternion.identity);
    }

    public void LeftCommand()
    {
        Instantiate(leftCommand, new Vector3(-7, 0, -6), Quaternion.identity);
    }

    public void RightCommand()
    {
        Instantiate(rightCommand, new Vector3(-7, 0, -6), Quaternion.identity);
    }

    public void FUpCommand()
    {
        Instantiate(fUpCommand, new Vector3(-7, 0, -6), Quaternion.identity);
    }

    public void FDownCommand()
    {
        Instantiate(fDownCommand, new Vector3(-7, 0, -6), Quaternion.identity);
    }

    public void FLeftCommand()
    {
        Instantiate(fLeftCommand, new Vector3(-7, 0, -6), Quaternion.identity);
    }

    public void FRightCommand()
    {
        Instantiate(fRightCommand, new Vector3(-7, 0, -6), Quaternion.identity);
    }

    public void JumpCommand()
    {
        Instantiate(jumpCommand, new Vector3(-7, -6, -6), Quaternion.identity);
    }

    public void LoadLevel(int levelN)
    {
        string level = "Level" + levelN;
        StartCoroutine(GameObject.FindObjectOfType<Fade_Scene>().FadeAndLoadScene(Fade_Scene.FadeDirection.In, level));
    }

     public void LoadLastLevel()
    {
        string lastLevel = PlayerPrefs.GetString("level");
        if(PlayerPrefs.HasKey("level"))
        {
            StartCoroutine(GameObject.FindObjectOfType<Fade_Scene>().FadeAndLoadScene(Fade_Scene.FadeDirection.In, lastLevel));
        }else{
            StartCoroutine(GameObject.FindObjectOfType<Fade_Scene>().FadeAndLoadScene(Fade_Scene.FadeDirection.In, "Level1"));
        }
    }

    public void ResumeLevel()
    {
        GameObject.Find("CommandPanel").GetComponent<Logic>().pauseMenu();
    }

    public void LoadNextLevel()
    {
        string nextLevel = "Level" + GetLevelNumber(GameVars.instance.getLevel());

        StartCoroutine(GameObject.FindObjectOfType<Fade_Scene>().FadeAndLoadScene(Fade_Scene.FadeDirection.In, nextLevel));
    }

    public void RetryLevel()
    {
        StartCoroutine(GameObject.FindObjectOfType<Fade_Scene>().FadeAndLoadScene(Fade_Scene.FadeDirection.In, GameVars.instance.getLevel()));
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
