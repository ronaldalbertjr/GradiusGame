using UnityEngine;
using System.Collections;

public class BackToMenuScript : MonoBehaviour
{
    public void OnBackToMenu()
    {
        Application.LoadLevel("Menu");
    }
}
