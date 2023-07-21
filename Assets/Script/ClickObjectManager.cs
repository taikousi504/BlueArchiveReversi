using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickObjectManager : SingletonMonoBehaviour<ClickObjectManager>
{
    /// <summary>
    /// クリックされたオブジェクト
    /// </summary>
    public GameObject ClickedObj { get; private set; } = null;

    /// <summary>
    /// マスをクリックした時のイベント
    /// </summary>
    public UnityEvent OnClickHex { get; set; } = new UnityEvent();

    /// <summary>
    /// クリックされたマス
    /// </summary>
    public Hex ClickedHex => ClickedObj.GetComponent<Hex>();

    void Update()
    {
        // 左クリック押下時
        if (Input.GetMouseButtonDown(0))
        {
            ClickedObj = null;

            // レイキャストでクリックしたオブジェクトを取得する
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            bool result = Physics.Raycast(ray, out hit);

            if (!result)
            {
                return;
            }

            ClickedObj = hit.collider.gameObject;

            // クリックされたのがマスであったらプロパティに格納し、マスクリック時イベント発動
            if (ClickedObj.CompareTag("Hex"))
            {
                Debug.Log("Hex(" + ClickedHex.InGamePos.x + ", " + ClickedHex.InGamePos.y + ")");

                OnClickHex?.Invoke();
            }
        }
    }
}
