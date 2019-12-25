﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasterMind.ConsoleApp.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class StaticConsoleTexts {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StaticConsoleTexts() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MasterMind.ConsoleApp.Resources.StaticConsoleTexts", typeof(StaticConsoleTexts).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///Pierwszy gracz ustala kod (sekretny) składający się z 4 kolorów -kolejność ma znaczenie, kolory mogą się powtarzać. 
        ///1) Podaje swoją kombinację 4 kolorów w odpowiedniej kolejności 
        ///a. Pierwszy gracz weryfikuje propozycję i odpowiada, podając liczbę trafień dokładnych (tzn. właściwy kolor na właściwej pozycji - odpowiednia liczba kółek czarnych) oraz trafień niedokładnych (tzn. właściwy kolor na niewłaściwej pozycji - odpowiednia liczba kółek białych) 
        ///b. Kroki powyższe powtarzane są wielokrotnie 
        ///c. D [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string GameRules {
            get {
                return ResourceManager.GetString("GameRules", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///Wybierz opcję: 
        ///1 - rozpoczęcie gry.
        ///2 - wyświetlenie zasad gry.
        ///.
        /// </summary>
        internal static string Options {
            get {
                return ResourceManager.GetString("Options", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///Chcesz spróbować ponownie? Wciśnij Y aby zatwierdzić.
        /// </summary>
        internal static string PlayAgain {
            get {
                return ResourceManager.GetString("PlayAgain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///Proszę spróbować jeszcze raz..
        /// </summary>
        internal static string TryAgain {
            get {
                return ResourceManager.GetString("TryAgain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Witaj w grze Mastermind!.
        /// </summary>
        internal static string WelcomeScreen {
            get {
                return ResourceManager.GetString("WelcomeScreen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///Zły kolor! Spróbuj ponownie!.
        /// </summary>
        internal static string WrongColor {
            get {
                return ResourceManager.GetString("WrongColor", resourceCulture);
            }
        }
    }
}