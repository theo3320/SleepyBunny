using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashMenu : MonoBehaviour
{
  public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void QuitGame()

    {
        Debug.Log("QUIT!!!");
        Application.Quit();
    }
}
