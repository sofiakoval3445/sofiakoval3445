using UnityEngine;

/// One force barrier sweeping across the shaft.
///
/// It owns nothing but its own sweep: amplitude, speed, phase and the half extents
/// the run director needs to decide whether the container just walked into it.
/// The sweep is a plain sine of game time, so it is identical on every device and
/// matches the curve the layout generator used when it proved the band passable.
public sealed class _0x4b229850 : MonoBehaviour
{
    private float _0x78daf05c;
    private float _0xac4190b3;
    private float _0xaae3ea07;
    public float _0x36e9d81c { get; private set; }

    public void _0x70dc2284(SpriteRenderer _0xc9646175, float _0xe1499f69, float _0x7c1e8e06, float _0x5f792f66, float _0x7812365e, Vector2 _0xe7f1e601)
    {
        this._0x4bdfd167 = _0xc9646175;
        this._0x1e988c28 = _0xe1499f69;
        this._0xac4190b3 = _0x7c1e8e06;
        this._0x0893ca25 = _0x5f792f66;
        this._0x78daf05c = _0x7812365e;
        this._0x36e9d81c = _0xe7f1e601.x * 0.5f;
        this._0x56a5b6f8 = _0xe7f1e601.y * 0.5f;
        this._0x2333fe8f = 0f;
        this._0xaae3ea07 = 0f;
        this._0x4dffa458(0f);
    }

    public float _0x2333fe8f { get; private set; }

    /// The sweep runs off its own clock rather than Time.time so a pause really
    /// pauses: the barrier resumes from where the player left it instead of
    /// teleporting to wherever the wall clock had wandered off to.
    private void Update()
    {
        if (_0xeb787fb1.Instance != null && !_0xeb787fb1.Instance._0xd0a09e2c)
        {
            return;
        }

        this._0xaae3ea07 += Time.deltaTime;
        this._0x4dffa458(this._0xaae3ea07);
    }

    private SpriteRenderer _0x4bdfd167;
    private void _0x4dffa458(float _0x3a8137c8)
    {
        if (this._0x1e988c28 <= 0.0001f)
        {
            return;
        }

        this._0x2333fe8f = this._0x1e988c28 * Mathf.Sin(this._0xac4190b3 / this._0x1e988c28 * _0x3a8137c8 + this._0x0893ca25);
        this.transform.localPosition = new Vector3(this._0x2333fe8f, this._0x78daf05c, 0f);
        if (this._0x4bdfd167 != null)
        {
            float _0x57ca8efa = Mathf.Abs(this._0x2333fe8f) / this._0x1e988c28;
            this._0x4bdfd167.color = Color.Lerp(_0xa2f55a4e.Fade(_0xa2f55a4e.Violet, 0.85f), _0xa2f55a4e.Fade(_0xa2f55a4e.Primary, 0.95f), _0x57ca8efa);
        }
    }

    public float _0x56a5b6f8 { get; private set; }

    private float _0x1e988c28;
    public float _0xa227f64d
    {
        get
        {
            return this._0x78daf05c;
        }
    }

    private float _0x0893ca25;
}