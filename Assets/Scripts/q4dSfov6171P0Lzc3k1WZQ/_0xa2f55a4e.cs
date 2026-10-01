using UnityEngine;

/// Palette of the lift shaft: deep navy base, electric blue structure, violet
/// barriers, gold for the container and the beacon, red for damage.
///
/// Every colour that ever becomes TEXT here is light on purpose: the shared font
/// material carries one dark outline for the whole app, so a dark face would sink
/// into its own outline and turn into a blob (CLAUDE-unity.md C.10 / C.14).
/// Ink is the OUTLINE colour and must never be passed as a text colour.
public static class _0xa2f55a4e
{
    public static Color Fade(Color _0xbf28cdd2, float _0xe767edd3)
    {
        return new Color(_0xbf28cdd2.r, _0xbf28cdd2.g, _0xbf28cdd2.b, _0xe767edd3);
    }

    public static readonly Color Deep = new Color(0.043f, 0.063f, 0.133f, 1f);
    public static readonly Color Danger = new Color(0.941f, 0.294f, 0.388f, 1f);
    public static readonly Color Surface = new Color(0.102f, 0.137f, 0.271f, 1f);
    public static readonly Color SurfaceAlt = new Color(0.137f, 0.180f, 0.337f, 1f);
    public static readonly Color Violet = new Color(0.545f, 0.271f, 0.827f, 1f);
    public static readonly Color TextMuted = new Color(0.604f, 0.651f, 0.788f, 1f);
    public static readonly Color Gold = new Color(0.949f, 0.769f, 0.310f, 1f);
    public static readonly Color Primary = new Color(0.176f, 0.486f, 1.000f, 1f);
    public static readonly Color Base = new Color(0.063f, 0.086f, 0.173f, 1f);
    public static readonly Color TextMain = new Color(0.961f, 0.969f, 1.000f, 1f);
    public static readonly Color Ink = new Color(0.043f, 0.063f, 0.133f, 1f);
}