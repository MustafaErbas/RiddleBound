using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Puzzle : MonoBehaviour
{
    Camera Cam;
    Vector2 StartPosition;

    GameObject[] kutu_dizisi;
    PuzzleController controller;

    private void OnMouseDrag()
    {
        Vector3 pozisyon = Cam.ScreenToWorldPoint(Input.mousePosition);
        pozisyon.z = 0;
        transform.position = pozisyon;
    }


    void Start()
    {
        Cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        StartPosition = transform.position;

        kutu_dizisi = GameObject.FindGameObjectsWithTag("kutu");
        controller = FindObjectOfType<PuzzleController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            foreach (GameObject kutu in kutu_dizisi)
            {
                if(kutu.name == gameObject.name)
                {
                    float mesafe = Vector3.Distance(kutu.transform.position, transform.position);

                    if (mesafe <= 1)
                    {
                        transform.position = kutu.transform.position;
                        controller.sayi_arttir();
                        this.enabled = false;
                    }
                    else 
                    { 
                        transform.position = StartPosition;
                    }
                }
            }
        }
    }
}
