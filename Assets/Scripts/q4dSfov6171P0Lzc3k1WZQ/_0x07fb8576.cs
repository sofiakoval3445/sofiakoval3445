using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// Dresses the menu scene: the splash mark, the shaft preview, the route sheet,
/// the how-to sheet and the face of the template's own scene-loading button.
///
/// Nothing on screen names the app. The branding is the abstract containment mark
/// and the palette, and every caption is functional (hard rule 1).
///
/// The template's menu carries no coin container, so the best climb is read
/// straight out of the shared player store and drawn on a plate of its own; the
/// run director writes the same value back, so the two scenes always agree.
public sealed class _0x07fb8576 : MonoBehaviour
{
    [SerializeField]
    private Sprite _ledgeLeftFace;
    private void _0x9dbb5ea3(RectTransform _0xf4a55b33, int _0xb4d1d452, Sprite _0x544de3ce, Color _0xb857c2e8, string _0x67536d2b)
    {
        float _0x57eaca7f = -(280f + _0xb4d1d452 * 320f);
        RectTransform _0x32fa2606 = _0xb1db93c9.Card(_0xf4a55b33, _0xa9a0ddc3._0x9d681c7a(new byte[8] { 177, 144, 145, 138, 151, 183, 138, 146 }, 229) + _0xb4d1d452, this._roundedPlate, new Vector2(0.5f, 1f), new Vector2(0f, _0x57eaca7f), new Vector2(940f, 280f), _0xa2f55a4e.Base, _0xa2f55a4e.Fade(_0xa2f55a4e.Primary, 0.7f), 1.5f, 3f);
        _0xb1db93c9.Picture(_0x32fa2606, _0xa9a0ddc3._0x9d681c7a(new byte[9] { 123, 90, 91, 64, 93, 105, 78, 76, 74 }, 47) + _0xb4d1d452, _0x544de3ce, new Vector2(0f, 0.5f), new Vector2(120f, 0f), new Vector2(150f, 150f), _0xb857c2e8);
        _0xb1db93c9.Label(_0x32fa2606, _0xa9a0ddc3._0x9d681c7a(new byte[9] { 154, 187, 186, 161, 188, 141, 161, 190, 183 }, 206) + _0xb4d1d452, this._font, _0x67536d2b, new Vector2(1f, 0.5f), new Vector2(-330f, 0f), new Vector2(600f, 160f), 38f, _0xa2f55a4e.TextMain, TextAlignmentOptions.Left);
    }

    private static readonly string BestKey = _0xa9a0ddc3._0x9d681c7a(new byte[9] { 132, 171, 174, 170, 165, 133, 162, 180, 179 }, 199);
    [SerializeField]
    private Sprite _roundedPlate;
    private RectTransform _0x3486b649;
    private const float TextWidth = 700f;
    [SerializeField]
    private Sprite _containerFace;
    private void _0x9698975f()
    {
        this._0x977dc050(this._0x3486b649);
    }

