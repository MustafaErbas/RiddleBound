using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cablemain : MonoBehaviour
{
    static public Cablemain Instance;

    public int switchCount;
    public GameObject winText;
    private int onCount = 0;

    private void Awake()
    {
        Instance = this;
    }
    public void SwitchChange(int points) {
        onCount = onCount + points;
        if (onCount == switchCount)
        {
            winText.SetActive(true);
            PlayerPrefs.SetInt("CableFinish", 1);
            PlayerPrefs.Save();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("LightHouseChapter");
        }
    }
}
