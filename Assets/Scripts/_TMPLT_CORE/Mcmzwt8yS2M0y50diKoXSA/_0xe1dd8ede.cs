using UnityEngine;

public class _0xe1dd8ede : MonoBehaviour
{
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this.gameObject.GetComponent<_0xe1dd8ede>();
            DontDestroyOnLoad(this.gameObject);
            this._0x1a24bf15();
        }
        else
        {
            this._0x47e3f3a3();
            Destroy(this.gameObject);
        }
    }

    public bool IsOnlyWinGameEndEnabled;
    public bool IsBestScoreEnabled;
    public bool IsLevelSelectorEnabled;
    public bool IsTutorialEnabled;
    public bool IsCheckScoreEnabled;
    public bool IsTimerEnabled;
    private void _0x47e3f3a3()
    {
    }

    private void _0x1a24bf15()
    {
        {
#if !B_LOGS
        {
            Debug.unityLogger.logEnabled = false;
            Application.SetStackTraceLogType(LogType.Assert, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Exception, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Warning, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Error, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
        }
#endif
        }

        QualitySettings.vSyncCount = 1;
        Application.runInBackground = true;
    //Application.targetFrameRate = 60;
    // Time.fixedDeltaTime = 0.03f; // USE CUSTOM PHYSICS TIME FOR OPTIMIZATION IF NEEDED
    // Add this once at startup to silence the specific assertion
    }

    public bool IsStoryEnabled;
    public bool IsSkipSplashEnabled;
    public bool IsLevelIncrementOnWin;
    public static _0xe1dd8ede Instance;
}