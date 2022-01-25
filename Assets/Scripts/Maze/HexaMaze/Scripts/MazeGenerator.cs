using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexaMaze
{
    public class MazeGenerator : MonoBehaviour
    {
        [SerializeField]
        MazeHexa mazePrefab = null;
        MazeHexa mazeInstance = null;

        private void Start()
        {
            Begin();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) == true)
                Restart();
        }

        protected virtual void Restart()
        {
            StopAllCoroutines();

            Destroy(mazeInstance.gameObject);

            Begin();
        }

        protected virtual void Begin()
        {
            mazeInstance = Instantiate(mazePrefab) as MazeHexa;
            //StartCoroutine(mazeInstance.Generate());
            mazeInstance.Generate();
        }
    }
}
