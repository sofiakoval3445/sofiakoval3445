using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

/// Draws the shaft in world space and answers the two questions the run director
/// asks every frame: where is the container, and did it just hit something.
///
/// Every size is derived from the camera - one section is a fraction of the
/// orthographic half height, the shaft is a fraction of the half width, and each
/// sprite is a multiple of those (CLAUDE-unity.md C.0). Nothing is a literal.
///
/// The camera never moves. The whole shaft slides underneath it instead, which
/// keeps the template background, the canvas and the HUD exactly where they were
/// authored while the container stays parked at the anchor line.
///
/// Sorting orders are named constants in the -18..-4 band: the background canvas
/// sits at -30 and the pops at 10, so no piece of shaft art can ever cover a
/// result card (C.21).
public sealed class _0x42bb33f7 : MonoBehaviour
{
    public float _0xe972553c { get; private set; }

    private GameObject _0x23d4a23d;
    private void _0xbddc6368()
    {
        float _0x3f3c6338 = this._0xc6b77c42 * _0x1d9b8829.BarrierFraction;
        float _0x63aed7f8 = _0x3f3c6338 * 0.3f; // the barrier png is 640x192
        for (int _0xa51de869 = 0; _0xa51de869 < this._0xcd3b7209.Barriers.Count; _0xa51de869++)
        {
            _0xd855cefb._0xdd633498 _0x8c7b8313 = this._0xcd3b7209.Barriers[_0xa51de869];
            float _0xc8197a61 = this._0x111a8200(_0x8c7b8313.Ledge) + this._0x8785f478 * _0x8c7b8313.Height;
            SpriteRenderer _0x51d0ddae = this._0xeaeeb6d9(this._0x23d4a23d, OrderBarrier, new Vector2(_0x3f3c6338, _0x63aed7f8), new Vector3(0f, _0xc8197a61, 0f));
            if (_0x51d0ddae == null)
            {
                continue;
            }

            _0x4b229850 _0x8fcbb155 = _0x51d0ddae.gameObject.AddComponent<_0x4b229850>();
            _0x8fcbb155._0x70dc2284(_0x51d0ddae, this._0x8d128cf1, _0x8c7b8313.Speed, _0x8c7b8313.Phase, _0xc8197a61, new Vector2(_0x3f3c6338, _0x63aed7f8));
            this._0xeaf542dc.Add(_0x8fcbb155);
        }
    }

    public void _0xa6271afa(float _0xcd72caab, float _0xc084d7a3)
    {
        this._0x98d18dde(_0xcd72caab, _0xc084d7a3, _0xa2f55a4e.Gold);
        if (this._0x9112293e == null)
        {
            return;
        }

        DOTween.Kill(this._0x9112293e, true);
        this._0x9112293e.localScale = Vector3.one;
        this._0x9112293e.DOPunchScale(Vector3.one * 0.16f, _0x1d9b8829.LockFlash, 6, 0.6f);
    }

    private Transform _0x9112293e;
    public float _0x73d0b5a9 { get; private set; }
    public float _0xc6b77c42 { get; private set; }

    public void _0x45e5c899(int _0x5a3c4490)
    {
        if (_0x5a3c4490 < 0 || _0x5a3c4490 >= this._0x65e9caea.Count)
        {
            return;
        }

        SpriteRenderer _0x7137bd20 = this._0x65e9caea[_0x5a3c4490];
        if (_0x7137bd20 == null)
        {
            return;
        }

        DOTween.Kill(_0x7137bd20, true);
        _0x7137bd20.DOColor(_0xa2f55a4e.Gold, _0x1d9b8829.TweenBase);
    }

    private const int OrderFx = -4;
    public void _0x2ccaddbd()
    {
        if (this._0x043908f1 == null)
        {
            return;
        }

        DOTween.Kill(this._0x043908f1, true);
        this._0x043908f1.DOColor(_0xa2f55a4e.Gold, 0.6f);
        this._0x043908f1.transform.DOPunchScale(Vector3.one * 0.18f, 0.7f, 5, 0.5f);
    }

