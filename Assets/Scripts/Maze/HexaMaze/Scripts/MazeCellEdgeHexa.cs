using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexaMaze
{
    public class MazeCellEdgeHexa : MonoBehaviour
    {
        public MazeCellHexa cell = null;
        public MazeCellHexa other = null;
        public MazeDirectionHexa direction;

        public void Init(MazeCellHexa cell, MazeCellHexa other, MazeDirectionHexa direction)
        {
            this.cell = cell;
            this.other = other;
            this.direction = direction;

            cell.SetEdge(this, direction);

            transform.parent = cell.transform;
            transform.localPosition = Vector3.zero;

            transform.localRotation = direction.ToRotation();
        }
    }
}


