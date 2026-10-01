using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _0xb671a95a : MonoBehaviour
{
    private void Update()
    {
        this._0x4803ebcc();
    }

    private void _0x4803ebcc()
    {
        if (this._0x0fc7211a.canvasRenderer.GetColor() != this._0x5dca90f1.canvasRenderer.GetColor())
            this._0x5dca90f1.canvasRenderer.SetColor(this._0x0fc7211a.canvasRenderer.GetColor());
    }

    private TMP_Text _0x5dca90f1;
    private Image _0x0fc7211a;
}