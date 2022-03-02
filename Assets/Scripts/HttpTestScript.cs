using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HttpTestScript : MonoBehaviour
{
    public GameObject text_object = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        StartCoroutine(HttpConnect());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // HTTPリクエスト実行
    IEnumerator HttpConnect()
    {
        string url = "http://127.0.0.1:3101/users/";
        UnityWebRequest uwr = UnityWebRequest.Get(url);
        yield return uwr.SendWebRequest();
        if (uwr.result == UnityWebRequest.Result.ProtocolError || uwr.result == UnityWebRequest.Result.ConnectionError) {
            Debug.Log(uwr.error);
        } else {
            Debug.Log(uwr.downloadHandler.text);

            // テキストの書き換え
            Text test_text = text_object.GetComponent<Text> ();
            test_text.text = "変更後テキスト";
        }
    }
}
