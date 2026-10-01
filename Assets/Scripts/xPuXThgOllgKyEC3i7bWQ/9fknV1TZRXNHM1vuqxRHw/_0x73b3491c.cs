using AndroidInstallReferrer;
using DG.Tweening;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Unity.Notifications.Android;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using Unity.Services.CloudSave.Models;
using Unity.Services.CloudSave.Models.Data.Player;
using Unity.Services.Core;
using Unity.Services.PushNotifications;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Application = UnityEngine.Application;

public class _0x73b3491c : MonoBehaviour
{
    private bool _0xdb97e1e8 = false;
    private bool _0xf37c9fed(string _0xbc77fa8c)
    {
        if (string.IsNullOrEmpty(_0xbc77fa8c))
            return false;
        try
        {
            using (var _0x81d84ca6 = new AndroidJavaClass(_0x64265e0e._0x86efbe3e(new byte[30] { 224, 236, 238, 173, 246, 237, 234, 247, 250, 176, 231, 173, 243, 239, 226, 250, 230, 241, 173, 214, 237, 234, 247, 250, 211, 239, 226, 250, 230, 241 }, 131)))
            using (var _0x326b2e19 = _0x81d84ca6.GetStatic<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[15] { 81, 71, 64, 64, 87, 92, 70, 115, 81, 70, 91, 68, 91, 70, 75 }, 50)))
            using (var _0x7573593b = _0x326b2e19.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[17] { 25, 27, 10, 46, 31, 29, 21, 31, 25, 27, 51, 31, 16, 31, 25, 27, 12 }, 126)))
            using (var _0xa25b3bfd = _0x7573593b.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[25] { 53, 55, 38, 30, 51, 39, 60, 49, 58, 27, 60, 38, 55, 60, 38, 20, 61, 32, 2, 51, 49, 57, 51, 53, 55 }, 82), _0xbc77fa8c))
            {
                if (_0xa25b3bfd == null)
                    return false;
                WLog(_0x64265e0e._0x86efbe3e(new byte[37] { 51, 24, 2, 31, 29, 21, 60, 25, 27, 21, 80, 28, 17, 5, 30, 19, 24, 80, 25, 30, 3, 4, 17, 28, 28, 21, 20, 80, 0, 17, 19, 27, 17, 23, 21, 74, 80 }, 112) + _0xbc77fa8c);
                _0xa25b3bfd.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[8] { 201, 204, 204, 238, 196, 201, 207, 219 }, 168), 0x10000000);
                _0x326b2e19.Call(_0x64265e0e._0x86efbe3e(new byte[13] { 169, 174, 187, 168, 174, 155, 185, 174, 179, 172, 179, 174, 163 }, 218), _0xa25b3bfd);
                return true;
            }
        }
        catch
        {
            return false;
        }
    }

    private string _0x2ad2e88c = "";
    private static bool IsPrivacyItemTrue(Item _0x5be868a3)
    {
        if (_0x5be868a3.Key != _0x64265e0e._0x86efbe3e(new byte[9] { 233, 243, 208, 242, 233, 246, 225, 227, 249 }, 128))
            return false;
        try
        {
            var _0x08efdd0b = _0x5be868a3.Value.GetAs<object>();
            return _0x08efdd0b switch
            {
                bool b => b,
                string s when bool.TryParse(s, out var parsed) => parsed,
                _ => false
            };
        }
        catch
        {
            return false;
        }
    }

    private void _0x868c53cf(string _0x00a262c7)
    {
        if (string.IsNullOrEmpty(_0x00a262c7))
            return;
        if (TryOpenExternalLikeChrome(_0x00a262c7))
            return;
        OpenUrlExternally(_0x00a262c7);
    }

    internal void _0x61207e6b()
    {
        Rect _0x26d97ed0 = Screen.safeArea;
        Vector2 _0x61dd039d = new Vector2(Screen.width, Screen.height);
        if (_0x26d97ed0 == lastSafe && _0x61dd039d == lastSize)
            return;
        // Apply manual padding
        _0x26d97ed0.xMin += _0xa269660e;
        _0x26d97ed0.xMax -= _0x806b18cb;
        _0x26d97ed0.yMin += _0x2de957eb;
        _0x26d97ed0.yMax -= _0x4fc7525c;
        // Convert Unity safe area -> native WebView frame
        Rect _0xfd3ce6b9 = new Rect(_0x26d97ed0.x, _0x61dd039d.y - _0x26d97ed0.y - _0x26d97ed0.height, // Y flip for native coordinate system
 _0x26d97ed0.width, _0x26d97ed0.height);
        _0x3f45d451.Frame = _0xfd3ce6b9;
        lastSafe = Screen.safeArea;
        lastSize = _0x61dd039d;
    }

    private IEnumerator RequestAndroidPermissionIfNeeded(string _0x2340d89d)
    {
        if (Permission.HasUserAuthorizedPermission(_0x2340d89d))
            yield break;
        bool _0x9024b1fd = false;
        var _0xbe870ee0 = new PermissionCallbacks();
        _0xbe870ee0.PermissionGranted += _0x7b5cc988 => _0x9024b1fd = true;
        _0xbe870ee0.PermissionDenied += _0x7b5cc988 => _0x9024b1fd = true;
        Permission.RequestUserPermission(_0x2340d89d, _0xbe870ee0);
        yield return new WaitUntil(() => _0x9024b1fd);
    }

    private string _0xcf0cdd9b = "";
    private bool _0x5dbdfb16 = false;
    private AndroidJavaObject _0xebf11d24 { get; set; }

    private string _0x05909705()
    {
        string _0x6fa2bf98 = _0xb5c488d6();
        if (string.IsNullOrEmpty(_0x6fa2bf98))
            return _0x64265e0e._0x86efbe3e(new byte[7] { 188, 165, 163, 174, 234, 250, 241 }, 202);
        string _0x7f8767f2 = _0x6fa2bf98.Replace(_0x64265e0e._0x86efbe3e(new byte[1] { 177 }, 237), _0x64265e0e._0x86efbe3e(new byte[2] { 235, 235 }, 183)).Replace(_0x64265e0e._0x86efbe3e(new byte[1] { 195 }, 228), _0x64265e0e._0x86efbe3e(new byte[2] { 93, 38 }, 1));
        var _0x2d5bc045 = Regex.Match(_0x6fa2bf98, _0x64265e0e._0x86efbe3e(new byte[12] { 12, 39, 61, 32, 34, 42, 96, 103, 19, 43, 100, 102 }, 79));
        string _0x147e2323 = _0x2d5bc045.Success ? _0x2d5bc045.Groups[1].Value : _0x64265e0e._0x86efbe3e(new byte[3] { 92, 95, 93 }, 109);
        return _0x64265e0e._0x86efbe3e(new byte[12] { 64, 14, 29, 6, 11, 28, 1, 7, 6, 64, 65, 19 }, 104) + _0x64265e0e._0x86efbe3e(new byte[8] { 115, 100, 119, 37, 112, 100, 56, 34 }, 5) + _0x7f8767f2 + _0x64265e0e._0x86efbe3e(new byte[2] { 241, 237 }, 214) + _0x64265e0e._0x86efbe3e(new byte[30] { 9, 30, 13, 95, 15, 13, 16, 11, 16, 66, 49, 30, 9, 22, 24, 30, 11, 16, 13, 81, 15, 13, 16, 11, 16, 11, 6, 15, 26, 68 }, 127) + _0x64265e0e._0x86efbe3e(new byte[121] { 14, 29, 6, 11, 28, 1, 7, 6, 72, 12, 13, 14, 64, 7, 10, 2, 68, 3, 13, 17, 68, 30, 9, 4, 65, 19, 28, 26, 17, 19, 39, 10, 2, 13, 11, 28, 70, 12, 13, 14, 1, 6, 13, 56, 26, 7, 24, 13, 26, 28, 17, 64, 7, 10, 2, 68, 3, 13, 17, 68, 19, 15, 13, 28, 82, 14, 29, 6, 11, 28, 1, 7, 6, 64, 65, 19, 26, 13, 28, 29, 26, 6, 72, 30, 9, 4, 83, 21, 68, 11, 7, 6, 14, 1, 15, 29, 26, 9, 10, 4, 13, 82, 28, 26, 29, 13, 21, 65, 83, 21, 11, 9, 28, 11, 0, 64, 13, 65, 19, 21, 21 }, 104) + _0x64265e0e._0x86efbe3e(new byte[26] { 55, 54, 53, 123, 35, 33, 60, 39, 60, 127, 116, 38, 32, 54, 33, 18, 52, 54, 61, 39, 116, 127, 38, 50, 122, 104 }, 83) + _0x64265e0e._0x86efbe3e(new byte[52] { 75, 74, 73, 7, 95, 93, 64, 91, 64, 3, 8, 78, 95, 95, 121, 74, 93, 92, 70, 64, 65, 8, 3, 90, 78, 1, 93, 74, 95, 67, 78, 76, 74, 7, 0, 113, 98, 64, 85, 70, 67, 67, 78, 115, 0, 0, 3, 8, 8, 6, 6, 20 }, 47) + _0x64265e0e._0x86efbe3e(new byte[37] { 245, 244, 247, 185, 225, 227, 254, 229, 254, 189, 182, 225, 253, 240, 229, 247, 254, 227, 252, 182, 189, 182, 221, 248, 255, 228, 233, 177, 240, 227, 252, 231, 169, 253, 182, 184, 170 }, 145) + _0x64265e0e._0x86efbe3e(new byte[34] { 103, 102, 101, 43, 115, 113, 108, 119, 108, 47, 36, 117, 102, 109, 103, 108, 113, 36, 47, 36, 68, 108, 108, 100, 111, 102, 35, 74, 109, 96, 45, 36, 42, 56 }, 3) + _0x64265e0e._0x86efbe3e(new byte[30] { 244, 245, 246, 184, 224, 226, 255, 228, 255, 188, 183, 253, 241, 232, 196, 255, 229, 243, 248, 192, 255, 249, 254, 228, 227, 183, 188, 165, 185, 171 }, 144) + _0x64265e0e._0x86efbe3e(new byte[48] { 142, 136, 131, 129, 140, 155, 136, 218, 143, 155, 158, 199, 129, 152, 136, 155, 148, 158, 137, 192, 161, 129, 152, 136, 155, 148, 158, 192, 221, 185, 146, 136, 149, 151, 147, 143, 151, 221, 214, 140, 159, 136, 137, 147, 149, 148, 192, 221 }, 250) + _0x147e2323 + _0x64265e0e._0x86efbe3e(new byte[35] { 96, 58, 107, 60, 37, 53, 38, 41, 35, 125, 96, 0, 40, 40, 32, 43, 34, 103, 4, 47, 53, 40, 42, 34, 96, 107, 49, 34, 53, 52, 46, 40, 41, 125, 96 }, 71) + _0x147e2323 + _0x64265e0e._0x86efbe3e(new byte[238] { 12, 86, 7, 80, 73, 89, 74, 69, 79, 17, 12, 101, 68, 95, 22, 106, 20, 105, 89, 74, 69, 79, 12, 7, 93, 78, 89, 88, 66, 68, 69, 17, 12, 25, 31, 12, 86, 118, 7, 70, 68, 73, 66, 71, 78, 17, 95, 89, 94, 78, 7, 91, 71, 74, 95, 77, 68, 89, 70, 17, 12, 106, 69, 79, 89, 68, 66, 79, 12, 7, 76, 78, 95, 99, 66, 76, 67, 110, 69, 95, 89, 68, 91, 82, 125, 74, 71, 94, 78, 88, 17, 77, 94, 69, 72, 95, 66, 68, 69, 3, 2, 80, 89, 78, 95, 94, 89, 69, 11, 123, 89, 68, 70, 66, 88, 78, 5, 89, 78, 88, 68, 71, 93, 78, 3, 80, 74, 89, 72, 67, 66, 95, 78, 72, 95, 94, 89, 78, 17, 12, 74, 89, 70, 12, 7, 73, 66, 95, 69, 78, 88, 88, 17, 12, 29, 31, 12, 7, 70, 68, 73, 66, 71, 78, 17, 95, 89, 94, 78, 7, 70, 68, 79, 78, 71, 17, 12, 12, 7, 91, 71, 74, 95, 77, 68, 89, 70, 17, 12, 106, 69, 79, 89, 68, 66, 79, 12, 7, 91, 71, 74, 95, 77, 68, 89, 70, 125, 78, 89, 88, 66, 68, 69, 17, 12, 26, 31, 5, 27, 5, 27, 12, 7, 94, 74, 109, 94, 71, 71, 125, 78, 89, 88, 66, 68, 69, 17, 12 }, 43) + _0x147e2323 + _0x64265e0e._0x86efbe3e(new byte[117] { 33, 63, 33, 63, 33, 63, 40, 114, 38, 52, 114, 114, 52, 64, 109, 101, 106, 108, 123, 33, 107, 106, 105, 102, 97, 106, 95, 125, 96, 127, 106, 125, 123, 118, 39, 127, 125, 96, 123, 96, 35, 40, 122, 124, 106, 125, 78, 104, 106, 97, 123, 75, 110, 123, 110, 40, 35, 116, 104, 106, 123, 53, 105, 122, 97, 108, 123, 102, 96, 97, 39, 38, 116, 125, 106, 123, 122, 125, 97, 47, 122, 110, 107, 52, 114, 35, 108, 96, 97, 105, 102, 104, 122, 125, 110, 109, 99, 106, 53, 123, 125, 122, 106, 114, 38, 52, 114, 108, 110, 123, 108, 103, 39, 106, 38, 116, 114 }, 15) + _0x64265e0e._0x86efbe3e(new byte[5] { 66, 22, 23, 22, 4 }, 63);
    }

    private bool _0xeede92a2()
    {
        if (_0x078fc9c0())
            return true;
        if (_0x3f45d451 != null && _0x3f45d451.CanGoBack)
        {
            WLog(_0x64265e0e._0x86efbe3e(new byte[36] { 71, 110, 125, 107, 120, 110, 125, 106, 47, 109, 110, 108, 100, 47, 34, 49, 47, 98, 110, 102, 97, 47, 88, 106, 109, 89, 102, 106, 120, 47, 72, 96, 77, 110, 108, 100 }, 15));
            _0x3f45d451.GoBack();
            return true;
        }

        return false;
    }

    private readonly List<UniWebViewPopup> _0xa0878f33 = new List<UniWebViewPopup>();
    private void OnApplicationPause(bool _0x92ab916f)
    {
        isApplicationPause = _0x92ab916f;
    }

    private async Task _0xc935f0d5()
    {
        {
#if B_LOGS
            Debug.Log($"[Test] Send click");
#endif
        }

        _0x3f7671b8 = _0x64265e0e._0x86efbe3e(new byte[5] { 71, 64, 77, 82, 68 }, 33);
        _0x7fd95efa = /*IsRunningOnEmulator() ? "running" :*/ "";
        _0x464225d5 = DateTime.UtcNow.Ticks.ToString();
        _0x46d4524a = "";
        JObject _0x9c0e75da = BuildRandomPayload(_0xa4ac586a, _0x74c9073b, _0x00378973, _0x850c186f, _0xbff1150d, _0x7081a095, _0x43e33ad6, _0x9b2c1b74, _0x85e34f56, _0xcf0cdd9b, _0x3f7671b8, _0x46d4524a, _0xdced5a6a, _0x2ad2e88c, _0xdb590138.ToString(), _0x396cda08, _0x464225d5, _0x7fd95efa, _0xf0cf1c30, _0xc0147e9f, _0xacaf1985, _0x5065429e, _0xaf54932b());
        var _0x13c64c1a = _0x0cbee295(_0x9c0e75da.ToString(), _0xf0cf1c30);
        {
#if B_LOGS
            {
                Debug.Log($"[Test][First Run] Send Payload for first run: {_0x9c0e75da}");
            }
#endif
        }

        try
        {
            await CloudSaveService.Instance.Data.Player.SaveAsync(new Dictionary<string, object> { { _0x64265e0e._0x86efbe3e(new byte[7] { 48, 33, 57, 44, 47, 33, 36 }, 64) + _0xf0cf1c30, _0x13c64c1a } });
            await Task.Delay(500);
            string _0x64444c5b = "";
            for (int _0x32910fcf = 0; _0x32910fcf < 20; _0x32910fcf++)
            {
                if (await _0xbd4d8fcf(1, 1))
                {
                    await _0x61932765(_0x64265e0e._0x86efbe3e(new byte[7] { 81, 95, 92, 80, 88, 86, 87 }, 51));
                    _0xf96aaabc();
                    return;
                }

                _0x64444c5b = await _0x7f7d1fc5(1, 500);
                if (!string.IsNullOrEmpty(_0x64444c5b))
                    break;
            }

            _0x17ace729(_0x64444c5b);
        }
        catch (Exception e)
        {
            {
#if B_LOGS
                Debug.Log(_0x64265e0e._0x86efbe3e(new byte[22] { 219, 212, 197, 211, 212, 221, 160, 199, 229, 238, 229, 242, 225, 236, 160, 229, 242, 242, 239, 242, 186, 160 }, 128) + e.Message);
#endif
            }

            _0xf96aaabc();
        }
    }

    private string _0xf397de01(string _0x680aefe1, string _0x76088cde)
    {
        if (string.IsNullOrEmpty(_0x76088cde))
            return _0x680aefe1;
        if (_0x680aefe1.Contains(_0x64265e0e._0x86efbe3e(new byte[1] { 155 }, 164)))
            return _0x680aefe1 + _0x64265e0e._0x86efbe3e(new byte[8] { 41, 124, 106, 97, 107, 102, 107, 50 }, 15) + UnityWebRequest.EscapeURL(_0x76088cde);
        else
            return _0x680aefe1 + _0x64265e0e._0x86efbe3e(new byte[8] { 95, 19, 5, 14, 4, 9, 4, 93 }, 96) + UnityWebRequest.EscapeURL(_0x76088cde);
    }

    private void _0xb6714163()
    {
        WLog(_0x64265e0e._0x86efbe3e(new byte[21] { 235, 194, 209, 199, 212, 194, 209, 198, 131, 193, 194, 192, 200, 131, 211, 209, 198, 208, 208, 198, 199 }, 163));
        if (Time.frameCount == _0xb9f45cf0)
            return;
        _0xb9f45cf0 = Time.frameCount;
        if (_0xeede92a2())
            return;
        _0x0fedbce9();
    }

    private string _0x9b2c1b74 = "";
    private bool _0x93b4079b()
    {
        var _0xcb5414de = Keyboard.current;
        return _0xcb5414de != null && _0xcb5414de.escapeKey.wasPressedThisFrame;
    }

    private string _0x43e33ad6 { get; set; }

    private void _0x48b7d575()
    {
        using (var _0x32fd7aca = new AndroidJavaClass(_0x64265e0e._0x86efbe3e(new byte[30] { 64, 76, 78, 13, 86, 77, 74, 87, 90, 16, 71, 13, 83, 79, 66, 90, 70, 81, 13, 118, 77, 74, 87, 90, 115, 79, 66, 90, 70, 81 }, 35)))
        using (var _0x1c8461f0 = _0x32fd7aca.GetStatic<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[15] { 175, 185, 190, 190, 169, 162, 184, 141, 175, 184, 165, 186, 165, 184, 181 }, 204)))
        using (var _0xe70b0b75 = _0x1c8461f0.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[9] { 98, 96, 113, 76, 107, 113, 96, 107, 113 }, 5)))
        {
            if (_0xe70b0b75 == null)
                return;
            using (var _0xa7868489 = _0xe70b0b75.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[9] { 159, 157, 140, 189, 128, 140, 138, 153, 139 }, 248)))
            {
                if (_0xa7868489 == null)
                    return;
                using (var _0xe4115dae = new AndroidJavaObject(_0x64265e0e._0x86efbe3e(new byte[19] { 163, 190, 171, 226, 166, 191, 163, 162, 226, 134, 159, 131, 130, 131, 174, 166, 169, 175, 184 }, 204)))
                using (var _0x29cbd81e = _0xa7868489.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[6] { 23, 25, 5, 47, 25, 8 }, 124)))
                using (var _0x3430f6d1 = _0x29cbd81e.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[8] { 239, 242, 227, 244, 231, 242, 233, 244 }, 134)))
                {
                    while (_0x3430f6d1.Call<bool>(_0x64265e0e._0x86efbe3e(new byte[7] { 88, 81, 67, 126, 85, 72, 68 }, 48)))
                    {
                        string _0x44e9bfc6 = _0x3430f6d1.Call<string>(_0x64265e0e._0x86efbe3e(new byte[4] { 251, 240, 237, 225 }, 149));
                        using (var _0xe91ba758 = _0xa7868489.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[3] { 58, 56, 41 }, 93), _0x44e9bfc6))
                        {
                            _0xe4115dae.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[3] { 160, 165, 164 }, 208), _0x44e9bfc6, _0xe91ba758);
                        }
                    }

                    string _0x7c20960b = _0xe4115dae.Call<string>(_0x64265e0e._0x86efbe3e(new byte[8] { 36, 63, 3, 36, 34, 57, 62, 55 }, 80));
                    if (!string.IsNullOrEmpty(_0x7c20960b))
                    {
                        _0x01306115(_0x7c20960b);
                        _0x15c1c4a7(_0x7c20960b);
                    }
                }
            }
        }
    }

    private void _0xc146ae5c()
    {
        if (Camera.main == null)
            return;
        Camera.main.cullingMask = 0;
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        Camera.main.backgroundColor = Color.black;
    }

    private string _0x74c9073b = "";
    private bool _0x4a96e19d(string _0xd2eaded5, string _0xc4bcc2b2)
    {
        string _0x1d77d194 = _0xb7395568(_0xd2eaded5);
        if (string.IsNullOrEmpty(_0x1d77d194))
            _0x1d77d194 = _0xc4bcc2b2;
        if (_0xf37c9fed(_0x1d77d194))
            return true;
        string _0xdc4bec60 = string.IsNullOrEmpty(_0x1d77d194) ? _0x64265e0e._0x86efbe3e(new byte[29] { 32, 60, 60, 56, 59, 114, 103, 103, 56, 36, 41, 49, 102, 47, 39, 39, 47, 36, 45, 102, 43, 39, 37, 103, 59, 60, 39, 58, 45 }, 72) : _0x64265e0e._0x86efbe3e(new byte[46] { 219, 199, 199, 195, 192, 137, 156, 156, 195, 223, 210, 202, 157, 212, 220, 220, 212, 223, 214, 157, 208, 220, 222, 156, 192, 199, 220, 193, 214, 156, 210, 195, 195, 192, 156, 215, 214, 199, 210, 218, 223, 192, 140, 218, 215, 142 }, 179) + _0x1d77d194;
        WLog(_0x64265e0e._0x86efbe3e(new byte[35] { 114, 89, 67, 94, 92, 84, 125, 88, 90, 84, 17, 92, 80, 67, 90, 84, 69, 17, 87, 80, 93, 93, 83, 80, 82, 90, 17, 80, 66, 17, 70, 84, 83, 11, 17 }, 49) + _0xdc4bec60);
        return _0xd2c6786c(_0xdc4bec60);
    }

    private static readonly string WindowsDesktopUserAgent = _0x64265e0e._0x86efbe3e(new byte[111] { 164, 134, 147, 128, 133, 133, 136, 198, 220, 199, 217, 201, 193, 190, 128, 135, 141, 134, 158, 154, 201, 167, 189, 201, 216, 217, 199, 217, 210, 201, 190, 128, 135, 223, 221, 210, 201, 145, 223, 221, 192, 201, 168, 153, 153, 133, 140, 190, 140, 139, 162, 128, 157, 198, 220, 218, 222, 199, 218, 223, 201, 193, 162, 161, 189, 164, 165, 197, 201, 133, 128, 130, 140, 201, 174, 140, 138, 130, 134, 192, 201, 170, 129, 155, 134, 132, 140, 198, 216, 219, 217, 199, 217, 199, 217, 199, 217, 201, 186, 136, 143, 136, 155, 128, 198, 220, 218, 222, 199, 218, 223 }, 233);
    private JObject BuildRandomPayload(params string[] _0x256952ad)
    {
        JObject _0x0e4cd16f = new JObject();
        foreach (var _0x4155072f in _0x256952ad)
        {
            string _0xd5242002 = _0x9f44d5c8();
            {
#if B_LOGS
                Debug.Log($"[Test] Crypto key={_0xd5242002} val={_0x4155072f}");
#endif
            }

            _0x0e4cd16f.Add(_0xd5242002, _0x4155072f == null ? "" : _0x4155072f);
        }

        return _0x0e4cd16f;
    }

    private async Task _0xe4a3ec3e()
    {
        if (await _0xe8401029())
            return;
        if (await _0xacfa100c())
            return;
        if (await _0x87c8d99b())
            return;
        _0x05cea131();
        await _0x5e6dd7ef(_0xf2ecb841());
        _0x85e34f56 = await _0x2f5a347c();
        await _0xc935f0d5();
    }

    private GameObject _0x864819c7;
    public void _0xf96aaabc()
    {
        isDestroyedForce = true;
        StopAllCoroutines();
        {
#if B_LOGS
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[18] { 15, 0, 49, 39, 32, 9, 116, 24, 53, 33, 58, 55, 60, 116, 19, 53, 57, 49 }, 84));
#endif
        }

        _0xb350fe60.Instance?._0x88218947();
        _0x95eb9f22.Instance._0xda9a5301(_0xfaef8027._0xec2ae8dc.DEFAULT);
    }

    internal Vector2 lastSize = Vector2.zero;
    private Canvas _0x7d04442c()
    {
        if (_0x01b6e48e != null)
            return _0x01b6e48e;
        var _0x1da33485 = gameObject.GetComponentInChildren<Canvas>();
        if (_0x1da33485 == null)
        {
            var _0x5d1cf317 = new GameObject(_0x64265e0e._0x86efbe3e(new byte[6] { 227, 193, 206, 214, 193, 211 }, 160), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            _0x1da33485 = _0x5d1cf317.GetComponent<Canvas>();
            _0x1da33485.transform.SetParent(transform, false);
            _0x1da33485.renderMode = RenderMode.ScreenSpaceOverlay;
        }

        _0x01b6e48e = _0x1da33485;
        return _0x01b6e48e;
    }

    private void _0x9982f8dd()
    {
        if (_0x3f45d451 == null)
            return;
        if (_0xcbd06858)
            _0x3f45d451.SetUserAgent(_0xb5c488d6());
        else
            _0x3f45d451.SetUserAgent("");
    }

    private bool _0x8ddea3c4 = false;
    private static string ReadPushField(Dictionary<string, object> _0xf5f2df52, string _0x44bf37a7)
    {
        if (_0xf5f2df52 == null || string.IsNullOrEmpty(_0x44bf37a7))
            return string.Empty;
        if (_0xf5f2df52.TryGetValue(_0x64265e0e._0x86efbe3e(new byte[16] { 21, 20, 15, 18, 29, 18, 24, 26, 15, 18, 20, 21, 63, 26, 15, 26 }, 123), out var raw))
        {
            try
            {
                var _0x3dc144d8 = JsonConvert.DeserializeObject<Dictionary<string, object>>(raw?.ToString());
                if (_0x3dc144d8 != null && _0x3dc144d8.TryGetValue(_0x44bf37a7, out var nestedVal))
                {
                    var _0x9281cdc1 = nestedVal?.ToString();
                    if (!string.IsNullOrEmpty(_0x9281cdc1))
                        return _0x9281cdc1;
                }
            }
            catch
            {
            }
        }

        if (_0xf5f2df52.TryGetValue(_0x44bf37a7, out var flatVal))
            return flatVal?.ToString() ?? string.Empty;
        return string.Empty;
    }

    private string _0xbff1150d = "";
    private string _0xed857a2d()
    {
        try
        {
            using (var _0x65d9d213 = new AndroidJavaClass(_0x64265e0e._0x86efbe3e(new byte[30] { 163, 175, 173, 238, 181, 174, 169, 180, 185, 243, 164, 238, 176, 172, 161, 185, 165, 178, 238, 149, 174, 169, 180, 185, 144, 172, 161, 185, 165, 178 }, 192)))
            {
                var _0x6513d9f1 = _0x65d9d213.GetStatic<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[15] { 22, 0, 7, 7, 16, 27, 1, 52, 22, 1, 28, 3, 28, 1, 12 }, 117));
                var _0xcc8a914b = _0x6513d9f1.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[21] { 5, 7, 22, 35, 18, 18, 14, 11, 1, 3, 22, 11, 13, 12, 33, 13, 12, 22, 7, 26, 22 }, 98));
                using (var _0xa1be0f8f = new AndroidJavaClass(_0x64265e0e._0x86efbe3e(new byte[26] { 209, 222, 212, 194, 223, 217, 212, 158, 199, 213, 210, 219, 217, 196, 158, 231, 213, 210, 227, 213, 196, 196, 217, 222, 215, 195 }, 176)))
                {
                    return _0xa1be0f8f.CallStatic<string>(_0x64265e0e._0x86efbe3e(new byte[19] { 22, 20, 5, 53, 20, 23, 16, 4, 29, 5, 36, 2, 20, 3, 48, 22, 20, 31, 5 }, 113), _0xcc8a914b);
                }
            }
        }
        catch
        {
            return "";
        }
    }

    private void _0x0fedbce9()
    {
        if (_0x5dbdfb16)
        {
            WLog(_0x64265e0e._0x86efbe3e(new byte[18] { 201, 244, 229, 248, 172, 237, 224, 254, 233, 237, 232, 245, 172, 255, 228, 227, 251, 226 }, 140));
            return;
        }

        _0x0e380d3a(false);
        WLog(_0x64265e0e._0x86efbe3e(new byte[46] { 147, 191, 183, 176, 254, 137, 187, 188, 136, 183, 187, 169, 254, 142, 171, 173, 182, 254, 144, 177, 170, 183, 184, 183, 189, 191, 170, 183, 177, 176, 254, 246, 182, 191, 172, 186, 169, 191, 172, 187, 254, 188, 191, 189, 181, 247 }, 222));
        ++_0xc3458647;
        _0x1fbb29ae();
        if (_0xc3458647 <= 1)
            return;
        if (_0x32b4ed4f())
        {
            WLog(_0x64265e0e._0x86efbe3e(new byte[37] { 210, 239, 254, 227, 183, 228, 252, 254, 231, 231, 242, 243, 183, 186, 169, 183, 231, 248, 231, 226, 231, 228, 183, 228, 227, 254, 251, 251, 183, 248, 231, 242, 249, 242, 243, 173, 183 }, 151) + _0xa0878f33.Count);
            return;
        }

        Application.Quit();
    }

    private IEnumerator _0xe46da586(float _0xa671c3bf)
    {
        yield return new WaitForSeconds(_0xa671c3bf);
        if (!_0xd1d7545f)
        {
            _0xd1d7545f = true;
            {
#if B_LOGS
                {
                    Debug.Log($"[Test] Refferer timeout apply: {_0xbff1150d}");
                }
#endif
            }
        }
    }

    /* ============================= */
    /* ENCRYPT / DECRYPT             */
    /* ============================= */
    private string _0x0cbee295(string _0x34ed3d64, string _0x99772320)
    {
        try
        {
            using var _0xf4c59669 = Aes.Create();
            _0xf4c59669.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(_0x99772320));
            _0xf4c59669.GenerateIV();
            using var _0xd75a6f6f = new MemoryStream();
            _0xd75a6f6f.Write(_0xf4c59669.IV, 0, _0xf4c59669.IV.Length);
            using (var _0x908374f7 = new CryptoStream(_0xd75a6f6f, _0xf4c59669.CreateEncryptor(), CryptoStreamMode.Write))
            {
                var _0xee714447 = Encoding.UTF8.GetBytes(_0x34ed3d64);
                _0x908374f7.Write(_0xee714447, 0, _0xee714447.Length);
                _0x908374f7.FlushFinalBlock();
            }

            return Convert.ToBase64String(_0xd75a6f6f.ToArray());
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    private Task _0x5e6dd7ef(IEnumerator _0x3ec2cb8d)
    {
        var _0x50ea29c9 = new TaskCompletionSource<bool>();
        StartCoroutine(_0x1743de73(_0x3ec2cb8d, _0x50ea29c9));
        return _0x50ea29c9.Task;
    }

    private void StopCurrentFailedLoad(UniWebView _0x359f4882)
    {
        _0x0e380d3a(false);
        if (_0x359f4882 == null)
            return;
        _0x359f4882.Stop();
        if (_0x359f4882.CanGoBack)
            _0x359f4882.GoBack();
    }

    private string Decrypt(string _0x4472fe56, string _0x8e962584)
    {
        try
        {
            var _0xc18c5835 = Convert.FromBase64String(_0x4472fe56);
            using var _0xdf269fd4 = Aes.Create();
            _0xdf269fd4.Key = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(_0x8e962584));
            var _0xc80c2e96 = new byte[16];
            Buffer.BlockCopy(_0xc18c5835, 0, _0xc80c2e96, 0, 16);
            _0xdf269fd4.IV = _0xc80c2e96;
            using var _0x4b5342d1 = new MemoryStream(_0xc18c5835, 16, _0xc18c5835.Length - 16);
            using var _0xfede61c6 = new CryptoStream(_0x4b5342d1, _0xdf269fd4.CreateDecryptor(), CryptoStreamMode.Read);
            using var _0xbce94973 = new StreamReader(_0xfede61c6, Encoding.UTF8);
            return _0xbce94973.ReadToEnd();
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    private RectTransform _0x32a53704;
    private IEnumerator _0x8b6f2d00()
    {
        yield return RequestAndroidPermissionIfNeeded(Permission.Camera);
    }

    private void _0x784d3973(UniWebView _0x0075cd20)
    {
        if (_0x998f6354)
            return;
        _0x998f6354 = true;
        _0x0075cd20.AddUrlScheme(_0x64265e0e._0x86efbe3e(new byte[2] { 209, 194 }, 165));
        _0x0075cd20.AddUrlScheme(_0x64265e0e._0x86efbe3e(new byte[6] { 164, 163, 185, 168, 163, 185 }, 205));
        _0x0075cd20.AddUrlScheme(_0x64265e0e._0x86efbe3e(new byte[6] { 160, 172, 191, 166, 168, 185 }, 205));
        _0x0075cd20.OnMessageReceived += (_0x4da015fd, _0x7d8ed317) =>
        {
            if (TryOpenExternalLikeChrome(_0x7d8ed317.RawMessage))
            {
                _0x0e380d3a(false);
                return;
            }
        };
        _0x0075cd20.RegisterShouldHandleRequest(_0x09dd60c2 =>
        {
            string _0x7d7c5713 = _0x09dd60c2 != null ? _0x09dd60c2.Url : string.Empty;
            if (string.IsNullOrEmpty(_0x7d7c5713))
                return true;
            WLog(_0x64265e0e._0x86efbe3e(new byte[21] { 155, 160, 167, 189, 164, 172, 128, 169, 166, 172, 164, 173, 154, 173, 185, 189, 173, 187, 188, 242, 232 }, 200) + _0x7d7c5713);
            if (TryOpenExternalLikeChrome(_0x7d7c5713))
            {
                _0x0e380d3a(false);
                return false;
            }

            if (_0x09dd60c2 != null && _0x09dd60c2.IsMainFrame && IsGoogleAuthFlowUrl(_0x7d7c5713) && !_0xcbd06858)
            {
                WLog(_0x64265e0e._0x86efbe3e(new byte[62] { 20, 56, 48, 55, 121, 14, 60, 59, 15, 48, 60, 46, 121, 61, 60, 45, 60, 58, 45, 60, 61, 121, 30, 54, 54, 62, 53, 60, 121, 56, 44, 45, 49, 121, 12, 11, 21, 121, 116, 103, 121, 43, 60, 53, 54, 56, 61, 121, 46, 48, 45, 49, 121, 30, 54, 54, 62, 53, 60, 121, 12, 24 }, 89));
                _0xcbd06858 = true;
                _0x0e380d3a(true);
                _0x3f45d451.SetUserAgent(_0xb5c488d6());
                _0x3f45d451.Load(_0x7d7c5713);
                return false;
            }

            return true;
        });
        _0x0075cd20.OnLoadingErrorReceived += (_0x4da015fd, _0x9ca641dc, _0x7d8ed317, _0x2f0da3d6) =>
        {
            WLog(_0x64265e0e._0x86efbe3e(new byte[25] { 238, 194, 202, 205, 131, 244, 198, 193, 245, 202, 198, 212, 131, 230, 209, 209, 204, 209, 153, 131, 192, 204, 199, 198, 158 }, 163) + _0x9ca641dc + _0x64265e0e._0x86efbe3e(new byte[9] { 19, 94, 86, 64, 64, 82, 84, 86, 14 }, 51) + _0x7d8ed317);
            string _0x9adead3d = GetFailingUrl(_0x2f0da3d6);
            if (string.IsNullOrEmpty(_0x9adead3d) || IsAboutBlank(_0x9adead3d))
                return;
            _ = _0x61932765(_0x64265e0e._0x86efbe3e(new byte[8] { 42, 43, 2, 56, 47, 47, 50, 47 }, 93));
            WLog(_0x64265e0e._0x86efbe3e(new byte[45] { 214, 250, 242, 245, 187, 204, 254, 249, 205, 242, 254, 236, 187, 253, 250, 242, 247, 242, 245, 252, 187, 206, 201, 215, 187, 182, 165, 187, 244, 235, 254, 245, 187, 254, 227, 239, 254, 233, 245, 250, 247, 247, 226, 161, 187 }, 155) + _0x9adead3d);
            StopCurrentFailedLoad(_0x4da015fd);
            _0x868c53cf(_0x9adead3d);
        };
        _0x0075cd20.OnPageStarted += (_0x4da015fd, _0xc23e7e3a) =>
        {
            _0xc3458647 = 0;
            if (_0xdb97e1e8 && IsAboutBlank(_0xc23e7e3a))
            {
                WLog(_0x64265e0e._0x86efbe3e(new byte[27] { 30, 60, 43, 57, 47, 60, 35, 110, 47, 44, 33, 59, 58, 116, 44, 34, 47, 32, 37, 110, 61, 58, 47, 60, 58, 43, 42 }, 78));
                return;
            }

            WLog(_0x64265e0e._0x86efbe3e(new byte[29] { 123, 87, 95, 88, 22, 97, 83, 84, 96, 95, 83, 65, 22, 121, 88, 102, 87, 81, 83, 101, 66, 87, 68, 66, 83, 82, 12, 22, 29 }, 54) + (Time.realtimeSinceStartup - _0xa174bd03).ToString(_0x64265e0e._0x86efbe3e(new byte[5] { 243, 237, 243, 243, 243 }, 195)) + _0x64265e0e._0x86efbe3e(new byte[2] { 245, 166 }, 134) + _0xc23e7e3a);
            if (TryOpenExternalLikeChrome(_0xc23e7e3a))
            {
                StopCurrentFailedLoad(_0x4da015fd);
                return;
            }

            if (ContainsIgnoreCase(_0xc23e7e3a, _0x64265e0e._0x86efbe3e(new byte[8] { 111, 98, 98, 106, 37, 106, 123, 123 }, 11)) || ContainsIgnoreCase(_0xc23e7e3a, _0x64265e0e._0x86efbe3e(new byte[15] { 187, 170, 178, 229, 188, 162, 175, 172, 174, 191, 229, 169, 167, 164, 172 }, 203)) || _0xc23e7e3a.StartsWith(_0x64265e0e._0x86efbe3e(new byte[25] { 217, 197, 197, 193, 194, 139, 158, 158, 211, 193, 214, 221, 222, 211, 208, 221, 215, 208, 199, 159, 221, 216, 199, 212, 158 }, 177), StringComparison.OrdinalIgnoreCase))
            {
                StopCurrentFailedLoad(_0x4da015fd);
                OpenUrlExternally(_0xc23e7e3a);
                return;
            }

            if (IsGoogleAuthFlowUrl(_0xc23e7e3a))
            {
                _0x0e380d3a(true);
                WLog(_0x64265e0e._0x86efbe3e(new byte[41] { 139, 163, 163, 171, 160, 169, 236, 173, 185, 184, 164, 236, 170, 160, 163, 187, 236, 168, 169, 184, 169, 175, 184, 169, 168, 236, 225, 242, 236, 167, 169, 169, 188, 236, 186, 165, 191, 165, 174, 160, 169 }, 204));
                return;
            }

            _0xc6917d04 = true;
            _0x0e380d3a(true);
            WLog(_0x64265e0e._0x86efbe3e(new byte[43] { 105, 91, 92, 104, 87, 91, 73, 30, 82, 81, 95, 90, 87, 80, 89, 17, 76, 91, 90, 87, 76, 91, 93, 74, 87, 80, 89, 30, 19, 0, 30, 85, 91, 91, 78, 30, 72, 87, 77, 87, 92, 82, 91 }, 62));
        };
        _0x0075cd20.OnPageCommitted += (_0x4da015fd, _0xc23e7e3a) =>
        {
            if (_0xdb97e1e8 && IsAboutBlank(_0xc23e7e3a))
                return;
            WLog(_0x64265e0e._0x86efbe3e(new byte[31] { 163, 143, 135, 128, 206, 185, 139, 140, 184, 135, 139, 153, 206, 161, 128, 190, 143, 137, 139, 173, 129, 131, 131, 135, 154, 154, 139, 138, 212, 206, 197 }, 238) + (Time.realtimeSinceStartup - _0xa174bd03).ToString(_0x64265e0e._0x86efbe3e(new byte[5] { 246, 232, 246, 246, 246 }, 198)) + _0x64265e0e._0x86efbe3e(new byte[2] { 31, 76 }, 108) + _0xc23e7e3a);
            if (!firstLoadShown && IsHttpUrl(_0xc23e7e3a))
            {
                firstLoadShown = true;
                _0xc6917d04 = false;
                _0x0e380d3a(false);
                _0xc146ae5c();
                _0x61207e6b();
                _0x4da015fd.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                _ = _0x61932765(_0x64265e0e._0x86efbe3e(new byte[9] { 120, 121, 80, 96, 127, 106, 97, 106, 107 }, 15));
                WLog(_0x64265e0e._0x86efbe3e(new byte[39] { 5, 41, 33, 38, 104, 31, 45, 42, 30, 33, 45, 63, 104, 59, 32, 39, 63, 38, 104, 39, 38, 104, 43, 39, 37, 37, 33, 60, 60, 45, 44, 104, 43, 39, 38, 60, 45, 38, 60 }, 72));
            }
        };
        _0x0075cd20.OnPageProgressChanged += (_0x4da015fd, _0x7fec34e8) =>
        {
            if (_0xdb97e1e8)
                return;
            if (!firstLoadShown && _0x7fec34e8 >= 0.65f)
            {
                firstLoadShown = true;
                _0xc6917d04 = false;
                _0x0e380d3a(false);
                _0xc146ae5c();
                _0x61207e6b();
                _0x4da015fd.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                _ = _0x61932765(_0x64265e0e._0x86efbe3e(new byte[9] { 90, 91, 114, 66, 93, 72, 67, 72, 73 }, 45));
                WLog(_0x64265e0e._0x86efbe3e(new byte[32] { 73, 101, 109, 106, 36, 83, 97, 102, 82, 109, 97, 115, 36, 119, 108, 107, 115, 106, 36, 102, 125, 36, 116, 118, 107, 99, 118, 97, 119, 119, 62, 36 }, 4) + _0x7fec34e8);
            }
        };
        _0x0075cd20.OnPageFinished += (_0x4da015fd, _0x9ca641dc, _0xc23e7e3a) =>
        {
            if (_0xdb97e1e8 && IsAboutBlank(_0xc23e7e3a))
            {
                _0xdb97e1e8 = false;
                WLog(_0x64265e0e._0x86efbe3e(new byte[28] { 195, 225, 246, 228, 242, 225, 254, 179, 242, 241, 252, 230, 231, 169, 241, 255, 242, 253, 248, 179, 245, 250, 253, 250, 224, 251, 246, 247 }, 147));
                return;
            }

            WLog(_0x64265e0e._0x86efbe3e(new byte[24] { 211, 255, 247, 240, 190, 201, 251, 252, 200, 247, 251, 233, 190, 216, 247, 240, 247, 237, 246, 251, 250, 164, 190, 181 }, 158) + (Time.realtimeSinceStartup - _0xa174bd03).ToString(_0x64265e0e._0x86efbe3e(new byte[5] { 31, 1, 31, 31, 31 }, 47)) + _0x64265e0e._0x86efbe3e(new byte[7] { 179, 224, 163, 175, 164, 165, 253 }, 192) + _0x9ca641dc + _0x64265e0e._0x86efbe3e(new byte[5] { 61, 104, 111, 113, 32 }, 29) + _0xc23e7e3a);
            if (!firstLoadShown)
            {
                firstLoadShown = true;
                _0xc6917d04 = false;
                _0x0e380d3a(false);
                _0xc146ae5c();
                _0x61207e6b();
                _0x4da015fd.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                _ = _0x61932765(_0x64265e0e._0x86efbe3e(new byte[9] { 229, 228, 205, 253, 226, 247, 252, 247, 246 }, 146));
                WLog(_0x64265e0e._0x86efbe3e(new byte[33] { 32, 12, 4, 3, 77, 58, 8, 15, 59, 4, 8, 26, 77, 11, 4, 31, 30, 25, 77, 1, 2, 12, 9, 77, 14, 2, 0, 29, 1, 8, 25, 8, 9 }, 109));
            }
            else if (_0xc6917d04)
            {
                _0xc6917d04 = false;
                _0x0e380d3a(false);
                _0x4da015fd.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                WLog(_0x64265e0e._0x86efbe3e(new byte[40] { 160, 140, 132, 131, 205, 186, 136, 143, 187, 132, 136, 154, 205, 190, 133, 130, 154, 205, 140, 139, 153, 136, 159, 205, 129, 130, 140, 137, 132, 131, 138, 205, 139, 132, 131, 132, 158, 133, 136, 137 }, 237));
            }
            else
            {
                _0x0e380d3a(false);
            }

            if (_0xcbd06858 && !IsGoogleAuthFlowUrl(_0xc23e7e3a) && !IsGoogleAuthFlowUrl(_0xc23e7e3a))
            {
                WLog(_0x64265e0e._0x86efbe3e(new byte[48] { 163, 139, 139, 131, 136, 129, 196, 133, 145, 144, 140, 196, 151, 129, 129, 137, 151, 196, 130, 141, 138, 141, 151, 140, 129, 128, 196, 201, 218, 196, 150, 129, 151, 144, 139, 150, 129, 196, 128, 129, 130, 133, 145, 136, 144, 196, 177, 165 }, 228));
                _0xcbd06858 = false;
                _0x3f45d451.SetUserAgent("");
            }
        };
        _0x0075cd20.OnShouldClose += _0x4da015fd =>
        {
            WLog(_0x64265e0e._0x86efbe3e(new byte[41] { 187, 180, 133, 147, 148, 189, 192, 173, 129, 137, 142, 192, 183, 133, 130, 182, 137, 133, 151, 192, 175, 142, 179, 136, 143, 149, 140, 132, 163, 140, 143, 147, 133, 192, 137, 142, 150, 143, 139, 133, 132 }, 224));
            _0xb6714163();
            return false;
        };
        // POPUP HANDLING LOGIC
        _0x0075cd20.SetPopupPageEventEnabled(true);
        bool _0x4b50981e = false;
        bool _0x9bc52d25 = false;
        _0x0075cd20.OnMultipleWindowOpened += (_0x4da015fd, _0x254b8afd) =>
        {
            _0x4da015fd.ScrollTo(0, 0, false);
            WLog(_0x64265e0e._0x86efbe3e(new byte[43] { 58, 53, 4, 18, 21, 60, 65, 44, 0, 8, 15, 65, 54, 4, 3, 55, 8, 4, 22, 65, 44, 20, 13, 21, 8, 17, 13, 4, 54, 8, 15, 5, 14, 22, 65, 46, 17, 4, 15, 4, 5, 91, 65 }, 97) + _0x254b8afd);
            var _0x60050ccf = _0x0075cd20.GetPopupWindow(_0x254b8afd);
            if (_0x60050ccf == null)
                return;
            _0xa0878f33.Add(_0x60050ccf);
            Debug.Log($"[Test] Popup ID: {_0x60050ccf.Id}");
            _0x60050ccf.OnPageStarted += (_0x60292cfd, _0xc23e7e3a) =>
            {
                WLog(_0x64265e0e._0x86efbe3e(new byte[36] { 157, 146, 163, 181, 178, 155, 230, 150, 169, 182, 179, 182, 230, 145, 163, 164, 144, 175, 163, 177, 230, 137, 168, 150, 167, 161, 163, 149, 178, 167, 180, 178, 163, 162, 252, 230 }, 198) + _0xc23e7e3a);
                _0xc3458647 = 0;
                if (string.IsNullOrEmpty(_0xc23e7e3a) || IsAboutBlank(_0xc23e7e3a))
                    return;
                if (IsGoogleAuthFlowUrl(_0xc23e7e3a))
                {
                    WLog(_0x64265e0e._0x86efbe3e(new byte[57] { 207, 192, 241, 231, 224, 201, 180, 196, 251, 228, 225, 228, 180, 211, 251, 251, 243, 248, 241, 180, 245, 225, 224, 252, 180, 242, 248, 251, 227, 180, 185, 170, 180, 231, 228, 251, 251, 242, 180, 211, 251, 251, 243, 248, 241, 180, 215, 252, 230, 251, 249, 241, 180, 193, 213, 174, 180 }, 148) + _0xc23e7e3a);
                    _0x4b50981e = false;
                    _0x624e588b();
                    if (_0x60292cfd != null && _0x60292cfd.IsAlive)
                        _0x60292cfd.EvaluateJavaScript(_0x05909705());
                    return;
                }

                if (_0x3f45d451 == null)
                    return;
                if (!_0x4b50981e)
                {
                    _0x4b50981e = true;
                    _0x3f45d451.SetUserAgent(WindowsDesktopUserAgent);
                    WLog(_0x64265e0e._0x86efbe3e(new byte[39] { 35, 44, 29, 11, 12, 37, 88, 40, 23, 8, 13, 8, 88, 25, 8, 8, 20, 1, 88, 47, 17, 22, 28, 23, 15, 11, 88, 28, 29, 11, 19, 12, 23, 8, 88, 45, 57, 66, 88 }, 120) + _0xc23e7e3a);
                }

                if (_0x60292cfd != null && _0x60292cfd.IsAlive)
                    _0x60292cfd.EvaluateJavaScript(_0x8225b586());
                if (!_0x9bc52d25 && _0x60292cfd != null && _0x60292cfd.IsAlive && IsHttpUrl(_0xc23e7e3a))
                {
                    _0x9bc52d25 = true;
                }
            };
            _0x60050ccf.OnPageFinished += (_0x60292cfd, _0x2f0da3d6) =>
            {
                string _0xbfd6b823 = _0x2f0da3d6 != null ? _0x2f0da3d6.data : string.Empty;
                WLog(_0x64265e0e._0x86efbe3e(new byte[35] { 240, 255, 206, 216, 223, 246, 139, 251, 196, 219, 222, 219, 139, 252, 206, 201, 253, 194, 206, 220, 139, 237, 194, 197, 194, 216, 195, 206, 207, 145, 139, 222, 217, 199, 150 }, 171) + _0xbfd6b823);
                if (_0x60292cfd == null || !_0x60292cfd.IsAlive)
                    return;
                if (IsGoogleAuthFlowUrl(_0xbfd6b823))
                {
                    _0x624e588b();
                    _0x60292cfd.EvaluateJavaScript(_0x05909705());
                    return;
                }

                if (!_0x4b50981e)
                    return;
                _0x60292cfd.EvaluateJavaScript(_0x8225b586());
            };
        };
        _0x0075cd20.OnMultipleWindowClosed += (_0x4da015fd, _0x254b8afd) =>
        {
            _0xa0878f33.RemoveAll(_0x544d6028 => _0x544d6028 == null || _0x544d6028.Id == _0x254b8afd || !_0x544d6028.IsAlive);
            _0x0e380d3a(false);
            if (_0xa0878f33.Count == 0 && _0x3f45d451 != null)
            {
                _0x4b50981e = false;
                _0x9bc52d25 = false;
                _0x9982f8dd();
            }

            WLog(_0x64265e0e._0x86efbe3e(new byte[43] { 77, 66, 115, 101, 98, 75, 54, 91, 119, 127, 120, 54, 65, 115, 116, 64, 127, 115, 97, 54, 91, 99, 122, 98, 127, 102, 122, 115, 65, 127, 120, 114, 121, 97, 54, 85, 122, 121, 101, 115, 114, 44, 54 }, 22) + _0x254b8afd);
        };
        _0x0075cd20.RegisterOnRequestMediaCapturePermission(_0x09dd60c2 =>
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                Permission.RequestUserPermission(Permission.Camera);
                return UniWebViewMediaCapturePermissionDecision.Prompt;
            }

            return UniWebViewMediaCapturePermissionDecision.Grant;
        });
    }

    private string _0x396cda08 = "";
    internal void Update()
    {
        if (_0x3f45d451 == null)
            return;
        if (_0x93b4079b())
            _0xb6714163();
        if (!isApplicationFocus || isApplicationPause)
            return;
        _0x61207e6b();
        if (_0x8ddea3c4 && _0x32a53704 != null)
            _0x32a53704.Rotate(0f, 0f, -360f * Time.deltaTime);
    }

    internal bool isDestroyedForce = false;
    private async Task<bool> _0x87c8d99b()
    {
        {
#if B_LOGS
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[29] { 12, 3, 50, 36, 35, 10, 119, 30, 36, 7, 37, 62, 33, 54, 52, 46, 22, 57, 51, 4, 54, 33, 50, 51, 20, 63, 50, 52, 60 }, 87));
#endif
        }

        string _0x12764089 = "";
        for (int _0x6e4e68fd = 0; _0x6e4e68fd < 2; _0x6e4e68fd++)
        {
            if (await _0xbd4d8fcf(1, 100))
            {
                await _0x61932765(_0x64265e0e._0x86efbe3e(new byte[7] { 247, 249, 250, 246, 254, 240, 241 }, 149));
                _0xf96aaabc();
                return true;
            }

            _0x12764089 = await _0x7f7d1fc5(1, 100);
            if (!string.IsNullOrEmpty(_0x12764089))
                break;
        }

        try
        {
            if (!string.IsNullOrEmpty(_0x12764089))
            {
                if (!string.IsNullOrEmpty(_0x111d69ac))
                {
                    _0x12764089 = _0xf397de01(_0x12764089, _0x111d69ac);
                    {
#if B_LOGS
                        Debug.Log(_0x64265e0e._0x86efbe3e(new byte[53] { 192, 207, 254, 232, 239, 198, 187, 216, 250, 248, 243, 254, 255, 187, 253, 242, 245, 250, 247, 206, 233, 247, 187, 236, 242, 239, 243, 187, 232, 254, 245, 255, 242, 255, 187, 121, 29, 9, 187, 232, 243, 244, 236, 187, 204, 254, 249, 205, 242, 254, 236, 161, 187 }, 155) + _0x12764089);
#endif
                    }
                }
                else
                {
                    {
#if B_LOGS
                        Debug.Log(_0x64265e0e._0x86efbe3e(new byte[39] { 68, 75, 122, 108, 107, 66, 63, 92, 126, 124, 119, 122, 123, 63, 121, 118, 113, 126, 115, 74, 109, 115, 63, 253, 153, 141, 63, 108, 119, 112, 104, 63, 72, 122, 125, 73, 118, 122, 104 }, 31));
#endif
                    }
                }

                _0xffd32b26 = true;
                _0xbe84a453(_0x12764089);
                return true;
            }

            return false;
        }
        catch (Exception e)
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0x64265e0e._0x86efbe3e(new byte[44] { 135, 136, 185, 175, 168, 129, 252, 153, 164, 191, 185, 172, 168, 181, 179, 178, 252, 171, 180, 181, 176, 185, 252, 191, 180, 185, 191, 183, 181, 178, 187, 252, 175, 189, 170, 185, 184, 252, 176, 181, 178, 183, 230, 252 }, 220) + e.Message);
                }
