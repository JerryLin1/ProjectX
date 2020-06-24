using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;

public class DarkMirrorInstaller : EditorWindow
{
    [MenuItem("Dark Mirror/Installer")]
    public static void ShowWindow()
    {
        EditorWindow window = GetWindow<DarkMirrorInstaller>("Installer");
        window.maxSize = new Vector3(200, 75);
    }

    int installing = 0;
    WebClient wc;
    int percentage = 0;

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label(Resources.Load<Texture>("DarkMirrorIcon"), GUILayout.Height(50), GUILayout.Width(50));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        switch (installing)
        {
            case 0:
                GUILayout.Space(20);
                if (GUILayout.Button("Install Latest Version"))
                {
                    installing = 1;
                    if (!Directory.Exists("DarkMirrorDownloads"))
                        Directory.CreateDirectory("DarkMirrorDownloads");
                    wc = new WebClient();
                    wc.DownloadFileAsync(new System.Uri("https://www.darkriftnetworking.com/DarkRift2/Releases/Free/2.6.0.unitypackage"), @"DarkMirrorDownloads\DarkRift.unitypackage");
                    wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                    percentage = 0;
                    EditorApplication.LockReloadAssemblies();
                }
                break;
            case 1:
                DrawMiddleText("Downloading DarkRift2...\n" + percentage + "%");
                break;
            case 2:
                DrawMiddleText("Installing DarkRift2...");
                break;
            case 3:
                DrawMiddleText("Downloading Latest\nDark Reflective Mirror...\n" + percentage + "%");
                break;
            case 4:
                DrawMiddleText("Installing Dark Mirror...");
                break;
        }

    }

    void DrawMiddleText(string text)
    {
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label(text);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }

    private void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        if (installing == 1)
        {
            installing = 2;
            AssetDatabase.importPackageCompleted += AssetDatabase_importPackageCompleted;
            AssetDatabase.ImportPackage(@"DarkMirrorDownloads\DarkRift.unitypackage", false);
            wc.DownloadProgressChanged -= Wc_DownloadProgressChanged;
            wc.DownloadFileCompleted -= Wc_DownloadFileCompleted;
        }

        if (installing == 3)
        {
            installing = 4;
            AssetDatabase.importPackageCompleted += AssetDatabase_importPackageCompleted;
            AssetDatabase.ImportPackage(@"DarkMirrorDownloads\DarkMirror.unitypackage", false);
            wc.DownloadProgressChanged -= Wc_DownloadProgressChanged;
            wc.DownloadFileCompleted -= Wc_DownloadFileCompleted;
        }
    }

    private void AssetDatabase_importPackageCompleted(string packageName)
    {
        if (packageName == @"DarkMirrorDownloads\DarkRift")
        {
            AssetDatabase.importPackageCompleted -= AssetDatabase_importPackageCompleted;

            if (!Directory.Exists(@"Assets\Mirror\Runtime\Transport\DarkReflectiveMirror\"))
                Directory.CreateDirectory(@"Assets\Mirror\Runtime\Transport\DarkReflectiveMirror\");

            if (Directory.Exists(@"Assets\Editor\DRClient\"))
                Directory.Delete(@"Assets\Editor\DRClient\", true);

            if (Directory.Exists(@"Assets\Editor\DRServer\"))
                Directory.Delete(@"Assets\Editor\DRServer\", true);

            if (Directory.Exists(@"Assets\Mirror\Runtime\Transport\DarkReflectiveMirror\DarkRift\"))
                Directory.Delete(@"Assets\Mirror\Runtime\Transport\DarkReflectiveMirror\DarkRift\", true);

            Directory.Move(@"Assets\DarkRift\DarkRift\Plugins\Client\Editor\", @"Assets\Editor\DRClient\");
            Directory.Move(@"Assets\DarkRift\DarkRift\Plugins\Server\Editor\", @"Assets\Editor\DRServer\");

            // Wait until first two are done.

            System.Threading.Thread.Sleep(200);

            Directory.Move(@"Assets\DarkRift\", @"Assets\Mirror\Runtime\Transport\DarkReflectiveMirror\DarkRift\");




            installing = 3;
            wc.DownloadFileAsync(new System.Uri("http://34.72.21.213/latest.unitypackage"), @"DarkMirrorDownloads\DarkMirror.unitypackage");
            wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
            percentage = 0;
        }

        if (packageName == @"DarkMirrorDownloads\DarkMirror")
        {
            EditorApplication.UnlockReloadAssemblies();
            installing = 0;
        }
    }

    private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        percentage = e.ProgressPercentage;
    }
}
