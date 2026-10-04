using UnityEngine;
using UnityEngine.UI;

public class _0x2156c4a4 : MonoBehaviour
{
    private void Awake()
    {
        if (this.Button == null)
            if (!this.TryGetComponent(out this.Button))
                this.Button = this.GetComponentInChildren<Button>();
    }

    public bool IsPhysicsRunOnClick;
    public Button Button;
    private void Start()
    {
        this.Button.onClick.AddListener(() => _0xeb787fb1.Instance._0xf04b6c96(this.IsPhysicsRunOnClick));
    }
}