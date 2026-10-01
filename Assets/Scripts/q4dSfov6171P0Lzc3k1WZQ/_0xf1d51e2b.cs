using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// Owns the three result cards at pop indices 7 / 8 / 6.
///
/// The template ships them wearing another game's wording, a grey body, labels for
/// metrics this game does not have ("Score:", "Reward:") and a close button whose
/// Image carries no sprite at all - which Unity draws as a solid white slab in the
/// corner. Patching that chrome piece by piece is how white slabs reach a store
/// build, so every child of the pop body is switched off and this game's own card
/// is built inside it instead: the slab is gone by construction, each button gets
/// its own caption, and the close glyph is a real sprite handed over as a
/// serialized reference (CLAUDE-unity.md C.3 / C.17).
///
/// Nothing here is addressed by name. The pops come from PopsController by index
/// and every sprite arrives through the inspector, so renaming survives.
public sealed class _0xf1d51e2b : MonoBehaviour
{
    private void _0x66d16b7a(int _0x78f193cd)
    {
        if (this._0x64e6ad11 == null)
        {
            return;
        }

        if (_0x78f193cd == _0xfaef8027._0x250cf309.PAUSE)
        {
            this._0x64e6ad11._0xf328d6f7();
            return;
        }

        this._0x64e6ad11._0x424439bd();
    }

    public void _0x7c30cbfe(int _0xb25b4249, int _0x9c45f745)
    {
        this.Fill(_0xfaef8027._0x250cf309.WIN, _0x7aebc1fc._0xaed68ac8(new byte[8] { 218, 204, 202, 221, 192, 198, 199, 169 }, 137) + _0x1d9b8829.Sections.ToString(_0x7aebc1fc._0xaed68ac8(new byte[2] { 202, 202 }, 250)) + _0x7aebc1fc._0xaed68ac8(new byte[3] { 149, 154, 149 }, 181) + _0x1d9b8829.Sections.ToString(_0x7aebc1fc._0xaed68ac8(new byte[2] { 35, 35 }, 19)), _0x7aebc1fc._0xaed68ac8(new byte[12] { 200, 207, 217, 222, 170, 194, 207, 195, 205, 194, 222, 170 }, 138) + _0x9c45f745.ToString() + _0x7aebc1fc._0xaed68ac8(new byte[2] { 177, 220 }, 145));
        this._0x08c9d11a(_0xfaef8027._0x250cf309.WIN, _0xb25b4249);
        this._0x62e6cd58(_0xfaef8027._0x250cf309.WIN);
    }

