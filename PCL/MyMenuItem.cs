using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class MyMenuItem : MenuItem
{
	public int Uuid;

	private const int AnimationTimeIn = 100;

	private const int AnimationTimeOut = 200;

	private string ColorName;

	public MyMenuItem()
	{
		Loaded += MyMenuItem_Loaded;
		MouseEnter += [SpecialName] (object a0, MouseEventArgs a1) =>
		{
			RefreshColor();
		};
		MouseLeave += [SpecialName] (object a0, MouseEventArgs a1) =>
		{
			RefreshColor();
		};
		IsEnabledChanged += [SpecialName] (object a0, DependencyPropertyChangedEventArgs a1) =>
		{
			RefreshColor();
		};
		Click += MyMenuItem_Click;
		Uuid = ModBase.GetUuid();
	}

	private void MyMenuItem_Loaded(object sender, RoutedEventArgs e)
	{
		if (Icon != null)
		{
			Path path = (Path)GetTemplateChild("Icon");
			if (path != null)
			{
				path.Data = (Geometry)new GeometryConverter().ConvertFromString(Conversions.ToString(Icon));
			}
		}
		if (Parent is ContextMenu)
		{
			((ContextMenu)Parent).Opacity = (double)Settings.Get<int>("UiLauncherTransparent") / 1000.0 + 0.4;
		}
	}

	private void RefreshColor()
	{
		string text;
		string text2;
		int time;
		if (!IsEnabled)
		{
			text = "ColorBrushTransparent";
			text2 = "ColorBrushGray5";
			time = 200;
		}
		else if (IsMouseOver)
		{
			text = "ColorBrush6";
			text2 = "ColorBrush2";
			time = 100;
		}
		else
		{
			text = "ColorBrushTransparent";
			text2 = "ColorBrush1";
			time = 200;
		}
		if (Operators.CompareString(ColorName, text, TextCompare: false) != 0)
		{
			ColorName = text;
			if (IsLoaded && ModAnimation.AniControlEnabled == 0)
			{
				ModAnimation.AniStart(new ModAnimation.AniData[2]
				{
					ModAnimation.AaColor(this, Control.BackgroundProperty, text, time),
					ModAnimation.AaColor(this, Control.ForegroundProperty, text2, time)
				}, "MyMenuItem Color " + Conversions.ToString(Uuid));
			}
			else
			{
				ModAnimation.AniStop("MyMenuItem Color " + Conversions.ToString(Uuid));
				SetResourceReference(Control.BackgroundProperty, text);
				SetResourceReference(Control.ForegroundProperty, text2);
			}
		}
	}

	private void MyMenuItem_Click(object sender, RoutedEventArgs e)
	{
		ModMain.RaiseCustomEvent(this);
	}
}
