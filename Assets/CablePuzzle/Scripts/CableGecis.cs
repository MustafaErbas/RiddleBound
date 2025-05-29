using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CableGecis : MonoBehaviour
{
    private bool oyuncu_icinde = false;
    public GameObject puzzleEntryText;
    public GameObject Box;
    public GameObject Map;

    private static bool hasInitialized = false;

    void Update()
    {
        if (oyuncu_icinde && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.karakterPozisyonu = GameObject.FindWithTag("Player").transform.position;
            GameManager.Instance.pozisyonKayitli = true;
            SceneManager.LoadScene("CablePuzzle");
        }

        
    }

    private void Awake()
    {
        if (!hasInitialized)
        {
            PlayerPrefs.SetInt("CableFinish", 0);
            PlayerPrefs.Save();
            this.gameObject.SetActive(true);
            hasInitialized = true;
            // Bir defalýk setup kodlarý
        }

        int CableFinish = PlayerPrefs.GetInt("CableFinish", 0);
        if (CableFinish == 1)
        {
            Map.SetActive(true);
            Transform BoxChild = Box.transform.GetChild(0);
            BoxChild.rotation = Quaternion.Euler(-45, 0, 0);
            this.gameObject.SetActive(false);
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
                SceneManager.LoadScene("DGNC");
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