using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageInstanceModDisabled : MyPageRight, IComponentConnector
{
	[field: AccessedThroughProperty("PanMain")]
	internal virtual MyCard PanMain
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnDownload")]
	internal virtual MyButton BtnDownload
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnDownload_Click;
			RoutedEventHandler value2 = [SpecialName] (object a0, RoutedEventArgs a1) =>
			{
				BtnDownload_Loaded();
			};
			MyButton myButton = field;
			if (myButton != null)
			{
				myButton.Click -= obj;
				myButton.Loaded -= value2;
			}
			field = value;
			myButton = field;
			if (myButton != null)
			{
				myButton.Click += obj;
				myButton.Loaded += value2;
			}
		}
	}

	[field: AccessedThroughProperty("BtnVersion")]
	internal virtual MyButton BtnVersion
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnVersion_Click;
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

	public PageInstanceModDisabled()
	{
		InitializeComponent();
	}

	private void BtnDownload_Click(object sender, EventArgs e)
	{
		ModMain.FrmMain.PageChange(FormMain.PageType.Download);
	}

	private void BtnVersion_Click(object sender, EventArgs e)
	{
		ModMain.FrmMain.PageChange(FormMain.PageType.Launch);
		ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSelect);
	}

	public void BtnDownload_Loaded()
	{
		Visibility visibility = (((Settings.Get<bool>("UiHiddenPageDownload") && !PageSetupUI.HiddenForceShow) || (ModMain.FrmSelectRight != null && ModMain.FrmSelectRight.ShowHidden)) ? Visibility.Collapsed : Visibility.Visible);
		if (BtnDownload.Visibility != visibility)
		{
			BtnDownload.Visibility = visibility;
			PanMain.TriggerForceResize();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
