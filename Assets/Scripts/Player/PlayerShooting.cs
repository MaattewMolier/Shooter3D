using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerShooting : MonoBehaviour
{
    // General optons
    [Header("General")] 
    [SerializeField] private Rig rightHandRig;
    [SerializeField] private Transform gunShootPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int damage;
    // Aim options
    [Header("Aim")]
    [SerializeField] private Camera MainCamera;
    [SerializeField] private Vector3 aimingCameraPosition;
    [SerializeField] private float aimSpeed;
    // Audio options
    [Header("Audio")]
    [SerializeField] private AudioSource gunAudioSource;
    // Settings
    [Header("Settings")]
    [Range(0,10)]
    [SerializeField] private float rigChangeSpeed = 2f;
    [Range(0,1)]
    [SerializeField] private float maxRigWeight = 1f;
    [Range(0, 1)]
    [SerializeField] private float minRigWeight = 0f;
    [SerializeField] private float shootDelay = 0.2f;
    // Delay and Raycast setting
    private float currentShootDelay;
    [SerializeField] private LayerMask raycastMask;

    private Vector3 StartingPosition;

    private void Start()
    {
        StartingPosition = MainCamera.transform.localPosition;
        currentShootDelay = 0f;
    }

    private void Update()
    {
        // Smooth rig weight
        rightHandRig.weight = Mathf.Lerp( 
            rightHandRig.weight, 
            Input.GetMouseButton(0) ? maxRigWeight : minRigWeight, 
            Time.deltaTime * rigChangeSpeed 
        );
        currentShootDelay += Time.deltaTime;
        if (Input.GetMouseButton(0) && currentShootDelay >= shootDelay)
        {
             Shoot();
             currentShootDelay = 0f;
        }

        if (Input.GetMouseButtonDown(1))
        {
            MainCamera.transform.localPosition = Vector3.MoveTowards(MainCamera.transform.localPosition, aimingCameraPosition, Time.deltaTime * aimSpeed);
            float y = transform.forward.y;
            transform.forward = Vector3.Lerp(transform.forward, MainCamera.transform.forward, Time.deltaTime * aimSpeed);
            transform.forward = new Vector3(transform.forward.x, y, transform.forward.z);

            gunShootPoint.forward = MainCamera.transform.forward;
        }
        else
        {
            MainCamera.transform.localPosition = Vector3.MoveTowards(MainCamera.transform.localPosition, StartingPosition, Time.deltaTime * aimSpeed);

        }
    }
    private void Shoot()
    {
        // 1. Ray from camera
        Camera cam = Camera.main;
        if (!cam) return;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out RaycastHit hit, 200f, raycastMask))
            targetPoint = hit.point;
        else
            targetPoint = ray.origin + ray.direction * 200f;

        // 2. Shoot direction
        Vector3 direction = (targetPoint - gunShootPoint.position).normalized;

        // 3. Play sound
        gunAudioSource.Play();

        // 4. Instantiate bullet
        GameObject bulletGO = Instantiate(
            bulletPrefab,
            gunShootPoint.position,
            Quaternion.LookRotation(direction)
        );

        // 5. Set velocity & damage
        Bullet bulletComponent = bulletGO.GetComponent<Bullet>();
        if (bulletComponent != null)
        {
            bulletComponent.Shoot(direction);
            bulletComponent.SetDamage(damage);
        }

        // 6. Ignore collision with player
        Collider playerC = GetComponentInParent<Collider>();
        Collider bulletC = bulletGO.GetComponent<Collider>();

        if (playerC && bulletC)
            Physics.IgnoreCollision(bulletC, playerC);
    }
}