    private readonly Dictionary<int, TextMeshProUGUI> _0xfcef30fa = new Dictionary<int, TextMeshProUGUI>();
    private void _0x18d58eab(int _0x23133d6b, string _0x9077d500, Color _0x09fefd89, string _0xef70b128, string _0xb5baed8a, float _0xa65f05a5, bool _0x18f9875d, bool _0x41fe1fa1)
    {
        _0x058495bc _0x896240eb = this._0xcc634472(_0x23133d6b);
        if (_0x896240eb == null || _0x896240eb.Content == null)
        {
            return;
        }

        Transform _0xbfe32322 = _0x896240eb.Content.transform;
        for (int _0xfb9eb2ad = _0xbfe32322.childCount - 1; _0xfb9eb2ad >= 0; _0xfb9eb2ad--)
        {
            _0xbfe32322.GetChild(_0xfb9eb2ad).gameObject.SetActive(false);
        }

        RectTransform _0xa7f58434 = _0xb1db93c9.Card(_0xbfe32322, _0x7aebc1fc._0xaed68ac8(new byte[10] { 156, 171, 189, 187, 162, 186, 141, 175, 188, 170 }, 206), this._roundedPlate, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(1000f, _0xa65f05a5), _0xa2f55a4e.Surface, _0xa2f55a4e.Fade(_0xa2f55a4e.Primary, 0.9f), 1.3f, 5f);
        RectTransform _0x6d1191bb = _0xb1db93c9.Card(_0xa7f58434, _0x7aebc1fc._0xaed68ac8(new byte[9] { 103, 72, 75, 87, 65, 119, 72, 75, 80 }, 36), this._roundedPlate, new Vector2(1f, 1f), new Vector2(-78f, -78f), new Vector2(110f, 110f), _0xa2f55a4e.Base, _0xa2f55a4e.Fade(_0xa2f55a4e.Primary, 0.9f), 1.5f, 3f);
        _0xb1db93c9.Picture(_0x6d1191bb, _0x7aebc1fc._0xaed68ac8(new byte[10] { 191, 144, 147, 143, 153, 187, 144, 133, 140, 148 }, 252), this._closeIcon, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(56f, 56f), _0xa2f55a4e.TextMain);
        Button _0x5e823c5b = _0xb1db93c9.Pressable(_0x6d1191bb, Color.white, _0xa2f55a4e.Primary);
        int _0x978f07ff = _0x23133d6b;
        _0x5e823c5b.onClick.AddListener(() => this._0x66d16b7a(_0x978f07ff));
        // 740 wide, not the full body: a wider box would run under the close chip in
        // the corner even though the text inside it is centred.
        this._0x0c386e42[_0x23133d6b] = _0xb1db93c9.Label(_0xa7f58434, _0x7aebc1fc._0xaed68ac8(new byte[9] { 29, 63, 44, 58, 10, 55, 42, 50, 59 }, 94), this._font, _0x9077d500, new Vector2(0.5f, 1f), new Vector2(0f, -150f), new Vector2(740f, 112f), 64f, _0x09fefd89, TextAlignmentOptions.Center);
        // Row heights measured against the buttons: the primary sits 258 above the
        // body floor and is 148 tall, so nothing may reach below bodyHeight - 332.
        float _0x8117a1e0 = _0x18f9875d ? -600f : -300f;
        float _0x636ebb28 = _0x18f9875d ? -700f : (_0x41fe1fa1 ? -420f : -300f);
        float _0xa7274158 = _0x18f9875d ? -790f : (_0x41fe1fa1 ? -530f : -410f);
        if (_0x18f9875d)
        {
            Image _0xbe6b6ee8 = _0xb1db93c9.Picture(_0xa7f58434, _0x7aebc1fc._0xaed68ac8(new byte[9] { 46, 12, 31, 9, 46, 31, 8, 30, 25 }, 109), this._beaconFace, new Vector2(0.5f, 1f), new Vector2(0f, -370f), new Vector2(200f, 300f), _0xa2f55a4e.Gold);
            _0xbe6b6ee8.transform.DOPunchScale(Vector3.one * 0.16f, 0.7f, 5, 0.5f);
        }

        if (_0x41fe1fa1)
        {
            Image[] _0x8c22aeae = new Image[_0x1d9b8829.StartIntegrity];
            for (int _0xa159f2a8 = 0; _0xa159f2a8 < _0x8c22aeae.Length; _0xa159f2a8++)
            {
                _0x8c22aeae[_0xa159f2a8] = _0xb1db93c9.Picture(_0xa7f58434, _0x7aebc1fc._0xaed68ac8(new byte[7] { 11, 41, 58, 44, 24, 33, 56 }, 72) + _0xa159f2a8, this._pipFace, new Vector2(0.5f, 1f), new Vector2((_0xa159f2a8 - 1) * 88f, _0x8117a1e0), new Vector2(60f, 60f), _0xa2f55a4e.Fade(_0xa2f55a4e.Gold, 0.25f));
            }

            this._0xc71cd4df[_0x23133d6b] = _0x8c22aeae;
        }

        this._0x74617867[_0x23133d6b] = _0xb1db93c9.Label(_0xa7f58434, _0x7aebc1fc._0xaed68ac8(new byte[8] { 204, 238, 253, 235, 194, 238, 230, 225 }, 143), this._font, "", new Vector2(0.5f, 1f), new Vector2(0f, _0x636ebb28), new Vector2(860f, 84f), 48f, _0xa2f55a4e.TextMain, TextAlignmentOptions.Center);
        this._0xfcef30fa[_0x23133d6b] = _0xb1db93c9.Label(_0xa7f58434, _0x7aebc1fc._0xaed68ac8(new byte[9] { 92, 126, 109, 123, 90, 103, 107, 109, 126 }, 31), this._font, "", new Vector2(0.5f, 1f), new Vector2(0f, _0xa7274158), new Vector2(860f, 72f), 36f, _0xa2f55a4e.TextMuted, TextAlignmentOptions.Center);
        RectTransform _0xd9f2f250 = _0xb1db93c9.Card(_0xa7f58434, _0x7aebc1fc._0xaed68ac8(new byte[11] { 18, 48, 35, 53, 1, 35, 56, 60, 48, 35, 40 }, 81), this._roundedPlate, new Vector2(0.5f, 0f), new Vector2(0f, 258f), new Vector2(720f, 148f), _0xa2f55a4e.Primary, _0xa2f55a4e.Fade(_0xa2f55a4e.Gold, 0.9f), 1.3f, 4f);
        _0xb1db93c9.Label(_0xd9f2f250, _0x7aebc1fc._0xaed68ac8(new byte[14] { 6, 36, 63, 59, 55, 36, 47, 21, 55, 38, 34, 63, 57, 56 }, 86), this._font, _0xef70b128, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(650f, 76f), 52f, _0xa2f55a4e.TextMain, TextAlignmentOptions.Center);
        Button _0x53674c43 = _0xb1db93c9.Pressable(_0xd9f2f250, Color.white, _0xa2f55a4e.Violet);
        int _0x08f92a76 = _0x23133d6b;
        _0x53674c43.onClick.AddListener(() => this._0xe512bda5(_0x08f92a76));
        RectTransform _0x7d7c5633 = _0xb1db93c9.Card(_0xa7f58434, _0x7aebc1fc._0xaed68ac8(new byte[13] { 227, 193, 210, 196, 243, 197, 195, 207, 206, 196, 193, 210, 217 }, 160), this._roundedPlate, new Vector2(0.5f, 0f), new Vector2(0f, 118f), new Vector2(560f, 120f), _0xa2f55a4e.Base, _0xa2f55a4e.Fade(_0xa2f55a4e.Violet, 0.9f), 1.5f, 3f);
        _0xb1db93c9.Label(_0x7d7c5633, _0x7aebc1fc._0xaed68ac8(new byte[16] { 146, 164, 162, 174, 175, 165, 160, 179, 184, 130, 160, 177, 181, 168, 174, 175 }, 193), this._font, _0xb5baed8a, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(500f, 64f), 44f, _0xa2f55a4e.TextMuted, TextAlignmentOptions.Center);
        Button _0xe8668420 = _0xb1db93c9.Pressable(_0x7d7c5633, Color.white, _0xa2f55a4e.Violet);
        int _0x1c601e38 = _0x23133d6b;
        _0xe8668420.onClick.AddListener(() => this._0x0be39c0c(_0x1c601e38));
    }

