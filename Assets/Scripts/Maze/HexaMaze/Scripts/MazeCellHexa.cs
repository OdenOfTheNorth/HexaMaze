using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexaMaze
{
    
    public class MazeCellHexa : MonoBehaviour
    {
        public Vector2 coord = Vector2.zero;

        MazeCellEdgeHexa[] edges = new MazeCellEdgeHexa[MazeDirections.countHexa];
        int initializedEdgeCount = 0;
        
        public bool IsFullyInitialized => initializedEdgeCount == MazeDirections.countHexa;

        public MazeDirectionHexa RandomUninitializedDirection
        {
            get
            {
                int skips = Random.Range(0, MazeDirections.countHexa - initializedEdgeCount);
                for (int i = 0; i < MazeDirections.countHexa; i++)
                {
                    if (edges[i] == null)
                    {
                        if (skips == 0)
                        {
                            return (MazeDirectionHexa)i;
                        }
                        skips--;
                    }
                }
                throw new System.InvalidOperationException("MazeCell has all directions initialized.");
            }
        }
        
        public MazeCellEdgeHexa GetEdge(MazeDirectionHexa direction)
        {
            return edges[(int)direction];
        }
        public void SetEdge(MazeCellEdgeHexa edge, MazeDirectionHexa direction)
        {
            edges[(int)direction] = edge;
            initializedEdgeCount++;
        }
    }

}