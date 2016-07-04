using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    public Canvas exit;
    void Start()
    {
        exit.enabled = false;
    }
    public void OnPlayButton()
    {
        Application.LoadLevel("Cena1");
    }
    public void OnMultiplayer()
    {
        Application.LoadLevel("Cena2");
    }
    public void OnCredits()
    {
        Application.LoadLevel("Credits");
    }
    public void OnExit()
    {
        exit.enabled = true;
    }
    public void OnNo()
    {
        exit.enabled = false;
    }
    public void OnYes()
    {
        Application.Quit();
    }
}
