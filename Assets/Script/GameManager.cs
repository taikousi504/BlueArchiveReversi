using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kivotos;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public ESchool NowTurnSchool { get; private set; } = ESchool.Trinity;

    // Start is called before the first frame update
    void Start()
    {
        // 初期配置をセット
        HexManager.Instance.SetInitAllPiece();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextTurn()
    {
        if (NowTurnSchool == ESchool.Trinity)
        {
            NowTurnSchool = ESchool.Gehenna;
        }
        else if (NowTurnSchool == ESchool.Gehenna)
        {
            NowTurnSchool = ESchool.Millennium;
        }
        else
        {
            NowTurnSchool = ESchool.Trinity;
        }
    }
}
