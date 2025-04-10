using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PickUpCore;

namespace MoverCore
{
    public class Mover : MonoBehaviour
    {
        private float walkSpeed = 1.5f;       // Yürüme hızı
        private float runSpeed = 5.6f;        // Koşma hızı
        [SerializeField] float acceleration;      // Hızlanma oranı
        [SerializeField] float deceleration;      // Yavaşlama oranı
        [SerializeField] float turnSpeed;       // Dönüş hızı

        private NavMeshAgent agent;
        private Animator animator;
        private AudioSource sounds;

        private float currentSpeed = 0f;     // Karakterin anlık hızı
        private float targetSpeed = 0f;      // Hedef hız (yavaşlama/hızlanma durumu)

        private float stepTimer = 0f;
        private float stepInterval = 0.5f;

        PickUp pickup;
         
        void Start()
        {
            //Playerın kayıtlı pozisyondan başlaması
            if (GameManager.Instance != null && GameManager.Instance.pozisyonKayitli)
            {
                transform.position = GameManager.Instance.karakterPozisyonu;
                GameManager.Instance.pozisyonKayitli = false;
            }
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            sounds = GetComponent<AudioSource>();
            pickup = GetComponent<PickUp>();
        }

        void Update()
        {
            if (!pickup.isPickingUp)
            {
                HandleMovement();
            }
            UpdateAnimator();
            HandleStepSound();
        }
        
        private void HandleMovement()
        {
            float moveZ = Input.GetAxisRaw("Vertical");
            moveZ = moveZ == -1 ? 0 : moveZ; // S tuşuna basıldığında engellenir

            bool isRunning = Input.GetKey(KeyCode.LeftShift); // Shift tuşuna basılı mı?

            // Hızlanma ve durma işlemleri
            if (moveZ != 0)
            {
                targetSpeed = isRunning ? runSpeed : walkSpeed;
            }
            else
            {
                // Hiçbir tuşa basılmadığında yavaşça durma
                targetSpeed = 0f;
            }

            // Hızlanma veya yavaşlama
            if (!isRunning)
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, deceleration * Time.deltaTime);  // Yavaşlama
            }
            else
            {
                currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime); // Hızlanma
            }

            // NavMeshAgent hızını ayarlama
            agent.speed = currentSpeed;

            // Yavaşça durma işlemi için velocity sıfırlanması
            agent.velocity = transform.forward * currentSpeed;

            // A/D ile karakterin yönünü değiştirme (yumuşak dönüş)
            float rotateY = Input.GetAxisRaw("Horizontal"); // A (-1) - D (1)
            if (rotateY != 0)
            {
                float targetAngle = rotateY * turnSpeed * Time.deltaTime; // Yumuşak dönüş
                transform.Rotate(Vector3.up * targetAngle);
            }
        }

        private void UpdateAnimator()
        {
            animator.SetFloat("forwardSpeed", Mathf.Abs(currentSpeed)); // Animator’a hız aktar

        }

        // 🔊 Bağımsız ses efekti yönetimi
        private void HandleStepSound()
        {
            if (pickup.isPickingUp)
            {
                return;
            }
            if (currentSpeed >= 0.1f)
            {
                // Yürüyüş temposu: hız arttıkça adımlar sıklaşsın
                float maxSpeed = runSpeed;
                float minStepInterval = 0.40f; // koşarken
                float maxStepInterval = 0.75f;  // yürürken

                // Speed'e göre adım aralığı ayarla (Lerp gibi çalışır)
                float speedPercent = currentSpeed / maxSpeed;
                stepInterval = Mathf.Lerp(maxStepInterval, minStepInterval, speedPercent);

                stepTimer += Time.deltaTime;

                if (stepTimer >= stepInterval)
                {
                    sounds.PlayOneShot(sounds.clip);
                    stepTimer = 0f;
                }
            }
            else
            {
                stepTimer = 0f; // durunca sıfırla
            }
        }

    }
}

