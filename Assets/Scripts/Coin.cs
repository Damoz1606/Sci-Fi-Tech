using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip soundCoinCollected;

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("coin");
            other.GetComponent<Player>().CollectCoin();
            AudioSource.PlayClipAtPoint(this.soundCoinCollected, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
    }
}
