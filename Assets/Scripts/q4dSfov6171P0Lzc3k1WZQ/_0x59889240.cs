using System.Collections.Generic;
using TMPro;
using UnityEngine;

// TmpContrastGuard.cs — staged into every Unity app by approve-pipeline-unity.sh
// (stage 5c3, rule C.14 in CLAUDE-unity.md). Do not edit the copy inside a project;
// edit scripts/lib/unity/TmpContrastGuard.cs.
//
// WHY: every TMP label gets an outline (C.10), and by default that outline is dark.
// A dark face colour on a dark outline merges into a smudge — the label is not
// readable on any backing (ANDROID-3627: PLAY drawn Deep #12151E on the #12151E
// outline read as a black blob). enforce-text-contrast.sh fixes colours SERIALISED
// in scenes/prefabs, but labels built at runtime from C# (UiKit.Cta, VaultUi.Caption,
// label.color = Palette.X ...) never reach a scene file, so that pass cannot see them.
//
// WHAT: after any TMP text is regenerated, compare its face colour with the outline
// colour of the material it actually renders with. Below WCAG 4.5:1 the face is
// blended toward white (dark outline) or black (light outline) until it reaches 7:1.
// Hue is kept; alpha is kept. A label whose outline was deliberately switched to a
// light colour (TextReadability-style per-label material) is measured against THAT
// outline, so intentionally dark text on a light rim is left alone. Labels without
// an outline are left alone too.
public sealed class _0x59889240 : MonoBehaviour
{
    private static float Linear(float _0xea017d0f)
    {
        _0xea017d0f = Mathf.Clamp01(_0xea017d0f);
        return _0xea017d0f <= 0.03928f ? _0xea017d0f / 12.92f : Mathf.Pow((_0xea017d0f + 0.055f) / 1.055f, 2.4f);
    }

    private readonly HashSet<TMP_Text> _0xb0a326f8 = new HashSet<TMP_Text>();
    // A lambda held in a field, never the bare method group: Plana renames the method
    // declaration but not a method-group reference (verify-unity-buttons.sh, CS0103).
    // The field keeps Add and Remove on the same delegate instance.
    private System.Action<Object> _0x44c61a16;
    private const float MinOutlineWidth = 0.01f;
    private void OnDisable()
    {
        if (this._0x44c61a16 != null)
            TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(this._0x44c61a16);
    }

    private static _0x59889240 _0xd1c94680;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Boot()
    {
        if (_0xd1c94680 != null)
            return;
        GameObject _0xf4232444 = new GameObject(_0x78555853._0x28ff7994(new byte[16] { 119, 78, 83, 96, 76, 77, 87, 81, 66, 80, 87, 100, 86, 66, 81, 71 }, 35));
        _0xf4232444.hideFlags = HideFlags.HideInHierarchy;
        DontDestroyOnLoad(_0xf4232444);
        _0xd1c94680 = _0xf4232444.AddComponent<_0x59889240>();
    }

    private void OnEnable()
    {
        if (this._0x44c61a16 == null)
            this._0x44c61a16 = _0xf4fabfe9 => this._0x6eb686f4(_0xf4fabfe9);
        TMPro_EventManager.TEXT_CHANGED_EVENT.Add(this._0x44c61a16);
    }

    private readonly List<TMP_Text> _0xdef7b014 = new List<TMP_Text>();
    private static float Ratio(Color _0xdd204141, Color _0xdc07ce6d)
    {
        float _0x87b1ac66 = Luminance(_0xdd204141);
        float _0xa1bbbffd = Luminance(_0xdc07ce6d);
        return (Mathf.Max(_0x87b1ac66, _0xa1bbbffd) + 0.05f) / (Mathf.Min(_0x87b1ac66, _0xa1bbbffd) + 0.05f);
    }

    // The event fires from inside the canvas rebuild. Changing the colour right there
    // would re-dirty the graphic mid-rebuild, which Unity rejects — so queue it and
    // apply in LateUpdate, which runs before the next frame's rebuild.
    private void _0x6eb686f4(Object _0x630caf3b)
    {
        TMP_Text _0x3b495f1a = _0x630caf3b as TMP_Text;
        if (_0x3b495f1a != null)
            this._0xb0a326f8.Add(_0x3b495f1a);
    }

    private const float TargetRatio = 7f;
    private const float MinRatio = 4.5f;
    private static void Fix(TMP_Text _0x58c61712)
    {
        if (_0x58c61712 == null || !_0x58c61712.isActiveAndEnabled)
            return;
        Material _0xd778d249 = _0x58c61712.fontSharedMaterial;
        if (_0xd778d249 == null || !_0xd778d249.HasProperty(ShaderUtilities.ID_OutlineColor) || !_0xd778d249.HasProperty(ShaderUtilities.ID_OutlineWidth))
            return;
        if (_0xd778d249.GetFloat(ShaderUtilities.ID_OutlineWidth) < MinOutlineWidth)
            return;
        Color _0xae1a4dd0 = _0x58c61712.color;
        if (_0xae1a4dd0.a <= 0f)
            return;
        Color _0x5b2e5925 = _0xd778d249.GetColor(ShaderUtilities.ID_OutlineColor);
        if (Ratio(_0xae1a4dd0, _0x5b2e5925) >= MinRatio)
            return;
        Color _0xa90be745 = Luminance(_0x5b2e5925) < 0.5f ? Color.white : Color.black;
        Color _0x3b472265;
        if (Ratio(_0xa90be745, _0x5b2e5925) < TargetRatio)
        {
            _0x3b472265 = _0xa90be745;
        }
        else
        {
            // Smallest blend that reaches the target: contrast grows monotonically
            // with t, so a short bisection keeps as much of the hue as possible.
            float _0xabf93360 = 0f;
            float _0x46a0fd6f = 1f;
            for (int _0xfb8db26e = 0; _0xfb8db26e < 20; _0xfb8db26e++)
            {
                float _0x3602407e = (_0xabf93360 + _0x46a0fd6f) * 0.5f;
                if (Ratio(Color.Lerp(_0xae1a4dd0, _0xa90be745, _0x3602407e), _0x5b2e5925) >= TargetRatio)
                    _0x46a0fd6f = _0x3602407e;
                else
                    _0xabf93360 = _0x3602407e;
            }

            _0x3b472265 = Color.Lerp(_0xae1a4dd0, _0xa90be745, _0x46a0fd6f);
        }

        _0x3b472265.a = _0xae1a4dd0.a;
        _0x58c61712.color = _0x3b472265;
    }

    // WCAG relative luminance of an sRGB colour, and the contrast ratio of two.
    private static float Luminance(Color _0xd7e432b0)
    {
        return 0.2126f * Linear(_0xd7e432b0.r) + 0.7152f * Linear(_0xd7e432b0.g) + 0.0722f * Linear(_0xd7e432b0.b);
    }

    private void LateUpdate()
    {
        if (this._0xb0a326f8.Count == 0)
            return;
        this._0xdef7b014.Clear();
        this._0xdef7b014.AddRange(this._0xb0a326f8);
        this._0xb0a326f8.Clear();
        for (int _0xe4a0ca30 = 0; _0xe4a0ca30 < this._0xdef7b014.Count; _0xe4a0ca30++)
            Fix(this._0xdef7b014[_0xe4a0ca30]);
    }
}

internal static class _0x78555853
{
    internal static string _0x28ff7994(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}