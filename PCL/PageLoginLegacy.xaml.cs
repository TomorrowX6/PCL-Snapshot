using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using MeloongCore.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageLoginLegacy : Grid, IComponentConnector
{
	public bool IsReloaded;

	[field: AccessedThroughProperty("PanMain")]
	internal virtual StackPanel PanMain
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("HintChinese")]
	internal virtual MyHint HintChinese
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Skin")]
	internal virtual MySkin Skin
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MySkin.ClickEventHandler obj = [SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				Skin_Click();
			};
			MySkin mySkin = field;
			if (mySkin != null)
			{
				mySkin.Click -= obj;
			}
			field = value;
			mySkin = field;
			if (mySkin != null)
			{
				mySkin.Click += obj;
			}
		}
	}

	[field: AccessedThroughProperty("ComboName")]
	internal virtual MyComboBox ComboName
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			KeyEventHandler value2 = ComboName_PreviewKeyDown;
			MyComboBox.TextChangedEventHandler obj = ComboLegacy_TextChanged;
			MyComboBox myComboBox = field;
			if (myComboBox != null)
			{
				myComboBox.PreviewKeyDown -= value2;
				myComboBox.TextChanged -= obj;
			}
			field = value;
			myComboBox = field;
			if (myComboBox != null)
			{
				myComboBox.PreviewKeyDown += value2;
				myComboBox.TextChanged += obj;
			}
		}
	}

	public PageLoginLegacy()
	{
		Loaded += PageLoginLegacy_Loaded;
		IsReloaded = false;
		InitializeComponent();
		Skin.Loader = PageLaunchLeft.SkinLegacy;
	}

	private void PageLoginLegacy_Loaded(object sender, RoutedEventArgs e)
	{
		Skin.Loader.Start();
	}

	public void Reload(bool KeepInput)
	{
		if (KeepInput && IsReloaded)
		{
			string text = ComboName.Text.Trim();
			ComboName.ItemsSource = ((Operators.CompareString(Settings.Get<string>("LoginLegacyName"), "", TextCompare: false) == 0) ? null : Settings.Get<string>("LoginLegacyName").Split("\u00a8"));
			ComboName.Text = text;
		}
		else if (Operators.CompareString(Settings.Get<string>("LoginLegacyName"), "", TextCompare: false) == 0)
		{
			ComboName.ItemsSource = null;
		}
		else
		{
			ComboName.ItemsSource = Settings.Get<string>("LoginLegacyName").ToString().Split("\u00a8");
			ComboName.Text = Settings.Get<string>("LoginLegacyName").ToString().BeforeFirst("\u00a8")
				.Trim();
		}
		IsReloaded = true;
	}

	public static ModLaunch.McLoginData GetLoginData()
	{
		string userName = ((ModMain.FrmLoginLegacy == null) ? "" : ModMain.FrmLoginLegacy.ComboName.Text.Replace("\u00a8", "").Trim());
		return new ModLaunch.McLoginLegacy
		{
			UserName = userName,
			SkinType = Settings.Get<int>("LaunchSkinType"),
			SkinName = Settings.Get<string>("LaunchSkinID")
		};
	}

	public static string IsVaild(ModLaunch.McLoginLegacy LoginData)
	{
		if (Operators.CompareString(LoginData.UserName.Trim(), "", TextCompare: false) == 0)
		{
			return "玩家名不能为空！";
		}
		if (LoginData.UserName.Contains("\""))
		{
			return "玩家名不能包含英文引号！";
		}
		if ((object)ModMinecraft.McInstanceSelected != null && ModMinecraft.McInstanceSelected.Version.Valid && ModMinecraft.McInstanceSelected.Version.Vanilla >= new Version(20, 0, 3) && LoginData.UserName.Trim().Length > 16)
		{
			return "自 1.20.3 起，玩家名至多只能包含 16 个字符！";
		}
		return "";
	}

	public string IsVaild()
	{
		return IsVaild((ModLaunch.McLoginLegacy)GetLoginData());
	}

	private void ComboName_PreviewKeyDown(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Space)
		{
			int caretIndex = ((MyTextBox)ComboName.Template.FindName("PART_EditableTextBox", ComboName)).CaretIndex;
			if (caretIndex == ComboName.Text.Length || caretIndex == 0)
			{
				e.Handled = true;
			}
		}
	}

	private void ComboLegacy_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (Settings.Get<int>("LaunchSkinType") == 0)
		{
			PageLaunchLeft.SkinLegacy.Start(null, IsForceRestart: true);
		}
		HintChinese.Visibility = (ComboName.Text.RegexCheck("^[0-9A-Za-z_]*$") ? Visibility.Collapsed : Visibility.Visible);
		ModBase.RunInUi([SpecialName] () =>
		{
			PanMain.InvalidateMeasure();
		}, ForceWaitUntilLoaded: true);
	}

	private void Skin_Click()
	{
		if ((Settings.Get<bool>("UiHiddenPageSetup") || Settings.Get<bool>("UiHiddenSetupLaunch")) && !PageSetupUI.HiddenForceShow)
		{
			ModMain.Hint("启动设置已被禁用！", ModMain.HintType.Red);
		}
		else
		{
			ModMain.FrmMain.PageChange(FormMain.PageType.Setup);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
