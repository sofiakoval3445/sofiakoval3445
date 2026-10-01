using UnityEngine;

/// Builds the shaft for one attempt from a seed, then PROVES it is climbable
/// before anyone sees it (CLAUDE-unity.md C.11).
///
/// The seed is derived from the attempt counter, so two runs in a row differ in
/// what the player actually reads: which wall each ledge hangs off, how high it
/// sits inside its section, and the speed and phase of every barrier. Only the
/// fallback shaft is written out by hand, and it is reached solely when twenty
/// seeded attempts in a row fail the passability check.
///
/// System.Random on purpose, never UnityEngine.Random: the global generator is
/// shared with everything else in the process, so "the same seed" would stop
/// meaning the same shaft as soon as a second system pulled from it.
public sealed class _0x50191def
{
    public _0xd855cefb _0x6dc706bb(int _0x97038e56)
    {
        for (int _0x68bfdc2a = 0; _0x68bfdc2a < Attempts; _0x68bfdc2a++)
        {
            int _0xf1c9c73b = (_0x97038e56 * 7919) ^ ((_0x68bfdc2a + 1) * 104729);
            _0xd855cefb _0xe10d978d = this._0xdc21d0b3(_0xf1c9c73b);
            if (this._0xa5ac1584(_0xe10d978d))
            {
#if B_LOGS
                Debug.Log(_0xcec4d9d5._0xe712736a(new byte[13] { 139, 179, 188, 185, 189, 178, 141, 240, 163, 181, 181, 180, 237 }, 208) + _0xf1c9c73b + _0xcec4d9d5._0xe712736a(new byte[9] { 54, 119, 98, 98, 115, 123, 102, 98, 43 }, 22) + _0x97038e56 + _0xcec4d9d5._0xe712736a(new byte[6] { 120, 40, 57, 43, 43, 101 }, 88) + _0x68bfdc2a);
#endif
                return _0xe10d978d;
            }
        }

#if B_LOGS
        Debug.Log(_0xcec4d9d5._0xe712736a(new byte[33] { 231, 223, 208, 213, 209, 222, 225, 156, 218, 221, 208, 208, 222, 221, 223, 215, 156, 208, 221, 197, 211, 201, 200, 144, 156, 221, 200, 200, 217, 209, 204, 200, 129 }, 188) + _0x97038e56);
#endif
        return this._0x8ae6cf50();
    }

    private readonly float _0x7a083d09;
    private const float ProbeStep = 0.02f;
    /// The guaranteed shaft: a clean alternating staircase with one unhurried
    /// barrier per guarded band. It exists so a hostile seed can never leave the
    /// player staring at a shaft with no way up, and it is never the first choice.
    private _0xd855cefb _0x8ae6cf50()
    {
        _0xd855cefb _0x1522c28b = new _0xd855cefb(_0x1d9b8829.Sections);
        _0x1522c28b.Seed = 0;
        for (int _0xe9f9bb4a = 0; _0xe9f9bb4a < _0x1522c28b.Sections; _0xe9f9bb4a++)
        {
            _0x1522c28b.LedgeOnLeft[_0xe9f9bb4a] = _0xe9f9bb4a % 2 == 0;
            _0x1522c28b.LedgeOffset[_0xe9f9bb4a] = 0f;
            if (_0x1d9b8829.BarriersAbove(_0xe9f9bb4a) <= 0)
            {
                continue;
            }

            _0xd855cefb._0xdd633498 _0x94e82ca4 = new _0xd855cefb._0xdd633498();
            _0x94e82ca4.Ledge = _0xe9f9bb4a;
            _0x94e82ca4.Rush = false;
            _0x94e82ca4.Height = 0.6f;
            _0x94e82ca4.Speed = _0x1d9b8829.BarrierSlowLow * this._0xc0b041d4 * 2f;
            _0x94e82ca4.Phase = _0xe9f9bb4a * 0.7f;
            _0x1522c28b.Barriers.Add(_0x94e82ca4);
        }

        return _0x1522c28b;
    }

    private const float ProbeSpan = 9f;
    private readonly float _0x625962ec;
    public float _0x77c2a73a(_0xd855cefb._0xdd633498 _0xdbd1c5a3, float _0xbd641c3c)
    {
        if (this._0xc0b041d4 <= 0.0001f)
        {
            return 0f;
        }

        return this._0xc0b041d4 * Mathf.Sin(_0xdbd1c5a3.Speed / this._0xc0b041d4 * _0xbd641c3c + _0xdbd1c5a3.Phase);
    }

    private bool _0x9424a870(_0xd855cefb _0x099950b0, int _0x9ce52064, float _0x21796058, float _0x5defffb9)
    {
        for (int _0x8793af26 = 0; _0x8793af26 < _0x099950b0.Barriers.Count; _0x8793af26++)
        {
            _0xd855cefb._0xdd633498 _0x6aefcf62 = _0x099950b0.Barriers[_0x8793af26];
            if (_0x6aefcf62.Ledge != _0x9ce52064)
            {
                continue;
            }

            if (Mathf.Abs(_0x21796058 - this._0x77c2a73a(_0x6aefcf62, _0x5defffb9)) < this._0x625962ec)
            {
                return false;
            }
        }

        return true;
    }

