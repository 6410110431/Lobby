using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerBox : MonoBehaviour
{
    public TextMeshProUGUI PlayerText;
    private PlayerBox player;

    public void SetPlayer(PlayerBox player)
    {
        this.player = player;
        PlayerText.text = "NOSE";
    }
}
