using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// The run HUD, built from this game's OWN objects inside the panel body rather
/// than dressed onto the template's placeholder slots (CLAUDE-unity.md C.2).
///
/// Two columns that never share an x band (C.25): the altimeter lives alone in a
/// gutter centred on x=62 of the 1242-unit canvas, and it occupies the vertical
/// middle of the screen, where the bracket at the top and the hint at the bottom
/// cannot reach it. Every reading label is centred and at most 1000 units wide, so
/// its left edge lands at x=121 - well clear of the gutter's right lip at 83.
///
/// The gesture hint is permanent, because the only control this game has is a
/// press-and-hold and the review is judged from screenshots (C.6).
public sealed class _0x22d52bec : MonoBehaviour
{
    private const float GutterCentre = 62f;
    private const float ColumnLow = 0.28f;
    private readonly List<Image> _0x1b9a6e00 = new List<Image>();
    public Button _0x4c64e63d { get; private set; }
    public RectTransform _0xf7828c0f { get; private set; }
    public Button _0x3e8ee91f { get; private set; }

    public void _0xa5aae22d(Transform _0x4bd54c5a, TMP_FontAsset _0x0f88302e, Sprite _0x75937396, Sprite _0x4b47a1d9, Sprite _0x68c3cbaf, Sprite _0x6ddced34, Sprite _0xc6e1380b)
    {
        RectTransform _0xb1a328a9 = _0xb1db93c9.Sheet(_0x4bd54c5a, _0x1d6a8fdc._0xed45595d(new byte[8] { 77, 98, 103, 99, 108, 70, 123, 106 }, 14));
        this._0xf7828c0f = _0xb1a328a9;
        // --- top bracket: back, the two readings, integrity, pause --------------
        RectTransform _0xb8c5e8b6 = _0xb1db93c9.Card(_0xb1a328a9, _0x1d6a8fdc._0xed45595d(new byte[10] { 203, 246, 231, 193, 241, 226, 224, 232, 230, 247 }, 131), _0x75937396, new Vector2(0.5f, BracketBand), new Vector2(0f, -150f), new Vector2(1160f, 300f), _0xa2f55a4e.Fade(_0xa2f55a4e.Surface, 0.94f), _0xa2f55a4e.Fade(_0xa2f55a4e.Primary, 0.88f), 1.3f, 4f);
        RectTransform _0x5373d730 = _0xb1db93c9.Card(_0xb8c5e8b6, _0x1d6a8fdc._0xed45595d(new byte[8] { 144, 179, 177, 185, 129, 190, 189, 166 }, 210), _0x75937396, new Vector2(0f, 0.5f), new Vector2(84f, 0f), new Vector2(132f, 132f), _0xa2f55a4e.Base, _0xa2f55a4e.Fade(_0xa2f55a4e.Primary, 0.9f), 1.5f, 3f);
        _0xb1db93c9.Picture(_0x5373d730, _0x1d6a8fdc._0xed45595d(new byte[9] { 237, 206, 204, 196, 232, 195, 214, 223, 199 }, 175), _0x6ddced34, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(88f, 88f), _0xa2f55a4e.TextMain);
        this._0x3e8ee91f = _0xb1db93c9.Pressable(_0x5373d730, Color.white, _0xa2f55a4e.Primary);
        RectTransform _0x294ee608 = _0xb1db93c9.Card(_0xb8c5e8b6, _0x1d6a8fdc._0xed45595d(new byte[9] { 219, 234, 254, 248, 238, 216, 231, 228, 255 }, 139), _0x75937396, new Vector2(1f, 0.5f), new Vector2(-84f, 0f), new Vector2(132f, 132f), _0xa2f55a4e.Base, _0xa2f55a4e.Fade(_0xa2f55a4e.Primary, 0.9f), 1.5f, 3f);
        _0xb1db93c9.Picture(_0x294ee608, _0x1d6a8fdc._0xed45595d(new byte[10] { 29, 44, 56, 62, 40, 10, 33, 52, 61, 37 }, 77), _0xc6e1380b, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(88f, 88f), _0xa2f55a4e.TextMain);
        this._0x4c64e63d = _0xb1db93c9.Pressable(_0x294ee608, Color.white, _0xa2f55a4e.Primary);
        // The box is cut for the widest reading this label will ever hold.
        this._0x051b96d0 = _0xb1db93c9.Label(_0xb8c5e8b6, _0x1d6a8fdc._0xed45595d(new byte[11] { 41, 31, 25, 14, 19, 21, 20, 54, 19, 20, 31 }, 122), _0x0f88302e, _0x1d6a8fdc._0xed45595d(new byte[15] { 164, 178, 180, 163, 190, 184, 185, 215, 199, 198, 215, 216, 215, 198, 207 }, 247), new Vector2(0.5f, 1f), new Vector2(0f, -74f), new Vector2(620f, 92f), 48f, _0xa2f55a4e.Gold, TextAlignmentOptions.Center);
        this._0x5da98124 = _0xb1db93c9.Label(_0xb8c5e8b6, _0x1d6a8fdc._0xed45595d(new byte[10] { 46, 3, 15, 1, 14, 18, 42, 15, 8, 3 }, 102), _0x0f88302e, _0x1d6a8fdc._0xed45595d(new byte[11] { 54, 38, 75, 38, 69, 74, 79, 75, 68, 67, 66 }, 6), new Vector2(0.5f, 1f), new Vector2(0f, -158f), new Vector2(620f, 64f), 36f, _0xa2f55a4e.TextMuted, TextAlignmentOptions.Center);
        _0xb1db93c9.Label(_0xb8c5e8b6, _0x1d6a8fdc._0xed45595d(new byte[12] { 24, 63, 37, 52, 54, 35, 56, 37, 40, 18, 48, 33 }, 81), _0x0f88302e, _0x1d6a8fdc._0xed45595d(new byte[9] { 250, 253, 231, 246, 244, 225, 250, 231, 234 }, 179), new Vector2(0.5f, 0f), new Vector2(0f, 104f), new Vector2(420f, 44f), 32f, _0xa2f55a4e.TextMuted, TextAlignmentOptions.Center);
        for (int _0x1b24a078 = 0; _0x1b24a078 < _0x1d9b8829.StartIntegrity; _0x1b24a078++)
        {
            Image _0xefadb71d = _0xb1db93c9.Picture(_0xb8c5e8b6, _0x1d6a8fdc._0xed45595d(new byte[3] { 198, 255, 230 }, 150) + _0x1b24a078, _0x4b47a1d9, new Vector2(0.5f, 0f), new Vector2((_0x1b24a078 - 1) * 76f, 52f), new Vector2(60f, 60f), _0xa2f55a4e.Gold);
            this._0x1b9a6e00.Add(_0xefadb71d);
        }

        // --- altimeter: one segment per section, alone in its gutter -------------
        for (int _0x5159b76d = 0; _0x5159b76d < _0x1d9b8829.Sections; _0x5159b76d++)
        {
            Image _0x84b3d75f = _0xb1db93c9.Picture(_0xb1a328a9, _0x1d6a8fdc._0xed45595d(new byte[3] { 71, 106, 114 }, 6) + _0x5159b76d, _0x68c3cbaf, new Vector2(0f, ColumnLow + _0x5159b76d * ColumnPitch), new Vector2(GutterCentre, 0f), new Vector2(42f, 42f), _0xa2f55a4e.Fade(_0xa2f55a4e.SurfaceAlt, 0.9f));
            this._0xc03383cd.Add(_0x84b3d75f);
        }

        // --- the gesture, spelled out, for the whole run -------------------------
        RectTransform _0x1eec006f = _0xb1db93c9.Card(_0xb1a328a9, _0x1d6a8fdc._0xed45595d(new byte[9] { 138, 171, 172, 182, 145, 182, 176, 171, 178 }, 194), _0x75937396, new Vector2(0.5f, HintBand), Vector2.zero, new Vector2(1000f, 124f), _0xa2f55a4e.Fade(_0xa2f55a4e.Deep, 0.88f), _0xa2f55a4e.Fade(_0xa2f55a4e.Primary, 0.7f), 1.3f, 3f);
        this._0x1209c1ff = _0xb1db93c9.Label(_0x1eec006f, _0x1d6a8fdc._0xed45595d(new byte[8] { 5, 36, 35, 57, 1, 36, 35, 40 }, 77), _0x0f88302e, _0x1d6a8fdc._0xed45595d(new byte[30] { 23, 16, 19, 27, 127, 11, 16, 127, 13, 22, 12, 26, 127, 114, 127, 13, 26, 19, 26, 30, 12, 26, 127, 11, 16, 127, 19, 16, 28, 20 }, 95), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(930f, 72f), 40f, _0xa2f55a4e.TextMain, TextAlignmentOptions.Center);
    }

