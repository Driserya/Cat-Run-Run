using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gronds : MonoBehaviour
{
    public GameObject Cat;

    private void Update()
    {
        transform.position = new Vector3(Cat.transform.position.x, transform.position.y);//相机限制上下位置；
    }
}
