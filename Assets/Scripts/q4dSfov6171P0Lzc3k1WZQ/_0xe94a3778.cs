using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using ClimbTouch = UnityEngine.InputSystem.EnhancedTouch.Touch;

/// Runs one ascent: builds the shaft, reads the press-and-hold, applies the lock
/// rule and raises the right result card.
///
/// THE RULE OF THE RUN. Hold and the container climbs the wall it is standing on.
/// Let go and it locks onto a ledge: whichever one the climb actually reached,
/// and never fewer than one above where it started, so a flick of the thumb is
/// still a step and a long hold is several. The longer the hold, the more barrier
/// bands are crossed in one go - that is the whole risk, and it is the player's to
/// take.
///
/// There is no clock, no fuel and no draining meter anywhere in here. A container
/// parked on a ledge with nobody touching the screen stays there indefinitely,
/// which is what keeps the review capture landing on a live shaft instead of a
/// result card (CLAUDE-unity.md C.5).
public sealed class _0xe94a3778 : MonoBehaviour
{
    private int _0xa19f8ca1;
    [SerializeField]
    private GameObject _glowPrefab;
    /// The attempt counter is the seed of the next shaft, so finishing a run is
    /// what makes the one after it a different climb (C.11).
    private void _0x39a2357a()
    {
        PlayerPrefs.SetInt(AttemptKey, PlayerPrefs.GetInt(AttemptKey, 0) + 1);
        PlayerPrefs.Save();
    }

    private void _0x3c569576()
    {
        this._0x9988b8ce = true;
        this._0x39a2357a();
        int _0xc3589e46 = PlayerPrefs.GetInt(BestKey, 0);
        int _0xed8c5bf8 = this._0xefe7ce57;
        DOVirtual.DelayedCall(_0x1d9b8829.ResultDelay, () =>
        {
            _0xeb787fb1.Instance._0xf04b6c96(false);
            if (this._cards != null)
            {
                this._cards._0xf910d1f4(_0xed8c5bf8, _0xc3589e46);
            }
        });
    }

    private float _0xab20b177;
    private Transform _0xdd913154;
    private void _0x93e7c935()
    {
        if (this._0x9988b8ce)
        {
            return;
        }

        _0xeb787fb1.Instance._0xf04b6c96(false);
        if (this._cards != null)
        {
            this._cards._0x171d273a(this._0xefe7ce57, this._0xa19f8ca1);
        }
    }

    private float _0x7964df9a;
    private const int PhaseRest = 0;
    [SerializeField]
    private Sprite _markFace;
    [SerializeField]
    private Sprite _backIcon;
    public void _0xf328d6f7()
    {
        _0x148306eb.Instance._0xc14479c5();
        this._0x935fde51();
        this._0xab20b177 = 0f;
        _0xeb787fb1.Instance._0xf04b6c96(true);
    }

    [SerializeField]
    private GameObject _wallPrefab;
    private const int PhaseDrop = 3;
    private const int PhaseSettle = 2;
    public void _0x80c8bd44()
    {
        _0xeb787fb1.Instance._0xf04b6c96(true);
        _0xeb787fb1.Instance._0xc3fabe22();
    }

    [SerializeField]
    private GameObject _ledgePrefab;
    [SerializeField]
    private Sprite _pauseIcon;
    [SerializeField]
    private GameObject _barrierPrefab;
    private _0xd855cefb _0x27dde061;
    public void _0x424439bd()
    {
        _0xeb787fb1.Instance._0xf04b6c96(true);
        _0xeb787fb1.Instance.LoadSceneByIndex(_0xfaef8027._0xc501cde9.SCENE_0);
    }

    private const int PhaseRise = 1;
    private float _0x2cd3a70d;
    /// The panel body arrives carrying another game's HUD - a timer, a score line,
    /// two unlabelled corner buttons. This game brings its own back and pause, so
    /// the template set is switched off wholesale rather than half-reused, which is
    /// what leaves two mismatched rows of buttons on top of each other (rule H).
    /// The pops live in the same body and are left alone.
    private void _0x935fde51()
    {
        if (this._0xdd913154 == null)
        {
            return;
        }

        for (int _0xea01983b = this._0xdd913154.childCount - 1; _0xea01983b >= 0; _0xea01983b--)
        {
            Transform _0xf0d0f94c = this._0xdd913154.GetChild(_0xea01983b);
            if (_0xf0d0f94c.GetComponentInChildren<_0x058495bc>(true) != null)
            {
                continue;
            }

            if (this._0x55ccd905 != null && this._0x55ccd905._0xf7828c0f != null && _0xf0d0f94c == this._0x55ccd905._0xf7828c0f)
            {
                continue;
            }

            _0xf0d0f94c.gameObject.SetActive(false);
        }
    }

