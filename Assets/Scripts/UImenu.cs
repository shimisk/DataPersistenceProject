using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImenu : MonoBehaviour
{
    public Text _playerName;

    private void Update()
    {
        if (_playerName !=null)
        {
            GameManager.instance.playerName = _playerName.text;
        }
    }
}
