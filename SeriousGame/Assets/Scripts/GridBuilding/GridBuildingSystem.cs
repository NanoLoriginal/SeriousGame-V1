using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuildingSystem : MonoBehaviour
{

    [SerializeField] LayerMask mouseLayer;
    [SerializeField] private Transform mouseVisualTransform;

    [SerializeField] private Transform testTransform;

    private GridXZ<GridObject> grid;

    private void Awake()
    {

        int gridWidth = 10;
        int gridHeight = 10;
        float cellSize = 10f;
        grid = new GridXZ<GridObject>(gridWidth, gridHeight, cellSize, new Vector3(-20,0,-20), (GridXZ<GridObject> g, int x, int z) => new GridObject(g, x, z));
    }

    public class GridObject
    {
        private GridXZ<GridObject> grid;
        private int x;
        private int z;
        private Transform transform;

        public GridObject(GridXZ<GridObject> grid, int x, int z)
        {
            this.grid = grid;
            this.x = x;
            this.z = z;
        }

        public void SetTransform(Transform transform)
        {
            this.transform = transform;
            grid.TriggerGridObjectChanged(x, z);
        }

        public void ClearTransform()
        {
            transform = null;
            grid.TriggerGridObjectChanged(x, z);
        }

        public bool CanBuild()
        {
            return transform == null;
        }

        public override string ToString()
        {
            return x + "," + z;
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
            grid.GetXZ(mouseVisualTransform.position, out int x, out int z);

            GridObject gridObject = grid.GetGridObject(x, z);
            if(gridObject.CanBuild()) {
                Transform builtTransform = Instantiate(testTransform, grid.GetWorldPosition(x, z), Quaternion.identity);
                gridObject.SetTransform(builtTransform);
            }
            else
            {
                gridUtils.CreateWorldTextPopup("Cannot build here !", grid.GetWorldPosition(x - 1 , z + 1));
            }
            
            Instantiate(testTransform, grid.GetWorldPosition(x, z), Quaternion.identity);   
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetGridObject(mouseVisualTransform.position));
        }
    }

}
