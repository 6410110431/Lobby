using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class PlayerBox : NetworkBehaviour
{
    public static PlayerBox localPlayer;
    [SyncVar] public string matchID;

    private NetworkMatch networkMatch;

    private void Start()
    {
        networkMatch = GetComponent<NetworkMatch>();

        if (isLocalPlayer)
        {
            localPlayer = this;
        }
        else
        {
            MainMenu.instance.SpawnPlayerUIPrefab(this);
        }
    }

    public void HostGame()
    {
        string ID = MainMenu.GetRandomID();
        CmdHostGame(ID);
    }

    [Command]
    public void CmdHostGame(string ID)
    {
        matchID = ID;
        if (MainMenu.instance.HostGame(ID, gameObject))
        {
            Debug.Log("HostGame");
            networkMatch.matchId = ID.ToGuid();
            TargetHostGame(true, ID);
        }
        else
        {
            Debug.Log("HostGame Fail");
            TargetHostGame(false, ID);
        }
    }

    [TargetRpc]
    void TargetHostGame(bool success, string ID)
    {
        matchID = ID;
        Debug.Log($"ID {matchID} == {ID}");
        MainMenu.instance.HostSuccess(success, ID);
    }

    public void JoinGame(string inputID)
    {
        CmdJoinGame(inputID);
    }

    [Command]
    public void CmdJoinGame(string ID)
    {
        matchID = ID;
        if (MainMenu.instance.JoinGame(ID, gameObject))
        {
            Debug.Log("JoinGame");
            networkMatch.matchId = ID.ToGuid();
            TargetJoinGame(true, ID);
        }
        else
        {
            Debug.Log("JoinGame Fail");
            TargetJoinGame(false, ID);
        }
    }

    [TargetRpc]
    void TargetJoinGame(bool success, string ID)
    {
        matchID = ID;
        Debug.Log($"ID {matchID} == {ID}");
        MainMenu.instance.JoinSuccess(success, ID);
    }

    public void BeginGame()
    {
        CmdBeginGame();
    }

    [Command]
    public void CmdBeginGame()
    {
        MainMenu.instance.BeginGame(matchID);
        Debug.Log("BeginGame");
    }

    public void StartGame()
    {
        TargetBeginGame();
    }

    [TargetRpc]
    void TargetBeginGame()
    {
        Debug.Log($"ID {matchID} | Start");
        DontDestroyOnLoad(gameObject);
        MainMenu.instance.inGame = true;
        transform.localScale = new Vector3(1, 1, 1); 
        SceneManager.LoadScene("Game", LoadSceneMode.Additive);
    }

    void Update()
    {
        if (hasAuthority)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            float speed = 6f * Time.deltaTime;

            transform.Translate(new Vector2(moveHorizontal * speed, moveVertical * speed));
        }
    

    }

}