    public void _0x037c3092(int _0xe80a10ae)
    {
        for (int _0x2ea3e4c2 = 0; _0x2ea3e4c2 < this._0x1b9a6e00.Count; _0x2ea3e4c2++)
        {
            Image _0x5c98e6b3 = this._0x1b9a6e00[_0x2ea3e4c2];
            if (_0x5c98e6b3 == null)
            {
                continue;
            }

            bool _0x061a145d = _0x2ea3e4c2 < _0xe80a10ae;
            _0x5c98e6b3.color = _0x061a145d ? _0xa2f55a4e.Gold : _0xa2f55a4e.Fade(_0xa2f55a4e.Danger, 0.35f);
            if (!_0x061a145d)
            {
                _0x5c98e6b3.transform.DOPunchScale(Vector3.one * 0.3f, _0x1d9b8829.TweenBase, 6, 0.6f);
            }
        }
    }

    private const float ColumnPitch = 0.0247f;
    /// The hint is at full strength for the first stretch of the run - which is
    /// exactly the window the review screenshots fall in - then settles back so it
    /// stops competing with the shaft without ever leaving the screen.
    public void _0x059201c9()
    {
        if (this._0x1209c1ff == null)
        {
            return;
        }

        this._0x1209c1ff.DOFade(0.5f, 0.8f);
    }

