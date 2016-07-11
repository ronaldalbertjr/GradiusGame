using UnityEngine;
using System.Collections;

public class BackToMenuScript : MonoBehaviour
{
    public void OnBackToMenu()
    {
        Application.LoadLevel("Menu");
    }
    public void OnPlay()
    {
        Application.LoadLevel("Cena1");
    }
    public void OnMultiplayerPlay()
    {
        Application.LoadLevel("Cena2");
    }
}
