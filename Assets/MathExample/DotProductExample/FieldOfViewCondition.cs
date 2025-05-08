using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewCondition : MonoBehaviour
{
    private Transform _sourceObject;

    private float _fieldOfViewwDegree;

    public FieldOfViewCondition(Transform sourceObject, float fieldOfViewwDegree)
    {
        _sourceObject = sourceObject;
        _fieldOfViewwDegree = fieldOfViewwDegree;
    }

    public bool IsCompleteFor(Transform target)
    {
        Vector3 directionToTarget = target.position - _sourceObject.position;

        float dotProduct = Vector3.Dot(_sourceObject.forward, directionToTarget);

        float cos = dotProduct / (directionToTarget.magnitude * _sourceObject.forward.magnitude);

        float angleToTarget = Mathf.Acos(cos) * Mathf.Rad2Deg;

        if (angleToTarget > _fieldOfViewwDegree)
            return false;

        return true;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
