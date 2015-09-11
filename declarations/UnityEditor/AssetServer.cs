﻿namespace UnityEditor
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using UnityEngine;
    using UnityEngine.Internal;

    internal sealed class AssetServer
    {
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void AdminChangePassword(string userName, string newPassword);
        [ExcludeFromDocs]
        public static int AdminCreateDB(string newProjectName)
        {
            string copyFromProjectName = string.Empty;
            return AdminCreateDB(newProjectName, copyFromProjectName);
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern int AdminCreateDB(string newProjectName, [DefaultValue("\"\"")] string copyFromProjectName);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern int AdminCreateUser(string userName, string userFullName, string userEmail, string userPassword);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern int AdminDeleteDB(string projectName);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern int AdminDeleteUser(string userName);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern MaintUserRecord[] AdminGetUsers(string databaseName);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool AdminModifyUserInfo(string databaseName, string userName, string fullName, string email);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern MaintDatabaseRecord[] AdminRefreshDatabases();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void AdminSetCredentials(string server, int port, string user, string password);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool AdminSetUserEnabled(string databaseName, string userName, string fullName, string email, int enabled);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool AssetIsBinaryByGUID(string guid);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool AssetIsDir(string guid);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern AssetsItem[] BuildAllExportPackageAssetListAssetsItems();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern AssetsItem[] BuildExportPackageAssetListAssetsItems(string[] guids, bool dependencies);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void CheckForServerUpdates();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void Clear();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void ClearAssetServerError();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void ClearCommitPersistentData();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void ClearRefreshCommit();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void ClearRefreshUpdate();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string[] CollectAllChildren(string guid, string[] collection);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string[] CollectAllDependencies(string[] selection);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string[] CollectDeepSelection();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string[] CollectSelection();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool CommitAbort();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool CommitBegin(string changeDescription, string[] candidates);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool CommitComplete();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern float CommitGetUploadProgress();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool CommitStartUpload();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool CompareFiles(string[] guids, CompareInfo[] selection);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void DoCommitOnNextTick(string description, string[] guids);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void DoRecoverOnNextTick(DeletedAsset[] assets);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void DoRefreshAssetsAndUpdateStatusOnNextTick();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void DoRefreshAssetsOnNextTick();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void DoRevertOnNextTick(int changeset, string guid);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void DoUpdateOnNextTick(bool forceShowConflictResolutions, string backendFunctionForConflictResolutions);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void DoUpdateStatusOnNextTick();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        internal static extern void DoUpdateWithoutConflictResolutionOnNextTick(string[] guids);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void ExportPackage(string[] guids, string fileName);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string[] GetAllRootGUIDs();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string GetAndRemoveString(string strName);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string GetAssetPathName(string guid);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string GetAssetServerError();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern int GetCachesInitialized();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        internal static extern ChangeFlags GetChangeFlags(string guid);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string[] GetCommitSelectionGUIDs();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string GetDatabaseName(string server, string user, string password, string port, string projectName);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string GetDeletedItemPathAndName(string guid);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern DownloadResolution GetDownloadResolution(string guid);
        [ExcludeFromDocs]
        public static Changeset[] GetHistory()
        {
            int downToRevision = -1;
            return GetHistory(downToRevision);
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern Changeset[] GetHistory([DefaultValue("-1")] int downToRevision);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern Changeset[] GetHistorySelected(string[] guids);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string GetLastCommitMessage();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern int GetLastControllerActionResult();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern AssetsItem[] GetLocalDeletedItems();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern NameConflictResolution GetNameConflictResolution(string guid);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern Changeset[] GetNewItems();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string GetParentGUID(string itemGUID, int changeset);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string GetPathNameConflict(string guid);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string GetProgressText();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool GetRefreshCommit();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool GetRefreshUpdate();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string GetRootGUID();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern DeletedAsset[] GetServerDeletedItems();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern int GetServerItemChangeset(string guid, int changeset);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        internal static extern AssetStatus GetStatus(UnityEngine.Object asset);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        internal static extern AssetStatus GetStatusGUID(string guidString);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string GetString(string strName);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern int GetWorkingItemChangeset(string guid);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool HasConnectionError();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool HasDeletionConflict(string guid);
        private static AssetsItem[] ImportPackageStep1(string packagePath)
        {
            string str;
            return ImportPackageStep1(packagePath, out str);
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern AssetsItem[] ImportPackageStep1(string packagePath, out string packageIconPath);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void ImportPackageStep2(AssetsItem[] assets);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void Initialize(string userName, string connectionString, int timeout);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern int IsAssetAvailable(string guid);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern int IsAssetBinary(string name);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern int IsConstantGUID(string guid);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern int IsControllerBusy();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern int IsGUIDValid(string guid);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool IsItemDeleted(string guid);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool RecoverDeleted(string assetGUID, int version, string name, string parentGUID);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void RemoveMaintErrorsFromConsole();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool RevertVersion(string assetGUID, int version);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void SaveString(string strName, string strValue);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void SetAfterActionFinishedCallback(string className, string functionName);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void SetAssetServerError(string error, bool isConnectionError);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void SetCommitSelectionGUIDs(string[] guids);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void SetDownloadResolution(string guid, DownloadResolution res);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void SetDownloadResolutionInt(string guid, int res);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void SetLastCommitMessage(string message);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void SetNameConflictResolution(string guid, NameConflictResolution res);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void SetProjectName(string name);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void SetSelectionFromGUID(string guid);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void SetSelectionFromGUIDs(string[] guids);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern void SetStickyChangeset(int changeset);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        internal static extern void ShowDialogOnNextTick(string title, string text, string button1, string button2);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern string UnityGUID(int a, int b, int c, int d);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool UpdateAbort();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool UpdateComplete();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        internal static extern string[] UpdateGetConflicts();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern float UpdateGetDownloadProgress();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        internal static extern bool UpdateSetResolutions(string[] guids, DownloadResolution[] resolutions);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public static extern bool UpdateStartDownload();
    }
}

