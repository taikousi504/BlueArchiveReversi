using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kivotos;

public class Hex : MonoBehaviour
{
    [SerializeField]
    private Texture texNone;
    [SerializeField]
    private Texture texT;
    [SerializeField]
    private Texture texG;
    [SerializeField]
    private Texture texM;

    /// <summary>
    /// 現在の学校の種類
    /// </summary>
    public ESchool NowSchool { get; private set; } = ESchool.None;

    /// <summary>
    /// リバース先の学校の種類
    /// </summary>
    public ESchool NextSchool { get; private set; } = ESchool.None;

    /// <summary>
    /// 盤面の左上をVector2.Zeroとする駒の位置
    /// </summary>
    public Vector2Int InGamePos { get; private set; } = Vector2Int.zero;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ゲーム内位置をセット
    /// </summary>
    /// <param name="inGamePos"></param>
    public void SetInGamePos(int x, int y)
    {
        this.InGamePos = new Vector2Int(x, y);
        SetPosFromInGamePos();
    }

    /// <summary>
    /// 学校をセットし、モデルを更新
    /// </summary>
    /// <param name="school"></param>
    public void SetSchool(ESchool school)
    {
        NowSchool = school;
        SetModelTexture();
    }

    /// <summary>
    /// InGamePosからワールド座標をセット
    /// </summary>
    private void SetPosFromInGamePos()
    {
        this.gameObject.transform.position = new Vector3(InGamePos.x * 1.76f - InGamePos.y * 0.88f, 0, -InGamePos.y * 1.525f);
    }

    /// <summary>
    /// 学校の種類によってモデルのテクスチャを変更する
    /// </summary>
    private void SetModelTexture()
    {
        var material = this.gameObject.transform.Find("Model").GetComponent<MeshRenderer>().material;

        if (NowSchool == ESchool.None)
        {
            material.mainTexture = texNone;
        }
        else if (NowSchool == ESchool.Trinity)
        {
            material.mainTexture = texT;
        }
        else if (NowSchool == ESchool.Gehenna)
        {
            material.mainTexture = texG;
        }
        else if (NowSchool == ESchool.Millennium)
        {
            material.mainTexture = texM;
        }
    }
}