    public float _0x1858b1bc()
    {
        return this._0x111a8200(_0x1d9b8829.Sections - 1) + this._0x8785f478 * 0.92f;
    }

    public float _0x111a8200(int _0x4edd717c)
    {
        if (this._0xcd3b7209 == null)
        {
            return _0x4edd717c * this._0x8785f478;
        }

        int _0x41907f79 = Mathf.Clamp(_0x4edd717c, 0, this._0xcd3b7209.Sections - 1);
        return (_0x41907f79 + this._0xcd3b7209.LedgeOffset[_0x41907f79]) * this._0x8785f478;
    }

    private GameObject _0xf71b3969;
    private const int OrderParallax = -16;
    private const int OrderBarrier = -10;
    private const int OrderContainer = -8;
    private SpriteRenderer _0xeaeeb6d9(GameObject _0xacf04364, int _0x5b5238d3, Vector2 _0x5aa81e59, Vector3 _0xaa691a56)
    {
        GameObject _0x574b27ae = Instantiate(_0xacf04364, this._0x2eaec46e);
        _0x574b27ae.transform.localPosition = _0xaa691a56;
        _0x574b27ae.transform.localScale = Vector3.one;
        SpriteRenderer _0x0fcf885d = _0x574b27ae.GetComponent<SpriteRenderer>();
        if (_0x0fcf885d != null)
        {
            _0x0fcf885d.sortingOrder = _0x5b5238d3;
            _0x0fcf885d.size = _0x5aa81e59;
        }

        return _0x0fcf885d;
    }

    private GameObject _0x7333acf0;
    public float _0x8e0164f3 { get; private set; }

    private void _0x98d18dde(float _0x683e8200, float _0xb0fdf4e2, Color _0xdcbfe6c3)
    {
        if (this._0x97f3b2fb == null || this._0x03fb6000 == null)
        {
            return;
        }

        this._0x97f3b2fb.localPosition = new Vector3(_0xb0fdf4e2, _0x683e8200, 0f);
        this._0x97f3b2fb.localScale = Vector3.one * 0.6f;
        DOTween.Kill(this._0x97f3b2fb, true);
        DOTween.Kill(this._0x03fb6000, true);
        this._0x03fb6000.color = _0xa2f55a4e.Fade(_0xdcbfe6c3, 0.9f);
        this._0x97f3b2fb.DOScale(1.3f, _0x1d9b8829.LockFlash).SetEase(Ease.OutQuad);
        this._0x03fb6000.DOFade(0f, _0x1d9b8829.LockFlash);
    }

