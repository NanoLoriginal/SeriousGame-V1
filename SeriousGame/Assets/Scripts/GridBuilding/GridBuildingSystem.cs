using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuildingSystem : MonoBehaviour
{

    [SerializeField] LayerMask mouseLayer;
    [SerializeField] private Transform mouseVisualTransform;

    private GridXZ<GridObject> grid;

    private void Awake()
    {

        int gridWidth = 10;
        int gridHeight = 10;
        float cellSize = 10f;
        grid = new GridXZ<GridObject>(gridWidth, gridHeight, cellSize, Vector3.zero, (GridXZ<GridObject> g, int x, int z) => new GridObject(g, x, z));
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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
