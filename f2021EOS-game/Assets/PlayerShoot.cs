using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Camera fpsCam;
    [SerializeField] private float damage;
    [SerializeField] private int ammo;
    [SerializeField] private int maxClipSize;

    [SerializeField] private TextMeshProUGUI ammoText;

    private int ammoLeft;

    private void Start()
    {
        ammoLeft = maxClipSize;
        UpdateAmmoText();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammoLeft > 0)
            {
                Shoot();
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void Shoot()
    {
        ammoLeft -= 1;
        UpdateAmmoText();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 200))
        {
            Health health = hit.transform.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    private void Reload()
    {
        int ammoToRemove = maxClipSize - ammoLeft;
        ammo -= ammoToRemove;
        ammoLeft = maxClipSize;
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {
        ammoText.text = GetAmmoText();
    }

    string GetAmmoText()
    {
        return "Ammo " + ammoLeft + "/" + ammo;
    }
}
