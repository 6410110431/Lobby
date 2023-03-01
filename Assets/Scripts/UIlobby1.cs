using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MirrorBasics
{
    public class UIlobby1 : MonoBehaviour
    {
        [SerializeField] TMP_InputField joinMatchInput;
        [SerializeField] Button joinButton;
        [SerializeField] Button hostButton;
        public void Host()
        {
            joinMatchInput.interactable= false;
            joinButton.interactable = false;
            hostButton.interactable = false;
        }
        public void Join()
        {
            joinMatchInput.interactable = false;
            joinButton.interactable = false;
            hostButton.interactable = false;
        }
    }


}