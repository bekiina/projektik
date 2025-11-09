using UnityEditor;
using UnityEngine;
using System.IO;
using System;

public class ProjectBackupUtility
{
    [MenuItem("Tools/Backup/Save Backup %#b")] // Ctrl+Shift+B
    public static void BackupProject()
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string projectPath = Directory.GetParent(Application.dataPath).FullName;
        string backupPath = Path.Combine(projectPath, "Backups", "Backup_" + timestamp);

        // Create backup directory
        Directory.CreateDirectory(backupPath);

        // Folders to backup
        string[] foldersToBackup = { "Assets", "ProjectSettings", "Packages" };

        foreach (string folder in foldersToBackup)
        {
            string source = Path.Combine(projectPath, folder);
            string destination = Path.Combine(backupPath, folder);
            CopyDirectory(source, destination);
        }

        Debug.Log("Backup created at: " + backupPath);
    }

    static void CopyDirectory(string sourceDir, string destinationDir)
    {
        Directory.CreateDirectory(destinationDir);

        foreach (string file in Directory.GetFiles(sourceDir))
        {
            string dest = Path.Combine(destinationDir, Path.GetFileName(file));
            File.Copy(file, dest, true);
        }

        foreach (string folder in Directory.GetDirectories(sourceDir))
        {
            string dest = Path.Combine(destinationDir, Path.GetFileName(folder));
            CopyDirectory(folder, dest);
        }
    }
}
