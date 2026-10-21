using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using MeloongCore;
using MeloongCore.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageSetupSystem : MyPageRight, IComponentConnector
{
	[SpecialName]
	private bool _0024STATIC_0024PageSetupSystem_Loaded_002420211C128141_0024IsLoaded;

	[SpecialName]
	private StaticLocalInitFlag _0024STATIC_0024PageSetupSystem_Loaded_002420211C128141_0024IsLoaded_0024Init;

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

	[field: AccessedThroughProperty("ComboDownloadSource")]
	internal virtual MyComboBox ComboDownloadSource
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboDownloadVersion")]
	internal virtual MyComboBox ComboDownloadVersion
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("SliderDownloadThread")]
	internal virtual MySlider SliderDownloadThread
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MySlider.PreviewChangeEventHandler obj = SliderDownloadThread_PreviewChange;
			MySlider mySlider = field;
			if (mySlider != null)
			{
				mySlider.PreviewChange -= obj;
			}
			field = value;
			mySlider = field;
			if (mySlider != null)
			{
				mySlider.PreviewChange += obj;
			}
		}
	}

	[field: AccessedThroughProperty("SliderDownloadSpeed")]
	internal virtual MySlider SliderDownloadSpeed
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboDownloadMod")]
	internal virtual MyComboBox ComboDownloadMod
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboDownloadTranslateV2")]
	internal virtual MyComboBox ComboDownloadTranslateV2
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboModLocalNameStyle")]
	internal virtual MyComboBox ComboModLocalNameStyle
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckUpdateRelease")]
	internal virtual MyCheckBox CheckUpdateRelease
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckUpdateSnapshot")]
	internal virtual MyCheckBox CheckUpdateSnapshot
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckHelpChinese")]
	internal virtual MyCheckBox CheckHelpChinese
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboSystemUpdate")]
	internal virtual MyComboBox ComboSystemUpdate
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			SelectionChangedEventHandler value2 = ComboSystemUpdate_SelectionChanged;
			MyComboBox myComboBox = field;
			if (myComboBox != null)
			{
				myComboBox.SelectionChanged -= value2;
			}
			field = value;
			myComboBox = field;
			if (myComboBox != null)
			{
				myComboBox.SelectionChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ItemSystemUpdateDownload")]
	internal virtual MyComboBoxItem ItemSystemUpdateDownload
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboSystemActivity")]
	internal virtual MyComboBox ComboSystemActivity
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			SelectionChangedEventHandler value2 = ComboSystemActivity_SelectionChanged;
			MyComboBox myComboBox = field;
			if (myComboBox != null)
			{
				myComboBox.SelectionChanged -= value2;
			}
			field = value;
			myComboBox = field;
			if (myComboBox != null)
			{
				myComboBox.SelectionChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("TextSystemCache")]
	internal virtual MyTextBox TextSystemCache
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckSystemTelemetry")]
	internal virtual MyCheckBox CheckSystemTelemetry
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnSystemUpdate")]
	internal virtual MyButton BtnSystemUpdate
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnSystemUpdate_Click;
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

	[field: AccessedThroughProperty("BtnSystemSettingExp")]
	internal virtual MyButton BtnSystemSettingExp
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnSystemSettingExp_Click;
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

	[field: AccessedThroughProperty("BtnSystemSettingImp")]
	internal virtual MyButton BtnSystemSettingImp
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnSystemSettingImp_Click;
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

	[field: AccessedThroughProperty("PanDonate")]
	internal virtual Grid PanDonate
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnSystemIdentify")]
	internal virtual MyButton BtnSystemIdentify
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnSystemIdentify_Click;
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

	[field: AccessedThroughProperty("BtnSystemUnlock")]
	internal virtual MyButton BtnSystemUnlock
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnSystemUnlock_Click;
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

	[field: AccessedThroughProperty("CardDebug")]
	internal virtual MyCard CardDebug
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanDebugAnim")]
	internal virtual Grid PanDebugAnim
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("SliderDebugAnim")]
	internal virtual MySlider SliderDebugAnim
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckDebugSkipCopy")]
	internal virtual MyCheckBox CheckDebugSkipCopy
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CheckDebugMode")]
	internal virtual MyCheckBox CheckDebugMode
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckDebugMode_Change();
			};
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

	[field: AccessedThroughProperty("CheckDebugDelay")]
	internal virtual MyCheckBox CheckDebugDelay
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public PageSetupSystem()
	{
		Loaded += PageSetupSystem_Loaded;
		InitializeComponent();
	}

	private void PageSetupSystem_Loaded(object sender, RoutedEventArgs e)
	{
		PanBack.ScrollToHome();
		PanDonate.Visibility = Visibility.Visible;
		ItemSystemUpdateDownload.Content = "在有新版本时自动下载（更新快照版前需要先输入土豆码）";
		if (_0024STATIC_0024PageSetupSystem_Loaded_002420211C128141_0024IsLoaded_0024Init == null)
		{
			Interlocked.CompareExchange(ref _0024STATIC_0024PageSetupSystem_Loaded_002420211C128141_0024IsLoaded_0024Init, new StaticLocalInitFlag(), null);
		}
		bool lockTaken = false;
		try
		{
			Monitor.Enter(_0024STATIC_0024PageSetupSystem_Loaded_002420211C128141_0024IsLoaded_0024Init, ref lockTaken);
			if (_0024STATIC_0024PageSetupSystem_Loaded_002420211C128141_0024IsLoaded_0024Init.State == 0)
			{
				_0024STATIC_0024PageSetupSystem_Loaded_002420211C128141_0024IsLoaded_0024Init.State = 2;
				_0024STATIC_0024PageSetupSystem_Loaded_002420211C128141_0024IsLoaded = false;
			}
			else if (_0024STATIC_0024PageSetupSystem_Loaded_002420211C128141_0024IsLoaded_0024Init.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_0024STATIC_0024PageSetupSystem_Loaded_002420211C128141_0024IsLoaded_0024Init.State = 1;
			if (lockTaken)
			{
				Monitor.Exit(_0024STATIC_0024PageSetupSystem_Loaded_002420211C128141_0024IsLoaded_0024Init);
			}
		}
		checked
		{
			if (!_0024STATIC_0024PageSetupSystem_Loaded_002420211C128141_0024IsLoaded)
			{
				_0024STATIC_0024PageSetupSystem_Loaded_002420211C128141_0024IsLoaded = true;
				ModAnimation.AniControlEnabled++;
				Reload();
				SliderLoad();
				ModAnimation.AniControlEnabled--;
			}
		}
	}

	public void Reload()
	{
		SettingService.RefreshSettings(this);
	}

	public void Reset()
	{
		try
		{
			SettingService.ResetSettings(this);
			Logger.Info("已初始化启动器页设置", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupSystem.xaml.vb");
			ModMain.Hint("已初始化启动器页设置！", ModMain.HintType.Green, Log: false);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "初始化启动器页设置失败", LogBehavior.Alert, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupSystem.xaml.vb");
			ProjectData.ClearProjectError();
		}
		Reload();
	}

	private void SliderLoad()
	{
		SliderDownloadThread.GetHintText = (VB_0024AnonymousDelegate_25<object, object>)([SpecialName] (object v) => Operators.AddObject(v, 1));
		SliderDownloadSpeed.GetHintText = (VB_0024AnonymousDelegate_25<object, object>)([SpecialName] (object v) =>
		{
			if (Operators.ConditionalCompareObjectLessEqual(v, 14, TextCompare: false))
			{
				return Operators.ConcatenateObject(Operators.MultiplyObject(Operators.AddObject(v, 1), 0.1), " M/s");
			}
			if (Operators.ConditionalCompareObjectLessEqual(v, 31, TextCompare: false))
			{
				return Operators.ConcatenateObject(Operators.MultiplyObject(Operators.SubtractObject(v, 11), 0.5), " M/s");
			}
			return Operators.ConditionalCompareObjectLessEqual(v, 41, TextCompare: false) ? Operators.ConcatenateObject(Operators.SubtractObject(v, 21), " M/s") : "无限制";
		});
		SliderDebugAnim.GetHintText = (VB_0024AnonymousDelegate_25<object, object>)([SpecialName] (object v) => (!Operators.ConditionalCompareObjectGreater(v, 29, TextCompare: false)) ? Operators.ConcatenateObject(Operators.AddObject(Operators.DivideObject(v, 10), 0.1), "x") : "关闭");
	}

	private void SliderDownloadThread_PreviewChange(object sender, ModBase.RouteEventArgs e)
	{
		if (SliderDownloadThread.Value >= 100 && !Settings.Get<bool>("HintDownloadThread"))
		{
			Settings.Set("HintDownloadThread", true);
			ModMain.MyMsgBox("如果设置过多的下载线程，可能会导致下载时出现非常严重的卡顿。\r\n一般设置 64 线程即可满足大多数下载需求，除非你知道你在干什么，否则不建议设置更多的线程数！", "警告", "我知道了", "", "", IsWarn: true);
		}
	}

	private void BtnSystemIdentify_Click(object sender, MouseButtonEventArgs e)
	{
		PageOtherAbout.CopyIdentify();
	}

	private void BtnSystemUnlock_Click(object sender, MouseButtonEventArgs e)
	{
		ModSecret.InputPotatoCode(IsUpdating: false);
	}

	private void CheckDebugMode_Change()
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModMain.Hint("部分调试信息将在刷新或启动器重启后切换显示！", ModMain.HintType.Blue, Log: false);
		}
	}

	private void ComboSystemActivity_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (ModAnimation.AniControlEnabled == 0 && ComboSystemActivity.SelectedIndex == 2 && ModMain.MyMsgBox("若选择此项，即使在将来出现严重问题时，你也无法获取相关通知。\r\n例如，如果发现某个版本游戏存在严重 Bug，你可能就会因为无法得到通知而导致无法预知的后果。\r\n\r\n一般选择 仅在有重要通知时显示公告 就可以让你尽量不受打扰了。\r\n除非你在制作服务器整合包，或时常手动更新启动器，否则极度不推荐选择此项！", "警告", "我知道我在做什么", "取消", "", IsWarn: true) == 2 && e.RemovedItems.Count > 0)
		{
			ComboSystemActivity.SelectedItem = RuntimeHelpers.GetObjectValue(e.RemovedItems[0]);
		}
	}

	private void ComboSystemUpdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (ModAnimation.AniControlEnabled == 0 && ComboSystemUpdate.SelectedIndex == 3 && ModMain.MyMsgBox("若选择此项，即使在启动器将来出现严重问题时，你也无法获取更新并获得修复。\r\n例如，如果官方修改了登录方式，从而导致现有启动器无法登录，你可能就会因为无法更新而无法开始游戏。\r\n\r\n一般选择 仅在有重大漏洞更新时显示提示 就可以让你尽量不受打扰了。\r\n除非你在制作服务器整合包，或时常手动更新启动器，否则极度不推荐选择此项！", "警告", "我知道我在做什么", "取消", "", IsWarn: true) == 2 && e.RemovedItems.Count > 0)
		{
			ComboSystemUpdate.SelectedItem = RuntimeHelpers.GetObjectValue(e.RemovedItems[0]);
		}
	}

	private void BtnSystemUpdate_Click(object sender, EventArgs e)
	{
		ModSecret.UpdateCheckByButton();
	}

	public static bool? IsLauncherNewest()
	{
		bool? result;
		try
		{
			string fullStr = FileUtils.TryReadAsString(ModBase.PathTemp + "Cache\\Notice.cfg") ?? "";
			if (fullStr.Split("|").Count() >= 3)
			{
				return Conversions.ToDouble(fullStr.Split("|")[1]) <= 414.0;
			}
			result = null;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "确认启动器更新失败", LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupSystem.xaml.vb");
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void BtnSystemSettingExp_Click(object sender, MouseButtonEventArgs e)
	{
		ModMain.Hint("该功能尚在开发中！");
	}

	private void BtnSystemSettingImp_Click(object sender, MouseButtonEventArgs e)
	{
		ModMain.Hint("该功能尚在开发中！");
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
