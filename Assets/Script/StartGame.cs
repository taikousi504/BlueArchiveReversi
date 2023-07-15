using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartGame : SingletonMonoBehaviour<StartGame>
{
    [SerializeField]
    Piece pfPiece;

    /// <summary>
    /// 駒を初期状態に配置する
    /// </summary>
    public void SetInitAllPiece()
    {
        // 一旦トリニティVSゲヘナ
        var piece = Instantiate(pfPiece);
        piece.SetInGamePos(3, 3);
        piece.NowSchool = Kivotos.ESchool.Trinity;

        piece = Instantiate(pfPiece);
        piece.SetInGamePos(3, 4);
        piece.NowSchool = Kivotos.ESchool.Gehenna;

        piece = Instantiate(pfPiece);
        piece.SetInGamePos(4, 3);
        piece.NowSchool = Kivotos.ESchool.Gehenna;

        piece = Instantiate(pfPiece);
        piece.SetInGamePos(4, 4);
        piece.NowSchool = Kivotos.ESchool.Trinity;
    }
}
