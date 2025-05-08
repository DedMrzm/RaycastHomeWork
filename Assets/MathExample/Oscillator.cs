using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;
        float yPosition = _time;

        transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
    }
}