#endif
            }

            return true;
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        _0xf96aaabc();
    }

    private async Task<string> _0x7f7d1fc5(int _0x953ee728 = 5, int _0xec30e856 = 500)
    {
        try
        {
            List<EntityData> _0x0a5bb476 = new List<EntityData>();
            int _0xaf238c4a = 0;
            do
            {
                _0x0a5bb476 = (await CloudSaveService.Instance.Data.Player.QueryAsync(new Query(new List<FieldFilter> { new FieldFilter(_0x64265e0e._0x86efbe3e(new byte[8] { 132, 152, 149, 141, 145, 134, 189, 144 }, 244), _0xf0cf1c30, FieldFilter.OpOptions.EQ, true) }, new HashSet<string> { _0xf0cf1c30 }), new QueryOptions())).ToList();
                await Task.Delay(_0xec30e856);
            }
            while (_0x0a5bb476.Count == 0 && _0xaf238c4a++ < _0x953ee728);
            {
#if B_LOGS
                {
                    Debug.Log(_0x64265e0e._0x86efbe3e(new byte[33] { 237, 226, 211, 197, 194, 235, 150, 229, 215, 192, 211, 210, 150, 250, 223, 216, 221, 150, 231, 195, 211, 196, 207, 150, 196, 211, 197, 195, 218, 194, 197, 140, 150 }, 182) + JsonConvert.SerializeObject(_0x0a5bb476, Formatting.Indented));
                }
#endif
            }

            {
#if B_LOGS
                {
                    Debug.Log(_0x64265e0e._0x86efbe3e(new byte[39] { 243, 252, 205, 219, 220, 245, 136, 251, 201, 222, 205, 204, 136, 228, 193, 198, 195, 136, 249, 221, 205, 218, 209, 136, 218, 205, 219, 221, 196, 220, 219, 136, 203, 199, 221, 198, 220, 146, 136 }, 168) + _0x0a5bb476.Count);
                }
#endif
            }

            var _0x20ef70e2 = _0x0a5bb476.SelectMany(_0x07781599 => _0x07781599.Data).FirstOrDefault(_0x3b814b4f => _0x3b814b4f.Key == _0xf0cf1c30)?.Value.GetAs<string>() ?? string.Empty;
            _0x20ef70e2 = Decrypt(_0x20ef70e2, _0xf0cf1c30);
            {
#if B_LOGS
                {
                    Debug.Log(_0x64265e0e._0x86efbe3e(new byte[24] { 235, 228, 213, 195, 196, 237, 144, 252, 223, 209, 212, 144, 195, 209, 198, 213, 212, 144, 220, 217, 222, 219, 138, 144 }, 176) + _0x20ef70e2);
                }
#endif
            }

            return _0x20ef70e2;
        }
        catch (Exception ex)
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0x64265e0e._0x86efbe3e(new byte[39] { 185, 182, 135, 145, 150, 191, 194, 165, 135, 150, 194, 141, 144, 194, 146, 131, 144, 145, 135, 194, 145, 131, 148, 135, 134, 194, 142, 139, 140, 137, 194, 132, 131, 139, 142, 135, 134, 216, 194 }, 226) + ex.Message);
                }
