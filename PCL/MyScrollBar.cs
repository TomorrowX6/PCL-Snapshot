using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using MeloongCore;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class MyScrollBar : ScrollBar
{
	public int Uuid;

	public MyScrollBar()
	{
		IsEnabledChanged += [SpecialName] (object a0, DependencyPropertyChangedEventArgs a1) =>
		{
			RefreshColor();
		};
		GotMouseCapture += [SpecialName] (object a0, MouseEventArgs a1) =>
		{
			RefreshColor();
		};
		LostMouseCapture += [SpecialName] (object a0, MouseEventArgs a1) =>
		{
			RefreshColor();
		};
		MouseEnter += [SpecialName] (object a0, MouseEventArgs a1) =>
		{
			RefreshColor();
		};
		MouseLeave += [SpecialName] (object a0, MouseEventArgs a1) =>
		{
			RefreshColor();
		};
		IsVisibleChanged += [SpecialName] (object a0, DependencyPropertyChangedEventArgs a1) =>
		{
			RefreshColor();
		};
		Uuid = ModBase.GetUuid();
	}

	private void RefreshColor()
	{
		try
		{
			double num;
			int time;
			string text;
			if (!IsVisible)
			{
				num = 0.0;
				time = 20;
				text = "ColorBrush4";
			}
			else if (IsMouseCaptureWithin)
			{
				num = 1.0;
				text = "ColorBrush4";
				time = 50;
			}
			else if (IsMouseOver)
			{
				num = 0.9;
				text = "ColorBrush3";
				time = 130;
			}
			else
			{
				num = 0.5;
				text = "ColorBrush4";
				time = 180;
			}
			if (IsLoaded && ModAnimation.AniControlEnabled == 0)
			{
				ModAnimation.AniStart(new ModAnimation.AniData[2]
				{
					ModAnimation.AaColor(this, Control.ForegroundProperty, text, time),
					ModAnimation.AaOpacity(this, num - Opacity, time)
				}, "MyScrollBar Color " + Conversions.ToString(Uuid));
			}
			else
			{
				ModAnimation.AniStop("MyScrollBar Color " + Conversions.ToString(Uuid));
				SetResourceReference(Control.ForegroundProperty, text);
				Opacity = num;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Warn(ex2, "滚动条颜色改变出错", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Controls\\MyScrollBar.vb");
			ProjectData.ClearProjectError();
		}
	}
}
