using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject FinishObstacle;

    public Vector3 karakterPozisyonu;
    public bool pozisyonKayitli = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // sahne geçiþinde yok olmasýn
        }
        else
        {
            Destroy(gameObject);
        }
        int finish = PlayerPrefs.GetInt("finishLine", 0);
        if (finish == 1)
        {
            FinishObstacle.SetActive(false);
        }
    }
    private void Start()
    {

        

    }
    private void Update()
    {
        

    }
}
