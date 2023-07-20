using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class HexManager : SingletonMonoBehaviour<HexManager>
{
    [SerializeField]
    Hex pfHex;

    public readonly int SIDE_LENGTH = 15;

    private List<Hex> hexList = new List<Hex>();

    /// <summary>
    /// 駒を初期状態に配置する
    /// </summary>
    public void SetInitAllPiece()
    {
        if (SIDE_LENGTH % 3 != 0 || SIDE_LENGTH < 9)
        {
            Debug.LogError("SIDE_LENGTHは3の倍数かつ9以上の値にしてください。");
            return;
        }

        hexList.Clear();

        // ピラミット上に配置
        for (int i = 0; i < SIDE_LENGTH; i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                var hex = Instantiate(pfHex, this.transform);
                hex.SetInGamePos(j, i);
                hex.SetSchool(Kivotos.ESchool.None);

                hexList.Add(hex);
            }
        }

        // 初期色セット
        /*
                    [ 0]
                  [ 1][ 2]
                [ 3][ 4][ 5]
              [ 6][ 7][ 8][ 9]
            [10][11][12][13][14]
         */
        int posCenterTopX = (SIDE_LENGTH / 3 - 2);
        int posCenterTopY = posCenterTopX * 2;

        var hexCenter0 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX && h.InGamePos.y == posCenterTopY);
        var hexCenter1 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX && h.InGamePos.y == posCenterTopY + 1);
        var hexCenter2 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX + 1 && h.InGamePos.y == posCenterTopY + 1);
        var hexCenter3 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX && h.InGamePos.y == posCenterTopY + 2);
        var hexCenter4 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX + 1 && h.InGamePos.y == posCenterTopY + 2);
        var hexCenter5 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX + 2 && h.InGamePos.y == posCenterTopY + 2);
        var hexCenter6 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX && h.InGamePos.y == posCenterTopY + 3);
        var hexCenter7 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX + 1 && h.InGamePos.y == posCenterTopY + 3);
        var hexCenter8 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX + 2 && h.InGamePos.y == posCenterTopY + 3);
        var hexCenter9 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX + 3 && h.InGamePos.y == posCenterTopY + 3);
        var hexCenter10 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX && h.InGamePos.y == posCenterTopY + 4);
        var hexCenter11 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX + 1 && h.InGamePos.y == posCenterTopY + 4);
        var hexCenter12 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX + 2 && h.InGamePos.y == posCenterTopY + 4);
        var hexCenter13 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX + 3 && h.InGamePos.y == posCenterTopY + 4);
        var hexCenter14 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX + 4 && h.InGamePos.y == posCenterTopY + 4);
        var hexCenter15 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX && h.InGamePos.y == posCenterTopY + 5);
        var hexCenter16 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX + 1 && h.InGamePos.y == posCenterTopY + 5);
        var hexCenter17 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX + 2 && h.InGamePos.y == posCenterTopY + 5);
        var hexCenter18 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX + 3 && h.InGamePos.y == posCenterTopY + 5);
        var hexCenter19 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX + 4 && h.InGamePos.y == posCenterTopY + 5);
        var hexCenter20 = hexList.FirstOrDefault(h => h.InGamePos.x == posCenterTopX + 5 && h.InGamePos.y == posCenterTopY + 5);

        hexCenter0.SetSchool(Kivotos.ESchool.Trinity);
        hexCenter1.SetSchool(Kivotos.ESchool.Gehenna);
        hexCenter2.SetSchool(Kivotos.ESchool.Millennium);
        hexCenter3.SetSchool(Kivotos.ESchool.Millennium);
        hexCenter4.SetSchool(Kivotos.ESchool.Trinity);
        hexCenter5.SetSchool(Kivotos.ESchool.Gehenna);
        hexCenter6.SetSchool(Kivotos.ESchool.Trinity);
        hexCenter7.SetSchool(Kivotos.ESchool.Gehenna);
        hexCenter8.SetSchool(Kivotos.ESchool.Millennium);
        hexCenter9.SetSchool(Kivotos.ESchool.Trinity);
        hexCenter10.SetSchool(Kivotos.ESchool.Gehenna);
        hexCenter11.SetSchool(Kivotos.ESchool.Millennium);
        hexCenter12.SetSchool(Kivotos.ESchool.Trinity);
        hexCenter13.SetSchool(Kivotos.ESchool.Gehenna);
        hexCenter14.SetSchool(Kivotos.ESchool.Millennium);
        hexCenter15.SetSchool(Kivotos.ESchool.Millennium);
        hexCenter16.SetSchool(Kivotos.ESchool.Trinity);
        hexCenter17.SetSchool(Kivotos.ESchool.Gehenna);
        hexCenter18.SetSchool(Kivotos.ESchool.Millennium);
        hexCenter19.SetSchool(Kivotos.ESchool.Trinity);
        hexCenter20.SetSchool(Kivotos.ESchool.Gehenna);
    }

    public Hex GetHex(int x, int y)
    {
        return hexList.FirstOrDefault(h => h.InGamePos.x == x && h.InGamePos.y == y);
    }
}
