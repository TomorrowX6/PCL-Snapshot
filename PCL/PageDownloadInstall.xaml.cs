using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using MeloongCore;
using MeloongCore.Extensions;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCLCS;

namespace PCL;

[DesignerGenerated]
public partial class PageDownloadInstall : MyPageRight, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal new sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static VB_0024AnonymousDelegate_10 _0024I3_002D0;

		public static Action<ModLoader.LoaderTask<string, ModDownload.DlClientListResult>> _0024IR3_002D3;

		public static Func<JObject, DateTime> _0024I35_002D0;

		public static Func<ModDownload.DlOptiFineListEntry, ModDownload.DlOptiFineListEntry, bool> _0024I41_002D0;

		public static Func<ModDownload.DlForgeVersionEntry, ModDownload.DlForgeVersionEntry> _0024I51_002D1;

		public static Func<ResourceVersion, DateTime> _0024I68_002D0;

		public static Func<ResourceVersion, DateTime> _0024I75_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__R3_002D3(ModLoader.LoaderTask<string, ModDownload.DlClientListResult> a0)
		{
			((VB_0024AnonymousDelegate_10)([SpecialName] () =>
			{
				throw new Exception("为遵守相关法律法规，PCL 暂时不再提供 MC 下载功能，非常抱歉 qwq……");
			}))();
		}

		[SpecialName]
		internal void _Lambda_0024__3_002D0()
		{
			throw new Exception("为遵守相关法律法规，PCL 暂时不再提供 MC 下载功能，非常抱歉 qwq……");
		}

		[SpecialName]
		internal DateTime _Lambda_0024__35_002D0(JObject j)
		{
			return j["releaseTime"].Value<DateTime>();
		}

		[SpecialName]
		internal bool _Lambda_0024__41_002D0(ModDownload.DlOptiFineListEntry Left, ModDownload.DlOptiFineListEntry Right)
		{
			if (!Left.IsPreview && Right.IsPreview)
			{
				return true;
			}
			if (Left.IsPreview && !Right.IsPreview)
			{
				return false;
			}
			return McUtils.CompareVersionGE(Left.DisplayName, Right.DisplayName);
		}

		[SpecialName]
		internal ModDownload.DlForgeVersionEntry _Lambda_0024__51_002D1(ModDownload.DlForgeVersionEntry v)
		{
			return v;
		}

		[SpecialName]
		internal DateTime _Lambda_0024__68_002D0(ResourceVersion v)
		{
			return v.ReleaseDate;
		}

		[SpecialName]
		internal DateTime _Lambda_0024__75_002D0(ResourceVersion v)
		{
			return v.ReleaseDate;
		}
	}

	private bool IsLoad;

	public bool IsInSelectPage;

	public string VanillaName;

	public JObject VanillaData;

	public string VanillaIcon;

	public ModDownload.DlOptiFineListEntry SelectedOptiFine;

	public ModDownload.DlLiteLoaderListEntry SelectedLiteLoader;

	public ModDownload.DlForgeVersionEntry SelectedForge;

	public ModDownload.DlNeoForgeListEntry SelectedNeoForge;

	public string SelectedFabric;

	public ResourceVersion SelectedFabricApi;

	public ResourceVersion SelectedOptiFabric;

	public bool IsSelectNameEdited;

	public JArray MinecraftVersions;

	public static string VersionWaitingSelect = null;

	public bool AutoSelectedFabricApi;

	public bool AutoSelectedOptiFabric;

	[SpecialName]
	private bool _0024STATIC_0024ReloadSelected_00242001_0024Ongoing;

	[SpecialName]
	private StaticLocalInitFlag _0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init;

	private int VanillaDrop => McVersion.VersionToDrop(VanillaName);

	[field: AccessedThroughProperty("PanAllBack")]
	internal virtual Grid PanAllBack
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanBack")]
	internal virtual MyScrollViewer PanBack
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanInner")]
	internal virtual Grid PanInner
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanMinecraft")]
	internal virtual StackPanel PanMinecraft
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanSelect")]
	internal virtual StackPanel PanSelect
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CardSelectName")]
	internal virtual MyCard CardSelectName
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnBack")]
	internal virtual MyIconButton BtnBack
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = [SpecialName] (object a0, EventArgs a1) =>
			{
				ExitSelectPage();
			};
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

	[field: AccessedThroughProperty("ImgLogo")]
	internal virtual MyImage ImgLogo
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("TextSelectName")]
	internal virtual MyTextBox TextSelectName
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			TextChangedEventHandler value2 = TextSelectName_TextChanged;
			MyTextBox.ValidateChangedEventHandler obj = TextSelectName_ValidateChanged;
			KeyEventHandler value3 = TextSelectName_KeyDown;
			MyTextBox myTextBox = field;
			if (myTextBox != null)
			{
				myTextBox.TextChanged -= value2;
				MyTextBox.ValidateChanged -= obj;
				myTextBox.KeyDown -= value3;
			}
			field = value;
			myTextBox = field;
			if (myTextBox != null)
			{
				myTextBox.TextChanged += value2;
				MyTextBox.ValidateChanged += obj;
				myTextBox.KeyDown += value3;
			}
		}
	}

	[field: AccessedThroughProperty("LabSelectName")]
	internal virtual TextBlock LabSelectName
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnOriginalNameRestore")]
	internal virtual MyIconButton BtnOriginalNameRestore
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("HintSelectName")]
	internal virtual MyHint HintSelectName
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("HintFabricAPI")]
	internal virtual MyHint HintFabricAPI
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("HintOptiFabric")]
	internal virtual MyHint HintOptiFabric
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("HintOptiFabricOld")]
	internal virtual MyHint HintOptiFabricOld
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("HintModOptiFine")]
	internal virtual MyHint HintModOptiFine
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CardMinecraft")]
	internal virtual MyCard CardMinecraft
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanMinecraftInfo")]
	internal virtual Grid PanMinecraftInfo
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ImgMinecraft")]
	internal virtual MyImage ImgMinecraft
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabMinecraftVersion")]
	internal virtual TextBlock LabMinecraftVersion
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanMinecraftCompare")]
	internal virtual Grid PanMinecraftCompare
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ImgMinecraftOld")]
	internal virtual MyImage ImgMinecraftOld
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabMinecraftOld")]
	internal virtual TextBlock LabMinecraftOld
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ImgMinecraftNew")]
	internal virtual MyImage ImgMinecraftNew
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabMinecraftNew")]
	internal virtual TextBlock LabMinecraftNew
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnMinecraftRestore")]
	internal virtual MyIconButton BtnMinecraftRestore
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CardForge")]
	internal virtual MyCard CardForge
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				ReloadSelected();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardForge_PreviewSwap;
			MyCard myCard = field;
			if (myCard != null)
			{
				myCard.Swap -= obj;
				myCard.PreviewSwap -= obj2;
			}
			field = value;
			myCard = field;
			if (myCard != null)
			{
				myCard.Swap += obj;
				myCard.PreviewSwap += obj2;
			}
		}
	}

	[field: AccessedThroughProperty("PanForge")]
	internal virtual StackPanel PanForge
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanForgeInfo")]
	internal virtual Grid PanForgeInfo
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ImgForge")]
	internal virtual MyImage ImgForge
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabForge")]
	internal virtual TextBlock LabForge
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanForgeCompare")]
	internal virtual Grid PanForgeCompare
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabForgeOld")]
	internal virtual TextBlock LabForgeOld
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnForgeClear")]
	internal virtual MyIconButton BtnForgeClear
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = Forge_Clear;
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

	[field: AccessedThroughProperty("BtnForgeRestore")]
	internal virtual MyIconButton BtnForgeRestore
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CardNeoForge")]
	internal virtual MyCard CardNeoForge
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				ReloadSelected();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardNeoForge_PreviewSwap;
			MyCard myCard = field;
			if (myCard != null)
			{
				myCard.Swap -= obj;
				myCard.PreviewSwap -= obj2;
			}
			field = value;
			myCard = field;
			if (myCard != null)
			{
				myCard.Swap += obj;
				myCard.PreviewSwap += obj2;
			}
		}
	}

	[field: AccessedThroughProperty("PanNeoForge")]
	internal virtual StackPanel PanNeoForge
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanNeoForgeInfo")]
	internal virtual Grid PanNeoForgeInfo
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ImgNeoForge")]
	internal virtual MyImage ImgNeoForge
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabNeoForge")]
	internal virtual TextBlock LabNeoForge
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanNeoForgeCompare")]
	internal virtual Grid PanNeoForgeCompare
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabNeoForgeOld")]
	internal virtual TextBlock LabNeoForgeOld
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnNeoForgeClear")]
	internal virtual MyIconButton BtnNeoForgeClear
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = NeoForge_Clear;
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

	[field: AccessedThroughProperty("BtnNeoForgeRestore")]
	internal virtual MyIconButton BtnNeoForgeRestore
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CardFabric")]
	internal virtual MyCard CardFabric
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				ReloadSelected();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardFabric_PreviewSwap;
			MyCard myCard = field;
			if (myCard != null)
			{
				myCard.Swap -= obj;
				myCard.PreviewSwap -= obj2;
			}
			field = value;
			myCard = field;
			if (myCard != null)
			{
				myCard.Swap += obj;
				myCard.PreviewSwap += obj2;
			}
		}
	}

	[field: AccessedThroughProperty("PanFabric")]
	internal virtual StackPanel PanFabric
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanFabricInfo")]
	internal virtual Grid PanFabricInfo
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ImgFabric")]
	internal virtual MyImage ImgFabric
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabFabric")]
	internal virtual TextBlock LabFabric
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanFabricCompare")]
	internal virtual Grid PanFabricCompare
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabFabricOld")]
	internal virtual TextBlock LabFabricOld
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnFabricClear")]
	internal virtual MyIconButton BtnFabricClear
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = Fabric_Clear;
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

	[field: AccessedThroughProperty("BtnFabricRestore")]
	internal virtual MyIconButton BtnFabricRestore
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CardFabricApi")]
	internal virtual MyCard CardFabricApi
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				ReloadSelected();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardFabricApi_PreviewSwap;
			MyCard myCard = field;
			if (myCard != null)
			{
				myCard.Swap -= obj;
				myCard.PreviewSwap -= obj2;
			}
			field = value;
			myCard = field;
			if (myCard != null)
			{
				myCard.Swap += obj;
				myCard.PreviewSwap += obj2;
			}
		}
	}

	[field: AccessedThroughProperty("PanFabricApi")]
	internal virtual StackPanel PanFabricApi
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanFabricApiInfo")]
	internal virtual Grid PanFabricApiInfo
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ImgFabricApi")]
	internal virtual MyImage ImgFabricApi
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabFabricApi")]
	internal virtual TextBlock LabFabricApi
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanFabricApiCompare")]
	internal virtual Grid PanFabricApiCompare
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabFabricApiOld")]
	internal virtual TextBlock LabFabricApiOld
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnFabricApiClear")]
	internal virtual MyIconButton BtnFabricApiClear
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = FabricApi_Clear;
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

	[field: AccessedThroughProperty("BtnFabricApiRestore")]
	internal virtual MyIconButton BtnFabricApiRestore
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CardOptiFine")]
	internal virtual MyCard CardOptiFine
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				ReloadSelected();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardOptiFine_PreviewSwap;
			MyCard myCard = field;
			if (myCard != null)
			{
				myCard.Swap -= obj;
				myCard.PreviewSwap -= obj2;
			}
			field = value;
			myCard = field;
			if (myCard != null)
			{
				myCard.Swap += obj;
				myCard.PreviewSwap += obj2;
			}
		}
	}

	[field: AccessedThroughProperty("PanOptiFine")]
	internal virtual StackPanel PanOptiFine
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanOptiFineInfo")]
	internal virtual Grid PanOptiFineInfo
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ImgOptiFine")]
	internal virtual MyImage ImgOptiFine
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabOptiFine")]
	internal virtual TextBlock LabOptiFine
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanOptiFineCompare")]
	internal virtual Grid PanOptiFineCompare
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabOptiFineOld")]
	internal virtual TextBlock LabOptiFineOld
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnOptiFineClear")]
	internal virtual MyIconButton BtnOptiFineClear
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = OptiFine_Clear;
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

	[field: AccessedThroughProperty("BtnOptiFineRestore")]
	internal virtual MyIconButton BtnOptiFineRestore
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CardOptiFabric")]
	internal virtual MyCard CardOptiFabric
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				ReloadSelected();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardOptiFabric_PreviewSwap;
			MyCard myCard = field;
			if (myCard != null)
			{
				myCard.Swap -= obj;
				myCard.PreviewSwap -= obj2;
			}
			field = value;
			myCard = field;
			if (myCard != null)
			{
				myCard.Swap += obj;
				myCard.PreviewSwap += obj2;
			}
		}
	}

	[field: AccessedThroughProperty("PanOptiFabric")]
	internal virtual StackPanel PanOptiFabric
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanOptiFabricInfo")]
	internal virtual Grid PanOptiFabricInfo
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ImgOptiFabric")]
	internal virtual MyImage ImgOptiFabric
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabOptiFabric")]
	internal virtual TextBlock LabOptiFabric
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanOptiFabricCompare")]
	internal virtual Grid PanOptiFabricCompare
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabOptiFabricOld")]
	internal virtual TextBlock LabOptiFabricOld
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnOptiFabricClear")]
	internal virtual MyIconButton BtnOptiFabricClear
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = OptiFabric_Clear;
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

	[field: AccessedThroughProperty("BtnOptiFabricRestore")]
	internal virtual MyIconButton BtnOptiFabricRestore
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("CardLiteLoader")]
	internal virtual MyCard CardLiteLoader
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				ReloadSelected();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardLiteLoader_PreviewSwap;
			MyCard myCard = field;
			if (myCard != null)
			{
				myCard.Swap -= obj;
				myCard.PreviewSwap -= obj2;
			}
			field = value;
			myCard = field;
			if (myCard != null)
			{
				myCard.Swap += obj;
				myCard.PreviewSwap += obj2;
			}
		}
	}

	[field: AccessedThroughProperty("PanLiteLoader")]
	internal virtual StackPanel PanLiteLoader
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanLiteLoaderInfo")]
	internal virtual Grid PanLiteLoaderInfo
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("ImgLiteLoader")]
	internal virtual MyImage ImgLiteLoader
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabLiteLoader")]
	internal virtual TextBlock LabLiteLoader
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("PanLiteLoaderCompare")]
	internal virtual Grid PanLiteLoaderCompare
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LabLiteLoaderOld")]
	internal virtual TextBlock LabLiteLoaderOld
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnLiteLoaderClear")]
	internal virtual MyIconButton BtnLiteLoaderClear
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = LiteLoader_Clear;
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

	[field: AccessedThroughProperty("BtnLiteLoaderRestore")]
	internal virtual MyIconButton BtnLiteLoaderRestore
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("BtnStart")]
	internal virtual MyExtraTextButton BtnStart
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyExtraTextButton.ClickEventHandler obj = [SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				BtnStart_Click();
			};
			MyExtraTextButton myExtraTextButton = field;
			if (myExtraTextButton != null)
			{
				myExtraTextButton.Click -= obj;
			}
			field = value;
			myExtraTextButton = field;
			if (myExtraTextButton != null)
			{
				myExtraTextButton.Click += obj;
			}
		}
	}

	[field: AccessedThroughProperty("PanLoad")]
	internal virtual MyCard PanLoad
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LoadMinecraft")]
	internal virtual MyLoading LoadMinecraft
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	[field: AccessedThroughProperty("LoadOptiFine")]
	internal virtual MyLoading LoadOptiFine
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				ReloadSelected();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				OptiFine_Loaded();
			};
			MyLoading myLoading = field;
			if (myLoading != null)
			{
				myLoading.StateChanged -= obj;
				myLoading.StateChanged -= obj2;
			}
			field = value;
			myLoading = field;
			if (myLoading != null)
			{
				myLoading.StateChanged += obj;
				myLoading.StateChanged += obj2;
			}
		}
	}

	[field: AccessedThroughProperty("LoadForge")]
	internal virtual MyLoading LoadForge
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				ReloadSelected();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				Forge_Loaded();
			};
			MyLoading myLoading = field;
			if (myLoading != null)
			{
				myLoading.StateChanged -= obj;
				myLoading.StateChanged -= obj2;
			}
			field = value;
			myLoading = field;
			if (myLoading != null)
			{
				myLoading.StateChanged += obj;
				myLoading.StateChanged += obj2;
			}
		}
	}

	[field: AccessedThroughProperty("LoadNeoForge")]
	internal virtual MyLoading LoadNeoForge
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				ReloadSelected();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				NeoForge_Loaded();
			};
			MyLoading myLoading = field;
			if (myLoading != null)
			{
				myLoading.StateChanged -= obj;
				myLoading.StateChanged -= obj2;
			}
			field = value;
			myLoading = field;
			if (myLoading != null)
			{
				myLoading.StateChanged += obj;
				myLoading.StateChanged += obj2;
			}
		}
	}

	[field: AccessedThroughProperty("LoadLiteLoader")]
	internal virtual MyLoading LoadLiteLoader
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				ReloadSelected();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				LiteLoader_Loaded();
			};
			MyLoading myLoading = field;
			if (myLoading != null)
			{
				myLoading.StateChanged -= obj;
				myLoading.StateChanged -= obj2;
			}
			field = value;
			myLoading = field;
			if (myLoading != null)
			{
				myLoading.StateChanged += obj;
				myLoading.StateChanged += obj2;
			}
		}
	}

	[field: AccessedThroughProperty("LoadFabric")]
	internal virtual MyLoading LoadFabric
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				ReloadSelected();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				Fabric_Loaded();
			};
			MyLoading myLoading = field;
			if (myLoading != null)
			{
				myLoading.StateChanged -= obj;
				myLoading.StateChanged -= obj2;
			}
			field = value;
			myLoading = field;
			if (myLoading != null)
			{
				myLoading.StateChanged += obj;
				myLoading.StateChanged += obj2;
			}
		}
	}

	[field: AccessedThroughProperty("LoadFabricApi")]
	internal virtual MyLoading LoadFabricApi
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				ReloadSelected();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				FabricApi_Loaded();
			};
			MyLoading myLoading = field;
			if (myLoading != null)
			{
				myLoading.StateChanged -= obj;
				myLoading.StateChanged -= obj2;
			}
			field = value;
			myLoading = field;
			if (myLoading != null)
			{
				myLoading.StateChanged += obj;
				myLoading.StateChanged += obj2;
			}
		}
	}

	[field: AccessedThroughProperty("LoadOptiFabric")]
	internal virtual MyLoading LoadOptiFabric
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				ReloadSelected();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				OptiFabric_Loaded();
			};
			MyLoading myLoading = field;
			if (myLoading != null)
			{
				myLoading.StateChanged -= obj;
				myLoading.StateChanged -= obj2;
			}
			field = value;
			myLoading = field;
			if (myLoading != null)
			{
				myLoading.StateChanged += obj;
				myLoading.StateChanged += obj2;
			}
		}
	}

	public PageDownloadInstall()
	{
		Initialized += [SpecialName] (object a0, EventArgs a1) =>
		{
			LoaderInit();
		};
		Loaded += [SpecialName] (object a0, RoutedEventArgs a1) =>
		{
			Init();
		};
		IsLoad = false;
		IsInSelectPage = false;
		SelectedOptiFine = null;
		SelectedLiteLoader = null;
		SelectedForge = null;
		SelectedNeoForge = null;
		SelectedFabric = null;
		SelectedFabricApi = null;
		SelectedOptiFabric = null;
		IsSelectNameEdited = false;
		AutoSelectedFabricApi = false;
		AutoSelectedOptiFabric = false;
		InitializeComponent();
	}

	public void ControlInit()
	{
		DisabledPageAnimControls.Add(BtnStart);
		LoadOptiFine.State = ModDownload.DlOptiFineListLoader;
		LoadLiteLoader.State = ModDownload.DlLiteLoaderListLoader;
		LoadFabric.State = ModDownload.DlFabricListLoader;
		LoadFabricApi.State = ModDownload.DlFabricApiLoader;
		LoadNeoForge.State = ModDownload.DlNeoForgeListLoader;
		LoadOptiFabric.State = ModDownload.DlOptiFabricLoader;
		ModDownloadLib.McDownloadForgeRecommendedRefresh();
	}

	public virtual void LoaderInit()
	{
		ControlInit();
		PageLoaderInit(LoadMinecraft, PanLoad, PanAllBack, null, ModDownload.DlClientListLoader, [SpecialName] (ModLoader.LoaderTask<string, ModDownload.DlClientListResult> a0) =>
		{
			LoadMinecraft_OnFinish();
		});
	}

	public virtual void Init()
	{
		if (IsLoad)
		{
			IsSelectNameEdited = false;
			ExitSelectPage();
			if (ModDownload.DlClientListLoader.State == ModBase.LoadState.Finished)
			{
				TrySelectWaitingVersion();
			}
		}
		IsLoad = true;
		PanBack.ScrollToHome();
		ModDownload.DlOptiFineListLoader.Start();
		ModDownload.DlLiteLoaderListLoader.Start();
		ModDownload.DlFabricListLoader.Start();
		ModDownload.DlNeoForgeListLoader.Start();
		TextSelectName.ValidateRules = new Collection<ValidateBase>
		{
			new ValidateFolderName(ModMinecraft.McFolderSelected + "versions")
		};
		TextSelectName.Validate();
		ReloadSelected();
	}

	public void PrepareSelectPage()
	{
		IsInSelectPage = true;
		PanInner.Margin = new Thickness(25.0, 10.0, 25.0, 40.0);
		PanSelect.Visibility = Visibility.Visible;
		PanSelect.IsHitTestVisible = true;
		PanMinecraft.IsHitTestVisible = false;
		PanBack.IsHitTestVisible = false;
		PanBack.ScrollToHome();
		DisabledPageAnimControls.Remove(BtnStart);
		BtnStart.Show = true;
		MyCard[] array = new MyCard[7] { CardOptiFine, CardLiteLoader, CardForge, CardNeoForge, CardFabric, CardFabricApi, CardOptiFabric };
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			array[i].IsSwapped = true;
		}
		foreach (FrameworkElement allAnimControl in GetAllAnimControls(PanSelect))
		{
			allAnimControl.Opacity = 1.0;
			if (allAnimControl.RenderTransform == null || allAnimControl.RenderTransform is TranslateTransform)
			{
				allAnimControl.RenderTransform = new TranslateTransform();
			}
		}
	}

	private void EnterSelectPage()
	{
		if (!IsInSelectPage)
		{
			AutoSelectedFabricApi = false;
			AutoSelectedOptiFabric = false;
			PrepareSelectPage();
			if (McVersion.IsStandardFormat(VanillaName))
			{
				ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>("DlForgeVersion " + VanillaName, ModDownload.DlForgeVersionMain);
				LoadForge.State = loaderTask;
				loaderTask.Start(VanillaName);
			}
			ModDownload.DlFabricApiLoader.Start();
			ModDownload.DlOptiFabricLoader.Start();
			ModAnimation.AniStart(new ModAnimation.AniData[6]
			{
				ModAnimation.AaOpacity(PanMinecraft, 0.0 - PanMinecraft.Opacity, 70, 10),
				ModAnimation.AaTranslateX(PanMinecraft, -50.0 - ((TranslateTransform)PanMinecraft.RenderTransform).X, 90, 10),
				ModAnimation.AaCode([SpecialName] () =>
				{
					PanBack.ScrollToHome();
					ReloadComponentLists();
					PanMinecraft.Visibility = Visibility.Collapsed;
				}, 0, After: true),
				ModAnimation.AaOpacity(PanSelect, 1.0 - PanSelect.Opacity, 70, 100),
				ModAnimation.AaTranslateX(PanSelect, 0.0 - ((TranslateTransform)PanSelect.RenderTransform).X, 160, 100, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.ExtraStrong)),
				ModAnimation.AaCode([SpecialName] () =>
				{
					PanBack.IsHitTestVisible = true;
				}, 0, After: true)
			}, "FrmDownloadInstall SelectPageSwitch", RefreshTime: true);
		}
	}

	public void ReloadComponentLists()
	{
		TextSelectName.Validate();
		OptiFine_Loaded();
		LiteLoader_Loaded();
		Forge_Loaded();
		NeoForge_Loaded();
		Fabric_Loaded();
		FabricApi_Loaded();
		OptiFabric_Loaded();
		ReloadSelected();
	}

	public void ExitSelectPage()
	{
		if (IsInSelectPage)
		{
			IsInSelectPage = false;
			PanInner.Margin = new Thickness(25.0, 10.0, 25.0, 25.0);
			DisabledPageAnimControls.Add(BtnStart);
			BtnStart.Show = false;
			ClearSelected();
			PanMinecraft.Visibility = Visibility.Visible;
			PanSelect.IsHitTestVisible = false;
			PanMinecraft.IsHitTestVisible = true;
			PanBack.IsHitTestVisible = false;
			PanBack.ScrollToHome();
			ModAnimation.AniStart(new ModAnimation.AniData[6]
			{
				ModAnimation.AaOpacity(PanSelect, 0.0 - PanSelect.Opacity, 70, 10),
				ModAnimation.AaTranslateX(PanSelect, 50.0 - ((TranslateTransform)PanSelect.RenderTransform).X, 90, 10),
				ModAnimation.AaCode([SpecialName] () =>
				{
					PanBack.ScrollToHome();
				}, 0, After: true),
				ModAnimation.AaOpacity(PanMinecraft, 1.0 - PanMinecraft.Opacity, 70, 100),
				ModAnimation.AaTranslateX(PanMinecraft, 0.0 - ((TranslateTransform)PanMinecraft.RenderTransform).X, 160, 100, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.ExtraStrong)),
				ModAnimation.AaCode([SpecialName] () =>
				{
					PanSelect.Visibility = Visibility.Collapsed;
					PanBack.IsHitTestVisible = true;
				}, 0, After: true)
			}, "FrmDownloadInstall SelectPageSwitch");
		}
	}

	public virtual void MinecraftSelected(MyListItem sender, MouseButtonEventArgs e)
	{
		VanillaName = sender.Title;
		VanillaData = (JObject)sender.Tag;
		VanillaIcon = sender.Logo;
		LabMinecraftVersion.Text = VanillaName;
		EnterSelectPage();
	}

	public virtual void ReloadSelected()
	{
		if (_0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init == null)
		{
			Interlocked.CompareExchange(ref _0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init, new StaticLocalInitFlag(), null);
		}
		bool lockTaken = false;
		try
		{
			Monitor.Enter(_0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init, ref lockTaken);
			if (_0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init.State == 0)
			{
				_0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init.State = 2;
				_0024STATIC_0024ReloadSelected_00242001_0024Ongoing = false;
			}
			else if (_0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init.State == 2)
			{
				throw new IncompleteInitialization();
			}
		}
		finally
		{
			_0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init.State = 1;
			if (lockTaken)
			{
				Monitor.Exit(_0024STATIC_0024ReloadSelected_00242001_0024Ongoing_0024Init);
			}
		}
		if (VanillaName == null || _0024STATIC_0024ReloadSelected_00242001_0024Ongoing)
		{
			return;
		}
		_0024STATIC_0024ReloadSelected_00242001_0024Ongoing = true;
		SelectNameUpdate();
		ImgLogo.Source = GetSelectLogo();
		ImgMinecraft.Source = VanillaIcon;
		string text = LoadOptiFineGetError();
		CardOptiFine.MainSwap.Visibility = ((text != null) ? Visibility.Collapsed : Visibility.Visible);
		if (text != null)
		{
			CardOptiFine.IsSwapped = true;
		}
		SetPanelVisibility(PanOptiFineInfo, CardOptiFine.IsSwapped);
		if (SelectedOptiFine == null)
		{
			BtnOptiFineClear.Visibility = Visibility.Collapsed;
			ImgOptiFine.Visibility = Visibility.Collapsed;
			LabOptiFine.Text = text ?? "可以添加";
			LabOptiFine.Foreground = ModSecret.ColorGray4;
		}
		else
		{
			BtnOptiFineClear.Visibility = Visibility.Visible;
			ImgOptiFine.Visibility = Visibility.Visible;
			LabOptiFine.Text = SelectedOptiFine.DisplayName.Replace(VanillaName + " ", "");
			LabOptiFine.Foreground = ModSecret.ColorGray1;
		}
		if (VanillaDrop >= 130)
		{
			CardLiteLoader.Visibility = Visibility.Collapsed;
		}
		else
		{
			CardLiteLoader.Visibility = Visibility.Visible;
			string text2 = LoadLiteLoaderGetError();
			CardLiteLoader.MainSwap.Visibility = ((text2 != null) ? Visibility.Collapsed : Visibility.Visible);
			if (text2 != null)
			{
				CardLiteLoader.IsSwapped = true;
			}
			SetPanelVisibility(PanLiteLoaderInfo, CardLiteLoader.IsSwapped);
			if (SelectedLiteLoader == null)
			{
				BtnLiteLoaderClear.Visibility = Visibility.Collapsed;
				ImgLiteLoader.Visibility = Visibility.Collapsed;
				LabLiteLoader.Text = text2 ?? "可以添加";
				LabLiteLoader.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				BtnLiteLoaderClear.Visibility = Visibility.Visible;
				ImgLiteLoader.Visibility = Visibility.Visible;
				LabLiteLoader.Text = SelectedLiteLoader.Inherit;
				LabLiteLoader.Foreground = ModSecret.ColorGray1;
			}
		}
		if (!McVersion.IsStandardFormat(VanillaName))
		{
			CardForge.Visibility = Visibility.Collapsed;
		}
		else
		{
			CardForge.Visibility = Visibility.Visible;
			string text3 = LoadForgeGetError();
			CardForge.MainSwap.Visibility = ((text3 != null) ? Visibility.Collapsed : Visibility.Visible);
			if (text3 != null)
			{
				CardForge.IsSwapped = true;
			}
			SetPanelVisibility(PanForgeInfo, CardForge.IsSwapped);
			if (SelectedForge == null)
			{
				BtnForgeClear.Visibility = Visibility.Collapsed;
				ImgForge.Visibility = Visibility.Collapsed;
				LabForge.Text = text3 ?? "可以添加";
				LabForge.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				BtnForgeClear.Visibility = Visibility.Visible;
				ImgForge.Visibility = Visibility.Visible;
				LabForge.Text = SelectedForge.VersionName;
				LabForge.Foreground = ModSecret.ColorGray1;
			}
		}
		if (DateTime.Compare(VanillaData["releaseTime"].ToObject<DateTime>(), new DateTime(2023, 6, 11)) < 0)
		{
			CardNeoForge.Visibility = Visibility.Collapsed;
		}
		else
		{
			CardNeoForge.Visibility = Visibility.Visible;
			string text4 = LoadNeoForgeGetError();
			CardNeoForge.MainSwap.Visibility = ((text4 != null) ? Visibility.Collapsed : Visibility.Visible);
			if (text4 != null)
			{
				CardNeoForge.IsSwapped = true;
			}
			SetPanelVisibility(PanNeoForgeInfo, CardNeoForge.IsSwapped);
			if (SelectedNeoForge == null)
			{
				BtnNeoForgeClear.Visibility = Visibility.Collapsed;
				ImgNeoForge.Visibility = Visibility.Collapsed;
				LabNeoForge.Text = text4 ?? "可以添加";
				LabNeoForge.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				BtnNeoForgeClear.Visibility = Visibility.Visible;
				ImgNeoForge.Visibility = Visibility.Visible;
				LabNeoForge.Text = SelectedNeoForge.VersionName;
				LabNeoForge.Foreground = ModSecret.ColorGray1;
			}
		}
		if (VanillaDrop <= 130)
		{
			CardFabric.Visibility = Visibility.Collapsed;
		}
		else
		{
			CardFabric.Visibility = Visibility.Visible;
			string text5 = LoadFabricGetError();
			CardFabric.MainSwap.Visibility = ((text5 != null) ? Visibility.Collapsed : Visibility.Visible);
			if (text5 != null)
			{
				CardFabric.IsSwapped = true;
			}
			SetPanelVisibility(PanFabricInfo, CardFabric.IsSwapped);
			if (SelectedFabric == null)
			{
				BtnFabricClear.Visibility = Visibility.Collapsed;
				ImgFabric.Visibility = Visibility.Collapsed;
				LabFabric.Text = text5 ?? "可以添加";
				LabFabric.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				BtnFabricClear.Visibility = Visibility.Visible;
				ImgFabric.Visibility = Visibility.Visible;
				LabFabric.Text = SelectedFabric.Replace("+build", "");
				LabFabric.Foreground = ModSecret.ColorGray1;
			}
		}
		if (SelectedFabric == null)
		{
			CardFabricApi.Visibility = Visibility.Collapsed;
		}
		else
		{
			CardFabricApi.Visibility = Visibility.Visible;
			string text6 = LoadFabricApiGetError();
			CardFabricApi.MainSwap.Visibility = ((text6 != null) ? Visibility.Collapsed : Visibility.Visible);
			if (text6 != null || SelectedFabric == null)
			{
				CardFabricApi.IsSwapped = true;
			}
			SetPanelVisibility(PanFabricApiInfo, CardFabricApi.IsSwapped);
			if (SelectedFabricApi == null)
			{
				BtnFabricApiClear.Visibility = Visibility.Collapsed;
				ImgFabricApi.Visibility = Visibility.Collapsed;
				LabFabricApi.Text = text6 ?? "可以添加";
				LabFabricApi.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				BtnFabricApiClear.Visibility = Visibility.Visible;
				ImgFabricApi.Visibility = Visibility.Visible;
				LabFabricApi.Text = SelectedFabricApi.Display.Split("]")[1].Replace("Fabric API ", "").Replace(" build ", ".").Split("+")
					.First()
					.Trim();
				LabFabricApi.Foreground = ModSecret.ColorGray1;
			}
		}
		if (SelectedFabric == null || SelectedOptiFine == null)
		{
			CardOptiFabric.Visibility = Visibility.Collapsed;
		}
		else
		{
			CardOptiFabric.Visibility = Visibility.Visible;
			string text7 = LoadOptiFabricGetError();
			CardOptiFabric.MainSwap.Visibility = ((text7 != null) ? Visibility.Collapsed : Visibility.Visible);
			if (text7 != null || SelectedFabric == null)
			{
				CardOptiFabric.IsSwapped = true;
			}
			SetPanelVisibility(PanOptiFabricInfo, CardOptiFabric.IsSwapped);
			if (SelectedOptiFabric == null)
			{
				BtnOptiFabricClear.Visibility = Visibility.Collapsed;
				ImgOptiFabric.Visibility = Visibility.Collapsed;
				LabOptiFabric.Text = text7 ?? "可以添加";
				LabOptiFabric.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				BtnOptiFabricClear.Visibility = Visibility.Visible;
				ImgOptiFabric.Visibility = Visibility.Visible;
				LabOptiFabric.Text = SelectedOptiFabric.Display.Lower().Replace("optifabric-", "").Replace(".jar", "")
					.Trim()
					.TrimStart('v');
				LabOptiFabric.Foreground = ModSecret.ColorGray1;
			}
		}
		if (SelectedFabric != null && SelectedFabricApi == null)
		{
			HintFabricAPI.Visibility = Visibility.Visible;
		}
		else
		{
			HintFabricAPI.Visibility = Visibility.Collapsed;
		}
		if (SelectedFabric != null && SelectedOptiFine != null && SelectedOptiFabric == null)
		{
			if (VanillaDrop >= 140 && VanillaDrop <= 150)
			{
				HintOptiFabric.Visibility = Visibility.Collapsed;
				HintOptiFabricOld.Visibility = Visibility.Visible;
			}
			else
			{
				HintOptiFabric.Visibility = Visibility.Visible;
				HintOptiFabricOld.Visibility = Visibility.Collapsed;
			}
		}
		else
		{
			HintOptiFabric.Visibility = Visibility.Collapsed;
			HintOptiFabricOld.Visibility = Visibility.Collapsed;
		}
		if (VanillaDrop >= 160 && SelectedOptiFine != null && (SelectedForge != null || SelectedFabric != null))
		{
			HintModOptiFine.Visibility = Visibility.Visible;
		}
		else
		{
			HintModOptiFine.Visibility = Visibility.Collapsed;
		}
		_0024STATIC_0024ReloadSelected_00242001_0024Ongoing = false;
	}

	public void ClearSelected()
	{
		VanillaName = null;
		VanillaData = null;
		VanillaIcon = null;
		SelectedOptiFine = null;
		SelectedLiteLoader = null;
		SelectedForge = null;
		SelectedNeoForge = null;
		SelectedFabric = null;
		SelectedFabricApi = null;
		SelectedOptiFabric = null;
		MyIconButton[] array = new MyIconButton[7] { BtnOptiFineClear, BtnLiteLoaderClear, BtnForgeClear, BtnNeoForgeClear, BtnFabricClear, BtnFabricApiClear, BtnOptiFabricClear };
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			array[i].Visibility = Visibility.Collapsed;
		}
	}

	private void SetPanelVisibility(Grid Panel, bool IsVisible)
	{
		if (!Operators.ConditionalCompareObjectEqual(Panel.Tag, IsVisible.ToString(), TextCompare: false))
		{
			Panel.Tag = IsVisible.ToString();
			if (IsVisible)
			{
				ModAnimation.AniStart(new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(Panel, 0.0 - ((TranslateTransform)Panel.RenderTransform).Y, 150, 0, new ModAnimation.AniEaseOutFluent()),
					ModAnimation.AaOpacity(Panel, 1.0 - Panel.Opacity, 60)
				}, "PageDownloadInstall Visibility " + Panel.Name);
			}
			else
			{
				ModAnimation.AniStart(new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(Panel, 6.0 - ((TranslateTransform)Panel.RenderTransform).Y, 60),
					ModAnimation.AaOpacity(Panel, 0.0 - Panel.Opacity, 60)
				}, "PageDownloadInstall Visibility " + Panel.Name);
			}
		}
	}

	public virtual string GetSelectLogo()
	{
		if (SelectedFabric != null)
		{
			return "pack://application:,,,/images/Blocks/Fabric.png";
		}
		if (SelectedForge != null)
		{
			return "pack://application:,,,/images/Blocks/Anvil.png";
		}
		if (SelectedNeoForge != null)
		{
			return "pack://application:,,,/images/Blocks/NeoForge.png";
		}
		if (SelectedLiteLoader != null)
		{
			return "pack://application:,,,/images/Blocks/Egg.png";
		}
		if (SelectedOptiFine != null)
		{
			return "pack://application:,,,/images/Blocks/GrassPath.png";
		}
		return VanillaIcon;
	}

	public string GetSelectName()
	{
		string text = VanillaName;
		if (SelectedFabric != null)
		{
			text = text + "-Fabric " + SelectedFabric.BeforeFirst("+");
		}
		if (SelectedForge != null)
		{
			text = text + "-Forge_" + SelectedForge.VersionName;
		}
		if (SelectedNeoForge != null)
		{
			text = text + "-NeoForge_" + SelectedNeoForge.VersionName.BeforeFirst("+");
		}
		if (SelectedLiteLoader != null)
		{
			text += "-LiteLoader";
		}
		if (SelectedOptiFine != null)
		{
			text = text + "-OptiFine_" + SelectedOptiFine.DisplayName.Replace(VanillaName + " ", "").Replace(" ", "_");
		}
		return text;
	}

	private void SelectNameUpdate()
	{
		if (!IsSelectNameEdited)
		{
			TextSelectName.Text = GetSelectName();
			IsSelectNameEdited = false;
		}
	}

	private void TextSelectName_TextChanged(object sender, TextChangedEventArgs e)
	{
		IsSelectNameEdited = true;
	}

	private void TextSelectName_ValidateChanged(object sender, EventArgs e)
	{
		BtnStart.IsEnabled = TextSelectName.IsValidated;
		HintSelectName.Text = TextSelectName.ValidateResult;
		HintSelectName.Visibility = (TextSelectName.IsValidated ? Visibility.Collapsed : Visibility.Visible);
	}

	private void LoadMinecraft_OnFinish()
	{
		MinecraftVersions = (JArray)ModDownload.DlClientListLoader.Output.Value["versions"].DeepClone();
		ShowMinecraftVersionList();
		TrySelectWaitingVersion();
	}

	public virtual void ShowMinecraftVersionList()
	{
		ExitSelectPage();
		try
		{
			Dictionary<string, List<JObject>> dictionary = new Dictionary<string, List<JObject>>
			{
				{
					"正式版",
					new List<JObject>()
				},
				{
					"预览版",
					new List<JObject>()
				},
				{
					"远古版",
					new List<JObject>()
				},
				{
					"愚人节版",
					new List<JObject>()
				}
			};
			foreach (JObject minecraftVersion in MinecraftVersions)
			{
				string key;
				switch ((string?)minecraftVersion["type"])
				{
				case "release":
					key = "正式版";
					break;
				case "snapshot":
					key = "预览版";
					if (minecraftVersion["id"].ToString().StartsWithF("1.") && !minecraftVersion["id"].ToString().Lower().Contains("combat") && !minecraftVersion["id"].ToString().Lower().Contains("rc") && !minecraftVersion["id"].ToString().Lower().Contains("experimental") && !minecraftVersion["id"].ToString().Lower().Contains("pre"))
					{
						key = "正式版";
						minecraftVersion["type"] = "release";
					}
					switch (minecraftVersion["id"].ToString().Lower())
					{
					case "20w14infinite":
					case "20w14∞":
						key = "愚人节版";
						minecraftVersion["id"] = "20w14∞";
						minecraftVersion["type"] = "special";
						minecraftVersion.Add("lore", ModMinecraft.GetMcFoolName((string?)minecraftVersion["id"]));
						break;
					case "3d shareware v1.34":
					case "1.rv-pre1":
					case "15w14a":
					case "2.0":
					case "22w13oneblockatatime":
					case "23w13a_or_b":
					case "24w14potato":
					case "25w14craftmine":
					case "26w14a":
						key = "愚人节版";
						minecraftVersion["type"] = "special";
						minecraftVersion.Add("lore", ModMinecraft.GetMcFoolName((string?)minecraftVersion["id"]));
						break;
					default:
					{
						DateTime dateTime = minecraftVersion["releaseTime"].Value<DateTime>().ToUniversalTime().AddHours(2.0);
						if (dateTime.Month == 4 && dateTime.Day == 1)
						{
							key = "愚人节版";
							minecraftVersion["type"] = "special";
						}
						break;
					}
					}
					break;
				case "special":
					key = "愚人节版";
					break;
				default:
					key = "远古版";
					break;
				}
				dictionary[key].Add(minecraftVersion);
			}
			foreach (KeyValuePair<string, List<JObject>> item in dictionary.ToList())
			{
				dictionary[item.Key] = item.Value.OrderByDescending((_Closure_0024__._0024I35_002D0 == null) ? (_Closure_0024__._0024I35_002D0 = [SpecialName] (JObject j) => j["releaseTime"].Value<DateTime>()) : _Closure_0024__._0024I35_002D0).ToList();
			}
			PanMinecraft.Children.Clear();
			MyCard myCard = new MyCard
			{
				Title = "最新版本",
				Margin = new Thickness(0.0, 15.0, 0.0, 15.0)
			};
			List<JObject> list = new List<JObject>();
			JObject jObject2 = (JObject)dictionary["正式版"][0].DeepClone();
			jObject2["lore"] = "最新正式版，发布于 " + jObject2["releaseTime"].Value<DateTime>().ToString("yyyy'/'MM'/'dd HH':'mm");
			list.Add(jObject2);
			if (DateTime.Compare(dictionary["正式版"][0]["releaseTime"].Value<DateTime>(), dictionary["预览版"][0]["releaseTime"].Value<DateTime>()) < 0)
			{
				JObject jObject3 = (JObject)dictionary["预览版"][0].DeepClone();
				jObject3["lore"] = "最新预览版，发布于 " + jObject3["releaseTime"].Value<DateTime>().ToString("yyyy'/'MM'/'dd HH':'mm");
				list.Add(jObject3);
			}
			StackPanel stackPanel = new StackPanel
			{
				Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
				VerticalAlignment = VerticalAlignment.Top,
				RenderTransform = new TranslateTransform(0.0, 0.0)
			};
			myCard.Children.Add(stackPanel);
			myCard.SwapControl = stackPanel;
			myCard.SetContentBuilder(list, [SpecialName] (JObject Version) => ModDownloadLib.McDownloadListItem(Version, [SpecialName] (object sender, MouseButtonEventArgs e) =>
			{
				MinecraftSelected((MyListItem)sender, e);
			}, IsSaveOnly: false));
			myCard.BuildContent();
			PanMinecraft.Children.Insert(0, myCard);
			foreach (KeyValuePair<string, List<JObject>> item2 in dictionary)
			{
				if (!item2.Value.Any())
				{
					continue;
				}
				MyCard myCard2 = new MyCard
				{
					Title = item2.Key,
					Margin = new Thickness(0.0, 0.0, 0.0, 15.0)
				};
				StackPanel stackPanel2 = new StackPanel
				{
					Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
					VerticalAlignment = VerticalAlignment.Top,
					RenderTransform = new TranslateTransform(0.0, 0.0)
				};
				myCard2.Children.Add(stackPanel2);
				myCard2.SwapControl = stackPanel2;
				myCard2.SetContentBuilder(item2.Value, [SpecialName] (JObject Version) => ModDownloadLib.McDownloadListItem(Version, [SpecialName] (object sender, MouseButtonEventArgs e) =>
				{
					MinecraftSelected((MyListItem)sender, e);
				}, IsSaveOnly: false));
				myCard2.IsSwapped = true;
				PanMinecraft.Children.Add(myCard2);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "可视化安装版本列表出错", LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
			ProjectData.ClearProjectError();
		}
	}

	private void TrySelectWaitingVersion()
	{
		if (VersionWaitingSelect == null)
		{
			return;
		}
		foreach (JObject minecraftVersion in MinecraftVersions)
		{
			if (Operators.CompareString(minecraftVersion["id"].ToString(), VersionWaitingSelect, TextCompare: false) == 0)
			{
				Logger.Info($"自动选择 MC 版本：{VersionWaitingSelect}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
				MinecraftSelected(ModDownloadLib.McDownloadListItem(minecraftVersion, null, IsSaveOnly: false).Init(), null);
				VersionWaitingSelect = null;
				break;
			}
		}
	}

	public string LoadOptiFineGetError()
	{
		if (SelectedNeoForge != null)
		{
			return "与 NeoForge 不兼容";
		}
		if (SelectedForge != null && McUtils.CompareVersionGE(VanillaName, "1.13") && McUtils.CompareVersionGE("1.14.3", VanillaName))
		{
			return "与 Forge 不兼容";
		}
		if (SelectedFabric != null && McUtils.CompareVersion(VanillaName, "1.20.4") > 0)
		{
			return "与 Fabric 不兼容";
		}
		if (GetLoaderError(LoadOptiFine) != null)
		{
			return GetLoaderError(LoadOptiFine);
		}
		bool flag = false;
		bool flag2 = false;
		foreach (ModDownload.DlOptiFineListEntry item in ModDownload.DlOptiFineListLoader.Output.Value)
		{
			if (item.DisplayName.StartsWithF(VanillaName + " "))
			{
				flag = true;
				if (SelectedForge == null)
				{
					return null;
				}
				if (IsOptiFineSuitForForge(item, SelectedForge))
				{
					return null;
				}
				if (item.RequiredForgeVersion != null)
				{
					flag2 = true;
				}
			}
		}
		if (!flag)
		{
			return "无";
		}
		if (flag2)
		{
			return "仅兼容特定版本的 Forge";
		}
		return "与 Forge 不兼容";
	}

	public static bool IsOptiFineSuitForForge(ModDownload.DlOptiFineListEntry OptiFine, ModDownload.DlForgeVersionEntry Forge)
	{
		if (Operators.CompareString(Forge.Inherit, OptiFine.Inherit, TextCompare: false) != 0)
		{
			return false;
		}
		if (OptiFine.RequiredForgeVersion == null)
		{
			return false;
		}
		if (string.IsNullOrWhiteSpace(OptiFine.RequiredForgeVersion))
		{
			return true;
		}
		if (OptiFine.RequiredForgeVersion.Contains("."))
		{
			return McUtils.CompareVersion(Forge.Version.ToString(), OptiFine.RequiredForgeVersion) == 0;
		}
		return (double)Forge.Version.Revision == Conversions.ToDouble(OptiFine.RequiredForgeVersion);
	}

	private void CardOptiFine_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadOptiFineGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void OptiFine_Loaded()
	{
		try
		{
			if (ModDownload.DlOptiFineListLoader.State != ModBase.LoadState.Finished)
			{
				return;
			}
			List<ModDownload.DlOptiFineListEntry> list = new List<ModDownload.DlOptiFineListEntry>();
			foreach (ModDownload.DlOptiFineListEntry item in ModDownload.DlOptiFineListLoader.Output.Value)
			{
				if ((SelectedForge == null || IsOptiFineSuitForForge(item, SelectedForge)) && item.DisplayName.StartsWithF(VanillaName + " "))
				{
					list.Add(item);
				}
			}
			if (!list.Any())
			{
				return;
			}
			list = ModBase.SortByComparison(list, [SpecialName] (ModDownload.DlOptiFineListEntry Left, ModDownload.DlOptiFineListEntry Right) =>
			{
				if (!Left.IsPreview && Right.IsPreview)
				{
					return true;
				}
				return (!Left.IsPreview || Right.IsPreview) && McUtils.CompareVersionGE(Left.DisplayName, Right.DisplayName);
			});
			PanOptiFine.Children.Clear();
			foreach (ModDownload.DlOptiFineListEntry item2 in list)
			{
				PanOptiFine.Children.Add(ModDownloadLib.OptiFineDownloadListItem(item2, [SpecialName] (object a0, MouseButtonEventArgs a1) =>
				{
					OptiFine_Selected((MyListItem)a0, a1);
				}, IsSaveOnly: false));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "可视化 OptiFine 安装版本列表出错", LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
			ProjectData.ClearProjectError();
		}
	}

	private void OptiFine_Selected(MyListItem sender, EventArgs e)
	{
		SelectedOptiFine = (ModDownload.DlOptiFineListEntry)sender.Tag;
		if (SelectedForge != null && !IsOptiFineSuitForForge(SelectedOptiFine, SelectedForge))
		{
			SelectedForge = null;
		}
		OptiFabric_Loaded();
		Forge_Loaded();
		NeoForge_Loaded();
		CardOptiFine.IsSwapped = true;
		ReloadSelected();
	}

	private void OptiFine_Clear(object sender, EventArgs e)
	{
		SelectedOptiFine = null;
		SelectedOptiFabric = null;
		BtnOptiFabricClear.Visibility = Visibility.Collapsed;
		AutoSelectedOptiFabric = false;
		CardOptiFine.IsSwapped = true;
		Forge_Loaded();
		NeoForge_Loaded();
		ReloadSelected();
	}

	public string LoadLiteLoaderGetError()
	{
		if (GetLoaderError(LoadLiteLoader) != null)
		{
			return GetLoaderError(LoadLiteLoader);
		}
		return ModDownload.DlLiteLoaderListLoader.Output.Value.Any([SpecialName] (ModDownload.DlLiteLoaderListEntry v) => Operators.CompareString(v.Inherit, VanillaName, TextCompare: false) == 0) ? null : "无";
	}

	private void CardLiteLoader_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadLiteLoaderGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void LiteLoader_Loaded()
	{
		try
		{
			if (ModDownload.DlLiteLoaderListLoader.State != ModBase.LoadState.Finished)
			{
				return;
			}
			List<ModDownload.DlLiteLoaderListEntry> list = new List<ModDownload.DlLiteLoaderListEntry>();
			foreach (ModDownload.DlLiteLoaderListEntry item in ModDownload.DlLiteLoaderListLoader.Output.Value)
			{
				if (Operators.CompareString(item.Inherit, VanillaName, TextCompare: false) == 0)
				{
					list.Add(item);
				}
			}
			if (!list.Any())
			{
				return;
			}
			PanLiteLoader.Children.Clear();
			foreach (ModDownload.DlLiteLoaderListEntry item2 in list)
			{
				PanLiteLoader.Children.Add(ModDownloadLib.LiteLoaderDownloadListItem(item2, [SpecialName] (object a0, MouseButtonEventArgs a1) =>
				{
					LiteLoader_Selected((MyListItem)a0, a1);
				}, IsSaveOnly: false));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "可视化 LiteLoader 安装版本列表出错", LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
			ProjectData.ClearProjectError();
		}
	}

	private void LiteLoader_Selected(MyListItem sender, EventArgs e)
	{
		SelectedLiteLoader = (ModDownload.DlLiteLoaderListEntry)sender.Tag;
		CardLiteLoader.IsSwapped = true;
		ReloadSelected();
	}

	private void LiteLoader_Clear(object sender, EventArgs e)
	{
		SelectedLiteLoader = null;
		CardLiteLoader.IsSwapped = true;
		ReloadSelected();
	}

	public string LoadForgeGetError()
	{
		if (McUtils.CompareVersionGE("1.5.1", VanillaName) && McUtils.CompareVersionGE(VanillaName, "1.1"))
		{
			return "无";
		}
		if (GetLoaderError(LoadForge) != null)
		{
			return GetLoaderError(LoadForge);
		}
		ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = (ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>)LoadForge.State;
		if (Operators.CompareString(VanillaName, loaderTask.Input, TextCompare: false) != 0)
		{
			return "获取中……";
		}
		foreach (ModDownload.DlForgeVersionEntry item in loaderTask.Output)
		{
			if (Operators.CompareString(item.Category, "universal", TextCompare: false) != 0 && Operators.CompareString(item.Category, "client", TextCompare: false) != 0)
			{
				if (SelectedNeoForge != null)
				{
					return "与 NeoForge 不兼容";
				}
				if (SelectedFabric != null)
				{
					return "与 Fabric 不兼容";
				}
				if (SelectedOptiFine != null && McUtils.CompareVersionGE(VanillaName, "1.13") && McUtils.CompareVersionGE("1.14.3", VanillaName))
				{
					return "与 OptiFine 不兼容";
				}
				if (SelectedOptiFine == null || IsOptiFineSuitForForge(SelectedOptiFine, item))
				{
					return null;
				}
			}
		}
		return "与 OptiFine 不兼容";
	}

	private void CardForge_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadForgeGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void Forge_Loaded()
	{
		try
		{
			if (!LoadForge.State.IsLoader)
			{
				return;
			}
			ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = (ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>)LoadForge.State;
			if (Operators.CompareString(VanillaName, loaderTask.Input, TextCompare: false) != 0 || loaderTask.State != ModBase.LoadState.Finished)
			{
				return;
			}
			List<ModDownload.DlForgeVersionEntry> source = loaderTask.Output.ToList();
			if (!loaderTask.Output.Any())
			{
				return;
			}
			PanForge.Children.Clear();
			source = (from v in source.Where([SpecialName] (ModDownload.DlForgeVersionEntry v) =>
				{
					if (Operators.CompareString(v.Category, "universal", TextCompare: false) == 0 || Operators.CompareString(v.Category, "client", TextCompare: false) == 0)
					{
						return false;
					}
					return (SelectedOptiFine == null || IsOptiFineSuitForForge(SelectedOptiFine, v)) ? true : false;
				})
				orderby v descending
				select v).ToList();
			ModDownloadLib.ForgeDownloadListItemPreload(PanForge, source, [SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				Forge_Selected((MyListItem)a0, a1);
			}, IsSaveOnly: false);
			foreach (ModDownload.DlForgeVersionEntry item in source)
			{
				PanForge.Children.Add(ModDownloadLib.ForgeDownloadListItem(item, [SpecialName] (object a0, MouseButtonEventArgs a1) =>
				{
					Forge_Selected((MyListItem)a0, a1);
				}, IsSaveOnly: false));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "可视化 Forge 安装版本列表出错", LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
			ProjectData.ClearProjectError();
		}
	}

	private void Forge_Selected(MyListItem sender, EventArgs e)
	{
		SelectedForge = (ModDownload.DlForgeVersionEntry)sender.Tag;
		CardForge.IsSwapped = true;
		if (SelectedOptiFine != null && !IsOptiFineSuitForForge(SelectedOptiFine, SelectedForge))
		{
			SelectedOptiFine = null;
		}
		OptiFine_Loaded();
		ReloadSelected();
	}

	private void Forge_Clear(object sender, EventArgs e)
	{
		SelectedForge = null;
		CardForge.IsSwapped = true;
		OptiFine_Loaded();
		ReloadSelected();
	}

	public string LoadNeoForgeGetError()
	{
		if (SelectedOptiFine != null)
		{
			return "与 OptiFine 不兼容";
		}
		if (SelectedForge != null)
		{
			return "与 Forge 不兼容";
		}
		if (SelectedFabric != null)
		{
			return "与 Fabric 不兼容";
		}
		if (GetLoaderError(LoadNeoForge) != null)
		{
			return GetLoaderError(LoadNeoForge);
		}
		return ModDownload.DlNeoForgeListLoader.Output.Value.Any([SpecialName] (ModDownload.DlNeoForgeListEntry v) => Operators.CompareString(v.Inherit, VanillaName, TextCompare: false) == 0) ? null : "无";
	}

	private void CardNeoForge_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadNeoForgeGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void NeoForge_Loaded()
	{
		try
		{
			if (ModDownload.DlNeoForgeListLoader.State != ModBase.LoadState.Finished)
			{
				return;
			}
			List<ModDownload.DlNeoForgeListEntry> list = ModDownload.DlNeoForgeListLoader.Output.Value.Where([SpecialName] (ModDownload.DlNeoForgeListEntry v) => Operators.CompareString(v.Inherit, VanillaName, TextCompare: false) == 0).ToList();
			if (!list.Any())
			{
				return;
			}
			PanNeoForge.Children.Clear();
			ModDownloadLib.NeoForgeDownloadListItemPreload(PanNeoForge, list, [SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				NeoForge_Selected((MyListItem)a0, a1);
			}, IsSaveOnly: false);
			foreach (ModDownload.DlNeoForgeListEntry item in list)
			{
				PanNeoForge.Children.Add(ModDownloadLib.NeoForgeDownloadListItem(item, [SpecialName] (object a0, MouseButtonEventArgs a1) =>
				{
					NeoForge_Selected((MyListItem)a0, a1);
				}, IsSaveOnly: false));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "可视化 NeoForge 安装版本列表出错", LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
			ProjectData.ClearProjectError();
		}
	}

	private void NeoForge_Selected(MyListItem sender, EventArgs e)
	{
		SelectedNeoForge = (ModDownload.DlNeoForgeListEntry)sender.Tag;
		CardNeoForge.IsSwapped = true;
		OptiFine_Loaded();
		ReloadSelected();
	}

	private void NeoForge_Clear(object sender, EventArgs e)
	{
		SelectedNeoForge = null;
		CardNeoForge.IsSwapped = true;
		OptiFine_Loaded();
		ReloadSelected();
	}

	public string LoadFabricGetError()
	{
		if (SelectedOptiFine != null && McUtils.CompareVersionGE(VanillaName, "1.20.5"))
		{
			return "与 OptiFine 不兼容";
		}
		if (GetLoaderError(LoadFabric) != null)
		{
			return GetLoaderError(LoadFabric);
		}
		foreach (JObject item in (IEnumerable<JToken>)ModDownload.DlFabricListLoader.Output.Value["game"])
		{
			if (Operators.CompareString(item["version"].ToString(), VanillaName.Replace("∞", "infinite").Replace("Combat Test 7c", "1.16_combat-3"), TextCompare: false) == 0)
			{
				if (SelectedForge != null)
				{
					return "与 Forge 不兼容";
				}
				if (SelectedNeoForge != null)
				{
					return "与 NeoForge 不兼容";
				}
				return null;
			}
		}
		return "无";
	}

	private void CardFabric_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadFabricGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void Fabric_Loaded()
	{
		try
		{
			if (ModDownload.DlFabricListLoader.State != ModBase.LoadState.Finished)
			{
				return;
			}
			JArray source = (JArray)ModDownload.DlFabricListLoader.Output.Value["loader"];
			if (!source.Any())
			{
				return;
			}
			PanFabric.Children.Clear();
			CardFabric.SwapControl = PanFabric;
			CardFabric.SetContentBuilder(source.OfType<JObject>(), [SpecialName] (JObject Version) => ModDownloadLib.FabricDownloadListItem(Version, [SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				Fabric_Selected((MyListItem)a0, a1);
			}));
			if (!CardFabric.IsSwapped)
			{
				CardFabric.BuildContent();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "可视化 Fabric 安装版本列表出错", LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
			ProjectData.ClearProjectError();
		}
	}

	public void Fabric_Selected(MyListItem sender, EventArgs e)
	{
		SelectedFabric = NewLateBinding.LateIndexGet(sender.Tag, new object[1] { "version" }, null).ToString();
		FabricApi_Loaded();
		OptiFabric_Loaded();
		CardFabric.IsSwapped = true;
		ReloadSelected();
	}

	private void Fabric_Clear(object sender, EventArgs e)
	{
		SelectedFabric = null;
		SelectedFabricApi = null;
		BtnFabricApiClear.Visibility = Visibility.Collapsed;
		AutoSelectedFabricApi = false;
		SelectedOptiFabric = null;
		BtnOptiFabricClear.Visibility = Visibility.Collapsed;
		AutoSelectedOptiFabric = false;
		CardFabric.IsSwapped = true;
		ReloadSelected();
	}

	public static bool IsFabricApiCompatible(ResourceVersion FabricApi, string MinecraftVersion)
	{
		string text = FabricApi.Display;
		checked
		{
			bool result;
			try
			{
				if (text == null || MinecraftVersion == null)
				{
					result = false;
				}
				else
				{
					text = text.Lower();
					string text2 = MinecraftVersion.Replace("∞", "infinite").Replace("Combat Test 7c", "1.16_combat-3").Lower();
					if (text.StartsWithF("[" + text2 + "]"))
					{
						result = true;
					}
					else if (!text.Contains("/") || !text.Contains("]"))
					{
						result = false;
					}
					else
					{
						string[] array = text.BeforeFirst("]").TrimStart('[').Split("/");
						int num = 0;
						while (true)
						{
							if (num < array.Length)
							{
								if (Operators.CompareString(array[num], text2, TextCompare: false) == 0)
								{
									result = true;
									break;
								}
								num++;
								continue;
							}
							List<string> list = text.BeforeFirst("]").RegexSearch("[a-z/]+|[0-9/]+").ToList();
							List<string> list2 = text2.BeforeFirst("]").RegexSearch("[a-z/]+|[0-9/]+").ToList();
							int num2 = 0;
							while (true)
							{
								if (list.Count - 1 < num2 && list2.Count - 1 < num2)
								{
									result = true;
									break;
								}
								string text3 = ((list.Count - 1 < num2) ? "-1" : list[num2]);
								string text4 = ((list2.Count - 1 < num2) ? "-1" : list2[num2]);
								if (!text3.Contains("/"))
								{
									if (Operators.CompareString(text3, text4, TextCompare: false) != 0)
									{
										result = false;
										break;
									}
								}
								else if (!text3.Contains(text4))
								{
									result = false;
									break;
								}
								num2++;
							}
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Logger.Warn(ex2, $"判断 Fabric API 版本适配性出错（{text}, {MinecraftVersion}）", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public string LoadFabricApiGetError()
	{
		if (GetLoaderError(LoadFabricApi) != null)
		{
			return GetLoaderError(LoadFabricApi);
		}
		if (ModDownload.DlFabricApiLoader.Output == null)
		{
			return (SelectedFabric == null) ? "需要安装 Fabric" : "获取中……";
		}
		if (ModDownload.DlFabricApiLoader.Output.Any([SpecialName] (ResourceVersion f) => IsFabricApiCompatible(f, VanillaName)))
		{
			return (SelectedFabric == null) ? "需要安装 Fabric" : null;
		}
		return "无";
	}

	private void CardFabricApi_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadFabricApiGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void FabricApi_Loaded()
	{
		try
		{
			if (ModDownload.DlFabricApiLoader.State != ModBase.LoadState.Finished || VanillaName == null || SelectedFabric == null)
			{
				return;
			}
			List<ResourceVersion> list = new List<ResourceVersion>();
			foreach (ResourceVersion item in ModDownload.DlFabricApiLoader.Output)
			{
				if (IsFabricApiCompatible(item, VanillaName))
				{
					if (!item.Display.StartsWithF("["))
					{
						Logger.Warn($"已特判修改 Fabric API 显示名：{item.Display}", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
						item.Display = "[" + VanillaName + "] " + item.Display;
					}
					list.Add(item);
				}
			}
			if (!list.Any())
			{
				return;
			}
			list = list.OrderByDescending([SpecialName] (ResourceVersion v) => v.ReleaseDate).ToList();
			PanFabricApi.Children.Clear();
			foreach (ResourceVersion item2 in list)
			{
				PanFabricApi.Children.Add(ModDownloadLib.FabricApiDownloadListItem(item2, [SpecialName] (object a0, MouseButtonEventArgs a1) =>
				{
					FabricApi_Selected((MyListItem)a0, a1);
				}));
			}
			if (!AutoSelectedFabricApi)
			{
				AutoSelectedFabricApi = true;
				MyListItem myListItem = (MyListItem)MyVirtualizingElement.TryInit((FrameworkElement)PanFabricApi.Children[0]);
				Logger.Info($"已自动选择 Fabric API：{myListItem.Title}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
				FabricApi_Selected(myListItem, null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "可视化 Fabric API 安装版本列表出错", LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
			ProjectData.ClearProjectError();
		}
	}

	private void FabricApi_Selected(MyListItem sender, EventArgs e)
	{
		SelectedFabricApi = (ResourceVersion)sender.Tag;
		CardFabricApi.IsSwapped = true;
		ReloadSelected();
	}

	private void FabricApi_Clear(object sender, EventArgs e)
	{
		SelectedFabricApi = null;
		CardFabricApi.IsSwapped = true;
		ReloadSelected();
	}

	public static bool IsOptiFabricCompatible(ResourceVersion ModFile, string MinecraftVersion)
	{
		bool result;
		try
		{
			result = MinecraftVersion != null && ModFile.GameVersions.Contains(MinecraftVersion);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Warn(ex2, $"判断 OptiFabric 版本适配性出错（{MinecraftVersion}）", LogBehavior.ToastIfDebug, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public string LoadOptiFabricGetError()
	{
		if (VanillaDrop >= 140 && VanillaDrop <= 150)
		{
			return "不兼容老版本 Fabric，请手动下载 OptiFabric Origins";
		}
		if (GetLoaderError(LoadOptiFabric) != null)
		{
			return GetLoaderError(LoadOptiFabric);
		}
		if (ModDownload.DlOptiFabricLoader.Output == null)
		{
			if (SelectedFabric == null && SelectedOptiFine == null)
			{
				return "需要安装 OptiFine 与 Fabric";
			}
			if (SelectedFabric == null)
			{
				return "需要安装 Fabric";
			}
			if (SelectedOptiFine == null)
			{
				return "需要安装 OptiFine";
			}
			return "获取中……";
		}
		foreach (ResourceVersion item in ModDownload.DlOptiFabricLoader.Output)
		{
			if (IsOptiFabricCompatible(item, VanillaName))
			{
				if (SelectedFabric == null && SelectedOptiFine == null)
				{
					return "需要安装 OptiFine 与 Fabric";
				}
				if (SelectedFabric == null)
				{
					return "需要安装 Fabric";
				}
				if (SelectedOptiFine == null)
				{
					return "需要安装 OptiFine";
				}
				return null;
			}
		}
		return "无";
	}

	private void CardOptiFabric_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadOptiFabricGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void OptiFabric_Loaded()
	{
		try
		{
			if (ModDownload.DlOptiFabricLoader.State != ModBase.LoadState.Finished || VanillaName == null || SelectedFabric == null || SelectedOptiFine == null)
			{
				return;
			}
			List<ResourceVersion> list = new List<ResourceVersion>();
			foreach (ResourceVersion item in ModDownload.DlOptiFabricLoader.Output)
			{
				if (IsOptiFabricCompatible(item, VanillaName))
				{
					list.Add(item);
				}
			}
			if (!list.Any())
			{
				return;
			}
			list = list.OrderByDescending([SpecialName] (ResourceVersion v) => v.ReleaseDate).ToList();
			PanOptiFabric.Children.Clear();
			foreach (ResourceVersion item2 in list)
			{
				PanOptiFabric.Children.Add(ModDownloadLib.OptiFabricDownloadListItem(item2, [SpecialName] (object a0, MouseButtonEventArgs a1) =>
				{
					OptiFabric_Selected((MyListItem)a0, a1);
				}));
			}
			if (!AutoSelectedOptiFabric && (VanillaDrop < 140 || VanillaDrop > 150))
			{
				AutoSelectedOptiFabric = true;
				MyListItem myListItem = (MyListItem)MyVirtualizingElement.TryInit((FrameworkElement)PanOptiFabric.Children[0]);
				Logger.Info($"已自动选择 OptiFabric：{myListItem.Title}", LogBehavior.None, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
				OptiFabric_Selected(myListItem, null);
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Logger.Error(ex2, "可视化 OptiFabric 安装版本列表出错", LogBehavior.AlertThenFeedback, "E:\\Projects\\PCL\\本体代码\\Plain Craft Launcher 2\\Pages\\PageDownload\\PageDownloadInstall.xaml.vb");
			ProjectData.ClearProjectError();
		}
	}

	private void OptiFabric_Selected(MyListItem sender, EventArgs e)
	{
		SelectedOptiFabric = (ResourceVersion)sender.Tag;
		CardOptiFabric.IsSwapped = true;
		ReloadSelected();
	}

	private void OptiFabric_Clear(object sender, EventArgs e)
	{
		SelectedOptiFabric = null;
		CardOptiFabric.IsSwapped = true;
		ReloadSelected();
	}

	public McComponents GetSelectedComponents()
	{
		return new McComponents(VanillaName, (SelectedOptiFine == null) ? null : JObject.FromObject(SelectedOptiFine), SelectedForge?.VersionName, SelectedNeoForge?.VersionName, SelectedFabric, SelectedFabricApi?.Version ?? SelectedFabricApi?.Id ?? SelectedFabricApi?.Display, SelectedOptiFabric?.Version ?? SelectedOptiFabric?.Id ?? SelectedOptiFabric?.Display, SelectedLiteLoader?.JsonToken?["version"].ToString());
	}

	private void TextSelectName_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.Key == Key.Return && IsInSelectPage && BtnStart.IsEnabled)
		{
			BtnStart_Click();
		}
	}

	private void BtnStart_Click()
	{
		string text = TextSelectName.Text;
		ModDownloadLib.McInstallRequest request = new ModDownloadLib.McInstallRequest
		{
			NewInstanceName = text,
			InstanceFolder = $"{ModMinecraft.McFolderSelected}versions\\{text}\\",
			Components = GetSelectedComponents(),
			MinecraftJson = VanillaData["url"].ToString(),
			ForgeEntry = SelectedForge,
			NeoForgeEntry = SelectedNeoForge,
			FabricApi = SelectedFabricApi,
			OptiFabric = SelectedOptiFabric,
			LiteLoaderEntry = SelectedLiteLoader
		};
		StartInstall(request);
	}

	public virtual void StartInstall(ModDownloadLib.McInstallRequest Request)
	{
		if (((SelectedForge == null && SelectedNeoForge == null && SelectedFabric == null) || (Settings.Get<int>("LaunchArgumentIndieV2") != 0 && Settings.Get<int>("LaunchArgumentIndieV2") != 2) || ModMain.MyMsgBox("你尚未开启版本隔离，多个 MC 版本会共用同一个 Mod 文件夹。\r\n因此，游戏可能会因为读取到与当前版本不符的 Mod 而崩溃。\r\n推荐先在 设置 → 启动选项 → 默认版本隔离 中开启版本隔离！", "版本隔离提示", "取消下载", "继续") != 1) && ModDownloadLib.McInstallStart(Request))
		{
			ExitSelectPage();
		}
	}

	private string GetLoaderError(MyLoading Loader)
	{
		if (Loader == null)
		{
			return "获取中……";
		}
		if (!Loader.State.IsLoader)
		{
			return "获取中……";
		}
		switch (Loader.State.LoadingState)
		{
		case MyLoading.MyLoadingState.Run:
			return "获取中……";
		case MyLoading.MyLoadingState.Error:
		{
			string message = ((ModLoader.LoaderBase)Loader.State).Error.Message;
			return (Operators.CompareString(message, "无", TextCompare: false) == 0) ? "无" : ("获取失败：" + message);
		}
		case MyLoading.MyLoadingState.Unloaded:
			return "未知错误，状态为 Unloaded";
		default:
			return null;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
