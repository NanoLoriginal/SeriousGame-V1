using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private GridXZ<GridObject> grid;

    [SerializeField] LayerMask mouseLayer;
    [SerializeField] private Transform mouseVisualTransform;

    

    private void Start()
    {
        grid = new GridXZ<GridObject>(4, 2, 10f, new Vector3(0, 0), (GridXZ<GridObject> g, int x, int z) => new GridObject(g, x, z));
    }

    public class GridObject
    {
        private GridXZ<GridObject> grid;
        private int x;
        private int z;

        public GridObject(GridXZ<GridObject> grid, int x, int z)
        {
            this.grid = grid;
            this.x = x;
            this.z = z;
        }
    }

    private void Update()
    {

        Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, mouseLayer))
        {
            mouseVisualTransform.position = raycastHit.point;
        }


        if (Input.GetMouseButtonDown(0))
        {
            //grid.SetValue(mouseVisualTransform.position, true);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(mouseVisualTransform.position));
        }
    }
}