    private TextMeshProUGUI _0x5da98124;
    public void _0x68f96dd4(int _0x2f26a174)
    {
        int _0xde6ffd40 = Mathf.Clamp(_0x2f26a174 + 1, 1, _0x1d9b8829.Sections);
        if (this._0x051b96d0 != null)
        {
            this._0x051b96d0.text = _0x1d6a8fdc._0xed45595d(new byte[8] { 98, 116, 114, 101, 120, 126, 127, 17 }, 49) + _0xde6ffd40.ToString(_0x1d6a8fdc._0xed45595d(new byte[2] { 75, 75 }, 123)) + _0x1d6a8fdc._0xed45595d(new byte[3] { 0, 15, 0 }, 32) + _0x1d9b8829.Sections.ToString(_0x1d6a8fdc._0xed45595d(new byte[2] { 37, 37 }, 21));
            this._0x051b96d0.transform.DOPunchScale(Vector3.one * 0.1f, _0x1d9b8829.TweenFast, 5, 0.6f);
        }

        if (this._0x5da98124 != null)
        {
            this._0x5da98124.text = _0x1d9b8829.MetresAt(_0x2f26a174).ToString() + _0x1d6a8fdc._0xed45595d(new byte[10] { 228, 137, 228, 135, 136, 141, 137, 134, 129, 128 }, 196);
        }

        for (int _0x35684d7d = 0; _0x35684d7d < this._0xc03383cd.Count; _0x35684d7d++)
        {
            Image _0x50ec1623 = this._0xc03383cd[_0x35684d7d];
            if (_0x50ec1623 == null)
            {
                continue;
            }

            bool _0x01b8f9fa = _0x35684d7d <= _0x2f26a174;
            _0x50ec1623.color = _0x01b8f9fa ? _0xa2f55a4e.Gold : _0xa2f55a4e.Fade(_0xa2f55a4e.SurfaceAlt, 0.9f);
            if (_0x35684d7d == _0x2f26a174)
            {
                _0x50ec1623.transform.DOPunchScale(Vector3.one * 0.3f, _0x1d9b8829.TweenBase, 5, 0.6f);
            }
        }
    }

    private const float BracketBand = 0.955f;
    private readonly List<Image> _0xc03383cd = new List<Image>();
    private const float HintBand = 0.075f;
    private TextMeshProUGUI _0x051b96d0;
    private TextMeshProUGUI _0x1209c1ff;
}

internal static class _0x1d6a8fdc
{
    internal static string _0xed45595d(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}