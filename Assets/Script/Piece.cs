using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kivotos;

public class Piece : MonoBehaviour
{
    [SerializeField]
    private Texture texT;
    [SerializeField]
    private Texture texG;
    [SerializeField]
    private Texture texM;
    [SerializeField]
    private Texture texTtoG;
    [SerializeField]
    private Texture texTtoM;
    [SerializeField]
    private Texture texGtoT;
    [SerializeField]
    private Texture texGtoM;
    [SerializeField]
    private Texture texMtoT;
    [SerializeField]
    private Texture texMtoG;

    /// <summary>
    /// 現在の学校の種類
    /// </summary>
    public ESchool NowSchool { get; set; } = ESchool.None;

    /// <summary>
    /// リバース先の学校の種類
    /// </summary>
    public ESchool NextSchool { get; set; } = ESchool.None;

    /// <summary>
    /// 盤面の左上をVector2.Zeroとする駒の位置
    /// </summary>
    private Vector2 inGamePos = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        // 学校の種類によってモデルのテクスチャを変更する
        SetModelTexture();
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
        this.inGamePos = new Vector2(x * 2, y * 2);
        SetPosFromGamePos();
    }

    private void SetPosFromGamePos()
    {
        this.gameObject.transform.position = new Vector3(inGamePos.x, 0, -inGamePos.y);
    }

    private void SetModelTexture()
    {
        if (NowSchool == ESchool.None)
        {
            Debug.LogError("学校が指定されていません");
            return;
        }

        var material = this.gameObject.transform.Find("Model").GetComponent<MeshRenderer>().material;

        if (NowSchool == ESchool.Trinity)
        {
            if (NextSchool == ESchool.None)
            {
                material.mainTexture = texT;
            }
            else if(NextSchool == ESchool.Trinity)
            {
                material.mainTexture = texT;
            }
            else if(NextSchool == ESchool.Gehenna)
            {
                material.mainTexture = texTtoG;
            }
            else if(NextSchool == ESchool.Millennium)
            {
                material.mainTexture = texTtoM;
            }
        }
        else if (NowSchool == ESchool.Gehenna)
        {
            if (NextSchool == ESchool.None)
            {
                material.mainTexture = texG;
            }
            else if (NextSchool == ESchool.Trinity)
            {
                material.mainTexture = texGtoT;
            }
            else if (NextSchool == ESchool.Gehenna)
            {
                material.mainTexture = texG;
            }
            else if (NextSchool == ESchool.Millennium)
            {
                material.mainTexture = texGtoM;
            }
        }
        else if (NowSchool == ESchool.Millennium)
        {
            if (NextSchool == ESchool.None)
            {
                material.mainTexture = texM;
            }
            else if (NextSchool == ESchool.Trinity)
            {
                material.mainTexture = texMtoT;
            }
            else if (NextSchool == ESchool.Gehenna)
            {
                material.mainTexture = texMtoG;
            }
            else if (NextSchool == ESchool.Millennium)
            {
                material.mainTexture = texM;
            }
        }
    }
}