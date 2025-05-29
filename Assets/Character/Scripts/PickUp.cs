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
            // F tuþuna basýldýðýnda ve pickup iþlemi yapýlabilir olduðunda iþlem yapýlacak
            if (Input.GetKeyDown(KeyCode.F) && !isPickingUp)
            {
                // Ýlgili nesnenin üzerinde ParcaController olup olmadýðýný kontrol et
                controller = GetPickupController();

                if (controller != null && controller.alýnabilir == true)
                {
                    StartCoroutine(DoPickUp());

                    // Nesnenin adýyla iþlem yapma
                    switch (controller.gameObject.name)
                    {
                        case "PuzzlePart1":
                            HandlePuzzlePart("PuzzlePart1", controller);
                            // Bayraðý true yap ve PlayerPrefs'e kaydet
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
                            Debug.LogWarning("Bilinmeyen parça!");
                            break;
                    }
                }
            }
        }

        // ParcaController'ý almak için bir fonksiyon
        private ParcaController GetPickupController()
        {
            // F tuþu ile pickup yapmaya çalýþtýðýnýzda, nesneye dokunulan collider'ý almak için raycast veya baþka bir yöntem kullanýlabilir.
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                ParcaController controller = hit.collider.GetComponent<ParcaController>();
                return controller;
            }
            return null;
        }

        // Puzzle parçalarýndaki collider'ý devre dýþý býrakmak için
        private void HandlePuzzlePart(string partName, ParcaController controller)
        {
            Debug.Log(partName + " alýndý!");
            // Nesnenin collider'ýný devre dýþý býrak
            Collider partCollider = controller.GetComponent<Collider>();
            if (partCollider != null)
            {
                // Collider'ý devre dýþý býrak
                partCollider.enabled = false;
                controller.ParcaText.SetActive(false);
                Debug.Log(partName + " collider'ý devre dýþý býrakýldý!");
            }
            else
            {
                Debug.LogWarning(partName + " collider'ý bulunamadý!");
            }
        }

        private IEnumerator DoPickUp()
        {
            isPickingUp = true;
            agent.isStopped = true;
            agent.velocity = Vector3.zero; // Aniden durmasý için

            animator.SetFloat("forwardSpeed", 0f);
            animator.SetTrigger("pickUpTrigger");

            yield return new WaitForSeconds(2.5f); // PickUp animasyon süresi kadar

            agent.isStopped = false;
            isPickingUp = false;
        }

        
    }
}

