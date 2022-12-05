using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Vector3 ScreenToWorld(Camera camera, Vector3 position)
    {
        //Debug.Log(position+" "+ Input.mousePosition);
        
        //position.z = camera.fieldOfView;
        Ray ray = camera.ScreenPointToRay(position);
        //Debug.DrawLine(ray.origin, ray.direction * 100, Color.red);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        //Debug.Log(hit.point + " " + hit.collider.name);
        return hit.point;

    }
}
