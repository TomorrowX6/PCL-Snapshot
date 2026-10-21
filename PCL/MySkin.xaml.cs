using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Effects;
using MeloongCore;
using MeloongCore.Extensions;
using MeloongCore.Wpf;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PCL;

[DesignerGenerated]
public partial class MySkin : Grid, IComponentConnector
{
	public delegate void ClickEventHandler(object sender, MouseButtonEventArgs e);

	[CompilerGenerated]
	internal sealed class _Closure_0024__22_002D0
	{
		public ModLoader.LoaderTask<(string, string), string> _0024VB_0024Local_sender;

		public _Closure_0024__22_002D0(_Closure_0024__22_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_sender = arg0._0024VB_0024Local_sender;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			try
			{
				ModMain.Hint("正在刷新皮肤……");
				Logger.Info("正在清空皮肤缓存", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\MySkin.xaml.vb");
				if (DirectoryUtils.Exists(ModBase.PathTemp + "Cache\\Skin"))
				{
					DirectoryUtils.Delete(ModBase.PathTemp + "Cache\\Skin");
				}
				if (DirectoryUtils.Exists(ModBase.PathTemp + "Cache\\Uuid"))
				{
					DirectoryUtils.Delete(ModBase.PathTemp + "Cache\\Uuid");
				}
				ModBase.IniClearCache(ModBase.PathTemp + "Cache\\Skin\\IndexMs.ini");
				ModBase.IniClearCache(ModBase.PathTemp + "Cache\\Skin\\IndexNide.ini");
				ModBase.IniClearCache(ModBase.PathTemp + "Cache\\Skin\\IndexAuth.ini");
				ModBase.IniClearCache(ModBase.PathTemp + "Cache\\Uuid\\Mojang.ini");
				ModLoader.LoaderTask<(string, string), string>[] array = ((_0024VB_0024Local_sender == null) ? new ModLoader.LoaderTask<(string, string), string>[2]
				{
					PageLaunchLeft.SkinLegacy,
					PageLaunchLeft.SkinMs
				} : new ModLoader.LoaderTask<(string, string), string>[1] { _0024VB_0024Local_sender });
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					array[i].WaitForExit(null, null, IsForceRestart: true);
				}
				ModMain.Hint("已刷新皮肤！", ModMain.HintType.Green);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Logger.Error(ex2, "刷新皮肤缓存失败", LogBehavior.Alert, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\MySkin.xaml.vb");
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__23_002D0
	{
		public string _0024VB_0024Local_SkinAddress;

		public _Closure_0024__23_002D0(_Closure_0024__23_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_SkinAddress = arg0._0024VB_0024Local_SkinAddress;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			try
			{
				ModBase.WriteIni(ModBase.PathTemp + "Cache\\Skin\\IndexMs.ini", Settings.Get<string>("CacheMsV2Uuid"), _0024VB_0024Local_SkinAddress);
				Logger.Info(string.Format("已写入皮肤地址缓存 {0} -> {1}", Settings.Get<string>("CacheMsV2Uuid"), _0024VB_0024Local_SkinAddress), LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\MySkin.xaml.vb");
				ModLoader.LoaderTask<(string, string), string>[] array = new ModLoader.LoaderTask<(string, string), string>[2]
				{
					PageLaunchLeft.SkinMs,
					PageLaunchLeft.SkinLegacy
				};
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					array[i].WaitForExit(null, null, IsForceRestart: true);
				}
				ModMain.Hint("更改皮肤成功！", ModMain.HintType.Green);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Logger.Error(ex2, "更改正版皮肤后刷新皮肤失败", LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\MySkin.xaml.vb");
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__28_002D0
	{
		public JObject _0024VB_0024Local_SkinData;

		public int? _0024VB_0024Local_SelectedIndex;

		public _Closure_0024__28_002D0(_Closure_0024__28_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_SkinData = arg0._0024VB_0024Local_SkinData;
				_0024VB_0024Local_SelectedIndex = arg0._0024VB_0024Local_SelectedIndex;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			try
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>
				{
					{ "Migrator", "迁移者披风" },
					{ "MapMaker", "Realms 地图制作者披风" },
					{ "Moderator", "Mojira 管理员披风" },
					{ "Translator-Chinese", "Crowdin 中文翻译者披风" },
					{ "Translator", "Crowdin 翻译者披风" },
					{ "Cobalt", "Cobalt 披风" },
					{ "Vanilla", "原版披风" },
					{ "Minecon2011", "Minecon 2011 参与者披风" },
					{ "Minecon2012", "Minecon 2012 参与者披风" },
					{ "Minecon2013", "Minecon 2013 参与者披风" },
					{ "Minecon2015", "Minecon 2015 参与者披风" },
					{ "Minecon2016", "Minecon 2016 参与者披风" },
					{ "Cherry Blossom", "樱花披风" },
					{ "15th Anniversary", "15 周年纪念披风" },
					{ "Purple Heart", "紫色心形披风" },
					{ "Follower's", "追随者披风" },
					{ "MCC 15th Year", "MCC 15 周年披风" },
					{ "Minecraft Experience", "村民救援披风" },
					{ "Mojang Office", "Mojang 办公室披风" },
					{ "Home", "家园披风" },
					{ "Menace", "入侵披风" },
					{ "Yearn", "渴望披风" },
					{ "Common", "普通披风" },
					{ "Pan", "薄煎饼披风" },
					{ "Founder's", "创始人披风" },
					{ "Copper", "铜披风" },
					{ "Zombie Horse", "僵尸马披风" },
					{ "Builder", "建造者披风" },
					{ "Crafter", "工匠披风" },
					{ "Aurora", "极光披风" }
				};
				List<IMyRadio> list = new List<IMyRadio>
				{
					new MyRadioBox
					{
						Text = "无披风",
						Checked = !_0024VB_0024Local_SkinData["capes"].Any([SpecialName] (JToken c) => Operators.CompareString(c["state"]?.ToString(), "ACTIVE", TextCompare: false) == 0)
					}
				};
				foreach (JToken item in (IEnumerable<JToken>)_0024VB_0024Local_SkinData["capes"])
				{
					string text = item["alias"].ToString();
					if (dictionary.ContainsKey(text))
					{
						text = dictionary[text];
					}
					list.Add(new MyRadioBox
					{
						Text = text,
						Checked = (Operators.CompareString(item["state"]?.ToString(), "ACTIVE", TextCompare: false) == 0)
					});
				}
				_0024VB_0024Local_SelectedIndex = ModMain.MyMsgBoxSelect(list, "选择披风", "确定", "取消");
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Logger.Error(ex2, "获取玩家皮肤列表失败", LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\MySkin.xaml.vb");
				ProjectData.ClearProjectError();
			}
		}
	}

	private string _Address;

	public ModLoader.LoaderTask<(string, string), string> Loader;

	private bool IsSkinMouseDown;

	private bool IsChanging;

	public string Address
	{
		get
		{
			return _Address;
		}
		set
		{
			_Address = value;
			ToolTip = ((Operators.CompareString(_Address, "", TextCompare: false) == 0) ? "加载中" : "点击更换皮肤（右键查看更多选项）");
		}
	}

	public bool HasCape
	{
		get
		{
			return BtnSkinCape.Visibility == Visibility.Collapsed;
		}
		set
		{
			if (value)
			{
				BtnSkinCape.Visibility = Visibility.Visible;
			}
			else
			{
				BtnSkinCape.Visibility = Visibility.Collapsed;
			}
		}
	}

	[field: AccessedThroughProperty("ShadowSkin")]
	internal virtual DropShadowEffect ShadowSkin
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnSkinSave")]
	internal virtual MyMenuItem BtnSkinSave
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RoutedEventHandler value2 = [SpecialName] (object a0, RoutedEventArgs a1) =>
			{
				BtnSkinSave_Click();
			};
			RoutedEventHandler value3 = [SpecialName] (object a0, RoutedEventArgs a1) =>
			{
				BtnSkinSave_Checked((MyMenuItem)a0, a1);
			};
			MyMenuItem myMenuItem = field;
			if (myMenuItem != null)
			{
				myMenuItem.Click -= value2;
				myMenuItem.Checked -= value3;
			}
			field = value;
			myMenuItem = field;
			if (myMenuItem != null)
			{
				myMenuItem.Click += value2;
				myMenuItem.Checked += value3;
			}
		}
	}

	[field: AccessedThroughProperty("BtnSkinRefresh")]
	internal virtual MyMenuItem BtnSkinRefresh
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RoutedEventHandler value2 = [SpecialName] (object a0, RoutedEventArgs a1) =>
			{
				RefreshClick();
			};
			MyMenuItem myMenuItem = field;
			if (myMenuItem != null)
			{
				myMenuItem.Click -= value2;
			}
			field = value;
			myMenuItem = field;
			if (myMenuItem != null)
			{
				myMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("BtnSkinCape")]
	internal virtual MyMenuItem BtnSkinCape
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			RoutedEventHandler value2 = [SpecialName] (object a0, RoutedEventArgs a1) =>
			{
				BtnSkinCape_Click();
			};
			MyMenuItem myMenuItem = field;
			if (myMenuItem != null)
			{
				myMenuItem.Click -= value2;
			}
			field = value;
			myMenuItem = field;
			if (myMenuItem != null)
			{
				myMenuItem.Click += value2;
			}
		}
	}

	[field: AccessedThroughProperty("ImgBack")]
	internal virtual Image ImgBack
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ImgFore")]
	internal virtual Image ImgFore
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public event ClickEventHandler Click;

	public MySkin()
	{
		MouseEnter += PanSkin_MouseEnter;
		MouseLeave += PanSkin_MouseLeave;
		MouseLeftButtonDown += PanSkin_MouseLeftButtonDown;
		MouseLeftButtonUp += PanSkin_MouseLeftButtonUp;
		IsSkinMouseDown = false;
		IsChanging = false;
		InitializeComponent();
	}

	private void PanSkin_MouseEnter(object sender, MouseEventArgs e)
	{
		ModAnimation.AniStart(ModAnimation.AaOpacity(ShadowSkin, 0.8 - ShadowSkin.Opacity, 200, 100), "Skin Shadow");
	}

	private void PanSkin_MouseLeave(object sender, MouseEventArgs e)
	{
		ModAnimation.AniStart(ModAnimation.AaOpacity(ShadowSkin, 0.2 - ShadowSkin.Opacity, 200), "Skin Shadow");
		IsSkinMouseDown = false;
		ModAnimation.AniStart(ModAnimation.AaScaleTransform(this, 1.0 - ((ScaleTransform)RenderTransform).ScaleX, 60, 0, new ModAnimation.AniEaseOutFluent()), "Skin Scale");
	}

	private void PanSkin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		IsSkinMouseDown = true;
		ModAnimation.AniStart(ModAnimation.AaScaleTransform(this, 0.9 - ((ScaleTransform)RenderTransform).ScaleX, 60, 0, new ModAnimation.AniEaseOutFluent()), "Skin Scale");
	}

	private void PanSkin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		ModAnimation.AniStart(ModAnimation.AaScaleTransform(this, 1.0 - ((ScaleTransform)RenderTransform).ScaleX, 60, 0, new ModAnimation.AniEaseOutFluent()), "Skin Scale");
		if (IsSkinMouseDown)
		{
			IsSkinMouseDown = false;
			Click?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	public void BtnSkinSave_Click()
	{
		Save(Loader);
	}

	public static void Save(ModLoader.LoaderTask<(string, string), string> Loader)
	{
		string output = Loader.Output;
		if (Loader.State != ModBase.LoadState.Finished)
		{
			ModMain.Hint("皮肤正在获取中，请稍候！", ModMain.HintType.Red);
			if (Loader.State != ModBase.LoadState.Loading)
			{
				Loader.Start();
			}
			return;
		}
		try
		{
			string text = Dialogs.SaveFile("选取保存皮肤的位置", PathUtils.GetLastPart(output), null, new (string, string)[1] { ("png", "皮肤图片文件") });
			if (text != null && text.Contains("\\"))
			{
				FileUtils.Delete(text);
				if (output.StartsWithF(ModBase.PathImage))
				{
					new MyBitmap(output).Save(text);
				}
				else
				{
					FileUtils.Copy(output, text);
				}
				ModMain.Hint("皮肤保存成功！", ModMain.HintType.Green);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "保存皮肤失败", LogBehavior.Toast, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\MySkin.xaml.vb");
			ProjectData.ClearProjectError();
		}
	}

	private void BtnSkinSave_Checked(MyMenuItem sender, RoutedEventArgs e)
	{
		sender.IsEnabled = Operators.CompareString(Address, "", TextCompare: false) == 0;
	}

	public void Load()
	{
		checked
		{
			try
			{
				Address = Loader.Output;
				if (string.IsNullOrEmpty(Address))
				{
					throw new Exception("皮肤加载器 " + Loader.Name + " 没有输出");
				}
				if (!Address.StartsWithF(ModBase.PathImage) && !FileUtils.Exists(Address))
				{
					throw new FileNotFoundException("皮肤文件未找到", Address);
				}
				MyBitmap myBitmap;
				try
				{
					myBitmap = new MyBitmap(Address);
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Logger.Error(ex2, $"皮肤文件已损坏：{Address}", LogBehavior.Toast, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\MySkin.xaml.vb");
					FileUtils.Delete(Address);
					ProjectData.ClearProjectError();
					return;
				}
				ImgBack.Tag = Address;
				int num = (int)Math.Round((double)myBitmap.Pic.Width / 64.0);
				if (myBitmap.Pic.Width < 32 || myBitmap.Pic.Height < 32)
				{
					ImgFore.Source = null;
					ImgBack.Source = null;
					throw new Exception("图片大小不足，长为 " + Conversions.ToString(myBitmap.Pic.Height) + "，宽为 " + Conversions.ToString(myBitmap.Pic.Width));
				}
				if (myBitmap.Pic.Width >= 64 && myBitmap.Pic.Height >= 32)
				{
					if (myBitmap.Pic.GetPixel(1, 1).A == 0 || myBitmap.Pic.GetPixel(myBitmap.Pic.Width - 1, myBitmap.Pic.Height - 1).A == 0 || myBitmap.Pic.GetPixel(myBitmap.Pic.Width - 2, (int)Math.Round((double)myBitmap.Pic.Height / 2.0 - 2.0)).A == 0 || (myBitmap.Pic.GetPixel(1, 1) != myBitmap.Pic.GetPixel(num * 41, num * 9) && myBitmap.Pic.GetPixel(myBitmap.Pic.Width - 1, myBitmap.Pic.Height - 1) != myBitmap.Pic.GetPixel(num * 41, num * 9) && myBitmap.Pic.GetPixel(myBitmap.Pic.Width - 2, (int)Math.Round((double)myBitmap.Pic.Height / 2.0 - 2.0)) != myBitmap.Pic.GetPixel(num * 41, num * 9)))
					{
						ImgFore.Source = myBitmap.Clip(num * 40, num * 8, num * 8, num * 8);
					}
					else
					{
						ImgFore.Source = null;
					}
				}
				else
				{
					ImgFore.Source = null;
				}
				ImgBack.Source = myBitmap.Clip(num * 8, num * 8, num * 8, num * 8);
				Logger.Info($"载入头像成功：{Loader.Name}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\MySkin.xaml.vb");
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				Logger.Error(ex4, string.Format("载入头像失败（{0},{1}）", Address ?? "null", Loader.Name), LogBehavior.Toast, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\MySkin.xaml.vb");
				ProjectData.ClearProjectError();
			}
		}
	}

	public void Clear()
	{
		Address = "";
		ImgFore.Source = null;
		ImgBack.Source = null;
	}

	public void RefreshClick()
	{
		RefreshCache(Loader);
	}

	public static void RefreshCache(ModLoader.LoaderTask<(string, string), string> sender = null)
	{
		_Closure_0024__22_002D0 arg = default;
		_Closure_0024__22_002D0 CS_0024_003C_003E8__locals3 = new _Closure_0024__22_002D0(arg);
		CS_0024_003C_003E8__locals3._0024VB_0024Local_sender = sender;
		bool flag = false;
		foreach (ModLoader.LoaderTask<(string, string), string> skinLoader in PageLaunchLeft.SkinLoaders)
		{
			if (skinLoader.State == ModBase.LoadState.Loading)
			{
				flag = true;
				break;
			}
		}
		if (ModMain.FrmLaunchLeft != null && flag)
		{
			ModMain.Hint("有正在获取中的皮肤，请稍后再试！");
			return;
		}
		ModBase.RunInThread([SpecialName] () =>
		{
			try
			{
				ModMain.Hint("正在刷新皮肤……");
				Logger.Info("正在清空皮肤缓存", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\MySkin.xaml.vb");
				if (DirectoryUtils.Exists(ModBase.PathTemp + "Cache\\Skin"))
				{
					DirectoryUtils.Delete(ModBase.PathTemp + "Cache\\Skin");
				}
				if (DirectoryUtils.Exists(ModBase.PathTemp + "Cache\\Uuid"))
				{
					DirectoryUtils.Delete(ModBase.PathTemp + "Cache\\Uuid");
				}
				ModBase.IniClearCache(ModBase.PathTemp + "Cache\\Skin\\IndexMs.ini");
				ModBase.IniClearCache(ModBase.PathTemp + "Cache\\Skin\\IndexNide.ini");
				ModBase.IniClearCache(ModBase.PathTemp + "Cache\\Skin\\IndexAuth.ini");
				ModBase.IniClearCache(ModBase.PathTemp + "Cache\\Uuid\\Mojang.ini");
				ModLoader.LoaderTask<(string, string), string>[] array = ((CS_0024_003C_003E8__locals3._0024VB_0024Local_sender == null) ? new ModLoader.LoaderTask<(string, string), string>[2]
				{
					PageLaunchLeft.SkinLegacy,
					PageLaunchLeft.SkinMs
				} : new ModLoader.LoaderTask<(string, string), string>[1] { CS_0024_003C_003E8__locals3._0024VB_0024Local_sender });
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					array[i].WaitForExit(null, null, IsForceRestart: true);
				}
				ModMain.Hint("已刷新皮肤！", ModMain.HintType.Green);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Logger.Error(ex2, "刷新皮肤缓存失败", LogBehavior.Alert, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\MySkin.xaml.vb");
				ProjectData.ClearProjectError();
			}
		});
	}

	public static void ReloadCache(string SkinAddress)
	{
		_Closure_0024__23_002D0 arg = default;
		_Closure_0024__23_002D0 CS_0024_003C_003E8__locals3 = new _Closure_0024__23_002D0(arg);
		CS_0024_003C_003E8__locals3._0024VB_0024Local_SkinAddress = SkinAddress;
		ModBase.RunInThread([SpecialName] () =>
		{
			try
			{
				ModBase.WriteIni(ModBase.PathTemp + "Cache\\Skin\\IndexMs.ini", Settings.Get<string>("CacheMsV2Uuid"), CS_0024_003C_003E8__locals3._0024VB_0024Local_SkinAddress);
				Logger.Info(string.Format("已写入皮肤地址缓存 {0} -> {1}", Settings.Get<string>("CacheMsV2Uuid"), CS_0024_003C_003E8__locals3._0024VB_0024Local_SkinAddress), LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\MySkin.xaml.vb");
				ModLoader.LoaderTask<(string, string), string>[] array = new ModLoader.LoaderTask<(string, string), string>[2]
				{
					PageLaunchLeft.SkinMs,
					PageLaunchLeft.SkinLegacy
				};
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					array[i].WaitForExit(null, null, IsForceRestart: true);
				}
				ModMain.Hint("更改皮肤成功！", ModMain.HintType.Green);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Logger.Error(ex2, "更改正版皮肤后刷新皮肤失败", LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\MySkin.xaml.vb");
				ProjectData.ClearProjectError();
			}
		});
	}

	public void BtnSkinCape_Click()
	{
		if (IsChanging)
		{
			ModMain.Hint("正在更改披风中，请稍候！");
			return;
		}
		if (ModLaunch.McLoginMsLoader.State == ModBase.LoadState.Failed)
		{
			ModMain.Hint("登录失败，无法更改披风！", ModMain.HintType.Red);
			return;
		}
		if (ModLaunch.McLoginMsLoader.State != ModBase.LoadState.Finished)
		{
			ModMain.Hint("正在获取披风列表，请稍候……");
		}
		IsChanging = true;
		ModBase.RunInNewThread(checked([SpecialName] () =>
		{
			_Closure_0024__28_002D0 obj = default;
			while (true)
			{
				try
				{
					obj = new _Closure_0024__28_002D0(obj);
					if (ModLaunch.McLoginMsLoader.State != ModBase.LoadState.Finished)
					{
						ModLaunch.McLoginMsLoader.WaitForExit(PageLoginMsSkin.GetLoginData());
					}
					if (ModLaunch.McLoginMsLoader.State != ModBase.LoadState.Finished)
					{
						ModMain.Hint("登录失败，无法更改披风！", ModMain.HintType.Red);
					}
					else
					{
						string accessToken = ModLaunch.McLoginMsLoader.Output.AccessToken;
						_ = ModLaunch.McLoginMsLoader.Output;
						obj._0024VB_0024Local_SkinData = (JObject)ModLaunch.McLoginMsLoader.Output.ProfileJson.DeserializeJson();
						obj._0024VB_0024Local_SelectedIndex = null;
						ModBase.RunInUiWait(obj._Lambda_0024__1);
						if (obj._0024VB_0024Local_SelectedIndex.HasValue)
						{
							int? num = obj._0024VB_0024Local_SelectedIndex;
							HttpMethod method = (((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : ((bool?)null)) == true) ? HttpMethod.Delete : HttpMethod.Put);
							num = obj._0024VB_0024Local_SelectedIndex;
							string text = ModNet.NetRequestByClientRetry("https://api.minecraftservices.com/minecraft/profile/capes/active", method, null, ((num.HasValue ? new bool?(num.GetValueOrDefault() == 0) : ((bool?)null)) == true) ? "" : new JObject(new JProperty("capeId", obj._0024VB_0024Local_SkinData["capes"][obj._0024VB_0024Local_SelectedIndex - 1]["id"])).ToString(Formatting.None), "application/json", "*/*", new string[1, 2] { 
							{
								"Authorization",
								"Bearer " + accessToken
							} });
							if (text.Contains("\"errorMessage\""))
							{
								ModMain.Hint("更改披风失败：" + text.DeserializeJson()["errorMessage"].ToString(), ModMain.HintType.Red);
							}
							else
							{
								ModMain.Hint("更改披风成功！", ModMain.HintType.Green);
								foreach (JToken item in (IEnumerable<JToken>)obj._0024VB_0024Local_SkinData["capes"])
								{
									item["state"] = "INACTIVE";
								}
								num = obj._0024VB_0024Local_SelectedIndex;
								if ((num.HasValue ? new bool?(num.GetValueOrDefault() > 0) : ((bool?)null)) == true)
								{
									obj._0024VB_0024Local_SkinData["capes"][obj._0024VB_0024Local_SelectedIndex - 1]["state"] = "ACTIVE";
								}
								ModLaunch.McLoginMsLoader.Output.ProfileJson = obj._0024VB_0024Local_SkinData.ToString();
								Settings.Set("CacheMsV2ProfileJson", ModLaunch.McLoginMsLoader.Output.ProfileJson);
							}
						}
					}
					break;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					if (ex2 is HttpRequestCodeException)
					{
						HttpRequestCodeException ex3 = (HttpRequestCodeException)ex2;
						switch (ex3.StatusCode)
						{
						case HttpStatusCode.BadRequest:
						{
							Logger.Warn(ex2, "更改披风时遭遇 400 错误", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\MySkin.xaml.vb");
							string? response = ex3.Response;
							if (response != null && response.Contains("\"error\""))
							{
								ModMain.Hint("更改披风失败：" + ex3.Response.DeserializeJson()["error"].ToString(), ModMain.HintType.Red);
								ProjectData.ClearProjectError();
								return;
							}
							string? response2 = ex3.Response;
							if (response2 != null && response2.Contains("\"errorMessage\""))
							{
								ModMain.Hint("更改披风失败：" + ex3.Response.DeserializeJson()["errorMessage"].ToString(), ModMain.HintType.Red);
								ProjectData.ClearProjectError();
								return;
							}
							break;
						}
						case HttpStatusCode.Unauthorized:
							Logger.Warn(ex2, "更改披风时遭遇 401 错误", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\MySkin.xaml.vb");
							ModMain.Hint("正在重新登录，将在登录后自动更改披风……");
							ModLaunch.McLoginMsLoader.Start(PageLoginMsSkin.GetLoginData(), IsForceRestart: true);
							ProjectData.ClearProjectError();
							goto end_IL_033a;
						}
					}
					else if (ex2.IsBadNetwork())
					{
						ModMain.Hint("更改披风失败：连接 Mojang 服务器超时，请稍后再试，或使用 VPN 改善网络环境", ModMain.HintType.Red);
					}
					else
					{
						Logger.Error(ex2, "更改披风失败", LogBehavior.Toast, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageLaunch\\MySkin.xaml.vb");
					}
					ProjectData.ClearProjectError();
					break;
					end_IL_033a:;
				}
				finally
				{
					IsChanging = false;
				}
			}
		}), "Cape Change");
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
