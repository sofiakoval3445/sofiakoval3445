using System.Collections.Generic;

/// One generated ascent: which wall every ledge clings to, how high it sits inside
/// its section, and the barriers that sweep the gaps between them.
///
/// Plain data only. It is produced by ShaftLayoutGenerator from a seed and read by
/// ShaftStageView, so nothing in a run is hard-coded except the fallback the
/// generator falls back to when a seed refuses to produce a passable shaft.
public sealed class _0xd855cefb
{
    public bool[] LedgeOnLeft;
    public float[] LedgeOffset; // fraction of a section, jitter around the boundary
    public _0xd855cefb(int _0xe78441ed)
    {
        this.Sections = _0xe78441ed;
        this.LedgeOnLeft = new bool[_0xe78441ed];
        this.LedgeOffset = new float[_0xe78441ed];
    }

    public sealed class _0xdd633498
    {
        public int Ledge; // the band ABOVE this ledge
        public float Height; // fraction of one section height, measured from that ledge
        public float Speed; // world units per second at the middle of the sweep
        public float Phase; // radians
        public bool Rush; // the accelerated one of the late sections
    }

    public readonly List<_0xdd633498> Barriers = new List<_0xdd633498>();
    public int Sections;
    public int Seed;
    public List<_0xdd633498> _0xee5a79ec(int _0xf0b7e852)
    {
        List<_0xdd633498> _0x0ec2de0e = new List<_0xdd633498>();
        for (int _0x81ec5247 = 0; _0x81ec5247 < this.Barriers.Count; _0x81ec5247++)
        {
            if (this.Barriers[_0x81ec5247].Ledge == _0xf0b7e852)
            {
                _0x0ec2de0e.Add(this.Barriers[_0x81ec5247]);
            }
        }

        return _0x0ec2de0e;
    }
}