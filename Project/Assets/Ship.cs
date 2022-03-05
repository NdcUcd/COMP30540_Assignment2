using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    Vector3 original_position;

    void Start()
    {
        original_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(KeyCode key)
    {
        transform.position = new Vector3(original_position.x, 0, original_position.z);
    }
}
