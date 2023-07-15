using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 初期配置をセット
        StartGame.Instance.SetInitAllPiece();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
