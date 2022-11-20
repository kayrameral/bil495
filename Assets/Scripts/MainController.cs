using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using Newtonsoft.Json;
using HtmlAgilityPack;
using System.Net.Http;
using UnityEngine.Networking;

public class MainController : MonoBehaviour
{
    public int max;
    public int freq;
    public float timer;
    public static MainController instance;
    public bool newDataArrived;
    public Entry[] entries;


    private void Awake()
    {
        instance = this;
        entries = new Entry[max];

    }
    void Start()
    {
        for(int i = 0; i<5; i++)
        {
            entries[i]= new Entry("Ankara", i, "19.00", "hash1");
        }
        newDataArrived = true;
    }

    void Update()
    {
        if (timer <= 0) { 
        GetApiData.instance.GetData();
        newDataArrived = true;
            timer = freq;
    }
        timer -= Time.deltaTime; 


    }

}
