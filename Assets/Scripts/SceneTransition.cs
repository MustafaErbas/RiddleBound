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
        if (oyuncu_icinde)
        {
            puzzleEntryText.SetActive(true);

            if (oyuncu_icinde && Input.GetKeyDown(KeyCode.E))
            {
                GameManager.Instance.karakterPozisyonu = transform.position;
                GameManager.Instance.pozisyonKayitli = true;
                SceneManager.LoadScene("Puzzle");
            }
        }
        else
        {
            puzzleEntryText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            oyuncu_icinde = true;

            if (this.gameObject.name == "Bitis")
            {
                SceneManager.LoadScene("DGNC");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            oyuncu_icinde = false;
        }
    }
}
