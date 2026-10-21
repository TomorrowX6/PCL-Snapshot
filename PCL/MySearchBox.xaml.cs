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
public partial class MySearchBox : MyCard, IComponentConnector
{
	public delegate void TextChangedEventHandler(object sender, EventArgs e);

	public string HintText
	{
		get
		{
			return TextBox.HintText;
		}
		set
		{
			TextBox.HintText = value;
		}
	}

	public string Text
	{
		get
		{
			return TextBox.Text;
		}
		set
		{
			TextBox.Text = value;
		}
	}

	[field: AccessedThroughProperty("TextBox")]
	internal virtual MyTextBox TextBox
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			System.Windows.Controls.TextChangedEventHandler value2 = Text_TextChanged;
			MyTextBox myTextBox = field;
			if (myTextBox != null)
			{
				myTextBox.TextChanged -= value2;
			}
			field = value;
			myTextBox = field;
			if (myTextBox != null)
			{
				myTextBox.TextChanged += value2;
			}
		}
	}

	[field: AccessedThroughProperty("BtnClear")]
	internal virtual MyIconButton BtnClear
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = BtnClear_Click;
			MyIconButton myIconButton = field;
			if (myIconButton != null)
			{
				myIconButton.Click -= obj;
			}
			field = value;
			myIconButton = field;
			if (myIconButton != null)
			{
				myIconButton.Click += obj;
			}
		}
	}

	public event TextChangedEventHandler TextChanged;

	public MySearchBox()
	{
		Loaded += MySearchBox_Loaded;
		KeyUp += MySearchBox_KeyUp;
		InitializeComponent();
	}

	private void MySearchBox_Loaded(object sender, RoutedEventArgs e)
	{
		TextBox.Focus();
	}

	private void Text_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (string.IsNullOrEmpty(TextBox.Text))
		{
			ModAnimation.AniStart(ModAnimation.AaOpacity(BtnClear, 0.0 - BtnClear.Opacity, 90), "MySearchBox ClearBtn " + Conversions.ToString(Uuid));
			BtnClear.IsHitTestVisible = false;
		}
		else
		{
			ModAnimation.AniStart(ModAnimation.AaOpacity(BtnClear, 1.0 - BtnClear.Opacity, 90), "MySearchBox ClearBtn " + Conversions.ToString(Uuid));
			BtnClear.IsHitTestVisible = true;
		}
		TextChanged?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void BtnClear_Click(object sender, EventArgs e)
	{
		TextBox.Text = "";
		TextBox.Focus();
	}

	private void MySearchBox_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Return)
		{
			ModMain.RaiseCustomEvent(this);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
