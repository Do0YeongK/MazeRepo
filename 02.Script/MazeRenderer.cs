using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField, Range(1, 50)]
    private int width = 10;

    [SerializeField, Range(1, 50)]
    private int height = 10;

    [SerializeField]
    private float size = 3f;    //벽크기

    [SerializeField]
    private int gap = 3; //만들어질 미로의 너비(=벽크기랑 같아야함)

    [SerializeField]
    private Transform wallPrefab = null;    //prefab된 벽 넣기

    [SerializeField]
    private GameObject mazePos; //maze생성될 위치

    // Start is called before the first frame update
    void Start()
    {
        var maze = MazeGenerator.Generate(width, height);   //MazeGenerator에 있는 Generate함수 사용
        Draw(maze); //maze 나타내기(없으면 안보임)
    }

    private void Draw(WallState[,] maze)    //WallState : MazeGenerator에 있는 enum 함수
    {
        for (int i = 0; i < width; ++i) //width : maze의 가로 개수
        {
            for (int j = 0; j < height; ++j)    //height : maze의 세로 개수
            {
                var cell = maze[i, j];  //width,height index를 갖는 cell 만들어짐
                var position = mazePos.transform.position + new Vector3(-width / 2 + i * gap , 0, -height / 2 + j * gap);  //벽 크기가 커지면 벽사이의 간격도 바꿔야함
                
                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, size / 2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size / 2, 0, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }

                if (i == width - 1)
                {
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(+size / 2, 0, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                    }
                }
                if (j == 0)
                {
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        bottomWall.position = position + new Vector3(0, 0, -size / 2);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }
        }
    }
}
