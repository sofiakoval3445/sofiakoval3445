using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class _0x1eb84cac : MonoBehaviour
{
    private void _0x90cc9596(Touch? _0xc9e59a8c)
    {
        if (!_0xeb787fb1.Instance._0xd0a09e2c)
        {
            _0xc9e59a8c = null;
            return;
        }

        int _0xa780063c = _0xc9e59a8c.Value.touchId;
        _0xc9e59a8c = Touch.activeTouches.FirstOrDefault(_0x8a40d791 => _0x8a40d791.touchId == _0xa780063c);
        if (!this._0x18a33157(_0xc9e59a8c.Value))
            _0xc9e59a8c = null;
    }

    private bool _0x36a62aa8(Touch? _0x94207491, Bounds _0xa0f6e74a, TouchPhase _0x26a99645)
    {
        if (!_0xeb787fb1.Instance._0xd0a09e2c)
        {
            _0x94207491 = null;
            return false;
        }

        if (_0x94207491 != null)
            if (_0x94207491.Value.phase == _0x26a99645)
            {
                Vector3 _0x20dc882f = Camera.main.ScreenToWorldPoint(_0x94207491.Value.screenPosition);
                Vector3 _0xc627bbfc = new(_0x20dc882f.x, _0x20dc882f.y, _0xa0f6e74a.center.z);
                if (_0xa0f6e74a.Contains(_0xc627bbfc) && this._0x18a33157(_0x94207491.Value))
                    return true;
            }

        return false;
    }

    private Touch? _0x051598dc(Bounds _0x4a9888ae)
    {
        if (!_0xeb787fb1.Instance._0xd0a09e2c)
            return null;
        foreach (Touch _0xab38994a in Touch.activeTouches)
            if (!_0xab38994a.ended)
            {
                Vector3 _0xfc41132c = Camera.main.ScreenToWorldPoint(_0xab38994a.screenPosition);
                Vector3 _0x788e3f2c = new(_0xfc41132c.x, _0xfc41132c.y, _0x4a9888ae.center.z);
                if (_0x4a9888ae.Contains(_0x788e3f2c) && this._0x18a33157(_0xab38994a))
                    return _0xab38994a;
            }

        return null;
    }

    private Touch? _0x12130136(Bounds _0xb384feaa, TouchPhase _0x205228ae)
    {
        if (!_0xeb787fb1.Instance._0xd0a09e2c)
            return null;
        foreach (Touch _0x399e4ba1 in Touch.activeTouches)
            if (_0x399e4ba1.phase == _0x205228ae)
            {
                Vector3 _0x7bd99af6 = Camera.main.ScreenToWorldPoint(_0x399e4ba1.screenPosition);
                Vector3 _0x27a2f4c9 = new(_0x7bd99af6.x, _0x7bd99af6.y, _0xb384feaa.center.z);
                if (_0xb384feaa.Contains(_0x27a2f4c9) && this._0x18a33157(_0x399e4ba1))
                    return _0x399e4ba1;
            }

        return null;
    }

    public BoxCollider2D CameraTouchBounds;
    private void Awake()
    {
        EnhancedTouchSupport.Enable();
        _0x04f160b8 = this.gameObject.GetComponent<_0x1eb84cac>();
    }

    private static _0x1eb84cac _0x04f160b8;
    private Touch? _0xdb337942(Bounds _0x2ea110c9)
    {
        if (!_0xeb787fb1.Instance._0xd0a09e2c)
            return null;
        foreach (Touch _0x316d9ba2 in Touch.activeTouches)
            if (_0x316d9ba2.ended)
            {
                Vector3 _0xa8957188 = Camera.main.ScreenToWorldPoint(_0x316d9ba2.screenPosition);
                Vector3 _0x69821038 = new(_0xa8957188.x, _0xa8957188.y, _0x2ea110c9.center.z);
                if (_0x2ea110c9.Contains(_0x69821038) && this._0x18a33157(_0x316d9ba2))
                    return _0x316d9ba2;
            }

        return null;
    }

    private bool _0x18a33157(Touch? _0x11a847fc)
    {
        if (!_0x11a847fc.HasValue)
            return false;
        Vector3 _0x807ec86c = Camera.main.ScreenToWorldPoint(_0x11a847fc.Value.screenPosition);
        Vector3 _0x7ad8b22d = _0x807ec86c;
        _0x7ad8b22d.z = this.CameraTouchBounds.transform.position.z;
        if (this.CameraTouchBounds.bounds.Contains(_0x7ad8b22d))
            return true;
        _0x11a847fc = null;
        return false;
    }

    private Touch? _0xec3cbef2()
    {
        if (!_0xeb787fb1.Instance._0xd0a09e2c)
            return null;
        foreach (Touch _0xefbc922c in Touch.activeTouches)
            if (_0xefbc922c.ended)
                if (this._0x18a33157(_0xefbc922c))
                    return _0xefbc922c;
        return null;
    }

    private Touch? _0x081c35e9()
    {
        if (!_0xeb787fb1.Instance._0xd0a09e2c)
            return null;
        foreach (Touch _0x90d52045 in Touch.activeTouches)
            if (!_0x90d52045.ended)
                if (this._0x18a33157(_0x90d52045))
                    return _0x90d52045;
        return null;
    }
}