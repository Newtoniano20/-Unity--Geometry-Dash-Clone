using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private void Await()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