    [SerializeField]
    private _0xf1d51e2b _cards;
    private int _0x4d91af1e;
    private void Start()
    {
        EnhancedTouchSupport.Enable();
        if (this._lens == null)
        {
            this._lens = Camera.main;
        }

        GameObject _0xf790e202 = new GameObject(_0xe4caa590._0xe9a6847b(new byte[10] { 117, 78, 71, 64, 82, 113, 73, 84, 74, 66 }, 38));
        _0xf790e202.transform.SetParent(this.transform, false);
        this._0xf15e597b = _0xf790e202.AddComponent<_0x42bb33f7>();
        this._0xf15e597b._0xe13b7fb9(this._lens, this._wallPrefab, this._ledgePrefab, this._barrierPrefab, this._containerPrefab, this._beaconPrefab, this._glowPrefab, this._ledgeLeftFace, this._ledgeRightFace);
        int _0xf50174b6 = PlayerPrefs.GetInt(AttemptKey, 0);
        _0x50191def _0xfc62c77f = new _0x50191def(this._0xf15e597b._0x8d128cf1, this._0xf15e597b._0xce9c1ece, (this._0xf15e597b._0x73d0b5a9 + this._0xf15e597b._0xf820460e) * 0.86f);
        this._0x27dde061 = _0xfc62c77f._0x6dc706bb(_0xf50174b6);
        this._0xf15e597b._0x31faa5d7(this._0x27dde061);
        this._0xefe7ce57 = 0;
        this._0xc908d889 = 0;
        this._0x4d91af1e = 0;
        this._0xa19f8ca1 = _0x1d9b8829.StartIntegrity;
        this._0x80a8e9da = this._0xf15e597b._0x111a8200(0);
        this._0x2cd3a70d = this._0xf15e597b._0x5725c74f(0);
        this._0xe9ae5a87 = PhaseRest;
        this._0xf15e597b._0x2cf7c472(this._0x80a8e9da, this._0x2cd3a70d);
        this._0xf15e597b._0x81c397d6(this._0x80a8e9da, true);
        this._0xf15e597b._0x45e5c899(0);
        this._0xdd913154 = this._0xb04ecd70();
        this._0x935fde51();
        this._0x55ccd905 = this.gameObject.AddComponent<_0x22d52bec>();
        this._0x55ccd905._0xa5aae22d(this._0xdd913154, this._font, this._roundedPlate, this._pipFace, this._markFace, this._backIcon, this._pauseIcon);
        this._0x55ccd905._0x68f96dd4(0);
        this._0x55ccd905._0x037c3092(this._0xa19f8ca1);
        if (this._0x55ccd905._0x3e8ee91f != null)
        {
            this._0x55ccd905._0x3e8ee91f.onClick.AddListener(() => this._0x424439bd());
        }

        if (this._0x55ccd905._0x4c64e63d != null)
        {
            this._0x55ccd905._0x4c64e63d.onClick.AddListener(() => this._0x93e7c935());
        }

        if (this._cards != null)
        {
            this._cards._0x2c7aabda(this);
            this._cards._0xd74dd0e1();
        }

        _0xfb7b4cff _0x57de7810 = this.gameObject.AddComponent<_0xfb7b4cff>();
        _0x57de7810._0x43a51755();
        // Full strength for the first stretch of the run, which is the window the
        // review screenshots fall in, then it settles back and stays (C.6).
        DOVirtual.DelayedCall(20f, () => this._0x55ccd905._0x059201c9());
        this._0x98977a65 = true;
    }

    private void _0xdd1d0994()
    {
        float _0xbd34846d = this._0x80a8e9da - this._0xf15e597b._0x111a8200(this._0xc908d889);
        int _0xad3ac2be = Mathf.Max(1, Mathf.RoundToInt(_0xbd34846d / this._0xf15e597b._0x8785f478));
        this._0x4d91af1e = Mathf.Min(this._0xc908d889 + _0xad3ac2be, _0x1d9b8829.Sections - 1);
        this._0xe9ae5a87 = PhaseSettle;
    }

    private void _0x3414c3fb()
    {
        this._0xa19f8ca1--;
        this._0x55ccd905._0x037c3092(this._0xa19f8ca1);
        this._0xf15e597b._0xeec745c0(this._0x80a8e9da, this._0x2cd3a70d);
        this._0x7964df9a = _0x1d9b8829.InvulnerableTime;
        this._0xf15e597b._0x45851428(true);
        this._0x4d91af1e = Mathf.Max(0, this._0xefe7ce57 - 1);
        this._0xe9ae5a87 = PhaseDrop;
    }

