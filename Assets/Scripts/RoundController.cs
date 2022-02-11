using System;
using System.Collections.Generic;
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
        public int currentRow;
        public int direction;

        public List<GridNode> currentNode = new List<GridNode>();

        public int playAmount;
        
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

            if (Input.anyKeyDown)
            {
                currentRow++;
            }
        }

        private void Step()
        {
            if (direction == 0)
                direction = 1;
            
            if (currentStep >= sizeX - 1)
            {
                direction = -1;
            }

            if (currentStep <= -playAmount + 1)
            {
                direction = 1;
            }
            
            currentStep += direction;


            for (int i = 0; i < currentNode.Count; i++)
            {
                currentNode[i].Activate(false);
            }
            
            currentNode.Clear();

            if (currentStep >= 0 && currentStep < sizeX)
            {
                grid[currentStep, currentRow].Activate(true);
                currentNode.Add(grid[currentStep, currentRow]);
            }

            

            int secondNodeStep = currentStep + 1;
            
            if (secondNodeStep >= 0 && secondNodeStep < sizeX )
            {
                grid[secondNodeStep,currentRow].Activate(true);
                currentNode.Add(grid[secondNodeStep, currentRow]);
            }
            
            int thirdNodeStep = currentStep + 2;

            if (thirdNodeStep >= 0 && thirdNodeStep < sizeX)
            {
                grid[thirdNodeStep,currentRow].Activate(true);
                currentNode.Add(grid[thirdNodeStep, currentRow]);
            }
        }

        public void SpawnGrid()
        {
            grid = new GridNode[sizeX,sizeY];

            currentRow = 0;
            
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