using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Canvas))]
public class _0x85d6444a : MonoBehaviour
{
    private static readonly List<_0x85d6444a> _0x045dd22e = new();
    private static UnityEvent _0x928e7fc6 = new();
    private RectTransform _0x4d435af0;
    private void OnDestroy()
    {
        if (_0x045dd22e != null && _0x045dd22e.Contains(this))
            _0x045dd22e.Remove(this);
    }

    private static Rect _0xf9a35514 = Rect.zero;
    private void Update()
    {
        if (_0x045dd22e[0] != this)
            return;
        if (Application.isMobilePlatform && Screen.orientation != _0x11153673)
            OrientationChanged();
        if (Screen.safeArea != _0xf9a35514)
            SafeAreaChanged();
        if (Screen.width != _0x2d4c1b35.x || Screen.height != _0x2d4c1b35.y)
            ResolutionChanged();
    }

    private static Vector2 _0x2d4c1b35 = Vector2.zero;
    private static void OrientationChanged()
    {
        _0x11153673 = Screen.orientation;
        _0x2d4c1b35.x = Screen.width;
        _0x2d4c1b35.y = Screen.height;
        _0x928e7fc6.Invoke();
    }

    private Canvas _0x51c25a4d;
    private RectTransform _0xac77b64e;
    private static void ResolutionChanged()
    {
        _0x2d4c1b35.x = Screen.width;
        _0x2d4c1b35.y = Screen.height;
        _0x928e7fc6.Invoke();
    }

    private static void SafeAreaChanged()
    {
        _0xf9a35514 = Screen.safeArea;
        for (int _0x3283852f = 0; _0x3283852f < _0x045dd22e.Count; _0x3283852f++)
            _0x045dd22e[_0x3283852f]._0x7e0eb27a();
    }

    private static ScreenOrientation _0x11153673 = ScreenOrientation.LandscapeLeft;
    private static bool _0x165d5c32;
    private void Awake()
    {
        if (!_0x045dd22e.Contains(this))
            _0x045dd22e.Add(this);
        this._0x51c25a4d = this.GetComponent<Canvas>();
        this._0xac77b64e = this.GetComponent<RectTransform>();
        this._0x4d435af0 = this.transform.Find(_0xb8ce8bb0._0x47d0d2bd(new byte[8] { 121, 75, 76, 79, 107, 88, 79, 75 }, 42)) as RectTransform;
        if (!_0x165d5c32)
        {
            _0x11153673 = Screen.orientation;
            _0x2d4c1b35.x = Screen.width;
            _0x2d4c1b35.y = Screen.height;
            _0xf9a35514 = Screen.safeArea;
            _0x165d5c32 = true;
        }

        this._0x7e0eb27a();
    }

    private void _0x7e0eb27a()
    {
        if (this._0x4d435af0 == null)
            return;
        Rect _0x70e7d30a = Screen.safeArea;
        Vector2 _0xe015543b = _0x70e7d30a.position;
        Vector2 _0xd4d77518 = _0x70e7d30a.position + _0x70e7d30a.size;
        _0xe015543b.x /= this._0x51c25a4d.pixelRect.width;
        _0xe015543b.y /= this._0x51c25a4d.pixelRect.height;
        _0xd4d77518.x /= this._0x51c25a4d.pixelRect.width;
        _0xd4d77518.y /= this._0x51c25a4d.pixelRect.height;
        this._0x4d435af0.anchorMin = _0xe015543b;
        this._0x4d435af0.anchorMax = _0xd4d77518;
    }
}

internal static class _0xb8ce8bb0
{
    internal static string _0x47d0d2bd(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}