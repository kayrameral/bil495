using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Earthquake : MonoBehaviour
{
    public Text Location;
    public Text Magnitude;
    public Text Time;

    public void setValues(string loc, double mag, string time)
    {
        Location.text = loc;
        Magnitude.text = mag+"";
        Time.text = time;
    }
    public string getLocation()
    {
        return Location.text;
    }
}
