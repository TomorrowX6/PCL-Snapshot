using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using MeloongCore;
using MeloongCore.Extensions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCLCS;

namespace PCL;

public class ResourceSearcher
{
	public class SearchRequest
	{
		public SearchResult Storage;

		public int TargetResultCount;

		public ResourceTypes Type;

		public string Tag;

		public ModLoaders ModLoaders;

		public string GameVersion;

		public string SearchText;

		public ResourcePlatforms Sources;

		public bool CanContinue
		{
			get
			{
				if (Tag.StartsWithF("/") || !Sources.HasFlagF(ResourcePlatforms.CurseForge))
				{
					Storage.CurseForgeTotal = 0;
				}
				if (Tag.EndsWithF("/") || !Sources.HasFlagF(ResourcePlatforms.Modrinth))
				{
					Storage.ModrinthTotal = 0;
				}
				if (Storage.CurseForgeTotal == -1 || Storage.ModrinthTotal == -1)
				{
					return true;
				}
				return Storage.CurseForgeOffset < Storage.CurseForgeTotal || Storage.ModrinthOffset < Storage.ModrinthTotal;
			}
		}

		public SearchRequest(ResourceTypes Type, SearchResult Storage, int TargetResultCount)
		{
			Tag = "";
			ModLoaders = ModLoaders.None;
			GameVersion = null;
			SearchText = null;
			Sources = ResourcePlatforms.Any;
			this.Type = Type;
			this.Storage = Storage;
			this.TargetResultCount = TargetResultCount;
		}

		public string GetCurseForgeAddress(string SearchText, bool IgnoreModLoaderFilter)
		{
			if (Tag.StartsWithF("/"))
			{
				Storage.CurseForgeTotal = 0;
			}
			string text = $"https://api.curseforge.com/v1/mods/search?gameId=432&sortField=2&sortOrder=desc&pageSize={40}";
			switch (Type)
			{
			case ResourceTypes.Mod:
				text += "&classId=6";
				break;
			case ResourceTypes.ModPack:
				text += "&classId=4471";
				break;
			case ResourceTypes.DataPack:
				text += "&classId=6945";
				break;
			case ResourceTypes.Shader:
				text += "&classId=6552";
				break;
			case ResourceTypes.ResourcePack:
				text += "&classId=12";
				break;
			}
			if (Operators.CompareString(Tag, "", TextCompare: false) != 0)
			{
				text = text + "&categoryId=" + Tag.BeforeFirst("/");
			}
			if (ModLoaders != ModLoaders.None && !IgnoreModLoaderFilter)
			{
				text = text + "&modLoaderType=" + Conversions.ToString(Resource.ToCurseForgeModLoaderType(ModLoaders.Flags().First()));
			}
			if (!string.IsNullOrEmpty(GameVersion))
			{
				text = text + "&gameVersion=" + GameVersion;
			}
			if (!string.IsNullOrEmpty(SearchText))
			{
				text = text + "&searchFilter=" + StringUtils.UrlEscape(SearchText);
			}
			if (Storage.CurseForgeOffset > 0)
			{
				text = text + "&index=" + Conversions.ToString(Storage.CurseForgeOffset);
			}
			return text;
		}

		public string GetModrinthAddress(string SearchText, bool IgnoreModLoaderFilter)
		{
			if (Tag.EndsWithF("/"))
			{
				Storage.ModrinthTotal = 0;
			}
			string text = $"https://api.modrinth.com/v2/search?limit={40}&index=relevance";
			if (!string.IsNullOrEmpty(SearchText))
			{
				text = text + "&query=" + StringUtils.UrlEscape(SearchText);
			}
			if (Storage.ModrinthOffset > 0)
			{
				text = text + "&offset=" + Conversions.ToString(Storage.ModrinthOffset);
			}
			List<string> list = new List<string>();
			list.Add($"[\"project_type:{Type.ToString().Lower()}\"]");
			if (!string.IsNullOrEmpty(Tag))
			{
				list.Add(string.Format("[\"categories:'{0}'\"]", Tag.AfterLast("/")));
			}
			if (ModLoaders != ModLoaders.None && !IgnoreModLoaderFilter)
			{
				list.Add(string.Format("[\"categories:{0}\"]", (from f in ModLoaders.Flags()
					select f.ToString().Lower()).Join("\",\"categories:")));
			}
			if (!string.IsNullOrEmpty(GameVersion))
			{
				list.Add($"[\"versions:'{GameVersion}'\"]");
			}
			return text + "&facets=[" + string.Join(",", list) + "]";
		}

		public override bool Equals(object obj)
		{
			if (obj is SearchRequest searchRequest && Type == searchRequest.Type && TargetResultCount == searchRequest.TargetResultCount && Operators.CompareString(Tag, searchRequest.Tag, TextCompare: false) == 0 && ModLoaders == searchRequest.ModLoaders && Sources == searchRequest.Sources && Operators.CompareString(GameVersion, searchRequest.GameVersion, TextCompare: false) == 0)
			{
				return Operators.CompareString(SearchText, searchRequest.SearchText, TextCompare: false) == 0;
			}
			return false;
		}

		public static bool operator ==(SearchRequest left, SearchRequest right)
		{
			return EqualityComparer<SearchRequest>.Default.Equals(left, right);
		}

		public static bool operator !=(SearchRequest left, SearchRequest right)
		{
			return !(left == right);
		}

		public override int GetHashCode()
		{
			return (Type, Tag, ModLoaders, GameVersion, SearchText, Sources).GetHashCode();
		}
	}

	public class SearchResult
	{
		public int CurseForgeOffset;

		public int CurseForgeTotal;

		public int ModrinthOffset;

		public int ModrinthTotal;

		public List<ResourceProject> Results;

		public string ErrorMessage;