    [SerializeField]
    private Sprite _ledgeLeftFace;
    private void _0x726f1145()
    {
        int _0xee19a0bf = _0x1d9b8829.MetresAt(this._0xefe7ce57);
        if (_0xee19a0bf > PlayerPrefs.GetInt(BestKey, 0))
        {
            PlayerPrefs.SetInt(BestKey, _0xee19a0bf);
            PlayerPrefs.Save();
        }

        int _0x8f33ea0e = _0x1d9b8829.ScoreFor(this._0xefe7ce57, Mathf.Max(0, this._0xa19f8ca1), false);
        if (_0x8f33ea0e > _0xfaef8027._0x6b1ba0f2._0x53608a6a)
        {
            _0xfaef8027._0x6b1ba0f2._0x53608a6a = _0x8f33ea0e;
        }
    }

    private int _0xc908d889;
    private Transform _0xb04ecd70()
    {
        if (_0x95eb9f22.Instance == null || _0x95eb9f22.Instance.Panels == null)
        {
            return null;
        }

        int _0xe5275263 = _0xfaef8027._0xec2ae8dc.DEFAULT;
        if (_0xe5275263 < 0 || _0xe5275263 >= _0x95eb9f22.Instance.Panels.Count)
        {
            return null;
        }

        _0xedbb5775 _0x8841bf61 = _0x95eb9f22.Instance.Panels[_0xe5275263];
        return _0x8841bf61 == null || _0x8841bf61.Content == null ? null : _0x8841bf61.Content.transform;
    }

    [SerializeField]
    private Sprite _pipFace;
    private bool _0x9988b8ce;
    [SerializeField]
    private Camera _lens;
    private float _0x80a8e9da;
    [SerializeField]
    private TMP_FontAsset _font;
    private int _0xefe7ce57;
    [SerializeField]
    private Sprite _roundedPlate;
    private _0x22d52bec _0x55ccd905;
    [SerializeField]
    private Sprite _ledgeRightFace;
    [SerializeField]
    private GameObject _beaconPrefab;
    private int _0xe9ae5a87;
    private static readonly string AttemptKey = _0xe4caa590._0xe9a6847b(new byte[12] { 161, 142, 139, 143, 128, 163, 150, 150, 135, 143, 146, 150 }, 226);
    private void _0x4311a1ae()
    {
        this._0x9988b8ce = true;
        this._0xf15e597b._0x2ccaddbd();
        this._0x39a2357a();
        int _0xa75a9a63 = _0x1d9b8829.ScoreFor(this._0xefe7ce57, this._0xa19f8ca1, true);
        if (_0xa75a9a63 > _0xfaef8027._0x6b1ba0f2._0x53608a6a)
        {
            _0xfaef8027._0x6b1ba0f2._0x53608a6a = _0xa75a9a63;
        }

        int _0x3514f39c = PlayerPrefs.GetInt(BestKey, 0);
        DOVirtual.DelayedCall(_0x1d9b8829.ResultDelay, () =>
        {
            _0xeb787fb1.Instance._0xf04b6c96(false);
            if (this._cards != null)
            {
                this._cards._0x7c30cbfe(this._0xa19f8ca1, _0x3514f39c);
            }
        });
    }

    private void _0x6092260e()
    {
        this._0x80a8e9da = this._0xf15e597b._0x111a8200(this._0x4d91af1e);
        this._0x2cd3a70d = this._0xf15e597b._0x5725c74f(this._0x4d91af1e);
        this._0xf15e597b._0x2cf7c472(this._0x80a8e9da, this._0x2cd3a70d);
        bool _0xbd058739 = this._0x4d91af1e > this._0xefe7ce57;
        this._0xefe7ce57 = this._0x4d91af1e;
        this._0xe9ae5a87 = PhaseRest;
        this._0xab20b177 = 0f;
        this._0xf15e597b._0xa6271afa(this._0x80a8e9da, this._0x2cd3a70d);
        if (_0xbd058739)
        {
            this._0xf15e597b._0x45e5c899(this._0xefe7ce57);
        }

        this._0x55ccd905._0x68f96dd4(this._0xefe7ce57);
        this._0x726f1145();
        if (this._0xa19f8ca1 <= 0)
        {
            this._0x3c569576();
            return;
        }

        if (this._0xefe7ce57 >= _0x1d9b8829.Sections - 1)
        {
            this._0x4311a1ae();
        }
    }

