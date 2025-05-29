using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private bool oyuncu_icinde = false;
    public GameObject puzzleEntryText;

    void Update()
    {
            if (oyuncu_icinde && Input.GetKeyDown(KeyCode.E))
            {
                GameManager.Instance.karakterPozisyonu = GameObject.FindWithTag("Player").transform.position;
                GameManager.Instance.pozisyonKayitli = true;
                SceneManager.LoadScene("Puzzle");
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            oyuncu_icinde = true;
            puzzleEntryText.SetActive(true);

            if (this.gameObject.name == "Bitis")
            {
                SceneManager.LoadScene("LightHouseChapter");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            oyuncu_icinde = false;
            puzzleEntryText.SetActive(false);
        }
    }
}