    private void _0x23d4629c()
    {
        float _0xb0bf00aa = this._0x8785f478 * _0x1d9b8829.BeaconFraction;
        float _0x89253f53 = _0xb0bf00aa / 1.5f; // the beacon png is 512x768
        this._0x043908f1 = this._0xeaeeb6d9(this._0xef17cf73, OrderBeacon, new Vector2(_0x89253f53, _0xb0bf00aa), new Vector3(0f, this._0x1858b1bc(), 0f));
        if (this._0x043908f1 == null)
        {
            return;
        }

        this._0x043908f1.color = _0xa2f55a4e.Fade(_0xa2f55a4e.Primary, 0.75f);
        DOTween.Kill(this._0x043908f1.transform, true);
        this._0x043908f1.transform.DOScale(1.04f, 1.3f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    public void _0x45851428(bool _0x4139a87a)
    {
        if (this._0x347b0bd1 == null)
        {
            return;
        }

        this._0x347b0bd1.color = _0x4139a87a ? _0xa2f55a4e.Fade(Color.white, 0.55f) : Color.white;
    }

    private float _0xf6235cdc;
    public float _0x447aeda9 { get; private set; }

    private Camera _0xb4d64300;
    /// All of the game's spatial truth, in one place, read off the live camera.
    private void _0x25adce8f()
    {
        float _0x70d19eea = this._0xb4d64300 != null ? this._0xb4d64300.orthographicSize : 5f;
        float _0xffb600a2 = _0x70d19eea * (this._0xb4d64300 != null ? this._0xb4d64300.aspect : 0.45f);
        this._0x8785f478 = _0x70d19eea * _0x1d9b8829.SectionFraction;
        this._0xc6b77c42 = _0xffb600a2 * _0x1d9b8829.ShaftFraction;
        this._0x73d0b5a9 = this._0x8785f478 * _0x1d9b8829.ContainerFraction * 0.5f;
        this._0xc0f5ce85 = _0x70d19eea * _0x1d9b8829.AnchorFraction;
        this._0x447aeda9 = _0x70d19eea * _0x1d9b8829.RiseFraction;
        this._0x04ad7d11 = _0x70d19eea * _0x1d9b8829.SettleFraction;
        this._0xe972553c = _0x70d19eea * _0x1d9b8829.DropFraction;
        this._0x8e0164f3 = _0xffb600a2 * _0x1d9b8829.SwayFraction;
        float _0xf6021751 = this._0xc6b77c42 * _0x1d9b8829.LedgeFraction;
        this._0xce9c1ece = this._0xc6b77c42 - _0xf6021751 * 0.5f;
        float _0x9db0fa88 = this._0xc6b77c42 * _0x1d9b8829.BarrierFraction;
        this._0xf820460e = _0x9db0fa88 * 0.5f;
        this._0x8d128cf1 = Mathf.Max(0.01f, this._0xc6b77c42 - this._0xf820460e);
    }

    private GameObject _0x0bf2bcca;
    public float _0x8785f478 { get; private set; }

    private const int OrderLedge = -14;
    private SpriteRenderer _0x043908f1;
    /// True when the container rect overlaps a barrier rect. The extents are shaved
    /// a little so a clean-looking near miss is scored as a near miss.
    public bool _0x14942e21(float _0x708474bb, float _0xeb06cf13)
    {
        for (int _0x68951ec5 = 0; _0x68951ec5 < this._0xeaf542dc.Count; _0x68951ec5++)
        {
            _0x4b229850 _0x19a08682 = this._0xeaf542dc[_0x68951ec5];
            if (_0x19a08682 == null)
            {
                continue;
            }

            if (Mathf.Abs(_0x708474bb - _0x19a08682._0xa227f64d) >= (this._0x73d0b5a9 + _0x19a08682._0x56a5b6f8) * 0.82f)
            {
                continue;
            }

            if (Mathf.Abs(_0xeb06cf13 - _0x19a08682._0x2333fe8f) < (this._0x73d0b5a9 + _0x19a08682._0x36e9d81c) * 0.86f)
            {
                return true;
            }
        }

        return false;
    }

    private SpriteRenderer _0x347b0bd1;
    public void _0x31faa5d7(_0xd855cefb _0x3974e8e4)
    {
        this._0xcd3b7209 = _0x3974e8e4;
        this._0xeaf542dc.Clear();
        this._0x65e9caea.Clear();
        if (this._0x2eaec46e != null)
        {
            Destroy(this._0x2eaec46e.gameObject);
        }

        GameObject _0x7ca7131d = new GameObject(_0x0a28df1c._0xab7ca6e2(new byte[10] { 210, 233, 224, 231, 245, 210, 245, 224, 230, 228 }, 129));
        _0x7ca7131d.transform.SetParent(this.transform, false);
        this._0x2eaec46e = _0x7ca7131d.transform;
        this._0x642b5f16();
        this._0x13c63e19();
        this._0xbddc6368();
        this._0x23d4629c();
        this._0xb3c31014();
    }

    private void _0xb3c31014()
    {
        float _0xe60e5c5e = this._0x73d0b5a9 * 2f;
        this._0x347b0bd1 = this._0xeaeeb6d9(this._0xe556da02, OrderContainer, new Vector2(_0xe60e5c5e, _0xe60e5c5e), new Vector3(this._0x5725c74f(0), this._0x111a8200(0), 0f));
        if (this._0x347b0bd1 != null)
        {
            this._0x9112293e = this._0x347b0bd1.transform;
        }

        this._0x03fb6000 = this._0xeaeeb6d9(this._0x0bf2bcca, OrderFx, new Vector2(_0xe60e5c5e * 1.9f, _0xe60e5c5e * 1.9f), new Vector3(this._0x5725c74f(0), this._0x111a8200(0), 0f));
        if (this._0x03fb6000 == null)
        {
            return;
        }

        this._0x97f3b2fb = this._0x03fb6000.transform;
        this._0x03fb6000.color = _0xa2f55a4e.Fade(_0xa2f55a4e.Gold, 0f);
    }

    public void _0x2cf7c472(float _0xfccc9abc, float _0x842c0055)
    {
        if (this._0x9112293e == null)
        {
            return;
        }

        this._0x9112293e.localPosition = new Vector3(_0x842c0055, _0xfccc9abc, 0f);
    }

    private GameObject _0xef17cf73;
    public float _0xf820460e { get; private set; }

    private _0xd855cefb _0xcd3b7209;
    public void _0xe13b7fb9(Camera _0xd0683c75, GameObject _0x92c4f9b0, GameObject _0x2ee54ddf, GameObject _0xaf44437f, GameObject _0x04feee42, GameObject _0x50ca051d, GameObject _0xfc33b0da, Sprite _0xc07d1ca0, Sprite _0x47e438ed)
    {
        this._0xb4d64300 = _0xd0683c75;
        this._0xf71b3969 = _0x92c4f9b0;
        this._0x7333acf0 = _0x2ee54ddf;
        this._0x23d4a23d = _0xaf44437f;
        this._0xe556da02 = _0x04feee42;
        this._0xef17cf73 = _0x50ca051d;
        this._0x0bf2bcca = _0xfc33b0da;
        this._0x8e3de696 = _0xc07d1ca0;
        this._0xec88e946 = _0x47e438ed;
        this._0x25adce8f();
    }

    private Sprite _0xec88e946;
    public void _0xeec745c0(float _0xc85f74c5, float _0x283e0320)
    {
        this._0x98d18dde(_0xc85f74c5, _0x283e0320, _0xa2f55a4e.Danger);
        if (this._0x347b0bd1 == null)
        {
            return;
        }

        DOTween.Kill(this._0x347b0bd1, true);
        this._0x347b0bd1.color = _0xa2f55a4e.Danger;
        this._0x347b0bd1.DOColor(Color.white, 0.25f).SetDelay(0.12f);
    }

    private void _0x13c63e19()
    {
        float _0xb27ccb84 = this._0xc6b77c42 * _0x1d9b8829.LedgeFraction;
        float _0xdee24396 = _0xb27ccb84 * 0.5f; // the ledge png is 512x256
        for (int _0xe0180e6d = 0; _0xe0180e6d < this._0xcd3b7209.Sections; _0xe0180e6d++)
        {
            bool _0xc87ad0e2 = this._0xcd3b7209.LedgeOnLeft[_0xe0180e6d];
            SpriteRenderer _0xaffb9d2d = this._0xeaeeb6d9(this._0x7333acf0, OrderLedge, new Vector2(_0xb27ccb84, _0xdee24396), new Vector3(_0xc87ad0e2 ? -this._0xce9c1ece : this._0xce9c1ece, this._0x111a8200(_0xe0180e6d), 0f));
            if (_0xaffb9d2d == null)
            {
                continue;
            }

            // The two ledges are drawn as separate art facing opposite ways, so the
            // renderer picks the matching sprite instead of mirroring one of them.
            _0xaffb9d2d.sprite = _0xc87ad0e2 ? this._0x8e3de696 : this._0xec88e946;
            _0xaffb9d2d.color = _0xe0180e6d == this._0xcd3b7209.Sections - 1 ? _0xa2f55a4e.Fade(_0xa2f55a4e.Gold, 0.95f) : _0xa2f55a4e.Fade(_0xa2f55a4e.TextMain, 0.92f);
            this._0x65e9caea.Add(_0xaffb9d2d);
        }
    }

    public float _0xce9c1ece { get; private set; }

    private readonly List<_0x4b229850> _0xeaf542dc = new List<_0x4b229850>();
    private readonly List<SpriteRenderer> _0x65e9caea = new List<SpriteRenderer>();
    private Sprite _0x8e3de696;
    /// Slides the shaft so the container keeps riding the anchor line. The camera
    /// itself is never touched, so the background art stays exactly where the
    /// template put it.
    public void _0x81c397d6(float _0xdfc1a711, bool _0x53dfef5e)
    {
        if (this._0x2eaec46e == null)
        {
            return;
        }

        float _0x4dfa327c = this._0xc0f5ce85 - _0xdfc1a711;
        if (_0x53dfef5e)
        {
            this._0x58f98d67 = _0x4dfa327c;
            this._0xf6235cdc = 0f;
        }
        else
        {
            this._0x58f98d67 = Mathf.SmoothDamp(this._0x58f98d67, _0x4dfa327c, ref this._0xf6235cdc, _0x1d9b8829.FollowSmooth);
        }

        this._0x2eaec46e.localPosition = new Vector3(0f, this._0x58f98d67, 0f);
    }

    public float _0x8d128cf1 { get; private set; }

    private SpriteRenderer _0x03fb6000;
    private float _0x58f98d67;
    private Transform _0x97f3b2fb;
    public float _0x04ad7d11 { get; private set; }

    private Transform _0x2eaec46e;
    public float _0xc0f5ce85 { get; private set; }

    public float _0x5725c74f(int _0x1cd98a46)
    {
        if (this._0xcd3b7209 == null)
        {
            return this._0xce9c1ece;
        }

        int _0xf98d2031 = Mathf.Clamp(_0x1cd98a46, 0, this._0xcd3b7209.Sections - 1);
        return this._0xcd3b7209.LedgeOnLeft[_0xf98d2031] ? -this._0xce9c1ece : this._0xce9c1ece;
    }

    private const int OrderWallFar = -18;
    private GameObject _0xe556da02;
    private void _0x642b5f16()
    {
        float _0x1f0367e4 = this._0xb4d64300 != null ? this._0xb4d64300.orthographicSize * this._0xb4d64300.aspect : 2.25f;
        float _0x0875dea8 = _0x1f0367e4 * _0x1d9b8829.WallFraction;
        float _0xa72bafbc = _0x1f0367e4 * _0x1d9b8829.WallThickFraction;
        float _0xf1c613bf = _0x1f0367e4 * _0x1d9b8829.RibThickFraction;
        for (int _0xf73c0002 = -2; _0xf73c0002 < _0x1d9b8829.Sections + 2; _0xf73c0002++)
        {
            float _0xc29aa9a3 = _0xf73c0002 * this._0x8785f478;
            for (int _0x44a7706b = 0; _0x44a7706b < 2; _0x44a7706b++)
            {
                float _0xdddd41e6 = _0x44a7706b == 0 ? -_0x0875dea8 : _0x0875dea8;
                SpriteRenderer _0x62f13714 = this._0xeaeeb6d9(this._0xf71b3969, OrderWallFar, new Vector2(_0xa72bafbc, this._0x8785f478), new Vector3(_0xdddd41e6, _0xc29aa9a3, 0f));
                if (_0x62f13714 != null)
                {
                    _0x62f13714.color = _0xa2f55a4e.Fade(_0xa2f55a4e.Surface, _0xf73c0002 % 2 == 0 ? 0.95f : 0.80f);
                }

                SpriteRenderer _0x0992fab0 = this._0xeaeeb6d9(this._0xf71b3969, OrderParallax, new Vector2(_0xf1c613bf, this._0x8785f478 * 0.84f), new Vector3(_0x44a7706b == 0 ? -this._0xc6b77c42 : this._0xc6b77c42, _0xc29aa9a3, 0f));
                if (_0x0992fab0 == null)
                {
                    continue;
                }

                _0x0992fab0.color = _0xa2f55a4e.Fade(_0xa2f55a4e.Primary, 0.26f);
                DOTween.Kill(_0x0992fab0, true);
                _0x0992fab0.DOFade(0.55f, 1.7f + _0xf73c0002 * 0.04f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
            }
        }
    }

    private const int OrderBeacon = -6;
}

internal static class _0x0a28df1c
{
    internal static string _0xab7ca6e2(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}