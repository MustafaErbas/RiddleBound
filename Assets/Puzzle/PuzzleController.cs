using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleController : MonoBehaviour
{
    int yerlestirilen_parca = 0;
    int toplam_puzzle = 11;
    public GameObject gameOverText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("StationChapter");
        }
    }

    public void sayi_arttir()
    {
        yerlestirilen_parca++;

        if (yerlestirilen_parca == toplam_puzzle)
        {
            PlayerPrefs.SetInt("finishLine", 1);
            PlayerPrefs.Save();
            gameOverText.SetActive(true);
        }
    }
}
