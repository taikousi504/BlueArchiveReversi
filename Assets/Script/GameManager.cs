using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kivotos;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    /// <summary>
    /// 現在のターンの学校
    /// </summary>
    public ESchool NowTurnSchool { get; private set; } = ESchool.Trinity;

    // Start is called before the first frame update
    void Start()
    {
        // 初期配置をセット
        HexManager.Instance.Initialize();
        HexManager.Instance.SetInitAllPiece();

        ClickObjectManager.Instance.OnClickHex.AddListener(OnClickHex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 次のターンへ遷移
    /// </summary>
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

    /// <summary>
    /// マスクリック時のイベント
    /// </summary>
    public void OnClickHex()
    {
        var center = ClickObjectManager.Instance.ClickedHex;

        // すでにマスに色がついていたらやりなおし
        if (center.NowSchool != ESchool.None)
        {
            return;
        }

        // ひっくり返してみる
        bool result = ScanHex.ReverseHex(NowTurnSchool, center);

        //ひっくり返せたなら次のターンへ
        if (result)
        {
            GameManager.Instance.NextTurn();
        }
    }
}
