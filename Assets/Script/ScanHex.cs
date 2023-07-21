using Kivotos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanHex
{
    /// <summary>
    /// 方向
    /// </summary>
    public enum EDirection
    {
        UpRight,
        Right,
        DownRight,
        DownLeft,
        Left,
        UpLeft,
    }

    /// <summary>
    /// 全方向反転
    /// </summary>
    /// <param name="center">中心</param>
    public static bool ReverseHex(ESchool baseSchool, Hex center)
    {
        bool result = false;

        // 全方向に再帰処理をかける
        for (int i = 0; i < 6; i++)
        {
            bool resultStraight = ReverseHexStraight(baseSchool, center, (EDirection)i, 0);

            // 1つでもひっくり返せたならフラグを立てる
            if (resultStraight)
            {
                result = true;
            }
        }

        return result;
    }

    /// <summary>
    /// 一方向反転
    /// </summary>
    /// <param name="baseHex">中心</param>
    /// <param name="dir">方向</param>
    public static bool ReverseHexStraight(ESchool baseSchool, Hex baseHex, EDirection dir, int distance)
    {
        distance++;

        // 1つ先のマス取得
        Hex nextHex = null;

        switch (dir)
        {
            case EDirection.UpRight:
                nextHex = HexManager.Instance.GetHex(baseHex.InGamePos.x, baseHex.InGamePos.y - 1);
                break;
            case EDirection.Right:
                nextHex = HexManager.Instance.GetHex(baseHex.InGamePos.x + 1, baseHex.InGamePos.y);
                break;
            case EDirection.DownRight:
                nextHex = HexManager.Instance.GetHex(baseHex.InGamePos.x + 1, baseHex.InGamePos.y + 1);
                break;
            case EDirection.DownLeft:
                nextHex = HexManager.Instance.GetHex(baseHex.InGamePos.x, baseHex.InGamePos.y + 1);
                break;
            case EDirection.Left:
                nextHex = HexManager.Instance.GetHex(baseHex.InGamePos.x - 1, baseHex.InGamePos.y);
                break;
            case EDirection.UpLeft:
                nextHex = HexManager.Instance.GetHex(baseHex.InGamePos.x - 1, baseHex.InGamePos.y - 1);
                break;
        }

        // 1つ先のマスがnullであった場合ひっくり返さず終了
        if (nextHex == null)
        {
            return false;
        }

        // 1つ先のマスの学校が基準のマスの学校と一致していた時
        if (nextHex.NowSchool == baseSchool)
        {
            //距離が2以上なら挟まれているのでひっくり返せる
            if (distance >= 2)
            {
                baseHex.SetSchool(baseSchool);
                return true;
            }
            else
            {
                return false;
            }
        }

        // 1つ先のマスの学校が基準のマスの学校と一致していないなら次のマスを走査
        bool result = ReverseHexStraight(baseSchool, nextHex, dir, distance);

        if (result)
        {
            baseHex.SetSchool(baseSchool);
            return true;
        }

        return false;
    }
}
