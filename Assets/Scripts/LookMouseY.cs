using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMouseY : MonoBehaviour
{
    [SerializeField] private float sensibility = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float angleX = this.transform.localEulerAngles.x - mouseY * this.sensibility;
        float angleY = this.transform.localEulerAngles.y;
        float angleZ = this.transform.localEulerAngles.z;
        this.transform.localEulerAngles = new Vector3(angleX, angleY, angleZ);
    }
}
