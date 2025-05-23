﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HT.Framework
{
    /// <summary>
    /// 资源管理器的助手接口
    /// </summary>
    public interface IResourceHelper : IInternalModuleHelper
    {
        /// <summary>
        /// 当前的资源加载模式
        /// </summary>
        ResourceLoadMode LoadMode { get; }
        /// <summary>
        /// 是否是编辑器模式
        /// </summary>
        bool IsEditorMode { get; }
        /// <summary>
        /// 是否打印资源加载细节日志
        /// </summary>
        bool IsLogDetail { get; }
        /// <summary>
        /// AssetBundle资源加载根路径
        /// </summary>
        string AssetBundleRootPath { get; }
        /// <summary>
        /// 所有AssetBundle资源包清单的名称
        /// </summary>
        string AssetBundleManifestName { get; }
        /// <summary>
        /// 缓存的所有AssetBundle包【AB包名称、AB包】
        /// </summary>
        Dictionary<string, AssetBundle> AssetBundles { get; }
        /// <summary>
        /// 所有AssetBundle资源包清单
        /// </summary>
        AssetBundleManifest Manifest { get; }
        /// <summary>
        /// 所有AssetBundle的Hash128值【AB包名称、Hash128值】
        /// </summary>
        Dictionary<string, Hash128> AssetBundleHashs { get; }

        /// <summary>
        /// 设置加载器
        /// </summary>
        /// <param name="loadMode">加载模式</param>
        /// <param name="isEditorMode">是否是编辑器模式</param>
        /// <param name="manifestName">AB包清单名称</param>
        /// <param name="isLogDetail">是否打印资源加载细节日志</param>
        void SetLoader(ResourceLoadMode loadMode, bool isEditorMode, string manifestName, bool isLogDetail);
        /// <summary>
        /// 设置AssetBundle资源根路径（仅限 AssetBundle 模式）
        /// </summary>
        /// <param name="path">AssetBundle资源根路径</param>
        void SetAssetBundlePath(string path);
        /// <summary>
        /// 通过名称获取指定的AssetBundle（仅限 AssetBundle 模式）
        /// </summary>
        /// <param name="assetBundleName">名称</param>
        /// <returns>AssetBundle</returns>
        AssetBundle GetAssetBundle(string assetBundleName);

        /// <summary>
        /// 加载资源（异步）
        /// </summary>
        /// <typeparam name="T">资源类型</typeparam>
        /// <param name="info">资源信息标记</param>
        /// <param name="onLoading">加载中事件</param>
        /// <param name="onLoadDone">加载完成事件</param>
        /// <param name="isPrefab">是否是加载预制体</param>
        /// <param name="parent">预制体加载完成后的父级</param>
        /// <param name="isUI">是否是加载UI</param>
        /// <returns>加载协程迭代器</returns>
        IEnumerator LoadAssetAsync<T>(ResourceInfoBase info, HTFAction<float> onLoading, HTFAction<T> onLoadDone, bool isPrefab, Transform parent, bool isUI) where T : UnityEngine.Object;
        /// <summary>
        /// 加载场景（异步）
        /// </summary>
        /// <param name="info">资源信息标记</param>
        /// <param name="onLoading">加载中事件</param>
        /// <param name="onLoadDone">加载完成事件</param>
        /// <returns>加载协程迭代器</returns>
        IEnumerator LoadSceneAsync(SceneInfo info, HTFAction<float> onLoading, HTFAction onLoadDone);
        /// <summary>
        /// 加载资源（异步）
        /// </summary>
        /// <typeparam name="T">资源类型</typeparam>
        /// <param name="location">资源定位Key，可以为资源路径、或资源名称</param>
        /// <param name="type">资源标记类型</param>
        /// <param name="onLoading">加载中事件</param>
        /// <param name="onLoadDone">加载完成事件</param>
        /// <param name="isPrefab">是否是加载预制体</param>
        /// <param name="parent">预制体加载完成后的父级</param>
        /// <param name="isUI">是否是加载UI</param>
        /// <returns>加载协程迭代器</returns>
        IEnumerator LoadAssetAsync<T>(string location, Type type, HTFAction<float> onLoading, HTFAction<T> onLoadDone, bool isPrefab, Transform parent, bool isUI) where T : UnityEngine.Object;
        /// <summary>
        /// 加载场景（异步）
        /// </summary>
        /// <param name="location">资源定位Key，可以为资源路径、或资源名称</param>
        /// <param name="onLoading">加载中事件</param>
        /// <param name="onLoadDone">加载完成事件</param>
        /// <returns>加载协程迭代器</returns>
        IEnumerator LoadSceneAsync(string location, HTFAction<float> onLoading, HTFAction onLoadDone);

        /// <summary>
        /// 卸载资源（仅限 Addressables 模式）
        /// </summary>
        /// <param name="location">资源定位Key，可以为资源路径、或资源名称</param>
        void UnLoadAsset(string location);
        /// <summary>
        /// 卸载AB包（异步，仅限 AssetBundle 模式）
        /// </summary>
        /// <param name="assetBundleName">AB包名称</param>
        /// <param name="unloadAllLoadedObjects">是否同时卸载所有实体对象</param>
        /// <returns>卸载协程迭代器</returns>
        IEnumerator UnLoadAssetBundleAsync(string assetBundleName, bool unloadAllLoadedObjects);
        /// <summary>
        /// 卸载所有AB包（异步，仅限 AssetBundle 模式）
        /// </summary>
        /// <param name="unloadAllLoadedObjects">是否同时卸载所有实体对象</param>
        /// <returns>卸载协程迭代器</returns>
        IEnumerator UnLoadAllAssetBundleAsync(bool unloadAllLoadedObjects);
        /// <summary>
        /// 卸载场景（异步）
        /// </summary>
        /// <param name="info">资源信息标记</param>
        /// <returns>卸载协程迭代器</returns>
        IEnumerator UnLoadSceneAsync(SceneInfo info);
        /// <summary>
        /// 卸载场景（异步）
        /// </summary>
        /// <param name="location">资源定位Key，可以为资源路径、或资源名称</param>
        /// <returns>卸载协程迭代器</returns>
        IEnumerator UnLoadSceneAsync(string location);
        /// <summary>
        /// 卸载所有场景（异步）
        /// </summary>
        /// <returns>卸载协程迭代器</returns>
        IEnumerator UnLoadAllSceneAsync();

        /// <summary>
        /// 清理内存，释放空闲内存（异步）
        /// </summary>
        /// <returns>协程迭代器</returns>
        IEnumerator ClearMemory();
    }
}