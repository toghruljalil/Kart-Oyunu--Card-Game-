using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneManager : MonoBehaviour
{
    [SerializeField] private GameObject Info;
    [SerializeField] private GameObject Main;
    [SerializeField] private GameObject Input;
    public void DigerSahne()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void InfodanMaine()
    {
        Info.SetActive(false);
        Main.SetActive(true);
    }

    public void MaindenInfoya()
    {
        Info.SetActive(true);
        Main.SetActive(false);
    }

    public void InputaGec()
    {
        Main.SetActive(false);
        Input.SetActive(true);
    }

    public void MenuyeDon()
    {
        SceneManager.LoadScene(0);
    }

    public void Tekrar()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
