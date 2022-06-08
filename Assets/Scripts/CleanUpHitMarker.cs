using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpHitMarker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.DestoyHitMarket();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestoyHitMarket()
    {
        Destroy(this.gameObject, 1f);
    }
}
