using TMPro;
using UnityEngine;
using static _0xfaef8027;

public class _0x055edff1 : MonoBehaviour
{
    public void _0x63f8fb6f()
    {
        this.MoneyCountText.text = _0x6b1ba0f2._0x53608a6a.ToString();
    }

    public TMP_Text MoneyCountText;
    private void Start()
    {
        if (this.MoneyCountText == null)
        {
            TMP_Text _0x19c33439;
            if (this.gameObject.TryGetComponent(out _0x19c33439))
                this.MoneyCountText = _0x19c33439;
        }

        this._0x63f8fb6f();
    }
}