using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public int max;
    public Earthquake[] earthquakes;
    public Text clock;

    void Update()
    {
        clock.text = "Timer: "+MainController.instance.timer;
        if (MainController.instance.newDataArrived) {
            for (int i = 0; i < max; i++)
            {
                if (MainController.instance.entries[i].magnitude == 0)
                {
                    earthquakes[i].setValues("", 0, "");
                }
                else
                {
                    earthquakes[i].setValues(MainController.instance.entries[i].location, MainController.instance.entries[i].magnitude, MainController.instance.entries[i].time);
                }
            }
            MainController.instance.newDataArrived = false;
        }
        
    }
}
