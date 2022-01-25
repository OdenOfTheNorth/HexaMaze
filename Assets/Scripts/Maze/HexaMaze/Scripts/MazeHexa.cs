using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexaMaze
{
    
public class MazeHexa : MonoBehaviour
{
[SerializeField]
        float radius = 10f;

        // temporary hack
        [SerializeField]
        int count = 15;

        [SerializeField]
        MazeCellHexa cellPrefabHexa = null;

        List<MazeCellHexa> cells = new List<MazeCellHexa>();

        [SerializeField]
        protected float generationStepDelay = 0.01f;
        
        [SerializeField]
        MazePassageHexa passagePrefabHexa = null;

        [SerializeField]
        MazeWallHexa wallPrefabHexa = null;

        public Vector2 RandomCoordinateHexa => Vector2.zero; // Random.insideUnitCircle * radius;

        public void Generate() //IEnumerator
        {
            //WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
            cells.Clear();
            //Vector2 coord = RandomCoordinateHexa;

            List<MazeCellHexa> activeCells = new List<MazeCellHexa>();
            FirstGenerationStep(activeCells);

            while(activeCells.Count > 0)
            {
                NextGenerationStep(activeCells);
            }

            Debug.Log("done hexa");
        }

        void FirstGenerationStep(List<MazeCellHexa> activeCells)
        {
            activeCells.Add(CreateCell(RandomCoordinateHexa));
        }

        void NextGenerationStep(List<MazeCellHexa> activeCells)
        {
            //Debug.Log("active cells count: " + activeCells.Count);

            int currentIndex = activeCells.Count - 1;
            MazeCellHexa currentCell = activeCells[currentIndex];
            if (currentCell.IsFullyInitialized)
            {
                //Debug.Log("Fully initialized cell");
                activeCells.RemoveAt(currentIndex);
                return;
            }
            MazeDirectionHexa direction = currentCell.RandomUninitializedDirection;
            Vector2 coord = currentCell.coord + direction.ToVector2();


            if (ContainsHexa(coord) == true)
            {
                MazeCellHexa neighbor = GetCellHexa(coord);
                if (neighbor == null)
                {
                    neighbor = CreateCell(coord);
                    CreatePassage(currentCell, neighbor, direction);
                    activeCells.Add(neighbor);
                }
                else if (neighbor != null)
                {
                    CreateWall(currentCell, neighbor, direction);
                }
            }
            else if (ContainsHexa(coord) == false)
            {
                CreateWall(currentCell, null, direction);
            }
        }

        void CreateWall(MazeCellHexa currentCell, MazeCellHexa neighbor, MazeDirectionHexa direction)
        {
            MazeWallHexa wall = Instantiate(wallPrefabHexa) as MazeWallHexa;
            wall.Init(currentCell, neighbor, direction);

            if (neighbor != null)
            {
                wall = Instantiate(wallPrefabHexa) as MazeWallHexa;
                wall.Init(neighbor, currentCell, direction.GetOpposite());
            }
        }
        void CreatePassage(MazeCellHexa currentCell, MazeCellHexa neighbor, MazeDirectionHexa direction)
        {
            MazePassageHexa passage = Instantiate(passagePrefabHexa) as MazePassageHexa;
            passage.Init(currentCell, neighbor, direction);

            passage = Instantiate(passagePrefabHexa) as MazePassageHexa;
            passage.Init(neighbor, currentCell, direction.GetOpposite());
        }

        public bool ContainsHexa(Vector2 coord)
        {
            return Vector2.Dot(coord, coord) < radius*radius;
        }

        MazeCellHexa CreateCell(Vector2 coord)
        {
            MazeCellHexa newCell = Instantiate(cellPrefabHexa) as MazeCellHexa;
            newCell.name = "Maze Cell " + coord.x + ", " + coord.y;
            newCell.transform.parent = transform;

            newCell.transform.position = new Vector3(
                coord.x,
                0f,coord.y);

            newCell.coord = coord;

            cells.Add(newCell);

            return newCell;
        }
    
        public MazeCellHexa GetCellHexa(Vector2 coord)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].coord == coord)
                {
                    //Debug.Log("get cell");
                    return cells[i];
                }
            }

            return null;
        }
}

}