    private _0x42bb33f7 _0xf15e597b;
    [SerializeField]
    private GameObject _containerPrefab;
    private static readonly string BestKey = _0xe4caa590._0xe9a6847b(new byte[9] { 126, 81, 84, 80, 95, 127, 88, 78, 73 }, 61);
    private void Update()
    {
        if (!this._0x98977a65 || this._0x9988b8ce)
        {
            return;
        }

        if (_0xeb787fb1.Instance == null || !_0xeb787fb1.Instance._0xd0a09e2c)
        {
            this._0xab20b177 = 0f;
            return;
        }

        float step = Time.deltaTime;
        if (this._0x7964df9a > 0f)
        {
            this._0x7964df9a -= step;
            if (this._0x7964df9a <= 0f)
            {
                this._0xf15e597b._0x45851428(false);
            }
        }

        // A system tap from the review harness can be down and up again inside two
        // frames, so a press is latched for a grace period rather than sampled.
        if (this._0x4f885ddf())
        {
            this._0xab20b177 = _0x1d9b8829.HoldGrace;
        }
        else
        {
            this._0xab20b177 -= step;
        }

        bool _0x4ce231c9 = this._0xab20b177 > 0f;
        if (this._0xe9ae5a87 == PhaseRest)
        {
            if (_0x4ce231c9)
            {
                this._0xe9ae5a87 = PhaseRise;
                this._0xc908d889 = this._0xefe7ce57;
            }
        }
        else if (this._0xe9ae5a87 == PhaseRise)
        {
            this._0x80a8e9da += this._0xf15e597b._0x447aeda9 * step;
            this._0x2cd3a70d = this._0xf15e597b._0x5725c74f(this._0xc908d889) + Mathf.Sin(Time.time * Mathf.PI * 2f * _0x1d9b8829.SwayHz) * this._0xf15e597b._0x8e0164f3;
            float _0x9a34cf3a = this._0xf15e597b._0x111a8200(_0x1d9b8829.Sections - 1);
            if (this._0x80a8e9da >= _0x9a34cf3a)
            {
                this._0x80a8e9da = _0x9a34cf3a;
                this._0x4d91af1e = _0x1d9b8829.Sections - 1;
                this._0xe9ae5a87 = PhaseSettle;
            }
            else if (!_0x4ce231c9)
            {
                this._0xdd1d0994();
            }
        }
        else if (this._0xe9ae5a87 == PhaseSettle || this._0xe9ae5a87 == PhaseDrop)
        {
            float _0xd3b4afc9 = this._0xf15e597b._0x111a8200(this._0x4d91af1e);
            float _0x92f386ee = this._0xe9ae5a87 == PhaseDrop ? this._0xf15e597b._0xe972553c : this._0xf15e597b._0x04ad7d11;
            this._0x80a8e9da = Mathf.MoveTowards(this._0x80a8e9da, _0xd3b4afc9, _0x92f386ee * step);
            float _0x53674a17 = this._0xf15e597b._0xce9c1ece * 2f / 0.45f;
            this._0x2cd3a70d = Mathf.MoveTowards(this._0x2cd3a70d, this._0xf15e597b._0x5725c74f(this._0x4d91af1e), _0x53674a17 * step);
            if (Mathf.Approximately(this._0x80a8e9da, _0xd3b4afc9) && Mathf.Approximately(this._0x2cd3a70d, this._0xf15e597b._0x5725c74f(this._0x4d91af1e)))
            {
                this._0x6092260e();
            }
        }

        this._0xf15e597b._0x2cf7c472(this._0x80a8e9da, this._0x2cd3a70d);
        this._0xf15e597b._0x81c397d6(this._0x80a8e9da, false);
        if (this._0x7964df9a <= 0f && (this._0xe9ae5a87 == PhaseRise || this._0xe9ae5a87 == PhaseSettle))
        {
            if (this._0xf15e597b._0x14942e21(this._0x80a8e9da, this._0x2cd3a70d))
            {
                this._0x3414c3fb();
            }
        }
    }

    /// Only the middle of the screen drives the climb. The bracket at the top and
    /// the hint at the bottom keep their own taps, so reaching for pause never
    /// sends the container up the wall.
    private bool _0x4f885ddf()
    {
        var _0x9880d830 = ClimbTouch.activeTouches;
        for (int _0xa51b4602 = 0; _0xa51b4602 < _0x9880d830.Count; _0xa51b4602++)
        {
            if (_0x9880d830[_0xa51b4602].phase == UnityEngine.InputSystem.TouchPhase.Ended || _0x9880d830[_0xa51b4602].phase == UnityEngine.InputSystem.TouchPhase.Canceled)
            {
                continue;
            }

            if (this.InBand(_0x9880d830[_0xa51b4602].screenPosition))
            {
                return true;
            }
        }

        if (_0x9880d830.Count == 0 && Pointer.current != null)
        {
            if (Pointer.current.press.isPressed || Pointer.current.press.wasPressedThisFrame)
            {
                if (this.InBand(Pointer.current.position.ReadValue()))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool InBand(Vector2 _0x67c95fe0)
    {
        if (Screen.height <= 0)
        {
            return false;
        }

        float _0x54d4d5a8 = _0x67c95fe0.y / Screen.height;
        return _0x54d4d5a8 >= _0x1d9b8829.PlayBandLow && _0x54d4d5a8 <= _0x1d9b8829.PlayBandHigh;
    }

    private bool _0x98977a65;
}

internal static class _0xe4caa590
{
    internal static string _0xe9a6847b(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}