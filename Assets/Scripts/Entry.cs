using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry
{
    public string location;
    public double magnitude;
    public string time;
    public string hash;

    public Entry(string loc, double mag, string t, string hash)
    {
        magnitude = mag;
        location = loc;
        time = t;
    }
    public void NewValues(string loc, double mag, string t, string hash)
    {
        magnitude = mag;
        location = loc;
        time = t;
    }
    public void copyEntry(Entry e)
    {
        magnitude = e.magnitude;
        location = e.location;
        time = e.time;
    }
}
