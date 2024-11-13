using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{

    public void Play(string Level1)
    {
        SceneManager.LoadScene(Level1);
    }



    public void Exit()
    {
        Application.Quit();
        Debug.Log("Aqui se sale del Juego");


    }
}