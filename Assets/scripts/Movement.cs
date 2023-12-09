using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxCameraDistanceX;
    [SerializeField] float maxCameraDistanceZ;
    [SerializeField] float minCameraDistanceZ;
    //[SerializeField] Transform gameCamera;

    private void Update()
    {

        if (Input.GetKey("a"))
        {
            MoveObject(transform, Vector3.left);
            //if(Mathf.Abs(transform.position.x - gameCamera.position.x) > maxCameraDistanceX)
            //{
            //    MoveObject(gameCamera, Vector3.left);
            //}
        }

        if (Input.GetKey("w"))
        {
            MoveObject(transform, Vector3.forward);
            //if (Mathf.Abs(transform.position.z - gameCamera.position.z) > maxCameraDistanceZ)
            //{
            //    MoveObject(gameCamera, Vector3.forward);
            //}
        }

        if (Input.GetKey("d"))
        {
            MoveObject(transform, Vector3.right);
            //if (Mathf.Abs(transform.position.x - gameCamera.position.x) > maxCameraDistanceX)
            //{
            //    MoveObject(gameCamera, Vector3.right);
            //}
        }

        if (Input.GetKey("s"))
        {
            MoveObject(transform, Vector3.back);
            //if (Mathf.Abs(transform.position.z - gameCamera.position.z) > minCameraDistanceZ)
            //{
            //    MoveObject(gameCamera, Vector3.back);
            //}
        }
        LookAtMouse();
    }

    void MoveObject(Transform transform, Vector3 direction)
    {
        transform.position = transform.position + direction * speed * Time.deltaTime;
    }
    void LookAtMouse()
    {
        Vector3 mouse = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            mouse.z = hit.distance;
        }
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouse);
        mouseWorld.y = transform.position.y;
        transform.LookAt(mouseWorld);
    }
}
