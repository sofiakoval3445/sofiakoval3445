using TMPro;
using UnityEngine;

/// The template declares seven tutorial panels and this game dresses none of them:
/// its single gesture is written out permanently in the shaft itself and again on
/// the menu's own HOW TO PLAY sheet, so the tutorial flag on SETUP_OBJECT stays
/// off. Left alone, those panels still carry the filler paragraphs the template
/// ships with - exactly the leak that reached a store build on
/// ANDROID-3578. Every one of them is blanked at runtime instead (CLAUDE-unity.md
/// C.15).
///
/// The panels themselves stay in the pool and stay active: the controller addresses
/// panels by index, and pulling one out would renumber the rest.
public sealed class _0xfb7b4cff : MonoBehaviour
{
    private void _0x24e9d4f7(int _0xe5e64ee0)
    {
        if (_0x95eb9f22.Instance == null || _0x95eb9f22.Instance.Panels == null)
        {
            return;
        }

        if (_0xe5e64ee0 < 0 || _0xe5e64ee0 >= _0x95eb9f22.Instance.Panels.Count)
        {
            return;
        }

        _0xedbb5775 _0xe7fbb8d3 = _0x95eb9f22.Instance.Panels[_0xe5e64ee0];
        if (_0xe7fbb8d3 == null || _0xe7fbb8d3.Content == null)
        {
            return;
        }

        TMP_Text[] _0x4e2a3e99 = _0xe7fbb8d3.Content.GetComponentsInChildren<TMP_Text>(true);
        for (int _0x58f0a2b5 = 0; _0x58f0a2b5 < _0x4e2a3e99.Length; _0x58f0a2b5++)
        {
            _0x4e2a3e99[_0x58f0a2b5].text = "";
        }
    }

    public void _0x43a51755()
    {
        this._0x24e9d4f7(_0xfaef8027._0xec2ae8dc.TUTORIAL0);
        this._0x24e9d4f7(_0xfaef8027._0xec2ae8dc.TUTORIAL1);
        this._0x24e9d4f7(_0xfaef8027._0xec2ae8dc.TUTORIAL2);
        this._0x24e9d4f7(_0xfaef8027._0xec2ae8dc.TUTORIAL3);
        this._0x24e9d4f7(_0xfaef8027._0xec2ae8dc.TUTORIAL4);
        this._0x24e9d4f7(_0xfaef8027._0xec2ae8dc.TUTORIAL5);
        this._0x24e9d4f7(_0xfaef8027._0xec2ae8dc.TUTORIAL6);
    }
}