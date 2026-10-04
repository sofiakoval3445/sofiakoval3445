using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class _0x9283a3e1 : MonoBehaviour
{
    private List<string> _0x06e875be = new();
    private float _0x5fc6a9fb = 1.5f;
    private float _0x329127dc = 4;
    private void Update()
    {
        int _0x092a9383 = 1;
        if (this._0x06e875be.Count > 0)
        {
            string _0x3e0257cd = this._0xec7f7ee1.text;
            foreach (string _0x2ba7c352 in this._0x06e875be)
                while (_0x3e0257cd.Contains(_0x2ba7c352))
                    _0x3e0257cd = _0x3e0257cd.Replace(_0x2ba7c352, "");
            _0x092a9383 = _0x3e0257cd.Length;
        }
        else
        {
            _0x092a9383 = this._0xec7f7ee1.text.Length;
        }

        float _0x10ce4152 = Mathf.Clamp(this._0xf423360d + this._0x3af53987 * _0x092a9383, this._0x5fc6a9fb, this._0x329127dc);
        if (!Mathf.Approximately(this._0xe4c31ac4.aspectRatio, _0x10ce4152))
            this._0xe4c31ac4.aspectRatio = _0x10ce4152;
    }

    private TMP_Text _0xec7f7ee1;
    private float _0x3af53987 = 0.6f;
    private float _0xf423360d;
    private AspectRatioFitter _0xe4c31ac4;
}