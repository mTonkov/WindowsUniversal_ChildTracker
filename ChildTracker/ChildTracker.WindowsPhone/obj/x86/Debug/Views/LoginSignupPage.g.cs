﻿

#pragma checksum "C:\Users\M.Tonkov\Desktop\ChildTracker\WindowsUniversal_ChildTracker\ChildTracker\ChildTracker.Shared\Views\LoginSignupPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "917B3DF1446268B20F32FD143176B03D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChildTracker
{
    partial class LoginSignupPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 30 "..\..\..\Views\LoginSignupPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.OnLoginChildClick;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 31 "..\..\..\Views\LoginSignupPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.OnLoginParentClick;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 33 "..\..\..\Views\LoginSignupPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.OnSignUpClick;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


