using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public partial class PageDownloadShader : MyPageRight, IComponentConnector
{
	[field: AccessedThroughProperty("Content")]
	internal virtual PageResource Content
	{
		get;
		[MethodImpl(MethodImplOptions.Synchronized)]
		set;
	}

	public PageDownloadShader()
	{
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
