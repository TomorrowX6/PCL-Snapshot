using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MeloongCore;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageSetupLink : MyPageRight, IComponentConnector
{
	[SpecialName]
	private bool _0024STATIC_0024PageSetupLink_Loaded_002420211C128141_0024IsLoaded;

	[SpecialName]
	private StaticLocalInitFlag _0024STATIC_0024PageSetupLink_Loaded_002420211C128141_0024IsLoaded_0024Init;

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

	[field: AccessedThroughProperty("CardArgument")]
	internal virtual MyCard CardArgument
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ComboLatencyMode")]
	internal virtual MyComboBox ComboLatencyMode
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextCustomPeer")]
	internal virtual MyTextBox TextCustomPeer
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public PageSetupLink()
	{
		Loaded += PageSetupLink_Loaded;
		InitializeComponent();
	}

	private void PageSetupLink_Loaded(object sender, RoutedEventArgs e)
	{
		PanBack.ScrollToHome();
		if (_0024STATIC_0024PageSetupLink_Loaded_002420211C128141_0024IsLoaded_0024Init == null)
		{
			Interlocked.CompareExchange(ref _0024STATIC_0024PageSetupLink_Loaded_002420211C128141_0024IsLoaded_0024Init, new StaticLocalInitFlag(), null);
		}
		bool lockTaken = false;
		try
		{
			Monitor.Enter(_0024STATIC_0024PageSetupLink_Loaded_002420211C128141_0024IsLoaded_0024Init, ref lockTaken);
			if (_0024STATIC_0024PageSetupLink_Loaded_002420211C128141_0024IsLoaded_0024Init.State == 0)
			{
				_0024STATIC_0024PageSetupLink_Loaded_002420211C128141_0024IsLoaded_0024Init.State = 2;
				_0024STATIC_0024PageSetupLink_Loaded_002420211C128141_0024IsLoaded = false;
			}
			else if (_0024STATIC_0024PageSetupLink_Loaded_002420211C128141_0024IsLoaded_0024Init.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_0024STATIC_0024PageSetupLink_Loaded_002420211C128141_0024IsLoaded_0024Init.State = 1;
			if (lockTaken)
			{
				Monitor.Exit(_0024STATIC_0024PageSetupLink_Loaded_002420211C128141_0024IsLoaded_0024Init);
			}
		}
		checked
		{
			if (!_0024STATIC_0024PageSetupLink_Loaded_002420211C128141_0024IsLoaded)
			{
				_0024STATIC_0024PageSetupLink_Loaded_002420211C128141_0024IsLoaded = true;
				ModAnimation.AniControlEnabled++;
				Reload();
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
			Logger.Info("已初始化联机页设置", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupLink.xaml.vb");
			ModMain.Hint("已初始化联机页设置！", ModMain.HintType.Green, Log: false);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "初始化联机页设置失败", LogBehavior.Alert, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageSetup\\PageSetupLink.xaml.vb");
			ProjectData.ClearProjectError();
		}
		Reload();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
