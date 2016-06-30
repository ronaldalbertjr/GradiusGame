using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    public void OnPlayButton()
    {
        Application.LoadLevel("Cena1");
    }
    public void OnExit()
    {
        Application.Quit();
    }
}
