using System;
using UnityEngine;

namespace Core
{
    public class RoundController : MonoBehaviour
    {
        [SerializeField] private GridNode cubePrefab;

        [SerializeField] private int sizeX = 8;
        [SerializeField] private int sizeY = 36;
        
        [SerializeField] private float speed = 0.1f;
        
        private GridNode[,] grid;

        private float stepTimer;
        public int currentStep;
        public bool isRight;

        public GridNode currentNode;
        
        public void Start()
        {
            SpawnGrid();
        }

        private void Update()
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer < 0)
            {
                Step();
                stepTimer = speed;
            }
        }

        private void Step()
        {
            if (currentStep >= sizeX - 1)
            {
                isRight = false;
            }

            if (currentStep <= 0)
            {
                isRight = true;
            }
            
            currentStep += isRight ? 1 : -1;
            
            if(currentNode)
                currentNode.Activate(false);
            
            grid[currentStep,0].Activate(true);
            currentNode = grid[currentStep, 0];
        }

        public void SpawnGrid()
        {
            grid = new GridNode[sizeX,sizeY];

            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    grid[x, y] = Instantiate(cubePrefab, new Vector3(x,y,0), Quaternion.identity).Init();
                }
            }
        }
    }
}