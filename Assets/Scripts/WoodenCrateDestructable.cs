using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenCrateDestructable : MonoBehaviour
{
    [SerializeField] private GameObject crateDestroyed;
    public void UpdateCrate() {
        Instantiate(this.crateDestroyed, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

}
