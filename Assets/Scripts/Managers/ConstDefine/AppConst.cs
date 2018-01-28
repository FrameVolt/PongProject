using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppConst : MonoBehaviour
{

    public const bool DebugMode = true;
    public const string AppName = "Pong";
    public static string UserID = string.Empty;
    public const Platform platform = Platform.Editor;


    public enum Platform { Android, Editor, Ios, Standalone }
}
