using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PuzzleGecis : MonoBehaviour
{
    private bool oyuncu_icinde = false;
    public GameObject puzzleEntryText;
    public GameObject exitcollider;
    public GameObject Door;

    private static bool hasInitialized = false;

    void Update()
    {
        if (oyuncu_icinde && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.karakterPozisyonu = GameObject.FindWithTag("Player").transform.position;
            GameManager.Instance.pozisyonKayitli = true;
            SceneManager.LoadScene("SlidePuzzle");

        }
    }

    private void Awake()
    {

        if (!hasInitialized)
        {
            PlayerPrefs.SetInt("SlidePuzzleFinish", 0);
            PlayerPrefs.Save();
            hasInitialized = true;
            // Bir defalýk setup kodlarý
        }

        int SlidePuzzleFinish = PlayerPrefs.GetInt("SlidePuzzleFinish", 0);
        if (SlidePuzzleFinish == 1)
        {
            exitcollider.SetActive(true);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            Transform DoorChild1 = Door.transform.GetChild(0);
            DoorChild1.transform.localRotation = Quaternion.Euler(0, 90, 0);

            Transform DoorChild2 = Door.transform.GetChild(1);
            DoorChild2.gameObject.SetActive(true);
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