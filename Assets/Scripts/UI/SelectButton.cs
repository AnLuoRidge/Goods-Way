using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectButton : MonoBehaviour {
    public int sceneNumber = 0;
    public int productId = 0;
    public void OnBtnSetCatch(int productId)
    {
        PlayerPrefs.SetInt("productId", productId);
        Debug.Log(productId);

    }
    public void OnBtn(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