    private void _0xe512bda5(int _0x76540889)
    {
        if (this._0x64e6ad11 == null)
        {
            return;
        }

        if (_0x76540889 == _0xfaef8027._0x250cf309.PAUSE)
        {
            this._0x64e6ad11._0xf328d6f7();
            return;
        }

        this._0x64e6ad11._0x80c8bd44();
    }

    private void Fill(int _0xb32a367e, string _0xcc9ab24c, string _0x921aa052)
    {
        TextMeshProUGUI _0xa4eec67f;
        if (this._0x74617867.TryGetValue(_0xb32a367e, out _0xa4eec67f) && _0xa4eec67f != null)
        {
            _0xa4eec67f.text = _0xcc9ab24c;
        }

        TextMeshProUGUI _0x83f02be3;
        if (this._0xfcef30fa.TryGetValue(_0xb32a367e, out _0x83f02be3) && _0x83f02be3 != null)
        {
            _0x83f02be3.text = _0x921aa052;
        }
    }

    public void _0xd74dd0e1()
    {
        if (_0x148306eb.Instance == null || _0x148306eb.Instance.Pops == null)
        {
            return;
        }

        // Each card is cut to its own contents, so no card carries a band of empty
        // body between the last reading and the buttons.
        this._0x18d58eab(_0xfaef8027._0x250cf309.WIN, _0x7aebc1fc._0xaed68ac8(new byte[14] { 73, 78, 74, 72, 68, 69, 43, 89, 78, 74, 72, 67, 78, 79 }, 11), _0xa2f55a4e.Gold, _0x7aebc1fc._0xaed68ac8(new byte[11] { 42, 37, 32, 36, 43, 73, 40, 46, 40, 32, 39 }, 105), _0x7aebc1fc._0xaed68ac8(new byte[4] { 243, 251, 240, 235 }, 190), 1220f, true, true);
        this._0x18d58eab(_0xfaef8027._0x250cf309.LOSE, _0x7aebc1fc._0xaed68ac8(new byte[12] { 15, 0, 5, 1, 14, 108, 14, 30, 3, 7, 9, 2 }, 76), _0xa2f55a4e.Danger, _0x7aebc1fc._0xaed68ac8(new byte[5] { 133, 146, 131, 133, 142 }, 215), _0x7aebc1fc._0xaed68ac8(new byte[4] { 89, 81, 90, 65 }, 20), 1020f, false, true);
        this._0x18d58eab(_0xfaef8027._0x250cf309.PAUSE, _0x7aebc1fc._0xaed68ac8(new byte[10] { 135, 136, 141, 137, 134, 228, 140, 129, 136, 128 }, 196), _0xa2f55a4e.TextMain, _0x7aebc1fc._0xaed68ac8(new byte[6] { 222, 201, 223, 217, 193, 201 }, 140), _0x7aebc1fc._0xaed68ac8(new byte[4] { 0, 8, 3, 24 }, 77), 880f, false, false);
    }

