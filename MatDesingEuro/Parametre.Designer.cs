﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MatDesingEuro {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.7.0.0")]
    internal sealed partial class Parametre : global::System.Configuration.ApplicationSettingsBase {
        
        private static Parametre defaultInstance = ((Parametre)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Parametre())));
        
        public static Parametre Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost/Euro/version.txt")]
        public string version {
            get {
                return ((string)(this["version"]));
            }
        }
    }
}
