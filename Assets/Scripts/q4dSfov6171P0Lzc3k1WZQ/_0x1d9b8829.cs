using UnityEngine;

/// Tuning table for one ascent.
///
/// Nothing in here is a world size: every spatial number is a FRACTION of the
/// camera half-extents and is turned into units at runtime (CLAUDE-unity.md C.0),
/// so the shaft is the same shape on a 19.5:9 phone and on the 20:9 emulator.
///
/// There is no clock and no draining meter anywhere in the run. The container
/// parked on a ledge with no input stays there for ever, which is what keeps the
/// review capture landing on live gameplay instead of a result card (C.5).
public static class _0x1d9b8829
{
    public const float ClearWindow = 0.55f; // seconds of free path the generator demands
    public const float LedgeFraction = 0.48f; // of shaft half width
    // --- barrier sweep -------------------------------------------------------
    public const float BarrierSlowLow = 0.40f; // of halfWidth per second
    public const float BarrierFastLow = 0.56f;
    public const float TweenFast = 0.18f;
    /// How many barriers guard the band above ledge <paramref name = "ledge"/>.
    /// The first two sections are deliberately clear: the climb has to be legible
    /// before it is dangerous, and the first screenshots of the run show a board,
    /// not a result card.
    public static int BarriersAbove(int _0x80de916e)
    {
        if (_0x80de916e < 2)
        {
            return 0;
        }

        if (_0x80de916e < 6)
        {
            return 1;
        }

        return 2;
    }

    public const float BarrierSlowHigh = 0.56f;
    public const float BarrierBandHigh = 0.75f;
    public const float RibThickFraction = 0.045f; // of halfWidth
    // --- geometry, all relative to the camera -------------------------------
    public const float SectionFraction = 0.40f; // of halfHeight -> 2.0 units
    public const float LockFlash = 0.35f;
    public const int StartIntegrity = 3;
    public const float BarrierBandLow = 0.45f; // of section height above its ledge
    /// The six blocks of three sections the route sheet lists.
    public static readonly string[] BlockNames =
    {
        _0x490768fd._0x3127d5e1(new byte[11] { 99, 96, 120, 106, 125, 15, 124, 103, 110, 105, 123 }, 47),
        _0x490768fd._0x3127d5e1(new byte[10] { 61, 63, 44, 57, 49, 94, 44, 55, 48, 57 }, 126),
        _0x490768fd._0x3127d5e1(new byte[9] { 230, 234, 236, 233, 133, 225, 224, 230, 238 }, 165),
        _0x490768fd._0x3127d5e1(new byte[9] { 225, 230, 253, 224, 255, 146, 245, 243, 226 }, 178),
        _0x490768fd._0x3127d5e1(new byte[10] { 225, 228, 228, 241, 230, 148, 249, 245, 231, 224 }, 180),
        _0x490768fd._0x3127d5e1(new byte[11] { 48, 55, 51, 49, 61, 60, 82, 38, 59, 55, 32 }, 114)
    };
    public static int MetresAt(int _0xb870e6ee)
    {
        return _0xb870e6ee * MetresPerSection;
    }

    public const float WallFraction = 0.925f; // of halfWidth  -> wall centre
    // --- motion --------------------------------------------------------------
    public const float RiseFraction = 0.52f; // of halfHeight per second -> 2.6 u/s
    public const float ContainerFraction = 0.26f; // of section height
    public const int Sections = 18; // ledge 0 .. ledge 17
    public const float WallThickFraction = 0.20f; // of halfWidth
    public const int MetresPerSection = 2;
    public const float TweenBase = 0.28f;
    public const float SettleFraction = 0.80f; // of halfHeight per second
    public static int BarriersInBlock(int _0x40604021)
    {
        int _0x9d8544a4 = 0;
        for (int _0x193c398e = _0x40604021 * 3; _0x193c398e < _0x40604021 * 3 + 3 && _0x193c398e < Sections; _0x193c398e++)
        {
            _0x9d8544a4 += BarriersAbove(_0x193c398e);
        }

        return _0x9d8544a4;
    }

    public const float AnchorFraction = -0.24f; // of halfHeight, where the container rides
    public const float BarrierFastHigh = 0.76f;
    public const float ResultDelay = 0.85f;
    public const float BarrierFraction = 0.88f; // of shaft half width
    public static bool RushAbove(int _0xc2937e3f)
    {
        return _0xc2937e3f >= 12;
    }

    public static int ScoreFor(int _0x4301ccd2, int _0x87d52a22, bool _0x2dc74064)
    {
        return _0x4301ccd2 * 60 + _0x87d52a22 * 220 + (_0x2dc74064 ? 600 : 0);
    }

    public const float DropFraction = 0.62f; // of halfHeight per second
    public const float HoldGrace = 0.10f; // a 50 ms system tap still reads as a press
    public const float InvulnerableTime = 1.2f;
    public const float FollowSmooth = 0.18f; // camera rig SmoothDamp time
    public const float ShaftFraction = 0.80f; // of halfWidth  -> inner half width
    public const float SwayHz = 1.6f;
    public const float SwayFraction = 0.018f; // of halfWidth, lateral sway while rising
    // Taps are only read inside this vertical band so the HUD bracket at the top
    // and the gesture hint at the bottom never double as a climb control.
    public const float PlayBandLow = 0.18f;
    public const float BeaconFraction = 0.60f; // of section height
    public const float PlayBandHigh = 0.82f;
    public const float BarrierRushMultiplier = 1.35f;
}

internal static class _0x490768fd
{
    internal static string _0x3127d5e1(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}