using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TurnManager : MonoBehaviour
{
    private List<PlayerBox> players = new List<PlayerBox>();

    public void AddPlayer(PlayerBox player)
    {
        players.Add(player);
    }
}