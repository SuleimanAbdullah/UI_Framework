using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadAdditionGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadFruitGame()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadSubstractionGame()
    {
        SceneManager.LoadScene(4);
    }
}
