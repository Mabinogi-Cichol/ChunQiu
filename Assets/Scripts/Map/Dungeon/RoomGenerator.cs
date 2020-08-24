using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RoomGenerator : MonoBehaviour
{
    public enum Direction { up,down,left,right};
    public Direction direction;

    [Header("房间信息")]
    public GameObject roomPrefab;
    public int roomNumber;
    public Color startColor, endColor,bossColor;
    private GameObject endRoom;
    private GameObject bossRoom;
    private int bossRoomRandom;
    private GameObject endWall;

    [Header("位置控制")]
    public Transform generatorPoint;
    public float xOffset;
    public float yOffset;
    public LayerMask roomLayer;
    public int maxStep;

    public List<Room> rooms = new List<Room>();
    public List<GameObject> walls = new List<GameObject>();

    List<GameObject> farRooms = new List<GameObject>();
    List<GameObject> lessRooms = new List<GameObject>();
    List<GameObject> oneWayRooms = new List<GameObject>();

    public WallType walltype;

    static private bool Refish = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < roomNumber; i++)
        {
            rooms.Add(Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity).GetComponent<Room>());

            //改变Point位置
            ChangePointPos();
        }

        rooms[0].GetComponent<SpriteRenderer>().color = startColor;

        endRoom = rooms[0].gameObject;

        //找到最后房间
        foreach (var room in rooms)
        {
            //if (room.transform.position.sqrMagnitude > endRoom.transform.position.sqrMagnitude)
            //{
            //    endRoom = room.gameObject;
            //}

            SetupRoom(room, room.transform.position);
        }

        FindEndRoom();
        endRoom.GetComponent<SpriteRenderer>().color = endColor;

        //添加Boss房
        AddBossRoom();
        bossRoom.GetComponent<SpriteRenderer>().color = bossColor;

        //更新endRoom的房门
        SetupRoom(endRoom.GetComponent<Room>(), endRoom.transform.position);
        //添加Boss房门
        SetupBossRoom();



        //foreach (var room in rooms)
        //{
        //    //if (room.transform.position.sqrMagnitude > endRoom.transform.position.sqrMagnitude)
        //    //{
        //    //    endRoom = room.gameObject;
        //    //}

        //    SetupWall(room, room.transform.position);
        //}

        //SetupWall(endRoom.GetComponent<Room>(), endRoom.transform.position);
        /*
        Debug.Log(endRoom.transform.position);
        Debug.Log(endRoom.GetComponent<Room>().roomLeft);
        Debug.Log(endRoom.GetComponent<Room>().doorNumber);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Refish ==false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Refish = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //刷新场景
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    public void ChangePointPos()
    {
        do
        {
            direction = (Direction)Random.Range(0, 4);

            switch (direction)
            {
                case Direction.up:
                    generatorPoint.position += new Vector3(0, yOffset, 0);
                    break;
                case Direction.down:
                    generatorPoint.position += new Vector3(0, -yOffset, 0);
                    break;
                case Direction.left:
                    generatorPoint.position += new Vector3(-xOffset, 0, 0);
                    break;
                case Direction.right:
                    generatorPoint.position += new Vector3(xOffset, 0, 0);
                    break;
                default:
                    break;
            }
        } while (Physics2D.OverlapCircle(generatorPoint.position, 0.2f, roomLayer));
    }
    
    public void SetupRoom(Room newRoom,Vector3 roomPosition)
    {
        newRoom.roomUp = Physics2D.OverlapCircle(roomPosition + new Vector3(0, yOffset, 0), 0.2f, roomLayer);
        newRoom.roomDown = Physics2D.OverlapCircle(roomPosition + new Vector3(0, -yOffset, 0), 0.2f, roomLayer);
        newRoom.roomLeft = Physics2D.OverlapCircle(roomPosition + new Vector3(-xOffset, 0, 0), 0.2f, roomLayer);
        newRoom.roomRight = Physics2D.OverlapCircle(roomPosition + new Vector3(xOffset, 0, 0), 0.2f, roomLayer);


        Debug.Log(newRoom.roomUp);
        Debug.Log(newRoom.roomDown);
        Debug.Log(newRoom.roomLeft);
        Debug.Log(newRoom.roomRight);

        newRoom.UpdateRoom(xOffset,yOffset);

        switch (newRoom.doorNumber)
        {
            case 1:
                if (newRoom.roomUp)
                    walls.Add(Instantiate(walltype.singleUp, roomPosition, Quaternion.identity));
                if (newRoom.roomDown)
                    walls.Add(Instantiate(walltype.singleDown, roomPosition, Quaternion.identity));
                if (newRoom.roomLeft)
                    walls.Add(Instantiate(walltype.singleLeft, roomPosition, Quaternion.identity));
                if (newRoom.roomRight)
                    walls.Add(Instantiate(walltype.singleRight, roomPosition, Quaternion.identity));
                break;

            case 2:
                if (newRoom.roomLeft && newRoom.roomUp)
                    walls.Add(Instantiate(walltype.doubleLU, roomPosition, Quaternion.identity));
                if (newRoom.roomLeft && newRoom.roomRight)
                    walls.Add(Instantiate(walltype.doubleLR, roomPosition, Quaternion.identity));
                if (newRoom.roomLeft && newRoom.roomDown)
                    walls.Add(Instantiate(walltype.doubleLD, roomPosition, Quaternion.identity));

                if (newRoom.roomUp && newRoom.roomRight)
                    walls.Add(Instantiate(walltype.doubleUR, roomPosition, Quaternion.identity));
                if (newRoom.roomUp && newRoom.roomDown)
                    walls.Add(Instantiate(walltype.doubleUD, roomPosition, Quaternion.identity));
                if (newRoom.roomRight && newRoom.roomDown)
                    walls.Add(Instantiate(walltype.doubleRD, roomPosition, Quaternion.identity));
                break;

            case 3:
                if (newRoom.roomLeft && newRoom.roomUp && newRoom.roomRight)
                    walls.Add(Instantiate(walltype.tripleLUR, roomPosition, Quaternion.identity));
                if (newRoom.roomLeft && newRoom.roomUp && newRoom.roomDown)
                    walls.Add(Instantiate(walltype.tripleLUD, roomPosition, Quaternion.identity));
                if (newRoom.roomLeft && newRoom.roomRight && newRoom.roomDown)
                    walls.Add(Instantiate(walltype.tripleLRD, roomPosition, Quaternion.identity));
                if (newRoom.roomRight && newRoom.roomUp && newRoom.roomDown)
                    walls.Add(Instantiate(walltype.tripleURD, roomPosition, Quaternion.identity));
                break;

            case 4:
                if (newRoom.roomLeft && newRoom.roomUp && newRoom.roomRight && newRoom.roomDown)
                    walls.Add(Instantiate(walltype.fourDoors, roomPosition, Quaternion.identity));
                break;
        }

    }

    public void SetupWall(Room newRoom, Vector3 roomPosition)
    {
        switch (newRoom.doorNumber)
        {
            case 1:
                if (newRoom.roomUp)
                    endWall = Instantiate(walltype.singleUp, roomPosition, Quaternion.identity);
                if (newRoom.roomDown)
                    endWall = Instantiate(walltype.singleDown, roomPosition, Quaternion.identity);
                if (newRoom.roomLeft)
                    endWall = Instantiate(walltype.singleLeft, roomPosition, Quaternion.identity);
                if (newRoom.roomRight)
                    endWall = Instantiate(walltype.singleRight, roomPosition, Quaternion.identity);
                break;

            case 2:
                if (newRoom.roomLeft && newRoom.roomUp)
                    endWall = Instantiate(walltype.doubleLU, roomPosition, Quaternion.identity);
                if (newRoom.roomLeft && newRoom.roomRight)
                    endWall = Instantiate(walltype.doubleLR, roomPosition, Quaternion.identity);
                if (newRoom.roomLeft && newRoom.roomDown)
                    endWall = Instantiate(walltype.doubleLD, roomPosition, Quaternion.identity);

                if (newRoom.roomUp && newRoom.roomRight)
                    endWall = Instantiate(walltype.doubleUR, roomPosition, Quaternion.identity);
                if (newRoom.roomUp && newRoom.roomDown)
                    endWall = Instantiate(walltype.doubleUD, roomPosition, Quaternion.identity);
                if (newRoom.roomRight && newRoom.roomDown)
                    endWall = Instantiate(walltype.doubleRD, roomPosition, Quaternion.identity);
                break;

            case 3:
                if (newRoom.roomLeft && newRoom.roomUp && newRoom.roomRight)
                    endWall = Instantiate(walltype.tripleLUR, roomPosition, Quaternion.identity);
                if (newRoom.roomLeft && newRoom.roomUp && newRoom.roomDown)
                    endWall = Instantiate(walltype.tripleLUD, roomPosition, Quaternion.identity);
                if (newRoom.roomLeft && newRoom.roomRight && newRoom.roomDown)
                    endWall = Instantiate(walltype.tripleLRD, roomPosition, Quaternion.identity);
                if (newRoom.roomRight && newRoom.roomUp && newRoom.roomDown)
                    endWall = Instantiate(walltype.tripleURD, roomPosition, Quaternion.identity);
                break;

            case 4:
                if (newRoom.roomLeft && newRoom.roomUp && newRoom.roomRight && newRoom.roomDown)
                    endWall = Instantiate(walltype.fourDoors, roomPosition, Quaternion.identity);
                
                break;
        }

    }

    public void SetupBossRoom() 
    {
        if (endRoom.transform.position.x < bossRoom.transform.position.x)
        {
            bossRoom.GetComponent<Room>().roomLeft = true;
            walls.Add(Instantiate(walltype.BossLeft, bossRoom.transform.position, Quaternion.identity));
        }
        if (endRoom.transform.position.x > bossRoom.transform.position.x)
        {
            bossRoom.GetComponent<Room>().roomRight = true;
            walls.Add(Instantiate(walltype.BossRight, bossRoom.transform.position, Quaternion.identity));
        }
    }

    public void FindEndRoom()
    {
        //获得房间距离最大数值
        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].stepToStart > maxStep)
            {
                maxStep = rooms[i].stepToStart;
            }
        }


        //获得最大值房间和次大值
        foreach (var room in rooms)
        {
            if (room.stepToStart == maxStep)
            {
                farRooms.Add(room.gameObject);
            }
            if (room.stepToStart == maxStep - 1)
            {
                lessRooms.Add(room.gameObject);
            }
        }

        //判断最大值房间和次大值房间哪个只有一个门
        for (int i = 0; i < farRooms.Count; i++)
        {
            if (farRooms[i].GetComponent<Room>().doorNumber == 1)
            {
                oneWayRooms.Add(farRooms[i]);
            }
        }

        for (int i = 0; i < lessRooms.Count; i++)
        {
            if (lessRooms[i].GetComponent<Room>().doorNumber == 1)
            {
                oneWayRooms.Add(lessRooms[i]);
            }
        }


        int endRandom;
        //如果两者都有复数的门，则在最远房间随机
        if (oneWayRooms.Count != 0)
        {
            endRandom = Random.Range(0, oneWayRooms.Count);
            endRoom = oneWayRooms[endRandom];
        }
        else
        {
            endRandom = Random.Range(0, farRooms.Count);
            endRoom = farRooms[endRandom];
        }

        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].transform.position == endRoom.transform.position)
            {
                endWall = walls[i];
                Destroy(endWall);


                //SetupWall(endRoom.GetComponent<Room>(), endRoom.transform.position);
            }
        }
    }

    public void AddBossRoom()
    {
        //添加Boss房
        generatorPoint.position = endRoom.transform.position;
        
        if (endRoom.GetComponent<Room>().roomLeft == false && endRoom.GetComponent<Room>().roomRight)
        {
            generatorPoint.position += new Vector3(-xOffset, 0, 0);
            //endRoom.GetComponent<Room>().roomLeft = true;
        }
        if (endRoom.GetComponent<Room>().roomLeft && endRoom.GetComponent<Room>().roomRight == false)
        {
            generatorPoint.position += new Vector3(xOffset, 0, 0);
        }
        if (endRoom.GetComponent<Room>().roomLeft == false && endRoom.GetComponent<Room>().roomRight == false)
        {
            bossRoomRandom = Random.Range(1, 2);

            switch (bossRoomRandom)
            {
                case 1:
                    generatorPoint.position += new Vector3(xOffset, 0, 0);
                    break;
                case 2:
                    generatorPoint.position += new Vector3(-xOffset, 0, 0);
                    break;
            }
        }

        rooms.Add(Instantiate(roomPrefab, generatorPoint.position, Quaternion.identity).GetComponent<Room>());

        bossRoom = rooms[rooms.Count -1].gameObject;

    }
}


[System.Serializable]
public class WallType 
{
    public GameObject   singleLeft, singleRight, singleUp, singleDown,
                        doubleLU, doubleLR, doubleLD, doubleUR, doubleUD, doubleRD,
                        tripleLUR, tripleLUD, tripleURD, tripleLRD,
                        fourDoors,
                        BossLeft,BossRight;
}
