using System;
using System.CodeDom.Compiler;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using MeloongCore;
using MeloongCore.Extensions;
using MeloongCore.Wpf;
using Microsoft.VisualBasic.CompilerServices;
using PCL.My;
using PCLCS;

namespace PCL;

[DesignerGenerated]
public partial class PageInstanceMod : MyPageRight, IRefreshable, IComponentConnector
{
	public enum FilterType
	{
		All,
		Enabled,
		Disabled,
		CanUpdate
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__12_002D0
	{
		public MyLocalModItem _0024VB_0024Local_NewItem;

		[SpecialName]
		internal void _Lambda_0024__R4(LocalResourceFile a0)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			ModBase.RunInUi(_0024VB_0024Local_NewItem.Refresh);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__14_002D0
	{
		public List<LocalResourceFile> _0024VB_0024Local_ShowingMods;

		public _Closure_0024__14_002D0(_Closure_0024__14_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_ShowingMods = arg0._0024VB_0024Local_ShowingMods;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__1(string m)
		{
			_Closure_0024__14_002D1 arg = default;
			_Closure_0024__14_002D1 CS_0024_003C_003E8__locals2 = new _Closure_0024__14_002D1(arg);
			CS_0024_003C_003E8__locals2._0024VB_0024Local_m = m;
			return _0024VB_0024Local_ShowingMods.Any([SpecialName] (LocalResourceFile s) => Operators.CompareString(s.EnabledName, CS_0024_003C_003E8__locals2._0024VB_0024Local_m, TextCompare: false) == 0);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__14_002D1
	{
		public string _0024VB_0024Local_m;

		public _Closure_0024__14_002D1(_Closure_0024__14_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_m = arg0._0024VB_0024Local_m;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__2(LocalResourceFile s)
		{
			return Operators.CompareString(s.EnabledName, _0024VB_0024Local_m, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	internal new sealed class _Closure_0024__20_002D0
	{
		public string _0024VB_0024Local_Extension;

		public _Closure_0024__20_002D0(_Closure_0024__20_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Extension = arg0._0024VB_0024Local_Extension;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(string t)
		{
			return Operators.CompareString(t, _0024VB_0024Local_Extension, TextCompare: false) == 0;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__36_002D0
	{
		public LocalResourceFile _0024VB_0024Local_ModEntity;

		public _Closure_0024__36_002D0(_Closure_0024__36_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_ModEntity = arg0._0024VB_0024Local_ModEntity;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(MyLocalModItem i)
		{
			return i.Entry == _0024VB_0024Local_ModEntity;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__39_002D0
	{
		public IEnumerable<LocalResourceFile> _0024VB_0024Local_ModList;

		public _Closure_0024__39_002D0(_Closure_0024__39_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_ModList = arg0._0024VB_0024Local_ModList;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__39_002D1
	{
		public Dictionary<string, string> _0024VB_0024Local_FileCopyList;

		public List<string> _0024VB_0024Local_FinishedFileNames;

		public ModLoader.LoaderCombo<IEnumerable<LocalResourceFile>> _0024VB_0024Local_Loader;

		public string _0024VB_0024Local_PathMods;

		public _Closure_0024__39_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public Action _0024I2;

		public _Closure_0024__39_002D1(_Closure_0024__39_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_FileCopyList = arg0._0024VB_0024Local_FileCopyList;
				_0024VB_0024Local_FinishedFileNames = arg0._0024VB_0024Local_FinishedFileNames;
				_0024VB_0024Local_Loader = arg0._0024VB_0024Local_Loader;
				_0024VB_0024Local_PathMods = arg0._0024VB_0024Local_PathMods;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R10(ModLoader.LoaderTask<int, int> a0)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			try
			{
				foreach (LocalResourceFile item in _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ModList)
				{
					if (FileUtils.Exists(item.File.FullName))
					{
						FileUtils.Delete(item.File.FullName, toRecycleBin: true);
					}
					else
					{
						Logger.Warn($"未找到更新前的 Mod 文件，跳过对它的删除：{item.File.FullName}", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
					}
				}
				foreach (KeyValuePair<string, string> item2 in _0024VB_0024Local_FileCopyList)
				{
					if (DirectoryUtils.Exists(PathUtils.RemoveLastPart(item2.Value)))
					{
						FileUtils.Move(item2.Key, item2.Value);
						_0024VB_0024Local_FinishedFileNames.Add(PathUtils.GetLastPart(item2.Value));
					}
					else
					{
						Logger.Warn($"更新后的目标文件夹已被删除：{item2.Value}", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
					}
				}
			}
			catch (OperationCanceledException ex)
			{
				ProjectData.SetProjectError(ex);
				OperationCanceledException ex2 = ex;
				Logger.Warn(ex2, "替换旧版 Mod 文件时被主动取消", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R11(ModLoader.LoaderBase a0)
		{
			_Lambda_0024__1();
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			switch (_0024VB_0024Local_Loader.State)
			{
			default:
				return;
			case ModBase.LoadState.Finished:
				switch (_0024VB_0024Local_FinishedFileNames.Count)
				{
				case 0:
					Logger.Info("没有 Mod 被成功更新", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
					break;
				case 1:
					ModMain.Hint($"已成功更新 {_0024VB_0024Local_FinishedFileNames.Single()}！", ModMain.HintType.Green);
					break;
				default:
					ModMain.Hint($"已成功更新 {_0024VB_0024Local_FinishedFileNames.Count} 个 Mod！", ModMain.HintType.Green);
					break;
				}
				break;
			case ModBase.LoadState.Failed:
				ModMain.Hint("Mod 更新失败：" + _0024VB_0024Local_Loader.Error.GetDisplay(multiline: false), ModMain.HintType.Red);
				break;
			case ModBase.LoadState.Canceled:
				ModMain.Hint("Mod 更新已中止！");
				break;
			}
			Logger.Info($"已从正在进行 Mod 更新的文件夹列表移除：{_0024VB_0024Local_PathMods}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
			UpdatingInstanceModFolders.Remove(_0024VB_0024Local_PathMods);
			ModBase.RunInNewThread([SpecialName] () =>
			{
				try
				{
					foreach (string key in _0024VB_0024Local_FileCopyList.Keys)
					{
						FileUtils.Delete(key);
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Logger.Warn(ex2, "清理 Mod 更新缓存失败", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
					ProjectData.ClearProjectError();
				}
			}, "Clean Mod Update Cache", ThreadPriority.BelowNormal);
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			try
			{
				foreach (string key in _0024VB_0024Local_FileCopyList.Keys)
				{
					FileUtils.Delete(key);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Logger.Warn(ex2, "清理 Mod 更新缓存失败", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__41_002D0
	{
		public LocalResourceFile _0024VB_0024Local_ModEntity;

		public _Closure_0024__41_002D0(_Closure_0024__41_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_ModEntity = arg0._0024VB_0024Local_ModEntity;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__3(MyLocalModItem i)
		{
			return i.Entry.Equals(_0024VB_0024Local_ModEntity);
		}
	}

	private bool IsLoad;

	public ConcurrentDictionary<string, MyLocalModItem> ModItems;

	private int BottomBarShownCount;

	public List<string> SelectedMods;

	private FilterType _Filter;

	public static List<string> UpdatingInstanceModFolders = new List<string>();

	private List<LocalResourceFile> SearchResult;

	public FilterType Filter
	{
		get
		{
			return _Filter;
		}
		set
		{
			if (_Filter != value)
			{
				_Filter = value;
				switch (value)
				{
				case FilterType.All:
					BtnFilterAll.Checked = true;
					break;
				case FilterType.Enabled:
					BtnFilterEnabled.Checked = true;
					break;
				case FilterType.Disabled:
					BtnFilterDisabled.Checked = true;
					break;
				default:
					BtnFilterCanUpdate.Checked = true;
					break;
				}
				RefreshUI();
			}
		}
	}

	public bool IsSearching => !string.IsNullOrWhiteSpace(SearchBox.Text);

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

	[field: AccessedThroughProperty("PanMain")]
	internal virtual StackPanel PanMain
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("SearchBox")]
	internal virtual MySearchBox SearchBox
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = SearchBox_PreviewKeyDown;
			MySearchBox.TextChangedEventHandler obj = [SpecialName] (object a0, EventArgs a1) =>
			{
				SearchRun();
			};
			MySearchBox mySearchBox = field;
			if (mySearchBox != null)
			{
				mySearchBox.PreviewKeyDown -= value2;
				mySearchBox.TextChanged -= obj;
			}
			field = value;
			mySearchBox = field;
			if (mySearchBox != null)
			{
				mySearchBox.PreviewKeyDown += value2;
				mySearchBox.TextChanged += obj;
			}
		}
	}

	[field: AccessedThroughProperty("PanManage")]
	internal virtual MyCard PanManage
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnManageOpen")]
	internal virtual MyButton BtnManageOpen
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageOpen_Click;
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

	[field: AccessedThroughProperty("BtnManageInstall")]
	internal virtual MyButton BtnManageInstall
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageInstall_Click;
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

	[field: AccessedThroughProperty("BtnManageDownload")]
	internal virtual MyButton BtnManageDownload
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageDownload_Click;
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

	[field: AccessedThroughProperty("BtnManageSelectAll")]
	internal virtual MyButton BtnManageSelectAll
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageSelectAll_Click;
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

	[field: AccessedThroughProperty("PanListBack")]
	internal virtual MyCard PanListBack
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanFilter")]
	internal virtual StackPanel PanFilter
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnFilterAll")]
	internal virtual MyRadioButton BtnFilterAll
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyRadioButton.CheckEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				ChangeFilter((MyRadioButton)a0, a1);
			};
			MyRadioButton myRadioButton = field;
			if (myRadioButton != null)
			{
				myRadioButton.Check -= obj;
			}
			field = value;
			myRadioButton = field;
			if (myRadioButton != null)
			{
				myRadioButton.Check += obj;
			}
		}
	}

	[field: AccessedThroughProperty("BtnFilterEnabled")]
	internal virtual MyRadioButton BtnFilterEnabled
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyRadioButton.CheckEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				ChangeFilter((MyRadioButton)a0, a1);
			};
			MyRadioButton myRadioButton = field;
			if (myRadioButton != null)
			{
				myRadioButton.Check -= obj;
			}
			field = value;
			myRadioButton = field;
			if (myRadioButton != null)
			{
				myRadioButton.Check += obj;
			}
		}
	}

	[field: AccessedThroughProperty("BtnFilterDisabled")]
	internal virtual MyRadioButton BtnFilterDisabled
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyRadioButton.CheckEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				ChangeFilter((MyRadioButton)a0, a1);
			};
			MyRadioButton myRadioButton = field;
			if (myRadioButton != null)
			{
				myRadioButton.Check -= obj;
			}
			field = value;
			myRadioButton = field;
			if (myRadioButton != null)
			{
				myRadioButton.Check += obj;
			}
		}
	}

	[field: AccessedThroughProperty("BtnFilterCanUpdate")]
	internal virtual MyRadioButton BtnFilterCanUpdate
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyRadioButton.CheckEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				ChangeFilter((MyRadioButton)a0, a1);
			};
			MyRadioButton myRadioButton = field;
			if (myRadioButton != null)
			{
				myRadioButton.Check -= obj;
			}
			field = value;
			myRadioButton = field;
			if (myRadioButton != null)
			{
				myRadioButton.Check += obj;
			}
		}
	}

	[field: AccessedThroughProperty("PanList")]
	internal virtual StackPanel PanList
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanEmpty")]
	internal virtual MyCard PanEmpty
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnHintDownload")]
	internal virtual MyButton BtnHintDownload
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageDownload_Click;
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

	[field: AccessedThroughProperty("BtnHintInstall")]
	internal virtual MyButton BtnHintInstall
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageInstall_Click;
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

	[field: AccessedThroughProperty("BtnHintOpen")]
	internal virtual MyButton BtnHintOpen
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageOpen_Click;
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

	[field: AccessedThroughProperty("PanLoad")]
	internal virtual MyCard PanLoad
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Load")]
	internal virtual MyLoading Load
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyLoading.ClickEventHandler obj = Load_Click;
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				UnselectedAllWithAnimation();
			};
			MyLoading myLoading = field;
			if (myLoading != null)
			{
				myLoading.Click -= obj;
				myLoading.StateChanged -= obj2;
			}
			field = value;
			myLoading = field;
			if (myLoading != null)
			{
				myLoading.Click += obj;
				myLoading.StateChanged += obj2;
			}
		}
	}

	[field: AccessedThroughProperty("CardSelect")]
	internal virtual MyCard CardSelect
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TransSelect")]
	internal virtual TranslateTransform TransSelect
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabSelect")]
	internal virtual TextBlock LabSelect
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnSelectUpdate")]
	internal virtual MyIconTextButton BtnSelectUpdate
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				BtnSelectUpdate_Click();
			};
			MyIconTextButton myIconTextButton = field;
			if (myIconTextButton != null)
			{
				myIconTextButton.Click -= obj;
			}
			field = value;
			myIconTextButton = field;
			if (myIconTextButton != null)
			{
				myIconTextButton.Click += obj;
			}
		}
	}

	[field: AccessedThroughProperty("BtnSelectEnable")]
	internal virtual MyIconTextButton BtnSelectEnable
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				BtnSelectED_Click((MyIconTextButton)a0, a1);
			};
			MyIconTextButton myIconTextButton = field;
			if (myIconTextButton != null)
			{
				myIconTextButton.Click -= obj;
			}
			field = value;
			myIconTextButton = field;
			if (myIconTextButton != null)
			{
				myIconTextButton.Click += obj;
			}
		}
	}

	[field: AccessedThroughProperty("BtnSelectDisable")]
	internal virtual MyIconTextButton BtnSelectDisable
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				BtnSelectED_Click((MyIconTextButton)a0, a1);
			};
			MyIconTextButton myIconTextButton = field;
			if (myIconTextButton != null)
			{
				myIconTextButton.Click -= obj;
			}
			field = value;
			myIconTextButton = field;
			if (myIconTextButton != null)
			{
				myIconTextButton.Click += obj;
			}
		}
	}

	[field: AccessedThroughProperty("BtnSelectDelete")]
	internal virtual MyIconTextButton BtnSelectDelete
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				BtnSelectDelete_Click();
			};
			MyIconTextButton myIconTextButton = field;
			if (myIconTextButton != null)
			{
				myIconTextButton.Click -= obj;
			}
			field = value;
			myIconTextButton = field;
			if (myIconTextButton != null)
			{
				myIconTextButton.Click += obj;
			}
		}
	}

	[field: AccessedThroughProperty("BtnSelectCancel")]
	internal virtual MyIconTextButton BtnSelectCancel
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				BtnSelectCancel_Click();
			};
			MyIconTextButton myIconTextButton = field;
			if (myIconTextButton != null)
			{
				myIconTextButton.Click -= obj;
			}
			field = value;
			myIconTextButton = field;
			if (myIconTextButton != null)
			{
				myIconTextButton.Click += obj;
			}
		}
	}

	public PageInstanceMod()
	{
		Loaded += [SpecialName] (object a0, RoutedEventArgs a1) =>
		{
			PageOther_Loaded();
		};
		Initialized += [SpecialName] (object a0, EventArgs a1) =>
		{
			LoaderInit();
		};
		PageExit += UnselectedAllWithAnimation;
		IsLoad = false;
		ModItems = new ConcurrentDictionary<string, MyLocalModItem>();
		BottomBarShownCount = 0;
		SelectedMods = new List<string>();
		_Filter = FilterType.All;
		InitializeComponent();
	}

	public void PageOther_Loaded()
	{
		if (ModMain.FrmMain.PageLast.Page != FormMain.PageType.ResourceDetail)
		{
			PanBack.ScrollToHome();
		}
		checked
		{
			ModAnimation.AniControlEnabled++;
			SelectedMods.Clear();
			ReloadModList();
			ChangeAllSelected(Value: false);
			ModAnimation.AniControlEnabled--;
			if (IsLoad)
			{
				return;
			}
			IsLoad = true;
			ModMain.FrmMain.KeyDown += FrmMain_KeyDown;
			foreach (MyRadioButton child in PanFilter.Children)
			{
				child.LabText.Margin = new Thickness(-2.0, 0.0, 8.0, 0.0);
			}
		}
	}

	public void ReloadModList(bool ForceReload = false)
	{
		if (LoaderRun(ForceReload ? ModLoader.LoaderFolderRunType.ForceRun : ModLoader.LoaderFolderRunType.RunOnUpdated))
		{
			Logger.Info("已刷新 Mod 列表", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
			Filter = FilterType.All;
			PanBack.ScrollToHome();
			SearchBox.Text = "";
		}
	}

	private void RefreshSelf()
	{
		Refresh();
	}

	void IRefreshable.Refresh()
	{
		//ILSpy generated this explicit interface implementation from .override directive in RefreshSelf
		this.RefreshSelf();
	}

	public static void Refresh()
	{
		try
		{
			ResourceProject.Cache.Clear();
			ResourceVersion.ProjectFilesCache.Clear();
			FileUtils.Delete(ModBase.PathTemp + "Cache\\LocalMod.json");
			Logger.Info("由于点击刷新按钮，清理本地 Mod 信息缓存", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Warn(ex2, "强制刷新时清理本地 Mod 信息缓存失败", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
			ProjectData.ClearProjectError();
		}
		if (ModMain.FrmInstanceMod != null)
		{
			ModMain.FrmInstanceMod.ReloadModList(ForceReload: true);
		}
		ModMain.FrmInstanceLeft.ItemMod.Checked = true;
		ModMain.Hint("正在刷新……", ModMain.HintType.Blue, Log: false);
	}

	private void LoaderInit()
	{
		PageLoaderInit(Load, PanLoad, PanAllBack, null, LocalResourceLoaders.LocalResourceLoader, [SpecialName] (ModLoader.LoaderTask<string, List<LocalResourceFile>> a0) =>
		{
			LoadUIFromLoaderOutput();
		}, null, AutoRun: false);
	}

	private void Load_Click(object sender, MouseButtonEventArgs e)
	{
		if (LocalResourceLoaders.LocalResourceLoader.State == ModBase.LoadState.Failed)
		{
			LoaderRun(ModLoader.LoaderFolderRunType.ForceRun);
		}
	}

	public bool LoaderRun(ModLoader.LoaderFolderRunType Type)
	{
		return ModLoader.LoaderFolderRun(LocalResourceLoaders.LocalResourceLoader, PageInstanceLeft.Instance.PathIndie + "mods\\", Type);
	}

	private void LoadUIFromLoaderOutput()
	{
		try
		{
			if (LocalResourceLoaders.LocalResourceLoader.Output.Any())
			{
				PanBack.Visibility = Visibility.Visible;
				PanEmpty.Visibility = Visibility.Collapsed;
				ModItems.Clear();
				foreach (LocalResourceFile item in LocalResourceLoaders.LocalResourceLoader.Output)
				{
					ModItems[item.EnabledName] = McModListItem(item);
				}
				Filter = FilterType.All;
				SearchBox.Text = "";
				RefreshUI();
			}
			else
			{
				PanEmpty.Visibility = Visibility.Visible;
				PanBack.Visibility = Visibility.Collapsed;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "加载 Mod 列表 UI 失败", LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
			ProjectData.ClearProjectError();
		}
	}

	private MyLocalModItem McModListItem(LocalResourceFile Entry)
	{
		_Closure_0024__12_002D0 CS_0024_003C_003E8__locals3 = new _Closure_0024__12_002D0();
		checked
		{
			ModAnimation.AniControlEnabled++;
			CS_0024_003C_003E8__locals3._0024VB_0024Local_NewItem = new MyLocalModItem
			{
				SnapsToDevicePixels = true,
				Entry = Entry,
				ButtonHandler = McModContent,
				Checked = SelectedMods.Contains(Entry.EnabledName)
			};
			Entry.OnUpdate += [SpecialName] (LocalResourceFile a0) =>
			{
				CS_0024_003C_003E8__locals3._Lambda_0024__0();
			};
			ModAnimation.AniControlEnabled--;
			return CS_0024_003C_003E8__locals3._0024VB_0024Local_NewItem;
		}
	}

	private void McModContent(MyLocalModItem sender, EventArgs e)
	{
		sender.Changed += [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
		{
			CheckChanged((MyLocalModItem)a0, a1);
		};
		sender.Click += [SpecialName] (object a0, MouseButtonEventArgs a1) =>
		{
			((VB_0024AnonymousDelegate_16<MyLocalModItem, EventArgs>)([SpecialName] (MyLocalModItem ss, EventArgs ee) =>
			{
				ss.Checked = !ss.Checked;
			}))((MyLocalModItem)a0, a1);
		};
		MyIconButton myIconButton = new MyIconButton
		{
			LogoScale = 1.05,
			Logo = "M889.018182 418.909091H884.363636V316.509091a93.090909 93.090909 0 0 0-99.607272-89.832727h-302.545455l-93.090909-76.334546A46.545455 46.545455 0 0 0 358.865455 139.636364H146.152727A93.090909 93.090909 0 0 0 46.545455 229.469091V837.818182a46.545455 46.545455 0 0 0 46.545454 46.545454 46.545455 46.545455 0 0 0 16.756364-3.258181 109.381818 109.381818 0 0 0 25.134545 3.258181h586.472727a85.178182 85.178182 0 0 0 87.04-63.301818l163.374546-302.545454a46.545455 46.545455 0 0 0 5.585454-21.876364A82.385455 82.385455 0 0 0 889.018182 418.909091z m-744.727273-186.181818h198.283636l93.09091 76.334545a46.545455 46.545455 0 0 0 29.323636 10.705455h319.301818a12.101818 12.101818 0 0 1 6.516364 0V418.909091H302.545455a85.178182 85.178182 0 0 0-87.04 63.301818L139.636364 622.778182V232.727273a19.549091 19.549091 0 0 1 6.516363 0z m578.094546 552.029091a27.461818 27.461818 0 0 0-2.792728 6.516363H154.530909l147.083636-272.290909a27.461818 27.461818 0 0 0 2.792728-6.981818h565.061818z",
			Tag = sender
		};
		myIconButton.ToolTip = "打开文件位置";
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			Open_Click((MyIconButton)a0, a1);
		};
		MyIconButton myIconButton2 = new MyIconButton
		{
			LogoScale = 1.0,
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z",
			Tag = sender
		};
		myIconButton2.ToolTip = "详情";
		myIconButton2.Click += Info_Click;
		sender.MouseRightButtonUp += Info_Click;
		MyIconButton myIconButton3 = new MyIconButton
		{
			LogoScale = 1.0,
			Logo = "M520.192 0C408.43 0 317.44 82.87 313.563 186.734H52.736c-29.038 0-52.663 21.943-52.663 49.079s23.625 49.152 52.663 49.152h58.075v550.473c0 103.35 75.118 187.757 167.717 187.757h472.43c92.599 0 167.716-83.894 167.716-187.757V285.477h52.59c29.038 0 52.59-21.943 52.663-49.08-0.073-27.135-23.625-49.151-52.663-49.151H726.235C723.237 83.017 631.955 0 520.192 0zM404.846 177.957c3.803-50.03 50.176-89.015 107.447-89.015 57.197 0 103.57 38.985 106.788 89.015H404.92zM284.379 933.669c-33.353 0-69.997-39.351-69.997-95.525v-549.01H833.39v549.522c0 56.247-36.645 95.525-69.998 95.525H284.379v-0.512z M357.23 800.695a48.274 48.274 0 0 0 47.616-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.69 49.006V751.69c0 27.282 20.846 49.006 47.617 49.006z m166.62 0a48.274 48.274 0 0 0 47.688-49.006V471.7a48.274 48.274 0 0 0-47.689-49.08 48.274 48.274 0 0 0-47.543 49.006V751.69c0 27.282 21.431 49.006 47.543 49.006z m142.92 0a48.274 48.274 0 0 0 47.543-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.616 49.006V751.69c0 27.282 20.773 49.006 47.543 49.006z",
			Tag = sender
		};
		myIconButton3.ToolTip = "删除";
		myIconButton3.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			Delete_Click((MyIconButton)a0, a1);
		};
		MyIconButton myIconButton4 = new MyIconButton
		{
			LogoScale = 1.0,
			Logo = (sender.Entry.IsEnabled ? "M508 990.4c-261.6 0-474.4-212-474.4-474.4S246.4 41.6 508 41.6s474.4 212 474.4 474.4S769.6 990.4 508 990.4zM508 136.8c-209.6 0-379.2 169.6-379.2 379.2 0 209.6 169.6 379.2 379.2 379.2s379.2-169.6 379.2-379.2C887.2 306.4 717.6 136.8 508 136.8zM697.6 563.2 318.4 563.2c-26.4 0-47.2-21.6-47.2-47.2 0-26.4 21.6-47.2 47.2-47.2l379.2 0c26.4 0 47.2 21.6 47.2 47.2C744.8 542.4 724 563.2 697.6 563.2z" : "M512 0a512 512 0 1 0 512 512A512 512 0 0 0 512 0z m0 921.6a409.6 409.6 0 1 1 409.6-409.6 409.6 409.6 0 0 1-409.6 409.6z M716.8 339.968l-256 253.44L328.192 460.8A51.2 51.2 0 0 0 256 532.992l168.448 168.96a51.2 51.2 0 0 0 72.704 0l289.28-289.792A51.2 51.2 0 0 0 716.8 339.968z"),
			Tag = sender
		};
		myIconButton4.ToolTip = (sender.Entry.IsEnabled ? "禁用" : "启用");
		myIconButton4.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			ED_Click((MyIconButton)a0, a1);
		};
		sender.Buttons = new MyIconButton[4] { myIconButton2, myIconButton, myIconButton4, myIconButton3 };
	}

	public void RefreshUI()
	{
		_Closure_0024__14_002D0 arg = default;
		_Closure_0024__14_002D0 CS_0024_003C_003E8__locals6 = new _Closure_0024__14_002D0(arg);
		if (PanList == null)
		{
			return;
		}
		CS_0024_003C_003E8__locals6._0024VB_0024Local_ShowingMods = (IsSearching ? SearchResult : (LocalResourceLoaders.LocalResourceLoader.Output ?? new List<LocalResourceFile>())).Where([SpecialName] (LocalResourceFile m) => CanPassFilter(m)).ToList();
		checked
		{
			ModAnimation.AniControlEnabled++;
			if (CS_0024_003C_003E8__locals6._0024VB_0024Local_ShowingMods.Any())
			{
				PanList.Visibility = Visibility.Visible;
				PanList.Children.Clear();
				foreach (LocalResourceFile item in CS_0024_003C_003E8__locals6._0024VB_0024Local_ShowingMods)
				{
					MyLocalModItem value = null;
					if (ModItems.TryGetValue(item.EnabledName, out value))
					{
						value.Checked = SelectedMods.Contains(item.EnabledName);
						PanList.Children.Add(value);
					}
				}
			}
			else
			{
				PanList.Visibility = Visibility.Collapsed;
			}
			ModAnimation.AniControlEnabled--;
			SelectedMods = SelectedMods.Where([SpecialName] (string m) =>
			{
				_Closure_0024__14_002D1 arg2 = default;
				_Closure_0024__14_002D1 CS_0024_003C_003E8__locals7 = new _Closure_0024__14_002D1(arg2);
				CS_0024_003C_003E8__locals7._0024VB_0024Local_m = m;
				return CS_0024_003C_003E8__locals6._0024VB_0024Local_ShowingMods.Any([SpecialName] (LocalResourceFile s) => Operators.CompareString(s.EnabledName, CS_0024_003C_003E8__locals7._0024VB_0024Local_m, TextCompare: false) == 0);
			}).ToList();
			RefreshBars();
		}
	}

	public void RefreshBars()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		checked
		{
			foreach (LocalResourceFile item in IsSearching ? SearchResult : (LocalResourceLoaders.LocalResourceLoader.Output ?? new List<LocalResourceFile>()))
			{
				num++;
				if (item.HasUpdate)
				{
					num3++;
				}
				if (item.IsEnabled)
				{
					num2++;
				}
			}
			int num4 = num - num2;
			BtnFilterAll.Text = (IsSearching ? "搜索结果" : "全部") + $" ({num})";
			BtnFilterCanUpdate.Text = $"可更新 ({num3})";
			BtnFilterCanUpdate.Visibility = ((Filter != FilterType.CanUpdate && num3 <= 0) ? Visibility.Collapsed : Visibility.Visible);
			BtnFilterEnabled.Text = $"启用 ({num2})";
			BtnFilterEnabled.Visibility = ((Filter != FilterType.Enabled && (num2 <= 0 || num2 >= num)) ? Visibility.Collapsed : Visibility.Visible);
			BtnFilterDisabled.Text = $"禁用 ({num4})";
			BtnFilterDisabled.Visibility = ((Filter != FilterType.Disabled && num4 <= 0) ? Visibility.Collapsed : Visibility.Visible);
			int count = SelectedMods.Count;
			bool flag = count > 0;
			if (flag)
			{
				LabSelect.Text = $"已选择 {count} 个文件";
			}
			if (flag)
			{
				bool isEnabled = false;
				bool isEnabled2 = false;
				bool isEnabled3 = false;
				foreach (LocalResourceFile item2 in LocalResourceLoaders.LocalResourceLoader.Output)
				{
					if (SelectedMods.Contains(item2.EnabledName))
					{
						if (item2.HasUpdate)
						{
							isEnabled = true;
						}
						if (item2.IsEnabled)
						{
							isEnabled2 = true;
						}
						if (!item2.IsEnabled)
						{
							isEnabled3 = true;
						}
					}
				}
				BtnSelectDisable.IsEnabled = isEnabled2;
				BtnSelectEnable.IsEnabled = isEnabled3;
				BtnSelectUpdate.IsEnabled = isEnabled;
			}
			if (ModAnimation.AniControlEnabled == 0)
			{
				PanListBack.Margin = new Thickness(0.0, 0.0, 0.0, flag ? 95 : 15);
				if (flag)
				{
					if (BottomBarShownCount >= count)
					{
						BottomBarShownCount = count;
						return;
					}
					BottomBarShownCount = count;
					CardSelect.Visibility = Visibility.Visible;
					ModAnimation.AniStart(new ModAnimation.AniData[4]
					{
						ModAnimation.AaOpacity(CardSelect, 1.0 - CardSelect.Opacity, 60),
						ModAnimation.AaTranslateY(CardSelect, -27.0 - TransSelect.Y, 120, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)),
						ModAnimation.AaTranslateY(CardSelect, 3.0, 150, 120, new ModAnimation.AniEaseInoutFluent(ModAnimation.AniEasePower.Weak)),
						ModAnimation.AaTranslateY(CardSelect, -1.0, 90, 270, new ModAnimation.AniEaseInoutFluent(ModAnimation.AniEasePower.Weak))
					}, "Mod Sidebar");
				}
				else if (BottomBarShownCount != 0)
				{
					BottomBarShownCount = 0;
					ModAnimation.AniStart(new ModAnimation.AniData[3]
					{
						ModAnimation.AaOpacity(CardSelect, 0.0 - CardSelect.Opacity, 90),
						ModAnimation.AaTranslateY(CardSelect, -10.0 - TransSelect.Y, 90, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak)),
						ModAnimation.AaCode([SpecialName] () =>
						{
							CardSelect.Visibility = Visibility.Collapsed;
						}, 0, After: true)
					}, "Mod Sidebar");
				}
			}
			else
			{
				ModAnimation.AniStop("Mod Sidebar");
				BottomBarShownCount = count;
				if (flag)
				{
					CardSelect.Visibility = Visibility.Visible;
					CardSelect.Opacity = 1.0;
					TransSelect.Y = -25.0;
				}
				else
				{
					CardSelect.Visibility = Visibility.Collapsed;
					CardSelect.Opacity = 0.0;
					TransSelect.Y = -10.0;
				}
			}
		}
	}

	private void BtnManageOpen_Click(object sender, EventArgs e)
	{
		try
		{
			DirectoryUtils.Create(PageInstanceLeft.Instance.PathIndie + "mods\\");
			ModBase.OpenExplorer(PageInstanceLeft.Instance.PathIndie + "mods\\");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "打开 Mods 文件夹失败", LogBehavior.Alert, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
			ProjectData.ClearProjectError();
		}
	}

	private void BtnManageSelectAll_Click(object sender, MouseButtonEventArgs e)
	{
		ChangeAllSelected(SelectedMods.Count < PanList.Children.Count);
	}

	private void BtnManageInstall_Click(object sender, MouseButtonEventArgs e)
	{
		List<string> list = Dialogs.SelectFile("选择要安装的 Mod", multiselect: true, null, new (string[], string)[1] { (new string[4] { "jar", "litemod", "disabled", "old" }, "Mod 文件") });
		if (list.Any())
		{
			InstallMods(list);
		}
	}

	public static bool InstallMods(IEnumerable<string> FilePathList)
	{
		_Closure_0024__20_002D0 arg = default;
		_Closure_0024__20_002D0 CS_0024_003C_003E8__locals2 = new _Closure_0024__20_002D0(arg);
		CS_0024_003C_003E8__locals2._0024VB_0024Local_Extension = PathUtils.GetExtension(FilePathList.First());
		if (!new string[4] { "jar", "litemod", "disabled", "old" }.Any([SpecialName] (string t) => Operators.CompareString(t, CS_0024_003C_003E8__locals2._0024VB_0024Local_Extension, TextCompare: false) == 0))
		{
			return false;
		}
		Logger.Info("文件为 jar/litemod 格式，尝试作为 Mod 安装", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
		if (FilePathList.First().Contains(":\\$RECYCLE.BIN\\"))
		{
			ModMain.Hint("请先将文件从回收站还原，再尝试安装！", ModMain.HintType.Red);
			return true;
		}
		ModMinecraft.McInstance mcInstance = ModMinecraft.McInstanceSelected;
		if (ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSetup)
		{
			mcInstance = PageInstanceLeft.Instance;
		}
		if (ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSelect || (object)mcInstance == null || !mcInstance.Modable)
		{
			ModMain.Hint("若要安装 Mod，请先选择一个可以安装 Mod 的版本！");
		}
		else if ((ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSetup && ModMain.FrmMain.PageCurrentSub == FormMain.PageSubType.DownloadPack) || ModMain.MyMsgBox(string.Format("是否要将这{0}文件作为 Mod 安装到 {1}？", FilePathList.IsSingle() ? "个" : "些", mcInstance.Name), "Mod 安装确认", "确定", "取消") == 1)
		{
			try
			{
				foreach (string FilePath in FilePathList)
				{
					string text = new LocalResourceFile(FilePath).EnabledName;
					if (!text.Contains("."))
					{
						text += ".jar";
					}
					text = mcInstance.PathIndie + "mods\\" + text;
					if (!PathUtils.IsSame(FilePath, text))
					{
						FileUtils.Delete(text, toRecycleBin: true);
						FileUtils.Copy(FilePath, text);
					}
				}
				if (FilePathList.IsSingle())
				{
					ModMain.Hint($"已安装 {new LocalResourceFile(FilePathList.First()).EnabledName}！", ModMain.HintType.Green);
				}
				else
				{
					ModMain.Hint($"已安装 {FilePathList.Count()} 个 Mod！", ModMain.HintType.Green);
				}
				if (ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSetup && ModMain.FrmMain.PageCurrentSub == FormMain.PageSubType.DownloadPack)
				{
					ModLoader.LoaderFolderRun(LocalResourceLoaders.LocalResourceLoader, mcInstance.PathIndie + "mods\\", ModLoader.LoaderFolderRunType.ForceRun);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Logger.Error(ex2, "复制 Mod 文件失败", LogBehavior.Alert, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
				ProjectData.ClearProjectError();
			}
		}
		return true;
	}

	private void BtnManageDownload_Click(object sender, MouseButtonEventArgs e)
	{
		PageResource.TargetInstance = PageInstanceLeft.Instance;
		PageResource.TargetName = SearchBox.Text;
		ModMain.FrmMain.PageChange(FormMain.PageType.Download, FormMain.PageSubType.DownloadMod);
	}

	public void CheckChanged(MyLocalModItem sender, ModBase.RouteEventArgs e)
	{
		if (ModAnimation.AniControlEnabled != 0)
		{
			return;
		}
		string enabledName = sender.Entry.EnabledName;
		if (sender.Checked)
		{
			if (!SelectedMods.Contains(enabledName))
			{
				SelectedMods.Add(enabledName);
			}
		}
		else
		{
			SelectedMods.Remove(enabledName);
		}
		RefreshBars();
	}

	private void ChangeAllSelected(bool Value)
	{
		checked
		{
			ModAnimation.AniControlEnabled++;
			SelectedMods.Clear();
			foreach (MyLocalModItem value in ModItems.Values)
			{
				if (value.Checked = Value && PanList.Children.Contains(value))
				{
					SelectedMods.Add(value.Entry.EnabledName);
				}
			}
			ModAnimation.AniControlEnabled--;
			RefreshBars();
		}
	}

	private void UnselectedAllWithAnimation()
	{
		int aniControlEnabled = ModAnimation.AniControlEnabled;
		ModAnimation.AniControlEnabled = 0;
		ChangeAllSelected(Value: false);
		checked
		{
			ModAnimation.AniControlEnabled += aniControlEnabled;
		}
	}

	private void FrmMain_KeyDown(object sender, KeyEventArgs e)
	{
		if (ModMain.FrmMain.PageRight == this && MyWpfExtension.Computer.Keyboard.CtrlKeyDown && e.Key == Key.A)
		{
			ChangeAllSelected(Value: true);
		}
	}

	private void SearchBox_PreviewKeyDown(object sender, KeyEventArgs e)
	{
		if (!SearchBox.Text.Any() && MyWpfExtension.Computer.Keyboard.CtrlKeyDown && e.Key == Key.A)
		{
			PanBack.Focus();
		}
	}

	private bool CanPassFilter(LocalResourceFile CheckingMod)
	{
		return Filter switch
		{
			FilterType.All => true, 
			FilterType.Enabled => CheckingMod.IsEnabled, 
			FilterType.Disabled => !CheckingMod.IsEnabled, 
			FilterType.CanUpdate => CheckingMod.HasUpdate, 
			_ => false, 
		};
	}

	private void ChangeFilter(MyRadioButton sender, bool raiseByMouse)
	{
		Filter = (FilterType)Conversions.ToInteger(sender.Tag);
		RefreshUI();
	}

	private void BtnSelectED_Click(MyIconTextButton sender, ModBase.RouteEventArgs e)
	{
		EDMods(LocalResourceLoaders.LocalResourceLoader.Output.Where([SpecialName] (LocalResourceFile m) => SelectedMods.Contains(m.EnabledName)), !sender.Equals(BtnSelectDisable));
		ChangeAllSelected(Value: false);
	}

	private void EDMods(IEnumerable<LocalResourceFile> ModList, bool IsEnable)
	{
		bool flag = true;
		_Closure_0024__36_002D0 obj = default;
		foreach (LocalResourceFile item in ModList.ToList())
		{
			obj = new _Closure_0024__36_002D0(obj);
			obj._0024VB_0024Local_ModEntity = item;
			string text = null;
			if (obj._0024VB_0024Local_ModEntity.IsEnabled && !IsEnable)
			{
				text = PathUtils.RemoveExtendedPrefix(obj._0024VB_0024Local_ModEntity.File.FullName) + (FileUtils.Exists(obj._0024VB_0024Local_ModEntity.File.FullName + ".old") ? ".old" : ".disabled");
			}
			else
			{
				if (obj._0024VB_0024Local_ModEntity.IsEnabled || !IsEnable)
				{
					continue;
				}
				text = obj._0024VB_0024Local_ModEntity.EnabledFullName;
			}
			try
			{
				if (!FileUtils.Exists(text))
				{
					goto IL_0189;
				}
				if (FileUtils.Exists(obj._0024VB_0024Local_ModEntity.File.FullName))
				{
					if (Operators.CompareString(CryptographyUtils.ComputeFileHash(obj._0024VB_0024Local_ModEntity.File.FullName), CryptographyUtils.ComputeFileHash(text), TextCompare: false) == 0)
					{
						goto IL_0189;
					}
					ModMain.MyMsgBox(string.Format("目前同时存在启用和禁用的两个 Mod 文件：{0} - {1}{2} - {3}{4}{5}注意，这两个文件的内容并不相同。{6}在手动删除或重命名其中一个文件后，才能继续操作。", "\r\n", PathUtils.GetLastPart(text), "\r\n", obj._0024VB_0024Local_ModEntity.File.Name, "\r\n", "\r\n", "\r\n"), "存在文件冲突");
				}
				else
				{
					Logger.Warn("Mod 的状态已被切换", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
				}
				goto end_IL_00ab;
				IL_0189:
				FileUtils.Move(obj._0024VB_0024Local_ModEntity.File.FullName, text);
				goto IL_0230;
				end_IL_00ab:;
			}
			catch (FileNotFoundException ex)
			{
				ProjectData.SetProjectError(ex);
				FileNotFoundException ex2 = ex;
				Logger.Error(ex2, string.Format("未找到需要重命名的 Mod（{0}）", obj._0024VB_0024Local_ModEntity.File.FullName ?? "null"), LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
				ReloadModList(ForceReload: true);
				ProjectData.ClearProjectError();
				return;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				Logger.Warn(ex4, string.Format("重命名 Mod 失败（{0}）", obj._0024VB_0024Local_ModEntity.File.FullName ?? "null"), LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
				flag = false;
				ProjectData.ClearProjectError();
				goto IL_0230;
			}
			continue;
			IL_0230:
			LocalResourceFile localResourceFile = new LocalResourceFile(text);
			localResourceFile.FromJson(obj._0024VB_0024Local_ModEntity.ToJson());
			if (LocalResourceLoaders.LocalResourceLoader.Output.Contains(obj._0024VB_0024Local_ModEntity))
			{
				int index = LocalResourceLoaders.LocalResourceLoader.Output.IndexOf(obj._0024VB_0024Local_ModEntity);
				LocalResourceLoaders.LocalResourceLoader.Output.RemoveAt(index);
				LocalResourceLoaders.LocalResourceLoader.Output.Insert(index, localResourceFile);
			}
			if (SearchResult != null && SearchResult.Contains(obj._0024VB_0024Local_ModEntity))
			{
				int index2 = SearchResult.IndexOf(obj._0024VB_0024Local_ModEntity);
				SearchResult.Remove(obj._0024VB_0024Local_ModEntity);
				SearchResult.Insert(index2, localResourceFile);
			}
			MyLocalModItem myLocalModItem = McModListItem(localResourceFile);
			ModItems[obj._0024VB_0024Local_ModEntity.EnabledName] = myLocalModItem;
			int num = PanList.Children.IndexOf(PanList.Children.OfType<MyLocalModItem>().FirstOrDefault(obj._Lambda_0024__0));
			if (num != -1)
			{
				PanList.Children.RemoveAt(num);
				PanList.Children.Insert(num, myLocalModItem);
				myLocalModItem.UpdateLayout();
			}
		}
		if (flag)
		{
			RefreshBars();
		}
		else
		{
			ModMain.Hint("由于文件被占用，Mod 的状态切换失败，请尝试关闭正在运行的游戏后再试！", ModMain.HintType.Red);
			ReloadModList(ForceReload: true);
		}
		LoaderRun(ModLoader.LoaderFolderRunType.UpdateOnly);
	}

	private void BtnSelectUpdate_Click()
	{
		List<LocalResourceFile> list = LocalResourceLoaders.LocalResourceLoader.Output.Where([SpecialName] (LocalResourceFile m) => SelectedMods.Contains(m.EnabledName) && m.HasUpdate).ToList();
		if (list.Any())
		{
			UpdateMods(list);
			ChangeAllSelected(Value: false);
		}
	}

	public void UpdateMods(IEnumerable<LocalResourceFile> ModList)
	{
		_Closure_0024__39_002D0 obj = new _Closure_0024__39_002D0(default);
		obj._0024VB_0024Local_ModList = ModList;
		if (!Settings.Get<bool>("HintUpdateMod") || obj._0024VB_0024Local_ModList.Count() >= 15)
		{
			if (ModMain.MyMsgBox(string.Format("新版本 Mod 可能不兼容旧存档或者其他 Mod，这可能导致游戏崩溃，甚至永久损坏存档！{0}如果你在游玩整合包，请千万不要自行更新 Mod！{1}{2}在更新前，请先备份存档，并检查 Mod 的更新日志。{3}如果更新后出现问题，你也可以在回收站找回更新前的 Mod。", "\r\n", "\r\n", "\r\n", "\r\n"), "Mod 更新警告", "我已了解风险，继续更新", "取消", "", IsWarn: true) != 1)
			{
				return;
			}
			Settings.Set("HintUpdateMod", true);
		}
		checked
		{
			try
			{
				_Closure_0024__39_002D1 arg = default;
				_Closure_0024__39_002D1 CS_0024_003C_003E8__locals18 = new _Closure_0024__39_002D1(arg);
				CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_2 = obj;
				CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ModList = CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ModList.ToList();
				List<ModNet.NetFile> list = new List<ModNet.NetFile>();
				CS_0024_003C_003E8__locals18._0024VB_0024Local_FileCopyList = new Dictionary<string, string>();
				foreach (LocalResourceFile item in CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ModList)
				{
					ResourceVersion updateFile = item.UpdateFile;
					if (updateFile.DownloadAvailable)
					{
						string text = PathUtils.GetFileNameWithoutExtension(item.ProjectVersion.FileName);
						string text2 = PathUtils.GetFileNameWithoutExtension(item.UpdateFile.FileName);
						List<string> list2 = text.Split('-').ToList();
						List<string> list3 = text2.Split('-').ToList();
						bool flag = false;
						while (list2.Any() && list3.Any() && Operators.CompareString(list2.First(), list3.First(), TextCompare: false) == 0)
						{
							list2.RemoveAt(0);
							list3.RemoveAt(0);
							flag = true;
						}
						while (list2.Any() && list3.Any() && Operators.CompareString(list2.Last(), list3.Last(), TextCompare: false) == 0)
						{
							list2.RemoveAt(list2.Count - 1);
							list3.RemoveAt(list3.Count - 1);
							flag = true;
						}
						if (flag && list2.Any() && list3.Any())
						{
							text = list2.Join("-");
							text2 = list3.Join("-");
						}
						string text3 = ModBase.PathTemp + "mods\\" + item.File.Name.Replace(text, text2);
						string value = Path.Combine(PathUtils.RemoveLastPart(item.File.FullName), item.File.Name.Replace(text, text2));
						list.Add(updateFile.ToNetFile(text3, ResourceVersion.DownloadReason.Update, PageInstanceLeft.Instance.Version.VanillaName, PageInstanceLeft.Instance.Version.ModLoaders));
						CS_0024_003C_003E8__locals18._0024VB_0024Local_FileCopyList[text3] = value;
					}
				}
				List<ModLoader.LoaderBase> list4 = new List<ModLoader.LoaderBase>();
				CS_0024_003C_003E8__locals18._0024VB_0024Local_FinishedFileNames = new List<string>();
				list4.Add(new ModNet.LoaderDownload("下载新版 Mod 文件", list)
				{
					ProgressWeight = (double)CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ModList.Count() * 1.5
				});
				list4.Add(new ModLoader.LoaderTask<int, int>("替换旧版 Mod 文件", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					CS_0024_003C_003E8__locals18._Lambda_0024__0();
				}));
				CS_0024_003C_003E8__locals18._0024VB_0024Local_Loader = new ModLoader.LoaderCombo<IEnumerable<LocalResourceFile>>("Mod 更新：" + PageInstanceLeft.Instance.Name, list4);
				CS_0024_003C_003E8__locals18._0024VB_0024Local_PathMods = PageInstanceLeft.Instance.PathIndie + "mods\\";
				CS_0024_003C_003E8__locals18._0024VB_0024Local_Loader.OnStateChanged = [SpecialName] (ModLoader.LoaderBase a0) =>
				{
					CS_0024_003C_003E8__locals18._Lambda_0024__1();
				};
				Logger.Info(string.Format("开始更新 {0} 个 Mod：{1}", CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ModList.Count(), CS_0024_003C_003E8__locals18._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ModList.Select([SpecialName] (LocalResourceFile m) => m.File.Name).Join("，")), LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
				UpdatingInstanceModFolders.Add(CS_0024_003C_003E8__locals18._0024VB_0024Local_PathMods);
				CS_0024_003C_003E8__locals18._0024VB_0024Local_Loader.Start();
				ModLoader.LoaderTaskbarAdd(CS_0024_003C_003E8__locals18._0024VB_0024Local_Loader);
				ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
				ModMain.FrmMain.BtnExtraDownload.Ribble();
				ReloadModList(ForceReload: true);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Logger.Warn(ex2, "初始化 Mod 更新失败", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
				ProjectData.ClearProjectError();
			}
		}
	}

	private void BtnSelectDelete_Click()
	{
		DeleteMods(LocalResourceLoaders.LocalResourceLoader.Output.Where([SpecialName] (LocalResourceFile m) => SelectedMods.Contains(m.EnabledName)));
		ChangeAllSelected(Value: false);
	}

	private void DeleteMods(IEnumerable<LocalResourceFile> ModsToDelete)
	{
		try
		{
			bool flag = true;
			bool shiftKeyDown = MyWpfExtension.Computer.Keyboard.ShiftKeyDown;
			List<LocalResourceFile> list = (from m in ModsToDelete.SelectMany([SpecialName] (LocalResourceFile Target) => Target.IsEnabled ? new string[2]
				{
					Target.File.FullName,
					Target.File.FullName + (FileUtils.Exists(Target.File.FullName + ".old") ? ".old" : ".disabled")
				} : new string[2]
				{
					Target.File.FullName,
					Target.EnabledFullName
				}).Distinct()
				where FileUtils.Exists(m)
				select new LocalResourceFile(m)).ToList();
			using (List<LocalResourceFile>.Enumerator enumerator = list.GetEnumerator())
			{
				_Closure_0024__41_002D0 obj = default;
				while (enumerator.MoveNext())
				{
					obj = new _Closure_0024__41_002D0(obj);
					obj._0024VB_0024Local_ModEntity = enumerator.Current;
					try
					{
						FileUtils.Delete(obj._0024VB_0024Local_ModEntity.File.FullName, !shiftKeyDown);
					}
					catch (OperationCanceledException ex)
					{
						ProjectData.SetProjectError(ex);
						OperationCanceledException ex2 = ex;
						Logger.Warn(ex2, "删除 Mod 被主动取消", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
						ReloadModList(ForceReload: true);
						ProjectData.ClearProjectError();
						return;
					}
					catch (Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						Exception ex4 = ex3;
						Logger.Error(ex4, $"删除 Mod 失败（{obj._0024VB_0024Local_ModEntity.File.FullName}）", LogBehavior.Alert, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
						flag = false;
						ProjectData.ClearProjectError();
					}
					SelectedMods.Remove(obj._0024VB_0024Local_ModEntity.EnabledName);
					LocalResourceLoaders.LocalResourceLoader.Output.Remove(obj._0024VB_0024Local_ModEntity);
					SearchResult?.Remove(obj._0024VB_0024Local_ModEntity);
					ModItems.Remove(obj._0024VB_0024Local_ModEntity.EnabledName);
					int num = PanList.Children.IndexOf(PanList.Children.OfType<MyLocalModItem>().FirstOrDefault(obj._Lambda_0024__3));
					if (num >= 0)
					{
						PanList.Children.RemoveAt(num);
					}
				}
			}
			RefreshBars();
			if (!flag)
			{
				ModMain.Hint("由于文件被占用，Mod 删除失败，请尝试关闭正在运行的游戏后再试！", ModMain.HintType.Red);
				ReloadModList(ForceReload: true);
			}
			else if (PanList.Children.Count == 0)
			{
				ReloadModList(ForceReload: true);
			}
			else
			{
				RefreshBars();
			}
			if (!flag)
			{
				return;
			}
			if (list.IsSingle())
			{
				ModMain.Hint($"已删除 {list.Single().File.Name}！", ModMain.HintType.Green);
			}
			else
			{
				ModMain.Hint($"已删除 {list.Count} 个文件！", ModMain.HintType.Green);
			}
		}
		catch (OperationCanceledException ex5)
		{
			ProjectData.SetProjectError(ex5);
			OperationCanceledException ex6 = ex5;
			Logger.Warn(ex6, "删除 Mod 被主动取消", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
			ReloadModList(ForceReload: true);
			ProjectData.ClearProjectError();
		}
		catch (Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			Exception ex8 = ex7;
			Logger.Error(ex8, "删除 Mod 出现未知错误", LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
			ReloadModList(ForceReload: true);
			ProjectData.ClearProjectError();
		}
		LoaderRun(ModLoader.LoaderFolderRunType.UpdateOnly);
	}

	private void BtnSelectCancel_Click()
	{
		ChangeAllSelected(Value: false);
	}

	public void Info_Click(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				LocalResourceFile entry = ((MyLocalModItem)((sender is MyIconButton) ? NewLateBinding.LateGet(sender, null, "Tag", new object[0], null, null, null) : sender)).Entry;
				if ((object)entry.Project != null)
				{
					ModMain.FrmMain.PageChange(new FormMain.PageStackData
					{
						Page = FormMain.PageType.ResourceDetail,
						Additional = new object[5]
						{
							entry.Project,
							new List<string>(),
							PageInstanceLeft.Instance.Version.VanillaName,
							PageInstanceLeft.Instance.Version.ModLoaders,
							ResourceTypes.Mod
						}
					});
					return;
				}
				List<string> list = new List<string>();
				if (entry.Description != null)
				{
					list.Add(entry.Description + "\r\n");
				}
				list.Add("文件：" + entry.File.Name + "（" + StringUtils.FormatByteSize(entry.File.Length) + "）");
				if (entry.Version != null)
				{
					list.Add("版本：" + entry.Version);
				}
				List<string> list2 = new List<string>();
				if (list2.Any())
				{
					list.Add("");
					list.AddRange(list2);
				}
				string text = entry.Display.Replace(" ", "+");
				string text2 = text.Substring(0, 1);
				int num = text.Count() - 1;
				for (int i = 1; i <= num; i++)
				{
					bool flag = text[i - 1].ToString().Lower().Equals(text[i - 1].ToString());
					bool flag2 = text[i].ToString().Lower().Equals(text[i].ToString());
					if (flag && !flag2)
					{
						text2 += "+";
					}
					text2 += Conversions.ToString(text[i]);
				}
				text2 = text2.Replace("++", "+").Replace("pti+Fine", "ptiFine");
				if (ModMain.MyMsgBox(list.Join("\r\n"), entry.Display, "百科搜索", "返回") == 1)
				{
					ModBase.OpenWebsite("https://www.mcmod.cn/s?key=" + text2 + "&site=all&filter=0");
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Logger.Error(ex2, "获取 Mod 详情失败", LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
				ProjectData.ClearProjectError();
			}
		}
	}

	public void Open_Click(MyIconButton sender, EventArgs e)
	{
		try
		{
			ModBase.OpenExplorer(((MyLocalModItem)sender.Tag).Entry.File.FullName);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "打开 Mod 文件位置失败", LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageInstance\\PageInstanceMod.xaml.vb");
			ProjectData.ClearProjectError();
		}
	}

	public void Delete_Click(MyIconButton sender, EventArgs e)
	{
		MyLocalModItem myLocalModItem = (MyLocalModItem)sender.Tag;
		DeleteMods(new LocalResourceFile[1] { myLocalModItem.Entry });
	}

	public void ED_Click(MyIconButton sender, EventArgs e)
	{
		MyLocalModItem myLocalModItem = (MyLocalModItem)sender.Tag;
		EDMods(new LocalResourceFile[1] { myLocalModItem.Entry }, !myLocalModItem.Entry.IsEnabled);
	}

	public void SearchRun()
	{
		if (IsSearching)
		{
			List<ModBase.SearchEntry<LocalResourceFile>> list = new List<ModBase.SearchEntry<LocalResourceFile>>();
			foreach (LocalResourceFile item in LocalResourceLoaders.LocalResourceLoader.Output)
			{
				List<ModBase.SearchSource> list2 = new List<ModBase.SearchSource>();
				list2.Add(new ModBase.SearchSource(item.Display));
				list2.Add(new ModBase.SearchSource(item.File.Name));
				if (item.Version != null)
				{
					list2.Add(new ModBase.SearchSource(item.Version, 0.2));
				}
				if (item.Description != null && Operators.CompareString(item.Description, "", TextCompare: false) != 0)
				{
					list2.Add(new ModBase.SearchSource(item.Description, 0.4));
				}
				if ((object)item.Project != null)
				{
					if (Operators.CompareString(item.Project.RawName, item.Display, TextCompare: false) != 0)
					{
						list2.Add(new ModBase.SearchSource(item.Project.RawName));
					}
					if (Operators.CompareString(item.Project.TranslatedName, item.Project.RawName, TextCompare: false) != 0)
					{
						list2.Add(new ModBase.SearchSource(item.Project.TranslatedName));
					}
					if (Operators.CompareString(item.Project.Description, item.Description, TextCompare: false) != 0)
					{
						list2.Add(new ModBase.SearchSource(item.Project.Description, 0.4));
					}
					list2.Add(new ModBase.SearchSource(string.Join("", item.Project.Tags), 0.2));
				}
				list.Add(new ModBase.SearchEntry<LocalResourceFile>
				{
					Item = item,
					SearchSource = list2
				});
			}
			SearchResult = (from r in ModBase.Search(list, SearchBox.Text, 6, 0.35)
				select r.Item).ToList();
		}
		RefreshUI();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
