using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexaMaze
{
    public enum MazeDirection
    {
        North,
        East,
        South,
        West
    }

    public enum MazeDirectionHexa
    {
        NorthEast,
        East,
        SouthEast,

        SouthWest,
        West,
        NorthWest
    }

    public static class MazeDirections
    {
        private static MazeDirection[] opposites =
            {
        MazeDirection.South,
        MazeDirection.West,
        MazeDirection.North,
        MazeDirection.East
        };

        public static MazeDirectionHexa[] oppositesHexa =
        {
            MazeDirectionHexa.SouthWest,
            MazeDirectionHexa.West,
            MazeDirectionHexa.NorthWest,

            MazeDirectionHexa.NorthEast,
            MazeDirectionHexa.East,
            MazeDirectionHexa.SouthEast
        };

        public const int count = 4;
        public const int countHexa = 6;

        public static MazeDirection RandomValue => (MazeDirection)Random.Range(0, count);
        public static MazeDirectionHexa RandomValueHeza => (MazeDirectionHexa)Random.Range(0, countHexa);

        static Vector2Int[] vectors = new Vector2Int[]
        {
            new Vector2Int(0, 1),
            new Vector2Int(1, 0),
            new Vector2Int(0, -1),
            new Vector2Int(-1, 0)
        };

        static Vector2[] vectorsHexa = new Vector2[]
        {
            new Vector2(Mathf.Cos(60f*Mathf.Deg2Rad), Mathf.Sin(60f*Mathf.Deg2Rad)), // northEast
            new Vector2(1f, 0f), // east
            new Vector2(Mathf.Cos(60f*Mathf.Deg2Rad), -Mathf.Sin(60f*Mathf.Deg2Rad)), // southEast

            new Vector2(-Mathf.Cos(60f*Mathf.Deg2Rad), -Mathf.Sin(60f*Mathf.Deg2Rad)), // southWest
            new Vector2(-1f, 0f), // west
            new Vector2(-Mathf.Cos(60f*Mathf.Deg2Rad), Mathf.Sin(60f*Mathf.Deg2Rad)) // northWest
        };

        private static Quaternion[] rotations = {
        Quaternion.identity,
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(0f, 0f, -180f),
        Quaternion.Euler(0f, 0f, -270f)
    };

        static Quaternion[] rotationsHexa =
        {
            Quaternion.Euler(0f, 0f, -30f),
            Quaternion.Euler(0f, 0f, -90f),
            Quaternion.Euler(0f, 0f, -150f),

            Quaternion.Euler(0f, 0f, -210f),
            Quaternion.Euler(0f, 0f, -270f),
            Quaternion.Euler(0f, 0f, -330f)
        };

        public static Vector2Int ToVector2Int(this MazeDirection t)
        {
            return vectors[(int)t];
        }
        public static Vector2 ToVector2(this MazeDirectionHexa t)
        {
            return vectorsHexa[(int)t];
        }

        public static MazeDirection GetOpposite(this MazeDirection t)
        {
            return opposites[(int)t];
        }
        public static MazeDirectionHexa GetOpposite(this MazeDirectionHexa t)
        {
            return oppositesHexa[(int)t];
        }

        public static Quaternion ToRotation(this MazeDirection t)
        {
            return rotations[(int)t];
        }
        public static Quaternion ToRotation(this MazeDirectionHexa t)
        {
            return rotationsHexa[(int)t];
        }
    }

}

    