using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageOtherAbout : MyPageRight, IComponentConnector
{
	private new bool IsLoaded;

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

	[field: AccessedThroughProperty("ItemAboutPcl")]
	internal virtual MyListItem ItemAboutPcl
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnAboutUpdate")]
	internal virtual MyButton BtnAboutUpdate
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnAboutUpdate_Click;
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

	[field: AccessedThroughProperty("BtnDonateOutput")]
	internal virtual MyButton BtnDonateOutput
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnDonateOutput_Click;
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

	[field: AccessedThroughProperty("BtnDonateDonate")]
	internal virtual MyButton BtnDonateDonate
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnDonateCopy")]
	internal virtual MyButton BtnDonateCopy
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				CopyIdentify();
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

	[field: AccessedThroughProperty("BtnDonateInput")]
	internal virtual MyButton BtnDonateInput
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				BtnDonateCodeInput_Click();
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

	public PageOtherAbout()
	{
		Loaded += PageOtherAbout_Loaded;
		IsLoaded = false;
		InitializeComponent();
	}

	private void PageOtherAbout_Loaded(object sender, RoutedEventArgs e)
	{
		PanBack.ScrollToHome();
		if (!IsLoaded)
		{
			IsLoaded = true;
			ItemAboutPcl.Info = ItemAboutPcl.Info.Replace("%VERSION%", "快照版 2.99.0.0").Replace("%VERSIONCODE%", Conversions.ToString(414)).Replace("%BRANCH%", Conversions.ToString(0));
		}
	}

	public static void CopyIdentify()
	{
		ModBase.ClipboardSet(ModBase.Identify);
	}

	private void BtnDonateCodeInput_Click()
	{
		ModSecret.InputPotatoCode(IsUpdating: false);
	}

	private void BtnDonateOutput_Click(object sender, EventArgs e)
	{
		ModSecret.GeneratePotatoCode();
	}

	private void BtnAboutUpdate_Click(object sender, MouseButtonEventArgs e)
	{
		ModSecret.UpdateCheckByButton();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
