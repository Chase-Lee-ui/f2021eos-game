using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public Vector2 XRange;
    public Vector2 YRange;
    public Vector2 ZRange;
    private void Start()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(XRange.x, XRange.y), 
            Random.Range(YRange.x, YRange.y), 
            Random.Range(ZRange.x, ZRange.y));
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
    }
}
