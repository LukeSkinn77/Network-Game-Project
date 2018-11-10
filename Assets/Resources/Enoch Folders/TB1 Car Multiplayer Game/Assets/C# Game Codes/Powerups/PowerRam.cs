﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerRam : MonoBehaviour {

    public GameObject player;
    GameObject particleRamEffect;
    DamageMeterText playerDamage;
    float timer = 30;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("player"))
        {
            StartCoroutine(RamPickup(other));
        }
    }

    IEnumerator RamPickup(Collider Player)
    {
        // Instantiate some particle effects here...
        //Instantiate(particleRamEffect, transform.position, transform.rotation);
        playerDamage = player.GetComponent<DamageMeterText>();
        playerDamage.damageRate = 10;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(timer);
        playerDamage.damageRate = 1;
        Destroy(gameObject);
    }
}