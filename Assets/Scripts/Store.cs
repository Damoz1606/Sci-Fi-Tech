using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && other.GetComponent<Player>() && Input.GetKeyDown(KeyCode.E))
        {
            if (other.GetComponent<Player>().hasCoin)
            {
                other.GetComponent<Player>().RemoveCoin();
                this.GetComponent<AudioSource>().Play();
                other.GetComponent<Player>().EnableWeapon();
            } else
            {
                Debug.Log("Get out of here");
            }
        }
    }
}