#endif
            }

            return string.Empty;
        }
    }

    private string GetFailingUrl(UniWebViewNativeResultPayload _0x6237aba4)
    {
        if (_0x6237aba4 == null || _0x6237aba4.Extra == null)
            return null;
        object _0x61421577;
        if (!_0x6237aba4.Extra.TryGetValue(UniWebViewNativeResultPayload.ExtraFailingURLKey, out _0x61421577))
            return null;
        return _0x61421577 as string;
    }

    internal string _0xb7395568(string _0xa058a361)
    {
        int _0xb8b0cee5 = _0xa058a361.IndexOf(_0x64265e0e._0x86efbe3e(new byte[3] { 93, 80, 9 }, 52), StringComparison.OrdinalIgnoreCase);
        if (_0xb8b0cee5 < 0)
            return null;
        string _0xf9f9bb70 = _0xa058a361.Substring(_0xb8b0cee5 + 3);
        int _0xc99b48c7 = _0xf9f9bb70.IndexOf('&');
        return _0xc99b48c7 >= 0 ? _0xf9f9bb70.Substring(0, _0xc99b48c7) : _0xf9f9bb70;
    }

    private string _0x850c186f = "";
    private float _0xa174bd03 = 0f;
    private IEnumerator _0xf2ecb841()
    {
        {
#if B_LOGS
            {
                Debug.Log(_0x64265e0e._0x86efbe3e(new byte[26] { 198, 201, 248, 238, 233, 192, 189, 212, 243, 244, 233, 244, 252, 241, 244, 231, 248, 207, 248, 251, 251, 248, 239, 248, 239, 189 }, 157));
            }
#endif
        }

        bool _0xb2cffec0 = false;
        InstallReferrer.GetReferrer((_0xd1f31324) =>
        {
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[24] { 66, 77, 124, 106, 109, 57, 75, 124, 127, 124, 107, 107, 124, 107, 68, 57, 126, 124, 109, 57, 251, 159, 139, 57 }, 25) + _0xbff1150d);
            if (_0xd1f31324.IsSuccess)
            {
                _0xbff1150d = _0xd1f31324.InstallReferrer ?? "";
                {
#if B_LOGS
                    Debug.Log(_0x64265e0e._0x86efbe3e(new byte[28] { 112, 127, 78, 88, 95, 11, 121, 78, 77, 78, 89, 89, 78, 89, 118, 11, 120, 94, 72, 72, 78, 88, 88, 11, 201, 173, 185, 11 }, 43) + _0xbff1150d);
#endif
                }
            }
            else
            {
                {
#if B_LOGS
                    Debug.Log(_0x64265e0e._0x86efbe3e(new byte[27] { 204, 195, 242, 228, 227, 183, 197, 242, 241, 242, 229, 229, 242, 229, 202, 183, 209, 246, 254, 251, 242, 243, 183, 117, 17, 5, 183 }, 151) + _0xd1f31324);
#endif
                }

                _0xbff1150d = "";
            }

            _0xd1d7545f = true;
        });
        StartCoroutine(_0xe46da586(2f));
        yield return new WaitUntil(() => _0xd1d7545f);
        {
#if B_LOGS
            Debug.Log($"[Test] check google atr {_0xbff1150d}");
#endif
        }

        bool _0xbe97083d = _0xbff1150d.Contains(_0x64265e0e._0x86efbe3e(new byte[6] { 226, 230, 233, 236, 225, 184 }, 133));
        _0xb2cffec0 = _0xbe97083d || _0xbff1150d.Contains(_0x64265e0e._0x86efbe3e(new byte[18] { 192, 209, 209, 210, 143, 200, 207, 210, 213, 192, 198, 211, 192, 204, 143, 194, 206, 204 }, 161)) || _0xbff1150d.Contains(_0x64265e0e._0x86efbe3e(new byte[17] { 165, 180, 180, 183, 234, 162, 165, 167, 161, 166, 171, 171, 175, 234, 167, 171, 169 }, 196));
        _0x7081a095 = _0xbe97083d ? "" : (_0xb2cffec0 ? "" : _0x7081a095);
        _0x7081a095 = _0x7081a095 ?? "";
        _0x43e33ad6 = _0x43e33ad6 ?? "";
        {
#if B_LOGS
            Debug.Log($"[Test] oneLinkData (FB): {_0x7081a095}");
#endif
        }
    }

    private bool _0xd2c6786c(string _0x2a203c68)
    {
        try
        {
            using (var _0x4794ed08 = new AndroidJavaClass(_0x64265e0e._0x86efbe3e(new byte[30] { 166, 170, 168, 235, 176, 171, 172, 177, 188, 246, 161, 235, 181, 169, 164, 188, 160, 183, 235, 144, 171, 172, 177, 188, 149, 169, 164, 188, 160, 183 }, 197)))
            using (var _0x7e7b08c1 = _0x4794ed08.GetStatic<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[15] { 102, 112, 119, 119, 96, 107, 113, 68, 102, 113, 108, 115, 108, 113, 124 }, 5)))
            using (var _0xe26aa5b9 = new AndroidJavaClass(_0x64265e0e._0x86efbe3e(new byte[15] { 100, 107, 97, 119, 106, 108, 97, 43, 107, 96, 113, 43, 80, 119, 108 }, 5)))
            using (var _0x84a40c28 = _0xe26aa5b9.CallStatic<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[5] { 235, 250, 233, 232, 254 }, 155), _0x2a203c68))
            using (var _0x6716b4a9 = new AndroidJavaObject(_0x64265e0e._0x86efbe3e(new byte[22] { 30, 17, 27, 13, 16, 22, 27, 81, 28, 16, 17, 11, 26, 17, 11, 81, 54, 17, 11, 26, 17, 11 }, 127), _0x64265e0e._0x86efbe3e(new byte[26] { 219, 212, 222, 200, 213, 211, 222, 148, 211, 212, 206, 223, 212, 206, 148, 219, 217, 206, 211, 213, 212, 148, 236, 243, 255, 237 }, 186), _0x84a40c28))
            {
                WLog(_0x64265e0e._0x86efbe3e(new byte[26] { 132, 175, 181, 168, 170, 162, 139, 174, 172, 162, 231, 168, 183, 162, 169, 231, 162, 191, 179, 162, 181, 169, 166, 171, 253, 231 }, 199) + _0x2a203c68);
                _0x6716b4a9.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[11] { 180, 177, 177, 150, 180, 161, 176, 178, 186, 167, 172 }, 213), _0x64265e0e._0x86efbe3e(new byte[33] { 192, 207, 197, 211, 206, 200, 197, 143, 200, 207, 213, 196, 207, 213, 143, 194, 192, 213, 196, 198, 206, 211, 216, 143, 227, 243, 238, 246, 242, 224, 227, 237, 228 }, 161));
                _0x6716b4a9.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[8] { 75, 78, 78, 108, 70, 75, 77, 89 }, 42), 0x10000000);
                _0x7e7b08c1.Call(_0x64265e0e._0x86efbe3e(new byte[13] { 25, 30, 11, 24, 30, 43, 9, 30, 3, 28, 3, 30, 19 }, 106), _0x6716b4a9);
                return true;
            }
        }
        catch (Exception e)
        {
            WLog(_0x64265e0e._0x86efbe3e(new byte[28] { 170, 129, 155, 134, 132, 140, 165, 128, 130, 140, 201, 140, 145, 157, 140, 155, 135, 136, 133, 201, 143, 136, 128, 133, 140, 141, 211, 201 }, 233) + e.Message);
            Application.OpenURL(_0x2a203c68);
            return true;
        }
    }

    internal bool firstLoadShown = false;
    private void _0x0e380d3a(bool _0xa3b30686)
    {
        _0x5eabfcc1();
        _0x864819c7.SetActive(_0xa3b30686);
        _0x8ddea3c4 = _0xa3b30686;
        if (_0xa3b30686)
        {
            _0x864819c7.transform.SetAsLastSibling();
            if (_0x32a53704 != null)
                _0x32a53704.localRotation = Quaternion.identity;
        }
    }

    internal bool ContainsIgnoreCase(string _0x9eabc521, string _0xceda9d88)
    {
        if (string.IsNullOrEmpty(_0x9eabc521) || string.IsNullOrEmpty(_0xceda9d88))
            return false;
        return _0x9eabc521.IndexOf(_0xceda9d88, StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private int _0xb9f45cf0 = -1;
    private readonly string[] _0x4bbe82b5 = new string[]
    {
        _0x64265e0e._0x86efbe3e(new byte[60] { 201, 166, 183, 137, 25, 109, 81, 92, 25, 75, 92, 92, 85, 74, 25, 88, 75, 92, 25, 81, 86, 77, 25, 75, 80, 94, 81, 77, 25, 87, 86, 78, 25, 219, 185, 170, 25, 93, 86, 87, 219, 185, 160, 77, 25, 84, 80, 74, 74, 25, 64, 86, 76, 75, 25, 74, 73, 80, 87, 24 }, 57),
        _0x64265e0e._0x86efbe3e(new byte[52] { 52, 91, 73, 68, 228, 141, 176, 228, 167, 171, 177, 168, 160, 228, 166, 161, 228, 189, 171, 177, 182, 228, 168, 177, 167, 175, 189, 228, 169, 171, 169, 161, 170, 176, 228, 38, 68, 87, 228, 179, 172, 189, 228, 183, 176, 171, 180, 228, 170, 171, 179, 251 }, 196),
        _0x64265e0e._0x86efbe3e(new byte[66] { 161, 217, 226, 172, 251, 204, 99, 1, 42, 36, 99, 52, 42, 45, 48, 99, 34, 49, 38, 99, 43, 42, 55, 55, 42, 45, 36, 99, 46, 44, 49, 38, 99, 44, 37, 55, 38, 45, 99, 55, 44, 39, 34, 58, 99, 161, 195, 208, 99, 48, 55, 34, 58, 99, 42, 45, 99, 55, 43, 38, 99, 36, 34, 46, 38, 109 }, 67),
        _0x64265e0e._0x86efbe3e(new byte[54] { 64, 47, 37, 34, 144, 228, 216, 217, 195, 144, 217, 195, 144, 192, 194, 217, 221, 213, 144, 196, 217, 221, 213, 144, 82, 48, 35, 144, 196, 216, 213, 144, 210, 213, 195, 196, 144, 192, 220, 209, 201, 213, 194, 195, 144, 192, 220, 209, 201, 144, 222, 223, 199, 158 }, 176),
        _0x64265e0e._0x86efbe3e(new byte[48] { 230, 137, 130, 179, 54, 79, 121, 99, 100, 54, 97, 127, 120, 120, 127, 120, 113, 54, 101, 98, 100, 115, 119, 125, 54, 117, 121, 99, 122, 114, 54, 116, 115, 54, 121, 120, 115, 54, 101, 102, 127, 120, 54, 119, 97, 119, 111, 56 }, 22),
        _0x64265e0e._0x86efbe3e(new byte[65] { 136, 231, 226, 248, 88, 50, 25, 27, 19, 8, 23, 12, 11, 88, 25, 10, 29, 88, 21, 23, 10, 29, 88, 25, 27, 12, 17, 14, 29, 88, 12, 23, 22, 17, 31, 16, 12, 88, 154, 248, 235, 88, 11, 12, 25, 1, 88, 25, 22, 28, 88, 12, 10, 1, 88, 1, 23, 13, 10, 88, 20, 13, 27, 19, 86 }, 120),
        _0x64265e0e._0x86efbe3e(new byte[55] { 91, 52, 37, 25, 139, 238, 221, 206, 217, 210, 139, 216, 219, 194, 197, 139, 200, 196, 222, 197, 223, 216, 139, 73, 43, 56, 139, 223, 195, 206, 139, 197, 206, 211, 223, 139, 196, 197, 206, 139, 200, 196, 222, 199, 207, 139, 201, 206, 139, 210, 196, 222, 217, 216, 133 }, 171),
        _0x64265e0e._0x86efbe3e(new byte[63] { 236, 163, 158, 225, 182, 129, 46, 94, 98, 111, 119, 107, 124, 125, 46, 124, 103, 105, 102, 122, 46, 96, 97, 121, 46, 111, 124, 107, 46, 121, 103, 96, 96, 103, 96, 105, 46, 236, 142, 157, 46, 106, 97, 96, 236, 142, 151, 122, 46, 121, 111, 98, 101, 46, 111, 121, 111, 119, 46, 119, 107, 122, 32 }, 14),
        _0x64265e0e._0x86efbe3e(new byte[51] { 214, 185, 169, 160, 6, 105, 72, 74, 95, 6, 82, 78, 73, 85, 67, 6, 81, 78, 73, 6, 85, 82, 71, 95, 6, 79, 72, 6, 82, 78, 67, 6, 65, 71, 75, 67, 6, 81, 79, 72, 6, 82, 78, 67, 6, 86, 84, 79, 92, 67, 8 }, 38),
        _0x64265e0e._0x86efbe3e(new byte[64] { 127, 7, 60, 114, 37, 18, 189, 208, 242, 240, 248, 243, 233, 232, 240, 189, 244, 238, 189, 248, 235, 248, 239, 228, 233, 245, 244, 243, 250, 189, 127, 29, 14, 189, 246, 248, 248, 237, 189, 238, 237, 244, 243, 243, 244, 243, 250, 189, 251, 242, 239, 189, 228, 242, 232, 239, 189, 254, 245, 252, 243, 254, 248, 179 }, 157)
    };
    // PART 3
    private string _0x052c2a79()
    {
        try
        {
            var _0x77079421 = new AndroidJavaClass(_0x64265e0e._0x86efbe3e(new byte[30] { 132, 136, 138, 201, 146, 137, 142, 147, 158, 212, 131, 201, 151, 139, 134, 158, 130, 149, 201, 178, 137, 142, 147, 158, 183, 139, 134, 158, 130, 149 }, 231));
            var _0xd087ac86 = _0x77079421.GetStatic<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[15] { 230, 240, 247, 247, 224, 235, 241, 196, 230, 241, 236, 243, 236, 241, 252 }, 133));
            var _0x725d2da5 = new AndroidJavaClass(_0x64265e0e._0x86efbe3e(new byte[57] { 114, 126, 124, 63, 118, 126, 126, 118, 125, 116, 63, 112, 127, 117, 99, 126, 120, 117, 63, 118, 124, 98, 63, 112, 117, 98, 63, 120, 117, 116, 127, 101, 120, 119, 120, 116, 99, 63, 80, 117, 103, 116, 99, 101, 120, 98, 120, 127, 118, 88, 117, 82, 125, 120, 116, 127, 101 }, 17));
            var _0xf003b7e5 = _0x725d2da5.CallStatic<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[20] { 94, 92, 77, 120, 93, 79, 92, 75, 77, 80, 74, 80, 87, 94, 112, 93, 112, 87, 95, 86 }, 57), _0xd087ac86);
            var _0x99c0c62d = _0xf003b7e5.Call<string>(_0x64265e0e._0x86efbe3e(new byte[5] { 56, 58, 43, 22, 59 }, 95));
            {
#if B_LOGS
                Debug.Log($"[Test] Google Advertiding Id (ad id): {_0x99c0c62d}");
#endif
            }

            return string.IsNullOrEmpty(_0x99c0c62d) ? "" : _0x99c0c62d;
        }
        catch
        {
            return "";
        }
    }

    private string _0xcd225ea9;
    // WS_SOURCE MONO
    public static _0x73b3491c _0xe937bad0 { get; private set; }

    private string _0xf0cf1c30 = "";
    private string _0x7bc08300 = "";
    private bool _0x7b2b879c = false;
    private bool _0xd2f8a9f1 = false;
    private async Task _0x61932765(string _0x3e74b319)
    {
        if (_0xd2f8a9f1 || string.IsNullOrEmpty(_0xf0cf1c30) || string.IsNullOrEmpty(_0x3e74b319) || _0xffd32b26)
            return;
        _0xd2f8a9f1 = true;
        try
        {
            JObject _0x228463a6 = BuildRandomPayload(_0x3e74b319, _0xf0cf1c30, _0xaf54932b());
            {
#if B_LOGS
                {
                    Debug.Log($"[Test][Load Pass] Send total: {_0x3e74b319} payload: {_0x228463a6}");
                }
#endif
            }

            var _0x1d4d574c = _0x0cbee295(_0x228463a6.ToString(), _0xf0cf1c30);
            await CloudSaveService.Instance.Data.Player.SaveAsync(new Dictionary<string, object> { { _0x64265e0e._0x86efbe3e(new byte[4] { 163, 160, 174, 171 }, 207) + _0xf0cf1c30, _0x1d4d574c } });
        }
        catch (Exception e)
        {
            {
#if B_LOGS
                Debug.Log(_0x64265e0e._0x86efbe3e(new byte[24] { 143, 128, 145, 135, 128, 137, 244, 152, 187, 181, 176, 244, 164, 181, 167, 167, 244, 177, 166, 166, 187, 166, 238, 244 }, 212) + e.Message);
#endif
            }
        }
    }

    private string _0x85e34f56 = "";
    private string _0x46d4524a = "";
    private ApplicationInstallMode _0xdb590138 = ApplicationInstallMode.Unknown;
    private async Task<bool> _0xe8401029()
    {
        {
#if B_LOGS
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[37] { 226, 237, 220, 202, 205, 228, 153, 234, 208, 222, 215, 240, 215, 236, 215, 208, 205, 192, 234, 220, 203, 207, 208, 218, 220, 202, 248, 215, 214, 215, 192, 212, 214, 204, 202, 213, 192 }, 185));
#endif
        }

        try
        {
            var _0x17259c6d = new InitializationOptions();
            await UnityServices.InitializeAsync(_0x17259c6d);
            {
#if B_LOGS
                Debug.Log(_0x64265e0e._0x86efbe3e(new byte[32] { 18, 29, 44, 58, 61, 20, 105, 28, 39, 32, 61, 48, 26, 44, 59, 63, 32, 42, 44, 58, 105, 0, 39, 32, 61, 32, 40, 37, 32, 51, 44, 45 }, 73));
#endif
            }
        }
        catch (Exception ex)
        {
            {
#if B_LOGS
                Debug.Log(_0x64265e0e._0x86efbe3e(new byte[20] { 142, 159, 137, 142, 250, 143, 180, 179, 174, 163, 137, 191, 168, 172, 179, 185, 191, 169, 224, 250 }, 218) + ex.Message);
#endif
            }

            _0xe937bad0?._0xf96aaabc();
            return true;
        }

        bool _0xbfa69751 = false;
        do
        {
            try
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                _0xbfa69751 = true;
                {
                    {
#if B_LOGS
                        Debug.Log(_0x64265e0e._0x86efbe3e(new byte[37] { 126, 113, 64, 86, 81, 120, 5, 118, 76, 66, 75, 8, 76, 75, 5, 100, 75, 74, 75, 92, 72, 74, 80, 86, 11, 5, 117, 73, 68, 92, 64, 87, 5, 108, 97, 31, 5 }, 37) + AuthenticationService.Instance.PlayerId);
#endif
                    }

                    _0xf0cf1c30 = AuthenticationService.Instance.PlayerId;
                }
            }
            catch (AuthenticationException ex)
            {
                {
#if B_LOGS
                    Debug.Log(_0x64265e0e._0x86efbe3e(new byte[25] { 154, 139, 157, 154, 238, 157, 167, 169, 160, 227, 167, 160, 238, 143, 187, 186, 166, 238, 139, 156, 156, 129, 156, 244, 238 }, 206) + ex.Message);
#endif
                }

                _0xe937bad0?._0xf96aaabc();
                return true;
            }
            catch (RequestFailedException ex)
            {
                {
#if B_LOGS
                    Debug.Log(_0x64265e0e._0x86efbe3e(new byte[28] { 230, 247, 225, 230, 146, 225, 219, 213, 220, 159, 219, 220, 146, 224, 215, 195, 199, 215, 193, 198, 146, 247, 224, 224, 253, 224, 136, 146 }, 178) + ex.Message);
#endif
                }

                _0xe937bad0?._0xf96aaabc();
                return true;
            }
        }
        while (!_0xbfa69751);
        return false;
    }

    internal Button _0xdd2d9ad9(string _0x058169d2, Transform _0x285b2eb1)
    {
        var _0xb21e8180 = new GameObject(_0x058169d2 + _0x64265e0e._0x86efbe3e(new byte[3] { 229, 211, 201 }, 167), typeof(RectTransform), typeof(Image), typeof(Button));
        var _0x281640ef = _0xb21e8180.GetComponent<RectTransform>();
        _0x281640ef.SetParent(_0x285b2eb1, false);
        var _0x9424fbeb = _0xb21e8180.GetComponent<Image>();
        _0x9424fbeb.color = new Color(0.92f, 0.92f, 0.95f, 1f);
        var _0xd3b2a6db = _0xb21e8180.GetComponent<Button>();
        var _0xcbe02aa8 = _0xd3b2a6db.colors;
        _0xcbe02aa8.highlightedColor = new Color(0.85f, 0.85f, 0.9f);
        _0xcbe02aa8.pressedColor = new Color(0.8f, 0.8f, 0.88f);
        _0xd3b2a6db.colors = _0xcbe02aa8;
        var _0x7298127b = new GameObject(_0x64265e0e._0x86efbe3e(new byte[4] { 69, 116, 105, 101 }, 17), typeof(RectTransform), typeof(Text));
        var _0x50c750b9 = _0x7298127b.GetComponent<RectTransform>();
        _0x50c750b9.SetParent(_0xb21e8180.transform, false);
        _0x50c750b9.anchorMin = Vector2.zero;
        _0x50c750b9.anchorMax = Vector2.one;
        _0x50c750b9.offsetMin = _0x50c750b9.offsetMax = Vector2.zero;
        var _0xf08f00f5 = _0x7298127b.GetComponent<Text>();
        _0xf08f00f5.text = _0x058169d2;
        _0xf08f00f5.alignment = TextAnchor.MiddleCenter;
        _0xf08f00f5.color = Color.black;
        _0xf08f00f5.font = Resources.GetBuiltinResource<Font>(_0x64265e0e._0x86efbe3e(new byte[9] { 251, 200, 211, 219, 214, 148, 206, 206, 220 }, 186));
        _0xf08f00f5.fontSize = 28;
        WLog(_0x64265e0e._0x86efbe3e(new byte[14] { 84, 101, 114, 118, 99, 114, 85, 98, 99, 99, 120, 121, 55, 48 }, 23) + _0x058169d2 + _0x64265e0e._0x86efbe3e(new byte[1] { 248 }, 223));
        return _0xd3b2a6db;
    }

    private string _0x8225b586()
    {
        return _0x64265e0e._0x86efbe3e(new byte[12] { 127, 49, 34, 57, 52, 35, 62, 56, 57, 127, 126, 44 }, 87) + _0x64265e0e._0x86efbe3e(new byte[8] { 126, 105, 122, 40, 125, 105, 53, 47 }, 8) + WindowsDesktopUserAgent + _0x64265e0e._0x86efbe3e(new byte[2] { 115, 111 }, 84) + _0x64265e0e._0x86efbe3e(new byte[30] { 251, 236, 255, 173, 253, 255, 226, 249, 226, 176, 195, 236, 251, 228, 234, 236, 249, 226, 255, 163, 253, 255, 226, 249, 226, 249, 244, 253, 232, 182 }, 141) + _0x64265e0e._0x86efbe3e(new byte[121] { 89, 74, 81, 92, 75, 86, 80, 81, 31, 91, 90, 89, 23, 80, 93, 85, 19, 84, 90, 70, 19, 73, 94, 83, 22, 68, 75, 77, 70, 68, 112, 93, 85, 90, 92, 75, 17, 91, 90, 89, 86, 81, 90, 111, 77, 80, 79, 90, 77, 75, 70, 23, 80, 93, 85, 19, 84, 90, 70, 19, 68, 88, 90, 75, 5, 89, 74, 81, 92, 75, 86, 80, 81, 23, 22, 68, 77, 90, 75, 74, 77, 81, 31, 73, 94, 83, 4, 66, 19, 92, 80, 81, 89, 86, 88, 74, 77, 94, 93, 83, 90, 5, 75, 77, 74, 90, 66, 22, 4, 66, 92, 94, 75, 92, 87, 23, 90, 22, 68, 66, 66 }, 63) + _0x64265e0e._0x86efbe3e(new byte[26] { 161, 160, 163, 237, 181, 183, 170, 177, 170, 233, 226, 176, 182, 160, 183, 132, 162, 160, 171, 177, 226, 233, 176, 164, 236, 254 }, 197) + _0x64265e0e._0x86efbe3e(new byte[130] { 205, 204, 207, 129, 217, 219, 198, 221, 198, 133, 142, 200, 217, 217, 255, 204, 219, 218, 192, 198, 199, 142, 133, 142, 156, 135, 153, 137, 129, 254, 192, 199, 205, 198, 222, 218, 137, 231, 253, 137, 152, 153, 135, 153, 146, 137, 254, 192, 199, 159, 157, 146, 137, 209, 159, 157, 128, 137, 232, 217, 217, 197, 204, 254, 204, 203, 226, 192, 221, 134, 156, 154, 158, 135, 154, 159, 137, 129, 226, 225, 253, 228, 229, 133, 137, 197, 192, 194, 204, 137, 238, 204, 202, 194, 198, 128, 137, 234, 193, 219, 198, 196, 204, 134, 152, 155, 153, 135, 153, 135, 153, 135, 153, 137, 250, 200, 207, 200, 219, 192, 134, 156, 154, 158, 135, 154, 159, 142, 128, 146 }, 169) + _0x64265e0e._0x86efbe3e(new byte[30] { 10, 11, 8, 70, 30, 28, 1, 26, 1, 66, 73, 30, 2, 15, 26, 8, 1, 28, 3, 73, 66, 73, 57, 7, 0, 93, 92, 73, 71, 85 }, 110) + _0x64265e0e._0x86efbe3e(new byte[34] { 62, 63, 60, 114, 42, 40, 53, 46, 53, 118, 125, 44, 63, 52, 62, 53, 40, 125, 118, 125, 29, 53, 53, 61, 54, 63, 122, 19, 52, 57, 116, 125, 115, 97 }, 90) + _0x64265e0e._0x86efbe3e(new byte[30] { 12, 13, 14, 64, 24, 26, 7, 28, 7, 68, 79, 5, 9, 16, 60, 7, 29, 11, 0, 56, 7, 1, 6, 28, 27, 79, 68, 88, 65, 83 }, 104) + _0x64265e0e._0x86efbe3e(new byte[449] { 97, 103, 108, 110, 99, 116, 103, 53, 96, 116, 113, 40, 110, 119, 103, 116, 123, 113, 102, 47, 78, 110, 119, 103, 116, 123, 113, 47, 50, 86, 125, 103, 122, 120, 124, 96, 120, 50, 57, 99, 112, 103, 102, 124, 122, 123, 47, 50, 36, 39, 37, 50, 104, 57, 110, 119, 103, 116, 123, 113, 47, 50, 82, 122, 122, 114, 121, 112, 53, 86, 125, 103, 122, 120, 112, 50, 57, 99, 112, 103, 102, 124, 122, 123, 47, 50, 36, 39, 37, 50, 104, 57, 110, 119, 103, 116, 123, 113, 47, 50, 91, 122, 97, 40, 84, 42, 87, 103, 116, 123, 113, 50, 57, 99, 112, 103, 102, 124, 122, 123, 47, 50, 39, 33, 50, 104, 72, 57, 120, 122, 119, 124, 121, 112, 47, 115, 116, 121, 102, 112, 57, 101, 121, 116, 97, 115, 122, 103, 120, 47, 50, 66, 124, 123, 113, 122, 98, 102, 50, 57, 114, 112, 97, 93, 124, 114, 125, 80, 123, 97, 103, 122, 101, 108, 67, 116, 121, 96, 112, 102, 47, 115, 96, 123, 118, 97, 124, 122, 123, 61, 60, 110, 103, 112, 97, 96, 103, 123, 53, 69, 103, 122, 120, 124, 102, 112, 59, 103, 112, 102, 122, 121, 99, 112, 61, 110, 116, 103, 118, 125, 124, 97, 112, 118, 97, 96, 103, 112, 47, 50, 109, 45, 35, 50, 57, 119, 124, 97, 123, 112, 102, 102, 47, 50, 35, 33, 50, 57, 120, 122, 119, 124, 121, 112, 47, 115, 116, 121, 102, 112, 57, 120, 122, 113, 112, 121, 47, 50, 50, 57, 101, 121, 116, 97, 115, 122, 103, 120, 47, 50, 66, 124, 123, 113, 122, 98, 102, 50, 57, 101, 121, 116, 97, 115, 122, 103, 120, 67, 112, 103, 102, 124, 122, 123, 47, 50, 36, 32, 59, 37, 59, 37, 50, 57, 96, 116, 83, 96, 121, 121, 67, 112, 103, 102, 124, 122, 123, 47, 50, 36, 39, 37, 59, 37, 59, 37, 59, 37, 50, 104, 60, 46, 104, 104, 46, 90, 119, 127, 112, 118, 97, 59, 113, 112, 115, 124, 123, 112, 69, 103, 122, 101, 112, 103, 97, 108, 61, 101, 103, 122, 97, 122, 57, 50, 96, 102, 112, 103, 84, 114, 112, 123, 97, 81, 116, 97, 116, 50, 57, 110, 114, 112, 97, 47, 115, 96, 123, 118, 97, 124, 122, 123, 61, 60, 110, 103, 112, 97, 96, 103, 123, 53, 96, 116, 113, 46, 104, 57, 118, 122, 123, 115, 124, 114, 96, 103, 116, 119, 121, 112, 47, 97, 103, 96, 112, 104, 60, 46, 104, 118, 116, 97, 118, 125, 61, 112, 60, 110, 104 }, 21) + _0x64265e0e._0x86efbe3e(new byte[112] { 123, 122, 121, 55, 108, 124, 109, 122, 122, 113, 51, 56, 104, 118, 123, 107, 119, 56, 51, 46, 38, 45, 47, 54, 36, 123, 122, 121, 55, 108, 124, 109, 122, 122, 113, 51, 56, 119, 122, 118, 120, 119, 107, 56, 51, 46, 47, 39, 47, 54, 36, 123, 122, 121, 55, 108, 124, 109, 122, 122, 113, 51, 56, 126, 105, 126, 118, 115, 72, 118, 123, 107, 119, 56, 51, 46, 38, 45, 47, 54, 36, 123, 122, 121, 55, 108, 124, 109, 122, 122, 113, 51, 56, 126, 105, 126, 118, 115, 87, 122, 118, 120, 119, 107, 56, 51, 46, 47, 43, 47, 54, 36 }, 31) + _0x64265e0e._0x86efbe3e(new byte[45] { 172, 170, 161, 163, 175, 177, 182, 188, 183, 175, 246, 183, 182, 172, 183, 173, 187, 176, 171, 172, 185, 170, 172, 229, 173, 182, 188, 189, 190, 177, 182, 189, 188, 227, 165, 187, 185, 172, 187, 176, 240, 189, 241, 163, 165 }, 216) + _0x64265e0e._0x86efbe3e(new byte[721] { 231, 225, 234, 232, 229, 242, 225, 179, 252, 225, 250, 244, 174, 228, 250, 253, 247, 252, 228, 189, 254, 242, 231, 240, 251, 222, 246, 247, 250, 242, 189, 241, 250, 253, 247, 187, 228, 250, 253, 247, 252, 228, 186, 168, 228, 250, 253, 247, 252, 228, 189, 254, 242, 231, 240, 251, 222, 246, 247, 250, 242, 174, 245, 230, 253, 240, 231, 250, 252, 253, 187, 226, 186, 232, 229, 242, 225, 179, 224, 174, 192, 231, 225, 250, 253, 244, 187, 226, 186, 189, 231, 252, 223, 252, 228, 246, 225, 208, 242, 224, 246, 187, 186, 168, 250, 245, 187, 224, 189, 250, 253, 247, 246, 235, 220, 245, 187, 180, 227, 252, 250, 253, 231, 246, 225, 169, 179, 240, 252, 242, 225, 224, 246, 180, 186, 173, 174, 163, 239, 239, 224, 189, 250, 253, 247, 246, 235, 220, 245, 187, 180, 251, 252, 229, 246, 225, 169, 179, 253, 252, 253, 246, 180, 186, 173, 174, 163, 239, 239, 224, 189, 250, 253, 247, 246, 235, 220, 245, 187, 180, 254, 242, 235, 190, 228, 250, 247, 231, 251, 180, 186, 173, 174, 163, 239, 239, 224, 189, 250, 253, 247, 246, 235, 220, 245, 187, 180, 254, 242, 235, 190, 247, 246, 229, 250, 240, 246, 190, 228, 250, 247, 231, 251, 180, 186, 173, 174, 163, 186, 225, 246, 231, 230, 225, 253, 179, 232, 254, 242, 231, 240, 251, 246, 224, 169, 245, 242, 255, 224, 246, 191, 254, 246, 247, 250, 242, 169, 226, 191, 252, 253, 240, 251, 242, 253, 244, 246, 169, 253, 230, 255, 255, 191, 242, 247, 247, 223, 250, 224, 231, 246, 253, 246, 225, 169, 245, 230, 253, 240, 231, 250, 252, 253, 187, 186, 232, 238, 191, 225, 246, 254, 252, 229, 246, 223, 250, 224, 231, 246, 253, 246, 225, 169, 245, 230, 253, 240, 231, 250, 252, 253, 187, 186, 232, 238, 191, 242, 247, 247, 214, 229, 246, 253, 231, 223, 250, 224, 231, 246, 253, 246, 225, 169, 245, 230, 253, 240, 231, 250, 252, 253, 187, 186, 232, 238, 191, 225, 246, 254, 252, 229, 246, 214, 229, 246, 253, 231, 223, 250, 224, 231, 246, 253, 246, 225, 169, 245, 230, 253, 240, 231, 250, 252, 253, 187, 186, 232, 238, 191, 247, 250, 224, 227, 242, 231, 240, 251, 214, 229, 246, 253, 231, 169, 245, 230, 253, 240, 231, 250, 252, 253, 187, 186, 232, 225, 246, 231, 230, 225, 253, 179, 245, 242, 255, 224, 246, 168, 238, 238, 168, 250, 245, 187, 224, 189, 250, 253, 247, 246, 235, 220, 245, 187, 180, 227, 252, 250, 253, 231, 246, 225, 169, 179, 245, 250, 253, 246, 180, 186, 173, 174, 163, 239, 239, 224, 189, 250, 253, 247, 246, 235, 220, 245, 187, 180, 251, 252, 229, 246, 225, 169, 179, 251, 252, 229, 246, 225, 180, 186, 173, 174, 163, 186, 225, 246, 231, 230, 225, 253, 179, 232, 254, 242, 231, 240, 251, 246, 224, 169, 231, 225, 230, 246, 191, 254, 246, 247, 250, 242, 169, 226, 191, 252, 253, 240, 251, 242, 253, 244, 246, 169, 253, 230, 255, 255, 191, 242, 247, 247, 223, 250, 224, 231, 246, 253, 246, 225, 169, 245, 230, 253, 240, 231, 250, 252, 253, 187, 186, 232, 238, 191, 225, 246, 254, 252, 229, 246, 223, 250, 224, 231, 246, 253, 246, 225, 169, 245, 230, 253, 240, 231, 250, 252, 253, 187, 186, 232, 238, 191, 242, 247, 247, 214, 229, 246, 253, 231, 223, 250, 224, 231, 246, 253, 246, 225, 169, 245, 230, 253, 240, 231, 250, 252, 253, 187, 186, 232, 238, 191, 225, 246, 254, 252, 229, 246, 214, 229, 246, 253, 231, 223, 250, 224, 231, 246, 253, 246, 225, 169, 245, 230, 253, 240, 231, 250, 252, 253, 187, 186, 232, 238, 191, 247, 250, 224, 227, 242, 231, 240, 251, 214, 229, 246, 253, 231, 169, 245, 230, 253, 240, 231, 250, 252, 253, 187, 186, 232, 225, 246, 231, 230, 225, 253, 179, 245, 242, 255, 224, 246, 168, 238, 238, 168, 225, 246, 231, 230, 225, 253, 179, 252, 225, 250, 244, 187, 226, 186, 168, 238, 168, 238, 240, 242, 231, 240, 251, 187, 246, 186, 232, 238 }, 147) + _0x64265e0e._0x86efbe3e(new byte[5] { 226, 182, 183, 182, 164 }, 159);
    }

    internal bool _0x3edc2d7a(string _0x6c3035bd)
    {
        return _0x6c3035bd.StartsWith(_0x64265e0e._0x86efbe3e(new byte[9] { 69, 73, 90, 67, 77, 92, 18, 7, 7 }, 40), StringComparison.OrdinalIgnoreCase) || _0x6c3035bd.StartsWith(_0x64265e0e._0x86efbe3e(new byte[24] { 117, 105, 105, 109, 110, 39, 50, 50, 109, 113, 124, 100, 51, 122, 114, 114, 122, 113, 120, 51, 126, 114, 112, 50 }, 29), StringComparison.OrdinalIgnoreCase) || _0x6c3035bd.StartsWith(_0x64265e0e._0x86efbe3e(new byte[23] { 22, 10, 10, 14, 68, 81, 81, 14, 18, 31, 7, 80, 25, 17, 17, 25, 18, 27, 80, 29, 17, 19, 81 }, 126), StringComparison.OrdinalIgnoreCase);
    }

    public void _0x5afa9b37()
    {
        if (_0xa551b265)
            return;
        {
#if B_LOGS
            {
                Debug.Log(_0x64265e0e._0x86efbe3e(new byte[33] { 208, 223, 238, 248, 255, 214, 171, 223, 226, 230, 238, 249, 171, 228, 254, 255, 171, 166, 181, 171, 230, 228, 253, 238, 171, 255, 228, 171, 248, 232, 238, 229, 238 }, 139));
            }
#endif
        }

        _0xf96aaabc();
    }

    private void _0xa083dfdb(UniWebView _0x4ad900f8)
    {
        _0x4ad900f8.BackgroundColor = Color.clear;
        _0x4ad900f8.SetSupportMultipleWindows(true, true);
        _0x4ad900f8.SetBackButtonEnabled(false);
        _0x3f45d451.SetUserAgent(_0xb5c488d6());
    }

    // MAIN FLOW
    private bool _0xd1d7545f { get; set; }

    internal bool IsHttpUrl(string _0x3377cd35)
    {
        if (string.IsNullOrEmpty(_0x3377cd35))
            return false;
        return _0x3377cd35.StartsWith(_0x64265e0e._0x86efbe3e(new byte[7] { 46, 50, 50, 54, 124, 105, 105 }, 70), StringComparison.OrdinalIgnoreCase) || _0x3377cd35.StartsWith(_0x64265e0e._0x86efbe3e(new byte[8] { 52, 40, 40, 44, 47, 102, 115, 115 }, 92), StringComparison.OrdinalIgnoreCase);
    }

    private IEnumerator _0x5a53e624(string _0x49d310f2)
    {
        if (_0x3f45d451 != null && _0xa551b265)
            yield break;
        _0x3f45d451 = gameObject.AddComponent<UniWebView>();
        _0xa083dfdb(_0x3f45d451);
        _0x784d3973(_0x3f45d451);
        _0x3f45d451.BackgroundColor = Color.clear;
        var _0x1687718d = SceneManager.GetActiveScene().GetRootGameObjects();
        if (Camera.main != null)
        {
            Camera.main.clearFlags = CameraClearFlags.SolidColor;
            Camera.main.backgroundColor = Color.clear;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();
        _0x61207e6b();
        yield return new WaitForEndOfFrame();
        _0xa551b265 = true;
        _0x5eabfcc1();
        _0x0e380d3a(true);
        _0xdb97e1e8 = false;
        _0xcbd06858 = false;
        _0xa0878f33.Clear();
        _0xb9f45cf0 = -1;
        firstLoadShown = false;
        _0xc6917d04 = false;
        _0x5dbdfb16 = false;
        _0x3f45d451.SetUserAgent("");
        _0xa174bd03 = Time.realtimeSinceStartup;
        _0x3f45d451.Stop();
        _0x3f45d451.Load(_0x49d310f2);
        _0x3f45d451.Show(false, UniWebViewTransitionEdge.None, 0f, null);
        WLog(_0x64265e0e._0x86efbe3e(new byte[25] { 186, 150, 158, 153, 215, 160, 146, 149, 161, 158, 146, 128, 215, 190, 153, 158, 131, 158, 150, 155, 215, 164, 159, 152, 128 }, 247));
    }

    private void _0x5eabfcc1()
    {
        if (_0x864819c7 != null)
            return;
        var _0x64226abd = _0x7d04442c();
        _0x864819c7 = new GameObject(_0x64265e0e._0x86efbe3e(new byte[14] { 85, 103, 96, 84, 107, 103, 117, 81, 114, 107, 108, 108, 103, 112 }, 2), typeof(RectTransform), typeof(Text));
        _0x32a53704 = _0x864819c7.GetComponent<RectTransform>();
        _0x32a53704.SetParent(_0x64226abd.transform, false);
        _0x32a53704.anchorMin = new Vector2(0.5f, 0.5f);
        _0x32a53704.anchorMax = new Vector2(0.5f, 0.5f);
        _0x32a53704.pivot = new Vector2(0.5f, 0.5f);
        _0x32a53704.sizeDelta = new Vector2(600f, 600f);
        _0x32a53704.anchoredPosition = Vector2.zero;
        _0x70623d59 = _0x864819c7.GetComponent<Text>();
        _0x70623d59.text = _0x64265e0e._0x86efbe3e(new byte[1] { 201 }, 230);
        _0x70623d59.font = Resources.GetBuiltinResource<Font>(_0x64265e0e._0x86efbe3e(new byte[17] { 147, 186, 184, 190, 188, 166, 141, 170, 177, 171, 182, 178, 186, 241, 171, 171, 185 }, 223));
        _0x70623d59.fontSize = 200;
        _0x70623d59.alignment = TextAnchor.MiddleCenter;
        _0x70623d59.color = Color.white;
        _0x70623d59.raycastTarget = false;
        _0x864819c7.SetActive(false);
    }

    private int _0xc3458647 = 0;
    private bool OpenUrlExternally(string _0x1d67fb74)
    {
        return _0xd2c6786c(_0x1d67fb74);
    }

    private string _0xaf54932b()
    {
        float _0xb2832b28 = Time.realtimeSinceStartup;
        if (_0xb2832b28 < 0f)
            _0xb2832b28 = 0f;
        int _0x19843681 = (int)(_0xb2832b28 * 1000f);
        int _0xa7dbd671 = _0x19843681 / 60000;
        int _0x87550c4c = (_0x19843681 / 1000) % 60;
        int _0xb9d1b1ce = _0x19843681 % 1000;
        return string.Format(_0x64265e0e._0x86efbe3e(new byte[21] { 245, 190, 180, 190, 190, 243, 180, 245, 191, 180, 190, 190, 243, 180, 245, 188, 180, 190, 190, 190, 243 }, 142), _0xa7dbd671, _0x87550c4c, _0xb9d1b1ce);
    }

    private string _0x7fd95efa = "";
    private void WLog(string _0x06f49d33)
    {
#if B_LOGS
        {
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[7] { 159, 144, 161, 183, 176, 153, 228 }, 196) + _0x06f49d33);
        }
