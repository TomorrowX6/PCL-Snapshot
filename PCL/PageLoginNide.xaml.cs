using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MeloongCore.Extensions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageLoginNide : Grid, IComponentConnector
{
	private bool IsFirstLoad;

	[field: AccessedThroughProperty("ComboName")]
	internal virtual MyComboBox ComboName
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyComboBox.TextChangedEventHandler obj = ComboName_TextChanged;
			SelectionChangedEventHandler value2 = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
			{
				ComboName_SelectionChanged((MyComboBox)a0, a1);
			};
			MyComboBox.TextChangedEventHandler obj2 = [SpecialName] (object a0, TextChangedEventArgs a1) =>
			{
				ComboName_TextChanged();
			};
			MyComboBox myComboBox = field;
			if (myComboBox != null)
			{
				myComboBox.TextChanged -= obj;
				myComboBox.SelectionChanged -= value2;
				myComboBox.TextChanged -= obj2;
			}
			field = value;
			myComboBox = field;
			if (myComboBox != null)
			{
				myComboBox.TextChanged += obj;
				myComboBox.SelectionChanged += value2;
				myComboBox.TextChanged += obj2;
			}
		}
	}

	[field: AccessedThroughProperty("TextPass")]
	internal virtual PasswordBox TextPass
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RoutedEventHandler value2 = TextPass_PasswordChanged;
			PasswordBox passwordBox = field;
			if (passwordBox != null)
			{
				passwordBox.PasswordChanged -= value2;
			}
			field = value;
			passwordBox = field;
			if (passwordBox != null)
			{
				passwordBox.PasswordChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("CheckRemember")]
	internal virtual MyCheckBox CheckRemember
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
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

	[field: AccessedThroughProperty("BtnLink")]
	internal virtual MyTextButton BtnLink
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyTextButton.ClickEventHandler obj = Btn_Click;
			MyTextButton myTextButton = field;
			if (myTextButton != null)
			{
				myTextButton.Click -= obj;
			}
			field = value;
			myTextButton = field;
			if (myTextButton != null)
			{
				myTextButton.Click += obj;
			}
		}
	}

	public PageLoginNide()
	{
		IsFirstLoad = true;
		InitializeComponent();
	}

	public void Reload(bool KeepInput)
	{
		CheckRemember.Checked = Settings.Get<bool>("LoginRemember");
		if (KeepInput && !IsFirstLoad)
		{
			string text = ComboName.Text;
			ComboName.ItemsSource = ((Operators.CompareString(Settings.Get<string>("LoginNideEmail"), "", TextCompare: false) == 0) ? null : Settings.Get<string>("LoginNideEmail").ToString().Split("\u00a8"));
			ComboName.Text = text;
		}
		else if (Operators.CompareString(Settings.Get<string>("LoginNideEmail"), "", TextCompare: false) == 0)
		{
			ComboName.ItemsSource = null;
		}
		else
		{
			ComboName.ItemsSource = Settings.Get<string>("LoginNideEmail").Split("\u00a8");
			ComboName.Text = Settings.Get<string>("LoginNideEmail").BeforeFirst("\u00a8");
			if (Settings.Get<bool>("LoginRemember"))
			{
				TextPass.Password = Settings.Get<string>("LoginNidePass").BeforeFirst("\u00a8").Trim();
			}
		}
		IsFirstLoad = false;
	}

	public static ModLaunch.McLoginServer GetLoginData()
	{
		string text = (Information.IsNothing(ModMinecraft.McInstanceSelected) ? Settings.Get<string>("CacheNideServer") : Settings.Get<string>("VersionServerNide", ModMinecraft.McInstanceSelected));
		if (ModMain.FrmLoginNide == null)
		{
			return new ModLaunch.McLoginServer(ModLaunch.McLoginType.Nide)
			{
				Token = "Nide",
				UserName = "",
				Password = "",
				Description = "统一通行证",
				Type = ModLaunch.McLoginType.Nide,
				BaseUrl = "https://auth.mc-user.com:233/" + text + "/authserver"
			};
		}
		return new ModLaunch.McLoginServer(ModLaunch.McLoginType.Nide)
		{
			Token = "Nide",
			UserName = ModMain.FrmLoginNide.ComboName.Text.Replace("\u00a8", "").Trim(),
			Password = ModMain.FrmLoginNide.TextPass.Password.Replace("\u00a8", "").Trim(),
			Description = "统一通行证",
			Type = ModLaunch.McLoginType.Nide,
			BaseUrl = "https://auth.mc-user.com:233/" + text + "/authserver"
		};
	}

	public static string IsVaild(ModLaunch.McLoginServer LoginData)
	{
		if (Operators.CompareString(LoginData.UserName, "", TextCompare: false) == 0)
		{
			return "账号不能为空！";
		}
		if (Operators.CompareString(LoginData.Password, "", TextCompare: false) == 0)
		{
			return "密码不能为空！";
		}
		return "";
	}

	public string IsVaild()
	{
		return IsVaild(GetLoginData());
	}

	private void ComboName_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(sender, null, "Text", new object[0], null, null, null), "", TextCompare: false))
		{
			TextPass.Password = "";
		}
		if (ModAnimation.AniControlEnabled == 0)
		{
			Settings.Set("CacheNideAccess", "");
		}
	}

	private void TextPass_PasswordChanged(object sender, RoutedEventArgs e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			Settings.Set("CacheNideAccess", "");
		}
	}

	private void ComboName_SelectionChanged(MyComboBox sender, SelectionChangedEventArgs e)
	{
		if (sender.SelectedIndex == -1 || !Settings.Get<bool>("LoginRemember"))
		{
			TextPass.Password = "";
		}
		else
		{
			TextPass.Password = Settings.Get<string>("LoginNidePass").Split("\u00a8")[sender.SelectedIndex].Trim();
		}
	}

	private void CheckBoxChange(MyCheckBox sender, object e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			Settings.Set(Conversions.ToString(sender.Tag), sender.Checked);
		}
	}

	private void ComboName_TextChanged()
	{
		BtnLink.Content = ((Operators.CompareString(ComboName.Text, "", TextCompare: false) == 0) ? "注册账号" : "找回密码");
	}

	private void Btn_Click(object sender, EventArgs e)
	{
		if (Operators.ConditionalCompareObjectEqual(BtnLink.Content, "注册账号", TextCompare: false))
		{
			ModBase.OpenWebsite("https://login.mc-user.com:233/" + Settings.Get<string>("VersionServerNide", ModMinecraft.McInstanceSelected) + "/register");
		}
		else
		{
			ModBase.OpenWebsite("https://login.mc-user.com:233/account/login");
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
