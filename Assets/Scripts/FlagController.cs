using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parca1 : MonoBehaviour
{
    public GameObject PuzzlePart1;
    public GameObject PuzzlePart2;
    public GameObject PuzzlePart3;
    public GameObject PuzzlePart4;
    public GameObject PuzzlePart5;
    public GameObject PuzzlePart6;

    void Start()
    {
        // Bayraðý PlayerPrefs'ten alýyoruz
        int flagValue1 = PlayerPrefs.GetInt("PuzzlePart1Flag", 0);  
        int flagValue2 = PlayerPrefs.GetInt("PuzzlePart2Flag", 0);  
        int flagValue3 = PlayerPrefs.GetInt("PuzzlePart3Flag", 0);  
        int flagValue4 = PlayerPrefs.GetInt("PuzzlePart4Flag", 0);  
        int flagValue5 = PlayerPrefs.GetInt("PuzzlePart5Flag", 0);  
        int flagValue6 = PlayerPrefs.GetInt("PuzzlePart6Flag", 0);  

        if (flagValue1 == 1)
        {
            PuzzlePart1.SetActive(true);
        }
        if (flagValue2 == 1)
        {
            PuzzlePart2.SetActive(true);
        }
        if (flagValue3 == 1)
        {
            PuzzlePart3.SetActive(true);
        }
        if (flagValue4 == 1)
        {
            PuzzlePart4.SetActive(true);
        }
        if (flagValue5 == 1)
        {
            PuzzlePart5.SetActive(true);
        }
        if (flagValue6 == 1)
        {
            PuzzlePart6.SetActive(true);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
