/*using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;

public class FixAsmdefReferences : AssetPostprocessor
{
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        bool needsFix = false;
        foreach (string assetPath in importedAssets)
        {
            if (assetPath.EndsWith(".asmdef.meta") || assetPath.EndsWith(".asmdef"))
            {
                needsFix = true;
                break;
            }
        }

        if (needsFix)
        {
            EditorApplication.delayCall += FixReferences;
        }
    }

    static void FixReferences()
    {
        string coreGuid = GetAsmdefGuid("Assets/Scripts/Core/Core.asmdef");
        if (string.IsNullOrEmpty(coreGuid))
        {
            Debug.LogWarning("FixAsmdefReferences: Could not find Core.asmdef GUID. Please ensure Core.asmdef is imported first.");
            return;
        }

        string[] asmdefFiles = {
            "Assets/Scripts/Health/Health.asmdef",
            "Assets/Scripts/Gold/Gold.asmdef",
            "Assets/Scripts/Location/Location.asmdef",
            "Assets/Scripts/VIP/VIP.asmdef",
            "Assets/Scripts/Shop/Shop.asmdef"
        };

        bool anyFixed = false;
        foreach (string asmdefPath in asmdefFiles)
        {
            if (File.Exists(asmdefPath))
            {
                if (FixAsmdefFile(asmdefPath, coreGuid))
                {
                    anyFixed = true;
                }
            }
        }

        if (anyFixed)
        {
            AssetDatabase.Refresh();
            Debug.Log("FixAsmdefReferences: Updated asmdef references to use Core GUID.");
        }
    }

    static string GetAsmdefGuid(string asmdefPath)
    {
        string metaPath = asmdefPath + ".meta";
        if (File.Exists(metaPath))
        {
            string[] lines = File.ReadAllLines(metaPath);
            foreach (string line in lines)
            {
                if (line.StartsWith("guid:"))
                {
                    return line.Substring(5).Trim();
                }
            }
        }
        return null;
    }

    static bool FixAsmdefFile(string asmdefPath, string coreGuid)
    {
        string content = File.ReadAllText(asmdefPath);
        string originalContent = content;
        
        // Replace "GUID:Core" with actual GUID
        content = Regex.Replace(content, "\"GUID:Core\"", $"\"GUID:{coreGuid}\"", RegexOptions.IgnoreCase);
        
        if (content != originalContent)
        {
            File.WriteAllText(asmdefPath, content);
            return true;
        }
        return false;
    }
}*/