		public SearchResult()
		{
			CurseForgeOffset = 0;
			CurseForgeTotal = -1;
			ModrinthOffset = 0;
			ModrinthTotal = -1;
			Results = new List<ResourceProject>();
			ErrorMessage = null;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D0
	{
		public List<string> _0024VB_0024Local_Candidates;

		public Func<string, bool> _0024VB_0024Local_CanForm;

		public _Closure_0024__6_002D0(_Closure_0024__6_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Candidates = arg0._0024VB_0024Local_Candidates;
				_0024VB_0024Local_CanForm = arg0._0024VB_0024Local_CanForm;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__4(string s)
		{
			_Closure_0024__6_002D1 arg = default;
			_Closure_0024__6_002D1 CS_0024_003C_003E8__locals6 = new _Closure_0024__6_002D1(arg);
			CS_0024_003C_003E8__locals6._0024VB_0024NonLocal__0024VB_0024Closure_2 = this;
			CS_0024_003C_003E8__locals6._0024VB_0024Local_s = s;
			if (!_0024VB_0024Local_Candidates.Contains(CS_0024_003C_003E8__locals6._0024VB_0024Local_s))
			{
				return _0024VB_0024Local_Candidates.Any([SpecialName] (string c) => CS_0024_003C_003E8__locals6._0024VB_0024Local_s.StartsWith(c) && CS_0024_003C_003E8__locals6._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_CanForm(CS_0024_003C_003E8__locals6._0024VB_0024Local_s.Substring(c.Length)));
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda_0024__6(string w)
		{
			_Closure_0024__6_002D2 arg = default;
			_Closure_0024__6_002D2 CS_0024_003C_003E8__locals6 = new _Closure_0024__6_002D2(arg);
			CS_0024_003C_003E8__locals6._0024VB_0024NonLocal__0024VB_0024Closure_3 = this;
			CS_0024_003C_003E8__locals6._0024VB_0024Local_w = w;
			return !_0024VB_0024Local_Candidates.Any([SpecialName] (string c) => c.Length < CS_0024_003C_003E8__locals6._0024VB_0024Local_w.Length && CS_0024_003C_003E8__locals6._0024VB_0024Local_w.StartsWith(c) && CS_0024_003C_003E8__locals6._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_CanForm(CS_0024_003C_003E8__locals6._0024VB_0024Local_w.Substring(c.Length)));
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D1
	{
		public string _0024VB_0024Local_s;

		public _Closure_0024__6_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__6_002D1(_Closure_0024__6_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_s = arg0._0024VB_0024Local_s;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__5(string c)
		{
			if (_0024VB_0024Local_s.StartsWith(c))
			{
				return _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_CanForm(_0024VB_0024Local_s.Substring(c.Length));
			}
			return false;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D2
	{
		public string _0024VB_0024Local_w;

		public _Closure_0024__6_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_3;

		public _Closure_0024__6_002D2(_Closure_0024__6_002D2 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_w = arg0._0024VB_0024Local_w;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__7(string c)
		{
			if (c.Length < _0024VB_0024Local_w.Length && _0024VB_0024Local_w.StartsWith(c))
			{
				return _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_CanForm(_0024VB_0024Local_w.Substring(c.Length));
			}
			return false;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D3
	{
		public string _0024VB_0024Local_RawSearchText;

		public SearchRequest _0024VB_0024Local_Request;

		public string _0024VB_0024Local_CurseForgeAltSearchText;

		public bool _0024VB_0024Local_IgnoreModLoaderFilter;

		public ConcurrentBag<ResourceProject> _0024VB_0024Local_SearchResults;

		public SearchResult _0024VB_0024Local_Storage;

		public ConcurrentBag<(Exception Ex, ResourcePlatforms Source)> _0024VB_0024Local_Errors;

		public ModLoader.LoaderTask<SearchRequest, int> _0024VB_0024Local_Task;

		public string _0024VB_0024Local_ModrinthAltSearchText;

		public List<string> _0024VB_0024Local_ModrinthSlugs;

		public List<ResourceProject> _0024VB_0024Local_RealResults;

		public Func<ModBase.SearchSource, bool> _0024I12;

		public Action<ResourceProject> _0024I16;

		public Action<ResourceProject> _0024I18;

		public Func<JToken, bool> _0024I20;

		public Func<string, bool> _0024I21;

		public Action<ResourceProject> _0024I26;

		public _Closure_0024__6_002D3(_Closure_0024__6_002D3 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_RawSearchText = arg0._0024VB_0024Local_RawSearchText;
				_0024VB_0024Local_Request = arg0._0024VB_0024Local_Request;
				_0024VB_0024Local_CurseForgeAltSearchText = arg0._0024VB_0024Local_CurseForgeAltSearchText;
				_0024VB_0024Local_IgnoreModLoaderFilter = arg0._0024VB_0024Local_IgnoreModLoaderFilter;
				_0024VB_0024Local_SearchResults = arg0._0024VB_0024Local_SearchResults;
				_0024VB_0024Local_Storage = arg0._0024VB_0024Local_Storage;
				_0024VB_0024Local_Errors = arg0._0024VB_0024Local_Errors;
				_0024VB_0024Local_Task = arg0._0024VB_0024Local_Task;
				_0024VB_0024Local_ModrinthAltSearchText = arg0._0024VB_0024Local_ModrinthAltSearchText;
				_0024VB_0024Local_ModrinthSlugs = arg0._0024VB_0024Local_ModrinthSlugs;
				_0024VB_0024Local_RealResults = arg0._0024VB_0024Local_RealResults;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__12(ModBase.SearchSource s)
		{
			return s.Aliases.Contains(_0024VB_0024Local_RawSearchText);
		}

		[SpecialName]
		internal void _Lambda_0024__15()
		{
			checked
			{
				try
				{
					string curseForgeAddress = _0024VB_0024Local_Request.GetCurseForgeAddress(_0024VB_0024Local_CurseForgeAltSearchText ?? _0024VB_0024Local_RawSearchText, _0024VB_0024Local_IgnoreModLoaderFilter);
					Logger.Info($"开始 CurseForge 搜索：{curseForgeAddress}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
					JObject jObject = (JObject)ModDownload.DlModRequest(curseForgeAddress);
					List<ResourceProject> list = new List<ResourceProject>();
					foreach (JObject item in (IEnumerable<JToken>)jObject["data"])
					{
						ResourceProject resourceProject = new ResourceProject(item);
						if ((_0024VB_0024Local_Request.Type != ResourceTypes.ResourcePack || !resourceProject.Tags.Contains("数据包")) && (_0024VB_0024Local_Request.Type == ResourceTypes.Any || resourceProject.Types.HasFlagF(_0024VB_0024Local_Request.Type)))
						{
							list.Add(resourceProject);
						}
					}
					list.ForEach([SpecialName] (ResourceProject p) =>
					{
						_0024VB_0024Local_SearchResults.Add(p);
					});
					_0024VB_0024Local_Storage.CurseForgeOffset += jObject["data"].Count();
					_0024VB_0024Local_Storage.CurseForgeTotal = jObject["pagination"]["totalCount"].ToObject<int>();
					Logger.Info($"从 CurseForge 搜索到了 {list.Count} 个工程（总计已获取 {_0024VB_0024Local_Storage.CurseForgeOffset} 个，共 {_0024VB_0024Local_Storage.CurseForgeTotal} 个）", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Logger.Warn(ex2, "CurseForge 搜索失败", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
					_0024VB_0024Local_Storage.CurseForgeTotal = -1;
					_0024VB_0024Local_Errors.Add((ex2, ResourcePlatforms.CurseForge));
					ProjectData.ClearProjectError();
				}
				if (_0024VB_0024Local_Task.Progress < 0.75)
				{
					_0024VB_0024Local_Task.Progress += 0.25;
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__16(ResourceProject p)
		{
			_0024VB_0024Local_SearchResults.Add(p);
		}

		[SpecialName]
		internal void _Lambda_0024__17()
		{
			checked
			{
				try
				{
					string modrinthAddress = _0024VB_0024Local_Request.GetModrinthAddress(_0024VB_0024Local_ModrinthAltSearchText ?? _0024VB_0024Local_RawSearchText, _0024VB_0024Local_IgnoreModLoaderFilter);
					Logger.Info($"开始 Modrinth 搜索：{modrinthAddress}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
					JObject jObject = (JObject)ModDownload.DlModRequest(modrinthAddress);
					List<ResourceProject> list = new List<ResourceProject>();
					foreach (JObject item in (IEnumerable<JToken>)jObject["hits"])
					{
						list.Add(new ResourceProject(item));
					}
					list.ForEach([SpecialName] (ResourceProject p) =>
					{
						_0024VB_0024Local_SearchResults.Add(p);
					});
					_0024VB_0024Local_Storage.ModrinthOffset += jObject["hits"].Count();
					_0024VB_0024Local_Storage.ModrinthTotal = jObject["total_hits"].ToObject<int>();
					Logger.Info($"从 Modrinth 搜索到了 {list.Count} 个工程（总计已获取 {_0024VB_0024Local_Storage.ModrinthOffset} 个，共 {_0024VB_0024Local_Storage.ModrinthTotal} 个）", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Logger.Warn(ex2, "Modrinth 搜索失败", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
					_0024VB_0024Local_Storage.ModrinthTotal = -1;
					_0024VB_0024Local_Errors.Add((ex2, ResourcePlatforms.Modrinth));
					ProjectData.ClearProjectError();
				}
				if (_0024VB_0024Local_Task.Progress < 0.75)
				{
					_0024VB_0024Local_Task.Progress += 0.25;
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__18(ResourceProject p)
		{
			_0024VB_0024Local_SearchResults.Add(p);
		}

		[SpecialName]
		internal void _Lambda_0024__19()
		{
			try
			{
				string text = string.Format("https://api.modrinth.com/v2/projects?ids=[\"{0}\"]", _0024VB_0024Local_ModrinthSlugs.Join("\",\""));
				Logger.Info($"开始 Modrinth 直接获取：{text}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
				List<ResourceProject> list = new List<ResourceProject>();
				foreach (JObject item in (IEnumerable<JToken>)ModDownload.DlModRequest(text))
				{
					ResourceProject resourceProject = new ResourceProject(item);
					if ((_0024VB_0024Local_Request.Type == ResourceTypes.Any || resourceProject.Types.HasFlagF(_0024VB_0024Local_Request.Type)) && (string.IsNullOrEmpty(_0024VB_0024Local_Request.Tag) || item["categories"].Any([SpecialName] (JToken c) => Operators.CompareString(c.ToString(), _0024VB_0024Local_Request.Tag.AfterLast("/"), TextCompare: false) == 0)) && (_0024VB_0024Local_Request.ModLoaders == ModLoaders.None || _0024VB_0024Local_IgnoreModLoaderFilter || resourceProject.ModLoaders.Flags().Intersect(_0024VB_0024Local_Request.ModLoaders.Flags()).Any()) && (string.IsNullOrEmpty(_0024VB_0024Local_Request.GameVersion) || resourceProject.UnsafeGameVersions.Any([SpecialName] (string d) => Operators.CompareString(d, _0024VB_0024Local_Request.GameVersion, TextCompare: false) == 0)))
					{
						list.Add(resourceProject);
					}
				}
				if (list.Any() && _0024VB_0024Local_Request.ModLoaders != ModLoaders.None && !_0024VB_0024Local_IgnoreModLoaderFilter && !string.IsNullOrEmpty(_0024VB_0024Local_Request.GameVersion))
				{
					_Closure_0024__6_002D4 arg = default;
					_Closure_0024__6_002D4 CS_0024_003C_003E8__locals2 = new _Closure_0024__6_002D4(arg);
					string arg2 = list.Select([SpecialName] (ResourceProject p) => p.Id).Join("\",\"project_id:");
					string arg3 = (from f in _0024VB_0024Local_Request.ModLoaders.Flags()
						select f.ToString().Lower()).Join("\",\"categories:");
					string url = $"https://api.modrinth.com/v2/search?limit={list.Count}&facets=" + $"[[\"project_id:{arg2}\"],[\"categories:{arg3}\"],[\"versions:{_0024VB_0024Local_Request.GameVersion}\"]]";
					CS_0024_003C_003E8__locals2._0024VB_0024Local_MatchedIds = ModDownload.DlModRequest(url)["hits"].Select([SpecialName] (JToken h) => h["project_id"].ToString()).ToList();
					list.KeepIf([SpecialName] (ResourceProject p) => CS_0024_003C_003E8__locals2._0024VB_0024Local_MatchedIds.Contains(p.Id));
				}
				list.ForEach([SpecialName] (ResourceProject p) =>
				{
					_0024VB_0024Local_SearchResults.Add(p);
				});
				Logger.Info($"从 Modrinth 直接获取到了 {list.Count} 个工程", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
				_0024VB_0024Local_ModrinthSlugs.Clear();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Logger.Warn(ex2, "Modrinth 直接获取失败", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
				_0024VB_0024Local_Errors.Add((ex2, ResourcePlatforms.Modrinth));
				ProjectData.ClearProjectError();
			}
			if (_0024VB_0024Local_Task.Progress < 0.75)
			{
				_0024VB_0024Local_Task.Progress += 0.25;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__20(JToken c)
		{
			return Operators.CompareString(c.ToString(), _0024VB_0024Local_Request.Tag.AfterLast("/"), TextCompare: false) == 0;
		}

		[SpecialName]
		internal bool _Lambda_0024__21(string d)
		{
			return Operators.CompareString(d, _0024VB_0024Local_Request.GameVersion, TextCompare: false) == 0;
		}

		[SpecialName]
		internal void _Lambda_0024__26(ResourceProject p)
		{
			_0024VB_0024Local_SearchResults.Add(p);
		}

		[SpecialName]
		internal bool _Lambda_0024__32(ResourceProject r)
		{
			_Closure_0024__6_002D5 arg = default;
			_Closure_0024__6_002D5 CS_0024_003C_003E8__locals3 = new _Closure_0024__6_002D5(arg);
			CS_0024_003C_003E8__locals3._0024VB_0024Local_r = r;
			if (!_0024VB_0024Local_RealResults.Any([SpecialName] (ResourceProject b) => CS_0024_003C_003E8__locals3._0024VB_0024Local_r.IsLike(b)))
			{
				return !_0024VB_0024Local_Storage.Results.Any([SpecialName] (ResourceProject b) => CS_0024_003C_003E8__locals3._0024VB_0024Local_r.IsLike(b));
			}
			return false;
		}

		[SpecialName]
		internal double _Lambda_0024__35(ResourceProject Project)
		{
			switch (_0024VB_0024Local_Request.Type)
			{
			case ResourceTypes.Mod:
			case ResourceTypes.ModPack:
				return (Project.Platform == ResourcePlatforms.CurseForge) ? 1 : 5;
			case ResourceTypes.DataPack:
				return (Project.Platform != ResourcePlatforms.CurseForge) ? 1 : 10;
			case ResourceTypes.ResourcePack:
			case ResourceTypes.Shader:
				return (Project.Platform == ResourcePlatforms.CurseForge) ? 1 : 4;
			default:
				return 1.0;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D4
	{
		public List<string> _0024VB_0024Local_MatchedIds;

		public _Closure_0024__6_002D4(_Closure_0024__6_002D4 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_MatchedIds = arg0._0024VB_0024Local_MatchedIds;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__25(ResourceProject p)
		{
			return _0024VB_0024Local_MatchedIds.Contains(p.Id);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D5
	{
		public ResourceProject _0024VB_0024Local_r;

		public _Closure_0024__6_002D5(_Closure_0024__6_002D5 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_r = arg0._0024VB_0024Local_r;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__33(ResourceProject b)
		{
			return _0024VB_0024Local_r.IsLike(b);
		}

		[SpecialName]
		internal bool _Lambda_0024__34(ResourceProject b)
		{
			return _0024VB_0024Local_r.IsLike(b);
		}
	}

	private const int RESULT_PAGE_SIZE = 40;

	private const string MSG_NO_CHINESE_RESULT = "无搜索结果，请尝试搜索其英文名称";

	[SpecialName]
	private static List<ModBase.SearchEntry<WikiEntry>> _0024STATIC_0024Run_0024011151286FC21283B48_0024CurseForgeSearchEntries;

	[SpecialName]
	private static StaticLocalInitFlag _0024STATIC_0024Run_0024011151286FC21283B48_0024CurseForgeSearchEntries_0024Init;

	[SpecialName]
	private static List<ModBase.SearchEntry<WikiEntry>> _0024STATIC_0024Run_0024011151286FC21283B48_0024ModrinthSearchEntries;

	[SpecialName]
	private static StaticLocalInitFlag _0024STATIC_0024Run_0024011151286FC21283B48_0024ModrinthSearchEntries_0024Init;

	public static ModLoader.LoaderTask<SearchRequest, int> GetLoader(Func<SearchRequest> InputDelegate)
	{
		return new ModLoader.LoaderTask<SearchRequest, int>("社区资源获取", Run, InputDelegate)
		{
			ReloadTimeout = 60000
		};
	}

	private static void Run(ModLoader.LoaderTask<SearchRequest, int> Task)
	{
		_Closure_0024__6_002D3 arg = default;
		_Closure_0024__6_002D3 CS_0024_003C_003E8__locals175 = new _Closure_0024__6_002D3(arg);
		CS_0024_003C_003E8__locals175._0024VB_0024Local_Task = Task;
		CS_0024_003C_003E8__locals175._0024VB_0024Local_Request = CS_0024_003C_003E8__locals175._0024VB_0024Local_Task.Input;
		CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage = CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Storage;
		if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.Results.Count >= CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.TargetResultCount)
		{
			Logger.Info($"已有 {CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.Results.Count} 个结果，多于所需的 {CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.TargetResultCount} 个结果，结束处理", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
			return;
		}
		if (!CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.CanContinue)
		{
			if (!CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.Results.Any())
			{
				throw new Exception("没有符合条件的结果");
			}
			Logger.Info($"已有 {CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.Results.Count} 个结果，少于所需的 {CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.TargetResultCount} 个结果，但无法继续获取，结束处理", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
			return;
		}
		CS_0024_003C_003E8__locals175._0024VB_0024Local_RawSearchText = (CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.SearchText ?? "").Trim();
		CS_0024_003C_003E8__locals175._0024VB_0024Local_RawSearchText = CS_0024_003C_003E8__locals175._0024VB_0024Local_RawSearchText.Lower();
		Logger.Info($"工程列表搜索原始文本：{CS_0024_003C_003E8__locals175._0024VB_0024Local_RawSearchText}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
		CS_0024_003C_003E8__locals175._0024VB_0024Local_RawSearchText = Strings.StrConv(CS_0024_003C_003E8__locals175._0024VB_0024Local_RawSearchText, VbStrConv.SimplifiedChinese);
		bool flag = CS_0024_003C_003E8__locals175._0024VB_0024Local_RawSearchText.RegexCheck("[\\u4e00-\\u9fbb]") && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals175._0024VB_0024Local_RawSearchText) && (CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Type == ResourceTypes.Mod || CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Type == ResourceTypes.DataPack);
		CS_0024_003C_003E8__locals175._0024VB_0024Local_CurseForgeAltSearchText = null;
		CS_0024_003C_003E8__locals175._0024VB_0024Local_ModrinthAltSearchText = null;
		CS_0024_003C_003E8__locals175._0024VB_0024Local_ModrinthSlugs = new List<string>();
		if (flag)
		{
			VB_0024AnonymousDelegate_2<ModBase.SearchEntry<WikiEntry>, ResourcePlatforms, IEnumerable<string>> obj = [SpecialName] (ModBase.SearchEntry<WikiEntry> Result, ResourcePlatforms Source) =>
			{
				_Closure_0024__6_002D0 arg2 = default;
				_Closure_0024__6_002D0 CS_0024_003C_003E8__locals169 = new _Closure_0024__6_002D0(arg2);
				CS_0024_003C_003E8__locals169._0024VB_0024Local_Candidates = new List<string>();
				if (Result.Item.Slugs.ContainsKey(Source))
				{
					CS_0024_003C_003E8__locals169._0024VB_0024Local_Candidates.Add(Result.Item.Slugs[Source].Replace("-", " ").Replace("/", " "));
				}
				if (Result.Item.ChineseName != null)
				{
					CS_0024_003C_003E8__locals169._0024VB_0024Local_Candidates.Add(Result.Item.ChineseName.AfterLast(" (").TrimEnd(')').BeforeFirst(" - ")
						.Replace("-", " ")
						.Replace("/", " ")
						.Replace(":", " ")
						.Replace("(", " ")
						.Replace(")", ""));
				}
				CS_0024_003C_003E8__locals169._0024VB_0024Local_Candidates = (from w in CS_0024_003C_003E8__locals169._0024VB_0024Local_Candidates.SelectMany([SpecialName] (string c) => c.Split(" "))
					select w.TrimStart('{').TrimEnd('}').Lower()).Where([SpecialName] (string w) =>
				{
					if (w.Length <= 1)
					{
						return false;
					}
					if (new string[9] { "the", "of", "mod", "and", "forge", "fabric", "for", "quilt", "neoforge" }.Contains(w))
					{
						return false;
					}
					if (ModBase.Val(w) > 0.0)
					{
						return false;
					}
					return w.IsAsciiOnly() ? true : false;
				}).Distinct().ToList();
				CS_0024_003C_003E8__locals169._0024VB_0024Local_CanForm = null;
				CS_0024_003C_003E8__locals169._0024VB_0024Local_CanForm = [SpecialName] (string s) =>
				{
					_Closure_0024__6_002D1 arg3 = default;
					_Closure_0024__6_002D1 CS_0024_003C_003E8__locals180 = new _Closure_0024__6_002D1(arg3);
					CS_0024_003C_003E8__locals180._0024VB_0024NonLocal__0024VB_0024Closure_2 = CS_0024_003C_003E8__locals169;
					CS_0024_003C_003E8__locals180._0024VB_0024Local_s = s;
					return CS_0024_003C_003E8__locals169._0024VB_0024Local_Candidates.Contains(CS_0024_003C_003E8__locals180._0024VB_0024Local_s) || CS_0024_003C_003E8__locals169._0024VB_0024Local_Candidates.Any([SpecialName] (string c) => CS_0024_003C_003E8__locals180._0024VB_0024Local_s.StartsWith(c) && CS_0024_003C_003E8__locals180._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_CanForm(CS_0024_003C_003E8__locals180._0024VB_0024Local_s.Substring(c.Length)));
				};
				CS_0024_003C_003E8__locals169._0024VB_0024Local_Candidates = CS_0024_003C_003E8__locals169._0024VB_0024Local_Candidates.Where([SpecialName] (string w) =>
				{
					_Closure_0024__6_002D2 arg3 = default;
					_Closure_0024__6_002D2 CS_0024_003C_003E8__locals184 = new _Closure_0024__6_002D2(arg3);
					CS_0024_003C_003E8__locals184._0024VB_0024NonLocal__0024VB_0024Closure_3 = CS_0024_003C_003E8__locals169;
					CS_0024_003C_003E8__locals184._0024VB_0024Local_w = w;
					return !CS_0024_003C_003E8__locals169._0024VB_0024Local_Candidates.Any([SpecialName] (string c) => c.Length < CS_0024_003C_003E8__locals184._0024VB_0024Local_w.Length && CS_0024_003C_003E8__locals184._0024VB_0024Local_w.StartsWith(c) && CS_0024_003C_003E8__locals184._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_CanForm(CS_0024_003C_003E8__locals184._0024VB_0024Local_w.Substring(c.Length)));
				}).ToList();
				return CS_0024_003C_003E8__locals169._0024VB_0024Local_Candidates;
			};
			VB_0024AnonymousDelegate_3<ResourcePlatforms, IEnumerable<ModBase.SearchEntry<WikiEntry>>> obj2 = GetWikiEntries;
            IEnumerable<ModBase.SearchEntry<WikiEntry>> GetWikiEntries(ResourcePlatforms Source)
			{
				foreach (WikiEntry item in WikiEntry.All.Value)
				{
					if (item.Slugs.ContainsKey(Source))
					{
						if (item.ChineseName != null)
						{
							yield return new ModBase.SearchEntry<WikiEntry>
							{
								Item = item,
								SearchSource = new List<ModBase.SearchSource>
								{
									new ModBase.SearchSource(Strings.StrConv(item.ChineseName.BeforeFirst(" ("), VbStrConv.SimplifiedChinese).Split('/', removeEmptyEntries: true)),
									new ModBase.SearchSource(Strings.StrConv(item.ChineseName.AfterFirst(" ("), VbStrConv.SimplifiedChinese) + item.Slugs[Source], 0.5)
								}
							};
						}
						else
						{
							yield return new ModBase.SearchEntry<WikiEntry>
							{
								Item = item,
								SearchSource = new List<ModBase.SearchSource>
								{
									new ModBase.SearchSource(item.Slugs[Source], 0.5)
								}
							};
						}
					}
				}
			}
			if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Sources.HasFlagF(ResourcePlatforms.CurseForge))
			{
				if (_0024STATIC_0024Run_0024011151286FC21283B48_0024CurseForgeSearchEntries_0024Init == null)
				{
					Interlocked.CompareExchange(ref _0024STATIC_0024Run_0024011151286FC21283B48_0024CurseForgeSearchEntries_0024Init, new StaticLocalInitFlag(), null);
				}
				bool lockTaken = false;
				try
				{
					Monitor.Enter(_0024STATIC_0024Run_0024011151286FC21283B48_0024CurseForgeSearchEntries_0024Init, ref lockTaken);
					if (_0024STATIC_0024Run_0024011151286FC21283B48_0024CurseForgeSearchEntries_0024Init.State == 0)
					{
						_0024STATIC_0024Run_0024011151286FC21283B48_0024CurseForgeSearchEntries_0024Init.State = 2;
						_0024STATIC_0024Run_0024011151286FC21283B48_0024CurseForgeSearchEntries = obj2(ResourcePlatforms.CurseForge).ToList();
					}
					else if (_0024STATIC_0024Run_0024011151286FC21283B48_0024CurseForgeSearchEntries_0024Init.State == 2)
					{
						throw new IncompleteInitialization();
					}
				}
				finally
				{
					_0024STATIC_0024Run_0024011151286FC21283B48_0024CurseForgeSearchEntries_0024Init.State = 1;
					if (lockTaken)
					{
						Monitor.Exit(_0024STATIC_0024Run_0024011151286FC21283B48_0024CurseForgeSearchEntries_0024Init);
					}
				}
				List<ModBase.SearchEntry<WikiEntry>> source = ModBase.Search(_0024STATIC_0024Run_0024011151286FC21283B48_0024CurseForgeSearchEntries, CS_0024_003C_003E8__locals175._0024VB_0024Local_RawSearchText, 100, 0.25);
				if (source.Any())
				{
					ModBase.SearchEntry<WikiEntry> result = (source.First().AbsoluteRight ? source.Where([SpecialName] (ModBase.SearchEntry<WikiEntry> s) => s.AbsoluteRight).ToList() : source.MaxByAll([SpecialName] (ModBase.SearchEntry<WikiEntry> s) => s.Similarity)).MaxBy([SpecialName] (ModBase.SearchEntry<WikiEntry> s) => s.Item.Popularity);
					CS_0024_003C_003E8__locals175._0024VB_0024Local_CurseForgeAltSearchText = obj(result, ResourcePlatforms.CurseForge).Join(" ");
					Logger.Warn($"中文搜索关键词（CurseForge）：{CS_0024_003C_003E8__locals175._0024VB_0024Local_CurseForgeAltSearchText}", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
				}
			}
			if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Sources.HasFlagF(ResourcePlatforms.Modrinth))
			{
				if (_0024STATIC_0024Run_0024011151286FC21283B48_0024ModrinthSearchEntries_0024Init == null)
				{
					Interlocked.CompareExchange(ref _0024STATIC_0024Run_0024011151286FC21283B48_0024ModrinthSearchEntries_0024Init, new StaticLocalInitFlag(), null);
				}
				bool lockTaken2 = false;
				try
				{
					Monitor.Enter(_0024STATIC_0024Run_0024011151286FC21283B48_0024ModrinthSearchEntries_0024Init, ref lockTaken2);
					if (_0024STATIC_0024Run_0024011151286FC21283B48_0024ModrinthSearchEntries_0024Init.State == 0)
					{
						_0024STATIC_0024Run_0024011151286FC21283B48_0024ModrinthSearchEntries_0024Init.State = 2;
						_0024STATIC_0024Run_0024011151286FC21283B48_0024ModrinthSearchEntries = obj2(ResourcePlatforms.Modrinth).ToList();
					}
					else if (_0024STATIC_0024Run_0024011151286FC21283B48_0024ModrinthSearchEntries_0024Init.State == 2)
					{
						throw new IncompleteInitialization();
					}
				}
				finally
				{
					_0024STATIC_0024Run_0024011151286FC21283B48_0024ModrinthSearchEntries_0024Init.State = 1;
					if (lockTaken2)
					{
						Monitor.Exit(_0024STATIC_0024Run_0024011151286FC21283B48_0024ModrinthSearchEntries_0024Init);
					}
				}
				List<ModBase.SearchEntry<WikiEntry>> list = ModBase.Search(_0024STATIC_0024Run_0024011151286FC21283B48_0024ModrinthSearchEntries, CS_0024_003C_003E8__locals175._0024VB_0024Local_RawSearchText, 100, 0.25);
				if (list.Any())
				{
					Dictionary<string, double> dictionary = new Dictionary<string, double>();
					foreach (ModBase.SearchEntry<WikiEntry> item2 in list)
					{
						foreach (string item3 in obj(item2, ResourcePlatforms.Modrinth))
						{
							if (!dictionary.ContainsKey(item3))
							{
								dictionary.Add(item3, 0.0);
							}
							double num = (item2.SearchSource.Any([SpecialName] (ModBase.SearchSource s) => s.Aliases.Contains(CS_0024_003C_003E8__locals175._0024VB_0024Local_RawSearchText)) ? 1000.0 : item2.Similarity);
							dictionary[item3] += num * (double)item2.Item.Popularity;
						}
					}
					CS_0024_003C_003E8__locals175._0024VB_0024Local_ModrinthAltSearchText = dictionary.MaxBy([SpecialName] (KeyValuePair<string, double> w) => w.Value).Key;
					Logger.Warn($"中文搜索关键词（Modrinth）：{CS_0024_003C_003E8__locals175._0024VB_0024Local_ModrinthAltSearchText}", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
					CS_0024_003C_003E8__locals175._0024VB_0024Local_ModrinthSlugs = (from r in list.Take(100)
						select r.Item.Slugs[ResourcePlatforms.Modrinth]).ToList();
				}
			}
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals175._0024VB_0024Local_CurseForgeAltSearchText) && string.IsNullOrEmpty(CS_0024_003C_003E8__locals175._0024VB_0024Local_ModrinthAltSearchText) && !CS_0024_003C_003E8__locals175._0024VB_0024Local_ModrinthSlugs.Any())
			{
				throw new Exception("无搜索结果，请尝试搜索其英文名称");
			}
		}
		CS_0024_003C_003E8__locals175._0024VB_0024Local_Task.Progress = 0.05;
		CS_0024_003C_003E8__locals175._0024VB_0024Local_RealResults = new List<ResourceProject>();
		checked
		{
			while (true)
			{
				List<ResourceProject> source2 = new List<ResourceProject>();
				List<Thread> list2 = new List<Thread>();
				CS_0024_003C_003E8__locals175._0024VB_0024Local_Errors = new ConcurrentBag<(Exception, ResourcePlatforms)>();
				CS_0024_003C_003E8__locals175._0024VB_0024Local_IgnoreModLoaderFilter = CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.ModLoaders == ModLoaders.Forge && McVersion.VersionToDrop(CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.GameVersion) < 140;
				CS_0024_003C_003E8__locals175._0024VB_0024Local_SearchResults = new ConcurrentBag<ResourceProject>();
				try
				{
					if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Sources.HasFlagF(ResourcePlatforms.CurseForge) && (CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.CurseForgeTotal <= -1 || CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.CurseForgeTotal > CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.CurseForgeOffset) && (!flag || (flag && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals175._0024VB_0024Local_CurseForgeAltSearchText))))
					{
						list2.Add(ModBase.RunInNewThread([SpecialName] () =>
						{
							try
							{
								string curseForgeAddress = CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.GetCurseForgeAddress(CS_0024_003C_003E8__locals175._0024VB_0024Local_CurseForgeAltSearchText ?? CS_0024_003C_003E8__locals175._0024VB_0024Local_RawSearchText, CS_0024_003C_003E8__locals175._0024VB_0024Local_IgnoreModLoaderFilter);
								Logger.Info($"开始 CurseForge 搜索：{curseForgeAddress}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
								JObject jObject = (JObject)ModDownload.DlModRequest(curseForgeAddress);
								List<ResourceProject> list5 = new List<ResourceProject>();
								foreach (JObject item4 in (IEnumerable<JToken>)jObject["data"])
								{
									ResourceProject resourceProject = new ResourceProject(item4);
									if ((CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Type != ResourceTypes.ResourcePack || !resourceProject.Tags.Contains("数据包")) && (CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Type == ResourceTypes.Any || resourceProject.Types.HasFlagF(CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Type)))
									{
										list5.Add(resourceProject);
									}
								}
								list5.ForEach([SpecialName] (ResourceProject p) =>
								{
									CS_0024_003C_003E8__locals175._0024VB_0024Local_SearchResults.Add(p);
								});
								CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.CurseForgeOffset += jObject["data"].Count();
								CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.CurseForgeTotal = jObject["pagination"]["totalCount"].ToObject<int>();
								Logger.Info($"从 CurseForge 搜索到了 {list5.Count} 个工程（总计已获取 {CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.CurseForgeOffset} 个，共 {CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.CurseForgeTotal} 个）", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception ex2 = ex;
								Logger.Warn(ex2, "CurseForge 搜索失败", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
								CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.CurseForgeTotal = -1;
								CS_0024_003C_003E8__locals175._0024VB_0024Local_Errors.Add((ex2, ResourcePlatforms.CurseForge));
								ProjectData.ClearProjectError();
							}
							if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Task.Progress < 0.75)
							{
								CS_0024_003C_003E8__locals175._0024VB_0024Local_Task.Progress += 0.25;
							}
						}, "CurseForge Search"));
					}
					if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Sources.HasFlagF(ResourcePlatforms.Modrinth) && (CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.ModrinthTotal <= -1 || CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.ModrinthTotal > CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.ModrinthOffset) && (!flag || (flag && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals175._0024VB_0024Local_ModrinthAltSearchText))))
					{
						list2.Add(ModBase.RunInNewThread([SpecialName] () =>
						{
							try
							{
								string modrinthAddress = CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.GetModrinthAddress(CS_0024_003C_003E8__locals175._0024VB_0024Local_ModrinthAltSearchText ?? CS_0024_003C_003E8__locals175._0024VB_0024Local_RawSearchText, CS_0024_003C_003E8__locals175._0024VB_0024Local_IgnoreModLoaderFilter);
								Logger.Info($"开始 Modrinth 搜索：{modrinthAddress}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
								JObject jObject = (JObject)ModDownload.DlModRequest(modrinthAddress);
								List<ResourceProject> list5 = new List<ResourceProject>();
								foreach (JObject item5 in (IEnumerable<JToken>)jObject["hits"])
								{
									list5.Add(new ResourceProject(item5));
								}
								list5.ForEach([SpecialName] (ResourceProject p) =>
								{
									CS_0024_003C_003E8__locals175._0024VB_0024Local_SearchResults.Add(p);
								});
								CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.ModrinthOffset += jObject["hits"].Count();
								CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.ModrinthTotal = jObject["total_hits"].ToObject<int>();
								Logger.Info($"从 Modrinth 搜索到了 {list5.Count} 个工程（总计已获取 {CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.ModrinthOffset} 个，共 {CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.ModrinthTotal} 个）", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception ex2 = ex;
								Logger.Warn(ex2, "Modrinth 搜索失败", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
								CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.ModrinthTotal = -1;
								CS_0024_003C_003E8__locals175._0024VB_0024Local_Errors.Add((ex2, ResourcePlatforms.Modrinth));
								ProjectData.ClearProjectError();
							}
							if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Task.Progress < 0.75)
							{
								CS_0024_003C_003E8__locals175._0024VB_0024Local_Task.Progress += 0.25;
							}
						}, "Modrinth Search"));
					}
					if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Sources.HasFlagF(ResourcePlatforms.Modrinth) && (CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.ModrinthTotal <= -1 || CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.ModrinthTotal > CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.ModrinthOffset) && CS_0024_003C_003E8__locals175._0024VB_0024Local_ModrinthSlugs.Any())
					{
						list2.Add(ModBase.RunInNewThread([SpecialName] () =>
						{
							try
							{
								string text = string.Format("https://api.modrinth.com/v2/projects?ids=[\"{0}\"]", CS_0024_003C_003E8__locals175._0024VB_0024Local_ModrinthSlugs.Join("\",\""));
								Logger.Info($"开始 Modrinth 直接获取：{text}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
								List<ResourceProject> list5 = new List<ResourceProject>();
								foreach (JObject item6 in (IEnumerable<JToken>)ModDownload.DlModRequest(text))
								{
									ResourceProject resourceProject = new ResourceProject(item6);
									if ((CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Type == ResourceTypes.Any || resourceProject.Types.HasFlagF(CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Type)) && (string.IsNullOrEmpty(CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Tag) || item6["categories"].Any([SpecialName] (JToken c) => Operators.CompareString(c.ToString(), CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Tag.AfterLast("/"), TextCompare: false) == 0)) && (CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.ModLoaders == ModLoaders.None || CS_0024_003C_003E8__locals175._0024VB_0024Local_IgnoreModLoaderFilter || resourceProject.ModLoaders.Flags().Intersect(CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.ModLoaders.Flags()).Any()) && (string.IsNullOrEmpty(CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.GameVersion) || resourceProject.UnsafeGameVersions.Any([SpecialName] (string d) => Operators.CompareString(d, CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.GameVersion, TextCompare: false) == 0)))
									{
										list5.Add(resourceProject);
									}
								}
								if (list5.Any() && CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.ModLoaders != ModLoaders.None && !CS_0024_003C_003E8__locals175._0024VB_0024Local_IgnoreModLoaderFilter && !string.IsNullOrEmpty(CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.GameVersion))
								{
									_Closure_0024__6_002D4 arg2 = default;
									_Closure_0024__6_002D4 CS_0024_003C_003E8__locals174 = new _Closure_0024__6_002D4(arg2);
									string arg3 = list5.Select([SpecialName] (ResourceProject p) => p.Id).Join("\",\"project_id:");
									string arg4 = (from f in CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.ModLoaders.Flags()
										select f.ToString().Lower()).Join("\",\"categories:");
									string url = $"https://api.modrinth.com/v2/search?limit={list5.Count}&facets=" + $"[[\"project_id:{arg3}\"],[\"categories:{arg4}\"],[\"versions:{CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.GameVersion}\"]]";
									CS_0024_003C_003E8__locals174._0024VB_0024Local_MatchedIds = ModDownload.DlModRequest(url)["hits"].Select([SpecialName] (JToken h) => h["project_id"].ToString()).ToList();
									list5.KeepIf([SpecialName] (ResourceProject p) => CS_0024_003C_003E8__locals174._0024VB_0024Local_MatchedIds.Contains(p.Id));
								}
								list5.ForEach([SpecialName] (ResourceProject p) =>
								{
									CS_0024_003C_003E8__locals175._0024VB_0024Local_SearchResults.Add(p);
								});
								Logger.Info($"从 Modrinth 直接获取到了 {list5.Count} 个工程", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
								CS_0024_003C_003E8__locals175._0024VB_0024Local_ModrinthSlugs.Clear();
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception ex2 = ex;
								Logger.Warn(ex2, "Modrinth 直接获取失败", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
								CS_0024_003C_003E8__locals175._0024VB_0024Local_Errors.Add((ex2, ResourcePlatforms.Modrinth));
								ProjectData.ClearProjectError();
							}
							if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Task.Progress < 0.75)
							{
								CS_0024_003C_003E8__locals175._0024VB_0024Local_Task.Progress += 0.25;
							}
						}, "Modrinth Get"));
					}
					foreach (Thread item7 in list2)
					{
						item7.Join();
						if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Task.IsCanceled)
						{
							return;
						}
					}
					source2 = new List<ResourceProject>(CS_0024_003C_003E8__locals175._0024VB_0024Local_SearchResults);
					if (CS_0024_003C_003E8__locals175._0024VB_0024Local_IgnoreModLoaderFilter)
					{
						source2.KeepIf([SpecialName] (ResourceProject p) => p.ModLoaders == ModLoaders.None || p.ModLoaders.HasFlagF(ModLoaders.Forge));
					}
					CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.ErrorMessage = null;
					if (!source2.Any())
					{
						if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Errors.Any())
						{
							throw CS_0024_003C_003E8__locals175._0024VB_0024Local_Errors.First().Ex;
						}
						if (flag && CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Type != ResourceTypes.Mod && CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Type != ResourceTypes.DataPack)
						{
							throw new Exception("无搜索结果，请尝试搜索其英文名称");
						}
						if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Sources == ResourcePlatforms.CurseForge && CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Tag.StartsWithF("/"))
						{
							throw new Exception("CurseForge 不兼容所选的类型");
						}
						if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Sources == ResourcePlatforms.Modrinth && CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Tag.EndsWithF("/"))
						{
							throw new Exception("Modrinth 不兼容所选的类型");
						}
						throw new Exception("没有搜索结果");
					}
					if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Errors.Any())
					{
						if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Errors.Any([SpecialName] ((Exception Ex, ResourcePlatforms Source) e) => e.Source == ResourcePlatforms.CurseForge))
						{
							CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.ErrorMessage = string.Format("无法连接到 CurseForge，所以目前仅显示了来自 Modrinth 的内容，搜索结果可能不全。{0}请稍后再试，或使用 VPN 改善网络环境。", "\r\n");
						}
						else
						{
							CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.ErrorMessage = string.Format("无法连接到 Modrinth，所以目前仅显示了来自 CurseForge 的内容，搜索结果可能不全。{0}请稍后再试，或使用 VPN 改善网络环境。", "\r\n");
						}
					}
				}
				finally
				{
					foreach (Thread item8 in list2)
					{
						if (item8.IsAlive)
						{
							item8.Interrupt();
						}
					}
				}
				source2 = source2.Where([SpecialName] (ResourceProject x) => x.Platform == ResourcePlatforms.CurseForge).Concat(source2.Where([SpecialName] (ResourceProject x) => x.Platform != ResourcePlatforms.CurseForge)).ToList();
				source2 = source2.Distinct([SpecialName] (ResourceProject a, ResourceProject b) => a.IsLike(b)).ToList();
				source2 = source2.Where([SpecialName] (ResourceProject r) =>
				{
					_Closure_0024__6_002D5 arg2 = default;
					_Closure_0024__6_002D5 CS_0024_003C_003E8__locals177 = new _Closure_0024__6_002D5(arg2);
					CS_0024_003C_003E8__locals177._0024VB_0024Local_r = r;
					return !CS_0024_003C_003E8__locals175._0024VB_0024Local_RealResults.Any([SpecialName] (ResourceProject b) => CS_0024_003C_003E8__locals177._0024VB_0024Local_r.IsLike(b)) && !CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.Results.Any([SpecialName] (ResourceProject b) => CS_0024_003C_003E8__locals177._0024VB_0024Local_r.IsLike(b));
				}).ToList();
				CS_0024_003C_003E8__locals175._0024VB_0024Local_RealResults.AddRange(source2);
				Logger.Info($"去重、筛选后累计新增结果 {CS_0024_003C_003E8__locals175._0024VB_0024Local_RealResults.Count} 个（目前已有结果 {CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.Results.Count} 个）", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
				if (CS_0024_003C_003E8__locals175._0024VB_0024Local_RealResults.Count + CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.Results.Count >= CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.TargetResultCount)
				{
					break;
				}
				Logger.Info($"总结果数需求最少 {CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.TargetResultCount} 个，仅获得了 {CS_0024_003C_003E8__locals175._0024VB_0024Local_RealResults.Count + CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.Results.Count} 个", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
				if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.CanContinue && !CS_0024_003C_003E8__locals175._0024VB_0024Local_Errors.Any())
				{
					Logger.Info("将继续尝试加载下一页", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
					continue;
				}
				Logger.Info("无法继续加载，将强制结束", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Modules\\Resource\\ResourceSearcher.vb");
				break;
			}
			Dictionary<ResourceProject, double> dictionary2 = new Dictionary<ResourceProject, double>();
			VB_0024AnonymousDelegate_4<ResourceProject, double> obj3 = [SpecialName] (ResourceProject Project) =>
			{
				switch (CS_0024_003C_003E8__locals175._0024VB_0024Local_Request.Type)
				{
				case ResourceTypes.Mod:
				case ResourceTypes.ModPack:
					return (Project.Platform == ResourcePlatforms.CurseForge) ? 1 : 5;
				case ResourceTypes.DataPack:
					return (Project.Platform != ResourcePlatforms.CurseForge) ? 1 : 10;
				case ResourceTypes.ResourcePack:
				case ResourceTypes.Shader:
					return (Project.Platform == ResourcePlatforms.CurseForge) ? 1 : 4;
				default:
					return 1.0;
				}
			};
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals175._0024VB_0024Local_RawSearchText))
			{
				foreach (ResourceProject item9 in CS_0024_003C_003E8__locals175._0024VB_0024Local_RealResults)
				{
					dictionary2[item9] = (double)item9.DownloadCount * obj3(item9);
				}
			}
			else
			{
				List<ModBase.SearchEntry<ResourceProject>> list3 = new List<ModBase.SearchEntry<ResourceProject>>();
				foreach (ResourceProject item10 in CS_0024_003C_003E8__locals175._0024VB_0024Local_RealResults)
				{
					dictionary2[item10] = ((item10.WikiId > 0) ? 0.2 : 0.0) + Math.Log10((double)Math.Max(item10.DownloadCount, 1) * obj3(item10)) / 9.0;
					list3.Add(new ModBase.SearchEntry<ResourceProject>
					{
						Item = item10,
						SearchSource = new List<ModBase.SearchSource>
						{
							new ModBase.SearchSource((flag ? item10.TranslatedName : item10.RawName).Split('/', removeEmptyEntries: true)),
							new ModBase.SearchSource(item10.Description, 0.05)
						}
					});
				}
				List<ModBase.SearchEntry<ResourceProject>> list4 = ModBase.Search(list3, CS_0024_003C_003E8__locals175._0024VB_0024Local_RawSearchText, 10000, -1.0);
				foreach (ModBase.SearchEntry<ResourceProject> item11 in list4)
				{
					dictionary2[item11.Item] += (item11.AbsoluteRight ? 10.0 : item11.Similarity) / (list4.First().AbsoluteRight ? 10.0 : list4.First().Similarity);
				}
			}
			if (CS_0024_003C_003E8__locals175._0024VB_0024Local_Task.IsCanceled)
			{
				throw new OperationCanceledException();
			}
			CS_0024_003C_003E8__locals175._0024VB_0024Local_Storage.Results.AddRange(from r in dictionary2
				orderby r.Value descending
				select r.Key);
		}
	}
}
