using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevel : MonoBehaviour
{
    public void PlaygroundLevel()
    {
        Loader.Load(Loader.Scene.BikeCourse);
    }
    public void MainMenuLevel()
    {
        Loader.Load(Loader.Scene.MainMenu);
    }
    public void IntroLevel()
    {
        Loader.Load(Loader.Scene.Level01);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Loader.Load(Loader.Scene.MainMenu);
        }
    }
}
