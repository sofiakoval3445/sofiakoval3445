using UnityEngine;
using UnityEngine.UI;

public class _0xe1e96e13 : MonoBehaviour
{
    private bool _0x6f7e1801;
    private void Awake()
    {
        if (this._0xa1f93b9b == null)
            if (!this.TryGetComponent(out this._0xa1f93b9b))
                this._0xa1f93b9b = this.GetComponentInChildren<Button>();
    }

    private int _0x8eaf1528;
    private Button _0xa1f93b9b;
    private void Start()
    {
        if (this._0x6f7e1801)
            this._0xa1f93b9b.onClick.AddListener(() => _0x95eb9f22.Instance._0x77788017());
        else
            this._0xa1f93b9b.onClick.AddListener(() => _0x95eb9f22.Instance._0xda9a5301(this._0x8eaf1528));
    }
}