    /// Every band has to offer one uninterrupted window, at least ClearWindow long,
    /// in which the destination lane is clear of every barrier guarding it. A band
    /// that never opens is a wall, and a shaft with a wall in it is not a level.
    private bool _0xa5ac1584(_0xd855cefb _0x38ce6d3b)
    {
        for (int _0xd9eb2660 = 0; _0xd9eb2660 < _0x38ce6d3b.Sections - 1; _0xd9eb2660++)
        {
            if (_0x1d9b8829.BarriersAbove(_0xd9eb2660) == 0)
            {
                continue;
            }

            float _0x475a7e2c = _0x38ce6d3b.LedgeOnLeft[_0xd9eb2660 + 1] ? -this._0x7a083d09 : this._0x7a083d09;
            float _0xd62ea7ab = 0f;
            float _0x76ef39fd = 0f;
            for (float _0xc70c10ad = 0f; _0xc70c10ad < ProbeSpan; _0xc70c10ad += ProbeStep)
            {
                if (this._0x9424a870(_0x38ce6d3b, _0xd9eb2660, _0x475a7e2c, _0xc70c10ad))
                {
                    _0x76ef39fd += ProbeStep;
                    if (_0x76ef39fd > _0xd62ea7ab)
                    {
                        _0xd62ea7ab = _0x76ef39fd;
                    }
                }
                else
                {
                    _0x76ef39fd = 0f;
                }
            }

            if (_0xd62ea7ab < _0x1d9b8829.ClearWindow)
            {
                return false;
            }
        }

        return true;
    }

    private readonly float _0xc0b041d4;
    private _0xd855cefb _0xdc21d0b3(int _0x7f378b23)
    {
        System.Random _0x5b193b8b = new System.Random(_0x7f378b23);
        _0xd855cefb _0xed017079 = new _0xd855cefb(_0x1d9b8829.Sections);
        _0xed017079.Seed = _0x7f378b23;
        bool _0xa6ac4a59 = _0x5b193b8b.Next(2) == 0;
        for (int _0xf3c7e5cb = 0; _0xf3c7e5cb < _0xed017079.Sections; _0xf3c7e5cb++)
        {
            // Mostly alternating so the climb reads as a zig-zag, with the odd
            // repeat so two runs are not the same staircase in different colours.
            if (_0xf3c7e5cb > 0)
            {
                _0xa6ac4a59 = _0x5b193b8b.Next(100) < 78 ? !_0xa6ac4a59 : _0xa6ac4a59;
            }

            _0xed017079.LedgeOnLeft[_0xf3c7e5cb] = _0xa6ac4a59;
            _0xed017079.LedgeOffset[_0xf3c7e5cb] = _0xf3c7e5cb == 0 ? 0f : (float)(_0x5b193b8b.NextDouble() * 0.20d - 0.10d);
        }

        for (int _0x9627f85c = 0; _0x9627f85c < _0xed017079.Sections; _0x9627f85c++)
        {
            int _0xe0eaa450 = _0x1d9b8829.BarriersAbove(_0x9627f85c);
            bool _0x247ca095 = _0x1d9b8829.RushAbove(_0x9627f85c);
            for (int _0x02499b71 = 0; _0x02499b71 < _0xe0eaa450; _0x02499b71++)
            {
                _0xd855cefb._0xdd633498 _0xbf2a893b = new _0xd855cefb._0xdd633498();
                _0xbf2a893b.Ledge = _0x9627f85c;
                _0xbf2a893b.Rush = _0x247ca095 && _0x02499b71 == _0xe0eaa450 - 1;
                float _0xb88e6585 = _0xbf2a893b.Rush ? _0x1d9b8829.BarrierFastLow : _0x1d9b8829.BarrierSlowLow;
                float _0x75f38aa2 = _0xbf2a893b.Rush ? _0x1d9b8829.BarrierFastHigh : _0x1d9b8829.BarrierSlowHigh;
                float _0x6617d5eb = (float)_0x5b193b8b.NextDouble();
                _0xbf2a893b.Speed = Mathf.Lerp(_0xb88e6585, _0x75f38aa2, _0x6617d5eb) * this._0xc0b041d4 * 2f;
                if (_0xbf2a893b.Rush)
                {
                    _0xbf2a893b.Speed *= _0x1d9b8829.BarrierRushMultiplier;
                }

                // Two barriers in one band are pushed apart in height and in phase,
                // so a band is a pair of moving gates rather than one thick wall.
                float _0x2685c512 = _0xe0eaa450 <= 1 ? 0.5f : _0x02499b71 / (float)(_0xe0eaa450 - 1);
                _0xbf2a893b.Height = Mathf.Lerp(_0x1d9b8829.BarrierBandLow, _0x1d9b8829.BarrierBandHigh, _0x2685c512);
                _0xbf2a893b.Height += (float)(_0x5b193b8b.NextDouble() * 0.06d - 0.03d);
                _0xbf2a893b.Phase = (float)(_0x5b193b8b.NextDouble() * Mathf.PI * 2d) + _0x02499b71 * Mathf.PI;
                _0xed017079.Barriers.Add(_0xbf2a893b);
            }
        }

        return _0xed017079;
    }

    /// <param name = "amplitude">how far the centre of a barrier travels either side of the shaft axis</param>
    /// <param name = "laneInset">distance from the shaft axis to the lane a container climbs in</param>
    /// <param name = "clearance">centre distance at which a barrier counts as touching the container</param>
    public _0x50191def(float _0xb4dc2b4f, float _0xbfe1d4aa, float _0x62c05a16)
    {
        this._0xc0b041d4 = _0xb4dc2b4f;
        this._0x7a083d09 = _0xbfe1d4aa;
        this._0x625962ec = _0x62c05a16;
    }

    private const int Attempts = 20;
}

internal static class _0xcec4d9d5
{
    internal static string _0xe712736a(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}