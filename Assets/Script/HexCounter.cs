using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HexCounter : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textTrinity;

    [SerializeField]
    private TextMeshProUGUI textGehenna;

    [SerializeField]
    private TextMeshProUGUI textMilllennium;

    private void Update()
    {
        textTrinity.text = "x" + HexManager.Instance.GetHexs(Kivotos.ESchool.Trinity).Count.ToString();
        textGehenna.text = "x" + HexManager.Instance.GetHexs(Kivotos.ESchool.Gehenna).Count.ToString();
        textMilllennium.text = "x" + HexManager.Instance.GetHexs(Kivotos.ESchool.Millennium).Count.ToString();
    }
}
