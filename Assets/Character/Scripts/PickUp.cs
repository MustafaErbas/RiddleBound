using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoverCore;
using UnityEngine.AI;

namespace PickUpCore
{
    public class PickUp : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Animator animator;

        ParcaController controller;
        Parca1 parca1;
        // Start is called before the first frame update
        void Start()
        {

            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            controller = FindObjectOfType<ParcaController>();
            parca1 = FindObjectOfType<Parca1>();
        }

        // Update is called once per frame
        void Update()
        {
            HandlePickUp();
        }

        public bool isPickingUp = false;

        private void HandlePickUp()
        {
            // F tu�una bas�ld���nda ve pickup i�lemi yap�labilir oldu�unda i�lem yap�lacak
            if (Input.GetKeyDown(KeyCode.F) && !isPickingUp)
            {
                // �lgili nesnenin �zerinde ParcaController olup olmad���n� kontrol et
                controller = GetPickupController();

                if (controller != null && controller.al�nabilir == true)
                {
                    StartCoroutine(DoPickUp());

                    // Nesnenin ad�yla i�lem yapma
                    switch (controller.gameObject.name)
                    {
                        case "PuzzlePart1":
                            HandlePuzzlePart("PuzzlePart1", controller);
                            // Bayra�� true yap ve PlayerPrefs'e kaydet
                            PlayerPrefs.SetInt("PuzzlePart1Flag", 1);
                            PlayerPrefs.Save();
                            break;
                        case "PuzzlePart2":
                            HandlePuzzlePart("PuzzlePart2", controller);
                            PlayerPrefs.SetInt("PuzzlePart2Flag", 1);
                            PlayerPrefs.Save();
                            break;
                        case "PuzzlePart3":
                            HandlePuzzlePart("PuzzlePart3", controller);
                            PlayerPrefs.SetInt("PuzzlePart3Flag", 1);
                            PlayerPrefs.Save();
                            break;
                        case "PuzzlePart4":
                            HandlePuzzlePart("PuzzlePart4", controller);
                            PlayerPrefs.SetInt("PuzzlePart4Flag", 1);
                            PlayerPrefs.Save();
                            break;
                        case "PuzzlePart5":
                            HandlePuzzlePart("PuzzlePart5", controller);
                            PlayerPrefs.SetInt("PuzzlePart5Flag", 1);
                            PlayerPrefs.Save();
                            break;
                        case "PuzzlePart6":
                            HandlePuzzlePart("PuzzlePart6", controller);
                            PlayerPrefs.SetInt("PuzzlePart6Flag", 1);
                            PlayerPrefs.Save();
                            break;
                        default:
                            Debug.LogWarning("Bilinmeyen par�a!");
                            break;
                    }
                }
            }
        }

        // ParcaController'� almak i�in bir fonksiyon
        private ParcaController GetPickupController()
        {
            // F tu�u ile pickup yapmaya �al��t���n�zda, nesneye dokunulan collider'� almak i�in raycast veya ba�ka bir y�ntem kullan�labilir.
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                ParcaController controller = hit.collider.GetComponent<ParcaController>();
                return controller;
            }
            return null;
        }

        // Puzzle par�alar�ndaki collider'� devre d��� b�rakmak i�in
        private void HandlePuzzlePart(string partName, ParcaController controller)
        {
            Debug.Log(partName + " al�nd�!");
            // Nesnenin collider'�n� devre d��� b�rak
            Collider partCollider = controller.GetComponent<Collider>();
            if (partCollider != null)
            {
                // Collider'� devre d��� b�rak
                partCollider.enabled = false;
                controller.ParcaText.SetActive(false);
                Debug.Log(partName + " collider'� devre d��� b�rak�ld�!");
            }
            else
            {
                Debug.LogWarning(partName + " collider'� bulunamad�!");
            }
        }

        private IEnumerator DoPickUp()
        {
            isPickingUp = true;
            agent.isStopped = true;
            agent.velocity = Vector3.zero; // Aniden durmas� i�in

            animator.SetFloat("forwardSpeed", 0f);
            animator.SetTrigger("pickUpTrigger");

            yield return new WaitForSeconds(2.5f); // PickUp animasyon s�resi kadar

            agent.isStopped = false;
            isPickingUp = false;
        }

        
    }
}

