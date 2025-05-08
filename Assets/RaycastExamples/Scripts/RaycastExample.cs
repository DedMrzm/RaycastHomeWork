using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Vector3.zero, Vector3.forward);

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(cameraRay, out RaycastHit hitInfo))
        {
            Debug.Log(hitInfo.collider.gameObject.name);
        }

        Physics.RaycastAll(ray);

        Collider[] colliders = Physics.OverlapSphere(Vector3.zero, 10);
    }

    private void OnDrawGizmos()
    {
        if(Application.isPlaying)
        {
            Gizmos.color = Color.red;

            //Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Gizmos.DrawRay(cameraRay.origin, cameraRay.direction * 100);

            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Gizmos.DrawSphere(mouseWorldPosition, 1);
            Gizmos.DrawRay(mouseWorldPosition, Camera.main.transform.forward * 100);
        }
    }
}