    [SerializeField]
    private Sprite _roundedPlate;
    private readonly Dictionary<int, Image[]> _0xc71cd4df = new Dictionary<int, Image[]>();
    /// Every card's second action makes the same promise: leave the shaft for the
    /// menu. Keeping it identical on all three means a player never has to work out
    /// which card they are looking at before they can get out of it.
    private void _0x0be39c0c(int _0x51506938)
    {
        if (this._0x64e6ad11 == null)
        {
            return;
        }

        this._0x64e6ad11._0x424439bd();
    }

    [SerializeField]
    private TMP_FontAsset _font;
    public void _0x171d273a(int _0x17ae3994, int _0xea06db67)
    {
        this.Fill(_0xfaef8027._0x250cf309.PAUSE, _0x7aebc1fc._0xaed68ac8(new byte[8] { 78, 88, 94, 73, 84, 82, 83, 61 }, 29) + Mathf.Clamp(_0x17ae3994 + 1, 1, _0x1d9b8829.Sections).ToString(_0x7aebc1fc._0xaed68ac8(new byte[2] { 192, 192 }, 240)) + _0x7aebc1fc._0xaed68ac8(new byte[3] { 9, 6, 9 }, 41) + _0x1d9b8829.Sections.ToString(_0x7aebc1fc._0xaed68ac8(new byte[2] { 218, 218 }, 234)), _0x7aebc1fc._0xaed68ac8(new byte[30] { 151, 144, 147, 155, 255, 139, 144, 255, 141, 150, 140, 154, 255, 242, 255, 141, 154, 147, 154, 158, 140, 154, 255, 139, 144, 255, 147, 144, 156, 148 }, 223));
        this._0x62e6cd58(_0xfaef8027._0x250cf309.PAUSE);
    }

    [SerializeField]
    private Sprite _pipFace;
    /// The template fills these three fields with its own score strings whenever a
    /// pop goes up; clearing them keeps a stray number from sitting behind the card.
    private void _0xfebfbe22(_0x058495bc _0x39c9a84f)
    {
        if (_0x39c9a84f == null)
        {
            return;
        }

        if (_0x39c9a84f.ContentHeaderText != null)
        {
            _0x39c9a84f.ContentHeaderText.text = "";
        }

        if (_0x39c9a84f.ContentMainText != null)
        {
            _0x39c9a84f.ContentMainText.text = "";
        }

        if (_0x39c9a84f.ContentAdditionalText != null)
        {
            _0x39c9a84f.ContentAdditionalText.text = "";
        }
    }

