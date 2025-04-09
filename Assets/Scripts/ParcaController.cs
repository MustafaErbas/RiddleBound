using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PickUpCore
{
    public class ParcaController : MonoBehaviour
    {
        public bool alýnabilir = false;
        public GameObject ParcaText;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                alýnabilir = true;
                ParcaText.SetActive(true);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                alýnabilir = false;
                ParcaText.SetActive(false);
            }
        }
    }
}

