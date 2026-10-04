using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// Builder for the NEON chrome both scenes are dressed with: dark bodies, a bright
/// accent ring underneath, no drop shadow. Everything is laid out against the
/// canvas reference resolution of 1242x2688 that both scene templates carry.
///
/// Labels made here get the full readability treatment CLAUDE-unity.md C.10 asks
/// for, because a label created from C# never reaches a scene file and the
/// contrast pass that reads scene files can never see it: word wrap OFF, line
/// breaks only where the caller typed a \n, autosize ON, and a floor safely above
/// the 24 px readability minimum of C.12.
public static class _0xb1db93c9
{
    public static TextMeshProUGUI Label(Transform _0x344ac48d, string _0x19c87019, TMP_FontAsset _0xccaa3619, string _0x8f3df7e8, Vector2 _0x4395c0c0, Vector2 _0xf3b5103a, Vector2 _0xe2fc1846, float _0xc4c6a394, Color _0x5ede0676, TextAlignmentOptions _0xa4594521)
    {
        RectTransform _0x63a71a06 = Node(_0x344ac48d, _0x19c87019, _0x4395c0c0, _0xf3b5103a, _0xe2fc1846);
        TextMeshProUGUI _0x9c21ef06 = _0x63a71a06.gameObject.AddComponent<TextMeshProUGUI>();
        if (_0xccaa3619 != null)
        {
            _0x9c21ef06.font = _0xccaa3619;
        }

        _0x9c21ef06.text = _0x8f3df7e8;
        _0x9c21ef06.color = _0x5ede0676;
        _0x9c21ef06.alignment = _0xa4594521;
        _0x9c21ef06.raycastTarget = false;
        _0x9c21ef06.characterSpacing = 3f;
        _0x9c21ef06.enableWordWrapping = false;
        _0x9c21ef06.overflowMode = TextOverflowModes.Overflow;
        _0x9c21ef06.enableAutoSizing = true;
        _0x9c21ef06.fontSizeMin = LabelFloor;
        _0x9c21ef06.fontSizeMax = Mathf.Max(LabelFloor, _0xc4c6a394);
        _0x9c21ef06.fontSize = Mathf.Max(LabelFloor, _0xc4c6a394);
        Dress(_0x9c21ef06);
        return _0x9c21ef06;
    }

    public static RectTransform Node(Transform _0xf0ccf427, string _0x3efa4e0a, Vector2 _0x23f2d055, Vector2 _0xe54e63d1, Vector2 _0xc325cce2)
    {
        GameObject _0xf8da9d98 = new GameObject(_0x3efa4e0a, typeof(RectTransform));
        RectTransform _0xbe20d448 = _0xf8da9d98.GetComponent<RectTransform>();
        _0xbe20d448.SetParent(_0xf0ccf427, false);
        _0xbe20d448.anchorMin = _0x23f2d055;
        _0xbe20d448.anchorMax = _0x23f2d055;
        _0xbe20d448.pivot = new Vector2(0.5f, 0.5f);
        _0xbe20d448.anchoredPosition = _0xe54e63d1;
        _0xbe20d448.sizeDelta = _0xc325cce2;
        _0xbe20d448.localScale = Vector3.one;
        return _0xbe20d448;
    }

    /// Reading fontMaterial hands back a per-label INSTANCE, so the shared font
    /// asset keeps the theme it was given and each runtime label still gets the
    /// outline the shader will not draw without the keyword.
    public static void Dress(TMP_Text _0x419ecf31)
    {
        if (_0x419ecf31 == null)
        {
            return;
        }

        Material _0x52c7c5b1 = _0x419ecf31.fontMaterial;
        if (_0x52c7c5b1 == null)
        {
            return;
        }

        _0x52c7c5b1.EnableKeyword(ShaderUtilities.Keyword_Outline);
        _0x52c7c5b1.SetColor(ShaderUtilities.ID_OutlineColor, _0xa2f55a4e.Ink);
        _0x52c7c5b1.SetFloat(ShaderUtilities.ID_OutlineWidth, 0.25f);
        _0x52c7c5b1.SetFloat(ShaderUtilities.ID_FaceDilate, 0.2f);
    }

    /// Full-screen catcher for overlays: it swallows taps meant for whatever sits
    /// underneath instead of letting them through to the menu behind it.
    public static Image Shade(Transform _0x913e0857, string _0xd319ae6e, Color _0x7adca90f)
    {
        RectTransform _0x568083f4 = Sheet(_0x913e0857, _0xd319ae6e);
        Image _0xf680a07b = _0x568083f4.gameObject.AddComponent<Image>();
        _0xf680a07b.color = _0x7adca90f;
        _0xf680a07b.raycastTarget = true;
        _0xf680a07b.canvasRenderer.cullTransparentMesh = false;
        return _0xf680a07b;
    }

    public const float RefWidth = 1242f;
    /// A content picture. preserveAspect is ON so a 512x768 beacon never turns into
    /// an egg inside a square box (rule F.2a).
    public static Image Picture(Transform _0x83a5d31a, string _0x7dbb09e1, Sprite _0xfca11d69, Vector2 _0x498fe299, Vector2 _0x40ba3cc5, Vector2 _0xfc273425, Color _0x24c885a4)
    {
        RectTransform _0x7bbd5c7d = Node(_0x83a5d31a, _0x7dbb09e1, _0x498fe299, _0x40ba3cc5, _0xfc273425);
        Image _0xdc1a8c7e = _0x7bbd5c7d.gameObject.AddComponent<Image>();
        _0xdc1a8c7e.sprite = _0xfca11d69;
        _0xdc1a8c7e.color = _0x24c885a4;
        _0xdc1a8c7e.raycastTarget = false;
        _0xdc1a8c7e.preserveAspect = true;
        return _0xdc1a8c7e;
    }

