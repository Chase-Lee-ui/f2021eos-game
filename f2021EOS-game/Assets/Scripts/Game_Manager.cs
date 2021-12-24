using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    public static Dictionary<int, Player_Manager> players = new Dictionary<int, Player_Manager>();

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;
     private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying objects!");
            Destroy(this);
        }
    }

    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
    {
        GameObject _player;
        if(_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, _rotation);
        }
        else
        {
            _player = Instantiate(playerPrefab, _position, _rotation);
        }

        _player.GetComponent<Player_Manager>().id = _id;
        _player.GetComponent<Player_Manager>().username = _username;
        players.Add(_id, _player.GetComponent<Player_Manager>());
    }
}
