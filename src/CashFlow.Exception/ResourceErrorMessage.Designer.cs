﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CashFlow.Exception {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceErrorMessage {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceErrorMessage() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CashFlow.Exception.ResourceErrorMessage", typeof(ResourceErrorMessage).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The amount must be greater than zero.
        /// </summary>
        public static string AMOUNT_MUST_GREATER_THAN_ZERO_ERROR {
            get {
                return ResourceManager.GetString("AMOUNT_MUST_GREATER_THAN_ZERO_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This email already exists..
        /// </summary>
        public static string EMAIL_ALREADY_EXISTS {
            get {
                return ResourceManager.GetString("EMAIL_ALREADY_EXISTS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This e-mail is invalid..
        /// </summary>
        public static string EMAIL_EMPTY {
            get {
                return ResourceManager.GetString("EMAIL_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This e-mail is invalid..
        /// </summary>
        public static string EMAIL_INVALID {
            get {
                return ResourceManager.GetString("EMAIL_INVALID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to E-mail or password is invalid..
        /// </summary>
        public static string EMAIL_OR_PASSWORD_INVALID {
            get {
                return ResourceManager.GetString("EMAIL_OR_PASSWORD_INVALID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expenses cannot be for the future.
        /// </summary>
        public static string EXPENSE_CANNOT_FOR_THE_FUTURE_ERROR {
            get {
                return ResourceManager.GetString("EXPENSE_CANNOT_FOR_THE_FUTURE_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expense not found.
        /// </summary>
        public static string EXPENSE_NOT_FOUND {
            get {
                return ResourceManager.GetString("EXPENSE_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This name is invalid..
        /// </summary>
        public static string NAME_EMPTY {
            get {
                return ResourceManager.GetString("NAME_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your password must be at least 8 characters long, containing at least one uppercase letter, one lowercase letter, one number, and one special character..
        /// </summary>
        public static string PASSWORD_INVALID {
            get {
                return ResourceManager.GetString("PASSWORD_INVALID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Payment type is not valid.
        /// </summary>
        public static string PAYMENT_TYPE_INVALID_ERROR {
            get {
                return ResourceManager.GetString("PAYMENT_TYPE_INVALID_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Expense Tag not supported..
        /// </summary>
        public static string TAG_TYPE_NOT_SUPPORTED_ERROR {
            get {
                return ResourceManager.GetString("TAG_TYPE_NOT_SUPPORTED_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The title is required.
        /// </summary>
        public static string TITLE_IS_REQUIRED_ERROR {
            get {
                return ResourceManager.GetString("TITLE_IS_REQUIRED_ERROR", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown Error.
        /// </summary>
        public static string UNKNOWN_ERROR {
            get {
                return ResourceManager.GetString("UNKNOWN_ERROR", resourceCulture);
            }
        }
    }
}
