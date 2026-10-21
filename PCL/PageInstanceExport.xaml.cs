using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using MeloongCore;
using MeloongCore.Extensions;
using MeloongCore.Wpf;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCLCS;

namespace PCL;

[DesignerGenerated]
public partial class PageInstanceExport : MyPageRight, IRefreshable, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal new sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Func<DirectoryInfo, DateTime> _0024I7_002D1;

		public static Func<FileInfo, string> _0024I8_002D3;

		public static Func<LocalResourceFile, string> _0024I25_002D6;

		public static Func<LocalResourceFile, uint> _0024I25_002D8;

		public static Func<string, bool> _0024I25_002D11;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal DateTime _Lambda_0024__7_002D1(DirectoryInfo f)
		{
			return f.LastWriteTime;
		}

		[SpecialName]
		internal string _Lambda_0024__8_002D3(FileInfo f)
		{
			return f.Name;
		}

		[SpecialName]
		internal string _Lambda_0024__25_002D6(LocalResourceFile m)
		{
			return m.ModrinthHash;
		}

		[SpecialName]
		internal uint _Lambda_0024__25_002D8(LocalResourceFile m)
		{
			return m.CurseForgeHash;
		}

		[SpecialName]
		internal bool _Lambda_0024__25_002D11(string u)
		{
			return u.Contains("modrinth.com");
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__25_002D0
	{
		public string _0024VB_0024Local_CacheFolder;

		public string _0024VB_0024Local_PathIndie;

		public List<string> _0024VB_0024Local_AllRules;

		public string _0024VB_0024Local_OverridesFolder;

		public bool _0024VB_0024Local_CheckHostedAssets;

		public bool _0024VB_0024Local_IncludeJava;

		public ModMinecraft.McInstance _0024VB_0024Local_TargetInstance;

		public bool _0024VB_0024Local_IncludePCL;

		public List<string> _0024VB_0024Local_AllExtraFiles;

		public bool _0024VB_0024Local_IncludePCLCustom;

		public string _0024VB_0024Local_LoaderName;

		public bool _0024VB_0024Local_ModrinthUploadMode;

		public string _0024VB_0024Local_PackVersion;

		public string _0024VB_0024Local_PackName;

		public string _0024VB_0024Local_PackPath;

		public _Closure_0024__25_002D0(_Closure_0024__25_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_CacheFolder = arg0._0024VB_0024Local_CacheFolder;
				_0024VB_0024Local_PathIndie = arg0._0024VB_0024Local_PathIndie;
				_0024VB_0024Local_AllRules = arg0._0024VB_0024Local_AllRules;
				_0024VB_0024Local_OverridesFolder = arg0._0024VB_0024Local_OverridesFolder;
				_0024VB_0024Local_CheckHostedAssets = arg0._0024VB_0024Local_CheckHostedAssets;
				_0024VB_0024Local_IncludeJava = arg0._0024VB_0024Local_IncludeJava;
				_0024VB_0024Local_TargetInstance = arg0._0024VB_0024Local_TargetInstance;
				_0024VB_0024Local_IncludePCL = arg0._0024VB_0024Local_IncludePCL;
				_0024VB_0024Local_AllExtraFiles = arg0._0024VB_0024Local_AllExtraFiles;
				_0024VB_0024Local_IncludePCLCustom = arg0._0024VB_0024Local_IncludePCLCustom;
				_0024VB_0024Local_LoaderName = arg0._0024VB_0024Local_LoaderName;
				_0024VB_0024Local_ModrinthUploadMode = arg0._0024VB_0024Local_ModrinthUploadMode;
				_0024VB_0024Local_PackVersion = arg0._0024VB_0024Local_PackVersion;
				_0024VB_0024Local_PackName = arg0._0024VB_0024Local_PackName;
				_0024VB_0024Local_PackPath = arg0._0024VB_0024Local_PackPath;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(ModLoader.LoaderTask<int, int> Loader)
		{
			ModSecret.DownloadLatestPCL(Loader);
			FileUtils.Copy(ModBase.PathTemp + "Latest.exe", _0024VB_0024Local_CacheFolder + "Plain Craft Launcher.exe");
		}

		[SpecialName]
		internal void _Lambda_0024__1(ModLoader.LoaderTask<int, List<LocalResourceFile>> Loader)
		{
			_Closure_0024__25_002D1 arg = default;
			_Closure_0024__25_002D1 CS_0024_003C_003E8__locals24 = new _Closure_0024__25_002D1(arg);
			CS_0024_003C_003E8__locals24._0024VB_0024NonLocal__0024VB_0024Closure_2 = this;
			CS_0024_003C_003E8__locals24._0024VB_0024Local_Loader = Loader;
			CS_0024_003C_003E8__locals24._0024VB_0024Local_Loader.Output = new List<LocalResourceFile>();
			CS_0024_003C_003E8__locals24._0024VB_0024Local_Progress = 0;
			CS_0024_003C_003E8__locals24._0024VB_0024Local_SearchFolder = checked([SpecialName] (DirectoryInfo Folder) =>
			{
				foreach (DirectoryInfo item in Folder.EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
				{
					if ((!new string[3] { "assets", "versions", "libraries" }.Contains(item.Name) || !PathUtils.IsSame(CS_0024_003C_003E8__locals24._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_PathIndie, Folder.FullName)) && !new string[5] { "structureCacheV1", ".fabric", ".git", "avatar-cache", "cosmetic-cache" }.Contains(item.Name))
					{
						CS_0024_003C_003E8__locals24._0024VB_0024Local_SearchFolder(item);
					}
				}
				_Closure_0024__25_002D2 obj = default;
				foreach (FileInfo item2 in Folder.EnumerateFiles("*", SearchOption.TopDirectoryOnly))
				{
					obj = new _Closure_0024__25_002D2(obj);
					obj._0024VB_0024Local_RelativePath = item2.FullName.AfterFirst(CS_0024_003C_003E8__locals24._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_PathIndie);
					bool flag = false;
					foreach (string item3 in CS_0024_003C_003E8__locals24._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_AllRules)
					{
						bool flag2 = item3.StartsWithF("!");
						if (LikeOperator.LikeString(obj._0024VB_0024Local_RelativePath.Lower(), item3.TrimStart('!').Lower(), CompareMethod.Binary))
						{
							flag = !flag2;
						}
					}
					if (flag)
					{
						string text4 = CS_0024_003C_003E8__locals24._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_OverridesFolder + obj._0024VB_0024Local_RelativePath;
						FileUtils.Copy(item2.FullName, text4);
						if (CS_0024_003C_003E8__locals24._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_CheckHostedAssets && new string[5] { ".zip", ".rar", ".jar", ".disabled", ".old" }.Contains(item2.Extension.Lower()) && new string[4] { "mods", "packs", "openloader", "resource" }.Any(obj._Lambda_0024__3))
						{
							LocalResourceFile localResourceFile = new LocalResourceFile(text4);
							_ = localResourceFile.ModrinthHash;
							Conversions.ToString(localResourceFile.CurseForgeHash);
							CS_0024_003C_003E8__locals24._0024VB_0024Local_Loader.Output.Add(localResourceFile);
						}
						CS_0024_003C_003E8__locals24._0024VB_0024Local_Progress++;
						if (CS_0024_003C_003E8__locals24._0024VB_0024Local_Progress == 25)
						{
							CS_0024_003C_003E8__locals24._0024VB_0024Local_Loader.Progress += (0.84 - CS_0024_003C_003E8__locals24._0024VB_0024Local_Loader.Progress) * 0.012;
							CS_0024_003C_003E8__locals24._0024VB_0024Local_Progress = 0;
						}
					}
				}
			});
			CS_0024_003C_003E8__locals24._0024VB_0024Local_SearchFolder(DirectoryUtils.GetInfo(_0024VB_0024Local_PathIndie));
			Logger.Info($"复制 overrides 文件完成，有 {CS_0024_003C_003E8__locals24._0024VB_0024Local_Loader.Output.Count} 个文件需要联网检查", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
			CS_0024_003C_003E8__locals24._0024VB_0024Local_Loader.Progress = 0.85;
			if (_0024VB_0024Local_IncludeJava)
			{
				string text = PathUtils.RemoveLastPart((ModJava.SelectOrDownloadJava(_0024VB_0024Local_TargetInstance, TryFixOrHint: false, CS_0024_003C_003E8__locals24._0024VB_0024Local_Loader.CreateCancellationToken(), CS_0024_003C_003E8__locals24._0024VB_0024Local_Loader.CreateSyncProgressProvider(0.85, 0.93)) ?? throw new FileNotFoundException("版本文件夹中没有找到可导出的 Java。")).Folder);
				string text2 = Path.Combine(_0024VB_0024Local_OverridesFolder, text.AfterFirst(_0024VB_0024Local_TargetInstance.PathVersion, ignoreCase: true));
				DirectoryUtils.Copy(text, text2);
				Logger.Info($"已复制版本文件夹中的 Java：{text} → {text2}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
			}
			CS_0024_003C_003E8__locals24._0024VB_0024Local_Loader.Progress = 0.95;
			string text3 = (_0024VB_0024Local_IncludePCL ? _0024VB_0024Local_CacheFolder : (_0024VB_0024Local_CacheFolder + "modpack\\"));
			foreach (string item4 in _0024VB_0024Local_AllExtraFiles)
			{
				if (item4.EndsWithF("\\") || item4.EndsWithF("/"))
				{
					if (DirectoryUtils.Exists(item4))
					{
						DirectoryUtils.Copy(item4, text3 + PathUtils.GetLastPart(item4) + "\\");
					}
					else
					{
						ModMain.Hint($"未找到配置文件中指定的文件夹：{item4}", ModMain.HintType.Red);
					}
				}
				else if (FileUtils.Exists(item4))
				{
					FileUtils.Copy(item4, text3 + PathUtils.GetLastPart(item4));
				}
				else
				{
					ModMain.Hint($"未找到配置文件中指定的单个文件：{item4}", ModMain.HintType.Red);
				}
			}
			CS_0024_003C_003E8__locals24._0024VB_0024Local_Loader.Progress = 0.97;
			if (DirectoryUtils.Exists(_0024VB_0024Local_TargetInstance.PathVersion + "PCL\\"))
			{
				DirectoryUtils.Copy(_0024VB_0024Local_TargetInstance.PathVersion + "PCL\\", _0024VB_0024Local_OverridesFolder + "PCL\\");
			}
			ModBase.WriteIni(_0024VB_0024Local_OverridesFolder + "PCL\\Setup.ini", "IsStar", Conversions.ToString(Value: false));
			if (_0024VB_0024Local_IncludePCLCustom)
			{
				if (DirectoryUtils.Exists(Paths.Base + "PCL\\Pictures\\"))
				{
					DirectoryUtils.Copy(Paths.Base + "PCL\\Pictures\\", _0024VB_0024Local_CacheFolder + "PCL\\Pictures\\");
				}
				if (DirectoryUtils.Exists(Paths.Base + "PCL\\Musics\\"))
				{
					DirectoryUtils.Copy(Paths.Base + "PCL\\Musics\\", _0024VB_0024Local_CacheFolder + "PCL\\Musics\\");
				}
				if (DirectoryUtils.Exists(Paths.Base + "PCL\\Help\\"))
				{
					DirectoryUtils.Copy(Paths.Base + "PCL\\Help\\", _0024VB_0024Local_CacheFolder + "PCL\\Help\\");
				}
				if (FileUtils.Exists(Paths.Base + "PCL\\Custom.xaml"))
				{
					FileUtils.Copy(Paths.Base + "PCL\\Custom.xaml", _0024VB_0024Local_CacheFolder + "PCL\\Custom.xaml");
				}
				if (FileUtils.Exists(Paths.Base + "PCL\\Setup.ini"))
				{
					FileUtils.Copy(Paths.Base + "PCL\\Setup.ini", _0024VB_0024Local_CacheFolder + "PCL\\Setup.ini");
				}
				if (FileUtils.Exists(Paths.Base + "PCL\\hints.txt"))
				{
					FileUtils.Copy(Paths.Base + "PCL\\hints.txt", _0024VB_0024Local_CacheFolder + "PCL\\hints.txt");
				}
				if (FileUtils.Exists(Paths.Base + "PCL\\Logo.png"))
				{
					FileUtils.Copy(Paths.Base + "PCL\\Logo.png", _0024VB_0024Local_CacheFolder + "PCL\\Logo.png");
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__4(ModLoader.LoaderTask<List<LocalResourceFile>, Dictionary<LocalResourceFile, List<string>>> Loader)
		{
			_Closure_0024__25_002D3 arg = default;
			_Closure_0024__25_002D3 CS_0024_003C_003E8__locals25 = new _Closure_0024__25_002D3(arg);
			CS_0024_003C_003E8__locals25._0024VB_0024NonLocal__0024VB_0024Closure_3 = this;
			CS_0024_003C_003E8__locals25._0024VB_0024Local_Loader = Loader;
			CS_0024_003C_003E8__locals25._0024VB_0024Local_Loader.Output = new Dictionary<LocalResourceFile, List<string>>();
			if (!_0024VB_0024Local_CheckHostedAssets)
			{
				Logger.Info("要求跳过联网获取步骤", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
				return;
			}
			if (!CS_0024_003C_003E8__locals25._0024VB_0024Local_Loader.Input.Any())
			{
				Logger.Info("没有需要联网检查的文件，跳过联网获取步骤", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
				return;
			}
			CS_0024_003C_003E8__locals25._0024VB_0024Local_EndedThreadCount = 0;
			CS_0024_003C_003E8__locals25._0024VB_0024Local_FailedExceptions = new List<Exception>();
			checked
			{
				ModBase.RunInNewThread([SpecialName] () =>
				{
					try
					{
						IEnumerable<string> list = CS_0024_003C_003E8__locals25._0024VB_0024Local_Loader.Input.Select([SpecialName] (LocalResourceFile m) => m.ModrinthHash);
						JObject jObject = (JObject)ModDownload.DlModRequest("https://api.modrinth.com/v2/version_files", HttpMethod.Post, string.Format("{{\"hashes\": [\"{0}\"], \"algorithm\": \"sha1\"}}", list.Join("\",\"")), "application/json");
						foreach (LocalResourceFile item in CS_0024_003C_003E8__locals25._0024VB_0024Local_Loader.Input)
						{
							if (jObject.ContainsKey(item.ModrinthHash) && !((string?)jObject[item.ModrinthHash]?["files"]?[0]["hashes"]?["sha1"] != item.ModrinthHash))
							{
								CS_0024_003C_003E8__locals25._0024VB_0024Local_Loader.Output.AddIntoValueCollection(item, (string?)jObject[item.ModrinthHash]["files"][0]["url"]);
							}
						}
						Logger.Info($"从 Modrinth 获取到 {jObject.Count} 个本地资源项的对应信息", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						Logger.Warn(ex2, "从 Modrinth 获取本地 Mod 信息失败", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
						CS_0024_003C_003E8__locals25._0024VB_0024Local_FailedExceptions.Add(ex2);
						ProjectData.ClearProjectError();
					}
					finally
					{
						CS_0024_003C_003E8__locals25._0024VB_0024Local_EndedThreadCount++;
						CS_0024_003C_003E8__locals25._0024VB_0024Local_Loader.Progress += 0.45;
					}
				}, "Modrinth - " + _0024VB_0024Local_LoaderName);
				ModBase.RunInNewThread([SpecialName] () =>
				{
					try
					{
						if (!CS_0024_003C_003E8__locals25._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_ModrinthUploadMode)
						{
							IEnumerable<uint> list = CS_0024_003C_003E8__locals25._0024VB_0024Local_Loader.Input.Select([SpecialName] (LocalResourceFile m) => m.CurseForgeHash);
							JContainer jContainer = (JContainer)ModDownload.DlModRequest("https://api.curseforge.com/v1/fingerprints/432", HttpMethod.Post, string.Format("{{\"fingerprints\": [{0}]}}", list.Join(",")), "application/json")["data"]["exactMatches"];
							_Closure_0024__25_002D4 obj = default;
							foreach (JObject item2 in (IEnumerable<JToken>)jContainer)
							{
								obj = new _Closure_0024__25_002D4(obj);
								if (item2.ContainsKey("file"))
								{
									obj._0024VB_0024Local_File = (JObject)item2["file"];
									if (!string.IsNullOrEmpty((string?)obj._0024VB_0024Local_File["downloadUrl"]))
									{
										LocalResourceFile localResourceFile = CS_0024_003C_003E8__locals25._0024VB_0024Local_Loader.Input.FirstOrDefault(obj._Lambda_0024__9);
										if (localResourceFile != null)
										{
											foreach (string item3 in ResourceVersion.ParseCurseForgeDownloadUrls(obj._0024VB_0024Local_File["downloadUrl"].ToString()))
											{
												CS_0024_003C_003E8__locals25._0024VB_0024Local_Loader.Output.AddIntoValueCollection(localResourceFile, item3);
											}
										}
									}
								}
							}
							Logger.Info($"从 CurseForge 获取到 {jContainer.Count} 个本地资源项的对应信息", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						Logger.Warn(ex2, "从 CurseForge 获取本地 Mod 信息失败", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
						CS_0024_003C_003E8__locals25._0024VB_0024Local_FailedExceptions.Add(ex2);
						ProjectData.ClearProjectError();
					}
					finally
					{
						CS_0024_003C_003E8__locals25._0024VB_0024Local_EndedThreadCount++;
						CS_0024_003C_003E8__locals25._0024VB_0024Local_Loader.Progress += 0.45;
					}
				}, "CurseForge - " + _0024VB_0024Local_LoaderName);
				while (true)
				{
					if (CS_0024_003C_003E8__locals25._0024VB_0024Local_EndedThreadCount != 2)
					{
						if (!CS_0024_003C_003E8__locals25._0024VB_0024Local_Loader.IsCanceled)
						{
							Thread.Sleep(10);
							continue;
						}
						break;
					}
					if (CS_0024_003C_003E8__locals25._0024VB_0024Local_FailedExceptions.Count == 1)
					{
						if (ModMain.MyMsgBox("联网获取部分文件信息失败，是否继续导出？\r\n\r\n若继续，无法获取信息的文件将被直接打包。\r\n由于二次分发可能违反使用协议，请尽量不要公开发布导出的整合包！", "部分文件信息获取失败", "继续", "取消") == 2)
						{
							throw CS_0024_003C_003E8__locals25._0024VB_0024Local_FailedExceptions.First();
						}
						break;
					}
					if (CS_0024_003C_003E8__locals25._0024VB_0024Local_FailedExceptions.Count > 1 && ModMain.MyMsgBox("联网获取文件信息失败，是否继续导出？\r\n\r\n若继续，所有文件都将被直接打包。\r\n由于二次分发可能违反使用协议，请尽量不要公开发布导出的整合包！", "文件信息获取失败", "继续", "取消") == 2)
					{
						throw CS_0024_003C_003E8__locals25._0024VB_0024Local_FailedExceptions.First();
					}
					break;
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__10(ModLoader.LoaderTask<Dictionary<LocalResourceFile, List<string>>, int> Loader)
		{
			JArray jArray = new JArray();
			foreach (KeyValuePair<LocalResourceFile, List<string>> item in Loader.Input)
			{
				LocalResourceFile key = item.Key;
				jArray.Add(new JObject
				{
					{
						"path",
						PathUtils.RemoveExtendedPrefix(key.File.FullName).AfterFirst(_0024VB_0024Local_OverridesFolder).Replace("\\", "/")
					},
					{
						"hashes",
						new JObject
						{
							{ "sha1", key.ModrinthHash },
							{
								"sha512",
								CryptographyUtils.ComputeFileHash(key.File.FullName, CryptographyUtils.HashMethod.Sha512)
							}
						}
					},
					{
						"downloads",
						new JArray(item.Value.OrderBy((_Closure_0024__._0024I25_002D11 == null) ? (_Closure_0024__._0024I25_002D11 = [SpecialName] (string u) => u.Contains("modrinth.com")) : _Closure_0024__._0024I25_002D11))
					},
					{
						"fileSize",
						key.File.Length
					}
				});
				key.File.Delete();
			}
			Loader.Progress = 0.2;
			JObject jObject = new JObject { 
			{
				"minecraft",
				_0024VB_0024Local_TargetInstance.Version.VanillaName
			} };
			if (_0024VB_0024Local_TargetInstance.Version.ModLoaders.HasFlagF(ModLoaders.Forge))
			{
				jObject.Add("forge", _0024VB_0024Local_TargetInstance.Version.ModLoaderVersions[ModLoaders.Forge]);
			}
			if (_0024VB_0024Local_TargetInstance.Version.ModLoaders.HasFlagF(ModLoaders.Fabric))
			{
				jObject.Add("fabric-loader", _0024VB_0024Local_TargetInstance.Version.ModLoaderVersions[ModLoaders.Fabric]);
			}
			if (_0024VB_0024Local_TargetInstance.Version.ModLoaders.HasFlagF(ModLoaders.NeoForge))
			{
				jObject.Add("neoforge", _0024VB_0024Local_TargetInstance.Version.ModLoaderVersions[ModLoaders.NeoForge]);
			}
			JObject jObject2 = new JObject
			{
				{ "game", "minecraft" },
				{ "formatVersion", 1 },
				{ "versionId", _0024VB_0024Local_PackVersion },
				{ "name", _0024VB_0024Local_PackName },
				{ "summary", _0024VB_0024Local_TargetInstance.Info },
				{ "files", jArray },
				{ "dependencies", jObject }
			};
			FileUtils.Write(_0024VB_0024Local_CacheFolder + "modpack\\modrinth.index.json", jObject2.ToString(Formatting.Indented));
			if (_0024VB_0024Local_IncludePCL)
			{
				FileUtils.CreateZipFromDirectory(_0024VB_0024Local_CacheFolder + "modpack.mrpack", _0024VB_0024Local_CacheFolder + "modpack\\");
				Loader.Progress = 0.5;
				DirectoryUtils.Delete(_0024VB_0024Local_CacheFolder + "modpack\\");
				Loader.Progress = 0.6;
				FileUtils.CreateZipFromDirectory(_0024VB_0024Local_PackPath, _0024VB_0024Local_CacheFolder);
				Loader.Progress = 0.9;
			}
			else
			{
				FileUtils.CreateZipFromDirectory(_0024VB_0024Local_PackPath, _0024VB_0024Local_CacheFolder + "modpack\\");
				Loader.Progress = 0.8;
			}
			ModBase.OpenExplorer(_0024VB_0024Local_PackPath);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__25_002D1
	{
		public Action<DirectoryInfo> _0024VB_0024Local_SearchFolder;

		public ModLoader.LoaderTask<int, List<LocalResourceFile>> _0024VB_0024Local_Loader;

		public int _0024VB_0024Local_Progress;

		public _Closure_0024__25_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__25_002D1(_Closure_0024__25_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_SearchFolder = arg0._0024VB_0024Local_SearchFolder;
				_0024VB_0024Local_Loader = arg0._0024VB_0024Local_Loader;
				_0024VB_0024Local_Progress = arg0._0024VB_0024Local_Progress;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__2(DirectoryInfo Folder)
		{
			foreach (DirectoryInfo item in Folder.EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
			{
				if ((!new string[3] { "assets", "versions", "libraries" }.Contains(item.Name) || !PathUtils.IsSame(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_PathIndie, Folder.FullName)) && !new string[5] { "structureCacheV1", ".fabric", ".git", "avatar-cache", "cosmetic-cache" }.Contains(item.Name))
				{
					_0024VB_0024Local_SearchFolder(item);
				}
			}
			checked
			{
				_Closure_0024__25_002D2 obj = default;
				foreach (FileInfo item2 in Folder.EnumerateFiles("*", SearchOption.TopDirectoryOnly))
				{
					obj = new _Closure_0024__25_002D2(obj);
					obj._0024VB_0024Local_RelativePath = item2.FullName.AfterFirst(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_PathIndie);
					bool flag = false;
					foreach (string item3 in _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_AllRules)
					{
						bool flag2 = item3.StartsWithF("!");
						if (LikeOperator.LikeString(obj._0024VB_0024Local_RelativePath.Lower(), item3.TrimStart('!').Lower(), CompareMethod.Binary))
						{
							flag = !flag2;
						}
					}
					if (flag)
					{
						string text = _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_OverridesFolder + obj._0024VB_0024Local_RelativePath;
						FileUtils.Copy(item2.FullName, text);
						if (_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_CheckHostedAssets && new string[5] { ".zip", ".rar", ".jar", ".disabled", ".old" }.Contains(item2.Extension.Lower()) && new string[4] { "mods", "packs", "openloader", "resource" }.Any(obj._Lambda_0024__3))
						{
							LocalResourceFile localResourceFile = new LocalResourceFile(text);
							_ = localResourceFile.ModrinthHash;
							Conversions.ToString(localResourceFile.CurseForgeHash);
							_0024VB_0024Local_Loader.Output.Add(localResourceFile);
						}
						_0024VB_0024Local_Progress++;
						if (_0024VB_0024Local_Progress == 25)
						{
							_0024VB_0024Local_Loader.Progress += (0.84 - _0024VB_0024Local_Loader.Progress) * 0.012;
							_0024VB_0024Local_Progress = 0;
						}
					}
				}
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__25_002D2
	{
		public string _0024VB_0024Local_RelativePath;

		public _Closure_0024__25_002D2(_Closure_0024__25_002D2 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_RelativePath = arg0._0024VB_0024Local_RelativePath;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__3(string s)
		{
			return _0024VB_0024Local_RelativePath.Contains(s);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__25_002D3
	{
		public ModLoader.LoaderTask<List<LocalResourceFile>, Dictionary<LocalResourceFile, List<string>>> _0024VB_0024Local_Loader;

		public List<Exception> _0024VB_0024Local_FailedExceptions;

		public int _0024VB_0024Local_EndedThreadCount;

		public _Closure_0024__25_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_3;

		public _Closure_0024__25_002D3(_Closure_0024__25_002D3 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Loader = arg0._0024VB_0024Local_Loader;
				_0024VB_0024Local_FailedExceptions = arg0._0024VB_0024Local_FailedExceptions;
				_0024VB_0024Local_EndedThreadCount = arg0._0024VB_0024Local_EndedThreadCount;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__5()
		{
			checked
			{
				try
				{
					IEnumerable<string> list = _0024VB_0024Local_Loader.Input.Select([SpecialName] (LocalResourceFile m) => m.ModrinthHash);
					JObject jObject = (JObject)ModDownload.DlModRequest("https://api.modrinth.com/v2/version_files", HttpMethod.Post, string.Format("{{\"hashes\": [\"{0}\"], \"algorithm\": \"sha1\"}}", list.Join("\",\"")), "application/json");
					foreach (LocalResourceFile item in _0024VB_0024Local_Loader.Input)
					{
						if (jObject.ContainsKey(item.ModrinthHash) && !((string?)jObject[item.ModrinthHash]?["files"]?[0]["hashes"]?["sha1"] != item.ModrinthHash))
						{
							_0024VB_0024Local_Loader.Output.AddIntoValueCollection(item, (string?)jObject[item.ModrinthHash]["files"][0]["url"]);
						}
					}
					Logger.Info($"从 Modrinth 获取到 {jObject.Count} 个本地资源项的对应信息", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Logger.Warn(ex2, "从 Modrinth 获取本地 Mod 信息失败", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
					_0024VB_0024Local_FailedExceptions.Add(ex2);
					ProjectData.ClearProjectError();
				}
				finally
				{
					_0024VB_0024Local_EndedThreadCount++;
					_0024VB_0024Local_Loader.Progress += 0.45;
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__7()
		{
			checked
			{
				try
				{
					if (_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_ModrinthUploadMode)
					{
						return;
					}
					IEnumerable<uint> list = _0024VB_0024Local_Loader.Input.Select([SpecialName] (LocalResourceFile m) => m.CurseForgeHash);
					JContainer jContainer = (JContainer)ModDownload.DlModRequest("https://api.curseforge.com/v1/fingerprints/432", HttpMethod.Post, string.Format("{{\"fingerprints\": [{0}]}}", list.Join(",")), "application/json")["data"]["exactMatches"];
					_Closure_0024__25_002D4 obj = default;
					foreach (JObject item in (IEnumerable<JToken>)jContainer)
					{
						obj = new _Closure_0024__25_002D4(obj);
						if (!item.ContainsKey("file"))
						{
							continue;
						}
						obj._0024VB_0024Local_File = (JObject)item["file"];
						if (string.IsNullOrEmpty((string?)obj._0024VB_0024Local_File["downloadUrl"]))
						{
							continue;
						}
						LocalResourceFile localResourceFile = _0024VB_0024Local_Loader.Input.FirstOrDefault(obj._Lambda_0024__9);
						if (localResourceFile == null)
						{
							continue;
						}
						foreach (string item2 in ResourceVersion.ParseCurseForgeDownloadUrls(obj._0024VB_0024Local_File["downloadUrl"].ToString()))
						{
							_0024VB_0024Local_Loader.Output.AddIntoValueCollection(localResourceFile, item2);
						}
					}
					Logger.Info($"从 CurseForge 获取到 {jContainer.Count} 个本地资源项的对应信息", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Logger.Warn(ex2, "从 CurseForge 获取本地 Mod 信息失败", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
					_0024VB_0024Local_FailedExceptions.Add(ex2);
					ProjectData.ClearProjectError();
				}
				finally
				{
					_0024VB_0024Local_EndedThreadCount++;
					_0024VB_0024Local_Loader.Progress += 0.45;
				}
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__25_002D4
	{
		public JObject _0024VB_0024Local_File;

		public _Closure_0024__25_002D4(_Closure_0024__25_002D4 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_File = arg0._0024VB_0024Local_File;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__9(LocalResourceFile m)
		{
			return m.CurseForgeHash == _0024VB_0024Local_File["fileFingerprint"].ToObject<uint>();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__7_002D0
	{
		public FileInfo _0024VB_0024Local_File;

		public _Closure_0024__7_002D0(_Closure_0024__7_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_File = arg0._0024VB_0024Local_File;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(string b)
		{
			return _0024VB_0024Local_File.Name.Contains(b);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__7_002D1
	{
		public DirectoryInfo _0024VB_0024Local_SubFolder;

		public _Closure_0024__7_002D1(_Closure_0024__7_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_SubFolder = arg0._0024VB_0024Local_SubFolder;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__2(string b)
		{
			return _0024VB_0024Local_SubFolder.Name.Contains(b);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__8_002D0
	{
		public FileSystemInfo _0024VB_0024Local_i;

		public _Closure_0024__8_002D0(_Closure_0024__8_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_i = arg0._0024VB_0024Local_i;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__2(string b)
		{
			return _0024VB_0024Local_i.Name.Contains(b);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__8_002D1
	{
		public DirectoryInfo _0024VB_0024Local_SubFolder;

		public _Closure_0024__8_002D1(_Closure_0024__8_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_SubFolder = arg0._0024VB_0024Local_SubFolder;
			}
		}

		[SpecialName]
		internal string _Lambda_0024__4(FileInfo f)
		{
			return $"{_0024VB_0024Local_SubFolder.Name}\\{f.Name}";
		}

		[SpecialName]
		internal string _Lambda_0024__5(DirectoryInfo d)
		{
			return $"{_0024VB_0024Local_SubFolder.Name}\\{d.Name}\\";
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__8_002D2
	{
		public List<string> _0024VB_0024Local_AllEntries;

		public VB_0024AnonymousDelegate_14<DirectoryInfo, bool> _0024VB_0024Local_IsValidDirectory;

		public PageInstanceExport _0024VB_0024Me;

		public Func<string, bool> _0024I7;

		public _Closure_0024__8_002D2(_Closure_0024__8_002D2 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_AllEntries = arg0._0024VB_0024Local_AllEntries;
				_0024VB_0024Local_IsValidDirectory = arg0._0024VB_0024Local_IsValidDirectory;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__6(ExportOption TargetOption)
		{
			if (TargetOption.RequireOptiFine && !PageInstanceLeft.Instance.Version.HasOptiFine)
			{
				return false;
			}
			if (TargetOption.RequireModLoader && !PageInstanceLeft.Instance.Modable)
			{
				return false;
			}
			if (TargetOption.RequireModLoaderOrOptiFine && !PageInstanceLeft.Instance.Version.HasOptiFine && !PageInstanceLeft.Instance.Modable)
			{
				return false;
			}
			return _0024VB_0024Me.StandardizeLines((TargetOption.Rules ?? TargetOption.ShowRules).Split('|'), AddSuffixStarToFolderPath: true).Any([SpecialName] (string Rule) =>
			{
				_Closure_0024__8_002D3 arg = default;
				_Closure_0024__8_002D3 CS_0024_003C_003E8__locals10 = new _Closure_0024__8_002D3(arg);
				CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule = Rule;
				bool result;
				if (CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule.StartsWithF("!"))
				{
					result = false;
				}
				else
				{
					try
					{
						if (_0024VB_0024Local_AllEntries.Any([SpecialName] (string Entry) => LikeOperator.LikeString(Entry.Lower(), CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule.Lower(), CompareMethod.Binary)))
						{
							result = true;
							goto IL_0105;
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						Logger.Error(ex2, $"错误的规则：{CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule}", LogBehavior.Toast, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
						result = false;
						ProjectData.ClearProjectError();
						goto IL_0105;
					}
					CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule = CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule.Trim("*?".ToCharArray());
					result = CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule.Split('\\', removeEmptyEntries: true).Count() >= 3 && ((!CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule.EndsWithF("\\")) ? FileUtils.Exists(PageInstanceLeft.Instance.PathIndie + CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule) : _0024VB_0024Local_IsValidDirectory(DirectoryUtils.GetInfo(PageInstanceLeft.Instance.PathIndie + CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule)));
				}
				goto IL_0105;
				IL_0105:
				return result;
			});
		}

		[SpecialName]
		internal bool _Lambda_0024__7(string Rule)
		{
			_Closure_0024__8_002D3 arg = default;
			_Closure_0024__8_002D3 CS_0024_003C_003E8__locals10 = new _Closure_0024__8_002D3(arg);
			CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule = Rule;
			bool result;
			if (CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule.StartsWithF("!"))
			{
				result = false;
			}
			else
			{
				try
				{
					if (_0024VB_0024Local_AllEntries.Any([SpecialName] (string Entry) => LikeOperator.LikeString(Entry.Lower(), CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule.Lower(), CompareMethod.Binary)))
					{
						result = true;
						goto IL_0105;
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Logger.Error(ex2, $"错误的规则：{CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule}", LogBehavior.Toast, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
					result = false;
					ProjectData.ClearProjectError();
					goto IL_0105;
				}
				CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule = CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule.Trim("*?".ToCharArray());
				result = CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule.Split('\\', removeEmptyEntries: true).Count() >= 3 && ((!CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule.EndsWithF("\\")) ? FileUtils.Exists(PageInstanceLeft.Instance.PathIndie + CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule) : _0024VB_0024Local_IsValidDirectory(DirectoryUtils.GetInfo(PageInstanceLeft.Instance.PathIndie + CS_0024_003C_003E8__locals10._0024VB_0024Local_Rule)));
			}
			goto IL_0105;
			IL_0105:
			return result;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__8_002D3
	{
		public string _0024VB_0024Local_Rule;

		public _Closure_0024__8_002D3(_Closure_0024__8_002D3 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Rule = arg0._0024VB_0024Local_Rule;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__8(string Entry)
		{
			return LikeOperator.LikeString(Entry.Lower(), _0024VB_0024Local_Rule.Lower(), CompareMethod.Binary);
		}
	}

	private string CurrentInstance;

	private string[] SubOptionBlackList;

	private const string Sperator = "==============================================================";

	private List<string> _RulesOverrides;

	private List<string> ExtraFiles;

	private string ConfigPackPath;

	private List<string> RulesOverrides
	{
		get
		{
			return _RulesOverrides;
		}
		set
		{
			_RulesOverrides = value;
			if (value == null)
			{
				BtnOverrideCancel.Visibility = Visibility.Collapsed;
				PanOptions.Visibility = Visibility.Visible;
				CardOptions.Inlines.Clear();
				CardOptions.Inlines.Add(new Run("导出内容列表")
				{
					FontWeight = FontWeights.Bold
				});
			}
			else
			{
				BtnOverrideCancel.Visibility = Visibility.Visible;
				PanOptions.Visibility = Visibility.Collapsed;
				CardOptions.Inlines.Clear();
				CardOptions.Inlines.Add(new Run("导出内容列表:\u200a\u200a\u200a\u200a")
				{
					FontWeight = FontWeights.Bold
				});
				CardOptions.Inlines.Add(new Run("从配置文件中读取")
				{
					FontWeight = FontWeights.Normal
				});
			}
		}
	}

	[field: AccessedThroughProperty("PanAllBack")]
	internal virtual Grid PanAllBack
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanBack")]
	internal virtual MyScrollViewer PanBack
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("HintOptiFine")]
	internal virtual MyHint HintOptiFine
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("HintJava")]
	internal virtual MyHint HintJava
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextExportName")]
	internal virtual MyTextBox TextExportName
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RoutedEventHandler value2 = [SpecialName] (object a0, RoutedEventArgs a1) =>
			{
				TextExportName_GotFocus();
			};
			MyTextBox myTextBox = field;
			if (myTextBox != null)
			{
				myTextBox.GotFocus -= value2;
			}
			field = value;
			myTextBox = field;
			if (myTextBox != null)
			{
				myTextBox.GotFocus += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TextExportVersion")]
	internal virtual MyTextBox TextExportVersion
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CardOptions")]
	internal virtual MyCard CardOptions
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseButtonEventHandler value2 = [SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				CardOptions_MouseLeftButtonDown();
			};
			MyCard myCard = field;
			if (myCard != null)
			{
				myCard.MouseLeftButtonDown -= value2;
			}
			field = value;
			myCard = field;
			if (myCard != null)
			{
				myCard.MouseLeftButtonDown += value2;
			}
		}
	}

	[field: AccessedThroughProperty("BtnOverrideCancel")]
	internal virtual MyIconTextButton BtnOverrideCancel
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanOptions")]
	internal virtual StackPanel PanOptions
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckOptionsBasic")]
	internal virtual MyCheckBox CheckOptionsBasic
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckOptionsOptions")]
	internal virtual MyCheckBox CheckOptionsOptions
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckOptionsMod")]
	internal virtual MyCheckBox CheckOptionsMod
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckOptionsResourcePacks")]
	internal virtual MyCheckBox CheckOptionsResourcePacks
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanOptionsResourcePacks")]
	internal virtual StackPanel PanOptionsResourcePacks
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckOptionsShaderPacks")]
	internal virtual MyCheckBox CheckOptionsShaderPacks
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckOptionsShaderPackSettings")]
	internal virtual MyCheckBox CheckOptionsShaderPackSettings
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanOptionsShaderPacks")]
	internal virtual StackPanel PanOptionsShaderPacks
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckOptionsSaves")]
	internal virtual MyCheckBox CheckOptionsSaves
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanOptionsSaves")]
	internal virtual StackPanel PanOptionsSaves
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckOptionsJava")]
	internal virtual MyCheckBox CheckOptionsJava
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckOptionsPcl")]
	internal virtual MyCheckBox CheckOptionsPcl
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = CheckAdvancedModrinth_Change;
			MyCheckBox myCheckBox = field;
			if (myCheckBox != null)
			{
				myCheckBox.Change -= obj;
			}
			field = value;
			myCheckBox = field;
			if (myCheckBox != null)
			{
				myCheckBox.Change += obj;
			}
		}
	}

	[field: AccessedThroughProperty("CheckOptionsPclCustom")]
	internal virtual MyCheckBox CheckOptionsPclCustom
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckAdvancedInclude")]
	internal virtual MyCheckBox CheckAdvancedInclude
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = CheckAdvancedInclude_Change;
			MyCheckBox myCheckBox = field;
			if (myCheckBox != null)
			{
				myCheckBox.Change -= obj;
			}
			field = value;
			myCheckBox = field;
			if (myCheckBox != null)
			{
				myCheckBox.Change += obj;
			}
		}
	}

	[field: AccessedThroughProperty("CheckAdvancedModrinth")]
	internal virtual MyCheckBox CheckAdvancedModrinth
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = CheckAdvancedModrinth_Change;
			MyCheckBox myCheckBox = field;
			if (myCheckBox != null)
			{
				myCheckBox.Change -= obj;
			}
			field = value;
			myCheckBox = field;
			if (myCheckBox != null)
			{
				myCheckBox.Change += obj;
			}
		}
	}

	[field: AccessedThroughProperty("HintModrinthFormat")]
	internal virtual MyHint HintModrinthFormat
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnAdvancedImport")]
	internal virtual MyButton BtnAdvancedImport
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				ImportConfig();
			};
			MyButton myButton = field;
			if (myButton != null)
			{
				myButton.Click -= obj;
			}
			field = value;
			myButton = field;
			if (myButton != null)
			{
				myButton.Click += obj;
			}
		}
	}

	[field: AccessedThroughProperty("BtnAdvancedExport")]
	internal virtual MyButton BtnAdvancedExport
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				ExportConfig();
			};
			MyButton myButton = field;
			if (myButton != null)
			{
				myButton.Click -= obj;
			}
			field = value;
			myButton = field;
			if (myButton != null)
			{
				myButton.Click += obj;
			}
		}
	}

	[field: AccessedThroughProperty("BtnAdvancedHelp")]
	internal virtual MyButton BtnAdvancedHelp
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnExport")]
	internal virtual MyExtraTextButton BtnExport
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyExtraTextButton.ClickEventHandler obj = [SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				StartExport();
			};
			MyExtraTextButton myExtraTextButton = field;
			if (myExtraTextButton != null)
			{
				myExtraTextButton.Click -= obj;
			}
			field = value;
			myExtraTextButton = field;
			if (myExtraTextButton != null)
			{
				myExtraTextButton.Click += obj;
			}
		}
	}

	public PageInstanceExport()
	{
		Initialized += PageInstanceExport_Initialized;
		Loaded += [SpecialName] (object a0, RoutedEventArgs a1) =>
		{
			PageInstanceExport_Loaded();
		};
		Loaded += [SpecialName] (object a0, RoutedEventArgs a1) =>
		{
			RefreshJavaInfo();
		};
		CurrentInstance = "";
		SubOptionBlackList = new string[3] { "Quark Programmer Art.zip", "+ EuphoriaPatches_", "PCL2 Skin.zip" };
		_RulesOverrides = null;
		ExtraFiles = null;
		ConfigPackPath = null;
		InitializeComponent();
	}

	private void PageInstanceExport_Initialized(object sender, EventArgs e)
	{
		PageInstanceLeft.CurrentJavaWorker.Stopped += [SpecialName] () =>
		{
			ModBase.RunInUi(RefreshJavaInfo);
		};
	}

	private void PageInstanceExport_Loaded()
	{
		checked
		{
			ModAnimation.AniControlEnabled++;
			if (!PathUtils.IsSame(CurrentInstance, PageInstanceLeft.Instance.PathVersion))
			{
				RefreshAll();
			}
			CustomEventService.SetEventData(BtnAdvancedHelp, "指南/整合包制作 - Snapshot.json");
			ModAnimation.AniControlEnabled--;
		}
	}

	public void RefreshAll()
	{
		Logger.Info("刷新导出页面", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
		HintOptiFine.Visibility = ((!PageInstanceLeft.Instance.Version.HasOptiFine || PageInstanceLeft.Instance.Version.OptiFineAsMod) ? Visibility.Collapsed : Visibility.Visible);
		CurrentInstance = PageInstanceLeft.Instance.PathVersion;
		TextExportName.Text = "";
		TextExportName.HintText = PageInstanceLeft.Instance.Name;
		TextExportVersion.Text = "";
		TextExportVersion.HintText = "1.0.0";
		CheckAdvancedInclude.Checked = false;
		CheckAdvancedModrinth.Checked = false;
		GetExportOption(CheckOptionsBasic).Description = PageInstanceLeft.Instance.VersionDisplayName();
		ResetConfigOverrides();
		ReloadAllSubOptions();
		RefreshAllOptionsUI();
		RefreshJavaInfo();
		PanBack.ScrollToHome();
	}

	void IRefreshable.Refresh()
	{
		//ILSpy generated this explicit interface implementation from .override directive in RefreshAll
		this.RefreshAll();
	}

	private void ReloadAllSubOptions()
	{
		ReloadSubOptions(PanOptionsResourcePacks, true, true, "resourcepacks", "texturepacks");
		ReloadSubOptions(PanOptionsSaves, false, true, "saves");
		ReloadSubOptions(PanOptionsShaderPacks, true, true, "shaderpacks");
	}

	private void ReloadSubOptions(StackPanel Panel, bool AcceptCompressedFile, bool AcceptFolder, params string[] Folders)
	{
		Panel.Children.Clear();
		_Closure_0024__7_002D0 obj = default;
		_Closure_0024__7_002D1 obj2 = default;
		foreach (string text in Folders)
		{
			DirectoryInfo info = DirectoryUtils.GetInfo(PageInstanceLeft.Instance.PathIndie + text);
			if (!info.Exists)
			{
				continue;
			}
			if (AcceptCompressedFile)
			{
				using IEnumerator<FileInfo> enumerator = info.EnumerateFiles("*.zip").Concat(info.EnumerateFiles("*.rar")).GetEnumerator();
				while (enumerator.MoveNext())
				{
					obj = new _Closure_0024__7_002D0(obj);
					obj._0024VB_0024Local_File = enumerator.Current;
					if (!SubOptionBlackList.Any(obj._Lambda_0024__0))
					{
						Panel.Children.Add(new MyCheckBox
						{
							Tag = new ExportOption
							{
								Title = obj._0024VB_0024Local_File.Name,
								DefaultChecked = true,
								Rules = StringUtils.LikePatternEscape($"{text}/{obj._0024VB_0024Local_File.Name}")
							}
						});
					}
				}
			}
			if (!AcceptFolder)
			{
				continue;
			}
			using IEnumerator<DirectoryInfo> enumerator2 = (from f in info.EnumerateDirectories()
				orderby f.LastWriteTime descending
				select f).GetEnumerator();
			while (enumerator2.MoveNext())
			{
				obj2 = new _Closure_0024__7_002D1(obj2);
				obj2._0024VB_0024Local_SubFolder = enumerator2.Current;
				if (!SubOptionBlackList.Any(obj2._Lambda_0024__2) && obj2._0024VB_0024Local_SubFolder.EnumerateFileSystemInfos().Any())
				{
					MyCheckBox myCheckBox = new MyCheckBox
					{
						Tag = new ExportOption
						{
							Title = obj2._0024VB_0024Local_SubFolder.Name,
							DefaultChecked = true,
							Rules = StringUtils.LikePatternEscape($"{text}/{obj2._0024VB_0024Local_SubFolder.Name}/")
						}
					};
					if (AcceptCompressedFile)
					{
						GetExportOption(myCheckBox).Description = "文件夹";
					}
					if (Panel == PanOptionsSaves)
					{
						GetExportOption(myCheckBox).Description = obj2._0024VB_0024Local_SubFolder.LastWriteTime.ToString("yyyy'/'MM'/'dd HH':'mm");
					}
					Panel.Children.Add(myCheckBox);
				}
			}
		}
	}

	private void RefreshAllOptionsUI()
	{
		_Closure_0024__8_002D2 arg = default;
		_Closure_0024__8_002D2 CS_0024_003C_003E8__locals24 = new _Closure_0024__8_002D2(arg);
		CS_0024_003C_003E8__locals24._0024VB_0024Me = this;
		CS_0024_003C_003E8__locals24._0024VB_0024Local_AllEntries = new List<string>();
		CS_0024_003C_003E8__locals24._0024VB_0024Local_IsValidDirectory = [SpecialName] (DirectoryInfo Folder) =>
		{
			bool result;
			try
			{
				result = Folder.Exists && Folder.EnumerateFileSystemInfos().Any([SpecialName] (FileSystemInfo i) =>
				{
					_Closure_0024__8_002D0 arg2 = default;
					_Closure_0024__8_002D0 CS_0024_003C_003E8__locals26 = new _Closure_0024__8_002D0(arg2);
					CS_0024_003C_003E8__locals26._0024VB_0024Local_i = i;
					return !SubOptionBlackList.Any([SpecialName] (string b) => CS_0024_003C_003E8__locals26._0024VB_0024Local_i.Name.Contains(b));
				});
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		};
		DirectoryInfo info = DirectoryUtils.GetInfo(PageInstanceLeft.Instance.PathIndie);
		CS_0024_003C_003E8__locals24._0024VB_0024Local_AllEntries.AddRange(from f in info.EnumerateFiles()
			select f.Name);
		IEnumerator<DirectoryInfo> enumerator = default;
		try
		{
			IEnumerable<DirectoryInfo> source = info.EnumerateDirectories();
			VB_0024AnonymousDelegate_14<DirectoryInfo, bool> obj = CS_0024_003C_003E8__locals24._0024VB_0024Local_IsValidDirectory;
			enumerator = source.Where((obj == null) ? null : new Func<DirectoryInfo, bool>(obj.Invoke)).GetEnumerator();
			_Closure_0024__8_002D1 obj2 = default;
			while (enumerator.MoveNext())
			{
				obj2 = new _Closure_0024__8_002D1(obj2);
				obj2._0024VB_0024Local_SubFolder = enumerator.Current;
				CS_0024_003C_003E8__locals24._0024VB_0024Local_AllEntries.Add($"{obj2._0024VB_0024Local_SubFolder.Name}\\");
				CS_0024_003C_003E8__locals24._0024VB_0024Local_AllEntries.AddRange(obj2._0024VB_0024Local_SubFolder.EnumerateFiles().Select(obj2._Lambda_0024__4));
				List<string> list = CS_0024_003C_003E8__locals24._0024VB_0024Local_AllEntries;
				IEnumerable<DirectoryInfo> source2 = obj2._0024VB_0024Local_SubFolder.EnumerateDirectories();
				obj = CS_0024_003C_003E8__locals24._0024VB_0024Local_IsValidDirectory;
				list.AddRange(source2.Where((obj == null) ? null : new Func<DirectoryInfo, bool>(obj.Invoke)).Select(obj2._Lambda_0024__5));
			}
		}
		finally
		{
			enumerator?.Dispose();
		}
		Logger.Info($"共发现 {CS_0024_003C_003E8__locals24._0024VB_0024Local_AllEntries.Count} 个可行的二级文件/文件夹", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
		VB_0024AnonymousDelegate_15<ExportOption, bool> obj3 = [SpecialName] (ExportOption TargetOption) =>
		{
			if (TargetOption.RequireOptiFine && !PageInstanceLeft.Instance.Version.HasOptiFine)
			{
				return false;
			}
			if (TargetOption.RequireModLoader && !PageInstanceLeft.Instance.Modable)
			{
				return false;
			}
			return (!TargetOption.RequireModLoaderOrOptiFine || PageInstanceLeft.Instance.Version.HasOptiFine || PageInstanceLeft.Instance.Modable) && CS_0024_003C_003E8__locals24._0024VB_0024Me.StandardizeLines((TargetOption.Rules ?? TargetOption.ShowRules).Split('|'), AddSuffixStarToFolderPath: true).Any([SpecialName] (string Rule) =>
			{
				_Closure_0024__8_002D3 arg2 = default;
				_Closure_0024__8_002D3 CS_0024_003C_003E8__locals27 = new _Closure_0024__8_002D3(arg2);
				CS_0024_003C_003E8__locals27._0024VB_0024Local_Rule = Rule;
				bool result;
				if (CS_0024_003C_003E8__locals27._0024VB_0024Local_Rule.StartsWithF("!"))
				{
					result = false;
				}
				else
				{
					try
					{
						if (CS_0024_003C_003E8__locals24._0024VB_0024Local_AllEntries.Any([SpecialName] (string Entry) => LikeOperator.LikeString(Entry.Lower(), CS_0024_003C_003E8__locals27._0024VB_0024Local_Rule.Lower(), CompareMethod.Binary)))
						{
							result = true;
							goto IL_0105;
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						Logger.Error(ex2, $"错误的规则：{CS_0024_003C_003E8__locals27._0024VB_0024Local_Rule}", LogBehavior.Toast, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
						result = false;
						ProjectData.ClearProjectError();
						goto IL_0105;
					}
					CS_0024_003C_003E8__locals27._0024VB_0024Local_Rule = CS_0024_003C_003E8__locals27._0024VB_0024Local_Rule.Trim("*?".ToCharArray());
					result = CS_0024_003C_003E8__locals27._0024VB_0024Local_Rule.Split('\\', removeEmptyEntries: true).Count() >= 3 && ((!CS_0024_003C_003E8__locals27._0024VB_0024Local_Rule.EndsWithF("\\")) ? FileUtils.Exists(PageInstanceLeft.Instance.PathIndie + CS_0024_003C_003E8__locals27._0024VB_0024Local_Rule) : CS_0024_003C_003E8__locals24._0024VB_0024Local_IsValidDirectory(DirectoryUtils.GetInfo(PageInstanceLeft.Instance.PathIndie + CS_0024_003C_003E8__locals27._0024VB_0024Local_Rule)));
				}
				goto IL_0105;
				IL_0105:
				return result;
			});
		};
		foreach (MyCheckBox allOption in GetAllOptions(IncludeHidden: true))
		{
			ExportOption exportOption = GetExportOption(allOption);
			if (string.IsNullOrEmpty(exportOption.Rules) && string.IsNullOrEmpty(exportOption.ShowRules))
			{
				allOption.Visibility = Visibility.Visible;
				allOption.Checked = exportOption.DefaultChecked;
			}
			else
			{
				bool flag = obj3(exportOption);
				allOption.Visibility = ((!flag) ? Visibility.Collapsed : Visibility.Visible);
				allOption.Checked = exportOption.DefaultChecked && flag;
			}
			allOption.Inlines.Clear();
			if (allOption.Visibility == Visibility.Visible)
			{
				allOption.Inlines.Add(new Run(exportOption.Title));
				if (!string.IsNullOrEmpty(exportOption.Description))
				{
					allOption.Inlines.Add(new Run("   " + exportOption.Description)
					{
						Foreground = ModSecret.ColorGray5
					});
				}
			}
		}
	}

	private IEnumerable<string> StandardizeLines(IEnumerable<string> Raw, bool AddSuffixStarToFolderPath)
	{
		foreach (string item in Raw)
		{
			string current = item.Trim();
			if (Operators.CompareString(current, "", TextCompare: false) != 0 && !current.StartsWithF("#") && !current.StartsWithF("="))
			{
				current = current.Replace("/", "\\");
				yield return current + ((current.EndsWithF("\\") && AddSuffixStarToFolderPath) ? "*" : "");
			}
		}
	}

	private IEnumerable<MyCheckBox> GetAllOptions(bool IncludeHidden)
	{
		foreach (object child in PanOptions.Children)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(child);
			if (!IncludeHidden && Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue, null, "Visibility", new object[0], null, null, null), Visibility.Visible, TextCompare: false))
			{
				continue;
			}
			if (objectValue is MyCheckBox)
			{
				yield return (MyCheckBox)objectValue;
			}
			else
			{
				if (!(objectValue is StackPanel))
				{
					continue;
				}
				foreach (object child2 in ((StackPanel)objectValue).Children)
				{
					object objectValue2 = RuntimeHelpers.GetObjectValue(child2);
					if ((IncludeHidden || !Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue2, null, "Visibility", new object[0], null, null, null), Visibility.Visible, TextCompare: false)) && objectValue2 is MyCheckBox)
					{
						yield return (MyCheckBox)objectValue2;
					}
				}
			}
		}
	}

	private ExportOption GetExportOption(MyCheckBox CheckBox)
	{
		return (ExportOption)CheckBox.Tag;
	}

	private IEnumerable<string> GetAllRules()
	{
		if (RulesOverrides != null)
		{
			foreach (string rulesOverride in RulesOverrides)
			{
				yield return rulesOverride;
			}
			yield break;
		}
		yield return "";
		yield return "# 修改下方的规则以控制需要导出的内容。";
		yield return "# 以 ! 开头以反选。可以使用 *、?、[] 通配符。靠后的行覆盖靠前的。";
		yield return "";
		foreach (MyCheckBox allOption in GetAllOptions(IncludeHidden: false))
		{
			if (!allOption.Checked)
			{
				continue;
			}
			ExportOption exportOption = GetExportOption(allOption);
			List<string> list = exportOption.Rules?.Split('|').ToList() ?? new List<string>();
			if (allOption == CheckOptionsShaderPackSettings)
			{
				foreach (MyCheckBox item in PanOptionsShaderPacks.Children.OfType<MyCheckBox>())
				{
					if (item.Checked)
					{
						ExportOption exportOption2 = GetExportOption(item);
						string text = $"shaderpacks/{exportOption2.Title}.txt";
						if (FileUtils.Exists(Path.Combine(PageInstanceLeft.Instance.PathIndie, text)))
						{
							list.Add(StringUtils.LikePatternEscape(text));
						}
					}
				}
			}
			if (!list.Any())
			{
				continue;
			}
			yield return $"# {exportOption.Title}";
			foreach (string item2 in list)
			{
				yield return item2;
			}
			yield return "";
		}
		yield return "# 排除的文件";
		yield return "!*.log";
		yield return "!*.dat_old";
		yield return "!*.BakaCoreInfo";
		yield return "!hmclversion.cfg";
		yield return "!log4j2.xml";
		yield return "";
	}

	private IEnumerable<string> GetExtraFileLines()
	{
		if (ExtraFiles != null)
		{
			foreach (string extraFile in ExtraFiles)
			{
				yield return extraFile;
			}
			yield break;
		}
		yield return "";
		yield return "# 如果想将额外的文件自动放到压缩包根目录中，可以将它们的路径写在下方。";
		yield return "# 必须是完整路径。每行中，若以 \\ 结尾则代表是文件夹，不以 \\ 结尾则代表是文件。";
		yield return "";
	}

	private void ResetConfigOverrides()
	{
		RulesOverrides = null;
		ConfigPackPath = null;
		ExtraFiles = null;
		PanBack.ScrollToHome();
	}

	private void CardOptions_MouseLeftButtonDown()
	{
		if (RulesOverrides != null)
		{
			ResetConfigOverrides();
		}
	}

	private void ExportConfig()
	{
		try
		{
			string text = Dialogs.SaveFile("选择文件位置", "export_config.txt", Settings.Get<string>("CacheExportConfig"), new (string, string)[1] { ("txt", "整合包导出配置") });
			if (text != null)
			{
				Settings.Set("CacheExportConfig", text);
				List<string> list = new List<string>();
				list.Add("Name:" + TextExportName.Text);
				list.Add("Version:" + TextExportVersion.Text);
				list.Add("");
				list.Add($"# 当版本设置中选择了 {ModBase.vbLQ}使用版本文件夹中的 Java{ModBase.vbRQ} 时，是否打包版本文件夹中的 Java。");
				list.Add("IncludeJava:" + Conversions.ToString(CheckOptionsJava.Checked));
				list.Add("");
				list.Add("# 是否打包正式版 PCL，以便没有启动器的玩家安装整合包。");
				list.Add("IncludeLauncher:" + Conversions.ToString(CheckOptionsPcl.Checked));
				list.Add("");
				list.Add("# 是否打包 PCL 个性化内容，例如功能隐藏设置、主页、背景音乐和图片等。");
				list.Add("IncludeLauncherCustom:" + Conversions.ToString(CheckOptionsPclCustom.Checked));
				list.Add("");
				list.Add("# 是否将 Mod、资源包、光影包的文件直接放入整合包中，这样在导入时就无需联网下载它们。");
				list.Add("# 建议仅在无法稳定连接 CurseForge 或 Modrinth 时才考虑启用。");
				list.Add("# 二次分发可能违反使用协议，请尽量不要公开发布包含资源文件的整合包！");
				list.Add("DontCheckHostedAssets:" + Conversions.ToString(CheckAdvancedInclude.Checked));
				list.Add("");
				list.Add("# 若资源未在 Modrinth 上托管，则将其原始文件直接放入整合包中。");
				list.Add("# 如果你想将整合包上传到 Modrinth，这能帮助你分辨哪些文件未在 Modrinth 上托管。");
				list.Add("# 此选项与 DontCheckHostedAssets 冲突。");
				list.Add("ModrinthUploadMode:" + Conversions.ToString(CheckAdvancedModrinth.Checked));
				list.Add("");
				list.Add("# 导出的文件的存放位置。");
				list.Add("# 若设置了此项，在导出时会直接将文件放到此路径，不会弹窗要求选择。");
				list.Add("# 若 IncludeLauncher 为 True，应以 .zip 结尾；若为 False，应以 .mrpack 结尾。");
				list.Add("PackPath:" + ConfigPackPath);
				list.Add("");
				list.Add("==============================================================");
				list.AddRange(GetAllRules());
				list.Add("==============================================================");
				list.AddRange(GetExtraFileLines());
				FileUtils.Write(text, list.Join("\r\n"));
				ModMain.Hint("已保存配置文件：" + text, ModMain.HintType.Green);
				ModBase.OpenExplorer(text);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "保存配置失败", LogBehavior.Alert, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
			ProjectData.ClearProjectError();
		}
	}

	private void ImportConfig()
	{
		checked
		{
			try
			{
				string text = Dialogs.SelectFile("选择配置文件", multiselect: false, Settings.Get<string>("CacheExportConfig"), new (string[], string)[1] { (new string[1] { "txt" }, "整合包导出配置") }).FirstOrDefault();
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				Settings.Set("CacheExportConfig", text);
				string[] array = FileUtils.ReadAsString(text).Split("==============================================================");
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				string[] array2 = array[0].SplitLines(skipEmptyLines: true);
				for (int i = 0; i < array2.Length; i++)
				{
					string text2 = array2[i];
					text2 = text2.Trim();
					if (Operators.CompareString(text2, "", TextCompare: false) != 0 && !text2.StartsWithF("#") && !text2.StartsWithF("="))
					{
						int num = text2.IndexOfF(":");
						if (num > 0)
						{
							dictionary[text2.Substring(0, num)] = text2.Substring(num + 1);
						}
					}
				}
				TextExportName.Text = dictionary.GetOrDefault("Name", "");
				TextExportVersion.Text = dictionary.GetOrDefault("Version", "");
				CheckOptionsJava.Checked = Conversions.ToBoolean(dictionary.GetOrDefault("IncludeJava", Conversions.ToString(Value: true)));
				CheckOptionsPcl.Checked = Conversions.ToBoolean(dictionary.GetOrDefault("IncludeLauncher", Conversions.ToString(Value: true)));
				CheckOptionsPclCustom.Checked = Conversions.ToBoolean(dictionary.GetOrDefault("IncludeLauncherCustom", Conversions.ToString(Value: true)));
				CheckAdvancedInclude.Checked = Conversions.ToBoolean(dictionary.GetOrDefault("DontCheckHostedAssets", Conversions.ToString(Value: false)));
				if (!CheckAdvancedInclude.Checked)
				{
					CheckAdvancedModrinth.Checked = Conversions.ToBoolean(dictionary.GetOrDefault("ModrinthUploadMode", Conversions.ToString(Value: false)));
				}
				ConfigPackPath = dictionary.GetOrDefault("PackPath");
				RulesOverrides = array[1].SplitLines(skipEmptyLines: true).ToList();
				if (array.Length > 2)
				{
					ExtraFiles = array[2].SplitLines(skipEmptyLines: true).ToList();
				}
				else
				{
					ExtraFiles = null;
				}
				ModMain.Hint("已读取配置文件：" + text, ModMain.HintType.Green);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Logger.Error(ex2, "读取配置失败", LogBehavior.Alert, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
				ProjectData.ClearProjectError();
			}
		}
	}

	private void StartExport()
	{
		_Closure_0024__25_002D0 arg = default;
		_Closure_0024__25_002D0 CS_0024_003C_003E8__locals107 = new _Closure_0024__25_002D0(arg);
		CS_0024_003C_003E8__locals107._0024VB_0024Local_PackName = (string.IsNullOrEmpty(TextExportName.Text) ? TextExportName.HintText : TextExportName.Text);
		CS_0024_003C_003E8__locals107._0024VB_0024Local_PackVersion = (string.IsNullOrEmpty(TextExportVersion.Text) ? "1.0.0" : TextExportVersion.Text);
		CS_0024_003C_003E8__locals107._0024VB_0024Local_LoaderName = "导出整合包：" + CS_0024_003C_003E8__locals107._0024VB_0024Local_PackName;
		foreach (ModLoader.LoaderBase item in ModLoader.LoaderTaskbar)
		{
			if (Operators.CompareString(item.Name, CS_0024_003C_003E8__locals107._0024VB_0024Local_LoaderName, TextCompare: false) == 0)
			{
				ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
				return;
			}
		}
		CS_0024_003C_003E8__locals107._0024VB_0024Local_PackPath = null;
		if (!string.IsNullOrWhiteSpace(ConfigPackPath) && !ConfigPackPath.EndsWithF("\\") && !ConfigPackPath.EndsWithF("/"))
		{
			try
			{
				DirectoryUtils.Create(PathUtils.RemoveLastPart(ConfigPackPath));
				CS_0024_003C_003E8__locals107._0024VB_0024Local_PackPath = ConfigPackPath;
				Logger.Info($"使用配置文件中指定的导出路径：{ConfigPackPath}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Logger.Warn(ex2, $"无法使用配置文件中指定的导出路径（{ConfigPackPath}）", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
				if (ModMain.MyMsgBox(string.Format("指定的路径：{0}{1}{2}{3}", ConfigPackPath, "\r\n", "\r\n", ex2.GetDisplay(multiline: true)), "无法使用配置文件中指定的导出路径", "确定", "取消") == 2)
				{
					ProjectData.ClearProjectError();
					return;
				}
				ProjectData.ClearProjectError();
			}
		}
		if (CS_0024_003C_003E8__locals107._0024VB_0024Local_PackPath == null)
		{
			List<(string, string)> list = new List<(string, string)>();
			if (!CheckOptionsPcl.Checked && CheckAdvancedModrinth.Checked)
			{
				list.Add(("mrpack", "Modrinth 整合包文件"));
			}
			list.Add(("zip", "压缩文件"));
			if (!CheckOptionsPcl.Checked && !CheckAdvancedModrinth.Checked)
			{
				list.Add(("mrpack", "Modrinth 整合包文件"));
			}
			CS_0024_003C_003E8__locals107._0024VB_0024Local_PackPath = Dialogs.SaveFile("选择导出位置", CS_0024_003C_003E8__locals107._0024VB_0024Local_PackName + (string.IsNullOrEmpty(TextExportVersion.Text) ? "" : (" " + TextExportVersion.Text)), null, list);
			Logger.Info($"手动指定的导出路径：{CS_0024_003C_003E8__locals107._0024VB_0024Local_PackPath}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
		}
		if (CS_0024_003C_003E8__locals107._0024VB_0024Local_PackPath == null)
		{
			return;
		}
		CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder = ModMain.RequestTaskTempFolder();
		CS_0024_003C_003E8__locals107._0024VB_0024Local_OverridesFolder = CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder + "modpack\\overrides\\";
		CS_0024_003C_003E8__locals107._0024VB_0024Local_TargetInstance = PageInstanceLeft.Instance;
		CS_0024_003C_003E8__locals107._0024VB_0024Local_IncludeJava = (RulesOverrides == null && CheckOptionsJava.Visibility == Visibility.Visible && CheckOptionsJava.Checked) || (RulesOverrides != null && CheckOptionsJava.Checked && Settings.Get<int>("VersionArgumentJavaV2", CS_0024_003C_003E8__locals107._0024VB_0024Local_TargetInstance) == 2);
		CS_0024_003C_003E8__locals107._0024VB_0024Local_PathIndie = CS_0024_003C_003E8__locals107._0024VB_0024Local_TargetInstance.PathIndie;
		CS_0024_003C_003E8__locals107._0024VB_0024Local_CheckHostedAssets = !CheckAdvancedInclude.Checked;
		CS_0024_003C_003E8__locals107._0024VB_0024Local_ModrinthUploadMode = CheckAdvancedModrinth.Checked;
		CS_0024_003C_003E8__locals107._0024VB_0024Local_IncludePCL = CheckOptionsPcl.Checked;
		CS_0024_003C_003E8__locals107._0024VB_0024Local_IncludePCLCustom = CS_0024_003C_003E8__locals107._0024VB_0024Local_IncludePCL && CheckOptionsPclCustom.Checked;
		CS_0024_003C_003E8__locals107._0024VB_0024Local_AllRules = StandardizeLines(GetAllRules(), AddSuffixStarToFolderPath: true).ToList();
		CS_0024_003C_003E8__locals107._0024VB_0024Local_AllExtraFiles = StandardizeLines(GetExtraFileLines(), AddSuffixStarToFolderPath: false).ToList();
		Logger.Info($"准备导出整合包，共有 {CS_0024_003C_003E8__locals107._0024VB_0024Local_AllRules.Count} 条规则，{CS_0024_003C_003E8__locals107._0024VB_0024Local_AllExtraFiles.Count} 条追加内容行", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
		List<ModLoader.LoaderBase> list2 = new List<ModLoader.LoaderBase>();
		if (CS_0024_003C_003E8__locals107._0024VB_0024Local_IncludePCL)
		{
			list2.Add(new ModLoader.LoaderTask<int, int>("下载 PCL 正式版", [SpecialName] (ModLoader.LoaderTask<int, int> Loader) =>
			{
				ModSecret.DownloadLatestPCL(Loader);
				FileUtils.Copy(ModBase.PathTemp + "Latest.exe", CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder + "Plain Craft Launcher.exe");
			})
			{
				ProgressWeight = 0.5,
				Block = false
			});
		}
		checked
		{
			list2.Add(new ModLoader.LoaderTask<int, List<LocalResourceFile>>("复制导出内容", [SpecialName] (ModLoader.LoaderTask<int, List<LocalResourceFile>> Loader) =>
			{
				_Closure_0024__25_002D1 arg2 = default;
				_Closure_0024__25_002D1 CS_0024_003C_003E8__locals119 = new _Closure_0024__25_002D1(arg2);
				CS_0024_003C_003E8__locals119._0024VB_0024NonLocal__0024VB_0024Closure_2 = CS_0024_003C_003E8__locals107;
				CS_0024_003C_003E8__locals119._0024VB_0024Local_Loader = Loader;
				CS_0024_003C_003E8__locals119._0024VB_0024Local_Loader.Output = new List<LocalResourceFile>();
				CS_0024_003C_003E8__locals119._0024VB_0024Local_Progress = 0;
				CS_0024_003C_003E8__locals119._0024VB_0024Local_SearchFolder = [SpecialName] (DirectoryInfo Folder) =>
				{
					foreach (DirectoryInfo item2 in Folder.EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
					{
						if ((!new string[3] { "assets", "versions", "libraries" }.Contains(item2.Name) || !PathUtils.IsSame(CS_0024_003C_003E8__locals119._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_PathIndie, Folder.FullName)) && !new string[5] { "structureCacheV1", ".fabric", ".git", "avatar-cache", "cosmetic-cache" }.Contains(item2.Name))
						{
							CS_0024_003C_003E8__locals119._0024VB_0024Local_SearchFolder(item2);
						}
					}
					_Closure_0024__25_002D2 obj = default;
					foreach (FileInfo item3 in Folder.EnumerateFiles("*", SearchOption.TopDirectoryOnly))
					{
						obj = new _Closure_0024__25_002D2(obj);
						obj._0024VB_0024Local_RelativePath = item3.FullName.AfterFirst(CS_0024_003C_003E8__locals119._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_PathIndie);
						bool flag = false;
						foreach (string item4 in CS_0024_003C_003E8__locals119._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_AllRules)
						{
							bool flag2 = item4.StartsWithF("!");
							if (LikeOperator.LikeString(obj._0024VB_0024Local_RelativePath.Lower(), item4.TrimStart('!').Lower(), CompareMethod.Binary))
							{
								flag = !flag2;
							}
						}
						if (flag)
						{
							string text4 = CS_0024_003C_003E8__locals119._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_OverridesFolder + obj._0024VB_0024Local_RelativePath;
							FileUtils.Copy(item3.FullName, text4);
							if (CS_0024_003C_003E8__locals119._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_CheckHostedAssets && new string[5] { ".zip", ".rar", ".jar", ".disabled", ".old" }.Contains(item3.Extension.Lower()) && new string[4] { "mods", "packs", "openloader", "resource" }.Any(obj._Lambda_0024__3))
							{
								LocalResourceFile localResourceFile = new LocalResourceFile(text4);
								_ = localResourceFile.ModrinthHash;
								Conversions.ToString(localResourceFile.CurseForgeHash);
								CS_0024_003C_003E8__locals119._0024VB_0024Local_Loader.Output.Add(localResourceFile);
							}
							CS_0024_003C_003E8__locals119._0024VB_0024Local_Progress++;
							if (CS_0024_003C_003E8__locals119._0024VB_0024Local_Progress == 25)
							{
								CS_0024_003C_003E8__locals119._0024VB_0024Local_Loader.Progress += (0.84 - CS_0024_003C_003E8__locals119._0024VB_0024Local_Loader.Progress) * 0.012;
								CS_0024_003C_003E8__locals119._0024VB_0024Local_Progress = 0;
							}
						}
					}
				};
				CS_0024_003C_003E8__locals119._0024VB_0024Local_SearchFolder(DirectoryUtils.GetInfo(CS_0024_003C_003E8__locals107._0024VB_0024Local_PathIndie));
				Logger.Info($"复制 overrides 文件完成，有 {CS_0024_003C_003E8__locals119._0024VB_0024Local_Loader.Output.Count} 个文件需要联网检查", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
				CS_0024_003C_003E8__locals119._0024VB_0024Local_Loader.Progress = 0.85;
				if (CS_0024_003C_003E8__locals107._0024VB_0024Local_IncludeJava)
				{
					string text = PathUtils.RemoveLastPart((ModJava.SelectOrDownloadJava(CS_0024_003C_003E8__locals107._0024VB_0024Local_TargetInstance, TryFixOrHint: false, CS_0024_003C_003E8__locals119._0024VB_0024Local_Loader.CreateCancellationToken(), CS_0024_003C_003E8__locals119._0024VB_0024Local_Loader.CreateSyncProgressProvider(0.85, 0.93)) ?? throw new FileNotFoundException("版本文件夹中没有找到可导出的 Java。")).Folder);
					string text2 = Path.Combine(CS_0024_003C_003E8__locals107._0024VB_0024Local_OverridesFolder, text.AfterFirst(CS_0024_003C_003E8__locals107._0024VB_0024Local_TargetInstance.PathVersion, ignoreCase: true));
					DirectoryUtils.Copy(text, text2);
					Logger.Info($"已复制版本文件夹中的 Java：{text} → {text2}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
				}
				CS_0024_003C_003E8__locals119._0024VB_0024Local_Loader.Progress = 0.95;
				string text3 = (CS_0024_003C_003E8__locals107._0024VB_0024Local_IncludePCL ? CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder : (CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder + "modpack\\"));
				foreach (string item5 in CS_0024_003C_003E8__locals107._0024VB_0024Local_AllExtraFiles)
				{
					if (item5.EndsWithF("\\") || item5.EndsWithF("/"))
					{
						if (DirectoryUtils.Exists(item5))
						{
							DirectoryUtils.Copy(item5, text3 + PathUtils.GetLastPart(item5) + "\\");
						}
						else
						{
							ModMain.Hint($"未找到配置文件中指定的文件夹：{item5}", ModMain.HintType.Red);
						}
					}
					else if (FileUtils.Exists(item5))
					{
						FileUtils.Copy(item5, text3 + PathUtils.GetLastPart(item5));
					}
					else
					{
						ModMain.Hint($"未找到配置文件中指定的单个文件：{item5}", ModMain.HintType.Red);
					}
				}
				CS_0024_003C_003E8__locals119._0024VB_0024Local_Loader.Progress = 0.97;
				if (DirectoryUtils.Exists(CS_0024_003C_003E8__locals107._0024VB_0024Local_TargetInstance.PathVersion + "PCL\\"))
				{
					DirectoryUtils.Copy(CS_0024_003C_003E8__locals107._0024VB_0024Local_TargetInstance.PathVersion + "PCL\\", CS_0024_003C_003E8__locals107._0024VB_0024Local_OverridesFolder + "PCL\\");
				}
				ModBase.WriteIni(CS_0024_003C_003E8__locals107._0024VB_0024Local_OverridesFolder + "PCL\\Setup.ini", "IsStar", Conversions.ToString(Value: false));
				if (CS_0024_003C_003E8__locals107._0024VB_0024Local_IncludePCLCustom)
				{
					if (DirectoryUtils.Exists(Paths.Base + "PCL\\Pictures\\"))
					{
						DirectoryUtils.Copy(Paths.Base + "PCL\\Pictures\\", CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder + "PCL\\Pictures\\");
					}
					if (DirectoryUtils.Exists(Paths.Base + "PCL\\Musics\\"))
					{
						DirectoryUtils.Copy(Paths.Base + "PCL\\Musics\\", CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder + "PCL\\Musics\\");
					}
					if (DirectoryUtils.Exists(Paths.Base + "PCL\\Help\\"))
					{
						DirectoryUtils.Copy(Paths.Base + "PCL\\Help\\", CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder + "PCL\\Help\\");
					}
					if (FileUtils.Exists(Paths.Base + "PCL\\Custom.xaml"))
					{
						FileUtils.Copy(Paths.Base + "PCL\\Custom.xaml", CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder + "PCL\\Custom.xaml");
					}
					if (FileUtils.Exists(Paths.Base + "PCL\\Setup.ini"))
					{
						FileUtils.Copy(Paths.Base + "PCL\\Setup.ini", CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder + "PCL\\Setup.ini");
					}
					if (FileUtils.Exists(Paths.Base + "PCL\\hints.txt"))
					{
						FileUtils.Copy(Paths.Base + "PCL\\hints.txt", CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder + "PCL\\hints.txt");
					}
					if (FileUtils.Exists(Paths.Base + "PCL\\Logo.png"))
					{
						FileUtils.Copy(Paths.Base + "PCL\\Logo.png", CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder + "PCL\\Logo.png");
					}
				}
			})
			{
				ProgressWeight = 5.0
			});
			list2.Add(new ModLoader.LoaderTask<List<LocalResourceFile>, Dictionary<LocalResourceFile, List<string>>>("联网获取文件信息", [SpecialName] (ModLoader.LoaderTask<List<LocalResourceFile>, Dictionary<LocalResourceFile, List<string>>> Loader) =>
			{
				_Closure_0024__25_002D3 arg2 = default;
				_Closure_0024__25_002D3 CS_0024_003C_003E8__locals132 = new _Closure_0024__25_002D3(arg2);
				CS_0024_003C_003E8__locals132._0024VB_0024NonLocal__0024VB_0024Closure_3 = CS_0024_003C_003E8__locals107;
				CS_0024_003C_003E8__locals132._0024VB_0024Local_Loader = Loader;
				CS_0024_003C_003E8__locals132._0024VB_0024Local_Loader.Output = new Dictionary<LocalResourceFile, List<string>>();
				if (!CS_0024_003C_003E8__locals107._0024VB_0024Local_CheckHostedAssets)
				{
					Logger.Info("要求跳过联网获取步骤", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
				}
				else if (!CS_0024_003C_003E8__locals132._0024VB_0024Local_Loader.Input.Any())
				{
					Logger.Info("没有需要联网检查的文件，跳过联网获取步骤", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
				}
				else
				{
					CS_0024_003C_003E8__locals132._0024VB_0024Local_EndedThreadCount = 0;
					CS_0024_003C_003E8__locals132._0024VB_0024Local_FailedExceptions = new List<Exception>();
					ModBase.RunInNewThread([SpecialName] () =>
					{
						try
						{
							IEnumerable<string> list3 = CS_0024_003C_003E8__locals132._0024VB_0024Local_Loader.Input.Select([SpecialName] (LocalResourceFile m) => m.ModrinthHash);
							JObject jObject = (JObject)ModDownload.DlModRequest("https://api.modrinth.com/v2/version_files", HttpMethod.Post, string.Format("{{\"hashes\": [\"{0}\"], \"algorithm\": \"sha1\"}}", list3.Join("\",\"")), "application/json");
							foreach (LocalResourceFile item6 in CS_0024_003C_003E8__locals132._0024VB_0024Local_Loader.Input)
							{
								if (jObject.ContainsKey(item6.ModrinthHash) && !((string?)jObject[item6.ModrinthHash]?["files"]?[0]["hashes"]?["sha1"] != item6.ModrinthHash))
								{
									CS_0024_003C_003E8__locals132._0024VB_0024Local_Loader.Output.AddIntoValueCollection(item6, (string?)jObject[item6.ModrinthHash]["files"][0]["url"]);
								}
							}
							Logger.Info($"从 Modrinth 获取到 {jObject.Count} 个本地资源项的对应信息", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							Logger.Warn(ex4, "从 Modrinth 获取本地 Mod 信息失败", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
							CS_0024_003C_003E8__locals132._0024VB_0024Local_FailedExceptions.Add(ex4);
							ProjectData.ClearProjectError();
						}
						finally
						{
							CS_0024_003C_003E8__locals132._0024VB_0024Local_EndedThreadCount++;
							CS_0024_003C_003E8__locals132._0024VB_0024Local_Loader.Progress += 0.45;
						}
					}, "Modrinth - " + CS_0024_003C_003E8__locals107._0024VB_0024Local_LoaderName);
					ModBase.RunInNewThread([SpecialName] () =>
					{
						try
						{
							if (!CS_0024_003C_003E8__locals132._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_ModrinthUploadMode)
							{
								IEnumerable<uint> list3 = CS_0024_003C_003E8__locals132._0024VB_0024Local_Loader.Input.Select([SpecialName] (LocalResourceFile m) => m.CurseForgeHash);
								JContainer jContainer = (JContainer)ModDownload.DlModRequest("https://api.curseforge.com/v1/fingerprints/432", HttpMethod.Post, string.Format("{{\"fingerprints\": [{0}]}}", list3.Join(",")), "application/json")["data"]["exactMatches"];
								_Closure_0024__25_002D4 obj = default;
								foreach (JObject item7 in (IEnumerable<JToken>)jContainer)
								{
									obj = new _Closure_0024__25_002D4(obj);
									if (item7.ContainsKey("file"))
									{
										obj._0024VB_0024Local_File = (JObject)item7["file"];
										if (!string.IsNullOrEmpty((string?)obj._0024VB_0024Local_File["downloadUrl"]))
										{
											LocalResourceFile localResourceFile = CS_0024_003C_003E8__locals132._0024VB_0024Local_Loader.Input.FirstOrDefault(obj._Lambda_0024__9);
											if (localResourceFile != null)
											{
												foreach (string item8 in ResourceVersion.ParseCurseForgeDownloadUrls(obj._0024VB_0024Local_File["downloadUrl"].ToString()))
												{
													CS_0024_003C_003E8__locals132._0024VB_0024Local_Loader.Output.AddIntoValueCollection(localResourceFile, item8);
												}
											}
										}
									}
								}
								Logger.Info($"从 CurseForge 获取到 {jContainer.Count} 个本地资源项的对应信息", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
							}
						}
						catch (Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							Exception ex4 = ex3;
							Logger.Warn(ex4, "从 CurseForge 获取本地 Mod 信息失败", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceExport.xaml.vb");
							CS_0024_003C_003E8__locals132._0024VB_0024Local_FailedExceptions.Add(ex4);
							ProjectData.ClearProjectError();
						}
						finally
						{
							CS_0024_003C_003E8__locals132._0024VB_0024Local_EndedThreadCount++;
							CS_0024_003C_003E8__locals132._0024VB_0024Local_Loader.Progress += 0.45;
						}
					}, "CurseForge - " + CS_0024_003C_003E8__locals107._0024VB_0024Local_LoaderName);
					while (true)
					{
						if (CS_0024_003C_003E8__locals132._0024VB_0024Local_EndedThreadCount == 2)
						{
							if (CS_0024_003C_003E8__locals132._0024VB_0024Local_FailedExceptions.Count == 1)
							{
								if (ModMain.MyMsgBox("联网获取部分文件信息失败，是否继续导出？\r\n\r\n若继续，无法获取信息的文件将被直接打包。\r\n由于二次分发可能违反使用协议，请尽量不要公开发布导出的整合包！", "部分文件信息获取失败", "继续", "取消") != 2)
								{
									break;
								}
								throw CS_0024_003C_003E8__locals132._0024VB_0024Local_FailedExceptions.First();
							}
							if (CS_0024_003C_003E8__locals132._0024VB_0024Local_FailedExceptions.Count <= 1 || ModMain.MyMsgBox("联网获取文件信息失败，是否继续导出？\r\n\r\n若继续，所有文件都将被直接打包。\r\n由于二次分发可能违反使用协议，请尽量不要公开发布导出的整合包！", "文件信息获取失败", "继续", "取消") != 2)
							{
								break;
							}
							throw CS_0024_003C_003E8__locals132._0024VB_0024Local_FailedExceptions.First();
						}
						if (CS_0024_003C_003E8__locals132._0024VB_0024Local_Loader.IsCanceled)
						{
							break;
						}
						Thread.Sleep(10);
					}
				}
			})
			{
				Show = CS_0024_003C_003E8__locals107._0024VB_0024Local_CheckHostedAssets,
				ProgressWeight = (CS_0024_003C_003E8__locals107._0024VB_0024Local_CheckHostedAssets ? 2.0 : 0.01)
			});
			list2.Add(new ModLoader.LoaderTask<Dictionary<LocalResourceFile, List<string>>, int>("生成压缩包", [SpecialName] (ModLoader.LoaderTask<Dictionary<LocalResourceFile, List<string>>, int> Loader) =>
			{
				JArray jArray = new JArray();
				foreach (KeyValuePair<LocalResourceFile, List<string>> item9 in Loader.Input)
				{
					LocalResourceFile key = item9.Key;
					jArray.Add(new JObject
					{
						{
							"path",
							PathUtils.RemoveExtendedPrefix(key.File.FullName).AfterFirst(CS_0024_003C_003E8__locals107._0024VB_0024Local_OverridesFolder).Replace("\\", "/")
						},
						{
							"hashes",
							new JObject
							{
								{ "sha1", key.ModrinthHash },
								{
									"sha512",
									CryptographyUtils.ComputeFileHash(key.File.FullName, CryptographyUtils.HashMethod.Sha512)
								}
							}
						},
						{
							"downloads",
							new JArray(item9.Value.OrderBy((_Closure_0024__._0024I25_002D11 == null) ? (_Closure_0024__._0024I25_002D11 = [SpecialName] (string u) => u.Contains("modrinth.com")) : _Closure_0024__._0024I25_002D11))
						},
						{
							"fileSize",
							key.File.Length
						}
					});
					key.File.Delete();
				}
				Loader.Progress = 0.2;
				JObject jObject = new JObject { 
				{
					"minecraft",
					CS_0024_003C_003E8__locals107._0024VB_0024Local_TargetInstance.Version.VanillaName
				} };
				if (CS_0024_003C_003E8__locals107._0024VB_0024Local_TargetInstance.Version.ModLoaders.HasFlagF(ModLoaders.Forge))
				{
					jObject.Add("forge", CS_0024_003C_003E8__locals107._0024VB_0024Local_TargetInstance.Version.ModLoaderVersions[ModLoaders.Forge]);
				}
				if (CS_0024_003C_003E8__locals107._0024VB_0024Local_TargetInstance.Version.ModLoaders.HasFlagF(ModLoaders.Fabric))
				{
					jObject.Add("fabric-loader", CS_0024_003C_003E8__locals107._0024VB_0024Local_TargetInstance.Version.ModLoaderVersions[ModLoaders.Fabric]);
				}
				if (CS_0024_003C_003E8__locals107._0024VB_0024Local_TargetInstance.Version.ModLoaders.HasFlagF(ModLoaders.NeoForge))
				{
					jObject.Add("neoforge", CS_0024_003C_003E8__locals107._0024VB_0024Local_TargetInstance.Version.ModLoaderVersions[ModLoaders.NeoForge]);
				}
				JObject jObject2 = new JObject
				{
					{ "game", "minecraft" },
					{ "formatVersion", 1 },
					{ "versionId", CS_0024_003C_003E8__locals107._0024VB_0024Local_PackVersion },
					{ "name", CS_0024_003C_003E8__locals107._0024VB_0024Local_PackName },
					{
						"summary",
						CS_0024_003C_003E8__locals107._0024VB_0024Local_TargetInstance.Info
					},
					{ "files", jArray },
					{ "dependencies", jObject }
				};
				FileUtils.Write(CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder + "modpack\\modrinth.index.json", jObject2.ToString(Formatting.Indented));
				if (CS_0024_003C_003E8__locals107._0024VB_0024Local_IncludePCL)
				{
					FileUtils.CreateZipFromDirectory(CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder + "modpack.mrpack", CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder + "modpack\\");
					Loader.Progress = 0.5;
					DirectoryUtils.Delete(CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder + "modpack\\");
					Loader.Progress = 0.6;
					FileUtils.CreateZipFromDirectory(CS_0024_003C_003E8__locals107._0024VB_0024Local_PackPath, CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder);
					Loader.Progress = 0.9;
				}
				else
				{
					FileUtils.CreateZipFromDirectory(CS_0024_003C_003E8__locals107._0024VB_0024Local_PackPath, CS_0024_003C_003E8__locals107._0024VB_0024Local_CacheFolder + "modpack\\");
					Loader.Progress = 0.8;
				}
				ModBase.OpenExplorer(CS_0024_003C_003E8__locals107._0024VB_0024Local_PackPath);
			})
			{
				ProgressWeight = 6.0
			});
			ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(CS_0024_003C_003E8__locals107._0024VB_0024Local_LoaderName, list2);
			loaderCombo.OnStateChanged = ModDownloadLib.LoaderStateChangedHintOnly;
			loaderCombo.Start();
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
			ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
		}
	}

	private void RefreshJavaInfo()
	{
		int num = Settings.Get<int>("VersionArgumentJavaV2", PageInstanceLeft.Instance);
		RedoableWorker<Java> currentJavaWorker = PageInstanceLeft.CurrentJavaWorker;
		Java java = ((num == 2 && currentJavaWorker.LastSucceeded && !currentJavaWorker.Running) ? currentJavaWorker.LastResult : null);
		if (java == null)
		{
			CheckOptionsJava.Visibility = Visibility.Collapsed;
		}
		else
		{
			CheckOptionsJava.Visibility = Visibility.Visible;
			CheckOptionsJava.Inlines.Clear();
			CheckOptionsJava.Inlines.Add(new Run(GetExportOption(CheckOptionsJava).Title));
			CheckOptionsJava.Inlines.Add(new Run("   " + string.Format("Java {0} ({1})：{2}", java.Version.Major, java.Version, PathUtils.AddSlashSuffix(PathUtils.RemoveLastPart(java.Folder.Replace(PathUtils.RemoveLastPart(PathUtils.RemoveLastPart(PageInstanceLeft.Instance.PathVersion)), ""))).TrimStart('\\')))
			{
				Foreground = ModSecret.ColorGray5
			});
		}
		switch (num)
		{
		case 3:
			BtnExport.IsEnabled = true;
			HintJava.Visibility = Visibility.Visible;
			HintJava.Theme = MyHint.Themes.Yellow;
			HintJava.Text = $"该版本设置要求 {ModBase.vbLQ}使用指定的 Java{ModBase.vbRQ}，这在导出后很可能会失效。建议修改为 {ModBase.vbLQ}使用版本文件夹中的 Java{ModBase.vbRQ}。";
			return;
		case 2:
			if (currentJavaWorker.HasSucceeded && currentJavaWorker.LastResult == null)
			{
				BtnExport.IsEnabled = false;
				HintJava.Visibility = Visibility.Visible;
				HintJava.Theme = MyHint.Themes.Red;
				HintJava.Text = $"该版本设置要求 {ModBase.vbLQ}使用版本文件夹中的 Java{ModBase.vbRQ}，但版本文件夹中没能找到任何 Java。";
				return;
			}
			break;
		}
		BtnExport.IsEnabled = true;
		HintJava.Visibility = Visibility.Collapsed;
	}

	private void TextExportName_GotFocus()
	{
		if (Operators.CompareString(TextExportName.Text, "", TextCompare: false) == 0)
		{
			TextExportName.Text = TextExportName.HintText;
			TextExportName.SelectionStart = TextExportName.Text.Length;
		}
	}

	private void CheckAdvancedInclude_Change(object sender, bool user)
	{
		if (CheckAdvancedInclude.Checked)
		{
			CheckAdvancedModrinth.Checked = false;
		}
		CheckAdvancedModrinth.IsEnabled = !CheckAdvancedInclude.Checked;
	}

	private void CheckAdvancedModrinth_Change(object sender, bool user)
	{
		HintModrinthFormat.Visibility = ModBase.ToVisibility(CheckAdvancedModrinth.Checked && CheckOptionsPcl.Checked);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
