using UnityEngine;
using UnityEngine.UI;

public class _0x86e556a3 : MonoBehaviour
{
    public bool IsShowLastPop;
    private void Start()
    {
        if (this.IsShowLastPop)
            this.Button.onClick.AddListener(() =>
            {
                _0x148306eb.Instance._0xc36bcafb();
            });
        else if (this.IsHideAllPops)
            this.Button.onClick.AddListener(() => _0x148306eb.Instance._0xc14479c5());
        else
            this.Button.onClick.AddListener(() => _0x148306eb.Instance._0x1eb41fb2(this.PopToShowIndex));
    }

    public Button Button;
    public int PopToShowIndex;
    private void Awake()
    {
        if (this.Button == null)
            if (!this.TryGetComponent(out this.Button))
                this.Button = this.GetComponentInChildren<Button>();
    }

    public bool IsHideAllPops;
}