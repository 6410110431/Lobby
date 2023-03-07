using System.Collections;
using System.Collections.Generic;
using Mirror;
using Unity.VisualScripting;
using UnityEngine;

namespace MirrorBasics {
    public class AutoHostClient : MonoBehaviour {

        void Start () {
            if (!Application.isBatchMode) { 
                Debug.Log ($"=== Client Build ===");
                NetworkManager.singleton.StartClient ();
            } else {
                Debug.Log ($"=== Server Build ===");
                NetworkManager.singleton.StartServer();
            }
        }

        public void JoinLocal () {
            NetworkManager.singleton.StartClient ();
        }

    }
}