    private void _0x08c9d11a(int _0xda9213f4, int _0x899824a0)
    {
        Image[] _0xd3b2cd48;
        if (!this._0xc71cd4df.TryGetValue(_0xda9213f4, out _0xd3b2cd48))
        {
            return;
        }

        for (int _0xd74ce5d2 = 0; _0xd74ce5d2 < _0xd3b2cd48.Length; _0xd74ce5d2++)
        {
            if (_0xd3b2cd48[_0xd74ce5d2] == null)
            {
                continue;
            }

            bool _0xec8b6f7f = _0xd74ce5d2 < _0x899824a0;
            _0xd3b2cd48[_0xd74ce5d2].color = _0xec8b6f7f ? _0xa2f55a4e.Gold : _0xa2f55a4e.Fade(_0xa2f55a4e.Danger, 0.3f);
            if (_0xec8b6f7f)
            {
                _0xd3b2cd48[_0xd74ce5d2].transform.DOPunchScale(Vector3.one * 0.25f, 0.45f, 6, 0.6f).SetDelay(_0xd74ce5d2 * 0.08f);
            }
        }
    }

    private _0x058495bc _0xcc634472(int _0xd6856d3d)
    {
        if (_0x148306eb.Instance == null || _0x148306eb.Instance.Pops == null)
        {
            return null;
        }

        if (_0xd6856d3d < 0 || _0xd6856d3d >= _0x148306eb.Instance.Pops.Count)
        {
            return null;
        }

        return _0x148306eb.Instance.Pops[_0xd6856d3d];
    }

    private _0xe94a3778 _0x64e6ad11;
    [SerializeField]
    private Sprite _closeIcon;
    public void _0x2c7aabda(_0xe94a3778 _0xbd13ad95)
    {
        this._0x64e6ad11 = _0xbd13ad95;
    }

    private readonly Dictionary<int, TextMeshProUGUI> _0x0c386e42 = new Dictionary<int, TextMeshProUGUI>();
    [SerializeField]
    private Sprite _beaconFace;
    private void _0x62e6cd58(int _0xd3819ab7)
    {
        this._0xfebfbe22(this._0xcc634472(_0xd3819ab7));
        _0x148306eb.Instance._0x1eb41fb2(_0xd3819ab7);
    }

    private readonly Dictionary<int, TextMeshProUGUI> _0x74617867 = new Dictionary<int, TextMeshProUGUI>();
    public void _0xf910d1f4(int _0x48d3ec0b, int _0x224f9158)
    {
        this.Fill(_0xfaef8027._0x250cf309.LOSE, _0x7aebc1fc._0xaed68ac8(new byte[8] { 58, 44, 42, 61, 32, 38, 39, 73 }, 105) + Mathf.Clamp(_0x48d3ec0b + 1, 1, _0x1d9b8829.Sections).ToString(_0x7aebc1fc._0xaed68ac8(new byte[2] { 204, 204 }, 252)) + _0x7aebc1fc._0xaed68ac8(new byte[3] { 116, 123, 116 }, 84) + _0x1d9b8829.Sections.ToString(_0x7aebc1fc._0xaed68ac8(new byte[2] { 121, 121 }, 73)), _0x7aebc1fc._0xaed68ac8(new byte[12] { 199, 192, 214, 209, 165, 205, 192, 204, 194, 205, 209, 165 }, 133) + _0x224f9158.ToString() + _0x7aebc1fc._0xaed68ac8(new byte[2] { 170, 199 }, 138));
        this._0x08c9d11a(_0xfaef8027._0x250cf309.LOSE, 0);
        this._0x62e6cd58(_0xfaef8027._0x250cf309.LOSE);
    }
}

internal static class _0x7aebc1fc
{
    internal static string _0xaed68ac8(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}