using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] private float fireRate;
    [SerializeField] private Transform firePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
    {
        
    }

    private TakeDamage HitScan<T>()
    {
        if (Physics.Raycast(firePoint.position, firePoint.forward))
        {
            
        }

        return null;
    }

    IEnumerator FireRoutine()
    {
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(1 / fireRate);
        }
    }
}
