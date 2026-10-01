using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class _0x7770fbfb : MonoBehaviour
{
    private Vector3 _0x1654615b { get; set; }
    private Vector3 _0x3471683b { get; set; }
    private Vector3 _0xcb31d3d1 { get; set; }

    private Color _0xb051380b = Color.white;
    private Vector3 _0x86d22e1d { get; set; }
    private Vector3 _0x53a15d36 { get; set; }
    //public bool executeInUpdate;
    private float _0x299b0728 { get; set; }
    private Vector3 _0xa9f34b1d { get; set; }
    private float _0x732e8600 { get; set; }
    private Vector3 _0xcd3e8936 { get; set; }
    private Vector3 _0xfce33903 { get; set; }
    private Vector3 _0x771a226d { get; set; }

    private void OnDrawGizmos()
    {
        Gizmos.color = this._0xb051380b;
        Matrix4x4 _0x090a1151 = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(this.transform.position, this.transform.rotation, Vector3.one);
        if (this._0x98d4d1d0.orthographic)
        {
            float _0x73a06579 = this._0x98d4d1d0.farClipPlane - this._0x98d4d1d0.nearClipPlane;
            float _0xc47c8573 = (this._0x98d4d1d0.farClipPlane + this._0x98d4d1d0.nearClipPlane) * 0.5f;
            Gizmos.DrawWireCube(new Vector3(0, 0, _0xc47c8573), new Vector3(this._0x98d4d1d0.orthographicSize * 2 * this._0x98d4d1d0.aspect, this._0x98d4d1d0.orthographicSize * 2, _0x73a06579));
        }
        else
        {
            Gizmos.DrawFrustum(Vector3.zero, this._0x98d4d1d0.fieldOfView, this._0x98d4d1d0.farClipPlane, this._0x98d4d1d0.nearClipPlane, this._0x98d4d1d0.aspect);
        }

        Gizmos.matrix = _0x090a1151;
    }

    private _0x7cbea98a _0xd8eab38d = _0x7cbea98a.Portrait;
    private static _0x7770fbfb _0x8749c9c5;
    private float _0xa74a6cf8 = 1;
    public enum _0x7cbea98a
    {
        Landscape,
        Portrait
    }

    private void Awake()
    {
        this._0x98d4d1d0 = this.GetComponent<Camera>();
        _0x8749c9c5 = this;
        this._0x4e8385a6();
    }

    private new Camera _0x98d4d1d0;
    private void _0x4e8385a6()
    {
        float _0x6a82a260, _0xc026b8fc, _0xfca0c5c5, _0xc60e3b2c;
        if (this._0xd8eab38d == _0x7cbea98a.Landscape)
            this._0x98d4d1d0.orthographicSize = 1f / this._0x98d4d1d0.aspect * this._0xa74a6cf8 / 2f;
        else
            this._0x98d4d1d0.orthographicSize = this._0xa74a6cf8 / 2f;
        this._0x732e8600 = 2f * this._0x98d4d1d0.orthographicSize;
        this._0x299b0728 = this._0x732e8600 * this._0x98d4d1d0.aspect;
        float _0x3e356d94 = this._0x98d4d1d0.transform.position.x;
        float _0x80a1cb25 = this._0x98d4d1d0.transform.position.y;
        _0x6a82a260 = _0x3e356d94 - this._0x299b0728 / 2;
        _0xc026b8fc = _0x3e356d94 + this._0x299b0728 / 2;
        _0xfca0c5c5 = _0x80a1cb25 + this._0x732e8600 / 2;
        _0xc60e3b2c = _0x80a1cb25 - this._0x732e8600 / 2;
        this._0x53a15d36 = new Vector3(_0x6a82a260, _0xc60e3b2c, 0);
        this._0x86d22e1d = new Vector3(_0x3e356d94, _0xc60e3b2c, 0);
        this._0x3471683b = new Vector3(_0xc026b8fc, _0xc60e3b2c, 0);
        this._0xcb31d3d1 = new Vector3(_0x6a82a260, _0x80a1cb25, 0);
        this._0x771a226d = new Vector3(_0x3e356d94, _0x80a1cb25, 0);
        this._0xfce33903 = new Vector3(_0xc026b8fc, _0x80a1cb25, 0);
        this._0xcd3e8936 = new Vector3(_0x6a82a260, _0xfca0c5c5, 0);
        this._0xa9f34b1d = new Vector3(_0x3e356d94, _0xfca0c5c5, 0);
        this._0x1654615b = new Vector3(_0xc026b8fc, _0xfca0c5c5, 0);
    }
}