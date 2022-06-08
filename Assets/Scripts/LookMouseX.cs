using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouseX : MonoBehaviour
{
    [SerializeField] private float sensibility = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float angleX = this.transform.localEulerAngles.x;
        float angleY = this.transform.localEulerAngles.y + mouseX * this.sensibility;
        float angleZ = this.transform.localEulerAngles.z;
        this.transform.localEulerAngles = new Vector3(angleX, angleY, angleZ);
    }
}