    [SerializeField]
    private Sprite _mark;
    /// A short loop of the real thing: rise, lock, rise, lock, with a barrier
    /// sweeping the gap in between.
    private void BuildPreview(Transform _0x47322f29)
    {
        RectTransform _0xc268d370 = _0xb1db93c9.Card(_0x47322f29, _0xa9a0ddc3._0x9d681c7a(new byte[12] { 241, 211, 196, 215, 200, 196, 214, 242, 201, 192, 199, 213 }, 161), this._roundedPlate, new Vector2(0.5f, 0.565f), Vector2.zero, new Vector2(620f, 640f), _0xa2f55a4e.Fade(_0xa2f55a4e.Deep, 0.88f), _0xa2f55a4e.Fade(_0xa2f55a4e.Primary, 0.75f), 1.3f, 4f);
        _0xb1db93c9.Picture(_0xc268d370, _0xa9a0ddc3._0x9d681c7a(new byte[13] { 181, 151, 128, 147, 140, 128, 146, 167, 128, 132, 134, 138, 139 }, 229), this._beaconFace, new Vector2(0.5f, 1f), new Vector2(0f, -78f), new Vector2(92f, 138f), _0xa2f55a4e.Gold);
        _0xb1db93c9.Picture(_0xc268d370, _0xa9a0ddc3._0x9d681c7a(new byte[15] { 92, 126, 105, 122, 101, 105, 123, 64, 105, 104, 107, 105, 88, 99, 124 }, 12), this._ledgeLeftFace, new Vector2(0.5f, 1f), new Vector2(-160f, -196f), new Vector2(180f, 90f), _0xa2f55a4e.TextMain);
        _0xb1db93c9.Picture(_0xc268d370, _0xa9a0ddc3._0x9d681c7a(new byte[15] { 222, 252, 235, 248, 231, 235, 249, 194, 235, 234, 233, 235, 195, 231, 234 }, 142), this._ledgeRightFace, new Vector2(0.5f, 1f), new Vector2(160f, -336f), new Vector2(180f, 90f), _0xa2f55a4e.TextMain);
        _0xb1db93c9.Picture(_0xc268d370, _0xa9a0ddc3._0x9d681c7a(new byte[15] { 199, 229, 242, 225, 254, 242, 224, 219, 242, 243, 240, 242, 219, 248, 224 }, 151), this._ledgeLeftFace, new Vector2(0.5f, 1f), new Vector2(-160f, -476f), new Vector2(180f, 90f), _0xa2f55a4e.TextMain);
        Image _0x77b06a5e = _0xb1db93c9.Picture(_0xc268d370, _0xa9a0ddc3._0x9d681c7a(new byte[14] { 122, 88, 79, 92, 67, 79, 93, 104, 75, 88, 88, 67, 79, 88 }, 42), this._barrierFace, new Vector2(0.5f, 1f), new Vector2(0f, -268f), new Vector2(300f, 90f), _0xa2f55a4e.Fade(_0xa2f55a4e.Violet, 0.95f));
        _0x77b06a5e.rectTransform.DOAnchorPosX(130f, 1.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        Image _0x04f000c7 = _0xb1db93c9.Picture(_0xc268d370, _0xa9a0ddc3._0x9d681c7a(new byte[11] { 210, 240, 231, 244, 235, 231, 245, 193, 237, 240, 231 }, 130), this._containerFace, new Vector2(0.5f, 1f), new Vector2(-160f, -440f), new Vector2(96f, 96f), Color.white);
        RectTransform _0x666f9d42 = _0x04f000c7.rectTransform;
        Sequence _0xd4d297cc = DOTween.Sequence();
        _0xd4d297cc.Append(_0x666f9d42.DOAnchorPosY(-370f, 0.9f).SetEase(Ease.OutSine));
        _0xd4d297cc.Append(_0x666f9d42.DOAnchorPos(new Vector2(160f, -300f), 0.4f).SetEase(Ease.OutBack));
        _0xd4d297cc.AppendInterval(0.6f);
        _0xd4d297cc.Append(_0x666f9d42.DOAnchorPosY(-230f, 0.9f).SetEase(Ease.OutSine));
        _0xd4d297cc.Append(_0x666f9d42.DOAnchorPos(new Vector2(-160f, -160f), 0.4f).SetEase(Ease.OutBack));
        _0xd4d297cc.AppendInterval(0.8f);
        _0xd4d297cc.SetLoops(-1, LoopType.Restart);
    }

    private void _0x626906ff()
    {
        if (this._0x5789a19c != null)
        {
            this._0x5789a19c.gameObject.SetActive(false);
        }
    }

    private void _0x8ac8f2c4()
    {
        Transform _0x37897050 = this._0x76358957(_0xfaef8027._0xec2ae8dc.DEFAULT);
        if (_0x37897050 == null)
        {
            return;
        }

        RectTransform _0x072937b2 = _0xb1db93c9.Sheet(_0x37897050, _0xa9a0ddc3._0x9d681c7a(new byte[9] { 18, 58, 49, 42, 27, 45, 58, 44, 44 }, 95));
        _0x072937b2.SetAsFirstSibling();
        int _0x7fd5c775 = PlayerPrefs.GetInt(BestKey, 0);
        int _0x76237c22 = PlayerPrefs.GetInt(AttemptKey, 0);
        // --- status row --------------------------------------------------------
        RectTransform _0x6c425401 = _0xb1db93c9.Card(_0x072937b2, _0xa9a0ddc3._0x9d681c7a(new byte[9] { 23, 48, 38, 33, 5, 57, 52, 33, 48 }, 85), this._roundedPlate, new Vector2(0.5f, 0.925f), new Vector2(-280f, 0f), new Vector2(460f, 136f), _0xa2f55a4e.Fade(_0xa2f55a4e.Surface, 0.94f), _0xa2f55a4e.Fade(_0xa2f55a4e.Primary, 0.85f), 1.3f, 4f);
        _0xb1db93c9.Label(_0x6c425401, _0xa9a0ddc3._0x9d681c7a(new byte[7] { 196, 227, 245, 242, 197, 231, 246 }, 134), this._font, _0xa9a0ddc3._0x9d681c7a(new byte[11] { 57, 62, 40, 47, 91, 51, 62, 50, 60, 51, 47 }, 123), new Vector2(0.5f, 1f), new Vector2(0f, -36f), new Vector2(400f, 42f), 32f, _0xa2f55a4e.TextMuted, TextAlignmentOptions.Center);
        _0xb1db93c9.Label(_0x6c425401, _0xa9a0ddc3._0x9d681c7a(new byte[9] { 211, 244, 226, 229, 199, 240, 253, 228, 244 }, 145), this._font, _0x7fd5c775.ToString(_0xa9a0ddc3._0x9d681c7a(new byte[2] { 29, 29 }, 45)) + _0xa9a0ddc3._0x9d681c7a(new byte[2] { 104, 5 }, 72), new Vector2(0.5f, 0f), new Vector2(0f, 42f), new Vector2(400f, 66f), 52f, _0xa2f55a4e.Gold, TextAlignmentOptions.Center);
        RectTransform _0xb56b90ab = _0xb1db93c9.Card(_0x072937b2, _0xa9a0ddc3._0x9d681c7a(new byte[8] { 45, 10, 17, 47, 19, 30, 11, 26 }, 127), this._roundedPlate, new Vector2(0.5f, 0.925f), new Vector2(280f, 0f), new Vector2(460f, 136f), _0xa2f55a4e.Fade(_0xa2f55a4e.Surface, 0.94f), _0xa2f55a4e.Fade(_0xa2f55a4e.Violet, 0.85f), 1.3f, 4f);
        _0xb1db93c9.Label(_0xb56b90ab, _0xa9a0ddc3._0x9d681c7a(new byte[6] { 138, 173, 182, 155, 185, 168 }, 216), this._font, _0xa9a0ddc3._0x9d681c7a(new byte[7] { 235, 249, 233, 239, 228, 254, 249 }, 170), new Vector2(0.5f, 1f), new Vector2(0f, -36f), new Vector2(400f, 42f), 32f, _0xa2f55a4e.TextMuted, TextAlignmentOptions.Center);
        _0xb1db93c9.Label(_0xb56b90ab, _0xa9a0ddc3._0x9d681c7a(new byte[8] { 113, 86, 77, 117, 66, 79, 86, 70 }, 35), this._font, _0x76237c22.ToString(_0xa9a0ddc3._0x9d681c7a(new byte[2] { 205, 205 }, 253)), new Vector2(0.5f, 0f), new Vector2(0f, 42f), new Vector2(400f, 66f), 52f, _0xa2f55a4e.TextMain, TextAlignmentOptions.Center);
        // --- abstract mark -----------------------------------------------------
        Image _0x84aae016 = _0xb1db93c9.Picture(_0x072937b2, _0xa9a0ddc3._0x9d681c7a(new byte[8] { 121, 81, 90, 65, 121, 85, 70, 95 }, 52), this._mark, new Vector2(0.5f, 0.815f), Vector2.zero, new Vector2(280f, 280f), _0xa2f55a4e.TextMain);
        _0x84aae016.transform.DORotate(new Vector3(0f, 0f, 4f), 2.6f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        // --- looping shaft preview --------------------------------------------
        this.BuildPreview(_0x072937b2);
        // --- objective, two lines, broken by hand ------------------------------
        _0xb1db93c9.Label(_0x072937b2, _0xa9a0ddc3._0x9d681c7a(new byte[13] { 135, 175, 164, 191, 133, 168, 160, 175, 169, 190, 163, 188, 175 }, 202), this._font, _0xa9a0ddc3._0x9d681c7a(new byte[31] { 128, 151, 147, 145, 154, 242, 134, 154, 151, 242, 144, 151, 147, 145, 157, 156, 216, 227, 234, 242, 129, 151, 145, 134, 155, 157, 156, 129, 242, 135, 130 }, 210), new Vector2(0.5f, 0.395f), Vector2.zero, new Vector2(1000f, 150f), 46f, _0xa2f55a4e.TextMuted, TextAlignmentOptions.Center);
        // --- PLAY face over the template's scene-loading button ----------------
        this._0x3ddd0844();
        // --- secondary actions --------------------------------------------------
        RectTransform _0x9cbb8b3d = _0xb1db93c9.Card(_0x072937b2, _0xa9a0ddc3._0x9d681c7a(new byte[12] { 90, 103, 125, 124, 109, 123, 74, 125, 124, 124, 103, 102 }, 8), this._roundedPlate, new Vector2(0.5f, 0.165f), Vector2.zero, new Vector2(620f, 124f), _0xa2f55a4e.Base, _0xa2f55a4e.Fade(_0xa2f55a4e.Primary, 0.9f), 1.5f, 3f);
        _0xb1db93c9.Label(_0x9cbb8b3d, _0xa9a0ddc3._0x9d681c7a(new byte[13] { 88, 101, 127, 126, 111, 121, 73, 107, 122, 126, 99, 101, 100 }, 10), this._font, _0xa9a0ddc3._0x9d681c7a(new byte[6] { 190, 163, 185, 184, 169, 191 }, 236), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(560f, 62f), 46f, _0xa2f55a4e.TextMain, TextAlignmentOptions.Center);
        Button _0xfac1e26e = _0xb1db93c9.Pressable(_0x9cbb8b3d, Color.white, _0xa2f55a4e.Primary);
        _0xfac1e26e.onClick.AddListener(() => this._0x6899ea0f());
        RectTransform _0x8740a561 = _0xb1db93c9.Card(_0x072937b2, _0xa9a0ddc3._0x9d681c7a(new byte[11] { 253, 220, 221, 198, 219, 235, 220, 221, 221, 198, 199 }, 169), this._roundedPlate, new Vector2(0.5f, 0.085f), Vector2.zero, new Vector2(620f, 118f), _0xa2f55a4e.Base, _0xa2f55a4e.Fade(_0xa2f55a4e.Violet, 0.9f), 1.5f, 3f);
        _0xb1db93c9.Label(_0x8740a561, _0xa9a0ddc3._0x9d681c7a(new byte[12] { 193, 224, 225, 250, 231, 214, 244, 229, 225, 252, 250, 251 }, 149), this._font, _0xa9a0ddc3._0x9d681c7a(new byte[11] { 232, 239, 247, 128, 244, 239, 128, 240, 236, 225, 249 }, 160), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(560f, 58f), 42f, _0xa2f55a4e.TextMain, TextAlignmentOptions.Center);
        Button _0x515cb1d0 = _0xb1db93c9.Pressable(_0x8740a561, Color.white, _0xa2f55a4e.Violet);
        _0x515cb1d0.onClick.AddListener(() => this._0x9698975f());
        _0xb1db93c9.Label(_0x072937b2, _0xa9a0ddc3._0x9d681c7a(new byte[11] { 35, 11, 0, 27, 41, 11, 29, 26, 27, 28, 11 }, 110), this._font, _0xa9a0ddc3._0x9d681c7a(new byte[30] { 18, 21, 22, 30, 122, 14, 21, 122, 8, 19, 9, 31, 122, 119, 122, 8, 31, 22, 31, 27, 9, 31, 122, 14, 21, 122, 22, 21, 25, 17 }, 90), new Vector2(0.5f, 0.032f), Vector2.zero, new Vector2(1000f, 48f), 32f, _0xa2f55a4e.TextMuted, TextAlignmentOptions.Center);
        // The two sheets hang off the panel body AFTER the play button, so they draw
        // over it and swallow its taps while they are open (rule C.13).
        this._0xb1ca54fb(_0x37897050, _0x7fd5c775);
        this._0xd5872387(_0x37897050);
        this._0xc3a5c453(new Transform[] { _0x84aae016.transform, _0x9cbb8b3d, _0x8740a561 });
    }

    [SerializeField]
    private Sprite _closeIcon;
    private void _0xd5872387(Transform _0x44a4cd38)
    {
        RectTransform _0xc61bd6ad = _0xb1db93c9.Sheet(_0x44a4cd38, _0xa9a0ddc3._0x9d681c7a(new byte[10] { 30, 63, 62, 37, 56, 25, 34, 47, 47, 62 }, 74));
        this._0x3486b649 = _0xc61bd6ad;
        _0xb1db93c9.Shade(_0xc61bd6ad, _0xa9a0ddc3._0x9d681c7a(new byte[10] { 25, 56, 57, 34, 63, 30, 37, 44, 41, 40 }, 77), _0xa2f55a4e.Fade(_0xa2f55a4e.Deep, 0.9f));
        RectTransform _0xcd0d412b = _0xb1db93c9.Card(_0xc61bd6ad, _0xa9a0ddc3._0x9d681c7a(new byte[9] { 5, 36, 37, 62, 35, 18, 48, 35, 53 }, 81), this._roundedPlate, new Vector2(0.5f, 0.52f), Vector2.zero, new Vector2(1060f, 1340f), _0xa2f55a4e.Surface, _0xa2f55a4e.Fade(_0xa2f55a4e.Violet, 0.9f), 1.3f, 5f);
        _0xb1db93c9.Label(_0xcd0d412b, _0xa9a0ddc3._0x9d681c7a(new byte[10] { 25, 56, 57, 34, 63, 25, 36, 57, 33, 40 }, 77), this._font, _0xa9a0ddc3._0x9d681c7a(new byte[11] { 108, 107, 115, 4, 112, 107, 4, 116, 104, 101, 125 }, 36), new Vector2(0.5f, 1f), new Vector2(0f, -110f), new Vector2(900f, 96f), 56f, _0xa2f55a4e.Gold, TextAlignmentOptions.Center);
        this._0x9dbb5ea3(_0xcd0d412b, 0, this._containerFace, _0xa2f55a4e.Gold, _0xa9a0ddc3._0x9d681c7a(new byte[30] { 85, 82, 81, 89, 61, 73, 85, 88, 61, 78, 94, 79, 88, 88, 83, 23, 73, 85, 88, 61, 94, 82, 79, 88, 61, 79, 84, 78, 88, 78 }, 29));
        this._0x9dbb5ea3(_0xcd0d412b, 1, this._ledgeRightFace, _0xa2f55a4e.TextMain, _0xa9a0ddc3._0x9d681c7a(new byte[33] { 191, 168, 161, 168, 172, 190, 168, 205, 185, 162, 205, 161, 162, 174, 166, 231, 162, 163, 205, 185, 165, 168, 205, 163, 168, 181, 185, 205, 161, 168, 169, 170, 168 }, 237));
        this._0x9dbb5ea3(_0xcd0d412b, 2, this._barrierFace, _0xa2f55a4e.Violet, _0xa9a0ddc3._0x9d681c7a(new byte[48] { 53, 54, 37, 37, 62, 50, 37, 36, 87, 52, 56, 36, 35, 87, 62, 57, 35, 50, 48, 37, 62, 35, 46, 125, 35, 63, 37, 50, 50, 87, 63, 62, 35, 36, 87, 50, 57, 51, 87, 35, 63, 50, 87, 52, 59, 62, 58, 53 }, 119));
        this._0x27370502(_0xc61bd6ad, _0xa9a0ddc3._0x9d681c7a(new byte[10] { 133, 164, 165, 190, 163, 146, 189, 190, 162, 180 }, 209), () => this._0x82854c63());
        _0xc61bd6ad.gameObject.SetActive(false);
    }

    [SerializeField]
    private Sprite _barrierFace;
    /// The route sheet. The segment column and the text column never share an x
    /// band: the gutter is centred on 62 and nothing written starts left of 129,
    /// which keeps a 46-unit gap between the two (CLAUDE-unity.md C.25).
    private void _0xb1ca54fb(Transform _0x75b76289, int _0xb207f040)
    {
        RectTransform _0x1d04f700 = _0xb1db93c9.Sheet(_0x75b76289, _0xa9a0ddc3._0x9d681c7a(new byte[10] { 119, 74, 80, 81, 64, 118, 77, 64, 64, 81 }, 37));
        this._0x5789a19c = _0x1d04f700;
        _0xb1db93c9.Shade(_0x1d04f700, _0xa9a0ddc3._0x9d681c7a(new byte[10] { 144, 173, 183, 182, 167, 145, 170, 163, 166, 167 }, 194), _0xa2f55a4e.Fade(_0xa2f55a4e.Deep, 0.9f));
        RectTransform _0x999dae86 = _0xb1db93c9.Card(_0x1d04f700, _0xa9a0ddc3._0x9d681c7a(new byte[9] { 156, 161, 187, 186, 171, 141, 175, 188, 170 }, 206), this._roundedPlate, new Vector2(0.5f, 0.52f), Vector2.zero, new Vector2(1080f, 1560f), _0xa2f55a4e.Surface, _0xa2f55a4e.Fade(_0xa2f55a4e.Primary, 0.9f), 1.3f, 5f);
        _0xb1db93c9.Label(_0x999dae86, _0xa9a0ddc3._0x9d681c7a(new byte[10] { 108, 81, 75, 74, 91, 106, 87, 74, 82, 91 }, 62), this._font, _0xa9a0ddc3._0x9d681c7a(new byte[11] { 36, 57, 35, 34, 51, 86, 37, 62, 51, 51, 34 }, 118), new Vector2(0.5f, 1f), new Vector2(0f, -110f), new Vector2(900f, 96f), 56f, _0xa2f55a4e.Gold, TextAlignmentOptions.Center);
        float _0x75d063b3 = TextLeft + TextWidth * 0.5f;
        for (int _0xee24f565 = 0; _0xee24f565 < _0x1d9b8829.BlockNames.Length; _0xee24f565++)
        {
            float _0x7521d55a = -(260f + _0xee24f565 * 134f);
            _0xb1db93c9.Picture(_0x999dae86, _0xa9a0ddc3._0x9d681c7a(new byte[9] { 153, 164, 190, 191, 174, 134, 170, 185, 160 }, 203) + _0xee24f565, this._markerFace, new Vector2(0f, 1f), new Vector2(GutterCentre, _0x7521d55a), new Vector2(42f, 42f), _0x1d9b8829.MetresAt((_0xee24f565 + 1) * 3) <= _0xb207f040 ? _0xa2f55a4e.Gold : _0xa2f55a4e.Fade(_0xa2f55a4e.SurfaceAlt, 0.95f));
            _0xb1db93c9.Label(_0x999dae86, _0xa9a0ddc3._0x9d681c7a(new byte[9] { 100, 89, 67, 66, 83, 120, 87, 91, 83 }, 54) + _0xee24f565, this._font, _0x1d9b8829.BlockNames[_0xee24f565], new Vector2(0f, 1f), new Vector2(_0x75d063b3, _0x7521d55a), new Vector2(TextWidth, 54f), 36f, _0xa2f55a4e.TextMain, TextAlignmentOptions.Left);
            _0xb1db93c9.Label(_0x999dae86, _0xa9a0ddc3._0x9d681c7a(new byte[9] { 237, 208, 202, 203, 218, 236, 203, 222, 203 }, 191) + _0xee24f565, this._font, _0x1d9b8829.MetresAt((_0xee24f565 + 1) * 3).ToString() + _0xa9a0ddc3._0x9d681c7a(new byte[5] { 8, 101, 8, 8, 80 }, 40) + _0x1d9b8829.BarriersInBlock(_0xee24f565).ToString(), new Vector2(0f, 1f), new Vector2(945f, _0x7521d55a), new Vector2(170f, 48f), 30f, _0xa2f55a4e.TextMuted, TextAlignmentOptions.Right);
        }

        // An empty sheet still has to say something (rule G, empty states).
        if (_0xb207f040 > 0)
        {
            _0xb1db93c9.Label(_0x999dae86, _0xa9a0ddc3._0x9d681c7a(new byte[9] { 240, 205, 215, 214, 199, 224, 199, 209, 214 }, 162), this._font, _0xa9a0ddc3._0x9d681c7a(new byte[12] { 69, 66, 84, 83, 39, 79, 66, 78, 64, 79, 83, 39 }, 7) + _0xb207f040.ToString(_0xa9a0ddc3._0x9d681c7a(new byte[2] { 106, 106 }, 90)) + _0xa9a0ddc3._0x9d681c7a(new byte[2] { 227, 142 }, 195), new Vector2(0.5f, 0f), new Vector2(0f, 150f), new Vector2(880f, 80f), 44f, _0xa2f55a4e.Gold, TextAlignmentOptions.Center);
        }
        else
        {
            _0xb1db93c9.Label(_0x999dae86, _0xa9a0ddc3._0x9d681c7a(new byte[10] { 99, 94, 68, 69, 84, 116, 92, 65, 69, 72 }, 49), this._font, _0xa9a0ddc3._0x9d681c7a(new byte[38] { 212, 213, 186, 217, 214, 211, 215, 216, 186, 200, 223, 217, 213, 200, 222, 223, 222, 186, 195, 223, 206, 144, 201, 206, 219, 200, 206, 186, 206, 213, 186, 201, 223, 206, 186, 213, 212, 223 }, 154), new Vector2(0.5f, 0f), new Vector2(0f, 160f), new Vector2(880f, 140f), 36f, _0xa2f55a4e.TextMuted, TextAlignmentOptions.Center);
        }

        this._0x27370502(_0x1d04f700, _0xa9a0ddc3._0x9d681c7a(new byte[10] { 174, 147, 137, 136, 153, 191, 144, 147, 143, 153 }, 252), () => this._0x626906ff());
        _0x1d04f700.gameObject.SetActive(false);
    }

    private void _0xc3a5c453(Transform[] _0x6ea39ac2)
    {
        for (int _0xa3fe440e = 0; _0xa3fe440e < _0x6ea39ac2.Length; _0xa3fe440e++)
        {
            RectTransform _0x8d10feb2 = _0x6ea39ac2[_0xa3fe440e] as RectTransform;
            if (_0x8d10feb2 == null)
            {
                continue;
            }

            Vector2 _0xf7b2fad8 = _0x8d10feb2.anchoredPosition;
            _0x8d10feb2.anchoredPosition = _0xf7b2fad8 + new Vector2(0f, -40f);
            _0x8d10feb2.DOAnchorPos(_0xf7b2fad8, 0.34f).SetDelay(_0xa3fe440e * 0.06f).SetEase(Ease.OutCubic);
        }
    }

    private void Start()
    {
        this._0x943bee8f();
        this._0x8ac8f2c4();
        _0xfb7b4cff _0x0f110bf1 = this.gameObject.AddComponent<_0xfb7b4cff>();
        _0x0f110bf1._0x43a51755();
    }

    [SerializeField]
    private Sprite _beaconFace;
    [SerializeField]
    private RectTransform _playButtonSlot;
    private const float TextLeft = 129f;
    [SerializeField]
    private TMP_FontAsset _font;
    private Transform _0x76358957(int _0x25c254be)
    {
        if (_0x95eb9f22.Instance == null || _0x95eb9f22.Instance.Panels == null)
        {
            return null;
        }

        if (_0x25c254be < 0 || _0x25c254be >= _0x95eb9f22.Instance.Panels.Count)
        {
            return null;
        }

        _0xedbb5775 _0xa91f0955 = _0x95eb9f22.Instance.Panels[_0x25c254be];
        return _0xa91f0955 == null || _0xa91f0955.Content == null ? null : _0xa91f0955.Content.transform;
    }

    private RectTransform _0x5789a19c;
    /// The splash gets a darker veil than the menu and no PLAY row at all, so the
    /// two screens read as different pictures rather than the same one twice.
    private void _0x943bee8f()
    {
        Transform _0x015370b1 = this._0x76358957(_0xfaef8027._0xec2ae8dc.SPLASH);
        if (_0x015370b1 == null)
        {
            return;
        }

        RectTransform _0xc23c2db6 = _0xb1db93c9.Sheet(_0x015370b1, _0xa9a0ddc3._0x9d681c7a(new byte[11] { 158, 189, 161, 172, 190, 165, 137, 191, 168, 190, 190 }, 205));
        _0xc23c2db6.SetAsFirstSibling();
        Image _0xee013aa7 = _0xb1db93c9.Shade(_0xc23c2db6, _0xa9a0ddc3._0x9d681c7a(new byte[10] { 142, 173, 177, 188, 174, 181, 139, 184, 180, 177 }, 221), _0xa2f55a4e.Fade(_0xa2f55a4e.Deep, 0.62f));
        _0xee013aa7.raycastTarget = false;
        Image _0xa86ef34d = _0xb1db93c9.Picture(_0xc23c2db6, _0xa9a0ddc3._0x9d681c7a(new byte[10] { 81, 114, 110, 99, 113, 106, 74, 99, 110, 109 }, 2), this._mark, new Vector2(0.5f, 0.60f), Vector2.zero, new Vector2(620f, 620f), _0xa2f55a4e.Fade(_0xa2f55a4e.Primary, 0.20f));
        _0xa86ef34d.DOFade(0.5f, 1.1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        Image _0x77ce92f4 = _0xb1db93c9.Picture(_0xc23c2db6, _0xa9a0ddc3._0x9d681c7a(new byte[10] { 242, 209, 205, 192, 210, 201, 236, 192, 211, 202 }, 161), this._mark, new Vector2(0.5f, 0.60f), Vector2.zero, new Vector2(360f, 360f), _0xa2f55a4e.TextMain);
        _0x77ce92f4.transform.localScale = Vector3.one * 0.94f;
        _0x77ce92f4.transform.DOScale(1f, 1.1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        _0xb1db93c9.Label(_0xc23c2db6, _0xa9a0ddc3._0x9d681c7a(new byte[10] { 190, 157, 129, 140, 158, 133, 161, 132, 131, 136 }, 237), this._font, _0xa9a0ddc3._0x9d681c7a(new byte[19] { 196, 198, 209, 196, 213, 198, 221, 218, 211, 180, 192, 220, 209, 180, 199, 220, 213, 210, 192 }, 148), new Vector2(0.5f, 0.44f), Vector2.zero, new Vector2(900f, 56f), 36f, _0xa2f55a4e.TextMuted, TextAlignmentOptions.Center);
    }

    [SerializeField]
    private Sprite _ledgeRightFace;
    private void _0x82854c63()
    {
        if (this._0x3486b649 != null)
        {
            this._0x3486b649.gameObject.SetActive(false);
        }
    }

    private void _0x977dc050(RectTransform _0x36cb9534)
    {
        if (_0x36cb9534 == null)
        {
            return;
        }

        _0x36cb9534.gameObject.SetActive(true);
        _0x36cb9534.SetAsLastSibling();
        Transform _0xde731129 = _0x36cb9534.childCount > 1 ? _0x36cb9534.GetChild(1) : null;
        if (_0xde731129 == null)
        {
            return;
        }

        _0xde731129.localScale = Vector3.one * 0.88f;
        DOTween.Kill(_0xde731129, true);
        _0xde731129.DOScale(1f, 0.24f).SetEase(Ease.OutBack);
    }

    private const float GutterCentre = 62f;
    private void _0x3ddd0844()
    {
        if (this._playButtonSlot == null)
        {
            return;
        }

        RectTransform _0xcfb8ac26 = _0xb1db93c9.Node(this._playButtonSlot, _0xa9a0ddc3._0x9d681c7a(new byte[8] { 177, 141, 128, 152, 167, 128, 130, 132 }, 225), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(760f, 168f));
        Image _0xf8c26213 = _0xcfb8ac26.gameObject.AddComponent<Image>();
        _0xf8c26213.sprite = this._roundedPlate;
        _0xf8c26213.type = Image.Type.Sliced;
        _0xf8c26213.pixelsPerUnitMultiplier = 1.3f;
        _0xf8c26213.color = _0xa2f55a4e.Fade(_0xa2f55a4e.Gold, 0.9f);
        _0xf8c26213.raycastTarget = true;
        _0xf8c26213.canvasRenderer.cullTransparentMesh = false;
        RectTransform _0xc2bb6ed3 = _0xb1db93c9.Node(_0xcfb8ac26, _0xa9a0ddc3._0x9d681c7a(new byte[12] { 160, 156, 145, 137, 182, 145, 147, 149, 178, 159, 148, 137 }, 240), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(750f, 158f));
        Image _0x1c6cb818 = _0xc2bb6ed3.gameObject.AddComponent<Image>();
        _0x1c6cb818.sprite = this._roundedPlate;
        _0x1c6cb818.type = Image.Type.Sliced;
        _0x1c6cb818.pixelsPerUnitMultiplier = 1.5f;
        _0x1c6cb818.color = _0xa2f55a4e.Primary;
        _0x1c6cb818.raycastTarget = true;
        Image _0xcbc3c62c = _0xb1db93c9.Slab(_0xc2bb6ed3, _0xa9a0ddc3._0x9d681c7a(new byte[9] { 169, 149, 152, 128, 170, 145, 156, 156, 151 }, 249), this._roundedPlate, new Vector2(0.5f, 1f), new Vector2(0f, -40f), new Vector2(726f, 64f), _0xa2f55a4e.Fade(_0xa2f55a4e.Violet, 0.7f), 1.6f);
        _0xcbc3c62c.raycastTarget = false;
        _0xb1db93c9.Label(_0xc2bb6ed3, _0xa9a0ddc3._0x9d681c7a(new byte[11] { 108, 80, 93, 69, 127, 93, 76, 72, 85, 83, 82 }, 60), this._font, _0xa9a0ddc3._0x9d681c7a(new byte[4] { 127, 99, 110, 118 }, 47), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(680f, 84f), 58f, _0xa2f55a4e.TextMain, TextAlignmentOptions.Center);
        _0xcfb8ac26.DOScale(1.03f, 1.4f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    private void _0x27370502(RectTransform _0x1f508b60, string _0xb32f0cab, System.Action _0xa0d3ecf9)
    {
        RectTransform _0x09b9455a = _0xb1db93c9.Card(_0x1f508b60, _0xb32f0cab, this._roundedPlate, new Vector2(0.86f, 0.915f), Vector2.zero, new Vector2(120f, 120f), _0xa2f55a4e.Base, _0xa2f55a4e.Fade(_0xa2f55a4e.Gold, 0.9f), 1.5f, 3f);
        _0xb1db93c9.Picture(_0x09b9455a, _0xb32f0cab + _0xa9a0ddc3._0x9d681c7a(new byte[5] { 6, 45, 56, 49, 41 }, 65), this._closeIcon, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(62f, 62f), _0xa2f55a4e.TextMain);
        Button _0x0427f101 = _0xb1db93c9.Pressable(_0x09b9455a, Color.white, _0xa2f55a4e.Primary);
        _0x0427f101.onClick.AddListener(() => _0xa0d3ecf9());
    }

    private static readonly string AttemptKey = _0xa9a0ddc3._0x9d681c7a(new byte[12] { 156, 179, 182, 178, 189, 158, 171, 171, 186, 178, 175, 171 }, 223);
    private void _0x6899ea0f()
    {
        this._0x977dc050(this._0x5789a19c);
    }

    [SerializeField]
    private Sprite _markerFace;
}

internal static class _0xa9a0ddc3
{
    internal static string _0x9d681c7a(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}