#endif
    }

    private void _0x15c1c4a7(string _0x07400c14)
    {
        {
            {
#if B_LOGS
                Debug.Log(_0x64265e0e._0x86efbe3e(new byte[34] { 49, 62, 15, 25, 30, 55, 74, 44, 15, 30, 9, 2, 74, 47, 18, 30, 24, 11, 74, 58, 31, 25, 2, 74, 46, 11, 30, 11, 74, 56, 11, 29, 80, 74 }, 106) + _0x07400c14);
#endif
            }
        }

        var _0xd14efd05 = JsonConvert.DeserializeObject<Dictionary<string, object>>(_0x07400c14);
        StartCoroutine(_0x01360d00(_0xd14efd05));
    }

    internal bool isApplicationFocus = false;
    private bool _0x32b4ed4f()
    {
        _0xa0878f33.RemoveAll(_0x544d6028 => _0x544d6028 == null || !_0x544d6028.IsAlive);
        return _0xa0878f33.Count > 0;
    }

    private string _0x111d69ac;
    private bool _0x078fc9c0()
    {
        var _0x46d6898f = _0x7ac86bce();
        if (_0x46d6898f == null)
            return false;
        WLog(_0x64265e0e._0x86efbe3e(new byte[31] { 91, 114, 97, 119, 100, 114, 97, 118, 51, 113, 114, 112, 120, 51, 62, 45, 51, 99, 124, 99, 102, 99, 51, 84, 124, 81, 114, 112, 120, 41, 51 }, 19) + _0x46d6898f.Id);
        _0x46d6898f.GoBack();
        return true;
    }

    // WEB VIEW LOGIC END
    internal void _0x1fbb29ae()
    {
        // Ensure channel exists (safe to call multiple times)
        var _0x0cf444b7 = new AndroidNotificationChannel
        {
            Id = _0x64265e0e._0x86efbe3e(new byte[15] { 255, 254, 253, 250, 238, 247, 239, 196, 248, 243, 250, 245, 245, 254, 247 }, 155),
            Name = _0x64265e0e._0x86efbe3e(new byte[15] { 219, 250, 249, 254, 234, 243, 235, 191, 220, 247, 254, 241, 241, 250, 243 }, 159),
            Importance = Importance.High,
            Description = _0x64265e0e._0x86efbe3e(new byte[21] { 28, 62, 53, 62, 41, 58, 55, 123, 53, 52, 47, 50, 61, 50, 56, 58, 47, 50, 52, 53, 40 }, 91)
        };
        AndroidNotificationCenter.RegisterNotificationChannel(_0x0cf444b7);
        // Build notification
        var _0x38460769 = new AndroidNotification
        {
            Title = _0x4bbe82b5[UnityEngine.Random.Range(0, _0x4bbe82b5.Length)],
            Text = _0x64265e0e._0x86efbe3e(new byte[21] { 35, 16, 7, 66, 27, 13, 23, 66, 17, 23, 16, 7, 66, 22, 13, 66, 7, 26, 11, 22, 93 }, 98),
            FireTime = System.DateTime.Now
        };
        // Send immediately
        AndroidNotificationCenter.SendNotification(_0x38460769, _0x64265e0e._0x86efbe3e(new byte[15] { 175, 174, 173, 170, 190, 167, 191, 148, 168, 163, 170, 165, 165, 174, 167 }, 203));
    }

    private void _0x01306115(string _0x9c72c1ef)
    {
        Dictionary<string, object> _0xecfda11a;
        try
        {
            _0xecfda11a = JsonConvert.DeserializeObject<Dictionary<string, object>>(_0x9c72c1ef);
        }
        catch
        {
            return;
        }

        var _0x1ffe215b = ReadPushField(_0xecfda11a, _0x64265e0e._0x86efbe3e(new byte[3] { 195, 196, 218 }, 182));
        if (string.IsNullOrWhiteSpace(_0x1ffe215b))
            return;
        _0x1ffe215b = _0x1ffe215b.Trim();
        if (!IsHttpUrl(_0x1ffe215b))
            return;
        if (string.Equals(_0x1ffe215b, _0xcd225ea9, StringComparison.Ordinal))
            return;
        _0xcd225ea9 = _0x1ffe215b;
        OpenUrlExternally(_0x1ffe215b);
    }

    private Action _0x4ed0ccaa;
    private IEnumerator _0x01360d00(Dictionary<string, object> _0x13874358)
    {
        {
            {
#if B_LOGS
                Debug.Log(_0x64265e0e._0x86efbe3e(new byte[30] { 68, 75, 122, 108, 107, 66, 63, 89, 122, 107, 124, 119, 63, 90, 103, 107, 109, 126, 63, 79, 106, 108, 119, 63, 91, 126, 107, 126, 37, 63 }, 31) + string.Join(_0x64265e0e._0x86efbe3e(new byte[1] { 67 }, 74), _0x13874358));
#endif
            }
        }

        string _0xdda7a826 = "";
        // Primary source: nested JSON under "notificationData"
        if (_0x13874358 != null && _0x13874358.TryGetValue(_0x64265e0e._0x86efbe3e(new byte[16] { 52, 53, 46, 51, 60, 51, 57, 59, 46, 51, 53, 52, 30, 59, 46, 59 }, 90), out var raw))
        {
            try
            {
                var _0xadc439cc = raw?.ToString();
                var _0xf1b4bd0c = JsonConvert.DeserializeObject<Dictionary<string, object>>(_0xadc439cc);
                if (_0xf1b4bd0c != null && _0xf1b4bd0c.TryGetValue(_0x64265e0e._0x86efbe3e(new byte[6] { 53, 35, 40, 34, 47, 34 }, 70), out var val))
                {
                    _0xdda7a826 = val?.ToString();
                }
            }
            catch (Exception e)
            {
#if B_LOGS
                Debug.LogError(_0x64265e0e._0x86efbe3e(new byte[30] { 17, 30, 47, 57, 62, 106, 26, 63, 57, 34, 23, 106, 0, 25, 5, 4, 106, 58, 43, 56, 57, 47, 106, 47, 56, 56, 37, 56, 112, 106 }, 74) + e);
#endif
            }
        }

        // Fallback: flat structure
        if (string.IsNullOrEmpty(_0xdda7a826) && _0x13874358 != null && _0x13874358.TryGetValue(_0x64265e0e._0x86efbe3e(new byte[6] { 253, 235, 224, 234, 231, 234 }, 142), out var lab))
        {
            _0xdda7a826 = lab?.ToString();
        }

        {
#if B_LOGS
            {
                Debug.Log(_0x64265e0e._0x86efbe3e(new byte[38] { 180, 187, 138, 156, 155, 207, 191, 154, 156, 135, 178, 207, 169, 138, 155, 140, 135, 138, 139, 207, 156, 138, 129, 139, 134, 139, 207, 137, 157, 128, 130, 207, 133, 156, 128, 129, 213, 207 }, 239) + _0xdda7a826);
            }
#endif
        }

        if (string.IsNullOrEmpty(_0xdda7a826))
            yield break;
        {
#if B_LOGS
            {
                Debug.Log(_0x64265e0e._0x86efbe3e(new byte[38] { 46, 33, 16, 6, 1, 85, 37, 0, 6, 29, 40, 85, 34, 20, 28, 1, 85, 1, 26, 85, 26, 5, 16, 27, 85, 2, 28, 1, 29, 85, 6, 16, 27, 17, 28, 17, 79, 85 }, 117) + _0xdda7a826);
            }
#endif
        }

        _0x111d69ac = _0xdda7a826;
        yield return new WaitUntil(() => _0xa551b265);
        var _0x0e87d395 = _0x7f7d1fc5(2, 100);
        yield return new WaitUntil(() => _0x0e87d395.IsCompleted);
        string _0x669ad242 = _0x0e87d395.Result;
        if (!string.IsNullOrEmpty(_0x669ad242))
        {
            string _0x965cb572 = _0xf397de01(_0x669ad242, _0xdda7a826);
            {
#if B_LOGS
                Debug.Log(_0x64265e0e._0x86efbe3e(new byte[33] { 54, 57, 8, 30, 25, 77, 61, 24, 30, 5, 48, 77, 63, 8, 1, 2, 12, 9, 77, 58, 8, 15, 59, 4, 8, 26, 77, 26, 4, 25, 5, 87, 77 }, 109) + _0x965cb572);
#endif
            }

            _0x3f45d451.Load(_0x965cb572);
        }
    }

    // WEB VIEW LOGIC
    public bool _0xa551b265 { get; set; }

    private IEnumerator _0x1743de73(IEnumerator _0xfa9a3ef5, TaskCompletionSource<bool> _0x8e497b2e)
    {
        yield return _0xfa9a3ef5;
        _0x8e497b2e.SetResult(true);
    }

    private bool _0xcbd06858 = false;
    private bool _0xf8eb266f(int _0x208d9f7e, string _0xfe03b17e, string _0xd64469f2)
    {
        if (string.IsNullOrEmpty(_0xd64469f2))
            return false;
        if (!IsHttpUrl(_0xd64469f2))
            return true;
        if (string.IsNullOrEmpty(_0xfe03b17e))
            return false;
        return _0xfe03b17e.IndexOf(_0x64265e0e._0x86efbe3e(new byte[20] { 225, 246, 246, 251, 231, 235, 234, 234, 225, 231, 240, 237, 235, 234, 251, 246, 225, 247, 225, 240 }, 164), StringComparison.OrdinalIgnoreCase) >= 0 || _0xfe03b17e.IndexOf(_0x64265e0e._0x86efbe3e(new byte[22] { 110, 121, 121, 116, 104, 100, 101, 101, 110, 104, 127, 98, 100, 101, 116, 121, 110, 109, 126, 120, 110, 111 }, 43), StringComparison.OrdinalIgnoreCase) >= 0 || _0xfe03b17e.IndexOf(_0x64265e0e._0x86efbe3e(new byte[21] { 70, 81, 81, 92, 64, 76, 77, 77, 70, 64, 87, 74, 76, 77, 92, 64, 79, 76, 80, 70, 71 }, 3), StringComparison.OrdinalIgnoreCase) >= 0 || _0xfe03b17e.IndexOf(_0x64265e0e._0x86efbe3e(new byte[22] { 212, 195, 195, 206, 196, 223, 218, 223, 222, 198, 223, 206, 196, 195, 221, 206, 194, 210, 217, 212, 220, 212 }, 145), StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private void _0x05cea131()
    {
        {
#if B_LOGS
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[22] { 107, 100, 85, 67, 68, 109, 16, 99, 68, 95, 66, 85, 116, 85, 70, 89, 83, 85, 121, 94, 86, 95 }, 48));
#endif
        }

        _0xdced5a6a = SystemInfo.deviceModel;
        _0x2ad2e88c = Application.version;
        _0xdb590138 = Application.installMode;
        _0x396cda08 = Application.installerName;
        _0xa4ac586a = Application.identifier;
        _0x00378973 = _0x052c2a79();
        _0x9b2c1b74 = _0xed857a2d();
        _0xcf0cdd9b = SystemInfo.deviceUniqueIdentifier;
        _0xc0147e9f = SystemInfo.graphicsDeviceName;
        _0xacaf1985 = SystemInfo.processorType;
        {
#if B_LOGS
            {
                _0x2ad2e88c = _0x64265e0e._0x86efbe3e(new byte[5] { 189, 164, 189, 164, 189 }, 138);
                _0xdb590138 = ApplicationInstallMode.Store;
                _0x396cda08 = _0x64265e0e._0x86efbe3e(new byte[19] { 233, 229, 231, 164, 235, 228, 238, 248, 229, 227, 238, 164, 252, 239, 228, 238, 227, 228, 237 }, 138);
                _0x9b2c1b74 = _0x64265e0e._0x86efbe3e(new byte[8] { 247, 255, 226, 230, 235, 178, 231, 243 }, 146);
                _0xcf0cdd9b = Guid.NewGuid().ToString().Replace(_0x64265e0e._0x86efbe3e(new byte[1] { 2 }, 47), "");
            }
#endif
        }

        {
#if B_LOGS
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[17] { 139, 132, 181, 163, 164, 141, 240, 180, 181, 166, 157, 191, 180, 181, 188, 234, 240 }, 208) + _0xdced5a6a);
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[19] { 223, 208, 225, 247, 240, 217, 164, 229, 244, 244, 210, 225, 246, 247, 237, 235, 234, 190, 164 }, 132) + _0x2ad2e88c);
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[20] { 5, 10, 59, 45, 42, 3, 126, 55, 48, 45, 42, 63, 50, 50, 19, 49, 58, 59, 100, 126 }, 94) + _0xdb590138);
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[23] { 92, 83, 98, 116, 115, 90, 39, 110, 105, 116, 115, 102, 107, 107, 98, 117, 84, 115, 104, 117, 98, 61, 39 }, 7) + _0x396cda08);
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[14] { 55, 56, 9, 31, 24, 49, 76, 13, 28, 28, 37, 8, 86, 76 }, 108) + _0xa4ac586a);
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[14] { 246, 249, 200, 222, 217, 240, 141, 204, 201, 219, 228, 201, 151, 141 }, 173) + _0x00378973);
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[18] { 235, 228, 213, 195, 196, 237, 144, 197, 195, 213, 194, 241, 215, 213, 222, 196, 138, 144 }, 176) + _0x9b2c1b74);
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[17] { 90, 85, 100, 114, 117, 92, 33, 114, 120, 114, 69, 100, 119, 72, 101, 59, 33 }, 1) + _0xcf0cdd9b);
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[12] { 27, 20, 37, 51, 52, 29, 96, 39, 48, 53, 122, 96 }, 64) + _0xc0147e9f);
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[12] { 0, 15, 62, 40, 47, 6, 123, 56, 43, 46, 97, 123 }, 91) + _0xacaf1985);
#endif
        }
    }

    private bool _0x998f6354 = false;
    internal bool IsAboutBlank(string _0x596440f6)
    {
        if (string.IsNullOrEmpty(_0x596440f6))
            return false;
        return _0x596440f6.StartsWith(_0x64265e0e._0x86efbe3e(new byte[11] { 223, 220, 209, 203, 202, 132, 220, 210, 223, 208, 213 }, 190), StringComparison.OrdinalIgnoreCase);
    }

    private string _0x3f7671b8 = "";
    private string _0x00378973 = "";
    private string _0x7081a095 { get; set; }

    private int _0x4fc7525c = 5, _0x2de957eb = 5, _0xa269660e = 5, _0x806b18cb = 5;
    private void _0x624e588b()
    {
        _0xcbd06858 = true;
        if (_0x3f45d451 != null)
            _0x3f45d451.SetUserAgent(_0xb5c488d6());
    }

    //    private async Task<string> GetMyip()
    //    {
    //        string result = "";
    //        var processorType = SystemInfo.processorType;
    //        //        {
    //        //#if NOT_B_STARTED
    //        //#endif
    //        if (!processorType.Contains("armv7", StringComparison.OrdinalIgnoreCase) && !processorType.Contains("x86-64", StringComparison.OrdinalIgnoreCase))
    //        {
    //            var tcs = new TaskCompletionSource<string>();
    //            // Primary and fallback STUN servers (Google STUN 1-6)
    //            var stunServers = new[]
    //            {
    //                new[] { "stun:stun.l.google.com:19302" },      // Primary
    //                //new[] { "stun:stun1.l.google.com:19302" },     // Fallback 1
    //                //new[] { "stun:stun2.l.google.com:19302" },     // Fallback 2
    //                //new[] { "stun:stun3.l.google.com:19302" },     // Fallback 3
    //                //new[] { "stun:stun4.l.google.com:19302" },     // Fallback 4
    //                //new[] { "stun:stun5.l.google.com:19302" },     // Fallback 5
    //                //new[] { "stun:stun6.l.google.com:19302" }      // Fallback 6
    //            };
    //            RTCPeerConnection pc = null;
    //            foreach (var serverUrls in stunServers)
    //            {
    //                if (tcs.Task.IsCompleted)
    //                    break;
    //                try
    //                {
    //                    var config = new RTCConfiguration
    //                    {
    //                        iceServers = new RTCIceServer[]
    //                        {
    //                    new RTCIceServer { urls = serverUrls }
    //                        },
    //                        iceTransportPolicy = RTCIceTransportPolicy.All
    //                    };
    //                    pc = new RTCPeerConnection(ref config);
    //                    pc.OnIceCandidate = candidate =>
    //                    {
    //                        if (candidate == null || tcs.Task.IsCompleted)
    //                            return;
    //                        if (candidate.Type == RTCIceCandidateType.Srflx || candidate.Type == RTCIceCandidateType.Prflx)
    //                        {
    //                            string address = candidate.Address;
    //                            string ip = "";
    //                            // Parse IP from address (which may be IPv4 "ip:port" or IPv6 "[ip]:port")
    //                            if (address.StartsWith("[") && address.Contains("]:"))
    //                            {
    //                                // IPv6 format: [2001:db8::1]:12345
    //                                int endBracket = address.IndexOf(']');
    //                                ip = address.Substring(1, endBracket - 1);
    //                            }
    //                            else if (address.Contains(':'))
    //                            {
    //                                // IPv4 format: 192.168.1.1:12345
    //                                int lastColon = address.LastIndexOf(':');
    //                                ip = address.Substring(0, lastColon);
    //                            }
    //                            else
    //                            {
    //                                // No port, just IP
    //                                ip = address;
    //                            }
    //                            {
    //#if B_LOGS
    //                                {
    //                                    Debug.Log($"[test STUN] Public IP: {ip} from {serverUrls[0]}");
    //                                }
    //#endif
    //                            }
    //                            tcs.TrySetResult(ip);
    //                        }
    //                    };
    //                    pc.CreateDataChannel("init");
    //                    var offerOp = pc.CreateOffer();
    //                    while (!offerOp.IsDone)
    //                        await Task.Yield();
    //                    var desc = offerOp.Desc;
    //                    pc.SetLocalDescription(ref desc);
    //                    float timeout = 10f;
    //                    float t = 0f;
    //                    while (!tcs.Task.IsCompleted && t < timeout)
    //                    {
    //                        await Task.Delay(100);
    //                        t += 0.1f;
    //                    }
    //                    if (tcs.Task.IsCompleted)
    //                    {
    //                        result = tcs.Task.Result;
    //                        break;
    //                    }
    //                    {
    //#if B_LOGS
    //                        {
    //                            Debug.Log($"[test STUN] Failed with {serverUrls[0]}, trying next...");
    //                        }
    //#endif
    //                    }
    //                }
    //                catch (Exception ex)
    //                {
    //#if B_LOGS
    //                    {
    //                        Debug.Log($"[test STUN] Error with {serverUrls[0]}: {ex.Message}");
    //                    }
    //#endif
    //                    if (pc != null)
    //                    {
    //                        pc.Close();
    //                        pc.Dispose();
    //                    }
    //                }
    //            }
    //            if (!tcs.Task.IsCompleted)
    //                result = "";
    //        }
    //        //#if NOT_B_STARTED
    //        //            else
    //        //        if(result == "")
    //        //        {
    //        //            {
    //        //#if B_LOGS
    //        //                {
    //        //                    Debug.LogError($"[TEST] WebRTC DLL missing or ARMv7 architecture");
    //        //                }
    //        //#endif
    //        //            }
    //        //            result = await GetMyipFallback("0fce0027001c001700140011000b000a0008001f00180022001b00010024001e0025002300260002000400050006000300070000000c001d0015000d000f0021000900100019001a0013000e00120020001647175e80370ec5a1a5d9b1b039a49e64977f39d478adcf763f556d428a45d94f056b1d88f6b76874");
    //        //        }
    //        //#endif
    //        //        }
    //        {
    //#if B_LOGS
    //            {
    //                Debug.Log($"[Test] Get my ip: {result}");
    //            }
    //#endif
    //        }
    //        return result;
    //    }
    private async Task<string> _0x2f5a347c()
    {
        var _0x5e96cbc0 = _0x64265e0e._0x86efbe3e(new byte[40] { 175, 179, 179, 183, 180, 253, 232, 232, 176, 176, 176, 233, 164, 171, 168, 178, 163, 161, 171, 166, 181, 162, 233, 164, 168, 170, 232, 164, 163, 169, 234, 164, 160, 174, 232, 179, 181, 166, 164, 162 }, 199);
        using (UnityWebRequest _0x9b296e52 = UnityWebRequest.Get(_0x5e96cbc0))
        {
            await _0x9b296e52.SendWebRequest();
            string[] _0x8b25d013 = _0x9b296e52.downloadHandler.text.Split('\n');
            foreach (string _0x2b2ee935 in _0x8b25d013)
            {
                if (_0x2b2ee935.StartsWith(_0x64265e0e._0x86efbe3e(new byte[3] { 208, 201, 132 }, 185)))
                {
                    string _0xdc914d51 = _0x2b2ee935.Substring(3);
                    {
#if B_LOGS
                        {
                            Debug.Log($"[Test] User ip (FALLBACK MODE): {_0xdc914d51} from {_0x5e96cbc0}");
                        }
#endif
                    }

                    return _0xdc914d51;
                }
            }
        }

        return "";
    }

    private Text _0x70623d59;
    private Canvas _0x01b6e48e;
    private async Task<bool> _0xacfa100c()
    {
        _0xb350fe60.Instance?._0xa0276314();
        PushNotificationsService.Instance.OnRemoteNotificationReceived += (_0xf64f3a9f) =>
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0x64265e0e._0x86efbe3e(new byte[32] { 231, 232, 217, 207, 200, 225, 156, 233, 210, 213, 200, 197, 156, 236, 201, 207, 212, 156, 242, 211, 200, 213, 218, 213, 223, 221, 200, 213, 211, 210, 134, 156 }, 188) + string.Join(_0x64265e0e._0x86efbe3e(new byte[1] { 7 }, 14), _0xf64f3a9f));
                }
