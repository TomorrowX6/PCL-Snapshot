using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using MeloongCore;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class MyMsgSelect : Grid, IComponentConnector
{
	private readonly ModMain.MyMsgBoxConverter MyConverter;

	private readonly int Uuid;

	private int SelectedIndex;

	[field: AccessedThroughProperty("TransformRotate")]
	internal virtual RotateTransform TransformRotate
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TransformPos")]
	internal virtual TranslateTransform TransformPos
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanBorder")]
	internal virtual Border PanBorder
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseButtonEventHandler value2 = Drag;
			Border border = field;
			if (border != null)
			{
				border.MouseLeftButtonDown -= value2;
			}
			field = value;
			border = field;
			if (border != null)
			{
				border.MouseLeftButtonDown += value2;
			}
		}
	}

	[field: AccessedThroughProperty("EffectShadow")]
	internal virtual DropShadowEffect EffectShadow
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanMain")]
	internal virtual Grid PanMain
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabTitle")]
	internal virtual TextBlock LabTitle
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MouseButtonEventHandler value2 = Drag;
			TextBlock textBlock = field;
			if (textBlock != null)
			{
				textBlock.MouseLeftButtonDown -= value2;
			}
			field = value;
			textBlock = field;
			if (textBlock != null)
			{
				textBlock.MouseLeftButtonDown += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ShapeLine")]
	internal virtual Rectangle ShapeLine
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanCaption")]
	internal virtual MyScrollViewer PanCaption
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanSelection")]
	internal virtual StackPanel PanSelection
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanBtn")]
	internal virtual StackPanel PanBtn
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("Btn1")]
	public virtual MyButton Btn1
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				Btn1_Click();
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

	[field: AccessedThroughProperty("Btn2")]
	public virtual MyButton Btn2
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				Btn2_Click();
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

	public MyMsgSelect(ModMain.MyMsgBoxConverter Converter)
	{
		Loaded += Load;
		Uuid = ModBase.GetUuid();
		SelectedIndex = -1;
		try
		{
			InitializeComponent();
			Btn1.Name += Conversions.ToString(ModBase.GetUuid());
			Btn2.Name += Conversions.ToString(ModBase.GetUuid());
			MyConverter = Converter;
			LabTitle.Text = Converter.Title;
			Btn1.Text = Converter.Button1;
			if (Converter.IsWarn)
			{
				Btn1.ColorType = MyButton.ColorState.Red;
				LabTitle.SetResourceReference(TextBlock.ForegroundProperty, "ColorBrushRedLight");
			}
			Btn2.Text = Converter.Button2;
			Btn2.Visibility = ((Operators.CompareString(Converter.Button2, "", TextCompare: false) == 0) ? Visibility.Collapsed : Visibility.Visible);
			ShapeLine.StrokeThickness = ModBase.GetWPFSize(1.0);
			Btn1.IsEnabled = false;
			foreach (object item in (IEnumerable)Converter.Content)
			{
				IMyRadio myRadio = (IMyRadio)MyVirtualizingElement.TryInit((FrameworkElement)RuntimeHelpers.GetObjectValue(item));
				PanSelection.Children.Add((UIElement)myRadio);
				myRadio.Check += [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
				{
					OnChecked((IMyRadio)a0, a1);
				};
				if (myRadio is MyListItem)
				{
					((MyListItem)myRadio).Type = MyListItem.CheckType.RadioBox;
					((MyListItem)myRadio).MinHeight = 24.0;
				}
				else
				{
					((MyRadioBox)myRadio).MinHeight = 24.0;
				}
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "选择弹窗初始化失败", LogBehavior.Toast, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Controls\\MyMsg\\MyMsgSelect.xaml.vb");
			ProjectData.ClearProjectError();
		}
	}

	private void Load(object sender, EventArgs e)
	{
		try
		{
			if (Btn2.IsVisible && Btn1.ColorType != MyButton.ColorState.Red)
			{
				Btn1.ColorType = MyButton.ColorState.Highlight;
			}
			Opacity = 0.0;
			ModAnimation.AniStart(ModAnimation.AaColor(ModMain.FrmMain.PanMsg, Panel.BackgroundProperty, (MyConverter.IsWarn ? new ModBase.MyColor(140.0, 80.0, 0.0, 0.0) : new ModBase.MyColor(90.0, 0.0, 0.0, 0.0)) - ModMain.FrmMain.PanMsg.Background, 200), "PanMsg Background");
			ModAnimation.AniStart(new ModAnimation.AniData[3]
			{
				ModAnimation.AaOpacity(this, 1.0, 120, 60),
				ModAnimation.AaDouble([SpecialName] (object i) =>
				{
					TranslateTransform transformPos;
					(transformPos = TransformPos).Y = Conversions.ToDouble(Operators.AddObject(transformPos.Y, i));
				}, 0.0 - TransformPos.Y, 300, 60, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak)),
				ModAnimation.AaDouble([SpecialName] (object i) =>
				{
					RotateTransform transformRotate;
					(transformRotate = TransformRotate).Angle = Conversions.ToDouble(Operators.AddObject(transformRotate.Angle, i));
				}, 0.0 - TransformRotate.Angle, 300, 60, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak))
			}, "MyMsgBox " + Conversions.ToString(Uuid));
			Logger.Info($"选择弹窗：{LabTitle.Text}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Controls\\MyMsg\\MyMsgSelect.xaml.vb");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "选择弹窗加载失败", LogBehavior.Toast, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Controls\\MyMsg\\MyMsgSelect.xaml.vb");
			ProjectData.ClearProjectError();
		}
	}

	private void Close()
	{
		MyConverter.WaitFrame.Continue = false;
		ComponentDispatcher.PopModal();
		ModAnimation.AniStart(new ModAnimation.AniData[5]
		{
			ModAnimation.AaCode([SpecialName] () =>
			{
				if (!ModMain.WaitingMyMsgBox.Any())
				{
					ModAnimation.AniStart(ModAnimation.AaColor(ModMain.FrmMain.PanMsg, Panel.BackgroundProperty, new ModBase.MyColor(0.0, 0.0, 0.0, 0.0) - ModMain.FrmMain.PanMsg.Background, 200, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)));
				}
			}, 30),
			ModAnimation.AaOpacity(this, 0.0 - Opacity, 80, 20),
			ModAnimation.AaDouble([SpecialName] (object i) =>
			{
				TranslateTransform transformPos;
				(transformPos = TransformPos).Y = Conversions.ToDouble(Operators.AddObject(transformPos.Y, i));
			}, 20.0 - TransformPos.Y, 150, 0, new ModAnimation.AniEaseOutFluent()),
			ModAnimation.AaDouble([SpecialName] (object i) =>
			{
				RotateTransform transformRotate;
				(transformRotate = TransformRotate).Angle = Conversions.ToDouble(Operators.AddObject(transformRotate.Angle, i));
			}, 6.0 - TransformRotate.Angle, 150, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak)),
			ModAnimation.AaCode([SpecialName] () =>
			{
				((Grid)Parent).Children.Remove(this);
			}, 0, After: true)
		}, "MyMsgBox " + Conversions.ToString(Uuid));
	}

	public void Btn1_Click()
	{
		if (!MyConverter.IsExited && SelectedIndex != -1)
		{
			MyConverter.IsExited = true;
			MyConverter.Result = SelectedIndex;
			Close();
		}
	}

	public void Btn2_Click()
	{
		if (!MyConverter.IsExited)
		{
			MyConverter.IsExited = true;
			MyConverter.Result = null;
			Close();
		}
	}

	private void OnChecked(IMyRadio sender, EventArgs e)
	{
		Btn1.IsEnabled = true;
		SelectedIndex = PanSelection.Children.IndexOf((UIElement)sender);
	}

	private void Drag(object sender, MouseButtonEventArgs e)
	{
		int try0000_dispatch = -1;
		int num3 = default;
		int num = default;
		int num2 = default;
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0000_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = 1;
					goto IL_0007;
				case 86:
					{
						num = num2;
						switch (num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0000;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_0007;
						case 3:
							goto end_IL_0000_2;
						default:
							goto end_IL_0000;
						case 4:
							goto end_IL_0000_3;
						}
						goto default;
					}
					IL_0007:
					num2 = 2;
					if (!(e.GetPosition(ShapeLine).Y <= 2.0))
					{
						goto end_IL_0000_3;
					}
					break;
					end_IL_0000_2:
					break;
				}
				num2 = 3;
				ModMain.FrmMain.DragMove();
				break;
				end_IL_0000:;
			}
			catch (Exception ex) when ((num3 != 0) & (num == 0))
			{
				ProjectData.SetProjectError(ex);
				try0000_dispatch = 86;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0000_3:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
