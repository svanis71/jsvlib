﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace MySecurity
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class WebdbModel : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new WebdbModel object using the connection string found in the 'WebdbModel' section of the application configuration file.
        /// </summary>
        public WebdbModel() : base("name=WebdbModel", "WebdbModel")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new WebdbModel object.
        /// </summary>
        public WebdbModel(string connectionString) : base(connectionString, "WebdbModel")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new WebdbModel object.
        /// </summary>
        public WebdbModel(EntityConnection connection) : base(connection, "WebdbModel")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<users> users
        {
            get
            {
                if ((_users == null))
                {
                    _users = base.CreateObjectSet<users>("users");
                }
                return _users;
            }
        }
        private ObjectSet<users> _users;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the users EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTousers(users users)
        {
            base.AddObject("users", users);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="UserModel", Name="users")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class users : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new users object.
        /// </summary>
        /// <param name="userName">Initial value of the userName property.</param>
        /// <param name="email">Initial value of the email property.</param>
        /// <param name="openId">Initial value of the openId property.</param>
        public static users Createusers(global::System.String userName, global::System.String email, global::System.String openId)
        {
            users users = new users();
            users.userName = userName;
            users.email = email;
            users.openId = openId;
            return users;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String userName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (_userName != value)
                {
                    OnuserNameChanging(value);
                    ReportPropertyChanging("userName");
                    _userName = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("userName");
                    OnuserNameChanged();
                }
            }
        }
        private global::System.String _userName;
        partial void OnuserNameChanging(global::System.String value);
        partial void OnuserNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String email
        {
            get
            {
                return _email;
            }
            set
            {
                OnemailChanging(value);
                ReportPropertyChanging("email");
                _email = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("email");
                OnemailChanged();
            }
        }
        private global::System.String _email;
        partial void OnemailChanging(global::System.String value);
        partial void OnemailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String openId
        {
            get
            {
                return _openId;
            }
            set
            {
                OnopenIdChanging(value);
                ReportPropertyChanging("openId");
                _openId = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("openId");
                OnopenIdChanged();
            }
        }
        private global::System.String _openId;
        partial void OnopenIdChanging(global::System.String value);
        partial void OnopenIdChanged();

        #endregion
    
    }

    #endregion
    
}
