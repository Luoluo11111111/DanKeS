using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ZhuScene_tiaozhuan : MonoBehaviour
{
    public Button button;
    void Start()
    {
        button.onClick.AddListener(() =>
        {
            SceneManager.LoadSceneAsync("SampleScene");
        });
    }

    void Update()
    {
        
    }
}
