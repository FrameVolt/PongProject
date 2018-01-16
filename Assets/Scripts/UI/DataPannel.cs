using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataPannel : MonoBehaviour {


    [SerializeField]
    private Text score,life;
    private GameManager gm;
    private void Start()
    {
        gm = GameManager.Instance;
    }
    private void Update()
    {
        if (GameManager.Instance.CurrentPlayerCount == GameManager.PlayerCount.One)
        {
            //life.text = gm.Life.ToString();
            //score.text = gm.Score.ToString();
        }
    }
}
