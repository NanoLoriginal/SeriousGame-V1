using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{

    [SerializeField] LayerMask pingLayer;

    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = CastRay();

            if(hit.collider != null)
            {
                if (!hit.collider.CompareTag("ping"))
                {
                    return;
                }

                PingButton c = hit.collider.gameObject.GetComponent<PingButton>();
                if(c.getDisplayed() == false)
                {
                    c.activateCanvas(true);
                    c.setDisplayed(true);
                }
                else
                {
                    c.activateCanvas(false);
                    c.setDisplayed(false);
                }

            }
        }
    }


    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, 100f, pingLayer);

        return hit;
    }
}
