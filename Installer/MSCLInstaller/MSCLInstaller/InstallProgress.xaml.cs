﻿using IniParser;
using IniParser.Model;
using Ionic.Zip;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MSCLInstaller
{
    /// <summary>
    /// Interaction logic for InstallProgress.xaml
    /// </summary>
    public partial class InstallProgress : Page
    {
        MainWindow main;
        private Progress<(string text, string log)> progressLog = new();
        private Progress<(int percent, int max, bool isIndeterminate)> progress = new();
        
        public InstallProgress(MainWindow m)
        {
            InitializeComponent();
            LogBox.Clear();
            progressLog.ProgressChanged += (_, e) =>
            {
                ProgressText.Text = e.text;
                AddLog(e.log);
            };
            progress.ProgressChanged += (_, e) =>
            {
                progressBar.IsIndeterminate = e.isIndeterminate;
                progressBar.Maximum = e.max;
                progressBar.Value = e.percent;
            };
            main = m;
        }

        internal async void ChangeModsFolder(ModsFolder newfolder,bool deleteTarget)
        {
            AddLog("Changing Mods Folder...");
            await Task.Run(() => ChangeModsFolderWork(newfolder, deleteTarget, progressLog,progress));
            if (MessageBox.Show("Folder has been changed", "Change Mods Folder", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                main.ReInitInstallerPage();
                main.MSCLoaderInstallerPage();
            }
        }
        internal async void ChangeModsFolderAndCopyAsync(string oldPath, ModsFolder newFolder)
        {
            AddLog("Changing Mods Folder...");
            await Task.Run(() => ChangeModsFolderWork(newFolder, true, progressLog, progress));
            AddLog($"Copying mods from {oldPath} to {Storage.modsPath}...");
            progressBar.Maximum = 100;
            await Task.Run(() => ChangeModsFolderAndCopyWork(oldPath, progressLog, progress));
            if (MessageBox.Show("Folder has been changed", "Change Mods Folder", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                main.ReInitInstallerPage();
                main.MSCLoaderInstallerPage();
            }
        }
        internal async void UninstalMSCLoader()
        {
            AddLog("Uninstalling MSCLoader...");
            await Task.Run(() => UninstallMSCLoaderWork(progressLog, progress));
            if (MessageBox.Show("Uninstall Complete", "Uninstalling MSCLoader", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                main.ReInitInstallerPage();
                main.MSCLoaderInstallerPage();
            }
        }

        internal async void InstallMSCLoader(ModsFolder modsfolder)
        {
            AddLog("Installing MSCLoader...");
            await Task.Run(() => InstallMSCLoaderWork(modsfolder, progressLog, progress));
            if (MessageBox.Show("Install Complete", "Install MSCLoader", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                main.ReInitInstallerPage();
                main.MSCLoaderInstallerPage();
            }
        }

        internal async void UpdateMSCLoader(bool updateCore, bool updateRefs, bool updateMSCL)
        {
            AddLog("Updating MSCLoader...");
            await Task.Run(() => UpdateMSCLoaderWork(updateCore, updateRefs, updateMSCL, progressLog, progress));
            if (MessageBox.Show("Update Complete", "Update MSCLoader", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                main.ReInitInstallerPage();
                main.MSCLoaderInstallerPage();
            }
        }

        private void ChangeModsFolderWork(ModsFolder newfolder, bool deleteTarget, IProgress<(string text, string log)> progressLog, IProgress<(int percent, int max, bool isIndeterminate)> progress)
        {
            progress.Report((0, 10, true));
            System.Threading.Thread.Sleep(1500);
            if (!UpdateConfigFile(newfolder, progressLog, progress))
                return;
            System.Threading.Thread.Sleep(100);
            if (deleteTarget)
            {
                if (Directory.Exists(Storage.modsPath))
                {
                    progressLog.Report(("Deleting existing folder", $"Deleting.....{Storage.modsPath}"));
                    Directory.Delete(Storage.modsPath, true);
                    System.Threading.Thread.Sleep(100);
                }
                progressLog.Report(("Creating new folder structure", $"Creating new folder structure"));
                progress.Report((0, 5, false));

                System.Threading.Thread.Sleep(100);
                Directory.CreateDirectory(Storage.modsPath);
                progressLog.Report(($"Creating: {Storage.modsPath}", $"Creating.....{Storage.modsPath}"));
                progress.Report((1, 5, false));
                System.Threading.Thread.Sleep(100);
                Directory.CreateDirectory(Path.Combine(Storage.modsPath, "Assets"));
                progressLog.Report(($"Creating Assets folder", $"Creating.....{Path.Combine(Storage.modsPath, "Assets")}"));
                progress.Report((2, 5, false));
                System.Threading.Thread.Sleep(100);
                Directory.CreateDirectory(Path.Combine(Storage.modsPath, "References"));
                progressLog.Report(($"Creating References folder", $"Creating.....{Path.Combine(Storage.modsPath, "References")}"));
                progress.Report((3, 5, false));
            }
            System.Threading.Thread.Sleep(100);
            ExtractFiles(Path.Combine(".", "main_msc.pack"), Path.Combine(".", "temp"), progressLog, progress, true);
            System.Threading.Thread.Sleep(100);
            ExtractFiles(Path.Combine(".", "temp","Mods.zip"), Storage.modsPath, progressLog, progress, false);
            System.Threading.Thread.Sleep(100);
            Directory.Delete(Path.Combine(".", "temp"), true);
            progress.Report((5, 5, false));
            progressLog.Report(("Done", "Done!"));
        }

        private void ChangeModsFolderAndCopyWork(string oldPath, IProgress<(string text, string log)> progressLog, IProgress<(int percent, int max, bool isIndeterminate)> progress)
        {
            progress.Report((0, 10, true));
            string[] oldMods = Directory.GetFiles(oldPath, "*.dll");
            string[] oldAssets = Directory.GetDirectories(Path.Combine(oldPath, "Assets"));
            string[] oldRefs = Directory.GetFiles(Path.Combine(oldPath, "References"), "*.dll");
            System.Threading.Thread.Sleep(1500);
            progressLog.Report(($"Copying mods", $"- Start Copying Mods -"));
            for (int i = 0; i < oldMods.Length; i++)
            {
                progressLog.Report(($"Copying mod {Path.GetFileName(oldMods[i])}", $"Copying mod {Path.GetFileName(oldMods[i])}....."));
                progress.Report((i + 1, oldMods.Length, false));
                File.Copy(oldMods[i], Path.Combine(Storage.modsPath, Path.GetFileName(oldMods[i])));
                System.Threading.Thread.Sleep(100);
            }
            progressLog.Report(($"Copying mods", $"- End Copying Mods -"));
            System.Threading.Thread.Sleep(1000);
            progressLog.Report(($"Copying Assets", $"- Start Copying Assets -"));
            for (int i = 0; i < oldAssets.Length; i++)
            {
                DirectoryInfo dir = new DirectoryInfo(oldAssets[i]);
                if (dir.Name.StartsWith("MSCLoader_")) continue;
                progressLog.Report(($"Copying Asset {dir.Name}", $"Copying Asset {dir.Name}....."));
                progress.Report((i + 1, oldAssets.Length, false));
                CopyDirectory(oldAssets[i], Path.Combine(Path.Combine(Storage.modsPath, "Assets"), dir.Name), true);
                System.Threading.Thread.Sleep(100);
            }
            progressLog.Report(($"Copying Assets", $"- End Copying Assets -"));
            System.Threading.Thread.Sleep(1000);
            progressLog.Report(($"Copying Config", $"- Start Copying Config -"));
            CopyDirectory(Path.Combine(oldPath, "Config"), Path.Combine(Storage.modsPath, "Config"), true);
            progressLog.Report(($"Copying Config", $"- End Copying Config -"));
            System.Threading.Thread.Sleep(1000);
            progressLog.Report(($"Copying Refereces", $"- Start Copying Refereces -"));
            for (int i = 0; i < oldRefs.Length; i++)
            {
                progressLog.Report(($"Copying reference {Path.GetFileName(oldRefs[i])}", $"Copying reference {Path.GetFileName(oldMods[i])}....."));
                progress.Report((i + 1, oldRefs.Length, false));
                File.Copy(oldRefs[i], Path.Combine(Path.Combine(Storage.modsPath, "References"), Path.GetFileName(oldRefs[i])));
                System.Threading.Thread.Sleep(100);
            }
            progressLog.Report(($"Copying Refereces", $"- End Copying Refereces -"));
            progress.Report((5, 5, false));
            progressLog.Report(("Done", "Done!"));
        }
        private void UninstallMSCLoaderWork(IProgress<(string text, string log)> progressLog, IProgress<(int percent, int max, bool isIndeterminate)> progress)
        {
            progress.Report((0, 10, true));
            int max = 0;
            System.Threading.Thread.Sleep(1500);
            try
            {
                ZipFile zip1 = ZipFile.Read(Path.Combine(".", "main_ref.pack"));
                max = zip1.Entries.Count+3;
                for (int i = 0; i < zip1.Entries.Count; i++)
                {
                    ZipEntry zz = zip1[i];
                    progressLog.Report(($"Deleting {zz.FileName}", $"Deleting.....{zz.FileName}"));
                    DeleteIfExists(Path.Combine(Storage.mscPath, "mysummercar_Data","Managed" + zz.FileName));
                    progress.Report((i, max, false));
                    System.Threading.Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                progressLog.Report((ex.Message, ex.ToString()));
            }
            System.Threading.Thread.Sleep(100);
            DeleteIfExists(Path.Combine(Storage.mscPath, "mysummercar_Data", "Managed", "MSCLoader.dll"));
            DeleteIfExists(Path.Combine(Storage.mscPath, "mysummercar_Data", "Managed", "MSCLoader.dll.mdb"));
            DeleteIfExists(Path.Combine(Storage.mscPath, "mysummercar_Data", "Managed", "MSCLoader.pdb"));
            progressLog.Report(($"Deleting MSCLoader.dll", $"Deleting.....MSCLoader.dll"));
            progress.Report((max - 2, max, false));
            System.Threading.Thread.Sleep(100);
            DeleteIfExists(Path.Combine(Storage.mscPath, "winhttp.dll"));

            progressLog.Report(($"Deleting winhttp.dll", $"Deleting.....winhttp.dll"));
            progress.Report((max - 1, max, false));
            System.Threading.Thread.Sleep(100);
            DeleteIfExists(Path.Combine(Storage.mscPath, "doorstop_config.ini"));
            progressLog.Report(($"Deleting doorstop_config.ini", $"Deleting.....doorstop_config.ini"));
            progress.Report((max, max, false));
            System.Threading.Thread.Sleep(100);
            progressLog.Report(("Done", "Done!"));

        }
        private void InstallMSCLoaderWork(ModsFolder newfolder, IProgress<(string text, string log)> progressLog, IProgress<(int percent, int max, bool isIndeterminate)> progress)
        {
            bool failed = false;
            progress.Report((0, 10, true));
            progressLog.Report(($"Installing Core Files (1 / 4)", $"Installing Core Files"));
            System.Threading.Thread.Sleep(1500);
            if(Storage.is64)
                ExtractFiles(Path.Combine(".", "core64.pack"), Storage.mscPath, progressLog, progress, false);
            else
                ExtractFiles(Path.Combine(".", "core32.pack"), Storage.mscPath, progressLog, progress, false);
            progress.Report((0, 10, true));
            progressLog.Report(($"Installing References (2 / 4)", $"Installing References"));
            System.Threading.Thread.Sleep(1500);
            ExtractFiles(Path.Combine(".", "main_ref.pack"), Path.Combine(Storage.mscPath, "mysummercar_Data", "Managed"), progressLog, progress, false);
            progress.Report((0, 10, true));
            progressLog.Report(($"Installing MSCLoader (3 / 4)", $"Installing MSCLoader"));
            System.Threading.Thread.Sleep(1500);
            ExtractFiles(Path.Combine(".", "main_msc.pack"), Path.Combine(".", "temp"), progressLog, progress, true);
            System.Threading.Thread.Sleep(100);
            ExtractFiles(Path.Combine(".", "temp", "Managed.zip"), Path.Combine(Storage.mscPath, "mysummercar_Data", "Managed"), progressLog, progress, false);
            progress.Report((0, 10, true));
            progressLog.Report(($"Installing MSCLoader Assets (4 / 4)", $"Installing MSCLoader Assets"));
            System.Threading.Thread.Sleep(1500);
            ExtractFiles(Path.Combine(".", "temp", "Mods.zip"), Storage.modsPath, progressLog, progress, false);
            progress.Report((0, 10, true));
            progressLog.Report(($"Cleaning temp files", $"Cleaning temp files"));
            System.Threading.Thread.Sleep(1500);
            Directory.Delete(Path.Combine(".", "temp"), true);
            progress.Report((0, 10, true));
            progressLog.Report(($"Updating config file", $"Updating config file"));
            System.Threading.Thread.Sleep(1500);
            if (!UpdateConfigFile(newfolder, progressLog, progress))
                failed = true;
            progress.Report((5, 5, false));
            System.Threading.Thread.Sleep(100);
            progressLog.Report(("Done", "Done!"));
        }
        private void UpdateMSCLoaderWork(bool updateCore, bool updateRefs, bool updateMSCL, IProgress<(string text, string log)> progressLog, IProgress<(int percent, int max, bool isIndeterminate)> progress)
        {
            progress.Report((0, 10, true));
            progressLog.Report(($"Updating MSCLoader Files", $"Updating MSCLoader Files"));
            System.Threading.Thread.Sleep(1500);
            if (updateCore)
            {
                if (Storage.is64)
                    ExtractFiles(Path.Combine(".", "core64.pack"), Storage.mscPath, progressLog, progress, false);
                else
                    ExtractFiles(Path.Combine(".", "core32.pack"), Storage.mscPath, progressLog, progress, false);
                progressLog.Report(($"Updating config file", $"Updating config file"));
                System.Threading.Thread.Sleep(100);
                UpdateConfigFile(Storage.modsFolderCfg, progressLog, progress);
            }
            System.Threading.Thread.Sleep(100);
            if (updateRefs)
                ExtractFiles(Path.Combine(".", "main_ref.pack"), Path.Combine(Storage.mscPath, "mysummercar_Data", "Managed"), progressLog, progress, false);
            System.Threading.Thread.Sleep(100);
            if (updateMSCL)
            {
                ExtractFiles(Path.Combine(".", "main_msc.pack"), Path.Combine(".", "temp"), progressLog, progress, true);
                System.Threading.Thread.Sleep(100);
                ExtractFiles(Path.Combine(".", "temp", "Managed.zip"), Path.Combine(Storage.mscPath, "mysummercar_Data", "Managed"), progressLog, progress, false);
                System.Threading.Thread.Sleep(100);
                ExtractFiles(Path.Combine(".", "temp", "Mods.zip"), Storage.modsPath, progressLog, progress, false);
                progress.Report((0, 10, true));
                progressLog.Report(($"Cleaning temp files", $"Cleaning temp files"));
                System.Threading.Thread.Sleep(1500);
                Directory.Delete(Path.Combine(".", "temp"), true);
            }            
            progress.Report((5, 5, false));
            progressLog.Report(("Done", "Done!"));
        }
        private void AddLog(string log)
        {            
            LogBox.AppendText($"{log}{Environment.NewLine}");            
            LogBox.ScrollToEnd();
            Dbg.Log(log);
        }
        private bool ExtractFiles(string fn, string target, IProgress<(string text, string log)> progressLog, IProgress<(int percent, int max, bool isIndeterminate)> progress, bool isTemp)
        {
            try
            {
                if (!ZipFile.IsZipFile(fn))
                {
                    progressLog.Report(($"ERROR: Failed read file: {Path.GetFileName(fn)}", $"ERROR: Failed read file.....{Path.GetFileName(fn)}"));
                    return false;
                }
                else
                {
                    ZipFile zip1 = ZipFile.Read(fn);
                    progressLog.Report(($"Reading file: {Path.GetFileName(fn)}", $"Reading file.....{Path.GetFileName(fn)}"));
                    if(!isTemp)
                        progress.Report((0,zip1.Entries.Count,false));
                    System.Threading.Thread.Sleep(100);

                    for(int i = 0; i < zip1.Entries.Count; i++)
                    {
                        ZipEntry zz = zip1[i];
                        if (!isTemp)
                        {
                            progressLog.Report(($"Copying file: {zz.FileName}", $"Copying file.....{zz.FileName}"));
                            progress.Report((i, zip1.Entries.Count, false));
                        }
                        zz.Extract(target, ExtractExistingFileAction.OverwriteSilently);
                        System.Threading.Thread.Sleep(100);

                    }
                    zip1.Dispose();
                }
                
                return true;
            }
            catch (Exception e)
            {
                progressLog.Report(($"Failed read zip file {e.Message}", $"Failed read zip file{Environment.NewLine}{e}"));
                return false;
            }
        }
        private void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
        private bool UpdateConfigFile(ModsFolder modsFolder, IProgress<(string text, string log)> progressLog, IProgress<(int percent, int max, bool isIndeterminate)> progress)
        {
            string newCfg = "GF";
            switch (modsFolder)
            {
                case ModsFolder.GameFolder:
                    newCfg = "GF";
                    break;
                case ModsFolder.MyDocuments:
                    newCfg = "MD";
                    break;
                case ModsFolder.Appdata:
                    newCfg = "AD";
                    break;
                default:
                    //The fuck happened here?
                    break;
            }
            System.Threading.Thread.Sleep(100);
            if (File.Exists(Path.Combine(Storage.mscPath, "doorstop_config.ini")))
            {
                progressLog.Report(("Reading: doorstop_config.ini", "Reading.....doorstop_config.ini"));
                IniData ini = new FileIniDataParser().ReadFile(Path.Combine(Storage.mscPath, "doorstop_config.ini"));
                System.Threading.Thread.Sleep(100);
                ini["MSCLoader"]["mods"] = newCfg;
                ini["MSCLoader"]["skipIntro"] = Storage.skipIntroCfg.ToString().ToLower();
                ini["MSCLoader"]["skipConfigScreen"] = Storage.skipConfigScreenCfg.ToString().ToLower();
                progressLog.Report(("Writing: doorstop_config.ini", "Writing.....doorstop_config.ini"));
                new FileIniDataParser().WriteFile(Path.Combine(Storage.mscPath, "doorstop_config.ini"), ini, System.Text.Encoding.ASCII);
                System.Threading.Thread.Sleep(100);
                return true;
            }
            else
            {
                //This is probably super outdated MSCLoader.
                progressLog.Report(("ERROR: doorstop_config.ini does not exist", "ERROR: doorstop_config.ini does not exist"));
                progressLog.Report(("ERROR: doorstop_config.ini does not exist", "Please re-install MSCLoader first."));
                return false;
            }
        }
        private void DeleteIfExists(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }
    }
}
