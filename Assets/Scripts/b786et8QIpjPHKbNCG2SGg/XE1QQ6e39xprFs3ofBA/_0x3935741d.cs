using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class _0x3935741d : MonoBehaviour
{
    private static ScreenOrientation _0xca85ba76 = ScreenOrientation.LandscapeLeft;
    private void _0xfe3ee8fc()
    {
        if (this._0xcb9c9f67 == null)
            return;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        if (screenWidth <= 0f || screenHeight <= 0f)
            return;
        Rect _0x8bc5b7e4 = Screen.safeArea;
        Vector2 _0xea23cd54 = _0x8bc5b7e4.position;
        Vector2 _0xe5927ab3 = _0x8bc5b7e4.position + _0x8bc5b7e4.size;
        _0xea23cd54.x /= screenWidth;
        _0xea23cd54.y /= screenHeight;
        _0xe5927ab3.x /= screenWidth;
        _0xe5927ab3.y /= screenHeight;
        this._0xcb9c9f67.anchorMin = _0xea23cd54;
        this._0xcb9c9f67.anchorMax = _0xe5927ab3;
        this._0xcb9c9f67.offsetMin = Vector2.zero;
        this._0xcb9c9f67.offsetMax = Vector2.zero;
        if (this._0x0ffeb15c == null)
            return;
        Vector2 _0x71630532 = _0xe5927ab3 - _0xea23cd54;
        float _0xbcfb63b6 = 2f - _0x71630532.x;
        float _0xcddd1294 = 2f - _0x71630532.y;
        this._0x0ffeb15c.referenceResolution = this._0xe397847c * new Vector2(_0xbcfb63b6, _0xcddd1294);
    }

    private RectTransform _0xcb9c9f67;
    private RectTransform _0x7e879c04;
    private static Vector2 _0xf780a795 = Vector2.zero;
    private static void SafeAreaChanged()
    {
        _0x3fbde643 = Screen.safeArea;
        ApplySafeAreaToAll();
    }

    private static void OrientationChanged()
    {
        _0xca85ba76 = Screen.orientation;
        _0xf780a795.x = Screen.width;
        _0xf780a795.y = Screen.height;
        _0x3fbde643 = Screen.safeArea;
        ApplySafeAreaToAll();
        _0xda6f723f.Invoke();
    }

    private static void ApplySafeAreaToAll()
    {
        for (int _0x332a7348 = 0; _0x332a7348 < _0xc605b9ea.Count; _0x332a7348++)
            _0xc605b9ea[_0x332a7348]._0xfe3ee8fc();
    }

    private void Awake()
    {
        if (!_0xc605b9ea.Contains(this))
            _0xc605b9ea.Add(this);
        this._0x0c9f8acf = this.GetComponent<Canvas>();
        this._0x0ffeb15c = this.GetComponent<CanvasScaler>();
        if (this._0x0ffeb15c != null)
            this._0xe397847c = this._0x0ffeb15c.referenceResolution;
        this._0x7e879c04 = this.GetComponent<RectTransform>();
        this._0xcb9c9f67 = this.transform.Find(_0xe15eb75d._0xbc40fbf9(new byte[8] { 207, 253, 250, 249, 221, 238, 249, 253 }, 156)) as RectTransform;
        if (!_0xa69b3f72)
        {
            _0xca85ba76 = Screen.orientation;
            _0xf780a795.x = Screen.width;
            _0xf780a795.y = Screen.height;
            _0x3fbde643 = Screen.safeArea;
            _0xa69b3f72 = true;
        }

        this._0xfe3ee8fc();
    }

    private static Rect _0x3fbde643 = Rect.zero;
    private CanvasScaler _0x0ffeb15c;
    private static UnityEvent _0xda6f723f = new();
    private void OnDestroy()
    {
        if (_0xc605b9ea != null && _0xc605b9ea.Contains(this))
            _0xc605b9ea.Remove(this);
    }

    private void Start()
    {
    }

    private static readonly List<_0x3935741d> _0xc605b9ea = new();
    private static bool _0xa69b3f72;
    private Canvas _0x0c9f8acf;
    private void Update()
    {
        if (_0xc605b9ea.Count == 0 || _0xc605b9ea[0] != this)
            return;
        if (Application.isMobilePlatform && Screen.orientation != _0xca85ba76)
            OrientationChanged();
        if (Screen.safeArea != _0x3fbde643)
            SafeAreaChanged();
        if (Screen.width != _0xf780a795.x || Screen.height != _0xf780a795.y)
            ResolutionChanged();
    }

    private Vector2 _0xe397847c;
    private static void ResolutionChanged()
    {
        _0xf780a795.x = Screen.width;
        _0xf780a795.y = Screen.height;
        _0x3fbde643 = Screen.safeArea;
        ApplySafeAreaToAll();
        _0xda6f723f.Invoke();
    }
}

internal static class _0xe15eb75d
{
    internal static string _0xbc40fbf9(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}