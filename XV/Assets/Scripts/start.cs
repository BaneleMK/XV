using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public void StartWorking()
    {
        WorkerController[] g = FindObjectsOfType<WorkerController>();
        for (int i = 0; g[i] != null; i++)
        {
            g[i].starWorking();
        }
    }

    public void Startgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exitgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void pauseSim()
    {
        Time.timeScale = 0;
    }

    public void resume()
    {
        Time.timeScale = 1;
    }

}
