using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour 
{
    public AudioSource audio;
    public Slider slider;
    public Canvas pause;
	void Start () 
    {
        pause.enabled = false;
        slider.value = audio.volume;
	}
    void Update () 
    {
	    if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pause.enabled = true;
        }
	}
    public void OnResume()
    {
        pause.enabled = false;
        Time.timeScale = 1;
    }
    public void OnBackToMenu()
    {
        Application.LoadLevel("Menu");
        Time.timeScale = 1;
    }
    public void OnSlide()
    {
        audio.volume = slider.value;
    }
}