    /// A pressable card. The Button drives the BODY image, which is the surface the
    /// player actually sees, so the pressed tint reads instead of hiding behind the
    /// ring; the body also carries the raycast.
    public static Button Pressable(RectTransform _0xc4a12cc5, Color _0x61ddef24, Color _0xd9de5df0)
    {
        Image _0x93b8833e = _0xc4a12cc5.GetComponent<Image>();
        if (_0x93b8833e == null)
        {
            return null;
        }

        _0x93b8833e.raycastTarget = true;
        Button _0xabf3d9e2 = _0xc4a12cc5.gameObject.AddComponent<Button>();
        _0xabf3d9e2.targetGraphic = _0x93b8833e;
        ColorBlock _0xfd05bfef = _0xabf3d9e2.colors;
        _0xfd05bfef.normalColor = _0x61ddef24;
        _0xfd05bfef.highlightedColor = _0x61ddef24;
        _0xfd05bfef.pressedColor = _0xd9de5df0;
        _0xfd05bfef.selectedColor = _0x61ddef24;
        _0xfd05bfef.disabledColor = _0xa2f55a4e.Fade(_0xa2f55a4e.SurfaceAlt, 0.6f);
        _0xfd05bfef.fadeDuration = 0.08f;
        _0xabf3d9e2.colors = _0xfd05bfef;
        return _0xabf3d9e2;
    }

    /// A framed card: the accent ring is created FIRST and the dark body second, so
    /// the ring can never be drawn over the card's own contents. Children go into
    /// the body, which keeps the hierarchy order equal to the draw order (C.13).
    public static RectTransform Card(Transform _0x0d0460f1, string _0x87f38f27, Sprite _0xd7e802c2, Vector2 _0xec742ba5, Vector2 _0xe6ba1ce8, Vector2 _0xbf2dc54e, Color _0x696ef858, Color _0xc7132586, float _0x630bd10c, float _0x3d6aa702)
    {
        Image _0x1482f60d = Slab(_0x0d0460f1, _0x87f38f27, _0xd7e802c2, _0xec742ba5, _0xe6ba1ce8, _0xbf2dc54e, _0xc7132586, _0x630bd10c);
        RectTransform _0xae8343f0 = Node(_0x1482f60d.rectTransform, _0x87f38f27 + _0x92b5dfe8._0x78387de3(new byte[4] { 182, 155, 144, 141 }, 244), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(_0xbf2dc54e.x - _0x3d6aa702 * 2f, _0xbf2dc54e.y - _0x3d6aa702 * 2f));
        Image _0x0522d29d = _0xae8343f0.gameObject.AddComponent<Image>();
        _0x0522d29d.sprite = _0xd7e802c2;
        _0x0522d29d.type = Image.Type.Sliced;
        _0x0522d29d.pixelsPerUnitMultiplier = _0x630bd10c + 0.2f;
        _0x0522d29d.color = _0x696ef858;
        _0x0522d29d.raycastTarget = false;
        return _0xae8343f0;
    }

    /// A 9-sliced plate. Stretching is the whole point of these, so preserveAspect
    /// stays off here on purpose (rule F.2a, the explicit 9-slice exception).
    public static Image Slab(Transform _0x9dcd68fa, string _0x1c63fab8, Sprite _0xf1e2b8ac, Vector2 _0xfd31e17f, Vector2 _0x69833678, Vector2 _0x5b72fe8d, Color _0xa2519fbb, float _0xd981f869)
    {
        RectTransform _0xf160b1f2 = Node(_0x9dcd68fa, _0x1c63fab8, _0xfd31e17f, _0x69833678, _0x5b72fe8d);
        Image _0x3f6aa26c = _0xf160b1f2.gameObject.AddComponent<Image>();
        _0x3f6aa26c.sprite = _0xf1e2b8ac;
        _0x3f6aa26c.type = Image.Type.Sliced;
        _0x3f6aa26c.pixelsPerUnitMultiplier = _0xd981f869;
        _0x3f6aa26c.color = _0xa2519fbb;
        _0x3f6aa26c.raycastTarget = false;
        return _0x3f6aa26c;
    }

    public const float LabelFloor = 30f;
    public const float RefHeight = 2688f;
    public static RectTransform Sheet(Transform _0x4083adba, string _0x877a4480)
    {
        GameObject _0xf6efc568 = new GameObject(_0x877a4480, typeof(RectTransform));
        RectTransform _0x55b2a8e1 = _0xf6efc568.GetComponent<RectTransform>();
        _0x55b2a8e1.SetParent(_0x4083adba, false);
        _0x55b2a8e1.anchorMin = Vector2.zero;
        _0x55b2a8e1.anchorMax = Vector2.one;
        _0x55b2a8e1.pivot = new Vector2(0.5f, 0.5f);
        _0x55b2a8e1.offsetMin = Vector2.zero;
        _0x55b2a8e1.offsetMax = Vector2.zero;
        _0x55b2a8e1.localScale = Vector3.one;
        return _0x55b2a8e1;
    }
}

internal static class _0x92b5dfe8
{
    internal static string _0x78387de3(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}