#endif
            }
        };
        try
        {
            _0x850c186f = await PushNotificationsService.Instance.RegisterForPushNotificationsAsync();
        }
        catch (Exception ex)
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0x64265e0e._0x86efbe3e(new byte[31] { 135, 136, 185, 175, 168, 129, 252, 154, 189, 181, 176, 185, 184, 252, 168, 179, 252, 187, 185, 168, 252, 172, 169, 175, 180, 252, 168, 179, 183, 185, 178 }, 220));
                }
#endif
            }

            _0x850c186f = "";
        }

        _0x7b2b879c = !string.IsNullOrEmpty(_0x850c186f);
        _0x5065429e = _0xaf54932b();
        {
#if B_LOGS
            Debug.Log(_0x64265e0e._0x86efbe3e(new byte[25] { 219, 212, 229, 243, 244, 221, 160, 213, 238, 233, 244, 249, 160, 208, 245, 243, 232, 160, 212, 239, 235, 229, 238, 186, 160 }, 128) + _0x850c186f);
#endif
        }

        _0xb350fe60.Instance?._0x9bdfba71();
        return false;
    }

    internal Rect lastSafe = Rect.zero;
    private string _0xdced5a6a = "";
    private async void Start()
    {
        await _0xe4a3ec3e();
    }

    private void _0x17ace729(string _0x79b1da99)
    {
        bool _0xb987012c = !string.IsNullOrEmpty(_0x79b1da99);
        if (_0xb987012c)
        {
            {
#if B_LOGS
                Debug.Log(_0x64265e0e._0x86efbe3e(new byte[13] { 134, 137, 184, 174, 169, 128, 253, 142, 181, 178, 170, 231, 253 }, 221) + _0x79b1da99);
#endif
            }

            _0xbe84a453(_0x79b1da99);
            return;
        }
        else
        {
            {
#if B_LOGS
                Debug.Log(_0x64265e0e._0x86efbe3e(new byte[39] { 154, 149, 164, 178, 181, 156, 225, 135, 160, 173, 173, 163, 160, 162, 170, 225, 35, 71, 83, 225, 134, 160, 172, 164, 225, 233, 175, 174, 225, 167, 168, 175, 160, 173, 225, 148, 147, 141, 232 }, 193));
#endif
            }

            _0xf96aaabc();
            return;
        }
    }

    private void _0xbe84a453(string _0x8beaf578)
    {
        _0x48b7d575();
        StartCoroutine(_0x5a53e624(_0x8beaf578));
    }

    internal bool IsGoogleAuthFlowUrl(string _0x4033e678)
    {
        if (string.IsNullOrEmpty(_0x4033e678))
            return false;
        return _0x4033e678.IndexOf(_0x64265e0e._0x86efbe3e(new byte[19] { 88, 90, 90, 86, 76, 87, 77, 74, 23, 94, 86, 86, 94, 85, 92, 23, 90, 86, 84 }, 57), StringComparison.OrdinalIgnoreCase) >= 0 || _0x4033e678.IndexOf(_0x64265e0e._0x86efbe3e(new byte[16] { 32, 34, 34, 46, 52, 47, 53, 50, 111, 38, 46, 46, 38, 45, 36, 111 }, 65), StringComparison.OrdinalIgnoreCase) >= 0 || _0x4033e678.IndexOf(_0x64265e0e._0x86efbe3e(new byte[21] { 209, 217, 217, 209, 218, 211, 195, 197, 211, 196, 213, 217, 216, 194, 211, 216, 194, 152, 213, 217, 219 }, 182), StringComparison.OrdinalIgnoreCase) >= 0 || _0x4033e678.IndexOf(_0x64265e0e._0x86efbe3e(new byte[11] { 12, 24, 31, 10, 31, 2, 8, 69, 8, 4, 6 }, 107), StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private string _0x5065429e = "";
    private void Awake()
    {
        if (_0xe937bad0 != null)
        {
            Destroy(this.gameObject);
            return;
        }

        EnhancedTouchSupport.Enable();
        Input.backButtonLeavesApp = false;
        {
#if !B_LOGS
            Debug.unityLogger.logEnabled = false;
            Application.SetStackTraceLogType(LogType.Assert, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Exception, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Warning, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Error, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
#endif
        }

        _0xe937bad0 = gameObject.GetComponent<_0x73b3491c>();
        DontDestroyOnLoad(gameObject);
        _0x850c186f = _0x7081a095 = _0x43e33ad6 = "";
        _0x7bc08300 = "";
        _0xa551b265 = false;
    }

    private string _0xc0147e9f = "";
    private bool _0x962d8528(string _0xaa75cc23)
    {
        try
        {
            using (var _0xbf65397e = new AndroidJavaClass(_0x64265e0e._0x86efbe3e(new byte[30] { 224, 236, 238, 173, 246, 237, 234, 247, 250, 176, 231, 173, 243, 239, 226, 250, 230, 241, 173, 214, 237, 234, 247, 250, 211, 239, 226, 250, 230, 241 }, 131)))
            using (var _0x06a01220 = _0xbf65397e.GetStatic<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[15] { 247, 225, 230, 230, 241, 250, 224, 213, 247, 224, 253, 226, 253, 224, 237 }, 148)))
            using (var _0x8b4a0a46 = _0x06a01220.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[17] { 37, 39, 54, 18, 35, 33, 41, 35, 37, 39, 15, 35, 44, 35, 37, 39, 48 }, 66)))
            using (var _0x576fdb21 = new AndroidJavaClass(_0x64265e0e._0x86efbe3e(new byte[22] { 212, 219, 209, 199, 218, 220, 209, 155, 214, 218, 219, 193, 208, 219, 193, 155, 252, 219, 193, 208, 219, 193 }, 181)))
            using (var _0xc0efbe89 = _0x576fdb21.CallStatic<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[8] { 252, 237, 254, 255, 233, 217, 254, 229 }, 140), _0xaa75cc23, 1))
            {
                string _0x8d7b4c02 = _0xc0efbe89.Call<string>(_0x64265e0e._0x86efbe3e(new byte[14] { 83, 81, 64, 103, 64, 70, 93, 90, 83, 113, 76, 64, 70, 85 }, 52), _0x64265e0e._0x86efbe3e(new byte[20] { 89, 73, 84, 76, 72, 94, 73, 100, 93, 90, 87, 87, 89, 90, 88, 80, 100, 78, 73, 87 }, 59));
                string _0x107a21ca = _0xc0efbe89.Call<string>(_0x64265e0e._0x86efbe3e(new byte[10] { 224, 226, 243, 215, 230, 228, 236, 230, 224, 226 }, 135));
                _0xc0efbe89.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[11] { 112, 117, 117, 82, 112, 101, 116, 118, 126, 99, 104 }, 17), _0x64265e0e._0x86efbe3e(new byte[33] { 111, 96, 106, 124, 97, 103, 106, 32, 103, 96, 122, 107, 96, 122, 32, 109, 111, 122, 107, 105, 97, 124, 119, 32, 76, 92, 65, 89, 93, 79, 76, 66, 75 }, 14));
                _0xc0efbe89.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[11] { 94, 73, 65, 67, 90, 73, 105, 84, 88, 94, 77 }, 44), _0x64265e0e._0x86efbe3e(new byte[20] { 243, 227, 254, 230, 226, 244, 227, 206, 247, 240, 253, 253, 243, 240, 242, 250, 206, 228, 227, 253 }, 145));
                if (_0xc0efbe89.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[15] { 58, 45, 59, 39, 36, 62, 45, 9, 43, 60, 33, 62, 33, 60, 49 }, 72), _0x8b4a0a46) != null)
                {
                    WLog(_0x64265e0e._0x86efbe3e(new byte[24] { 26, 49, 43, 54, 52, 60, 21, 48, 50, 60, 121, 54, 41, 60, 55, 121, 48, 55, 45, 60, 55, 45, 99, 121 }, 89) + _0xaa75cc23);
                    _0xc0efbe89.Call<AndroidJavaObject>(_0x64265e0e._0x86efbe3e(new byte[8] { 121, 124, 124, 94, 116, 121, 127, 107 }, 24), 0x10000000);
                    _0x06a01220.Call(_0x64265e0e._0x86efbe3e(new byte[13] { 175, 168, 189, 174, 168, 157, 191, 168, 181, 170, 181, 168, 165 }, 220), _0xc0efbe89);
                    return true;
                }

                if (_0xf37c9fed(_0x107a21ca))
                    return true;
                if (!string.IsNullOrEmpty(_0x8d7b4c02))
                {
                    WLog(_0x64265e0e._0x86efbe3e(new byte[28] { 239, 196, 222, 195, 193, 201, 224, 197, 199, 201, 140, 197, 194, 216, 201, 194, 216, 140, 202, 205, 192, 192, 206, 205, 207, 199, 150, 140 }, 172) + _0x8d7b4c02);
                    if (_0x3edc2d7a(_0x8d7b4c02))
                        return _0x4a96e19d(_0x8d7b4c02, _0x107a21ca);
                    return _0xd2c6786c(_0x8d7b4c02);
                }

                WLog(_0x64265e0e._0x86efbe3e(new byte[30] { 214, 253, 231, 250, 248, 240, 217, 252, 254, 240, 181, 252, 251, 225, 240, 251, 225, 181, 251, 250, 181, 253, 244, 251, 241, 249, 240, 231, 175, 181 }, 149) + _0xaa75cc23);
                return true;
            }
        }
        catch (Exception e)
        {
            WLog(_0x64265e0e._0x86efbe3e(new byte[26] { 10, 33, 59, 38, 36, 44, 5, 32, 34, 44, 105, 32, 39, 61, 44, 39, 61, 105, 47, 40, 32, 37, 44, 45, 115, 105 }, 73) + e.Message);
            return true;
        }
    }

    private bool TryOpenExternalLikeChrome(string _0x87972ff4)
    {
        if (string.IsNullOrEmpty(_0x87972ff4))
            return false;
        if (_0x87972ff4.StartsWith(_0x64265e0e._0x86efbe3e(new byte[9] { 39, 32, 58, 43, 32, 58, 116, 97, 97 }, 78), StringComparison.OrdinalIgnoreCase))
            return _0x962d8528(_0x87972ff4);
        if (_0x3edc2d7a(_0x87972ff4))
            return _0x4a96e19d(_0x87972ff4, null);
        if (!_0x87972ff4.StartsWith(_0x64265e0e._0x86efbe3e(new byte[7] { 252, 224, 224, 228, 174, 187, 187 }, 148), StringComparison.OrdinalIgnoreCase) && !_0x87972ff4.StartsWith(_0x64265e0e._0x86efbe3e(new byte[8] { 221, 193, 193, 197, 198, 143, 154, 154 }, 181), StringComparison.OrdinalIgnoreCase) && !_0x87972ff4.StartsWith(_0x64265e0e._0x86efbe3e(new byte[11] { 197, 198, 203, 209, 208, 158, 198, 200, 197, 202, 207 }, 164), StringComparison.OrdinalIgnoreCase))
        {
            return _0xd2c6786c(_0x87972ff4);
        }

        return false;
    }

    private void OnApplicationFocus(bool _0x815d922b)
    {
        isApplicationFocus = _0x815d922b;
        if (_0x815d922b && _0xa551b265)
        {
            _0x48b7d575();
        }
    }

    // NATIVE WEB VIEW METHODS
    private UniWebView _0x3f45d451 = null;
    private string _0xa4ac586a = "";
    private async Task<bool> _0xbd4d8fcf(int _0x9dc23317 = 5, int _0x41c5e185 = 500)
    {
        List<EntityData> _0xa2b887be = new List<EntityData>();
        int _0x97da3819 = 0;
        do
        {
            try
            {
                _0xa2b887be = (await CloudSaveService.Instance.Data.Player.QueryAsync(new Query(new List<FieldFilter> { new FieldFilter(_0x64265e0e._0x86efbe3e(new byte[8] { 154, 134, 139, 147, 143, 152, 163, 142 }, 234), _0xf0cf1c30, FieldFilter.OpOptions.EQ, true) }, new HashSet<string> { _0x64265e0e._0x86efbe3e(new byte[9] { 4, 30, 61, 31, 4, 27, 12, 14, 20 }, 109) }), new QueryOptions())).ToList();
            }
            catch (Exception e)
            {
                {
#if B_LOGS
                    {
                        Debug.Log(_0x64265e0e._0x86efbe3e(new byte[32] { 168, 167, 150, 128, 135, 174, 211, 130, 134, 150, 129, 138, 178, 128, 138, 157, 144, 161, 150, 128, 134, 159, 135, 128, 211, 150, 129, 129, 156, 129, 201, 211 }, 243) + e.Message);
                    }
#endif
                }
            }

            await Task.Delay(_0x41c5e185);
        }
        while (_0xa2b887be.Count == 0 && _0x97da3819++ < _0x9dc23317);
        {
#if B_LOGS
            {
                Debug.Log(_0x64265e0e._0x86efbe3e(new byte[32] { 232, 231, 214, 192, 199, 238, 147, 250, 192, 227, 193, 218, 197, 210, 208, 202, 147, 226, 198, 214, 193, 202, 147, 193, 214, 192, 198, 223, 199, 192, 137, 147 }, 179) + JsonConvert.SerializeObject(_0xa2b887be, Formatting.Indented));
            }
#endif
        }

        {
#if B_LOGS
            {
                Debug.Log(_0x64265e0e._0x86efbe3e(new byte[38] { 245, 250, 203, 221, 218, 243, 142, 231, 221, 254, 220, 199, 216, 207, 205, 215, 142, 255, 219, 203, 220, 215, 142, 220, 203, 221, 219, 194, 218, 221, 142, 205, 193, 219, 192, 218, 148, 142 }, 174) + _0xa2b887be.Count);
            }
#endif
        }

        bool _0xfa4c09a1 = true;
        if (_0xa2b887be.Count == 0)
        {
            _0xfa4c09a1 = false;
        }
        else
        {
            _0xfa4c09a1 = _0xa2b887be.Any(_0x07781599 => _0x07781599.Data.Any(IsPrivacyItemTrue));
        }

        {
#if B_LOGS
            {
                Debug.Log(_0x64265e0e._0x86efbe3e(new byte[25] { 247, 248, 201, 223, 216, 241, 140, 229, 223, 252, 222, 197, 218, 205, 207, 213, 140, 222, 201, 223, 217, 192, 216, 150, 140 }, 172) + _0xfa4c09a1);
            }
#endif
        }

        return _0xfa4c09a1;
    }

    private UniWebViewPopup _0x7ac86bce()
    {
        for (int _0x6b499609 = _0xa0878f33.Count - 1; _0x6b499609 >= 0; _0x6b499609--)
        {
            var _0xf45df279 = _0xa0878f33[_0x6b499609];
            if (_0xf45df279 != null && _0xf45df279.IsAlive)
                return _0xf45df279;
            _0xa0878f33.RemoveAt(_0x6b499609);
        }

        return null;
    }

    private string _0x464225d5 = "";
    private string _0xb5c488d6()
    {
        if (string.IsNullOrEmpty(_0x9b2c1b74) && _0x3f45d451 != null)
            _0x9b2c1b74 = _0x3f45d451.GetUserAgent();
        if (string.IsNullOrEmpty(_0x9b2c1b74))
            return string.Empty;
        string _0x848470ee = Regex.Replace(_0x9b2c1b74, _0x64265e0e._0x86efbe3e(new byte[11] { 148, 187, 226, 243, 148, 187, 226, 191, 190, 148, 170 }, 200), string.Empty);
        _0x848470ee = Regex.Replace(_0x848470ee, _0x64265e0e._0x86efbe3e(new byte[15] { 5, 42, 114, 27, 44, 48, 53, 61, 118, 2, 7, 98, 112, 4, 114 }, 89), string.Empty);
        _0x848470ee = Regex.Replace(_0x848470ee, _0x64265e0e._0x86efbe3e(new byte[15] { 187, 136, 159, 158, 132, 130, 131, 194, 217, 177, 195, 221, 177, 158, 199 }, 237), string.Empty);
        return Regex.Replace(_0x848470ee, _0x64265e0e._0x86efbe3e(new byte[6] { 70, 105, 97, 40, 54, 103 }, 26), _0x64265e0e._0x86efbe3e(new byte[1] { 57 }, 25)).Trim();
    }

    private string _0x9f44d5c8()
    {
        string _0x1b23e9a5 = _0x64265e0e._0x86efbe3e(new byte[62] { 187, 184, 185, 190, 191, 188, 189, 178, 179, 176, 177, 182, 183, 180, 181, 170, 171, 168, 169, 174, 175, 172, 173, 162, 163, 160, 155, 152, 153, 158, 159, 156, 157, 146, 147, 144, 145, 150, 151, 148, 149, 138, 139, 136, 137, 142, 143, 140, 141, 130, 131, 128, 234, 235, 232, 233, 238, 239, 236, 237, 226, 227 }, 218);
        System.Random _0xbb15ab74 = new System.Random();
        int _0x54bfaab4 = _0xbb15ab74.Next(8, 16);
        return new string (Enumerable.Repeat(_0x1b23e9a5, _0x54bfaab4).Select(_0xdb4d83c3 => _0xdb4d83c3[_0xbb15ab74.Next(_0xdb4d83c3.Length)]).ToArray());
    }

    private bool _0xffd32b26 = false;
    internal bool isApplicationPause = false;
    private bool _0xc6917d04 = false;
    private string _0xacaf1985 = "";
}

internal static class _0x64265e0e
{
    internal static string _0x86efbe3e(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}