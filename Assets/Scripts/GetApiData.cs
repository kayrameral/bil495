using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using SimpleJSON;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class GetApiData : MonoBehaviour
{
    public static GetApiData instance;
    public string URL;
    public string json;


    private void Awake()
    {
        instance = this;

    }

    void Start()
    {
        //GetData();
    }

    public void GetData()
    {
        StartCoroutine(FetchData());
    }
    public IEnumerator FetchData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {

            yield return request.Send();
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {

                Debug.Log(request.error);
            }
            else
            {
                json = request.downloadHandler.text;
                JSONNode itemsData = JSON.Parse(json);

                if (MainController.instance.entries[0].hash != itemsData[1][0]["hash"])
                {
                    for (int i = 0; i < 5; i++)
                    {
                        MainController.instance.entries[i].location = itemsData[1][i]["lokasyon"];
                        MainController.instance.entries[i].magnitude = itemsData[1][i]["mag"];
                        MainController.instance.entries[i].time = itemsData[1][i]["date"];
                        MainController.instance.entries[i].hash = itemsData[1][i]["hash"];

                       DataBaseController.instance.addToDB(MainController.instance.entries[i]);

                    }
                }



            }
        }
    }
}