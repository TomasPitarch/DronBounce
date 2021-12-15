using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> SpawnPoints;

    [SerializeField]
    List<GameObject> CameraSpawnPoints;

   
    Camera myCamera;

    [SerializeField]
    string PlayerPrefabName;

    [SerializeField]
    PlayerController _playerController;

    private void Awake()
    {
        myCamera = Camera.main;
        _playerController = GameObject.FindObjectOfType<PlayerController>();
    }
    void Start()
    {
        var order = PhotonNetwork.LocalPlayer.ActorNumber-1;

        var rotation = new Quaternion();

        rotation.eulerAngles = SpawnPoints[order].transform.eulerAngles;
        
        var character = PhotonNetwork.Instantiate(PlayerPrefabName,
                                  SpawnPoints[order].transform.position,
                                  rotation);



        myCamera.transform.position = CameraSpawnPoints[order].transform.position;
        rotation.eulerAngles = CameraSpawnPoints[order].transform.eulerAngles;
        myCamera.transform.eulerAngles = rotation.eulerAngles;


        _playerController.SetCharacter(character.GetComponent<Character>());
        
    }
    

}
